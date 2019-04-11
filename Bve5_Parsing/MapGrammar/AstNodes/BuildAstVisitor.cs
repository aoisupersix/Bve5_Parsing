﻿using System;
using System.Text.RegularExpressions;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar.AstNodes
{

    /// <summary>
    /// CSTを巡回してASTを作成するVisitorクラス
    /// </summary>
    public class BuildAstVisitor : MapGrammarParserBaseVisitor<MapGrammarAstNodes>
    {

        /// <summary>
        /// ルートの巡回
        /// ステートメントの集合をノードに追加する
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>ルートASTノード</returns>
        public override MapGrammarAstNodes VisitRoot([NotNull] SyntaxDefinitions.MapGrammarParser.RootContext context)
        {
            var node = new RootNode(context.Start, context.Stop)
            {
                Version = context.version,
                Encoding = context.encoding()
            };

            foreach (var state in context.statement())
            {
                var child = base.Visit(state);
                if (child != null)
                    node.StatementList.Add(child);
            }
            return node;
        }

        #region ステートメントVisitors

        /// <summary>
        /// 距離程ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>距離程ASTノード</returns>
        public override MapGrammarAstNodes VisitDistState([NotNull] SyntaxDefinitions.MapGrammarParser.DistStateContext context)
        {
            return Visit(context.distance());
        }

        /// <summary>
        /// インクルードステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitIncludeState([NotNull] SyntaxDefinitions.MapGrammarParser.IncludeStateContext context)
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
        public override MapGrammarAstNodes VisitCurveState([NotNull] SyntaxDefinitions.MapGrammarParser.CurveStateContext context)
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
        /// 他軌道ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrackState([NotNull] SyntaxDefinitions.MapGrammarParser.TrackStateContext context)
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
        public override MapGrammarAstNodes VisitStructureState([NotNull] SyntaxDefinitions.MapGrammarParser.StructureStateContext context)
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
        public override MapGrammarAstNodes VisitRepeaterState([NotNull] SyntaxDefinitions.MapGrammarParser.RepeaterStateContext context)
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
        public override MapGrammarAstNodes VisitBackgroundState([NotNull] SyntaxDefinitions.MapGrammarParser.BackgroundStateContext context)
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
        public override MapGrammarAstNodes VisitStationState([NotNull] SyntaxDefinitions.MapGrammarParser.StationStateContext context)
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
        public override MapGrammarAstNodes VisitSectionState([NotNull] SyntaxDefinitions.MapGrammarParser.SectionStateContext context)
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
        public override MapGrammarAstNodes VisitSignalState([NotNull] SyntaxDefinitions.MapGrammarParser.SignalStateContext context)
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
        public override MapGrammarAstNodes VisitBeaconState([NotNull] SyntaxDefinitions.MapGrammarParser.BeaconStateContext context)
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
        public override MapGrammarAstNodes VisitSpeedlimitState([NotNull] SyntaxDefinitions.MapGrammarParser.SpeedlimitStateContext context)
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
        public override MapGrammarAstNodes VisitPretrainState([NotNull] SyntaxDefinitions.MapGrammarParser.PretrainStateContext context)
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
        public override MapGrammarAstNodes VisitLightState([NotNull] SyntaxDefinitions.MapGrammarParser.LightStateContext context)
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
        public override MapGrammarAstNodes VisitFogState([NotNull] SyntaxDefinitions.MapGrammarParser.FogStateContext context)
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
        public override MapGrammarAstNodes VisitDrawdistanceState([NotNull] SyntaxDefinitions.MapGrammarParser.DrawdistanceStateContext context)
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
        public override MapGrammarAstNodes VisitCabilluminanceState([NotNull] SyntaxDefinitions.MapGrammarParser.CabilluminanceStateContext context)
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
        public override MapGrammarAstNodes VisitIrregularityState([NotNull] SyntaxDefinitions.MapGrammarParser.IrregularityStateContext context)
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
        public override MapGrammarAstNodes VisitAdhesionState([NotNull] SyntaxDefinitions.MapGrammarParser.AdhesionStateContext context)
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
        public override MapGrammarAstNodes VisitSoundState([NotNull] SyntaxDefinitions.MapGrammarParser.SoundStateContext context)
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
        public override MapGrammarAstNodes VisitSound3dState([NotNull] SyntaxDefinitions.MapGrammarParser.Sound3dStateContext context)
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
        public override MapGrammarAstNodes VisitRollingnoiseState([NotNull] SyntaxDefinitions.MapGrammarParser.RollingnoiseStateContext context)
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
        public override MapGrammarAstNodes VisitFlangenoiseState([NotNull] SyntaxDefinitions.MapGrammarParser.FlangenoiseStateContext context)
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
        public override MapGrammarAstNodes VisitJointnoiseState([NotNull] SyntaxDefinitions.MapGrammarParser.JointnoiseStateContext context)
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
        public override MapGrammarAstNodes VisitTrainState([NotNull] SyntaxDefinitions.MapGrammarParser.TrainStateContext context)
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
        public override MapGrammarAstNodes VisitVarAssignState([NotNull] SyntaxDefinitions.MapGrammarParser.VarAssignStateContext context)
        {
            return base.Visit(context.varAssign());
        }

        /// <summary>
        /// レガシー関数ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLegacyState([NotNull] SyntaxDefinitions.MapGrammarParser.LegacyStateContext context)
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
        public override MapGrammarAstNodes VisitDistance([NotNull] SyntaxDefinitions.MapGrammarParser.DistanceContext context)
        {
            DistanceNode node = new DistanceNode(context.Start, context.Stop)
            {
                Value = Visit(context.expr())
            };
            return node;
        }

        public override MapGrammarAstNodes VisitInclude([NotNull] SyntaxDefinitions.MapGrammarParser.IncludeContext context)
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
        public override MapGrammarAstNodes VisitCurve([NotNull] SyntaxDefinitions.MapGrammarParser.CurveContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Curve, context.func.Text);
        }

        /// <summary>
        /// 縦曲線の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitGradient([NotNull] SyntaxDefinitions.MapGrammarParser.GradientContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Gradient, context.func.Text);
        }

        /// <summary>
        /// 他軌道の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrack([NotNull] SyntaxDefinitions.MapGrammarParser.TrackContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Track, context.func.Text, context.element?.Text);
        }

        /// <summary>
        /// ストラクチャの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStructure([NotNull] SyntaxDefinitions.MapGrammarParser.StructureContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Structure, context.func.Text);
        }

        /// <summary>
        /// 連続ストラクチャの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRepeater([NotNull] SyntaxDefinitions.MapGrammarParser.RepeaterContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Repeater, context.func.Text);

            if (node.FunctionName == MapFunctionName.Begin)
            {
                //Repeater.Beginは手動対応
                var beginNode = node as RepeaterBeginNode;
                foreach(var strKey in context.strkey())
                {
                    beginNode.AddStructureKey(Visit(strKey));
                }
                return beginNode;
            }
            else if(node.FunctionName == MapFunctionName.Begin0)
            {
                //Repeater.Begin0は手動対応
                var begin0Node = node as RepeaterBegin0Node;
                foreach (var strKey in context.strkey())
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
        public override MapGrammarAstNodes VisitBackground([NotNull] SyntaxDefinitions.MapGrammarParser.BackgroundContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Background, context.func.Text);
        }

        /// <summary>
        /// 停車場の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStation([NotNull] SyntaxDefinitions.MapGrammarParser.StationContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Station, context.func.Text);
        }

        /// <summary>
        /// 閉そくの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSection([NotNull] SyntaxDefinitions.MapGrammarParser.SectionContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Section, context.func.Text);

            if (node.FunctionName == MapFunctionName.Begin || node.FunctionName == MapFunctionName.Beginnew)
            {
                //Section.BeginとSection.Beginnewは手動対応
                var beginNode = node as SectionBeginNode;
                beginNode.AddSignalIndex(Visit(context.nullableExpr()));
                foreach (var sigIdx in context.exprArgs())
                {
                    beginNode.AddSignalIndex(Visit(sigIdx));
                }
                return beginNode;
            }
            else if (node.FunctionName == MapFunctionName.Setspeedlimit)
            {
                //Section.Setspeedlimitは手動対応
                var speedlimitNode = node as SectionSetspeedlimitNode;
                speedlimitNode.AddSpeedLimit(Visit(context.nullableExpr()));
                foreach (var spdLmt in context.exprArgs())
                {
                    speedlimitNode.AddSpeedLimit(Visit(spdLmt));
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
        public override MapGrammarAstNodes VisitSignal([NotNull] SyntaxDefinitions.MapGrammarParser.SignalContext context)
        {
            var node = SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Signal, context.func.Text);

            if (node.FunctionName == MapFunctionName.Speedlimit)
            {
                //Signal.Speedlimitは手動対応
                var speedlimitNode = node as SignalSpeedlimitNode;
                speedlimitNode.AddSpeedLimit(Visit(context.nullableExpr()[0]));
                foreach (var spdLmt in context.exprArgs())
                {
                    speedlimitNode.AddSpeedLimit(Visit(spdLmt));
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
        public override MapGrammarAstNodes VisitBeacon([NotNull] SyntaxDefinitions.MapGrammarParser.BeaconContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Beacon, context.func.Text);
        }

        /// <summary>
        /// 速度制限の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSpeedlimit([NotNull] SyntaxDefinitions.MapGrammarParser.SpeedlimitContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Speedlimit, context.func.Text);
        }

        /// <summary>
        /// 先行列車の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitPretrain([NotNull] SyntaxDefinitions.MapGrammarParser.PretrainContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Pretrain, context.func.Text);
        }

        /// <summary>
        /// 光源の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLight([NotNull] SyntaxDefinitions.MapGrammarParser.LightContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Light, context.func.Text);
        }

        /// <summary>
        /// 霧効果の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFog([NotNull] SyntaxDefinitions.MapGrammarParser.FogContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Fog, context.func.Text);
        }

        /// <summary>
        /// 風景描画距離の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitDrawdistance([NotNull] SyntaxDefinitions.MapGrammarParser.DrawdistanceContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Drawdistance, context.func.Text);
        }

        /// <summary>
        /// 運転台の明るさの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCabilluminance([NotNull] SyntaxDefinitions.MapGrammarParser.CabilluminanceContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Cabilluminance, context.func.Text);
        }

        /// <summary>
        /// 軌道変位の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitIrregularity([NotNull] SyntaxDefinitions.MapGrammarParser.IrregularityContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Irregularity, context.func.Text);
        }

        /// <summary>
        /// 粘着特性の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitAdhesion([NotNull] SyntaxDefinitions.MapGrammarParser.AdhesionContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Adhesion, context.func.Text);
        }

        /// <summary>
        /// 音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound([NotNull] SyntaxDefinitions.MapGrammarParser.SoundContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Sound, context.func.Text);
        }

        /// <summary>
        /// 固定音源の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound3d([NotNull] SyntaxDefinitions.MapGrammarParser.Sound3dContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Sound3d, context.func.Text);
        }

        /// <summary>
        /// 走行音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRollingnoise([NotNull] SyntaxDefinitions.MapGrammarParser.RollingnoiseContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Rollingnoise, context.func.Text);
        }

        /// <summary>
        /// フランジきしり音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFlangenoise([NotNull] SyntaxDefinitions.MapGrammarParser.FlangenoiseContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Flangenoise, context.func.Text);
        }

        /// <summary>
        /// 分岐器通過音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitJointnoise([NotNull] SyntaxDefinitions.MapGrammarParser.JointnoiseContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Jointnoise, context.func.Text);
        }

        /// <summary>
        /// 他列車の巡回
        /// </summary>
        /// <param name="context"></param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrain([NotNull] SyntaxDefinitions.MapGrammarParser.TrainContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Train, context.func.Text);
        }

        /// <summary>
        /// レガシー関数の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLegacy([NotNull] SyntaxDefinitions.MapGrammarParser.LegacyContext context)
        {
            return SyntaxNode.CreateSyntaxAstNode(this, context, MapElementName.Legacy, context.func.Text);
        }
        #endregion マップ構文Visitors

        /// <summary>
        /// ストラクチャKeyListVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStrkey([NotNull] SyntaxDefinitions.MapGrammarParser.StrkeyContext context)
        {
            return Visit(context.key);
        }

        #region 数式と変数Visitors

        /// <summary>
        /// 変数宣言Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarAssign([NotNull] SyntaxDefinitions.MapGrammarParser.VarAssignContext context)
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
        public override MapGrammarAstNodes VisitExprArgs([NotNull] SyntaxDefinitions.MapGrammarParser.ExprArgsContext context)
        {
            return Visit(context.nullableExpr());
        }

        /// <summary>
        /// null許容数式Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNullableExpr([NotNull] SyntaxDefinitions.MapGrammarParser.NullableExprContext context)
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
        public override MapGrammarAstNodes VisitParensExpr([NotNull] SyntaxDefinitions.MapGrammarParser.ParensExprContext context)
        {
            return base.Visit(context.expr());
        }

        /// <summary>
        /// ユーナリ演算Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitUnaryExpr([NotNull] SyntaxDefinitions.MapGrammarParser.UnaryExprContext context)
        {
            switch (context.op.Type)
            {
                case MapGrammarLexer.PLUS:
                    return Visit(context.expr());
                case MapGrammarLexer.MINUS:
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
        public override MapGrammarAstNodes VisitInfixExpr([NotNull] SyntaxDefinitions.MapGrammarParser.InfixExprContext context)
        {
            InfixExpressionNode node;

            switch (context.op.Type)
            {
                case MapGrammarLexer.PLUS:
                    node = new AdditionNode(context.Start, context.Stop);
                    break;
                case MapGrammarLexer.MINUS:
                    node = new SubtractionNode(context.Start, context.Stop);
                    break;
                case MapGrammarLexer.MULT:
                    node = new MultiplicationNode(context.Start, context.Stop);
                    break;
                case MapGrammarLexer.DIV:
                    node = new DivisionNode(context.Start, context.Stop);
                    break;
                case MapGrammarLexer.MOD:
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
        public override MapGrammarAstNodes VisitAbsExpr([NotNull] SyntaxDefinitions.MapGrammarParser.AbsExprContext context)
        {
            return new AbsNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数Atan2Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitAtan2Expr([NotNull] SyntaxDefinitions.MapGrammarParser.Atan2ExprContext context)
        {
            return new Atan2Node(context.Start, context.Stop) { Y = Visit(context.y), X = Visit(context.x) };
        }

        /// <summary>
        /// 数学関数CeilVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCeilExpr([NotNull] SyntaxDefinitions.MapGrammarParser.CeilExprContext context)
        {
            return new CeilNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数CosVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCosExpr([NotNull] SyntaxDefinitions.MapGrammarParser.CosExprContext context)
        {
            return new CosNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数ExpVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitExpExpr([NotNull] SyntaxDefinitions.MapGrammarParser.ExpExprContext context)
        {
            return new ExpNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数FloorVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitFloorExpr([NotNull] SyntaxDefinitions.MapGrammarParser.FloorExprContext context)
        {
            return new FloorNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数LogVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitLogExpr([NotNull] SyntaxDefinitions.MapGrammarParser.LogExprContext context)
        {
            return new LogNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数PowVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitPowExpr([NotNull] SyntaxDefinitions.MapGrammarParser.PowExprContext context)
        {
            return new Atan2Node(context.Start, context.Stop) { X = Visit(context.x), Y = Visit(context.y) };
        }

        /// <summary>
        /// 数学関数RandVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitRandExpr([NotNull] SyntaxDefinitions.MapGrammarParser.RandExprContext context)
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
        public override MapGrammarAstNodes VisitSinExpr([NotNull] SyntaxDefinitions.MapGrammarParser.SinExprContext context)
        {
            return new SinNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数SqrtVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitSqrtExpr([NotNull] SyntaxDefinitions.MapGrammarParser.SqrtExprContext context)
        {
            return new SqrtNode(context.Start, context.Stop) { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数字項Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNumberExpr([NotNull] SyntaxDefinitions.MapGrammarParser.NumberExprContext context)
        {
            return new NumberNode(context.Start, context.Stop) { Value = context.num };
        }

        /// <summary>
        /// 距離変数項Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitDistanceExpr([NotNull] SyntaxDefinitions.MapGrammarParser.DistanceExprContext context)
        {
            return new DistanceVariableNode(context.Start, context.Stop);
        }

        /// <summary>
        /// 文字列Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStringExpr([NotNull] SyntaxDefinitions.MapGrammarParser.StringExprContext context)
        {
            return new StringNode(context.Start, context.Stop) { Value = context.str };
        }

        /// <summary>
        /// 変数Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarExpr([NotNull] SyntaxDefinitions.MapGrammarParser.VarExprContext context)
        {
            return new VarNode(context.Start, context.Stop) { Key = context.v.varName };
        }

        #endregion 数式と変数Visitors

        public override MapGrammarAstNodes VisitString([NotNull] SyntaxDefinitions.MapGrammarParser.StringContext context)
        {
            return new StringNode(context.Start, context.Stop) { Value = context };
        }
    }
}
