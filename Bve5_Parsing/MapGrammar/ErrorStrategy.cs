using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.V1Parser.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammar構文解析器のエラー処理を行うクラス。
    /// </summary>
    internal class MapGrammarErrorStrategy : DefaultErrorStrategy
    {
        #region フィールド

        public const string ERRMSG_FAILED_PREDICATE = "{0}の検証に失敗しました。";
        public const string ERRMSG_INPUT_MISMATCH = "入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。";
        public const string ERRMSG_MISSING_TOKEN = "入力文字列{0}にマップ構文'{1}'がありません。";
        public const string ERRMSG_NO_VIABLE = "入力文字列{0}の構文を特定できませんでした。";
        public const string ERRMSG_UNWANTED_TOKEN = "入力文字列{0}が予期されたマップ構文'{1}'と一致しませんでした。";

        #endregion

        #region Report Error
        protected override void ReportFailedPredicate([NotNull] Parser recognizer, [NotNull] FailedPredicateException e)
        {
            var msg = string.Format(ERRMSG_FAILED_PREDICATE, GetTokenErrorDisplay(e.OffendingToken));
            NotifyErrorListeners(recognizer, msg, e);
        }

        protected override void ReportInputMismatch([NotNull] Parser recognizer, [NotNull] InputMismatchException e)
        {
            var msg = string.Format(ERRMSG_INPUT_MISMATCH, GetTokenErrorDisplay(e.OffendingToken), e.GetExpectedTokens().ToString(recognizer.Vocabulary));
            NotifyErrorListeners(recognizer, msg, e);
        }

        protected override void ReportMissingToken([NotNull] Parser recognizer)
        {
            if (InErrorRecoveryMode(recognizer))
            {
                return;
            }
            BeginErrorCondition(recognizer);
            IToken t = recognizer.CurrentToken;
            IntervalSet expecting = GetExpectedTokens(recognizer);

            var msg = string.Format(ERRMSG_MISSING_TOKEN, GetTokenErrorDisplay(t), expecting.ToString(recognizer.Vocabulary));
            NotifyErrorListeners(recognizer, t, msg);
        }

        protected override void ReportNoViableAlternative([NotNull] Parser recognizer, [NotNull] NoViableAltException e)
        {
            var msg = string.Format(ERRMSG_NO_VIABLE, GetTokenErrorDisplay(e.OffendingToken), e.GetExpectedTokens().ToString(recognizer.Vocabulary));
            NotifyErrorListeners(recognizer, msg, e);
        }

        protected override void ReportUnwantedToken([NotNull] Parser recognizer)
        {
            if (InErrorRecoveryMode(recognizer))
            {
                return;
            }
            BeginErrorCondition(recognizer);
            IToken t = recognizer.CurrentToken;
            string tokenName = GetTokenErrorDisplay(t);
            IntervalSet expecting = GetExpectedTokens(recognizer);

            var msg = string.Format(ERRMSG_UNWANTED_TOKEN, tokenName, expecting.ToString(recognizer.Vocabulary));
            NotifyErrorListeners(recognizer, t, msg);
        }

        protected override void NotifyErrorListeners([NotNull] Parser recognizer, string message, RecognitionException e)
        {
            recognizer.NotifyErrorListeners(e.OffendingToken, message, e);
        }

        protected void NotifyErrorListeners([NotNull] Parser recognizer, IToken offendingToken, string message)
        {
            recognizer.NotifyErrorListeners(offendingToken, message, null);
        }
        #endregion
    }
}
