using Antlr4.Runtime;
using Bve5_Parsing.ScenarioGrammar.AstNodes;
using Bve5_Parsing.ScenarioGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.ScenarioGrammar
{
    /// <summary>
    /// ScenarioGrammarの解析を行うクラス
    /// </summary>
    class ScenarioGrammarParser
    {
        public ScenarioData Parse(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ScenarioGrammarLexer lexer = new ScenarioGrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.ScenarioGrammarParser parser = new SyntaxDefinitions.ScenarioGrammarParser(commonTokenStream);

            ScenarioData value = null;
            var cst = parser.root();
            var ast = new BuildAstVisitor().VisitRoot(cst);

            return value;
        }
    }
}
