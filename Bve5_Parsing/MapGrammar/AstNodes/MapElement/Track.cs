using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Track
{
    /*
     * TrackのAST木定義
     */

    /// <summary>
    /// Track[key].X.Interpolate(x, radius) | Track[key].X.Interpolate(x) | Track[key].X.Interpolate()
    /// </summary>
    public class XInterpolateNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if (nodes.Count > 4)
            {
                //引数:radius
                AddArguments("x", nodes, 4, typeof(double));

                if (nodes.Count > 5)
                    //引数:cant
                    AddArguments("radius", nodes, 5, typeof(double));
            }
            //引数なし
        }
    }

    /// <summary>
    /// Track[key].Y.Interpolate(y, radius) | Track[key].Y.Interpolate(y) | Track[key].Y.Interpolate()
    /// </summary>
    public class YInterpolateNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if (nodes.Count > 4)
            {
                //引数:radius
                AddArguments("y", nodes, 4, typeof(double));

                if (nodes.Count > 5)
                    //引数:cant
                    AddArguments("radius", nodes, 5, typeof(double));
            }
            //引数なし
        }
    }

    /// <summary>
    /// Track[key].Position(x, y, radiusH, radiusV) | Track[key].Position(x, y, radiusH) | Track[key].Y.Interpolate(x, y)
    /// </summary>
    public class Position : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("x", nodes, 3, typeof(double));
            AddArguments("y", nodes, 4, typeof(double));
            if (nodes.Count > 5)
            {
                //引数:radius
                AddArguments("radiusH", nodes, 5, typeof(double));

                if (nodes.Count > 6)
                    //引数:cant
                    AddArguments("radiusV", nodes, 6, typeof(double));
            }
            //引数なし
        }
    }

    /// <summary>
    /// Track[key].Cant.SetGauge(value)
    /// </summary>
    public class CantSetGaugeNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("value", nodes, 4, typeof(double));
        }
    }

    /// <summary>
    /// Track[key].Cant.SetCenter(x)
    /// </summary>
    public class CantSetCenterNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("x", nodes, 4, typeof(double));
        }
    }

    /// <summary>
    /// Track[key].Cant.SetFunction(id)
    /// </summary>
    public class CantSetFunctionNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            //idは0か1のみなのでその判定 TODO
            AddArguments("id", nodes, 4, typeof(double));
        }
    }

    /// <summary>
    /// Track[key].Cant.BeginTransition()
    /// </summary>
    public class CantBeginTransitionNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            //引数なし
        }
    }

    /// <summary>
    /// Track[key].Cant.Begin(cant)
    /// </summary>
    public class CantBeginNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("cant", nodes, 4, typeof(double));
        }
    }

    /// <summary>
    /// Track[key].Cant.End()
    /// </summary>
    public class CantEndNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            //引数なし
        }
    }

    /// <summary>
    /// Track[key].Cant.Interpolate(cant) | Track[key].Cant.Interpolate()
    /// </summary>
    public class CantInterpolateNode : Syntax_3
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if(nodes.Count > 4)
                AddArguments("cant", nodes, 4, typeof(double));
        }
    }
}
