using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.SpeedLimit
{
    /*
     * SpeedLimitのAST木定義
     */

    /// <summary>
    /// SpeedLimit.Begin(v)
    /// </summary>
    public class BeginNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("v", nodes, 2);
        }
    }

    /// <summary>
    /// SpeedLimit.End()
    /// </summary>
    public class EndNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            //引数なし
        }
    }
}
