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

        /// <summary>
        /// ScenarioGrammarの構文解析器を初期化します。
        /// </summary>
        public ScenarioGrammarParser()
        {
            //TODO
        }

        /// <summary>
        /// 引数に与えられたScenarioGrammarの構文解析を行います。
        /// </summary>
        /// <param name="input">解析する文字列</param>
        /// <returns>解析結果</returns>
        public ScenarioData Parse(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ScenarioGrammarLexer lexer = new ScenarioGrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.ScenarioGrammarParser parser = new SyntaxDefinitions.ScenarioGrammarParser(commonTokenStream);

            ScenarioData value = null;
            var cst = parser.root();
            var ast = new BuildAstVisitor().VisitRoot(cst);
            value = (ScenarioData)new EvaluateScenarioGrammarVisitor().Visit(ast);
            return value;
        }
    }
}
