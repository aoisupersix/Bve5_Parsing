using System.Collections.Generic;
using System.Text.RegularExpressions;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.CurveNodes
{
    public class SetGaugeNode : AstNode
    {
        public SyntaxData Data { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //Dataに構文情報を格納していく
            Data = new SyntaxData();
            Data.MapElement = new string[1];
            Data.MapElement[0] = nodes[0].Term.ToString();
        }
    }
}
