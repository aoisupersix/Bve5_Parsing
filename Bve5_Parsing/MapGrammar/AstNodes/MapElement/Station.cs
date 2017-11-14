using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Station
{
    /*
     * StationのAST木定義
     */

    /// <summary>
    /// Station['stationkey'].Put(door, margin1, margin2)
    /// </summary>
    public class PutNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("door", nodes, 3);
            AddArguments("margin1", nodes, 4);
            AddArguments("margin2", nodes, 5);
        }
    }
}
