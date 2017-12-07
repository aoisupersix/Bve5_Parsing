using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;
using System;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammar構文解析器のエラーからの復帰処理を行うクラス
    /// 次のステートメントの終わり、もしくは構文の終わり(EOF)まで字句を読み飛ばします。
    /// </summary>
    internal class MapGrammarErrorStrategy : DefaultErrorStrategy
    {
        /// <summary>
        /// エラーの復帰処理を行います。
        /// </summary>
        /// <param name="recognizer"></param>
        /// <param name="e"></param>
        public override void Recover(Parser recognizer, RecognitionException e)
        {
            // This should should move the current position to the next 'END' token
            //base.Recover(recognizer, e);

            ITokenStream tokenStream = (ITokenStream)recognizer.InputStream;

            Console.WriteLine(tokenStream.Index + ":" + tokenStream.La(1));

            if (tokenStream.Index > 0 && (tokenStream.La(-1) == MapGrammarLexer.STATE_END || tokenStream.La(-1) == MapGrammarLexer.Eof))
                return;

            // Verify we are where we expect to be
            while (tokenStream.La(1) != MapGrammarLexer.STATE_END && tokenStream.La(1) != MapGrammarLexer.Eof)
            {

                // Move to the next token
                recognizer.Consume();
                Console.WriteLine(tokenStream.Index + ":" + tokenStream.La(-1) + "->" + tokenStream.La(1) + ",recognizer=" + recognizer.CurrentToken);
            }
        }
    }
}
