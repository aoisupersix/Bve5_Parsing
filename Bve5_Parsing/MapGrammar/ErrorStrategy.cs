using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammar構文解析器のエラー処理を行うクラス。
    /// </summary>
    internal class MapGrammarErrorStrategy : DefaultErrorStrategy
    {
        #region フィールド
        private readonly MessageGenerator ErrorMessage;
        private readonly string FilePath;
        #endregion

        protected MapGrammarErrorStrategy(MessageGenerator messageGenerator, string filePath = null)
        {
            ErrorMessage = messageGenerator;
            FilePath = filePath;
        }

        #region Report Error
        protected override void ReportFailedPredicate([NotNull] Parser recognizer, [NotNull] FailedPredicateException e)
        {
            var msg = ErrorMessage.GetMassage(ParseMessageType.FailedPredicate, FilePath, GetTokenErrorDisplay(e.OffendingToken));
            NotifyErrorListeners(recognizer, msg, e);
        }

        protected override void ReportInputMismatch([NotNull] Parser recognizer, [NotNull] InputMismatchException e)
        {
            var msg = ErrorMessage.GetMassage(ParseMessageType.InputMismatch, FilePath, GetTokenErrorDisplay(e.OffendingToken), e.GetExpectedTokens().ToString(recognizer.Vocabulary));
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

            var msg = ErrorMessage.GetMassage(ParseMessageType.MissingToken, FilePath, GetTokenErrorDisplay(t), expecting.ToString(recognizer.Vocabulary));
            NotifyErrorListeners(recognizer, t, msg);
        }

        protected override void ReportNoViableAlternative([NotNull] Parser recognizer, [NotNull] NoViableAltException e)
        {
            var msg = ErrorMessage.GetMassage(ParseMessageType.NoViable, FilePath, GetTokenErrorDisplay(e.OffendingToken), e.GetExpectedTokens().ToString(recognizer.Vocabulary));
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

            var msg = ErrorMessage.GetMassage(ParseMessageType.UnwantedToken, FilePath, tokenName, expecting.ToString(recognizer.Vocabulary));
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
