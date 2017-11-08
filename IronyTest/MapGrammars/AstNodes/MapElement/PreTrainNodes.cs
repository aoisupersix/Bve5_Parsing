using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.PreTrainNodes
{
    /*
     * PreTrainのAST木定義
     */

    /// <summary>
    /// PreTrain.Pass(hh:mm:ss) | PreTrain.Pass(second)
    /// </summary>
    public class PassNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if(nodes.Count > 3)
            {
                //hh:mm:ss TODO
                AddArguments("hh", nodes[2]);
                AddArguments("mm", nodes[2]);
                AddArguments("ss", nodes[2]);
            }
            else
            {
                //sec
                AddArguments("second", nodes[2]);
            }
        }
    }
}
