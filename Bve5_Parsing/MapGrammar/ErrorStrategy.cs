using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;
using System;

namespace Bve5_Parsing.MapGrammar
{
    internal class MapGrammarErrorStrategy : DefaultErrorStrategy
    {
        public override void Recover(Parser recognizer, RecognitionException e)
        {
            // This should should move the current position to the next 'END' token
            //base.Recover(recognizer, e);

            ITokenStream tokenStream = (ITokenStream)recognizer.InputStream;

            Console.WriteLine(tokenStream.Index + ":" + tokenStream.La(1));

            if (tokenStream.Index > 0 && ( tokenStream.La(-1) == MapGrammarLexer.STATE_END || tokenStream.La(-1) == MapGrammarLexer.Eof) )
                return;

            // Verify we are where we expect to be
            while (tokenStream.La(1) != MapGrammarLexer.STATE_END && tokenStream.La(1) != MapGrammarLexer.Eof)
            {
                // Get the next possible tokens
                IntervalSet intervalSet = GetErrorRecoverySet(recognizer);

                // Move to the next token
                tokenStream.Consume();

                Console.WriteLine(tokenStream.Index + ":" + tokenStream.La(-1) + "->" + tokenStream.La(1));
            }
        }
    }
}
