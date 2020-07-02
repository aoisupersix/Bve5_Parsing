using System;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.V1Parser.SyntaxDefinitions;
using static Bve5_Parsing.MapGrammar.V1Parser.SyntaxDefinitions.MapGrammarV1Parser;

namespace Bve5_Parsing.MapGrammar.V1Parser
{

    /// <summary>
    /// CSTを巡回してASTを作成するVisitorクラス
    /// </summary>
    public class BuildAstVisitor : MapGrammarV1ParserBaseVisitor<MapGrammarAstNodes>
    {

        /// <summary>
        /// ルートの巡回
        /// ステートメントの集合をノードに追加する
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>ルートASTノード</returns>
        public override MapGrammarAstNodes VisitRoot([NotNull] RootContext context)
        {
            var node = new RootNode(context.Start, context.Stop);

            foreach (var state in context.statement())
            {
                var child = base.Visit(state);
                if (child != null)
                    node.AddStatementNode(child);
            }
            return node;
        }

        #region ステートメントVisitors

        /// <summary>
        /// 距離程ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>距離程ASTノード</returns>
        public override MapGrammarAstNodes VisitDistState([NotNull] DistStateContext context)
        {
            var numberNode = new NumberNode(context.Start, context.Stop)
            {
                Value = context.num
            };

            return new DistanceNode(context.Start, context.Stop)
            {
                Value = numberNode
            };
        }

        /// <summary>
        /// 平面曲線ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitGaugeState([NotNull] GaugeStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.gauge());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 平面曲線ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCurveState([NotNull] CurveStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.curve());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 縦曲線ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitGradientState([NotNull] GradientStateContext context)
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
        /// 他軌道ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrackState([NotNull] TrackStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.track());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// ストラクチャステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStructureState([NotNull] StructureStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.structure());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 連続ストラクチャステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRepeaterState([NotNull] RepeaterStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.repeater());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 背景ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitBackgroundState([NotNull] BackgroundStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.background());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 停車場ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStationState([NotNull] StationStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.station());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 閉そくステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSectionState([NotNull] SectionStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.section());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 信号機ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSignalState([NotNull] SignalStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.signal());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 地上子ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitBeaconState([NotNull] BeaconStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.beacon());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 速度制限ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSpeedlimitState([NotNull] SpeedlimitStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.speedlimit());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 先行列車ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitPretrainState([NotNull] PretrainStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.pretrain());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 光源ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLightState([NotNull] LightStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.light());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 霧効果ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFogState([NotNull] FogStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.fog());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 運転台の明るさステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCabilluminanceState([NotNull] CabilluminanceStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.cabilluminance());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 軌道変位ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitIrregularityState([NotNull] IrregularityStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.irregularity());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 粘着特性ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitAdhesionState([NotNull] AdhesionStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.adhesion());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 音ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSoundState([NotNull] SoundStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.sound());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 固定音源ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound3dState([NotNull] Sound3dStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.sound3d());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 走行音ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRollingnoiseState([NotNull] RollingnoiseStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.rollingnoise());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// フランジきしり音ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFlangenoiseState([NotNull] FlangenoiseStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.flangenoise());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 分岐器通過音ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitJointnoiseState([NotNull] JointnoiseStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.jointnoise());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// 他列車ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrainState([NotNull] TrainStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.train());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }

        /// <summary>
        /// レガシー関数ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLegacyState([NotNull] LegacyStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.legacy());
            }
            catch (NullReferenceException)
            {
                node = null;
            }

