using System.Collections.Generic;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /*
     * 基本ステートメント(Rootなど)のAST木定義
     */


    public class MapFileNode : AstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            AddChild("version=" + nodes[2].Token.Value, nodes[3]);

            //変数の初期化
            Vars vars = Vars.GetInstance();
            vars.Clear();
        }
    }
    public class StatementsNode : AstNode
    {
        public List<AstNode> Statements { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            Statements = new List<AstNode>();

            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            double nowDist = 0;
            foreach (var node in nodes)
            {
                if (node.ToString().Equals("Distance"))
                {
                    //距離程
                    DistNode distance = (DistNode)node.AstNode;
                    nowDist = distance.Distance;
                }
                else
                {
                    //構文の距離程はnowDistに入っている　TODO 距離程処理
                    Statements.Add(AddChild("Dist=" + nowDist, node));
                }
            }
        }
    }

    public class StatementNode : AstNode
    {
        public AstNode Statement { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            Statement = AddChild("Statement", nodes[0]);
        }
    }

    /// <summary>
    /// 距離程
    /// </summary>
    public class DistNode : AstNode
    {
        public List<AstNode> BasicStates { get; private set; }
        public double Distance { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            BasicStates = new List<AstNode>();

            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //距離の取得
            if (nodes[0].Term.ToString().Equals("Expr"))
            {
                ExprNode expr = (ExprNode)nodes[0].AstNode;
                Distance = expr.Value;
                AddChild("Dist=" + expr.Value, nodes[0]);
            }
            else
            {
                Distance = 0;
            }

            //現在の距離程の構文を取得
            if (nodes.Count > 1)
            {
                foreach (var node in nodes[1].ChildNodes)
                    BasicStates.Add(AddChild("BasicStates", node));
            }
        }
    }

    public class BasicStatesNode : AstNode
    {
        public List<AstNode> BasicState { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            BasicState = new List<AstNode>();

            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            foreach (var node in nodes)
                BasicState.Add(AddChild("BasicState", node));
        }
    }

    public class BasicStateNode : AstNode
    {
        public AstNode MapElement { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            MapElement = AddChild("BasicState", nodes[0].ChildNodes[0]);
        }
    }

    public class MapElementNode : AstNode
    {
        public AstNode MapElement { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            MapElement = AddChild("MapElement", nodes[0]);
        }
    }
}
