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
            FilePath = (string)nodes[2].Token.Value;

            AddChild("Element-" + ElementName, nodes[0]);
            AddChild("FilePath-" + FilePath, nodes[2]);

        }
    }

    /// <summary>
    /// Syntax_1~3の親クラス
    /// </summary>
    public class Syntax : AstNode
    {
        public SyntaxData Data { get; protected set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Data = new SyntaxData();
        }

        /// <summary>
        /// 引数をDataに登録する
        /// </summary>
        /// <param name="argName">登録する引数名</param>
        /// <param name="nodes">構文の子ノード</param>
        /// <param name="idx">引数のインデックス</param>
        protected void AddArguments(string argName, ParseTreeNodeList nodes, int idx, System.Type type = null)
        {
            if (nodes.Count > idx)
            {
                object val;
                if (nodes[idx].ToString().Equals("Expr"))
                {
                    //引数が数式
                    ExprNode expr = (ExprNode)nodes[idx].AstNode;
                    val = expr.Value;
                    AddChild(argName + "=" + expr.Value, nodes[idx]);
                }
                else if (nodes[idx].ToString().Equals("NullableExpr"))
                {
                    //null許容数式
                    NullableExprNode expr = (NullableExprNode)nodes[idx].AstNode;
                    val = expr.Value;
                    AddChild(argName + "=" + expr.Value, nodes[idx]);
                }
                else if (nodes[idx].ToString().Equals("RawKey"))
                {
                    //RawKey
                    RawKeyNode rawKey = (RawKeyNode)nodes[idx].AstNode;
                    val = rawKey.Value;
                    AddChild(argName + "=" + rawKey.Value, nodes[idx]);
                }
                else
                {
                    //引数がキー
                    val = nodes[idx].Token.Value.ToString();
                    AddChild(argName + "=" + nodes[idx].Token.Value, nodes[idx]);
                }

                if(type == null)
                {
                    //引数の型を無視して登録
                    Data.Arguments.Add(argName, val);
                }
                else if(type == val.GetType())
                {
                    //型が一致するので引数に登録
                    Data.Arguments.Add(argName, val);
                }
                else
                {
                    //引数が指定された型と異なる
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
            Data.Key = nodes[1].Token.Value.ToString();
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
            Data.Key = nodes[1].Token.Value.ToString();
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

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素の登録
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString();

            //引数の登録
            AddArguments("mapPath", nodes, 1);

            string filePath = nodes[1].Token.Value.ToString();
            if (System.IO.File.Exists(filePath))
            {
                //ファイル読み込み
                StreamReader sr = new StreamReader(filePath);
                string input = sr.ReadToEnd();

                //構文解析
                ScriptApp app = new ScriptApp(new LanguageData(new MapGrammar()));
                try
                {
                    MapData result = (MapData)app.Evaluate(input);
                }
                catch (ScriptException e)
                {
                    LogMessageList parseTree = app.GetParserMessages();

                    if (parseTree.Count > 0)
                    {
                        foreach (var err in parseTree)
                        {
                            throw new ScriptException(filePath + ": " + err.Message, null, err.Location, null);
                        }
                    }
                    else
                    {
                        //Other error
                        throw e;
                    }
                }
            }
            else
            {
                //ファイルが存在しない
                throw new ScriptException(filePath + "が見つかりません", new System.IO.FileNotFoundException(), this.Location, new ScriptStackTrace());
            }
        }
    }

}
