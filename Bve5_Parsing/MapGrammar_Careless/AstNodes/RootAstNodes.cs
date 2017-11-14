using System.Collections.Generic;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless.AstNodes
{
    /*
     * 基本ステートメント(Rootなど)のAST木定義
     */


    public class MapFileNode : AstNode
    {

        public MapData MapData { get; set; }
        private AstNode statements;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            MapData = new MapData();

            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            if(nodes.Count == 5)
            {
                //エンコーディング指定あり
                statements = AddChild("ver=" + nodes[2].Token.Value + ",enc=" + nodes[3].Token.Value, nodes[4]);
                MapData.Version = nodes[2].Token.Value.ToString();
                MapData.Encoding = nodes[3].Token.Value.ToString();
            }
            else
            {
                //エンコーディング指定なし
                statements = AddChild("ver=" + nodes[2].Token.Value + ",enc=utf-8", nodes[3]);
                MapData.Version = nodes[2].Token.Value.ToString();
                MapData.Encoding = "utf-8";
            }

            //変数の初期化
            Vars vars = Vars.GetInstance();
            vars.Clear();

            //リストファイルの登録
            StatementsNode stateNode = (StatementsNode)statements;
            foreach(AstNode node in stateNode.ListFiles)
            {
                LoadListFileNode loadNode = (LoadListFileNode)node;
                MapData.SetListPathToString(loadNode.ElementName, loadNode.FilePath);
            }
        }

        protected override object DoEvaluate(ScriptThread thread)
        {
            thread.CurrentNode = this;

            thread.CurrentNode = Parent;
            return base.DoEvaluate(thread);
        }
    }

    public class StatementsNode : AstNode
    {
        public List<AstNode> Statements { get; private set; }
        public List<AstNode> ListFiles { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            Statements = new List<AstNode>();
            ListFiles = new List<AstNode>();

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
                    //構文
                    string syntaxName = node.Term.ToString();
                    if(node.AstNode.GetType() == typeof(LoadListFileNode))
                    {
                        ListFiles.Add(AddChild("LoadListFile", node));
                    }
                    else if (!syntaxName.Equals("VarAssign"))
                    {
                        //mapElementに距離程の登録
                        Syntax syntax = (Syntax)node.AstNode;
                        syntax.Data.Distance = nowDist;
                        Statements.Add(AddChild("Dist=" + nowDist, node));
                    }
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
