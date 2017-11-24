using Antlr4.Runtime;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// パーサのエラー処理クラス TODO
    /// </summary>
    public class ErrorListener : BaseErrorListener
    {
        public override void SyntaxError(IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            base.SyntaxError(recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }
    }
}
