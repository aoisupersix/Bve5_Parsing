using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes
{
    /// <summary>
    /// 構文情報を管理する構造体
    /// </summary>
    public class SyntaxData
    {
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
            //括弧を削除
            FilePath = FilePath.Substring(0, FilePath.Length - 1);

            AddChild("Element-" + ElementName, nodes[0]);
            AddChild("FilePath-" + FilePath, nodes[2]);
        }
    }

    /// <summary>
    /// 構文の親クラス
    /// マップ要素.関数(引数,引数,...);
    /// </summary>
    public class Syntax_1 : AstNode
    {
        public SyntaxData Data { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素と関数の登録
            Data = new SyntaxData();
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString();
            Data.Function = nodes[1].Term.ToString();

            //引数は子クラスで登録する
        }

        /// <summary>
        /// 引数を登録する
        /// </summary>
        /// <param name="argName">引数名</param>
        /// <param name="node">引数のnode</param>
        protected void AddArguments(string argName, ParseTreeNode node)
        {
            if (node.ToString().Equals("Expr"))
            {
                //引数が数式
                ExprNode expr = (ExprNode)node.AstNode;
                Data.Arguments.Add(argName, expr.Value);
                AddChild(argName + "=" + expr.Value, node);
            }
            else
            {
                //引数がキー
                Data.Arguments.Add(argName, node.Token.Value);
                AddChild(argName + "=" + node.Token.Value, node);
            }
        }
    }

    /// <summary>
    /// 構文の親クラス
    /// マップ要素[キー].関数(引数,引数,...);
    /// </summary>
    public class Syntax_2 : AstNode
    {
        public SyntaxData Data { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data = new SyntaxData();
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString();
            Data.Key = (string)nodes[1].Token.Value;
            Data.Function = nodes[2].Term.ToString();

            //引数は子クラスで登録する
        }

        /// <summary>
        /// 引数を登録する
        /// </summary>
        /// <param name="argName">引数名</param>
        /// <param name="node">引数のnode</param>
        protected void AddArguments(string argName, ParseTreeNode node)
        {
            if (node.ToString().Equals("Expr"))
            {
                //引数が数式
                ExprNode expr = (ExprNode)node.AstNode;
                Data.Arguments.Add(argName, expr.Value);
                AddChild(argName + "=" + expr.Value, node);
            }
            else
            {
                //引数がキー
                Data.Arguments.Add(argName, node.Token.Value);
                AddChild(argName + "=" + node.Token.Value, node);
            }
        }
    }

    /// <summary>
    /// 構文の親クラス
    /// マップ要素[キー].マップ要素.関数(引数,引数,...);
    /// </summary>
    public class Syntax_3 : AstNode
    {
        public SyntaxData Data { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data = new SyntaxData();
            Data.MapElement = new string[2];
            Data.MapElement[0] = nodes[0].Term.ToString();
            Data.Key = (string)nodes[1].Token.Value;
            Data.MapElement[0] = nodes[2].Term.ToString();
            Data.Function = nodes[3].Term.ToString();

            //引数は子クラスで登録する
        }

        /// <summary>
        /// 引数を登録する
        /// </summary>
        /// <param name="argName">引数名</param>
        /// <param name="node">引数のnode</param>
        protected void AddArguments(string argName, ParseTreeNode node)
        {
            if (node.ToString().Equals("Expr"))
            {
                //引数が数式
                ExprNode expr = (ExprNode)node.AstNode;
                Data.Arguments.Add(argName, expr.Value);
                AddChild(argName + "=" + expr.Value, node);
            }
            else
            {
                //引数がキー
                Data.Arguments.Add(argName, node.Token.Value);
                AddChild(argName + "=" + node.Token.Value, node);
            }
        }
    }

}
