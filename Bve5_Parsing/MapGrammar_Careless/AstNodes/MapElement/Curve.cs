using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless.AstNodes.Curve
{
    /*
     * CurveのAST木定義
     */

    /// <summary>
    /// Curve.SetGauge(value)
    /// </summary>
    public class SetGaugeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("value", nodes, 2);
        }
    }

    /// <summary>
    /// Curve.SetCenter(x)
    /// </summary>
    public class SetCenterNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("x", nodes, 2);
        }
    }

    /// <summary>
    /// Curve.SetFunction(id)
    /// </summary>
    public class SetFunctionNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            //idは0か1のみなのでその判定 TODO
            AddArguments("id", nodes, 2);
        }
    }

    /// <summary>
    /// Curve.BeginTransition()
    /// </summary>
    public class BeginTransitionNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数なし
        }
    }

    /// <summary>
    /// Curve.Begin(radius, cant) | Curve.Begin(radius)
    /// </summary>
    public class BeginNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("radius", nodes, 2);
            if (nodes.Count > 3)
                AddArguments("cant", nodes, 3);
        }
    }

    /// <summary>
    /// Curve.End()
    /// </summary>
    public class EndNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数なし
        }
    }

    /// <summary>
    /// Curve.Interpolate(radius, cant) | Curve.Interpolate(radius) | Curve.Interpolate()
    /// </summary>
    public class InterpolateNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if(nodes.Count > 2)
            {
                //引数:radius
                AddArguments("radius", nodes, 2);

                if (nodes.Count > 3)
                    //引数:cant
                    AddArguments("cant", nodes, 3);
            }
            //引数なし
        }
    }

    /// <summary>
    /// Curve.Change(radius)
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("radius", nodes, 2);
        }
    }
}
