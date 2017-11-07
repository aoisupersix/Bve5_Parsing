using System.Collections.Generic;
using System.Text.RegularExpressions;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.CurveNodes
{
    public class SetGaugeNode : Syntax_1
    {

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            ExprNode expr = (ExprNode)nodes[2].AstNode;
            Data.Arguments.Add("value", expr.Value);
            AddChild("Value", nodes[2]);
        }
    }
}
