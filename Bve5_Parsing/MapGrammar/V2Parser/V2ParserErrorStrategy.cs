using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.V2Parser.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar.V2Parser
{
    internal class V2ParserErrorStrategy : MapGrammarErrorStrategy
    {
        public V2ParserErrorStrategy(MessageGenerator messageGenerator, string filePath = null) : base(messageGenerator, filePath) { }

        /// <summary>
        /// エラーの復帰処理を行います。
        /// 次のステートメントの終わり、もしくは構文の終わり(EOF)まで字句を読み飛ばします。
        /// </summary>
        /// <param name="recognizer"></param>
        /// <param name="e"></param>
        public override void Recover(Parser recognizer, RecognitionException e)
        {
            int ttype = recognizer.InputStream.La(1);
            while (ttype != MapGrammarV2Lexer.Eof && ttype != MapGrammarV2Lexer.STATE_END)
            {
                recognizer.Consume();
                ttype = recognizer.InputStream.La(1);
            }
        }
    }
}
