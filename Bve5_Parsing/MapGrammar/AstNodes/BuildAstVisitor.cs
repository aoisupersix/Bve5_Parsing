using System;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar.AstNodes
{

    /// <summary>
    /// CSTを辿ってASTを作成するVisitorクラス
    /// </summary>
    internal class BuildAstVisitor : MapGrammarParserBaseVisitor<MapGrammarAstNodes>
    {
        /// <summary>
        /// ルートノード
        /// ステートメント+をノードに追加する
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitRoot([NotNull] SyntaxDefinitions.MapGrammarParser.RootContext context)
        {
            var node = new RootNode();
            foreach (var state in context.statement())
            {
                node.StatementList.Add(Visit(state));
            }
            return node;
        }

        #region Statement Visitors

        /// <summary>
        /// ステートメントノード(自軌道の平面曲線)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCurveState([NotNull] SyntaxDefinitions.MapGrammarParser.CurveStateContext context)
        {
            return Visit(context.curve());
        }

        /// <summary>
        /// ステートメントノード(変数宣言)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarAssignState([NotNull] SyntaxDefinitions.MapGrammarParser.VarAssignStateContext context)
        {
            return base.Visit(context.varAssign());
        }
        #endregion Statement Visitors

        #region Curve Visitors
        /// <summary>
        /// 自軌道の平面曲線ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCurve([NotNull] SyntaxDefinitions.MapGrammarParser.CurveContext context)
        {
            CurveNode node = new CurveNode();

            node.Function = context.func1.Text.ToLower();
            //引数の登録
            switch (node.Function)
            {
                case "begin":                                                       /* Begin(radius, cant?) */
                    node.Arguments.Add("radius", Visit(context.radius));
                    if (context.cant != null)
                        node.Arguments.Add("cant", Visit(context.cant));
                    break;
            }

            return node;
        }
        #endregion Curve Visitors

        #region Expression & Variable Visitors

        /// <summary>
        /// 変数宣言ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarAssign([NotNull] SyntaxDefinitions.MapGrammarParser.VarAssignContext context)
        {

            return new VarAssignNode
            {
                VarName = context.v.varName,
                Value = Visit(context.expr())
            };
        }

        /// <summary>
        /// 括弧数式ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitParensExpr([NotNull] SyntaxDefinitions.MapGrammarParser.ParensExprContext context)
        {
            return base.Visit(context.expr());
        }

        /// <summary>
        /// ユーナリ演算ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitUnaryExpr([NotNull] SyntaxDefinitions.MapGrammarParser.UnaryExprContext context)
        {
            switch (context.op.Type)
            {
                case MapGrammarLexer.PLUS:
                    return Visit(context.expr());
                case MapGrammarLexer.MINUS:
                    return new NegateNode { InnerNode = Visit(context.expr()) };
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 演算ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitInfixExpr([NotNull] SyntaxDefinitions.MapGrammarParser.InfixExprContext context)
        {
            InfixExpressionNode node;

            switch (context.op.Type)
            {
                case MapGrammarLexer.PLUS:
                    node = new AdditionNode();
                    break;
                case MapGrammarLexer.MINUS:
                    node = new SubtractionNode();
                    break;
                case MapGrammarLexer.MULT:
                    node = new MultiplicationNode();
                    break;
                case MapGrammarLexer.DIV:
                    node = new DivisionNode();
                    break;
                case MapGrammarLexer.MOD:
                    node = new ModuloNode();
                    break;
                default:
                    throw new NotSupportedException();
            }

            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        /// <summary>
        /// 項ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNumberExpr([NotNull] SyntaxDefinitions.MapGrammarParser.NumberExprContext context)
        {
            return new NumberNode { Value = double.Parse(context.num.Text, System.Globalization.NumberStyles.AllowDecimalPoint) };
        }

        /// <summary>
        /// 文字列ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStringExpr([NotNull] SyntaxDefinitions.MapGrammarParser.StringExprContext context)
        {
            return new StringNode { Value = context.str.text };
        }

        /// <summary>
        /// 変数ノード
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarExpr([NotNull] SyntaxDefinitions.MapGrammarParser.VarExprContext context)
        {
            return new VarNode { Key = context.v.varName };
        }

        #endregion Expression & Variable Visitors
    }
}
