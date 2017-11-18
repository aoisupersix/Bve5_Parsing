using Irony.Ast;
using Irony.Parsing;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using System.Collections.Generic;

namespace Bve5_Parsing.ScenarioGrammar.AstNodes
{
    /**
     * ScenarioGrammarのAST木定義
     */

    /// <summary>
    /// Title, RouteTitle, VehicleTitle, Author, Comment構文
    /// </summary>
    public class TextNode : Statement
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            if (nodes.Count > 1)
            {
                Value = nodes[1].Token.Value.ToString();
                AddChild(Name + ":Text", nodes[1]);
            }
        }
    }
    
    /// <summary>
    /// 各構文の親クラス
    /// </summary>
    public class Statement : AstNode
    {
        public string Name { get; private set; }
        public object Value { get; protected set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            Name = nodes[0].Term.Name.ToString().ToLower();
        }
    }

    /// <summary>
    /// 構文ノード
    /// </summary>
    public class StatementsNode : AstNode
    {
        public List<Statement> Statements { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            Statements = new List<Statement>();

            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            foreach (ParseTreeNode node in nodes)
            {
                AddChild("Statement", node);
                Statements.Add((Statement)node.AstNode);
            }
        }

        /// <summary>
        /// 構文を代入したScenarioDataクラスを返す
        /// </summary>
        /// <param name="thread">ScriptThread</param>
        /// <returns>ScenarioDataクラス</returns>
        protected override object DoEvaluate(ScriptThread thread)
        {
            thread.CurrentNode = this;

            ScenarioData scenarioData = new ScenarioData();
            foreach(var statement in Statements)
            {
                switch (statement.Name)
                {
                    case "route":
                        scenarioData.Route = (List<FilePath>)statement.Value;
                        break;
                    case "vehicle":
                        scenarioData.Vehicle = (List<FilePath>)statement.Value;
                        break;
                    case "image":
                        scenarioData.Image = (FilePath)statement.Value;
                        break;
                    case "title":
                        scenarioData.Title = (string)statement.Value;
                        break;
                    case "routetitle":
                        scenarioData.RouteTitle = (string)statement.Value;
                        break;
                    case "vehicletitle":
                        scenarioData.VehicleTitle = (string)statement.Value;
                        break;
                    case "author":
                        scenarioData.Author = (string)statement.Value;
                        break;
                    case "comment":
                        scenarioData.Comment = (string)statement.Value;
                        break;
                }
            }

            thread.CurrentNode = Parent;
            return scenarioData;
        }
    }

    /// <summary>
    /// ルートノード
    /// </summary>
    public class ProgramNode : AstNode
    {
        public AstNode Statements { get; private set; }
        private string version;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            version = (string)nodes[2].Token.Text;
            AddChild("Version=" + version, nodes[1]);
            Statements = AddChild("Statements", nodes[3]);
        }

        /// <summary>
        /// RootAST木の評価
        /// </summary>
        /// <param name="thread">ScriptThread</param>
        /// <returns>構文の値を代入したScenarioDataクラス</returns>
        protected override object DoEvaluate(ScriptThread thread)
        {
            thread.CurrentNode = this;

            //ScenarioDataクラスを返す
            ScenarioData scenarioData = (ScenarioData)Statements.Evaluate(thread);
            //バージョン情報の格納
            scenarioData.Version = version;

            thread.CurrentNode = Parent;
            return scenarioData;
        }
    }
}
