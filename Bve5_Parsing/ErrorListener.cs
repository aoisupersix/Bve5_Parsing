using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
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
        public const string ERRMSG_INPUT_MISMATCH = "入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。";

        /// <summary>
        /// NoViableExceptionのエラーメッセージ
        /// </summary>
        public const string ERRMSG_NO_VIABLE = "入力文字列{0}の構文を特定できませんでした。";
        #endregion

        #region プロパティ
        /// <summary>
        /// パースエラーメッセージ
        /// </summary>
        public ICollection<ParseError> Errors { get; }
        #endregion

        protected string GetTokenDisplayName(IToken t)
        {
            if (t == null)
            {
                return "<no token>";
            }
            string s = t.Text;
            if (s == null)
            {
                if (t.Type == TokenConstants.Eof)
                {
                    s = "<EOF>";
                }
                else
                {
                    s = "<" + t.Type + ">";
                }
            }
            return EscapeWSAndQuote(s);
        }

        protected string EscapeWSAndQuote([NotNull] string s)
        {
            s = s.Replace("\n", "\\n");
            s = s.Replace("\r", "\\r");
            s = s.Replace("\t", "\\t");
            return "'" + s + "'";
        }

        #region エラーメッセージ生成
        protected string GetErrorMessage(IRecognizer recognizer, IToken token, InputMismatchException e)
        {
            return string.Format(ERRMSG_INPUT_MISMATCH, GetTokenDisplayName(token), e.GetExpectedTokens().ToString(recognizer.Vocabulary));
        }

        protected string GetErrorMessage(IRecognizer recognizer, IToken token, NoViableAltException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, GetTokenDisplayName(token));
        }

        protected string GetErrorMessage(IRecognizer recognizer, IToken token, LexerNoViableAltException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, GetTokenDisplayName(token));
        }

        protected string GetErrorMessage(IRecognizer recognizer, IToken token, FailedPredicateException e)
        {
            return string.Format(ERRMSG_NO_VIABLE, GetTokenDisplayName(token));
        }
        #endregion

        public ParseErrorListener()
        {
            Errors = new List<ParseError>();
        }

        public ParseErrorListener(ICollection<ParseError> errors)
        {
            Errors = errors;
        }

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var m = msg;
            if (e != null)
                m = GetErrorMessage(recognizer, offendingSymbol, (dynamic)e.GetBaseException());
            var error = new ParseError(ParseErrorLevel.Error, line, charPositionInLine, m);
            Errors.Add(error);
        }
    }
}
