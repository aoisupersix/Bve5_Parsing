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
        /// ルートVisitor
        /// ステートメント+をノードに追加する
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitRoot([NotNull] SyntaxDefinitions.MapGrammarParser.RootContext context)
        {
            var node = new RootNode();

            foreach (var state in context.statement())
            {
                MapGrammarAstNodes child = base.Visit(state);
                if(child != null)
                    node.StatementList.Add(child);
            }
            return node;
        }

        #region Statement Visitors

        /// <summary>
        /// ステートメントVisitor(距離程)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitDistState([NotNull] SyntaxDefinitions.MapGrammarParser.DistStateContext context)
        {
            return Visit(context.distance());
        }

        /// <summary>
        /// ステートメントVisitor(自軌道の平面曲線)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCurveState([NotNull] SyntaxDefinitions.MapGrammarParser.CurveStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.curve());
            }
            catch(NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// ステートメントVisitor(縦曲線)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitGradientState([NotNull] SyntaxDefinitions.MapGrammarParser.GradientStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.gradient());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// ステートメントVisitor(変数宣言)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarAssignState([NotNull] SyntaxDefinitions.MapGrammarParser.VarAssignStateContext context)
        {
            return base.Visit(context.varAssign());
        }
        #endregion Statement Visitors

        #region Distance Visitors

        /// <summary>
        /// 距離程Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitDistance([NotNull] SyntaxDefinitions.MapGrammarParser.DistanceContext context)
        {
            return new DistanceNode { Value = Visit(context.expr()) };
        }
        #endregion Distance Visitors

        #region Curve Visitors

        /// <summary>
        /// 自軌道の平面曲線Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCurve([NotNull] SyntaxDefinitions.MapGrammarParser.CurveContext context)
        {
            Syntax1 node = new Syntax1();   //Curve構文は全て構文タイプ1

            node.MapElementName = "curve";
            node.FunctionName = context.func1.Text.ToLower();
            //引数の登録
            switch (node.FunctionName)
            {
                case "setgauge":                                                    /* SetGauge(value) */
                    node.Arguments.Add("value", Visit(context.value));
                    break;
                case "setcenter":                                                   /* SetCenter(x) */
                    node.Arguments.Add("x", Visit(context.x));
                    break;
                case "setfunction":                                                 /* SetFunction(id) */
                    node.Arguments.Add("id", Visit(context.id));
                    break;
                case "begintransition":                                             /* BeginTransition() */
                    break;
                case "begin":                                                       /* Begin(radius, cant?) */
                    node.Arguments.Add("radius", Visit(context.radius));
                    if (context.cant != null)
                        node.Arguments.Add("cant", Visit(context.cant));
                    break;
                case "end":                                                         /* End() */
                    break;
                case "interpolate":                                                 /* Interpolate(radius?, cant?) */
                    if (context.radius != null)
                        node.Arguments.Add("radius", Visit(context.radius));
                    if (context.cant != null)
                        node.Arguments.Add("cant", Visit(context.cant));
                    break;
                case "change":                                                      /* Change(radius) */
                    node.Arguments.Add("radius", Visit(context.radius));
                    break;
                
            }

            return node;
        }
        #endregion Curve Visitors

        #region Gradient Visitors

        /// <summary>
        /// 縦曲線Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitGradient([NotNull] SyntaxDefinitions.MapGrammarParser.GradientContext context)
        {
            Syntax1 node = new Syntax1();   //Gradient構文は全て構文タイプ1
            node.MapElementName = "gradient";
            node.FunctionName = context.func1.Text.ToLower();

            switch (node.FunctionName)
            {
                case "begintransition":                                             /* BeginTransition() */
                    break;
                case "begin":                                                       /* Begin(gradient) */
                    node.Arguments.Add("gradient", Visit(context.gradientArgs));
                    break;
                case "end":                                                         /* End() */
                    break;
                case "interpolate":                                                 /* Interpolate(gradient?) */
                    if (context.gradientArgs != null)
                        node.Arguments.Add("gradient", Visit(context.gradientArgs));
                    break;
            }
            return node;
        }
        #endregion Gradient Visitors

        #region Expression & Variable Visitors

        /// <summary>
        /// 変数宣言Visitor
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
        /// null許容数式Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNullableExpr([NotNull] SyntaxDefinitions.MapGrammarParser.NullableExprContext context)
        {
            if (context.ChildCount == 0)                    /* null */
                return new NumberNode { Value = 0 };

            return Visit(context.expr());
        }

        /// <summary>
        /// 括弧数式Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitParensExpr([NotNull] SyntaxDefinitions.MapGrammarParser.ParensExprContext context)
        {
            return base.Visit(context.expr());
        }

        /// <summary>
        /// ユーナリ演算Visitor
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
        /// 演算Visitor
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
        /// 項Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNumberExpr([NotNull] SyntaxDefinitions.MapGrammarParser.NumberExprContext context)
        {
            return new NumberNode { Value = double.Parse(context.num.Text, System.Globalization.NumberStyles.AllowDecimalPoint) };
        }

        /// <summary>
        /// 文字列Visitor
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStringExpr([NotNull] SyntaxDefinitions.MapGrammarParser.StringExprContext context)
        {
            return new StringNode { Value = context.str.text };
        }

        /// <summary>
        /// 変数Visitor
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
