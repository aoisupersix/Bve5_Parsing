
namespace Bve5_Parsing
{
    /// <summary>
    /// パーサのエラー情報を格納するクラスです。
    /// 必要に応じてコンソールに表示するなどして下さい。
    /// </summary>
    public class ParseError
    {
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

        public ParseError(int line, int column, string msg)
        {
            Line = line;
            Column = column;
            Message = msg;
        }
    }
}
