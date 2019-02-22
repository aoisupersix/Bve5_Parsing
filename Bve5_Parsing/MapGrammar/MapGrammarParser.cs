using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammarの解析を行うクラス
    /// </summary>
    public class MapGrammarParser
    {
        /// <summary>
        /// 構文解析のエラーを取得するリスナー
        /// </summary>
        public ParseErrorListener ErrorListener { get; set; }

        /// <summary>
        /// マップ構文の変数管理用
        /// </summary>
        public VariableStore Store { get; set; }

        /// <summary>
        /// 構文解析器を初期化します。
        /// </summary>
        public MapGrammarParser()
        {
            Store.ClearVar(); //変数の初期化
            ErrorListener = new ParseErrorListener();
        }

        /// <summary>
        /// 構文解析器をエラーリスナーを指定して初期化します。
        /// </summary>
        /// <param name="listener">エラーリスナークラス</param>
        public MapGrammarParser(ParseErrorListener listener)
        {
            Store.ClearVar();
            ErrorListener = listener;
        }

        /// <summary>
        /// 引数に与えられたMapGrammarの構文解析を行います。
        /// </summary>
        /// <param name="input">解析する文字列</param>
        public MapData Parse(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            MapGrammarLexer lexer = new MapGrammarLexer(inputStream);
            CommonTokenStream commonTokneStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.MapGrammarParser parser = new SyntaxDefinitions.MapGrammarParser(commonTokneStream);

            parser.AddErrorListener(ErrorListener);
            ErrorListener.ErrorMessages.Clear();
            //parser.ErrorHandler = new MapGrammarErrorStrategy();

            MapData value = null;
            var cst = parser.root();
            var ast = new BuildAstVisitor().VisitRoot(cst);
            value = (MapData)new EvaluateMapGrammarVisitor(Store).Visit(ast);

            return value;
        }
    }
}
