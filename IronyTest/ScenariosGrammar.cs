using System.Collections.Generic;

using Irony.Parsing;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;

namespace IronyTest
{
    [Language("ScenariosGrammar")]
    class ScenariosGrammar : InterpretedLanguageGrammar
    {
        public ScenariosGrammar() : base(true)
        {
            ////終端記号の定義
            //var filePath = new IdentifierTerminal("filePath", ExtraChars.MULTIBYTES + ExtraChars.TOKEN + @"\", ExtraChars.MULTIBYTES + ExtraChars.TOKEN);
            //var text = new IdentifierTerminal("text", ExtraChars.MULTIBYTES + ExtraChars.TOKEN + @"\s" + "\"", ExtraChars.MULTIBYTES + ExtraChars.TOKEN);
            //var equal = ToTerm("=");


            ////非終端記号の定義
            //var end = new NonTerminal("End", typeof(EndNode));
            //end.Rule = NewLine | Eof;

            //var route = new NonTerminal("Route", typeof(PathNode));
            //route.Rule = "Route" + equal + filePath + end | "Route" + equal + end;

            //var vehicle = new NonTerminal("Vehicle", typeof(PathNode));
            //vehicle.Rule = "Vehicle" + equal + filePath + end | "Vehicle" + equal + end;

            //var image = new NonTerminal("Image", typeof(PathNode));
            //image.Rule = "Image" + equal + filePath + end | "Image" + equal + end;

            //var title = new NonTerminal("Title", typeof(TextNode));
            //title.Rule = "Title" + equal + text + end | "Title" + equal + end;

            //var routeTitle = new NonTerminal("RouteTitle", typeof(TextNode));
            //routeTitle.Rule = "RouteTitle" + equal + text + end | "RouteTitle" + equal + end;

            //var vehicleTitle = new NonTerminal("VehicleTitle", typeof(TextNode));
            //vehicleTitle.Rule = "VehicleTitle" + equal + text + end | "VehicleTitle" + equal + end ;

            //var author = new NonTerminal("Author", typeof(TextNode));
            //author.Rule = "Author" + equal + text + end | "Author" + equal + end;

            //var scenarioComment = new NonTerminal("ScenarioComment", typeof(TextNode));
            //scenarioComment.Rule = "Comment" + equal + text + end | "Comment" + equal + end;

            //var statement = new NonTerminal("Statement", typeof(StatementNode));
            //statement.Rule = route | vehicle | image | title | routeTitle | vehicleTitle | author | scenarioComment | NewLine;

            //var program = new NonTerminal("Program", typeof(ProgramNode));
            //program.Rule = MakeStarRule(program, statement);

            //Root = program;

            ////コメント
            //var comment1 = new CommentTerminal("Comment#", "#", "\n", "\r");
            //var comment2 = new CommentTerminal("Comment;", ";", "\n", "\r");
            //this.NonGrammarTerminals.Add(comment1);
            //this.NonGrammarTerminals.Add(comment2);

            //LanguageFlags = LanguageFlags.CreateAst;
        }
    }
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
            if(nodes.Count > 0)
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
                if(node.ChildNodes.Count >= 1)
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
