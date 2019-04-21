using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Linq;

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
        public ReadOnlyCollection<ParseError> ParserErrors { get; }

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
            return Parse(input, MapGrammarParserOption.None);
        }

        /// <summary>
        /// 引数に与えられたマップ構文文字列の構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文を表す文字列</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData Parse(string input, MapGrammarParserOption option)
        {
            if (option.HasFlag(MapGrammarParserOption.ParseIncludeSyntaxRecursively))
                option &= MapGrammarParserOption.ParseIncludeSyntaxRecursively; // Include対応はできないのでOptionを削除する

            return Parse(input, null, option);
        }

        /// <summary>
        /// 引数に与えられたマップ構文ファイルの構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="filePath">解析するマップ構文のファイルパス</param>
        /// <returns></returns>
        public MapData ParseFromFile(string filePath)
        {
            return ParseFromFile(filePath, MapGrammarParserOption.None);
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
#if NETSTANDARD2_0
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Shift-Jisを扱うために必要
#endif
            using (var reader = new Hnx8.ReadJEnc.FileReader(fileInfo))
            {
                reader.Read(fileInfo);
                if (reader.Text == null)
                    throw new IOException(); // TODO
                return Parse(reader.Text, fileInfo.Directory.FullName, option);
            }
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
            Tuple<string, string, int> headerInfo = GetHeaderInfo(input);
            if (headerInfo.Item1 == null)
            {
                _parserError.Add(new ParseError(ParseErrorLevel.Error, 0, 0, "有効なマップファイルではありません。"));
                return null;
            }

            MapGrammarAstNodes ast = ParseToAst(input.Substring(headerInfo.Item3), headerInfo.Item1);
            MapData value = option.HasFlag(MapGrammarParserOption.ParseIncludeSyntaxRecursively) ?
                (MapData)new EvaluateMapGrammarVisitorWithInclude(Store, dirAbsolutePath, _parserError).Visit(ast) : // Includeを再帰的にパースする
                (MapData)new EvaluateMapGrammarVisitor(Store, _parserError).Visit(ast)
                ;

            if (value == null)
                return null;

            value.Version = headerInfo.Item1;
            if (headerInfo.Item2 != null)
                value.Encoding = headerInfo.Item2;

            return value;
        }

        /// <summary>
        /// 引数に与えられたマップ構文の構文解析を行い、ASTを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文のステートメントを表す文字列</param>
        /// <param name="versionString">パーサを指定するためのバージョン文字列（省略した場合はV2Parserを利用します）</param>
        /// <returns></returns>
        public MapGrammarAstNodes ParseToAst(string input, string versionString = null)
        {
            var inputStream = new AntlrInputStream(input);
            
            ErrorListener.Errors.Clear();
            MapGrammarAstNodes ast = null;
            if (versionString != null && ( versionString[0] == '1' || versionString[0] == '0'))
            {
                // V1Parser
                var lexer = new V1Parser.SyntaxDefinitions.MapGrammarV1Lexer(inputStream);
                var commonTokneStream = new CommonTokenStream(lexer);

                var parser = new V1Parser.SyntaxDefinitions.MapGrammarV1Parser(commonTokneStream);
                parser.AddErrorListener(ErrorListener);
                parser.ErrorHandler = new V1Parser.V1ParserErrorStrategy();
                var cst = parser.root();
                if (cst == null) { return null; }
                ast = new V1Parser.BuildAstVisitor().VisitRoot(cst);
            }
            else
            {
                // V2Parser
                var lexer = new V2Parser.SyntaxDefinitions.MapGrammarV2Lexer(inputStream);
                var commonTokneStream = new CommonTokenStream(lexer);

                var parser = new V2Parser.SyntaxDefinitions.MapGrammarV2Parser(commonTokneStream);
                parser.AddErrorListener(ErrorListener);
                parser.ErrorHandler = new V2Parser.V2ParserErrorStrategy();
                var cst = parser.root();
                if (cst == null) { return null; }
                ast = new V2Parser.BuildAstVisitor().VisitRoot(cst);
            }

            return ast;
        }

        /// <summary>
        /// 引数に与えられたマップファイルのヘッダ情報を取得します。
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// バージョン、エンコーディング、ステートメントの開始インデックスのタプルにまとめたもの。
        /// Item1にバージョン情報、Item2にエンコーディング、Item3にステートメント開始インデックスを返します。
        /// 引数に与えられた文字列が有効なマップファイルでない場合はバージョン情報がnullのタプルを返します。
        /// </returns>
        protected Tuple<string, string, int> GetHeaderInfo(string input)
        {
            string header = input.Replace("\r\n", "\n").Replace("\r", "\n").Split('\n').FirstOrDefault();
            if (string.IsNullOrEmpty(header) || header.Length < 14 || header.Substring(0, 9).ToLower() != "bvets map")
                return new Tuple<string, string, int>(null, null, 0); // 有効なマップファイルではない

            string version = header.Substring(10, 4);
            if (header.Length >= 15 && header[14] == ':')
                return new Tuple<string, string, int>(version, header.Substring(15).Trim(), header.Length); // エンコーディング指定あり

            return new Tuple<string, string, int>(version, null, header.Length); // エンコーディング指定なし
        }
    }
}
