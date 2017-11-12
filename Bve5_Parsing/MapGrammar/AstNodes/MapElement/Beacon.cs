using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Beacon
{
    /*
     * BeaconのAST木定義
     */

    /// <summary>
    /// Beacon.Put(type, section, sendData)
    /// </summary>
    public class PutNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("type", nodes[2]); //整数 TODO
            AddArguments("section", nodes[3]);
            AddArguments("sendData", nodes[4]); //整数 TODO
        }
    }
}
