using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;
using System.Collections.Generic;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammarの解析を行うクラス
    /// </summary>
    public class MapGrammarParser
    {
        /// <summary>
        /// 構文解析エラー
        /// </summary>
        public List<ParseError> ParserErrors { get; }

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
            ParserErrors = new List<ParseError>();
            ErrorListener = new ParseErrorListener(ParserErrors);
            Store = new VariableStore();
        }

        /// <summary>
        /// 引数に与えられたMapGrammarの構文解析を行います。
        /// </summary>
        /// <param name="input">解析する文字列</param>
        public MapData Parse(string input)
        {
            Store.ClearVar();
            ParserErrors.Clear();

            AntlrInputStream inputStream = new AntlrInputStream(input);
            MapGrammarLexer lexer = new MapGrammarLexer(inputStream);
            CommonTokenStream commonTokneStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.MapGrammarParser parser = new SyntaxDefinitions.MapGrammarParser(commonTokneStream);

            parser.AddErrorListener(ErrorListener);
            ErrorListener.Errors.Clear();
            parser.ErrorHandler = new MapGrammarErrorStrategy();

            var cst = parser.root();
            var ast = new BuildAstVisitor().VisitRoot(cst);
            MapData value = (MapData)new EvaluateMapGrammarVisitor(Store, ParserErrors).Visit(ast);

            return value;
        }
    }
}
