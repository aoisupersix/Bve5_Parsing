using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Section
{
    /*
     * SectionのAST木定義
     */

    /// <summary>
    /// Section.Begin({signalN})
    /// </summary>
    public class BeginNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("signal0", nodes, 2, typeof(double));
            if (nodes.Count > 3)
            {
                for (int i = 0; i < nodes[3].ChildNodes.Count; i++)
                {
                    AddArguments("signal" + (i + 1), nodes[3].ChildNodes, i, typeof(double));
                }
            }
        }
    }

    /// <summary>
    /// Section.SetSpeedLimit({vN})
    /// </summary>
    public class SetSpeedLimitNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("v0", nodes, 2, typeof(double));
            if (nodes.Count > 3)
            {
                for (int i = 0; i < nodes[3].ChildNodes.Count; i++)
                {
                    AddArguments("v" + (i + 1), nodes[3].ChildNodes, i, typeof(double));
                }
            }
        }
    }
}
