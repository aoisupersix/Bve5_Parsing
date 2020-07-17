using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.EvaluateData;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// マップファイルのパースを行います。
    /// </summary>
    public class MapGrammarParser
    {
        #region フィールド
        /// <summary>
        /// パーサの細かい動作を指定するためのオプションです。
        /// Parse()やParseToAst()メソッドの引数に渡してオプションを指定します。
        /// </summary>
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
            ParseIncludeSyntaxRecursively = 0x002,

            /// <summary>
            /// ファイルヘッダに記載されているマップファイルのバージョン情報を無視し、バージョン1.XXの構文としてパースします。
            /// ParseAsMapVersion2と併用できません。もし、ParseAsMapVersion1とParseAsMapVersion2を両方指定した場合、ParseAsMapVersion2を優先します。つまり、バージョン2.XXの構文としてパースします。
            /// </summary>
            ParseAsMapVersion1 = 0x004,

            /// <summary>
            /// ファイルヘッダに記載されているマップファイルのバージョン情報を無視し、バージョン2.XXの構文としてパースします。
            /// ParseAsMapVersion1と併用できません。もし、ParseAsMapVersion1とParseAsMapVersion2を両方指定した場合、ParseAsMapVersion2を優先します。つまり、バージョン2.XXの構文としてパースします。
            /// </summary>
            ParseAsMapVersion2 = 0x008,

            /// <summary>
            /// 与えられた文字列やファイルにファイルヘッダが存在しないものとしてパースします。
            /// マップファイルのバージョンは最新の2.02として扱います。
            /// 特定のバージョンを指定したい場合は、ParseAsMapVersion1、もしくはParseAsMapVersion2を同時に指定して下さい。
            /// </summary>
            NoHeader = 0x010,

            /// <summary>
            /// パース処理の前にパーサで管理している変数を初期化します。
            /// </summary>
            ClearVariables = 0x020,

            /// <summary>
            /// パース処理の前にエラーリスナーが保持するエラーを初期化しないままパースします。
            /// </summary>
            NoClearErrors = 0x040
        }
        #endregion

        #region プロパティ
        /// <summary>
        /// 構文解析のエラーを取得するするためのリスナーです。
        /// </summary>
        public ParseErrorListener ErrorListener { get; }

        /// <summary>
        /// パーサで保持しているエラーです。
        /// Parse()やParseToAst()を呼び出しパースを行う度に初期化されます。
        /// </summary>
        public ReadOnlyCollection<ParseError> ParserErrors { get; }

        /// <summary>
        /// マップ構文内の変数を保持します。
        /// 変数はパースの度に初期化されません。
        /// </summary>
        public VariableStore Store { get; set; }
        #endregion

        /// <summary>
        /// パーサを初期化します。
        /// </summary>
        public MapGrammarParser() : this(new MessageGenerator())
        {
        }

        /// <summary>
        /// パーサをMessageGeneratorを指定して初期化します。
        /// </summary>
        /// <param name="messageGenerator"></param>
        public MapGrammarParser(MessageGenerator messageGenerator) : this(new ParseErrorListener(messageGenerator))
        {
        }

        /// <summary>
        /// パーサをエラーリスナーを指定して初期化します。
        /// </summary>
        /// <param name="errorListener"></param>
        public MapGrammarParser(ParseErrorListener errorListener)
        {
            ErrorListener = errorListener;
            ParserErrors = ErrorListener.Errors.AsReadOnly();
            Store = new VariableStore();
        }

        /// <summary>
        /// 引数に与えられたマップ構文文字列の構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文を表す文字列</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData Parse(string input, MapGrammarParserOption option = MapGrammarParserOption.None)
        {
            if (option.HasFlag(MapGrammarParserOption.ParseIncludeSyntaxRecursively))
                option &= ~MapGrammarParserOption.ParseIncludeSyntaxRecursively; // Include対応はできないのでOptionを削除する

            return Parse(input, null, option);
        }

        /// <summary>
        /// 引数に与えられたマップ構文ファイルの構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="filePath">解析するマップ構文のファイルパス</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData ParseFromFile(string filePath, MapGrammarParserOption option = MapGrammarParserOption.None)
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
                return Parse(reader.Text, filePath, option);
            }
        }

        /// <summary>
        /// 引数に与えられたマップ構文文字列の構文解析と評価を行い、MapDataを生成します。
        /// </summary>
        /// <param name="input"></param>
        /// <param name="filePath">解析するマップ構文のファイルパス</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapData Parse(string input, string filePath, MapGrammarParserOption option = MapGrammarParserOption.None)
        {
            MapGrammarAstNodes ast = ParseToAst(input, filePath, option);

            if (ast == null) { return null; }

            MapData value = option.HasFlag(MapGrammarParserOption.ParseIncludeSyntaxRecursively) ?
                (MapData)new EvaluateMapGrammarVisitorWithInclude(Store, Path.GetDirectoryName(filePath), ErrorListener).Visit(ast) : // Includeを再帰的にパースする
                (MapData)new EvaluateMapGrammarVisitor(Store, ErrorListener).Visit(ast)
                ;

            if (value == null) { return null; }

            return value;
        }

        /// <summary>
        /// 引数に与えられたマップ構文の構文解析を行い、ASTを生成します。
        /// </summary>
        /// <param name="input">解析するマップ構文のステートメントを表す文字列</param>
        /// <param name="filePath">解析するマップ構文のファイルパス</param>
        /// <param name="option"></param>
        /// <returns></returns>
        public MapGrammarAstNodes ParseToAst(string input, string filePath = null, MapGrammarParserOption option = MapGrammarParserOption.None)
        {
            Tuple<string, string, int> headerInfo = GetHeaderInfo(input);

            if (option.HasFlag(MapGrammarParserOption.NoHeader))
                headerInfo = new Tuple<string, string, int>("2.02", headerInfo.Item2, headerInfo.Item3);
            if (option.HasFlag(MapGrammarParserOption.ParseAsMapVersion1))
                headerInfo = new Tuple<string, string, int>("1.00", headerInfo.Item2, headerInfo.Item3);
            if (option.HasFlag(MapGrammarParserOption.ParseAsMapVersion2))
                headerInfo = new Tuple<string, string, int>("2.02", headerInfo.Item2, headerInfo.Item3);

            if (headerInfo.Item1 == null)
            {
                ErrorListener.AddNewError(ParseMessageType.InvalidMapFormat, filePath, 0, 0);
                return null;
            }

            if (option.HasFlag(MapGrammarParserOption.ClearVariables))
                Store.ClearVar();

            var inputStream = new AntlrInputStream(input.Substring(headerInfo.Item3));

            if (!option.HasFlag(MapGrammarParserOption.NoClearErrors))
            {
                ErrorListener.Errors.Clear();
            }

            RootNode ast = null;
            if (headerInfo.Item1 != null && (headerInfo.Item1[0] == '1' || headerInfo.Item1[0] == '0'))
            {
                // V1Parser
                var lexer = new V1Parser.SyntaxDefinitions.MapGrammarV1Lexer(inputStream);
                var commonTokneStream = new CommonTokenStream(lexer);

                var parser = new V1Parser.SyntaxDefinitions.MapGrammarV1Parser(commonTokneStream);
                parser.AddErrorListener(ErrorListener);
                parser.ErrorHandler = new V1Parser.V1ParserErrorStrategy(ErrorListener.MessageGenerator, filePath);
                var cst = parser.root();
                if (cst == null) { return null; }
                ast = new V1Parser.BuildAstVisitor().VisitRoot(cst) as RootNode;
            }
            else
            {
                // V2Parser
                var lexer = new V2Parser.SyntaxDefinitions.MapGrammarV2Lexer(inputStream);
                var commonTokneStream = new CommonTokenStream(lexer);

                var parser = new V2Parser.SyntaxDefinitions.MapGrammarV2Parser(commonTokneStream);
                parser.AddErrorListener(ErrorListener);
                parser.ErrorHandler = new V2Parser.V2ParserErrorStrategy(ErrorListener.MessageGenerator, filePath);
                var cst = parser.root();
                if (cst == null) { return null; }
                ast = new V2Parser.BuildAstVisitor().VisitRoot(cst) as RootNode;
            }

            // バージョン情報とエンコーディング情報の代入
            // TODO: ここで代入するのはおかしい気がする
            ast.Version = headerInfo.Item1;
            if (headerInfo.Item2 != null)
                ast.Encoding = headerInfo.Item2;

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
        protected internal Tuple<string, string, int> GetHeaderInfo(string input)
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
