using Antlr4.Runtime;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /// <summary>
    /// マップ構文を示すASTノードのベースクラス。
    /// 全ての変数や数式を含め、全マップ構文がこのクラスを継承しています。
    /// </summary>
	public abstract class MapGrammarAstNodes
    {
        public IToken Start { get; set; }
        public IToken Stop { get; set; }

        protected MapGrammarAstNodes(IToken start, IToken stop)
        {
            Start = start;
            Stop = stop;
        }
    }
}
