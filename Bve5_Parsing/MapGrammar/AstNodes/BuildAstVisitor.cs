using System;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar.AstNodes
{

    /// <summary>
    /// CSTを巡回してASTを作成するVisitorクラス
    /// </summary>
    internal class BuildAstVisitor : MapGrammarParserBaseVisitor<MapGrammarAstNodes>
    {

        /// <summary>
        /// ルートの巡回
        /// ステートメントの集合をノードに追加する
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>ルートASTノード</returns>
        public override MapGrammarAstNodes VisitRoot([NotNull] SyntaxDefinitions.MapGrammarParser.RootContext context)
        {
            var node = new RootNode();
            node.Version = context.version.Text;

            foreach (var state in context.statement())
            {
                MapGrammarAstNodes child = base.Visit(state);
                if(child != null)
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
            catch(NullReferenceException)
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
        #endregion ステートメントVisitors

        #region マップ構文Visitors

        /// <summary>
        /// 距離程の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>距離程ASTノード</returns>
        public override MapGrammarAstNodes VisitDistance([NotNull] SyntaxDefinitions.MapGrammarParser.DistanceContext context)
        {
            DistanceNode node = new DistanceNode { Value = Visit(context.expr()) };
            return node;
        }

        public override MapGrammarAstNodes VisitInclude([NotNull] SyntaxDefinitions.MapGrammarParser.IncludeContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "include";
            node.FunctionName = "";
            node.Arguments.Add("path", new StringNode { Value = context.path.text });

            return node;
        }

        /// <summary>
        /// 平面曲線の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCurve([NotNull] SyntaxDefinitions.MapGrammarParser.CurveContext context)
        {
            Syntax1Node node = new Syntax1Node();

            node.MapElementName = "curve";
            node.FunctionName = context.func.Text.ToLower();
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
                    if (context.radiusE != null)
                        node.Arguments.Add("radius", Visit(context.radiusE));
                    else if (context.radius != null)
                    {
                        node.Arguments.Add("radius", Visit(context.radius));

                        if (context.cant != null)
                            node.Arguments.Add("cant", Visit(context.cant));
                    }
                    else
                    {
                        //引数なし TODO
                    }

                    break;
                case "change":                                                      /* Change(radius) */
                    node.Arguments.Add("radius", Visit(context.radius));
                    break;

            }

            return node;
        }

        /// <summary>
        /// 縦曲線の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitGradient([NotNull] SyntaxDefinitions.MapGrammarParser.GradientContext context)
        {
            Syntax1Node node = new Syntax1Node();   //Gradient構文は全て構文タイプ1
            node.MapElementName = "gradient";
            node.FunctionName = context.func.Text.ToLower();

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
                    if (context.gradientArgsE != null)
                        node.Arguments.Add("gradient", Visit(context.gradientArgsE));
                    else
                    {
                        //引数なし TODO
                    }
                    break;
            }
            return node;
        }

        /// <summary>
        /// 他軌道の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrack([NotNull] SyntaxDefinitions.MapGrammarParser.TrackContext context)
        {
            MapGrammarAstNodes key = Visit(context.key);
            if (context.element != null)                                             /* Syntax3Node */
            {
                Syntax3Node node = new Syntax3Node();
                node.MapElementNames[0] = "track";
                node.MapElementNames[1] = context.element.Text.ToLower();
                node.Key = key;
                node.FunctionName = context.func.Text.ToLower();

                switch (node.FunctionName)
                {
                    case "interpolate":
                        if (node.MapElementNames[1].Equals("cant"))
                        {                                                           /* Cant.Interpolate(cant?) */
                            if (context.cant != null)
                            {
                                node.Arguments.Add("cant", Visit(context.cant));
                            }
                            else
                            {
                                //引数なし TODO
                            }
                        }
                        else
                        {                                                           /* (X | Y).Interpolate(x?, radius?) */
                            if (context.xE != null)
                                node.Arguments.Add(node.MapElementNames[1], Visit(context.xE));
                            else if (context.x != null)
                            {
                                node.Arguments.Add(node.MapElementNames[1], Visit(context.x));

                                if (context.radius != null)
                                    node.Arguments.Add("radius", Visit(context.radius));
                            }
                            else
                            {
                                //引数なし TODO
                            }
                        }

                        break;
                    case "setcenter":                                               /* Cant.SetCenter(x) */
                        node.Arguments.Add("x", Visit(context.x));
                        break;
                    case "setgauge":                                                /* Cant.SetGauge(gauge) */
                        node.Arguments.Add("gauge", Visit(context.gauge));
                        break;
                    case "setfunction":                                             /* Cant.SetFunction(id) */
                        node.Arguments.Add("id", Visit(context.id));
                        break;
                    case "begintransition":                                         /* Cant.BeginTransition() */
                        break;
                    case "begin":                                                   /* Cant.Begin(cant) */
                        node.Arguments.Add("cant", Visit(context.cant));
                        break;
                }

                return node;
            }
            else                                                                    /* Syntax2Node */
            {
                Syntax2Node node = new Syntax2Node();
                node.MapElementName = "track";
                node.Key = key;
                node.FunctionName = context.func.Text.ToLower();

                switch (node.FunctionName)
                {
                    case "position":                                                    /* Position(x, y, radiush?, radiusv?) */
                        node.Arguments.Add("x", Visit(context.x));
                        node.Arguments.Add("y", Visit(context.y));
                        if (context.radiusH != null)
                        {
                            node.Arguments.Add("radiush", Visit(context.radiusH));
                            if (context.radiusV != null)
                                node.Arguments.Add("radiusv", Visit(context.radiusV));
                        }
                        break;
                }

                return node;
            }
        }

        /// <summary>
        /// ストラクチャの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStructure([NotNull] SyntaxDefinitions.MapGrammarParser.StructureContext context)
        {
            string funcName = context.func.Text.ToLower();

            if (funcName.Equals("load"))                                                    /* Load(filePath) */
                return new LoadListNode { MapElementName = "structure", Path = context.path.text };

            Syntax2Node node = new Syntax2Node();
            node.MapElementName = "structure";
            node.Key = Visit(context.key);
            node.FunctionName = context.func.Text.ToLower();

            switch (node.FunctionName)
            {
                case "put":                                                                 /* Put(trackkey,x,y,z,rx,ry,rz,tilt,span) */
                    node.Arguments.Add("trackkey", Visit(context.trackkey));
                    node.Arguments.Add("x", Visit(context.x));
                    node.Arguments.Add("y", Visit(context.y));
                    node.Arguments.Add("z", Visit(context.z));
                    node.Arguments.Add("rx", Visit(context.rx));
                    node.Arguments.Add("ry", Visit(context.ry));
                    node.Arguments.Add("rz", Visit(context.rz));
                    node.Arguments.Add("tilt", Visit(context.tilt));
                    node.Arguments.Add("span", Visit(context.span));
                    break;
                case "put0":                                                                /* Put0(trackkey, tilt, span) */
                    node.Arguments.Add("trackkey", Visit(context.trackkey));
                    node.Arguments.Add("tilt", Visit(context.tilt));
                    node.Arguments.Add("span", Visit(context.span));
                    break;
                case "putbetween":                                                          /* PutBetween(trackkey1, trackkey2, flag?) */
                    node.Arguments.Add("trackkey1", Visit(context.trackkey1));
                    node.Arguments.Add("trackkey2", Visit(context.trackkey2));
                    if (context.flag != null)
                        node.Arguments.Add("flag", Visit(context.flag));
                    break;
            }

            return node;
        }

        /// <summary>
        /// 連続ストラクチャの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRepeater([NotNull] SyntaxDefinitions.MapGrammarParser.RepeaterContext context)
        {
            Syntax2Node node = new Syntax2Node();
            node.MapElementName = "repeater";
            node.Key = Visit(context.key);
            node.FunctionName = context.func.Text.ToLower();

            switch (node.FunctionName)
            {
                case "begin":                                                               /* Begin(trackkey,x,y,z,rx,ry,rz,tilt,span,interval, strkey+) */
                    node.Arguments.Add("trackkey", Visit(context.trackkey));
                    node.Arguments.Add("x", Visit(context.x));
                    node.Arguments.Add("y", Visit(context.y));
                    node.Arguments.Add("z", Visit(context.z));
                    node.Arguments.Add("rx", Visit(context.rx));
                    node.Arguments.Add("ry", Visit(context.ry));
                    node.Arguments.Add("rz", Visit(context.rz));
                    node.Arguments.Add("tilt", Visit(context.tilt));
                    node.Arguments.Add("span", Visit(context.span));
                    node.Arguments.Add("interval", Visit(context.interval));
                    for (int i = 0; i < context.strkey().Length; i++)
                    {
                        node.Arguments.Add("key" + (i + 1), Visit(context.strkey()[i]));
                    }
                    break;
                case "begin0":                                                              /* Begin0(trackkey,tilt,span,interval,strkey+) */
                    node.Arguments.Add("trackkey", Visit(context.trackkey));
                    node.Arguments.Add("tilt", Visit(context.tilt));
                    node.Arguments.Add("span", Visit(context.span));
                    node.Arguments.Add("interval", Visit(context.interval));
                    for (int i = 0; i < context.strkey().Length; i++)
                    {
                        node.Arguments.Add("key" + (i + 1), Visit(context.strkey()[i]));
                    }
                    break;
                case "end":                                                                 /* End() */
                    break;
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
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "background";
            node.FunctionName = context.func.Text;
            node.Arguments.Add("structurekey", Visit(context.structurekey));

            return node;
        }

        /// <summary>
        /// 停車場の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitStation([NotNull] SyntaxDefinitions.MapGrammarParser.StationContext context)
        {
            string funcName = context.func.Text.ToLower();
            if (funcName.Equals("load"))                                                    /* Load(filePath) */
            {
                return new LoadListNode { MapElementName = "station", Path = context.path.text };
            }
            else if (funcName.Equals("put"))                                                /* Put(door, margin1, margin2) */
            {
                Syntax2Node node = new Syntax2Node();
                node.MapElementName = "station";
                node.Key = Visit(context.key);
                node.FunctionName = funcName;
                node.Arguments.Add("door", Visit(context.door));
                node.Arguments.Add("margin1", Visit(context.margin1));
                node.Arguments.Add("margin2", Visit(context.margin2));

                return node;
            }

            return null;
        }

        /// <summary>
        /// 閉そくの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSection([NotNull] SyntaxDefinitions.MapGrammarParser.SectionContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "section";
            node.FunctionName = context.func.Text.ToLower();
            switch (node.FunctionName)
            {
                case "begin":                                                           /* Begin(signalN+) */
                    node.Arguments.Add("signal0", Visit(context.nullableExpr()));
                    for (int i = 0; i < context.exprArgs().Length; i++)
                    {
                        node.Arguments.Add("signal" + (i + 1), Visit(context.exprArgs()[i]));
                    }
                    break;
                case "setspeedlimit":                                                   /* SetSpeedlimit(vN+) */
                    node.Arguments.Add("v0", Visit(context.nullableExpr()));
                    for (int i = 0; i < context.exprArgs().Length; i++)
                    {
                        node.Arguments.Add("v" + (i + 1), Visit(context.exprArgs()[i]));
                    }
                    break;
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
            string funcName = context.func.Text.ToLower();

            if (funcName.Equals("load"))                                                    /* Load(filePath) */
                return new LoadListNode { MapElementName = "structure", Path = context.path.text };

            Syntax2Node node = new Syntax2Node();                                           /* Put(section, trackkey, x, y, z?, rx?, ry?, rz?, tilt?, span?) */
            node.MapElementName = "signal";
            node.Key = Visit(context.key);
            node.FunctionName = funcName;

            node.Arguments.Add("section", Visit(context.sectionArgs));
            node.Arguments.Add("trackkey", Visit(context.trackkey));
            node.Arguments.Add("x", Visit(context.x));
            node.Arguments.Add("y", Visit(context.y));
            if (context.z != null)
            {
                node.Arguments.Add("z", Visit(context.z));
                node.Arguments.Add("rx", Visit(context.rx));
                node.Arguments.Add("ry", Visit(context.ry));
                node.Arguments.Add("rz", Visit(context.rz));
                node.Arguments.Add("tilt", Visit(context.tilt));
                node.Arguments.Add("span", Visit(context.span));
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
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "beacon";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("type", Visit(context.type));
            node.Arguments.Add("section", Visit(context.sectionArgs));
            node.Arguments.Add("senddata", Visit(context.sendData));
            return node;
        }

        /// <summary>
        /// 速度制限の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSpeedlimit([NotNull] SyntaxDefinitions.MapGrammarParser.SpeedlimitContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "speedlimit";
            node.FunctionName = context.func.Text.ToLower();
            if (context.func.Type == MapGrammarLexer.BEGIN)
            {
                node.Arguments.Add("v", Visit(context.v));
            }

            return node;
        }

        /// <summary>
        /// 先行列車の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitPretrain([NotNull] SyntaxDefinitions.MapGrammarParser.PretrainContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "pretrain";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("time", Visit(context.nullableExpr()));

            return node;
        }

        /// <summary>
        /// 光源の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitLight([NotNull] SyntaxDefinitions.MapGrammarParser.LightContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "light";
            node.FunctionName = context.func.Text.ToLower();

            switch (context.func.Type)
            {
                case MapGrammarLexer.AMBIENT:                           /* ambient(red, green, blue) */
                    node.Arguments.Add("red", Visit(context.red));
                    node.Arguments.Add("green", Visit(context.green));
                    node.Arguments.Add("blue", Visit(context.blue));
                    break;
                case MapGrammarLexer.DIFFUSE:                           /* diffuse(red, green, blue) */
                    node.Arguments.Add("red", Visit(context.red));
                    node.Arguments.Add("green", Visit(context.green));
                    node.Arguments.Add("blue", Visit(context.blue));
                    break;
                case MapGrammarLexer.DIRECTION:                         /* direction(pitch, yaw) */
                    node.Arguments.Add("pitch", Visit(context.pitch));
                    node.Arguments.Add("yaw", Visit(context.yaw));
                    break;
            }
            return node;
        }

        /// <summary>
        /// 霧効果の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFog([NotNull] SyntaxDefinitions.MapGrammarParser.FogContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "fog";
            node.FunctionName = context.func.Text.ToLower();
            if (context.red != null)                                         /* Interpolate(density, red, green, blue) */
            {
                node.Arguments.Add("density", Visit(context.density));
                node.Arguments.Add("red", Visit(context.red));
                node.Arguments.Add("green", Visit(context.green));
                node.Arguments.Add("blue", Visit(context.blue));
            }
            else if (context.densityE != null)                               /* Interpolate(density) */
            {
                node.Arguments.Add("density", Visit(context.densityE));
            }

            return node;
        }

        /// <summary>
        /// 風景描画距離の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitDrawdistance([NotNull] SyntaxDefinitions.MapGrammarParser.DrawdistanceContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "drawdistance";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("value", Visit(context.value));

            return node;
        }

        /// <summary>
        /// 運転台の明るさの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitCabilluminance([NotNull] SyntaxDefinitions.MapGrammarParser.CabilluminanceContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "cabilluminance";
            node.FunctionName = context.func.Text.ToLower();
            if (context.value != null)
                node.Arguments.Add("value", Visit(context.value));

            return node;
        }

        /// <summary>
        /// 軌道変位の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitIrregularity([NotNull] SyntaxDefinitions.MapGrammarParser.IrregularityContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "irregularity";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("x", Visit(context.x));
            node.Arguments.Add("y", Visit(context.y));
            node.Arguments.Add("r", Visit(context.r));
            node.Arguments.Add("lx", Visit(context.lx));
            node.Arguments.Add("ly", Visit(context.ly));
            node.Arguments.Add("lr", Visit(context.lr));

            return node;
        }

        /// <summary>
        /// 粘着特性の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitAdhesion([NotNull] SyntaxDefinitions.MapGrammarParser.AdhesionContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "adhesion";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("a", Visit(context.a));
            if (context.b != null)
            {
                node.Arguments.Add("b", Visit(context.b));
                node.Arguments.Add("c", Visit(context.c));
            }

            return node;
        }

        /// <summary>
        /// 音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound([NotNull] SyntaxDefinitions.MapGrammarParser.SoundContext context)
        {
            if (context.path != null)                                /* Load(filePath) */
            {
                return new LoadListNode { MapElementName = "sound", Path = context.path.text };
            }
            else                                                    /* [soundkey].Play() */
            {
                Syntax2Node node = new Syntax2Node();
                node.MapElementName = "sound";
                node.Key = Visit(context.key);
                node.FunctionName = context.func.Text.ToLower();

                return node;
            }
        }

        /// <summary>
        /// 固定音源の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitSound3d([NotNull] SyntaxDefinitions.MapGrammarParser.Sound3dContext context)
        {
            if (context.path != null)                                /* Load(filePath) */
            {
                return new LoadListNode { MapElementName = "sound3d", Path = context.path.text };
            }
            else                                                    /* [soundkey].Put(x,y) */
            {
                Syntax2Node node = new Syntax2Node();
                node.MapElementName = "sound3d";
                node.Key = Visit(context.key);
                node.FunctionName = context.func.Text.ToLower();
                node.Arguments.Add("x", Visit(context.x));
                node.Arguments.Add("y", Visit(context.y));

                return node;
            }
        }

        /// <summary>
        /// 走行音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitRollingnoise([NotNull] SyntaxDefinitions.MapGrammarParser.RollingnoiseContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "rollingnoise";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("index", Visit(context.index));

            return node;
        }

        /// <summary>
        /// フランジきしり音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitFlangenoise([NotNull] SyntaxDefinitions.MapGrammarParser.FlangenoiseContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "flangenoise";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("index", Visit(context.index));

            return node;
        }

        /// <summary>
        /// 分岐器通過音の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitJointnoise([NotNull] SyntaxDefinitions.MapGrammarParser.JointnoiseContext context)
        {
            Syntax1Node node = new Syntax1Node();
            node.MapElementName = "jointnoise";
            node.FunctionName = context.func.Text.ToLower();
            node.Arguments.Add("index", Visit(context.index));

            return node;
        }

        /// <summary>
        /// 他列車の巡回
        /// </summary>
        /// <param name="context"></param>
        /// <returns>構文ASTノード</returns>
        public override MapGrammarAstNodes VisitTrain([NotNull] SyntaxDefinitions.MapGrammarParser.TrainContext context)
        {
            if (context.func.Type == MapGrammarLexer.ADD)                        /* Add(trainkey, filePath, trackkey, direction */
            {
                Syntax1Node node = new Syntax1Node();
                node.MapElementName = "train";
                node.FunctionName = context.func.Text.ToLower();
                node.Arguments.Add("trainkey", Visit(context.trainkey));
                node.Arguments.Add("filepath", Visit(context.path));
                node.Arguments.Add("trackkey", Visit(context.trackkey));
                node.Arguments.Add("direction", Visit(context.direction));

                return node;
            }
            else
            {
                Syntax2Node node = new Syntax2Node();
                node.MapElementName = "train";
                node.Key = Visit(context.key);
                node.FunctionName = context.func.Text.ToLower();

                switch (context.func.Type)
                {
                    case MapGrammarLexer.LOAD:                                  /* Load(filePath, trackkey, direction) */
                        node.Arguments.Add("filepath", Visit(context.path));
                        node.Arguments.Add("trackkey", Visit(context.trackkey));
                        node.Arguments.Add("direction", Visit(context.direction));
                        break;
                    case MapGrammarLexer.ENABLE:                                /* Enable(time) */
                        node.Arguments.Add("time", Visit(context.time));
                        break;
                    case MapGrammarLexer.STOP:                                  /* Stop(decelerate, stopTime, accelerate, speed) */
                        node.Arguments.Add("decelerate", Visit(context.decelerate));
                        node.Arguments.Add("stoptime", Visit(context.stoptime));
                        node.Arguments.Add("accelerate", Visit(context.accelerate));
                        node.Arguments.Add("speed", Visit(context.speed));
                        break;
                }

                return node;
            }
        }
        #endregion マップ構文Visitors

        /// <summary>
        /// ストラクチャKeyListVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStrkey([NotNull] SyntaxDefinitions.MapGrammarParser.StrkeyContext context)
        {
            return new StringNode { Value = context.key.text };
        }

        #region 数式と変数Visitors

        /// <summary>
        /// 変数宣言Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
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
                    return new NegateNode { InnerNode = Visit(context.expr()) };
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
        /// 数学関数AbsVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitAbsExpr([NotNull] SyntaxDefinitions.MapGrammarParser.AbsExprContext context)
        {
            return new AbsNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数Atan2Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitAtan2Expr([NotNull] SyntaxDefinitions.MapGrammarParser.Atan2ExprContext context)
        {
            return new Atan2Node { Y = Visit(context.y), X = Visit(context.x) };
        }

        /// <summary>
        /// 数学関数CeilVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCeilExpr([NotNull] SyntaxDefinitions.MapGrammarParser.CeilExprContext context)
        {
            return new CeilNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数CosVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitCosExpr([NotNull] SyntaxDefinitions.MapGrammarParser.CosExprContext context)
        {
            return new CosNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数ExpVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitExpExpr([NotNull] SyntaxDefinitions.MapGrammarParser.ExpExprContext context)
        {
            return new ExpNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数FloorVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitFloorExpr([NotNull] SyntaxDefinitions.MapGrammarParser.FloorExprContext context)
        {
            return new FloorNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数LogVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitLogExpr([NotNull] SyntaxDefinitions.MapGrammarParser.LogExprContext context)
        {
            return new LogNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数PowVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitPowExpr([NotNull] SyntaxDefinitions.MapGrammarParser.PowExprContext context)
        {
            return new Atan2Node { X = Visit(context.x), Y = Visit(context.y) };
        }

        /// <summary>
        /// 数学関数RandVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitRandExpr([NotNull] SyntaxDefinitions.MapGrammarParser.RandExprContext context)
        {
            RandNode node = new RandNode();
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
            return new SinNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数学関数SqrtVisitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitSqrtExpr([NotNull] SyntaxDefinitions.MapGrammarParser.SqrtExprContext context)
        {
            return new SqrtNode { Value = Visit(context.value) };
        }

        /// <summary>
        /// 数字項Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitNumberExpr([NotNull] SyntaxDefinitions.MapGrammarParser.NumberExprContext context)
        {
            return new NumberNode { Value = double.Parse(context.num.Text, System.Globalization.NumberStyles.AllowDecimalPoint) };
        }

        /// <summary>
        /// 距離変数項Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitDistanceExpr([NotNull] SyntaxDefinitions.MapGrammarParser.DistanceExprContext context)
        {
            return new DistanceVariableNode();
        }

        /// <summary>
        /// 文字列Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitStringExpr([NotNull] SyntaxDefinitions.MapGrammarParser.StringExprContext context)
        {
            return new StringNode { Value = context.str.text };
        }

        /// <summary>
        /// 変数Visitor
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns></returns>
        public override MapGrammarAstNodes VisitVarExpr([NotNull] SyntaxDefinitions.MapGrammarParser.VarExprContext context)
        {
            return new VarNode { Key = context.v.varName };
        }

        #endregion 数式と変数Visitors
    }
}
