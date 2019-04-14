using Antlr4.Runtime;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /// <summary>
    /// AST親クラス
    /// </summary>
	public abstract class MapGrammarAstNodes
    {
        public IToken Start { get; set; }
        public IToken Stop { get; set; }

        public MapGrammarAstNodes(IToken start, IToken stop)
        {
            Start = start;
            Stop = stop;
        }

        public ParseError CreateNewWarning(string msg)
        {
            return new ParseError(ParseErrorLevel.Warning, Start.Line, Start.Column, msg);
        }

        public ParseError CreateNewError(string msg)
        {
            return new ParseError(ParseErrorLevel.Error, Start.Line, Start.Column, msg);
        }
    }
}
