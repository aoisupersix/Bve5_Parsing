using Irony.Parsing;
using Irony.Interpreter;
using Bve5_Parsing.MapGrammar.AstNodes;

namespace Bve5_Parsing.MapGrammar
{
    [Language("MapGrammar", "0.1", "Bve5.7 Map file grammar.")]
    class MapGrammar : InterpretedLanguageGrammar
    {
        public MapGrammar() : base(false)
        {
            /*
             * 構文定義
             */

            #region 終端記号の定義
            var key = new StringLiteral("Key", "'", StringOptions.NoEscapes);
            var encode = new IdentifierTerminal("Encode");
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
            var mapFile = new NonTerminal("MapFile", typeof(MapFileNode));
            var statement = new NonTerminal("Statement", typeof(StatementNode));
            var statements = new NonTerminal("Statements", typeof(StatementsNode));
            var basicState = new NonTerminal("BasicStatement", typeof(BasicStateNode));
            var basicStates = new NonTerminal("BasicStatements", typeof(BasicStatesNode));
            var basicStatesPlus = new NonTerminal("BasicStatementsPlus", typeof(BasicStatesNode));

            var mapElement = new NonTerminal("Element"); //マップ要素ごとの構文
            var dist = new NonTerminal("Distance", typeof(DistNode)); //距離程
            #endregion 基本ステートメントと距離程の定義

            #region 変数・数式の定義
            var expr = new NonTerminal("Expr", typeof(ExprNode));
            var nullableExpr = new NonTerminal("NullableExpr", typeof(NullableExprNode));
            var identifierKey = new NonTerminal("IdentifierKey", typeof(IdentifierKeyNode));
            var term = new NonTerminal("Term", typeof(TermNode));
            var var = new NonTerminal("Var", typeof(VarNode));
            var varAssign = new NonTerminal("VarAssign", typeof(VarAssignNode));
            var op = new NonTerminal("Op");
            #endregion 変数・数式の定義

            #region リストファイル読み込みの定義
            var loadListFile = new NonTerminal("LoadListFile", typeof(LoadListFileNode));
            var loadStrList = new NonTerminal("LoadStructureList", typeof(LoadListFileNode));
            var loadStaList = new NonTerminal("LoadStationList", typeof(LoadListFileNode));
            var loadSigList = new NonTerminal("LoadSignalList", typeof(LoadListFileNode));
            var loadSoundList = new NonTerminal("LoadSoundList", typeof(LoadListFileNode));
            var loadSound3DList = new NonTerminal("LoadSound3DList", typeof(LoadListFileNode));
            #endregion リストファイル読み込みの定義

            #region 引数の定義
            var rawKey = new NonTerminal("RawKey", typeof(RawKeyNode));
            var strKey = new NonTerminal("StrKey");
            var strKeys = new NonTerminal("StrKeys", typeof(StrKeysNode));
            var exprArg = new NonTerminal("exprArg");
            var exprArgs = new NonTerminal("exprArgs", typeof(ExprArgsNode));
            var nullableExprArg = new NonTerminal("nullableExprArg");
            var nullableExprArgs = new NonTerminal("nullableExprArgs", typeof(ExprArgsNode));
            #endregion 引数の定義

            #region 曲線とカントの定義
            var curve = new NonTerminal("Curve");
            var curve_setGauge = new NonTerminal("Curve.SetGauge", typeof(AstNodes.Curve.SetGaugeNode));
            var curve_setCenter = new NonTerminal("Curve.SetCenter", typeof(AstNodes.Curve.SetCenterNode));
            var curve_setFunction = new NonTerminal("Curve.SetFunction", typeof(AstNodes.Curve.SetFunctionNode));
            var curve_beginTransition = new NonTerminal("Curve.BeginTransition", typeof(AstNodes.Curve.BeginTransitionNode));
            var curve_begin = new NonTerminal("Curve.Begin", typeof(AstNodes.Curve.BeginNode));
            var curve_end = new NonTerminal("Curve.End", typeof(AstNodes.Curve.EndNode));
            var curve_interpolate = new NonTerminal("Curve.Interpolate", typeof(AstNodes.Curve.InterpolateNode));
            var curve_change = new NonTerminal("Curve.Change", typeof(AstNodes.Curve.ChangeNode));
            #endregion 曲線とカントの定義

            #region 自軌道の勾配の定義
            var gradient = new NonTerminal("Gradient");
            var gradient_beginTransition = new NonTerminal("Gradient.BeginTransition", typeof(AstNodes.Gradient.BeginTransition));
            var gradient_begin = new NonTerminal("Gradient.Begin", typeof(AstNodes.Gradient.BeginNode));
            var gradient_end = new NonTerminal("Gradient.End", typeof(AstNodes.Gradient.EndNode));
            var gradient_interpolate = new NonTerminal("Gradient.Interpolate", typeof(AstNodes.Gradient.InterpolateNode));
            #endregion 自軌道の勾配の定義

            #region 他軌道
            var track = new NonTerminal("Track");
            var track_x_interpolate = new NonTerminal("Track.X.Interpolate", typeof(AstNodes.Track.XInterpolateNode));
            var track_y_interpolate = new NonTerminal("Track.Y.Interpolate", typeof(AstNodes.Track.YInterpolateNode));
            var track_position = new NonTerminal("Track.Position", typeof(AstNodes.Track.Position));
            var track_cant_setGauge = new NonTerminal("Track.Cant.SetGauge", typeof(AstNodes.Track.CantSetGaugeNode));
            var track_cant_setCenter = new NonTerminal("Track.Cant.SetCenter", typeof(AstNodes.Track.CantSetCenterNode));
            var track_cant_setFunction = new NonTerminal("Track.Cant.SetFunction", typeof(AstNodes.Track.CantSetFunctionNode));
            var track_cant_beginTransition = new NonTerminal("Track.Cant.BeginTransition", typeof(AstNodes.Track.CantBeginTransitionNode));
            var track_cant_begin = new NonTerminal("Track.Cant.Begin", typeof(AstNodes.Track.CantBeginNode));
            var track_cant_end = new NonTerminal("Track.Cant.End", typeof(AstNodes.Track.CantEndNode));
            var track_cant_interpolate = new NonTerminal("Track.Cant.Interpolate", typeof(AstNodes.Track.CantInterpolateNode));
            #endregion 他軌道

            #region ストラクチャ
            var structure = new NonTerminal("Structure");
            var structure_put = new NonTerminal("Structure.Put", typeof(AstNodes.Structure.PutNode));
            var structure_put0 = new NonTerminal("Structure.Put0", typeof(AstNodes.Structure.Put0Node));
            var structure_putBetween = new NonTerminal("Structure.PutBetween", typeof(AstNodes.Structure.PutBetweenNode));
            #endregion ストラクチャ

            #region 連続ストラクチャ
            var repeater = new NonTerminal("Repeater");
            var repeater_begin = new NonTerminal("Repeater.Begin", typeof(AstNodes.Repeater.BeginNode));
            var repeater_begin0 = new NonTerminal("Repeater.Begin0", typeof(AstNodes.Repeater.Begin0Node));
            var repeater_end = new NonTerminal("Repeater.End", typeof(AstNodes.Repeater.EndNode));
            var background_change = new NonTerminal("Background.Change", typeof(AstNodes.Repeater.BackGroundChangeNode));
            #endregion 連続ストラクチャ

            #region 停車場
            var station = new NonTerminal("Station");
            var station_put = new NonTerminal("Station.Put", typeof(AstNodes.Station.PutNode));
            #endregion 停車場

            #region 閉塞
            var section = new NonTerminal("Section");
            var section_begin = new NonTerminal("Section.Begin", typeof(AstNodes.Section.BeginNode));
            var section_setSpeedLimit = new NonTerminal("Section.SetSpeedLimit", typeof(AstNodes.Section.SetSpeedLimitNode));
            #endregion 閉塞

            #region 地上信号機
            var signal = new NonTerminal("Signal");
            var signal_put = new NonTerminal("Signal.Put", typeof(AstNodes.Signal.PutNode));
            #endregion 地上信号機

            #region 地上子
            var beacon = new NonTerminal("Beacon");
            var beacon_put = new NonTerminal("Beacon.Put", typeof(AstNodes.Beacon.PutNode));
            #endregion 地上子

            #region 速度制限
            var speedLimit = new NonTerminal("SpeedLimit");
            var speedLimit_begin = new NonTerminal("SpeedLimit.Begin", typeof(AstNodes.SpeedLimit.BeginNode));
            var speedLimit_end = new NonTerminal("SpeedLimit.End", typeof(AstNodes.SpeedLimit.EndNode));
            #endregion 速度制限

            #region 先行列車
            var preTrain = new NonTerminal("PreTrain");
            var preTrain_pass = new NonTerminal("PreTrain.Pass", typeof(AstNodes.PreTrain.PassNode));
            #endregion 先行列車

            #region 光源
            var light = new NonTerminal("Light");
            var light_ambient = new NonTerminal("Light.Ambient", typeof(AstNodes.Light.AmbientNode));
            var light_diffuse = new NonTerminal("Light.Diffuse", typeof(AstNodes.Light.DiffuseNode));
            var light_direction = new NonTerminal("Light.Direction", typeof(AstNodes.Light.DirectionNode));
            #endregion 光源

            #region 霧効果
            var fog = new NonTerminal("Fog");
            var fog_interpolate = new NonTerminal("Fog.Interpolate", typeof(AstNodes.Fog.InterpolateNode));
            #endregion 霧効果

            #region 風景描画距離
            var drawDistance = new NonTerminal("DrawDistance");
            var drawDistance_change = new NonTerminal("DrawDistance.Change", typeof(AstNodes.DrawDistance.ChangeNode));
            #endregion 風景描画距離

            #region 運転台の明るさ
            var cabIlluminance = new NonTerminal("CabIlluminance");
            var cabIlluminance_interpolate = new NonTerminal("CabIlluminance.Interpolate", typeof(AstNodes.CabIlluminance.InterpolateNode));
            #endregion 運転台の明るさ

            #region 軌道変位
            var irregularity = new NonTerminal("Irregularity");
            var irregularity_change = new NonTerminal("Irregularity.Change", typeof(AstNodes.Irregularity.ChangeNode));
            #endregion 軌道変位

            #region 粘着特性
            var adhesion = new NonTerminal("Adhesion");
            var adhesion_change = new NonTerminal("Adhesion.Change", typeof(AstNodes.Adhesion.ChangeNode));
            #endregion 粘着特性

            #region 音
            var sound = new NonTerminal("Sound");
            var sound_play = new NonTerminal("Sound.Play", typeof(AstNodes.Sound.PlayNode));
            #endregion 音

            #region 固定音源
            var sound3D = new NonTerminal("Sound3D");
            var sound3D_put = new NonTerminal("Sound3D.Put", typeof(AstNodes.Sound3D.PutNode));
            #endregion 固定音源

            #region 走行音
            var rollingNoise = new NonTerminal("RollingNoise");
            var rollingNoise_change = new NonTerminal("RollingNoise.Change", typeof(AstNodes.RollingNoise.ChangeNode));
            #endregion 走行音

            #region フランジきしり音
            var flangeNoise = new NonTerminal("FlangeNoise");
            var flangeNoise_change = new NonTerminal("FlangeNoise.Change", typeof(AstNodes.FlangeNoise.ChangeNode));
            #endregion フランジきしり音

            #region 分岐器通過音
            var jointNoise = new NonTerminal("JointNoise");
            var jointNoise_play = new NonTerminal("JointNoise.Play", typeof(AstNodes.JointNoise.PlayNode));
            #endregion 分岐器通過音

            #region 他列車
            var train = new NonTerminal("Train");
            var train_add = new NonTerminal("Train.Add", typeof(AstNodes.Train.AddNode));
            var train_load = new NonTerminal("Train.Load", typeof(AstNodes.Train.LoadNode));
            var train_enable = new NonTerminal("Train.Enable", typeof(AstNodes.Train.EnableNode));
            var train_stop = new NonTerminal("Train.Stop", typeof(AstNodes.Train.StopNode));
            #endregion 他列車

            #region 他マップの挿入
            var include = new NonTerminal("Include", typeof(IncludeNode));
            #endregion 他マップの挿入

            /*
             * 文法の定義ここから
             */
            Root = mapFile; //ルート

            #region 基本ステートメントと距離程の文法
            mapFile.Rule = ToTerm("BveTs") + "Map" + num + ":" + encode + statements | ToTerm("BveTs") + "Map" + num + statements;
            statements.Rule = MakeStarRule(statements, statement);
            statement.Rule = dist | basicState;
            dist.Rule = expr + end;
            basicStates.Rule = MakeStarRule(basicStates, basicState);
            basicState.Rule = mapElement + end;
            mapElement.Rule = varAssign | loadListFile | curve | gradient | track | structure | repeater | station | section | signal | beacon
                | speedLimit | preTrain | light | fog | drawDistance | cabIlluminance | irregularity | adhesion | sound
                | sound3D | rollingNoise | flangeNoise | jointNoise | train | include;
            #endregion 基本ステートメントと距離程の文法

            #region 変数・数式の定義
            identifierKey.Rule = key | var;
            op.Rule = plus | minus | mul | div | mod;
            term.Rule = num | key | var;
            expr.Rule = term | term + op + expr | "(" + expr + ")";
            nullableExpr.Rule = expr | "null" | Empty;
            var.Rule = PreferShiftHere() + doll + varName;
            varAssign.Rule = var + equal + expr;
            #endregion 変数・数式の定義

            #region リストファイル読み込みの文法
            loadListFile.Rule = loadStrList | loadStaList | loadSigList | loadSoundList | loadSound3DList;
            loadStrList.Rule = "Structure" + dot + "Load" + "(" + identifierKey + ")";
            loadStaList.Rule = "Station" + dot + "Load" + "(" + identifierKey + ")";
            loadSigList.Rule = "Signal" + dot + "Load" + "(" + identifierKey + ")";
            loadSoundList.Rule = "Sound" + dot + "Load" + "(" + identifierKey + ")";
            loadSound3DList.Rule = "Sound3D" + dot + "Load" + "(" + identifierKey + ")";
            #endregion リストファイル読み込みの文法

            #region 引数の文法
            rawKey.Rule = num | identifierKey | Empty;
            strKey.Rule = comma + identifierKey;
            strKeys.Rule = MakeStarRule(strKeys, strKey);
            exprArg.Rule = comma + nullableExpr;
            exprArgs.Rule = MakeStarRule(exprArgs, exprArg);
            nullableExprArg.Rule = comma + nullableExpr;
            nullableExprArgs.Rule = MakeStarRule(nullableExprArgs, nullableExprArg);
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

            curve_setGauge.Rule = PreferShiftHere() + "Curve" + dot + "SetGauge" + "(" + nullableExpr + ")";
            curve_setCenter.Rule = PreferShiftHere() + "Curve" + dot + "SetCenter" + "(" + nullableExpr + ")";
            curve_setFunction.Rule = PreferShiftHere() + "Curve" + dot + "SetFunction" + "(" + nullableExpr + ")";
            curve_beginTransition.Rule = PreferShiftHere() + "Curve" + dot + "BeginTransition" + "(" + ")";
            curve_begin.Rule =
                  PreferShiftHere() + "Curve" + dot + "Begin" + "(" + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Curve" + dot + "Begin" + "(" + nullableExpr + ")";
            curve_end.Rule = "Curve" + dot + "End" + "(" + ")";
            curve_interpolate.Rule =
                  PreferShiftHere() + "Curve" + dot + "Interpolate" + "(" + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Curve" + dot + "Interpolate" + "(" + expr + ")"
                | PreferShiftHere() + "Curve" + dot + "Interpolate" + "(" + ")";
            curve_change.Rule = PreferShiftHere() + "Curve" + dot + "Change" + "(" + nullableExpr + ")";
            #endregion 曲線とカントの文法

            #region 自軌道の勾配の文法
            gradient.Rule =
                  gradient_beginTransition
                | gradient_begin
                | gradient_end
                | gradient_interpolate;

            gradient_beginTransition.Rule = PreferShiftHere() + "Gradient" + dot + "BeginTransition" + "(" + ")";
            gradient_begin.Rule = PreferShiftHere() + "Gradient" + dot + "Begin" + "(" + nullableExpr + ")";
            gradient_end.Rule = PreferShiftHere() + "Gradient" + dot + "End" + "(" + ")";
            gradient_interpolate.Rule =
                  PreferShiftHere() + "Gradient" + dot + "Interpolate" + "(" + expr + ")"
                | PreferShiftHere() + "Gradient" + dot + "Interpolate" + "(" + ")";
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

            track_x_interpolate.Rule =
                  PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "X" + dot + "Interpolate" + "(" + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "X" + dot + "Interpolate" + "(" + expr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "X" + dot + "Interpolate" + "(" + ")";
            track_y_interpolate.Rule =
                  PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Y" + dot + "Interpolate" + "(" + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Y" + dot + "Interpolate" + "(" + expr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Y" + dot + "Interpolate" + "(" + ")";
            track_position.Rule =
                  PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Position" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Position" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Position" + "(" + nullableExpr + comma + nullableExpr + ")";
            track_cant_setGauge.Rule = PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "SetGauge" + "(" + nullableExpr + ")";
            track_cant_setCenter.Rule = PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "SetCenter" + "(" + nullableExpr + ")";
            track_cant_setFunction.Rule = PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "SetFunction" + "(" + nullableExpr + ")";
            track_cant_beginTransition.Rule = PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "BeginTransition" + "(" + ")";
            track_cant_begin.Rule = PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "Begin" + "(" + nullableExpr + ")";
            track_cant_end.Rule = PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "End" + "(" + ")";
            track_cant_interpolate.Rule =
                  PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "Interpolate" + "(" + expr + ")"
                | PreferShiftHere() + "Track" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Cant" + dot + "Interpolate" + "(" + ")";
            #endregion 他軌道

            #region ストラクチャ
            structure.Rule =
                  structure_put
                | structure_put0
                | structure_putBetween;

            structure_put.Rule = PreferShiftHere() + "Structure" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Put" + "(" + rawKey + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            structure_put0.Rule = PreferShiftHere() + "Structure" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Put0" + "(" + rawKey + comma + nullableExpr + comma + nullableExpr + ")";
            structure_putBetween.Rule =
                  PreferShiftHere() + "Structure" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "PutBetween" + "(" + rawKey + comma + rawKey + comma + nullableExpr + ")"
                | PreferShiftHere() + "Structure" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "PutBetween" + "(" + rawKey + comma + rawKey + ")";
            #endregion ストラクチャ

            #region 連続ストラクチャ
            repeater.Rule =
                  repeater_begin
                | repeater_begin0
                | repeater_end
                | background_change;

            repeater_begin.Rule = PreferShiftHere() + "Repeater" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Begin" + "(" + rawKey + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + identifierKey + strKeys + ")";
            repeater_begin0.Rule = PreferShiftHere() + "Repeater" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Begin0" + "(" + rawKey + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + identifierKey + strKeys + ")";
            repeater_end.Rule = PreferShiftHere() + "Repeater" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "End" + "(" + ")";
            background_change.Rule = PreferShiftHere() + "BackGround" + dot + "Change" + "(" + identifierKey + ")";
            #endregion 連続ストラクチャ

            #region 停車場
            station.Rule = station_put;
            station_put.Rule = PreferShiftHere() + "Station" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Put" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            #endregion 停車場

            #region 閉塞
            section.Rule =
                  section_begin
                | section_setSpeedLimit;

            section_begin.Rule = PreferShiftHere() + "Section" + dot + "Begin" + "(" + nullableExpr + nullableExprArgs + ")";
            section_setSpeedLimit.Rule = PreferShiftHere() + "Section" + dot + "SetSpeedLimit" + "(" + nullableExpr + nullableExprArgs + ")";
            #endregion 閉塞

            #region 地上信号機
            signal.Rule = signal_put;
            signal_put.Rule =
                  PreferShiftHere() + "Signal" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Put" + "(" + nullableExpr + comma + rawKey + comma + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Signal" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Put" + "(" + nullableExpr + comma + rawKey + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            #endregion 地上信号機

            #region 地上子
            beacon.Rule = beacon_put;
            beacon_put.Rule = PreferShiftHere() + "Beacon" + dot + "Put" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            #endregion 地上子

            #region 速度制限
            speedLimit.Rule = speedLimit_begin | speedLimit_end;
            speedLimit_begin.Rule = PreferShiftHere() + "SpeedLimit" + dot + "Begin" + "(" + nullableExpr + ")";
            speedLimit_end.Rule = PreferShiftHere() + "SpeedLimit" + dot + "End" + "(" + ")";
            #endregion 速度制限

            #region 先行列車
            preTrain.Rule = preTrain_pass;
            preTrain_pass.Rule =
                  PreferShiftHere() + "PreTrain" + dot + "Pass" + "(" + expr + ")";
            #endregion 先行列車

            #region 光源
            light.Rule = light_ambient | light_diffuse | light_direction;
            light_ambient.Rule = PreferShiftHere() + "Light" + dot + "Ambient" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            light_diffuse.Rule = PreferShiftHere() + "Light" + dot + "Diffuse" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            light_direction.Rule = PreferShiftHere() + "Light" + dot + "Direction" + "(" + nullableExpr + comma + nullableExpr + ")";
            #endregion 光源

            #region 霧効果
            fog.Rule = fog_interpolate;
            fog_interpolate.Rule =
                  PreferShiftHere() + "Fog" + dot + "Interpolate" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")"
                | PreferShiftHere() + "Fog" + dot + "Interpolate" + "(" + expr + ")"
                | PreferShiftHere() + "Fog" + dot + "Interpolate" + "(" + ")";
            #endregion 霧効果

            #region 風景描画距離
            drawDistance.Rule = drawDistance_change;
            drawDistance_change.Rule = PreferShiftHere() + "DrawDistance" + dot + "Change" + "(" + nullableExpr + ")";
            #endregion 風景描画距離

            #region 運転台の明るさ
            cabIlluminance.Rule = cabIlluminance_interpolate;
            cabIlluminance_interpolate.Rule = PreferShiftHere() + "CabIlluminance" + dot + "Interpolate" + "(" + nullableExpr + ")";
            #endregion 運転台の明るさ

            #region 軌道変位
            irregularity.Rule = irregularity_change;
            irregularity_change.Rule = PreferShiftHere() + "Irregularity" + dot + "Change" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            #endregion 軌道変位

            #region 粘着特性
            adhesion.Rule = adhesion_change;
            adhesion_change.Rule =
                  PreferShiftHere() + "Adhesion" + dot + "Change" + "(" + nullableExpr + ")"
                | PreferShiftHere() + "Adhesion" + dot + "Change" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            #endregion 粘着特性

            #region 音
            sound.Rule = sound_play;
            sound_play.Rule = PreferShiftHere() + "Sound" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Play" + "(" + ")";
            #endregion 音

            #region 固定音源
            sound3D.Rule = sound3D_put;
            sound3D_put.Rule = PreferShiftHere() + "Sound3D" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Put" + "(" + nullableExpr + comma + nullableExpr + ")";
            #endregion 固定音源

            #region 走行音
            rollingNoise.Rule = rollingNoise_change;
            rollingNoise_change.Rule = PreferShiftHere() + "RollingNoise" + dot + "Change" + "(" + nullableExpr + ")";
            #endregion 走行音

            #region フランジきしり音
            flangeNoise.Rule = flangeNoise_change;
            flangeNoise_change.Rule = PreferShiftHere() + "FlangeNoise" + dot + "Change" + "(" + nullableExpr + ")";
            #endregion フランジきしり音

            #region 分岐器通過音
            jointNoise.Rule = jointNoise_play;
            jointNoise_play.Rule = PreferShiftHere() + "JointNoise" + dot + "Play" + "(" + nullableExpr + ")";
            #endregion 分岐器通過音

            #region 他列車
            train.Rule = train_add | train_load | train_enable | train_stop;
            train_add.Rule = PreferShiftHere() + "Train" + dot + "Add" + "(" + rawKey + comma + identifierKey + comma + identifierKey + comma + nullableExpr + ")";
            train_load.Rule = PreferShiftHere() + "Train" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Load" + "(" + identifierKey + comma + identifierKey + comma + nullableExpr + ")";
            train_enable.Rule =
                  PreferShiftHere() + "Train" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Enable" + "(" + "'" + expr + ":" + expr + ":" + expr + "'" + ")"
                | PreferShiftHere() + "Train" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Enable" + "(" + nullableExpr + ")";
            train_stop.Rule = PreferShiftHere() + "Train" + ToTerm("[") + identifierKey + ToTerm("]") + dot + "Stop" + "(" + nullableExpr + comma + nullableExpr + comma + nullableExpr + comma + nullableExpr + ")";
            #endregion 他列車

            #region 他マップの挿入
            include.Rule = "Include" + identifierKey;
            #endregion 他マップの挿入

            basicState.ErrorRule = SyntaxError + end;

            //演算子の優先順位設定
            RegisterOperators(0, plus, minus);
            RegisterOperators(1, mul, div, mod);
            RegisterOperators(3, equal);

            RegisterBracePair("(", ")");

            //非表示にする構文
            MarkTransient(statement, basicState, loadListFile, mapElement, op, curve, gradient, track, structure, repeater, station, section, signal, beacon, speedLimit, preTrain, light, fog, drawDistance, cabIlluminance, irregularity, adhesion, sound, sound3D, rollingNoise, flangeNoise, jointNoise, train, strKey, exprArg, nullableExprArg);
            MarkPunctuation(doll, dot, comma, end, ToTerm("("), ToTerm(")"), ToTerm("["), ToTerm("]"), ToTerm("'"), ToTerm(":"));

            //コメント
            var comment1 = new CommentTerminal("Comment#", "#", "\n", "\r");
            var comment2 = new CommentTerminal("Comment//", "//", "\n", "\r");
            this.NonGrammarTerminals.Add(comment1);
            this.NonGrammarTerminals.Add(comment2);


            this.LanguageFlags = LanguageFlags.NewLineBeforeEOF | LanguageFlags.CreateAst | LanguageFlags.TailRecursive;
        }
    }
}
