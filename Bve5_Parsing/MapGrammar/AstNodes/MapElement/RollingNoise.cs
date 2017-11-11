using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.RollingNoise
{
    /*
     * RollingNoiseのAST木定義
     */

    /// <summary>
    /// RollingNoise.Change(index)
    /// </summary>
    public class ChangeNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("index", nodes[2]);
        }
    }
}
