using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless.AstNodes.Adhesion
{
    /*
     * AdhesionのAST木定義
     */

    /// <summary>
    /// Adhesion.Change(a) | Adhesion(a, b, c)
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("a", nodes, 2);
            if(nodes.Count > 3)
            {
                AddArguments("b", nodes, 3);
                AddArguments("c", nodes, 4);
            }
        }
    }
}
