using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Strict.AstNodes.Repeater
{
    /*
     * RepeaterのAST木定義
     */

    /// <summary>
    /// Repeater[key].Begin(trackkey, x, y, z, rx, ry, rz, tilt, span, interval, structurekey1, {structurekey})
    /// </summary>
    public class BeginNode : Syntax_2
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
            AddArguments("interval", nodes[12]);
            AddArguments("structurekey1", nodes[13]);
            if(nodes.Count > 14)
            {
                for (int i = 0; i < nodes[14].ChildNodes.Count; i++)
                {
                    AddArguments("structurkey" + (i + 2), nodes[14].ChildNodes[i]);
                }
            }
        }
    }

    /// <summary>
    /// Repeater[key].Begin0(trackkey, tilt, span, interval, structurekey1, {structurekeyN})
    /// </summary>
    public class Begin0Node : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("trackkey", nodes[3]);
            AddArguments("tilt", nodes[4]);
            AddArguments("span", nodes[5]);
            AddArguments("interval", nodes[6]);
            AddArguments("structurekey1", nodes[7]);
            if (nodes.Count > 8)
            {
                for (int i = 0; i < nodes[8].ChildNodes.Count; i++)
                {
                    AddArguments("structurkey" + (i + 2), nodes[8].ChildNodes[i]);
                }
            }
        }
    }

    /// <summary>
    /// Repeater[key].End()
    /// </summary>
    public class EndNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数なし
        }
    }

    /// <summary>
    /// Background.Change(structurekey)
    /// </summary>
    public class BackGroundChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("structurekey", nodes[2]);
        }
    }
}
