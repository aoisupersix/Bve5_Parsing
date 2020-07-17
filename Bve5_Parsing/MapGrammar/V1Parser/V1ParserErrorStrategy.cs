using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.V1Parser.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar.V1Parser
{
    internal class V1ParserErrorStrategy : MapGrammarErrorStrategy
    {
        public V1ParserErrorStrategy(MessageGenerator messageGenerator, string filePath = null) : base(messageGenerator, filePath) { }

        /// <summary>
        /// エラーの復帰処理を行います。
        /// 次のステートメントの終わり、もしくは構文の終わり(EOF)まで字句を読み飛ばします。
        /// </summary>
        /// <param name="recognizer"></param>
        /// <param name="e"></param>
        public override void Recover(Parser recognizer, RecognitionException e)
        {
            int ttype = recognizer.InputStream.La(1);
            while (ttype != MapGrammarV1Lexer.Eof && ttype != MapGrammarV1Lexer.STATE_END && ttype != MapGrammarV1Lexer.ARG_END)
            {
                recognizer.Consume();
                ttype = recognizer.InputStream.La(1);
            }
        }
    }
}
