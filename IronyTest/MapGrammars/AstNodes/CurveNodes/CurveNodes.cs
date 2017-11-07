using System.Collections.Generic;
using System.Text.RegularExpressions;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.CurveNodes
{
    /*
     * CurveのAST木定義
     */

    /// <summary>
    /// Curve.SetGauge(value)
    /// </summary>
    public class SetGaugeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("value", nodes[2]);
        }
    }

    /// <summary>
    /// Curve.Begin(radius, cant) | Curve.Begin(radius)
    /// </summary>
    public class BeginNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            //TODO
        }
    }
}
