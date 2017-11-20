using Irony.Parsing;
using Irony.Interpreter;
using Bve5_Parsing.ScenarioGrammar.AstNodes;

namespace Bve5_Parsing.ScenarioGrammar
{
    [Language("ScenarioGrammar", "0.2", "Bve5.7 Scenario file grammar.")]
    public class ScenarioGrammar : InterpretedLanguageGrammar
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
            var filePath = new NonTerminal("FilePath", typeof(FilePathNode));
            var nextFilePath = new NonTerminal("NextFilePath");
            var nextFilePaths = new NonTerminal("NextFilePaths", typeof(FilePathsNode));
            var end = new NonTerminal("End");
            var route = new NonTerminal("Route", typeof(PathStatementNode));
            var vehicle = new NonTerminal("Vehicle", typeof(PathStatementNode));
            var image = new NonTerminal("Image", typeof(ImageNode));
            var title = new NonTerminal("Title", typeof(TextNode));
            var routeTitle = new NonTerminal("RouteTitle", typeof(TextNode));
            var vehicleTitle = new NonTerminal("VehicleTitle", typeof(TextNode));
            var author = new NonTerminal("Author", typeof(TextNode));
            var scenarioComment = new NonTerminal("ScenarioComment", typeof(TextNode));
            var statement = new NonTerminal("Statement");
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

            MarkTransient(statement, end, nextFilePath);
            MarkPunctuation(equal, or, mul);

            LanguageFlags = LanguageFlags.CreateAst;
        }
    }
}
