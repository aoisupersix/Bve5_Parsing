using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Strict.AstNodes
{
    /*
     * 変数のAST木定義
     */

    /// <summary>
    /// 変数 $varName
    /// </summary>
    public class VarNode : AstNode
    {
        public string Name { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            Name = nodes[0].Token.Value.ToString();
        }
    }

    /// <summary>
    /// 変数宣言 $varName = Expr;
    /// </summary>
    public class VarAssignNode : AstNode
    {
        public AstNode VarName { get; private set; }
        public AstNode VarValue { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //変数名と変数値を取得して変数に登録
            VarNode var = (VarNode)nodes[0].AstNode;
            ExprNode exprNode = (ExprNode)nodes[2].AstNode;
            Vars vars = Vars.GetInstance();
            vars.SetVar(var.Name, exprNode.Value);

            VarName = AddChild("VarName:" + var.Name, nodes[0]);
            VarValue = AddChild("VarValue:" + exprNode.Value, nodes[2]);
        }
    }
}
