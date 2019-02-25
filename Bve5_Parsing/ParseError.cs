
namespace Bve5_Parsing
{
    /// <summary>
    /// エラー種別
    /// </summary>
    public enum ParseErrorLevel
    {
        /// <summary>
        /// 警告
        /// </summary>
        Warning,

        /// <summary>
        /// エラー
        /// </summary>
        Error
    }

    /// <summary>
    /// パーサのエラー情報を格納するクラスです。
    /// 必要に応じてコンソールに表示するなどして下さい。
    /// </summary>
    public class ParseError
    {
        /// <summary>
        /// エラー種別
        /// </summary>
        public ParseErrorLevel ErrorLevel { get; }

        /// <summary>
        /// エラー対象構文の開始行
        /// </summary>
        public int Line { get; }

        /// <summary>
        /// エラー対象構文の開始列
        /// </summary>
        public int Column { get; }

        /// <summary>
        /// エラーメッセージ
        /// </summary>
        public string Message { get; }

        public ParseError(ParseErrorLevel errLevel, int line, int column, string msg)
        {
            ErrorLevel = errLevel;
            Line = line;
            Column = column;
            Message = msg;
        }
    }
}
