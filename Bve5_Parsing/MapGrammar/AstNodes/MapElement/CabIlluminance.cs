using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.CabIlluminance
{
    /*
     * CabIlluminanceのAST木定義
     */

    /// <summary>
    /// CabIlluminance.Interpolate(value) | CabIlluminance.Interpolate()
    /// </summary>
    public class InterpolateNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if(nodes.Count > 2)
                AddArguments("value", nodes, 2, typeof(double));
        }
    }
}
