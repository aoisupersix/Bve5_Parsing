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
        public List<AstNode> Statements { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            Statements = new List<AstNode>();

            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            foreach (ParseTreeNode node in nodes)
            {
                Statements.Add(AddChild("Statement", node));
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
                string name = statement.
            }

            thread.CurrentNode = Parent;
            return base.DoEvaluate(thread);
        }
    }

    /// <summary>
    /// ルートノード
    /// </summary>
    public class ProgramNode : AstNode
    {
        public List<AstNode> Statements { get; private set; }
        private string version;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            Statements = new List<AstNode>();

            version = (string)nodes[2].Token.Text;
            AddChild("Version=" + version, nodes[1]);
            foreach(var statement in nodes[3].ChildNodes)
            {
                Statements.Add(AddChild("Statements", statement));
            }
        }

        //protected override object DoEvaluate(ScriptThread thread)
        //{
        //    thread.CurrentNode = this;

        //    //Key -> Statement名, Value -> Valueの辞書を返す
        //    Dictionary<string, string> dict = new Dictionary<string, string>();
        //    if (Statements.ChildNodes.Count > 0)
        //    {
        //        foreach (AstNode statement in Statements.ChildNodes)
        //        {
        //            AstNode val = statement.ChildNodes[0];
        //            if (!dict.ContainsKey(statement.AsString) && val != null)
        //                dict.Add(statement.AsString, val.AsString);
        //        }
        //    }
        //    //バージョン情報の格納
        //    dict.Add("version", version);

        //    thread.CurrentNode = Parent;
        //    return dict;
        //}
    }
}
