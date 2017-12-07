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
            int ttype = recognizer.InputStream.La(1);
            while (ttype != MapGrammarLexer.Eof && ttype != MapGrammarLexer.STATE_END)
            {
                recognizer.Consume();
                ttype = recognizer.InputStream.La(1);
            }
            if (ttype == MapGrammarLexer.STATE_END)
                recognizer.Consume();
        }
    }
}
