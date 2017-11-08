using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.CabilluminanceNodes
{
    /*
     * CabilluminanceのAST木定義
     */

    /// <summary>
    /// Cabilluminance.Interpolate(value) | Cabilluminance.Interpolate()
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if(nodes.Count > 2)
                AddArguments("value", nodes[2]);
        }
    }
}
