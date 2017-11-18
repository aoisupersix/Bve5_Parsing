using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /*
     * 文字列のAST木
     */

    public class StrKeysNode : AstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            foreach(var node in nodes)
            {
                AddChild("StrKeys", node);
            }
        }
    }
    
    /// <summary>
    /// 文字列 / 変数識別子
    /// </summary>
    public class IdentifierKeyNode : AstNode
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            object node = nodes[0].AstNode;
            if (node.GetType() == typeof(VarNode))
            {
                //変数
                VarNode varNode = (VarNode)node;
                Vars vars = Vars.GetInstance();
                Value = vars.GetVar(varNode.Name).ToString();
                AddChild(varNode.Name + ":" + Value, nodes[0]);
            }
            else
            {
                //文字列
                Value = nodes[0].Token.Value.ToString();
                AddChild("IdenKey:" + Value, nodes[0]);
            }
        }
    }

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
                if(nodes[0].AstNode.GetType() == typeof(IdentifierKeyNode))
                {
                    //IdenKey
                    IdentifierKeyNode idenKey = (IdentifierKeyNode)nodes[0].AstNode;
                    Value = idenKey.Value;
                }
                else
                {
                    //num
                    Value = nodes[0].Token.Value.ToString();
                }
            }
            else
            {
                //Empty
                Value = "0";
            }
        }
    }
}
