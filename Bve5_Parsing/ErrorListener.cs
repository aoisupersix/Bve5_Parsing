using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace Bve5_Parsing
{
    /// <summary>
    /// パーサのデフォルトエラー処理クラス
    /// エラーに対して任意の処理を行ってErrorsに格納します。
    /// このクラスを継承し、パーサのコンストラクタに指定することで構文解析のエラーを取得できます。
    /// </summary>
    public class ParseErrorListener : BaseErrorListener
    {
        #region フィールド
        #endregion

        #region プロパティ
        public MessageGenerator MessageGenerator { get; }

        /// <summary>
        /// パースエラーメッセージ
        /// </summary>
        public List<ParseError> Errors { get; }
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
            return MessageGenerator.GetMassage(ParseMessageType.InputMismatch, null, GetTokenDisplayName(token), e.GetExpectedTokens().ToString(recognizer.Vocabulary));
        }

        protected string GetErrorMessage(IRecognizer recognizer, IToken token, NoViableAltException e)
        {
            return MessageGenerator.GetMassage(ParseMessageType.NoViable, null, GetTokenDisplayName(token));
        }

        protected string GetErrorMessage(IRecognizer recognizer, IToken token, LexerNoViableAltException e)
        {
            return MessageGenerator.GetMassage(ParseMessageType.NoViable, null, GetTokenDisplayName(token));
        }

        protected string GetErrorMessage(IRecognizer recognizer, IToken token, FailedPredicateException e)
        {
            return MessageGenerator.GetMassage(ParseMessageType.NoViable, null, GetTokenDisplayName(token));
        }
        #endregion

        public ParseErrorListener() : this(new MessageGenerator())
        {
        }

        public ParseErrorListener(MessageGenerator messageGenerator)
        {
            MessageGenerator = messageGenerator;
            Errors = new List<ParseError>();
        }

        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            var m = msg;
            if (e != null)
                m = GetErrorMessage(recognizer, offendingSymbol, (dynamic)e.GetBaseException());
            var error = new ParseError(ParseErrorLevel.Error, line, charPositionInLine, m);
            Errors.Add(error);
        }

        public void AddNewWarning(ParseMessageType messageType, string filePath, int startLine, int startColumn, params object[] args)
        {
            Errors.Add(new ParseError(ParseErrorLevel.Warning, startLine, startColumn, MessageGenerator.GetMassage(messageType, filePath, args)));
        }

        public void AddNewWarning(ParseMessageType messageType, string filePath, IToken start, params object[] args)
        {
            AddNewWarning(messageType, filePath, start.Line, start.Column, args);
        }

        public void AddNewError(ParseMessageType messageType, string filePath, int startLine, int startColumn, params object[] args)
        {
            Errors.Add(new ParseError(ParseErrorLevel.Error, startLine, startColumn, MessageGenerator.GetMassage(messageType, filePath, args)));
        }

        public void AddNewError(ParseMessageType messageType, string filePath, IToken start, params object[] args)
        {
            AddNewError(messageType, filePath, start.Line, start.Column, args);
        }
    }
}
