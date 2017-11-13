using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Strict.AstNodes.Sound3D
{
    /*
     * Sound3DのAST木定義
     */

    /// <summary>
    /// Sound[key].Put(x, y)
    /// </summary>
    public class PutNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("x", nodes[3]);
            AddArguments("y", nodes[4]);
        }
    }
}
