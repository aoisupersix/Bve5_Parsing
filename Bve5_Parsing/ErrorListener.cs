using Antlr4.Runtime;
using System;

namespace Bve5_Parsing
{
    /// <summary>
    /// パーサのデフォルトエラー処理クラス
    /// エラーをコンソールに出力します。
    /// このクラスを継承し、パーサのErrorListenerに指定することで構文解析のエラーを取得できます。
    /// </summary>
    public class ParseErrorListener : BaseErrorListener
    {
        #region フィールド
        /// <summary>
        /// InputMismatchExceptionのエラーメッセージ
        /// </summary>
        public const string ERRMSG_INPUT_MISMATCH = "行{0},列{1}: 入力文字列\"{2}\"がマップ構文と一致しませんでした。";

        /// <summary>
        /// NoViableExceptionのエラーメッセージ
        /// </summary>
        public const string ERRMSG_NO_VIABLE = "行{0},列{1}: 入力文字列\"{2}\"の構文を特定できませんでした。";
        #endregion

        #region エラーメッセージ生成
        private string GetErrorMessage(IRecognizer recognizer, IToken token, int line, int charPositionInLine, InputMismatchException e)
        {
            return string.Format(ERRMSG_INPUT_MISMATCH, line, charPositionInLine, token.Text);
        }

        private string GetErrorMessage(IRecognizer recognizer, IToken token, int line, int charPositionInLine, NoViableAltException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, line, charPositionInLine, token.Text);
        }

        private string GetErrorMessage(IRecognizer recognizer, IToken token, int line, int charPositionInLine, LexerNoViableAltException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, line, charPositionInLine, token.Text);
        }
        #endregion

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var m = GetErrorMessage(recognizer, offendingSymbol, line, charPositionInLine, (dynamic)e.GetBaseException());
            Console.Error.WriteLine(m);
        }
    }
}
