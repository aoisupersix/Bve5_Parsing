using Antlr4.Runtime;
using Bve5_Parsing.ScenarioGrammar.AstNodes;
using Bve5_Parsing.ScenarioGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.ScenarioGrammar
{
    /// <summary>
    /// シナリオファイルのパースを行います。
    /// </summary>
    public class ScenarioGrammarParser
    {

        /// <summary>
        /// 構文解析のエラーを取得するするためのリスナーです。
        /// エラーに対して独自の処理を行いたい場合は、このプロパティにParseErrorListenerを継承した独自のクラスを指定してください。
        /// </summary>
        public ParseErrorListener ErrorListener { get; set; }

        /// <summary>
        /// パーサを初期化します。
        /// </summary>
        public ScenarioGrammarParser()
        {
            ErrorListener = new ParseErrorListener();
        }

        /// <summary>
        /// パーサをエラーリスナーを指定して初期化します。
        /// </summary>
        /// <param name="listener"></param>
        public ScenarioGrammarParser(ParseErrorListener listener)
        {
            ErrorListener = listener;
        }

        /// <summary>
        /// 引数に与えられたScenarioGrammarの構文解析と評価を行い、ScenarioDataを返します。
        /// </summary>
        /// <param name="input">解析する文字列</param>
        /// <returns>解析結果</returns>
        public ScenarioData Parse(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            ScenarioGrammarLexer lexer = new ScenarioGrammarLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.ScenarioGrammarParser parser = new SyntaxDefinitions.ScenarioGrammarParser(commonTokenStream);

            parser.AddErrorListener(ErrorListener);

            ScenarioData value = null;
            var cst = parser.root();
            var ast = new BuildAstVisitor().VisitRoot(cst);
            value = (ScenarioData)new EvaluateScenarioGrammarVisitor().Visit(ast);
            return value;
        }
    }
}
