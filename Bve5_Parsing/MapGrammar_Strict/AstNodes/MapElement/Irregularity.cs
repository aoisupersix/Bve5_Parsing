using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Strict.AstNodes.Irregularity
{
    /*
     * IrregularityのAST木定義
     */

    /// <summary>
    /// Irregularity.Change(x, y, r, lx, ly, lr)
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("x", nodes[2]);
            AddArguments("y", nodes[3]);
            AddArguments("r", nodes[4]);
            AddArguments("lx", nodes[5]);
            AddArguments("ly", nodes[6]);
            AddArguments("lr", nodes[7]);
        }
    }
}
