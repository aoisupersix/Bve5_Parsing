using Antlr4.Runtime;

namespace Bve5_Parsing
{
    /// <summary>
    /// パーサのデフォルトエラー処理クラス
    /// エラーをコンソールに出力します。
    /// このクラスを継承し、パーサのErrorListenerに指定することで構文解析のエラーを取得できます。
    /// </summary>
    public class ParseErrorListener : BaseErrorListener
    {
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }
    }
}
