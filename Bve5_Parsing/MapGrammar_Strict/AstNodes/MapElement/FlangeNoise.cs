using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Strict.AstNodes.FlangeNoise
{
    /*
     * FlangeNoiseのAST木定義
     */

    /// <summary>
    /// FlangeNoise.Change(index)
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("index", nodes[2]);
        }
    }
}
