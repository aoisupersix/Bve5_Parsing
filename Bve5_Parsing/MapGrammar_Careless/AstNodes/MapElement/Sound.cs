using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless.AstNodes.Sound
{
    /*
     * SoundのAST木定義
     */

    /// <summary>
    /// Sound[key].Play()
    /// </summary>
    public class PlayNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            //引数なし
        }
    }
}