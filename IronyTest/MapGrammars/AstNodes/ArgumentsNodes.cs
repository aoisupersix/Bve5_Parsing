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
    /// 引数？
    /// 引数があるかないか
    /// </summary>
    public class ArgsNode : AstNode
    {
        public AstNode Arg { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if (nodes.Count > 0)
                Arg = AddChild("Arg", nodes[0]);
        }
    }

    /// <summary>
    /// 引数リスト
    /// </summary>
    public class ArgNode : AstNode
    {
        public object[] Arg { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //Argに引数を代入していく。サイズは1つ目+2つ目以降の数
            Arg = new object[nodes.Count + nodes[1].ChildNodes.Count];

            //一つ目の引数
            Arg[0] = GetArgument(nodes[0]);
            AddChild("Arg[0]=" + Arg[0], nodes[0]);

            //二つ目以降の引数
            for (int i = 0; i < nodes[1].ChildNodes.Count; i++)
            {
                Arg[i + 1] = GetArgument(nodes[1].ChildNodes[i]);
                AddChild("Arg[" + (i + 1) + "]=" + Arg[i + 1], nodes[1].ChildNodes[i]);
            }
        }

        /// <summary>
        /// 引数の実体の取得
        /// </summary>
        /// <param name="node">取得するノード</param>
        /// <returns>引数</returns>
        private object GetArgument(ParseTreeNode node)
        {
            string term = node.ToString();
            if (Regex.IsMatch(term, "Expr"))
            {
                //引数が数式
                ExprNode expr = (ExprNode)node.AstNode;
                return expr.Value;
            }
            else
            {
                //引数がキー
                return node.Token.Value;
            }
        }
    }

    /// <summary>
    /// 二つ目以降の引数
    /// </summary>
    public class NextArgsNode : AstNode
    {
        public AstNode[] NextArg { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            NextArg = new AstNode[nodes.Count];
            for (int i = 0; i < NextArg.Length; i++)
            {
                NextArg[i] = AddChild("NextArg[" + i + "]", nodes[i]);
            }
        }
    }
}