            return node;
        }
        #endregion ステートメントVisitors

        #region マップ構文Visitors

        /// <summary>
        /// 平面曲線の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitGauge([NotNull] GaugeContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Gauge, context.func.Text);
        }

        /// <summary>
        /// 平面曲線の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCurve([NotNull] CurveContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Curve, context.func.Text);
        }

        /// <summary>
        /// 縦曲線の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitGradient([NotNull] GradientContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Gradient, context.func.Text);
        }

        /// <summary>
        /// 他軌道の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrack([NotNull] TrackContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Track, context.func.Text);
        }

        /// <summary>
        /// ストラクチャの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStructure([NotNull] StructureContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Structure, context.func.Text);
        }

        /// <summary>
        /// 連続ストラクチャの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRepeater([NotNull] RepeaterContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Repeater, context.func.Text);

            if (node.FunctionName == MapFunctionName.Begin)
            {
                //Repeater.Beginは手動対応
                var beginNode = node as RepeaterBeginNode;
                foreach (var arg in context.args())
                {
                    beginNode.AddStructureKey(Visit(arg));
                }
                return beginNode;
            }
            else if (node.FunctionName == MapFunctionName.Begin0)
            {
                //Repeater.Begin0は手動対応
                var begin0Node = node as RepeaterBegin0Node;
                foreach (var arg in context.args())
                {
                    begin0Node.AddStructureKey(Visit(arg));
                }
                return begin0Node;
            }

            return node;
        }

        /// <summary>
        /// 背景の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitBackground([NotNull] BackgroundContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Background, context.func.Text);
        }

        /// <summary>
        /// 停車場の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStation([NotNull] StationContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Station, context.func.Text);
        }

        /// <summary>
        /// 閉そくの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSection([NotNull] SectionContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Section, context.func.Text);

            if (node.FunctionName == MapFunctionName.Begin || node.FunctionName == MapFunctionName.Beginnew)
            {
                //Section.BeginとSection.Beginnewは手動対応
                var beginNode = node as SectionBeginNode;
                beginNode.AddSignal(Visit(context.arg()));
                foreach (var sigIdx in context.args())
                {
                    beginNode.AddSignal(Visit(sigIdx));
                }
                return beginNode;
            }
            else if (node.FunctionName == MapFunctionName.Setspeedlimit)
            {
                //Section.Setspeedlimitは手動対応
                var speedlimitNode = node as SectionSetspeedlimitNode;
                speedlimitNode.AddV(Visit(context.arg()));
                foreach (var spdLmt in context.args())
                {
                    speedlimitNode.AddV(Visit(spdLmt));
                }
                return speedlimitNode;
            }

            return node;
        }

        /// <summary>
        /// 信号機の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSignal([NotNull] SignalContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Signal, context.func.Text);

            if (node.FunctionName == MapFunctionName.Speedlimit)
            {
                //Signal.Speedlimitは手動対応
                var speedlimitNode = node as SignalSpeedlimitNode;
                speedlimitNode.AddV(Visit(context.arg()[0]));
                foreach (var spdLmt in context.args())
                {
                    speedlimitNode.AddV(Visit(spdLmt));
                }
                return speedlimitNode;
            }

            return node;
        }

        /// <summary>
        /// 地上子の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitBeacon([NotNull] BeaconContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Beacon, context.func.Text);
        }

        /// <summary>
        /// 速度制限の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSpeedlimit([NotNull] SpeedlimitContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Speedlimit, context.func.Text);

            if (node.FunctionName == MapFunctionName.Setsignal)
            {
                //Speedlimit.Setsignalは手動対応
                var setSignalNode = node as SpeedlimitSetsignalNode;
                setSignalNode.AddV(Visit(context.arg()));
                foreach (var spdLmt in context.args())
                {
                    setSignalNode.AddV(Visit(spdLmt));
                }
                return setSignalNode;
            }

            return node;
        }

        /// <summary>
        /// 先行列車の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitPretrain([NotNull] PretrainContext context)
        {
            var node = new PretrainPassNode(context.start, context.stop);
            // Pretrain.Pass構文の引数がTimeかSecondかの判定は評価時に行う
            // 現時点ではTimeに代入しておく。
            node.Time = Visit(context.arg());

            return node;
        }

        /// <summary>
        /// 光源の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLight([NotNull] LightContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Light, context.func.Text);
        }

        /// <summary>
        /// 霧効果の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFog([NotNull] FogContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Fog, context.func.Text);
        }

        /// <summary>
        /// 運転台の明るさの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCabilluminance([NotNull] CabilluminanceContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Cabilluminance, context.func.Text);
        }

        /// <summary>
        /// 軌道変位の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitIrregularity([NotNull] IrregularityContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Irregularity, context.func.Text);
        }

        /// <summary>
        /// 粘着特性の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitAdhesion([NotNull] AdhesionContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Adhesion, context.func.Text);
        }

        /// <summary>
        /// 音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound([NotNull] SoundContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Sound, context.func.Text);
        }

        /// <summary>
        /// 固定音源の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound3d([NotNull] Sound3dContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Sound3d, context.func.Text);
        }

        /// <summary>
        /// 走行音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRollingnoise([NotNull] RollingnoiseContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Rollingnoise, context.func.Text);
        }

        /// <summary>
        /// フランジきしり音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFlangenoise([NotNull] FlangenoiseContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Flangenoise, context.func.Text);
        }

        /// <summary>
        /// 分岐器通過音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitJointnoise([NotNull] JointnoiseContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Jointnoise, context.func.Text);
        }

        /// <summary>
        /// 他列車の巡回
        /// </summary>
        /// <param name="context"></param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrain([NotNull] TrainContext context)
        {
            var funcName = context.func.Text;
            if (funcName.ToLower() == MapFunctionName.Enable.GetStringValue().ToLower())
            {
                var node = new TrainEnableNode(context.Start, context.Stop);
                node.Key = Visit(context.key);

                // Train.Enable構文の引数がTimeかSecondかの判定は評価時に行う
                // 現時点ではTimeに代入しておく。
                node.Time = Visit(context.time);

                return node;
            }
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Train, context.func.Text);
        }

        /// <summary>
        /// レガシー関数の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLegacy([NotNull] LegacyContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Legacy, context.func.Text);
        }
        #endregion

        #region 数式Visitors

        /// <summary>
        /// 数式の連続引数Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitArgs([NotNull] ArgsContext context)
        {
            return Visit(context.arg());
        }

        /// <summary>
        /// null許容数式Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitArg([NotNull] ArgContext context)
        {
            if (context.ChildCount == 0 || context.nullSyntax != null)                       /* null */
                return null;

            return Visit(context.str);
        }

        #endregion

        public override MapGrammarAstNodes VisitString([NotNull] StringContext context)
        {
            return new StringNode(context.Start, context.Stop) { Value = context.text };
        }
    }
}
