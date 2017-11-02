using Irony.Parsing;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;

namespace IronyTest.MapGrammars
{
    [Language("MapGrammar")]
    class MapGrammar : InterpretedLanguageGrammar
    {
        public MapGrammar() : base(false)
        {
            /*
             * 構文定義ここから
             */
            #region 終端記号の定義
            var key = new StringLiteral("Key", "'");
            var varName = new IdentifierTerminal("VarName");
            var num = new NumberLiteral("Num", NumberOptions.AllowSign);
            var doll = ToTerm("$");
            var plus = ToTerm("+");
            var minus = ToTerm("-");
            var mul = ToTerm("*");
            var div = ToTerm("/");
            var mod = ToTerm("%");
            var dot = ToTerm(".");
            var comma = ToTerm(",");
            var end = ToTerm(";");
            var equal = ToTerm("=");
            #endregion 終端記号の定義

            #region 基本ステートメントと距離程の定義
            var statement = new NonTerminal("Statement", typeof(StatementNode));
            var statements = new NonTerminal("Statements", typeof(StatementsNode));
            var basicState = new NonTerminal("BasicStatement", typeof(BasicStateNode));
            var basicStates = new NonTerminal("BasicStatements", typeof(BasicStatesNode));
            var mapElement = new NonTerminal("Element"); //マップ要素ごとの構文
            var dist = new NonTerminal("Distance", typeof(DistNode)); //距離程
            #endregion 基本ステートメントと距離程の定義

            #region 変数・数式の定義
            var expr = new NonTerminal("Expr", typeof(ExprNode));
            var term = new NonTerminal("Term", typeof(TermNode));
            var var = new NonTerminal("Var", typeof(VarNode));
            var varAssign = new NonTerminal("VarAssign", typeof(VarAssignNode));
            var op = new NonTerminal("Op");
            #endregion 変数・数式の定義

            #region 曲線とカントの定義
            var curve = new NonTerminal("Curve");
            var curve_setGauge = new NonTerminal("Curve.SetGauge", typeof(Syntax_1));
            var curve_setCenter = new NonTerminal("Curve.SetCenter", typeof(Syntax_1));
            var curve_setFunction = new NonTerminal("Curve.SetFunction", typeof(Syntax_1));
            var curve_beginTransition = new NonTerminal("Curve.BeginTransition", typeof(Syntax_1));
            var curve_begin = new NonTerminal("Curve.Begin", typeof(Syntax_1));
            var curve_end = new NonTerminal("Curve.End", typeof(Syntax_1));
            var curve_interpolate = new NonTerminal("Curve.Interpolate", typeof(Syntax_1));
            var curve_change = new NonTerminal("Curve.Change", typeof(Syntax_1));
            #endregion 曲線とカントの定義

            #region 自軌道の勾配の定義
            var gradient = new NonTerminal("Gradient");
            var gradient_beginTransition = new NonTerminal("Gradient.BeginTransition");
            var gradient_begin = new NonTerminal("Gradient.Begin");
            var gradient_end = new NonTerminal("Gradient.End");
            var gradient_interpolate = new NonTerminal("Gradient.Interpolate");
            #endregion 自軌道の勾配の定義

            /*
             * 文法の定義ここから
             */
            Root = statements; //ルート

            #region 基本ステートメントと距離程の文法
            statements.Rule = MakeStarRule(statements, statement);
            statement.Rule = dist | varAssign;
            dist.Rule = expr + end + basicStates;
            basicStates.Rule = MakeStarRule(basicStates, basicState);
            basicState.Rule = mapElement + end;
            mapElement.Rule = curve;
            #endregion 基本ステートメントと距離程の文法

            #region 変数・数式の定義
            op.Rule = plus | minus | mul | div | mod;
            term.Rule = num | var;
            expr.Rule = term | term + op + expr | "(" + expr + ")";
            var.Rule = doll + varName;
            varAssign.Rule = var + equal + expr + end;
            #endregion 変数・数式の定義

            #region 曲線とカントの文法
            curve.Rule =
                  curve_setGauge
                | curve_setCenter
                | curve_setFunction
                | curve_beginTransition
                | curve_begin
                | curve_end
                | curve_interpolate
                | curve_change;
            curve_setGauge.Rule = "Curve" + dot + "SetGauge" + "(" + expr + ")";
            curve_setCenter.Rule = "Curve" + dot + "SetCenter" + "(" + expr + ")";
            curve_setFunction.Rule = "Curve" + dot + "SetFunction" + "(" + expr + ")";
            curve_beginTransition.Rule = "Curve" + dot + "BeginTransition" + "(" + ")";
            curve_begin.Rule = "Curve" + dot + "Begin" + "(" + (expr + comma + expr | expr) + ")";
            curve_end.Rule = "Curve" + dot + "End" + "(" + ")";
            curve_interpolate.Rule = "Curve" + dot + "Interpolate" + "(" + (expr + comma + expr | expr  | ReduceHere()) + ")";
            curve_change.Rule = "Curve" + dot + "Change" + "(" + expr + ")";
            #endregion 曲線とカントの文法

            #region 自軌道の勾配の文法
            gradient.Rule =
                  gradient_beginTransition
                | gradient_begin
                | gradient_end
                | gradient_interpolate;
            gradient_beginTransition.Rule = "Gradient" + dot + "BeginTransition" + "(" + ")";
            #endregion 自軌道の勾配の文法

            //演算子の優先順位設定
            RegisterOperators(0, plus, minus);
            RegisterOperators(1, mul, div, mod);
            RegisterOperators(2, equal);

            RegisterBracePair("(", ")");

            //非表示にする構文
            MarkTransient(statement, basicState, mapElement, op, curve);
            MarkPunctuation(doll, dot, comma, end, ToTerm("("), ToTerm(")"));

            //コメント
            var comment1 = new CommentTerminal("Comment#", "#", "\n", "\r");
            var comment2 = new CommentTerminal("Comment//", "//", "\n", "\r");
            this.NonGrammarTerminals.Add(comment1);
            this.NonGrammarTerminals.Add(comment2);

            this.LanguageFlags = LanguageFlags.NewLineBeforeEOF | LanguageFlags.CreateAst;
        }
    }
}
