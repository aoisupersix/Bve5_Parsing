using Irony.Parsing;
using Irony.Ast;
using Irony.Interpreter;
using IronyTest.MapGrammars.AstNodes;

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
            var filePath = new IdentifierTerminal("filePath", ExtraChars.TOKEN + ExtraChars.MULTIBYTES + @"\", ExtraChars.TOKEN);
            filePath.AddSuffix(")");
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

            #region リストファイル読み込みの定義
            var loadListFile = new NonTerminal("LoadListFile", typeof(LoadListFileNode));
            var loadStrList = new NonTerminal("LoadStructList", typeof(LoadListFileNode));
            var loadStaList = new NonTerminal("LoadStationList", typeof(LoadListFileNode));
            var loadSigList = new NonTerminal("LoadSignalList", typeof(LoadListFileNode));
            var loadSoundList = new NonTerminal("LoadSoundList", typeof(LoadListFileNode));
            var loadSound3DList = new NonTerminal("LoadSound3DList", typeof(LoadListFileNode));
            #endregion リストファイル読み込みの定義

            #region 引数の定義
            var argTerm = new NonTerminal("ArgTerm");
            var nextArg = new NonTerminal("NextArg");
            var nextArgs = new NonTerminal("NextArgs", typeof(NextArgsNode));
            var arg = new NonTerminal("Arg", typeof(ArgNode));
            var args = new NonTerminal("Args", typeof(ArgsNode));
            #endregion 引数の定義

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
            var gradient_beginTransition = new NonTerminal("Gradient.BeginTransition", typeof(Syntax_1));
            var gradient_begin = new NonTerminal("Gradient.Begin", typeof(Syntax_1));
            var gradient_end = new NonTerminal("Gradient.End", typeof(Syntax_1));
            var gradient_interpolate = new NonTerminal("Gradient.Interpolate", typeof(Syntax_1));
            #endregion 自軌道の勾配の定義

            #region 他軌道
            var track = new NonTerminal("Track");
            var track_x_interpolate = new NonTerminal("Track.X.Interpolate", typeof(Syntax_3));
            var track_y_interpolate = new NonTerminal("Track.Y.Interpolate", typeof(Syntax_3));
            var track_position = new NonTerminal("Track.Position", typeof(Syntax_2));
            var track_cant_setGauge = new NonTerminal("Track.Cant.SetGauge", typeof(Syntax_3));
            var track_cant_setCenter = new NonTerminal("Track.Cant.SetCenter", typeof(Syntax_3));
            var track_cant_setFunction = new NonTerminal("Track.Cant.SetFunction", typeof(Syntax_3));
            var track_cant_beginTransition = new NonTerminal("Track.Cant.BeginTransition", typeof(Syntax_3));
            var track_cant_begin = new NonTerminal("Track.Cant.Begin", typeof(Syntax_3));
            var track_cant_end = new NonTerminal("Track.Cant.End", typeof(Syntax_3));
            var track_cant_interpolate = new NonTerminal("Track.Cant.Interpolate", typeof(Syntax_3));
            #endregion 他軌道

            #region ストラクチャ
            var structure = new NonTerminal("Structure");
            var structure_put = new NonTerminal("Structure.Put", typeof(Syntax_2));
            var structure_put0 = new NonTerminal("Structure.Put0", typeof(Syntax_2));
            var structure_putBetween = new NonTerminal("Structure.PutBetween", typeof(Syntax_2));
            #endregion ストラクチャ

            #region 連続ストラクチャ
            var repeater = new NonTerminal("Repeater");
            var repeater_begin = new NonTerminal("Repeater.Begin", typeof(Syntax_2));
            var repeater_begin0 = new NonTerminal("Repeater.Begin0", typeof(Syntax_2));
            var repeater_end = new NonTerminal("Repeater.End", typeof(Syntax_2));
            var background_change = new NonTerminal("Background.Change", typeof(Syntax_1));
            #endregion 連続ストラクチャ

            #region 停車場
            var station = new NonTerminal("Station");
            var station_put = new NonTerminal("Station.Put", typeof(Syntax_2));
            #endregion 停車場

            /*
             * 文法の定義ここから
             */
            Root = statements; //ルート

            #region 基本ステートメントと距離程の文法
            statements.Rule = MakeStarRule(statements, statement);
            statement.Rule = dist | varAssign | loadListFile;
            dist.Rule = expr + end + basicStates;
            basicStates.Rule = MakeStarRule(basicStates, basicState);
            basicState.Rule = mapElement + end;
            mapElement.Rule = curve | gradient | track | structure | repeater | station;
            #endregion 基本ステートメントと距離程の文法

            #region 変数・数式の定義
            op.Rule = plus | minus | mul | div | mod;
            term.Rule = num | var;
            expr.Rule = term | term + op + expr | "(" + expr + ")";
            var.Rule = doll + varName;
            varAssign.Rule = var + equal + expr + end;
            #endregion 変数・数式の定義

            #region リストファイル読み込みの文法
            loadListFile.Rule = loadStrList | loadStaList | loadSigList | loadSoundList | loadSound3DList;
            loadStrList.Rule = "Structure" + dot + "Load" + "(" + filePath + end;
            loadStaList.Rule = "Station" + dot + "Load" + "(" + filePath + end;
            loadSigList.Rule = "Signal" + dot + "Load" + "(" + filePath + end;
            loadSoundList.Rule = "Sound" + dot + "Load" + "(" + filePath + end;
            loadSound3DList.Rule = "Sound3D" + dot + "Load" + "(" + filePath + end;
            #endregion リストファイル読み込みの文法

            #region 引数の文法
            argTerm.Rule = expr | key;
            nextArg.Rule = comma + argTerm;
            nextArgs.Rule = MakeStarRule(nextArgs, nextArg);
            arg.Rule = argTerm + nextArgs;
            args.Rule = arg | Empty;
            #endregion 引数の文法

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

            curve_setGauge.Rule = "Curve" + dot + "SetGauge" + "(" + args + ")";
            curve_setCenter.Rule = "Curve" + dot + "SetCenter" + "(" + args + ")";
            curve_setFunction.Rule = "Curve" + dot + "SetFunction" + "(" + args + ")";
            curve_beginTransition.Rule = "Curve" + dot + "BeginTransition" + "(" + ")";
            curve_begin.Rule = "Curve" + dot + "Begin" + "(" + args + ")";
            curve_end.Rule = "Curve" + dot + "End" + "(" + ")";
            curve_interpolate.Rule = "Curve" + dot + "Interpolate" + "(" + args + ")";
            curve_change.Rule = "Curve" + dot + "Change" + "(" + args + ")";
            #endregion 曲線とカントの文法

            #region 自軌道の勾配の文法
            gradient.Rule =
                  gradient_beginTransition
                | gradient_begin
                | gradient_end
                | gradient_interpolate;
            gradient_beginTransition.Rule = "Gradient" + dot + "BeginTransition" + "(" + ")";
            gradient_begin.Rule = "Gradient" + dot + "Begin" + "(" + args + ")";
            gradient_end.Rule = "Gradient" + dot + "End" + "(" + ")";
            gradient_interpolate.Rule = "Gradient" + dot + "Interpolate" + "(" + args + ")";
            #endregion 自軌道の勾配の文法

            #region 他軌道
            track.Rule = 
                  track_x_interpolate
                | track_y_interpolate
                | track_position
                | track_cant_setGauge
                | track_cant_setCenter
                | track_cant_setFunction
                | track_cant_beginTransition
                | track_cant_begin
                | track_cant_end
                | track_cant_interpolate;

            track_x_interpolate.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "X" + dot + "Interpolate" + "(" + args + ")";
            track_y_interpolate.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Y" + dot + "Interpolate" + "(" + args + ")";
            track_position.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Position" + "(" + args + ")";
            track_cant_setGauge.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "SetGauge" + "(" + args + ")";
            track_cant_setCenter.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "SetCenter" + "(" + args + ")";
            track_cant_setFunction.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "SetFunction" + "(" + args + ")";
            track_cant_beginTransition.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "BeginTransition" + "(" + ")";
            track_cant_begin.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "Begin" + "(" + args + ")";
            track_cant_end.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "End" + "(" + ")";
            track_cant_interpolate.Rule = "Track" + ToTerm("[") + key + ToTerm("]") + dot + "Cant" + dot + "Interpolate" + "(" + args + ")";
            #endregion 他軌道

            #region ストラクチャ
            structure.Rule =
                  structure_put
                | structure_put0
                | structure_putBetween;

            structure_put.Rule = PreferShiftHere() + "Structure" + ToTerm("[") + key + ToTerm("]") + dot + "Put" + "(" + args + ")";
            structure_put0.Rule = PreferShiftHere() + "Structure" + ToTerm("[") + key + ToTerm("]") + dot + "Put0" + "(" + args + ")";
            structure_putBetween.Rule = PreferShiftHere() + "Structure" + ToTerm("[") + key + ToTerm("]") + dot + "PutBetween" + "(" + args + ")";
            #endregion ストラクチャ

            #region 連続ストラクチャ
            repeater.Rule =
                  repeater_begin
                | repeater_begin0
                | repeater_end
                | background_change;

            repeater_begin.Rule = "Repeater" + ToTerm("[") + key + ToTerm("]") + dot + "Begin" + "(" + args + ")";
            repeater_begin0.Rule = "Repeater" + ToTerm("[") + key + ToTerm("]") + dot + "Begin0" + "(" + args + ")";
            repeater_end.Rule = "Repeater" + ToTerm("[") + key + ToTerm("]") + dot + "End" + "(" + args + ")";
            background_change.Rule = "BackGround" + dot + "Change" + "(" + args + ")";
            #endregion 連続ストラクチャ

            #region 停車場
            station.Rule = station_put;
            station_put.Rule = PreferShiftHere() + "Station" + ToTerm("[") + key + ToTerm("]") + dot + "Put" + "(" + args + ")";
            #endregion 停車場

            //演算子の優先順位設定
            RegisterOperators(0, plus, minus);
            RegisterOperators(1, mul, div, mod);
            RegisterOperators(3, equal);

            RegisterBracePair("(", ")");

            //非表示にする構文
            MarkTransient(statement, basicState, loadListFile, mapElement, op, curve, gradient, track, structure, repeater, station, argTerm, nextArg);
            MarkPunctuation(doll, dot, comma, end, ToTerm("("), ToTerm(")"), ToTerm("["), ToTerm("]"));

            //コメント
            var comment1 = new CommentTerminal("Comment#", "#", "\n", "\r");
            var comment2 = new CommentTerminal("Comment//", "//", "\n", "\r");
            this.NonGrammarTerminals.Add(comment1);
            this.NonGrammarTerminals.Add(comment2);

            this.LanguageFlags = LanguageFlags.NewLineBeforeEOF | LanguageFlags.CreateAst;
        }
    }
}
