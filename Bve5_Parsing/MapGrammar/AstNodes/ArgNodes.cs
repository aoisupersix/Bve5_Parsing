using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /*
     * 引数関連のAST木
     */

    /// <summary>
    /// nullと数値許容識別子。0は自線を表す
    /// </summary>
    public class RawKeyNode : AstNode
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            if (nodes.Count > 0)
            {
                //値あり
                Value = nodes[0].Token.Value.ToString();
            }
            else
            {
                //Empty
                Value = "0";
            }
        }
    }
}
