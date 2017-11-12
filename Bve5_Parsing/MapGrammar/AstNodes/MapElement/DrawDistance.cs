using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.DrawDistance
{
    /*
     * DrawDistanceのAST木定義
     */

    /// <summary>
    /// DrawDistance.Change(value)
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("value", nodes[2]);
        }
    }
}
