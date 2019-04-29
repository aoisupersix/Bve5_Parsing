using Antlr4.Runtime;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /// <summary>
    /// マップ構文を示すASTノードのベースクラス。
    /// 全ての変数や数式を含め、全マップ構文がこのクラスを継承しています。
    /// </summary>
	public abstract class MapGrammarAstNodes
    {
        public IToken Start { get; set; }
        public IToken Stop { get; set; }

        public MapGrammarAstNodes(IToken start, IToken stop)
        {
            Start = start;
            Stop = stop;
        }

        /// <summary>
        /// 警告を示すParseErrorを生成して返します。
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ParseError</returns>
        protected internal ParseError CreateNewWarning(string msg)
        {
            return new ParseError(ParseErrorLevel.Warning, Start.Line, Start.Column, msg);
        }

        /// <summary>
        /// 警告を示すParseErrorを生成して返します。
        /// </summary>
        /// <param name="msg">エラーメッセージ</param>
        /// <returns>ParseError</returns>
        protected internal ParseError CreateNewError(string msg)
        {
            return new ParseError(ParseErrorLevel.Error, Start.Line, Start.Column, msg);
        }
    }
}
