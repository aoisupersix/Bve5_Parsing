using System.Collections.ObjectModel;
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
        /// </summary>
        public ParseErrorListener ErrorListener { get; }

        /// <summary>
        /// パーサで保持しているエラーです。
        /// Parse()を呼び出しパースを行う度に初期化されます。
        /// </summary>
        public ReadOnlyCollection<ParseError> ParserErrors { get; }

        /// <summary>
        /// パーサを初期化します。
        /// </summary>
        public ScenarioGrammarParser() : this(new MessageGenerator())
        {
        }

        /// <summary>
        /// パーサをMessageGeneratorを指定して初期化します。
        /// </summary>
        /// <param name="messageGenerator"></param>
        public ScenarioGrammarParser(MessageGenerator messageGenerator) : this(new ParseErrorListener(messageGenerator))
        {
        }

        /// <summary>
        /// パーサをエラーリスナーを指定して初期化します。
        /// </summary>
        /// <param name="listener"></param>
        public ScenarioGrammarParser(ParseErrorListener listener)
        {
            ErrorListener = listener;
            ParserErrors = ErrorListener.Errors.AsReadOnly();
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
