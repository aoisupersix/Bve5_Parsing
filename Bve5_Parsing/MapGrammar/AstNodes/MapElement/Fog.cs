using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Fog
{
    /*
     * FogのAST木定義
     */

    /// <summary>
    /// Fog.Interpolate(red, green, blue)
    /// </summary>
    public class InterpolateNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録 0~1 TODO
            if(nodes.Count > 2)
            {
                AddArguments("density", nodes, 2);
                if(nodes.Count > 3)
                {
                    AddArguments("red", nodes, 3);
                    AddArguments("green", nodes, 4);
                    AddArguments("blue", nodes, 5);
                }
            }
        }
    }
}
