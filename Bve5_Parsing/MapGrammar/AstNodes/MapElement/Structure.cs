using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.Structure
{
    /*
     * TrackのAST木定義
     */

    /// <summary>
    /// Structure[key].Put(trackkey, x, y, z, rx, ry, rz, tilt, span)
    /// </summary>
    public class PutNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("trackkey", nodes[3]);
            AddArguments("x", nodes[4]);
            AddArguments("y", nodes[5]);
            AddArguments("z", nodes[6]);
            AddArguments("rx", nodes[7]);
            AddArguments("ry", nodes[8]);
            AddArguments("rz", nodes[9]);
            AddArguments("tilt", nodes[10]);
            AddArguments("span", nodes[11]);
        }
    }

    /// <summary>
    /// Structure[key].Put0(trackkey, tilt, span)
    /// </summary>
    public class Put0Node : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("trackkey", nodes[3]);
            AddArguments("tilt", nodes[4]);
            AddArguments("span", nodes[5]);
        }
    }

    /// <summary>
    /// Structure[key].PutBetween(trackkey1, trackkey2, flag) | Structure[key].PutBetween(trackkey1, trackkey2)
    /// </summary>
    public class PutBetweenNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("trackkey1", nodes[3]);
            AddArguments("trackkey2", nodes[4]);
            if(nodes.Count > 5)
                AddArguments("flag", nodes[5]);
        }
    }
}
