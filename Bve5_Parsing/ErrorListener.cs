using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bve5_Parsing
{
    /// <summary>
    /// パーサのデフォルトエラー処理クラス
    /// エラーに対して任意の処理を行ってErrorsに格納します。
    /// このクラスを継承し、パーサのErrorListenerに指定することで構文解析のエラーを取得できます。
    /// </summary>
    public class ParseErrorListener : BaseErrorListener
    {
        #region フィールド
        /// <summary>
        /// InputMismatchExceptionのエラーメッセージ
        /// </summary>
        public const string ERRMSG_INPUT_MISMATCH = "入力文字列\"{0}\"がマップ構文と一致しませんでした。";

        /// <summary>
        /// NoViableExceptionのエラーメッセージ
        /// </summary>
        public const string ERRMSG_NO_VIABLE = "入力文字列\"{0}\"の構文を特定できませんでした。";
        #endregion

        #region プロパティ
        /// <summary>
        /// パースエラーメッセージ
        /// </summary>
        public List<ParseError> Errors { get; }
        #endregion

        #region エラーメッセージ生成
        private string GetErrorMessage(IRecognizer recognizer, IToken token, int line, int charPositionInLine, InputMismatchException e)
        {
            return string.Format(ERRMSG_INPUT_MISMATCH, token.Text);
        }

        private string GetErrorMessage(IRecognizer recognizer, IToken token, int line, int charPositionInLine, NoViableAltException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, token.Text);
        }

        private string GetErrorMessage(IRecognizer recognizer, IToken token, int line, int charPositionInLine, LexerNoViableAltException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, token.Text);
        }
        #endregion

        public ParseErrorListener()
        {
            Errors = new List<ParseError>();
        }

        public ParseErrorListener(IEnumerable<ParseError> errors)
        {
            Errors = errors.ToList();
        }

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var m = GetErrorMessage(recognizer, offendingSymbol, line, charPositionInLine, (dynamic)e.GetBaseException());
            var error = new ParseError(line, charPositionInLine, m);
            Errors.Add(error);
        }
    }
}
