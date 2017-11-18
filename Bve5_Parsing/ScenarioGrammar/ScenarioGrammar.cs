using Irony.Parsing;
using Irony.Interpreter;
using Bve5_Parsing.ScenarioGrammar.AstNodes;

namespace Bve5_Parsing.ScenarioGrammar
{
    [Language("ScenarioGrammar", "0.1", "Bve5.7 Scenario file grammar.")]
    class ScenarioGrammar : InterpretedLanguageGrammar
    {
        public ScenarioGrammar() : base(false)
        {
            #region 終端記号の定義
            var pathIdentifier = new IdentifierTerminal("pathIdentifier", ExtraChars.MULTIBYTES + ExtraChars.TOKEN + @"\", ExtraChars.MULTIBYTES + ExtraChars.TOKEN);
            var text = new IdentifierTerminal("text", ExtraChars.MULTIBYTES + ExtraChars.TOKEN + @"\s" + "\"", ExtraChars.MULTIBYTES + ExtraChars.TOKEN);
            var num = new NumberLiteral("Num", NumberOptions.AllowSign);
            var equal = ToTerm("=");
            var or = ToTerm("|");
            var mul = ToTerm("*");
            #endregion 非終端記号の定義

            #region 非終端記号の定義
            var filePath = new NonTerminal("FilePath");
            var nextFilePath = new NonTerminal("NextFilePath");
            var nextFilePaths = new NonTerminal("NextFilePaths");
            var end = new NonTerminal("End", typeof(EndNode));
            var route = new NonTerminal("Route", typeof(PathNode));
            var vehicle = new NonTerminal("Vehicle", typeof(PathNode));
            var image = new NonTerminal("Image", typeof(PathNode));
            var title = new NonTerminal("Title", typeof(TextNode));
            var routeTitle = new NonTerminal("RouteTitle", typeof(TextNode));
            var vehicleTitle = new NonTerminal("VehicleTitle", typeof(TextNode));
            var author = new NonTerminal("Author", typeof(TextNode));
            var scenarioComment = new NonTerminal("ScenarioComment", typeof(TextNode));
            var statement = new NonTerminal("Statement", typeof(StatementNode));
            var statements = new NonTerminal("Statements", typeof(StatementsNode));
            var program = new NonTerminal("Program", typeof(ProgramNode));
            #endregion 非終端記号の定義

            #region 非終端記号の文法
            filePath.Rule = pathIdentifier + mul + num | pathIdentifier;
            nextFilePath.Rule = or + filePath;
            nextFilePaths.Rule = MakeStarRule(nextFilePaths, nextFilePath);
            end.Rule = NewLine | Eof;
            route.Rule = "Route" + equal + filePath + nextFilePaths + end | "Route" + equal + end;
            vehicle.Rule = "Vehicle" + equal + filePath + nextFilePaths + end | "Vehicle" + equal + end;
            image.Rule = "Image" + equal + pathIdentifier + end | "Image" + equal + end;
            title.Rule = "Title" + equal + text + end | "Title" + equal + end;
            routeTitle.Rule = "RouteTitle" + equal + text + end | "RouteTitle" + equal + end;
            vehicleTitle.Rule = "VehicleTitle" + equal + text + end | "VehicleTitle" + equal + end;
            author.Rule = "Author" + equal + text + end | "Author" + equal + end;
            scenarioComment.Rule = "Comment" + equal + text + end | "Comment" + equal + end;
            statement.Rule = route | vehicle | image | title | routeTitle | vehicleTitle | author | scenarioComment | NewLine;
            statements.Rule = MakeStarRule(statements, statement);
            program.Rule = ToTerm("BveTs") + ToTerm("Scenario") + num + statements;
            #endregion 非終端記号の文法

            Root = program;

            //コメント
            var comment1 = new CommentTerminal("Comment#", "#", "\n", "\r");
            var comment2 = new CommentTerminal("Comment;", ";", "\n", "\r");
            this.NonGrammarTerminals.Add(comment1);
            this.NonGrammarTerminals.Add(comment2);

            RegisterOperators(1, pathIdentifier);
            RegisterOperators(3, ToTerm("|"));

            MarkPunctuation(or, mul);

            LanguageFlags = LanguageFlags.TailRecursive;
        }
    }
}
