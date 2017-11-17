using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Repeater
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
            AddArguments("trackkey", nodes, 3, typeof(string));
            AddArguments("x", nodes, 4, typeof(double));
            AddArguments("y", nodes, 5, typeof(double));
            AddArguments("z", nodes, 6, typeof(double));
            AddArguments("rx", nodes, 7, typeof(double));
            AddArguments("ry", nodes, 8, typeof(double));
            AddArguments("rz", nodes, 9, typeof(double));
            AddArguments("tilt", nodes, 10, typeof(double));
            AddArguments("span", nodes, 11, typeof(double));
            AddArguments("interval", nodes, 12, typeof(double));
            AddArguments("structurekey1", nodes, 13, typeof(string));
            if(nodes.Count > 14)
            {
                for (int i = 0; i < nodes[14].ChildNodes.Count; i++)
                {
                    AddArguments("structurkey" + (i + 2), nodes[14].ChildNodes, i, typeof(string));
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
            AddArguments("trackkey", nodes, 3, typeof(string));
            AddArguments("tilt", nodes, 4, typeof(double));
            AddArguments("span", nodes, 5, typeof(double));
            AddArguments("interval", nodes, 6, typeof(double));
            AddArguments("structurekey1", nodes, 7, typeof(string));
            if (nodes.Count > 8)
            {
                for (int i = 0; i < nodes[8].ChildNodes.Count; i++)
                {
                    AddArguments("structurkey" + (i + 2), nodes[8].ChildNodes, i, typeof(string));
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
            AddArguments("structurekey", nodes, 2, typeof(string));
        }
    }
}
