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
            AddArguments("section", nodes, 3, typeof(double));
            AddArguments("trackkey", nodes, 4, typeof(string));
            AddArguments("x", nodes, 5, typeof(double));
            AddArguments("y", nodes, 6, typeof(double));
            if(nodes.Count > 7)
            {
                AddArguments("z", nodes, 7, typeof(double));
                AddArguments("rx", nodes, 8, typeof(double));
                AddArguments("ry", nodes, 9, typeof(double));
                AddArguments("rz", nodes, 10, typeof(double));
                AddArguments("tilt", nodes, 11, typeof(double));
                AddArguments("span", nodes, 12, typeof(double));
            }
        }
    }
}
