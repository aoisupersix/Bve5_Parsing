using System;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.V2Parser.SyntaxDefinitions;
using static Bve5_Parsing.MapGrammar.V2Parser.SyntaxDefinitions.MapGrammarV2Parser;

namespace Bve5_Parsing.MapGrammar.V2Parser
{

    /// <summary>
    /// CSTを巡回してASTを作成するVisitorクラス
    /// </summary>
    public class BuildAstVisitor : MapGrammarV2ParserBaseVisitor<MapGrammarAstNodes>
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
            return Visit(context.distance());
        }

        /// <summary>
        /// インクルードステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitIncludeState([NotNull] IncludeStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.include());
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
        /// 風景描画距離ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitDrawdistanceState([NotNull] DrawdistanceStateContext context)
        {
            MapGrammarAstNodes node;
            try
            {
                node = Visit(context.drawdistance());
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
        /// 変数宣言ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>変数宣言ASTノード</returns>
        public override MapGrammarAstNodes VisitVarAssignState([NotNull] VarAssignStateContext context)
        {
            return base.Visit(context.varAssign());
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
        /// 距離程の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>距離程ASTノード</returns>
        public override MapGrammarAstNodes VisitDistance([NotNull] DistanceContext context)
        {
            DistanceNode node = new DistanceNode(context.Start, context.Stop)
            {
                Value = Visit(context.expr())
            };
            return node;
        }

        public override MapGrammarAstNodes VisitInclude([NotNull] IncludeContext context)
        {
            return new IncludeNode(context.Start, context.Stop)
            {
                FilePath = Visit(context.filepath)
            };
        }

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
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Track, context.func.Text, context.element?.Text);
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
                foreach (var strKey in context.exprArgs())
                {
                    beginNode.AddStructureKey(Visit(strKey));
                }
                return beginNode;
            }
            else if (node.FunctionName == MapFunctionName.Begin0)
            {
                //Repeater.Begin0は手動対応
                var begin0Node = node as RepeaterBegin0Node;
                foreach (var strKey in context.exprArgs())
                {
                    begin0Node.AddStructureKey(Visit(strKey));
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
                beginNode.AddSignal(Visit(context.nullableExpr()));
                foreach (var sigIdx in context.exprArgs())
                {
                    beginNode.AddSignal(Visit(sigIdx));
                }
                return beginNode;
            }
            else if (node.FunctionName == MapFunctionName.Setspeedlimit)
            {
                //Section.Setspeedlimitは手動対応
                var speedlimitNode = node as SectionSetspeedlimitNode;
                speedlimitNode.AddV(Visit(context.nullableExpr()));
                foreach (var spdLmt in context.exprArgs())
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
                speedlimitNode.AddV(Visit(context.nullableExpr()[0]));
                foreach (var spdLmt in context.exprArgs())
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
                setSignalNode.AddV(Visit(context.nullableExpr()));
                foreach (var spdLmt in context.exprArgs())
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
            node.Time = Visit(context.nullableExpr());

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
        /// 風景描画距離の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitDrawdistance([NotNull] DrawdistanceContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Drawdistance, context.func.Text);
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
                node.Time = Visit(context.nullableExpr()[0]);

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
        #endregion マップ構文Visitors

        #region 数式と変数Visitors

        /// <summary>
        /// 変数宣言Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarAssign([NotNull] VarAssignContext context)
        {

            return new VarAssignNode(context.Start, context.Stop)
            {
                VarName = context.v.varName,
                Value = Visit(context.expr())
            };
        }

        /// <summary>
        /// 数式の連続引数Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitExprArgs([NotNull] ExprArgsContext context)
        {
            return Visit(context.nullableExpr());
        }

        /// <summary>
        /// null許容数式Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNullableExpr([NotNull] NullableExprContext context)
        {
            if (context.ChildCount == 0 || context.nullSyntax != null)                       /* null */
                //return new NumberNode { Value = 0 };
                return null;

            return Visit(context.expr());
        }

        /// <summary>
        /// 括弧数式Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitParensExpr([NotNull] ParensExprContext context)
        {
            return base.Visit(context.expr());
        }

        /// <summary>
        /// ユーナリ演算Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitUnaryExpr([NotNull] UnaryExprContext context)
        {
            switch (context.op.Type)
            {
                case MapGrammarV2Lexer.PLUS:
                    return Visit(context.expr());
                case MapGrammarV2Lexer.MINUS:
                    return new UnaryNode(context.Start, context.Stop) { InnerNode = Visit(context.expr()) };
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// 演算Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitInfixExpr([NotNull] InfixExprContext context)
        {
            InfixExpressionNode node;

            switch (context.op.Type)
            {
                case MapGrammarV2Lexer.PLUS:
                    node = new AdditionNode(context.Start, context.Stop);
                    break;
                case MapGrammarV2Lexer.MINUS:
                    node = new SubtractionNode(context.Start, context.Stop);
                    break;
                case MapGrammarV2Lexer.MULT:
                    node = new MultiplicationNode(context.Start, context.Stop);
                    break;
                case MapGrammarV2Lexer.DIV:
                    node = new DivisionNode(context.Start, context.Stop);
                    break;
                case MapGrammarV2Lexer.MOD:
                    node = new ModuloNode(context.Start, context.Stop);
                    break;
                default:
                    throw new NotSupportedException();
            }

            node.Left = Visit(context.left);
            node.Right = Visit(context.right);

            return node;
        }

        /// <summary>
        /// 数学関数AbsVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitAbsExpr([NotNull] AbsExprContext context)
        {
            return new AbsNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数Atan2Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitAtan2Expr([NotNull] Atan2ExprContext context)
        {
            return new Atan2Node(context.Start, context.Stop) { Y = Visit(context.y), X = Visit(context.x) };
        }

        /// <summary>
        /// 数学関数CeilVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCeilExpr([NotNull] CeilExprContext context)
        {
            return new CeilNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数CosVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCosExpr([NotNull] CosExprContext context)
        {
            return new CosNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数ExpVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitExpExpr([NotNull] ExpExprContext context)
        {
            return new ExpNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数FloorVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitFloorExpr([NotNull] FloorExprContext context)
        {
            return new FloorNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数LogVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitLogExpr([NotNull] LogExprContext context)
        {
            return new LogNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数PowVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitPowExpr([NotNull] PowExprContext context)
        {
            return new Atan2Node(context.Start, context.Stop) { X = Visit(context.x), Y = Visit(context.y) };
        }

        /// <summary>
        /// 数学関数RandVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitRandExpr([NotNull] RandExprContext context)
        {
            RandNode node = new RandNode(context.Start, context.Stop);
            if (context.value != null)
                node.Value = Visit(context.value);

            return node;
        }

        /// <summary>
        /// 数学関数SinVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitSinExpr([NotNull] SinExprContext context)
        {
            return new SinNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数SqrtVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitSqrtExpr([NotNull] SqrtExprContext context)
        {
            return new SqrtNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数字項Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNumberExpr([NotNull] NumberExprContext context)
        {
            return new NumberNode(context.Start, context.Stop) { Value = context.num };
        }

        /// <summary>
        /// 距離変数項Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitDistanceExpr([NotNull] DistanceExprContext context)
        {
            return new DistanceVariableNode(context.Start, context.Stop);
        }

        /// <summary>
        /// 文字列Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStringExpr([NotNull] StringExprContext context)
        {
            return new StringNode(context.Start, context.Stop) { Value = context.str.text };
        }

        /// <summary>
        /// 変数Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarExpr([NotNull] VarExprContext context)
        {
            return new VarNode(context.Start, context.Stop) { Key = context.v.varName };
        }

        #endregion 数式と変数Visitors

        public override MapGrammarAstNodes VisitString([NotNull] StringContext context)
        {
            return new StringNode(context.Start, context.Stop) { Value = context.text };
        }
    }
}
