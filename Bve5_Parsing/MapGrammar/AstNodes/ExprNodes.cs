
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /*
     * 数式関係のAST木定義
     */

    /// <summary>
    /// 数式の引数
    /// </summary>
    public class ExprArgsNode : AstNode
    {
        public AstNode ExprNode { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            AddChild("Expr", nodes[0]);
        }
    }

    /// <summary>
    /// 数式
    /// </summary>
    public class ExprNode : AstNode
    {
        public double Value { get; private set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //演算を行いValueに代入する
            if (nodes.Count == 3)
            {
                //演算(term + op + expr)
                TermNode term = (TermNode)nodes[0].AstNode;
                double val1 = (double)term.Value;
                string op = nodes[1].Term.ToString();
                ExprNode exprNode = (ExprNode)nodes[2].AstNode;
                double var2 = exprNode.Value;
                Value = exprNode.Calc(val1, exprNode.Value, op);
                AddChild("Expr:", nodes[2]);
            }
            else if (nodes[0].ToString().Equals("Expr"))
            {
                //括弧
                ExprNode exprNode = (ExprNode)nodes[0].AstNode;
                Value = exprNode.Value;
                AddChild("kakko", nodes[0]);
            }
            else
            {
                //Term単体
                TermNode term = (TermNode)nodes[0].AstNode;
                Value = (double)term.Value;
                AddChild("Term:" + Value, nodes[0]);
            }
        }

        public double Calc(double val1, double val2, string op)
        {
            double result = 0;

            switch (op)
            {
                case "+":
                    result = val1 + val2;
                    break;
                case "-":
                    result = val1 - val2;
                    break;
                case "*":
                    result = val1 * val2;
                    break;
                case "/":
                    result = val1 / val2;
                    break;
                case "%":
                    result = val1 % val2;
                    break;
            }

            return result;
        }
    }

    /// <summary>
    /// null許容型数式
    /// </summary>
    public class NullableExprNode : AstNode
    {
        public double? Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            if(nodes.Count == 0)
            {
                //Empty
                Value = 0;
            }
            else if (nodes[0].Term.ToString().Equals("Expr"))
            {
                //数式
                ExprNode expr = (ExprNode)nodes[0].AstNode;
                Value = expr.Value;
                AddChild("Expr=" + expr.Value, nodes[0]);
            }
            else
            {
                //null
                Value = null;
                AddChild("Expr=" + nodes[0].ToString(), nodes[0]);
            }
        }
    }

    /// <summary>
    /// 数式の項(数値/文字列/変数)
    /// </summary>
    public class TermNode : AstNode
    {
        public object Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //Termの値を取得しValueに設定する
            if (nodes[0].ToString().Equals("Var"))
            {
                //変数
                VarNode varNode = (VarNode)nodes[0].AstNode;
                Vars vars = Vars.GetInstance();
                Value = vars.GetVar(varNode.Name);
                AddChild(varNode.Name + ":" + Value, nodes[0]);
            }
            else
            {
                //定数
                object val = nodes[0].Token.Value;
                if (val.GetType() == typeof(StringLiteral))
                {
                    //文字列
                    Value = val.ToString();
                }
                else
                {
                    //数字列
                    Value = double.Parse(val.ToString());
                }
            }
        }
    }
}
