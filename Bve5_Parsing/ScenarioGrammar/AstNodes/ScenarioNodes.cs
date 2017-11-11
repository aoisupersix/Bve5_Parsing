using Irony.Ast;
using Irony.Parsing;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using System.Collections.Generic;

namespace Bve5_Parsing.ScenarioGrammar.AstNodes
{
    public class EndNode : AstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
        }
    }

    public class PathNode : AstNode
    {
        public AstNode Path { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if (nodes.Count > 2 && !nodes[2].ToString().Equals("End"))
                Path = AddChild("Path", nodes[2]);
        }
    }

    public class TextNode : AstNode
    {
        public AstNode Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if (nodes.Count > 2 && !nodes[2].ToString().Equals("End"))
                Value = AddChild("Value", nodes[2]);
        }
    }

    public class StatementNode : AstNode
    {
        public List<AstNode> Values { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            if (Values == null)
                Values = new List<AstNode>();

            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if (nodes.Count > 0)
                Values.Add(AddChild("Type", nodes[0]));
        }
    }

    public class ProgramNode : AstNode
    {
        public List<AstNode> Statement { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            if (Statement == null)
                Statement = new List<AstNode>();

            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            foreach (ParseTreeNode node in nodes)
            {
                if (node.ChildNodes.Count >= 1)
                    Statement.Add(AddChild("Statement", node.ChildNodes[0]));
            }
        }

        protected override object DoEvaluate(ScriptThread thread)
        {
            thread.CurrentNode = this;

            //Key -> Statement名, Value -> Valueの辞書を返す
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (AstNode statement in Statement)
            {
                AstNode val = statement.ChildNodes[0];
                if (!dict.ContainsKey(statement.AsString) && val != null)
                    dict.Add(statement.AsString, val.AsString);
            }

            thread.CurrentNode = Parent;
            return dict;
        }
    }
}
