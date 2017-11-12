using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Gradient
{
    /*
     * GradientのAST木定義
     */

    /// <summary>
    /// Gradient.BeginTransition()
    /// </summary>
    public class BeginTransition : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            //引数なし
        }
    }

    /// <summary>
    /// Gradient.Begin(gradient)
    /// </summary>
    public class BeginNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("gradient", nodes[2]);
        }
    }

    /// <summary>
    /// Gradient.End()
    /// </summary>
    public class EndNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            //引数なし
        }
    }

    /// <summary>
    /// Gradient.Interpolate(gradient) | Gradient.Interpolate()
    /// </summary>
    public class InterpolateNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if(nodes.Count > 2)
                AddArguments("gradient", nodes[2]);
        }
    }
}
