using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammarの解析を行うクラス
    /// </summary>
    public class MapGrammarParser
    {
        #region フィールド
        protected List<ParseError> _parserError;

        [Flags]
        public enum MapGrammarParserOption
        {

            /// <summary>
            /// オプション指定なし
            /// </summary>
            None = 0x001,

            /// <summary>
            /// パース中にInclude構文が出現した場合、指定されたファイルを再帰的にパースします。
            /// このフラグはParseメソッドにファイル名を指定した場合のみ有効です。
            /// </summary>
            ParseIncludeSyntaxRecursively = 0x002
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 構文解析エラー
        /// </summary>
        public IReadOnlyCollection<ParseError> ParserErrors { get; }

        /// <summary>
        /// 構文解析のエラーを取得するリスナー
        /// </summary>
        public ParseErrorListener ErrorListener { get; set; }

        /// <summary>
        /// マップ構文の変数管理用
        /// </summary>
        public VariableStore Store { get; set; }
        #endregion

        /// <summary>
        /// 構文解析器を初期化します。
        /// </summary>
        public MapGrammarParser()
        {
            _parserError = new List<ParseError>();
            ParserErrors = _parserError.AsReadOnly();
            ErrorListener = new ParseErrorListener(_parserError);
            Store = new VariableStore();
        }

        /// <summary>
        /// 引数に与えられたマップ構文文字列の構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文を表す文字列</param>
        public MapData Parse(string input)
        {
            var ast = ParseToAst(input);
            MapData value = (MapData)new EvaluateMapGrammarVisitor(Store, _parserError).Visit(ast);

            return value;
        }

        /// <summary>
        /// 引数に与えられたマップ構文文字列の構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文を表す文字列</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData Parse(string input, MapGrammarParserOption option)
        {
            // TODO: 現在は特にオプション無し
            return Parse(input);
        }

        /// <summary>
        /// 引数に与えられたマップ構文文字列の構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="input"></param>
        /// <param name="dirAbsolutePath"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData Parse(string input, string dirAbsolutePath, MapGrammarParserOption option)
        {
            // Includeを再帰的にパースするか？
            if (option.HasFlag(MapGrammarParserOption.ParseIncludeSyntaxRecursively))
            {
                var ast = ParseToAst(input);
                var value = (MapData)new EvaluateMapGrammarVisitorWithInclude(Store, dirAbsolutePath, _parserError).Visit(ast);
                return value;
            }
            else
            {
                return Parse(input, option);
            }
        }

        /// <summary>
        /// 引数に与えられたマップ構文ファイルの構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="filePath">解析するマップ構文のファイルパス</param>
        /// <returns></returns>
        public MapData ParseFromFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);
            using (var reader = new Hnx8.ReadJEnc.FileReader(fileInfo))
            {
                reader.Read(fileInfo);
                if (reader.Text == null)
                    throw new IOException(); // TODO
                var ast = ParseToAst(reader.Text);
                return Parse(reader.Text);
            }
        }

        /// <summary>
        /// 引数に与えられたマップ構文ファイルの構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="filePath">解析するマップ構文のファイルパス</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData ParseFromFile(string filePath, MapGrammarParserOption option)
        {
            var fileInfo = new FileInfo(filePath);
            using(var reader = new Hnx8.ReadJEnc.FileReader(fileInfo))
            {
                reader.Read(fileInfo);
                if (reader.Text == null)
                    throw new IOException(); // TODO
                return Parse(reader.Text, fileInfo.Directory.FullName, option);
            }
        }

        /// <summary>
        /// 引数に与えられたマップ構文の構文解析を行い、ASTを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文を表す文字列</param>
        public MapGrammarAstNodes ParseToAst(string input)
        {
            AntlrInputStream inputStream = new AntlrInputStream(input);
            MapGrammarLexer lexer = new MapGrammarLexer(inputStream);
            CommonTokenStream commonTokneStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.MapGrammarParser parser = new SyntaxDefinitions.MapGrammarParser(commonTokneStream);

            parser.AddErrorListener(ErrorListener);
            ErrorListener.Errors.Clear();
            parser.ErrorHandler = new MapGrammarErrorStrategy();

            var cst = parser.root();
            var ast = new BuildAstVisitor().VisitRoot(cst);

            return ast;
        }
    }
}
