using System.Collections.Generic;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using Irony.Interpreter;
using System.IO;
using Irony;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /// <summary>
    /// 構文情報を管理する構造体
    /// </summary>
    public class SyntaxData
    {
        public double Distance { get; set; }
        public string[] MapElement { get; set; }
        public string Key { get; set; }
        public string Function { get; set; }
        public Dictionary<string, object> Arguments { get; set; }

        public SyntaxData()
        {
            Arguments = new Dictionary<string, object>();
        }

    }

    /// <summary>
    /// 定義ファイルの読み込み構文
    /// </summary>
    public class LoadListFileNode : AstNode
    {
        public string ElementName { get; private set; }
        public string FilePath { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            ElementName = nodes[0].Term.ToString();
            IdentifierKeyNode idenKey = (IdentifierKeyNode)nodes[2].AstNode;
            FilePath = idenKey.Value;

            AddChild("Element=" + ElementName, nodes[0]);
            AddChild("FilePath=" + FilePath, nodes[2]);

        }
    }

    /// <summary>
    /// Syntax_1~3の親クラス
    /// </summary>
    public class Syntax : AstNode
    {
        public SyntaxData Data { get; protected set; }
        public AstContext Context { get; protected set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Data = new SyntaxData();

            Context = context;
        }

        /// <summary>
        /// 引数をDataに登録する
        /// </summary>
        /// <param name="argName">登録する引数名</param>
        /// <param name="nodes">構文の子ノード</param>
        /// <param name="idx">引数のインデックス</param>
        /// <param name="type">引数に指定する型(Optional)</param>
        protected void AddArguments(string argName, ParseTreeNodeList nodes, int idx, System.Type type = null)
        {
            object node = nodes[idx].AstNode;
            object val;

            /*
             * 引数の値を取得
             */
            if (node.GetType() == typeof(ExprNode))
            {
                //引数が数式
                ExprNode expr = (ExprNode)node;
                val = expr.Value;
                AddChild(argName + "=" + expr.Value, nodes[idx]);
            }
            else if (node.GetType() == typeof(NullableExprNode))
            {
                //null許容数式
                NullableExprNode expr = (NullableExprNode)node;
                val = expr.Value;
                AddChild(argName + "=" + expr.Value, nodes[idx]);
            }
            else if (node.GetType() == typeof(IdentifierKeyNode))
            {
                //IdenKey
                IdentifierKeyNode idenKey = (IdentifierKeyNode)node;
                val = idenKey.Value;
                AddChild(argName + "=" + idenKey.Value, nodes[idx]);
            }
            else if (node.GetType() == typeof(RawKeyNode))
            {
                //RawKey
                RawKeyNode rawKey = (RawKeyNode)node;
                val = rawKey.Value;
                AddChild(argName + "=" + rawKey.Value, nodes[idx]);
            }
            else
            {
                //引数がキー
                val = nodes[idx].Token.Value.ToString();
                AddChild(argName + "=" + nodes[idx].Token.Value, nodes[idx]);
            }

            /*
             * 取得した値の登録
             */
            if (type == null)
            {
                //引数の型を無視して登録
                Data.Arguments.Add(argName, val);
            }
            else
            {
                //引数の型に変換して登録
                try
                {
                    var v = System.Convert.ChangeType(val, type);
                    Data.Arguments.Add(argName, v);

                }
                catch (System.FormatException e)
                {
                    LogMessage logMessage = new LogMessage(ErrorLevel.Error, this.Location, e.Message, Context.Language.ParserData.States[Context.Language.ParserData.States.Count - 1]);
                    Context.Messages.Add(logMessage);
                }
            }
        }
    }

    /// <summary>
    /// 構文の親クラス
    /// マップ要素.関数(引数,引数,...);
    /// </summary>
    public class Syntax_1 : Syntax
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素と関数の登録
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString();
            Data.Function = nodes[1].Term.ToString();

            //引数は子クラスで登録する
        }
    }

    /// <summary>
    /// 構文の親クラス
    /// マップ要素[キー].関数(引数,引数,...);
    /// </summary>
    public class Syntax_2 : Syntax
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString();
            IdentifierKeyNode idenKey = (IdentifierKeyNode)nodes[1].AstNode;
            Data.Key = idenKey.Value;
            Data.Function = nodes[2].Term.ToString();

            //引数は子クラスで登録する
        }
    }

    /// <summary>
    /// 構文の親クラス
    /// マップ要素[キー].マップ要素.関数(引数,引数,...);
    /// </summary>
    public class Syntax_3 : Syntax
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data.MapElement = new string[2];
            Data.MapElement[0] = nodes[0].Term.ToString();
            IdentifierKeyNode idenKey = (IdentifierKeyNode)nodes[1].AstNode;
            Data.Key = idenKey.Value;
            Data.MapElement[1] = nodes[2].Term.ToString();
            Data.Function = nodes[3].Term.ToString();

            //引数は子クラスで登録する
        }
    }

    /// <summary>
    /// Include構文(この構文だけ形式が違うので特別に扱う)
    /// include 'key';
    /// </summary>
    public class IncludeNode : Syntax
    {
        public MapData IncludeData { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素の登録
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString().ToLower();

            //引数の登録
            AddArguments("mapPath", nodes, 1, typeof(string));

            IdentifierKeyNode idenKey = (IdentifierKeyNode)nodes[1].AstNode;
            string filePath = idenKey.Value;
            if (System.IO.File.Exists(filePath))
            {
                //ファイル読み込み
                StreamReader sr = new StreamReader(filePath);
                string input = sr.ReadToEnd();

                //構文解析
                ScriptApp app = new ScriptApp(new LanguageData(new MapGrammar()));
                try
                {
                    IncludeData = (MapData)app.Evaluate(input);
                }
                catch (ScriptException)
                {
                    LogMessageList parseTree = app.GetParserMessages();
                    context.Messages.AddRange(parseTree);
                }
            }
            else
            {
                //ファイルが存在しない
                LogMessage logMessage = new LogMessage(ErrorLevel.Error, this.Location, filePath + "が見つかりません", context.Language.ParserData.States[context.Language.ParserData.States.Count - 1]);
                context.Messages.Add(logMessage);
            }
        }
    }

}
