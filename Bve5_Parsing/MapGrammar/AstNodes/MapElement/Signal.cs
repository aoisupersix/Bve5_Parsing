using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Signal
{
    /*
     * SignalのAST木定義
     */

    /// <summary>
    /// Signal['signalAspectKey'].Put(section, trackkey, x, y) | Signal['signalAspectKey'].Put(section, trackkey, x, y, z, rx, ry, rz, tilt, span)
    /// </summary>
    public class PutNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("section", nodes[3]);
            AddArguments("trackkey", nodes[4]);
            AddArguments("x", nodes[5]);
            AddArguments("y", nodes[6]);
            if(nodes.Count > 7)
            {
                AddArguments("z", nodes[7]);
                AddArguments("rx", nodes[8]);
                AddArguments("ry", nodes[9]);
                AddArguments("rz", nodes[10]);
                AddArguments("tilt", nodes[11]);
                AddArguments("span", nodes[12]);
            }
        }
    }
}
