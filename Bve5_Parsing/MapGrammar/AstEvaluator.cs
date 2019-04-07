using Bve5_Parsing.MapGrammar.AstNodes;
using Hnx8.ReadJEnc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bve5_Parsing.MapGrammar
{

    /// <summary>
    /// ASTノードの評価手続きクラス
    /// </summary>
    public class EvaluateMapGrammarVisitor : AstVisitor<object>
    {
        /// <summary>
        /// 変数管理
        /// </summary>
        protected VariableStore Store;

        /// <summary>
        /// エラー保持
        /// </summary>
        protected ICollection<ParseError> Errors;

        /// <summary>
        /// 評価結果
        /// </summary>
        protected MapData evaluateData;

        /// <summary>
        /// 現在評価中の距離程
        /// </summary>
        public double NowDistance { get; protected set; } = 0;

        public EvaluateMapGrammarVisitor(VariableStore store, ICollection<ParseError> errors)
        {
            Store = store;
            Errors = errors;
        }

        public EvaluateMapGrammarVisitor(VariableStore store, ICollection<ParseError> errors, double nowDistance)
        {
            Store = store;
            Errors = errors;
            NowDistance = nowDistance;
        }

        /// <summary>
        /// ルートノードの評価
        /// </summary>
        /// <param name="node">ルートノード</param>
        /// <returns>解析結果のMapData</returns>
        public override object Visit(RootNode node)
        {
            evaluateData = new MapData();

            if (node.Version == null)
            {

            }
            else
            {
                evaluateData.Version = node.Version.Text;
                if (node.Version.Text != "2.02")
                    Errors.Add(node.CreateNewWarning($"バージョン：\"{node.Version.Text}\"はBve5_Parsingではサポートしていないバージョンです。"));
            }

            if (node.Encoding != null)
                evaluateData.Encoding = node.Encoding.text;

            foreach(var state in node.StatementList)
            {
                object childData = Visit(state);
                if(childData != null)
                    evaluateData.AddStatement((SyntaxData)childData);
            }

            return evaluateData;
        }

        /// <summary>
        /// 距離程の評価
        /// </summary>
        /// <param name="node">距離程ノード</param>
        /// <returns>null</returns>
        public override object Visit(DistanceNode node)
        {
            NowDistance = Convert.ToDouble(Visit(node.Value));

            return null;
        }

        #region 構文ノードの評価

        /// <summary>
        /// 構文タイプ1の評価
        /// </summary>
        /// <param name="node">Syntax1Node</param>
        /// <returns>解析結果のSyntaxDataクラス</returns>
        public override object Visit(Syntax1Node node)
        {
            SyntaxData returnData = new SyntaxData();
            //構文情報を登録する
            returnData.Distance = NowDistance;
            returnData.MapElement = new string[1];
            returnData.MapElement[0] = node.MapElementName;
            returnData.Function = node.FunctionName;
            foreach (string key in node.Arguments.Keys)
            {
                if (node.Arguments[key] != null)
                    returnData.SetArg(key, Visit(node.Arguments[key]));
                else
                    returnData.SetArg(key, null);
            }

            return returnData;
        }

        /// <summary>
        /// 構文タイプ2の評価
        /// </summary>
        /// <param name="node">Syntax2Node</param>
        /// <returns>解析結果のSyntaxDataクラス</returns>
        public override object Visit(Syntax2Node node)
        {
            SyntaxData returnData = new SyntaxData();
            //構文情報を登録する
            returnData.Distance = NowDistance;
            returnData.MapElement = new string[1];
            returnData.MapElement[0] = node.MapElementName;
            returnData.Key = Visit(node.Key).ToString();
            returnData.Function = node.FunctionName;
            foreach (string key in node.Arguments.Keys)
            {
                if (node.Arguments[key] != null)
                    returnData.SetArg(key, Visit(node.Arguments[key]));
                else
                    returnData.SetArg(key, null);
            }

            return returnData;
        }

        /// <summary>
        /// 構文タイプ3の評価
        /// </summary>
        /// <param name="node">Syntax3Node</param>
        /// <returns>解析結果のSyntaxDataクラス</returns>
        public override object Visit(Syntax3Node node)
        {
            SyntaxData returnData = new SyntaxData();
            //構文情報を登録する
            returnData.Distance = NowDistance;
            returnData.MapElement = node.MapElementNames;
            returnData.Key = Visit(node.Key).ToString();
            returnData.Function = node.FunctionName;
            foreach (string key in node.Arguments.Keys)
            {
                if (node.Arguments[key] != null)
                    returnData.SetArg(key, Visit(node.Arguments[key]));
                else
                    returnData.SetArg(key, null);
            }

            return returnData;
        }

        public override object Visit(CurveSetgaugeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveSetcenterNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveSetfunctionNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveBegintransitionNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveBeginNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveEndNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CurveChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(GradientBegintransitionNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(GradientBeginNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(GradientEndNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(GradientInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackXInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackYInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackPositionNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantSetgaugeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantSetcenterNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantSetfunctionNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantBegintransitionNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantBeginNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantEndNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrackCantInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(StructureLoadNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(StructurePutNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(StructurePut0Node node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(StructurePutbetweenNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(RepeaterBeginNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(RepeaterBegin0Node node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(RepeaterEndNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(BackgroundChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(StationLoadNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(StationPutNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SectionBeginNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SectionSetspeedlimitNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SignalLoadNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SignalPutNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(BeaconPutNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SpeedlimitBeginNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SpeedlimitEndNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(PretrainPassNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(LightAmbientNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(LightDiffuseNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(FogInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(DrawdistanceChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(CabilluminanceInterpolateNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(IrregularityChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(AdhisionChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SoundLoadNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(SoundPlayNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(Sound3dLoadNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(Sound3dPutNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(RollingnoiseChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(FlangenoiseChangeNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(JointnoisePlayNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrainAddNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrainLoadNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrainEnableNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        public override object Visit(TrainStopNode node)
        {
            return node.CreateSyntaxData(this, NowDistance);
        }

        /// <summary>
        /// リストファイルノードの評価
        /// リストファイルの参照パスを追加する
        /// </summary>
        /// <param name="node">リストファイルノード</param>
        /// <returns>null</returns>
        public override object Visit(LoadListNode node)
        {
            if (node.Path == null)
                Errors.Add(node.CreateNewError("ファイルパスが指定されていません。"));
            else
                evaluateData.SetListPathToString(node.MapElementName, node.Path.text);

            return null;
        }

        #endregion

        /// <summary>
        /// 変数宣言ノードの評価
        /// </summary>
        /// <param name="node">変数宣言ノード</param>
        /// <returns>null</returns>
        public override object Visit(VarAssignNode node)
        {
            var val = Visit(node.Value);
            Store.SetVar(node.VarName, val);
            return null;
        }

        #region 数式ノードの評価

        /// <summary>
        /// 加算ノードの評価
        /// </summary>
        /// <param name="node">加算ノード</param>
        /// <returns>演算後の数値(Double)、もしくは文字列(String)</returns>
        public override object Visit(AdditionNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            if (left.GetType() == typeof(string) || right.GetType() == typeof(string))
                return left.ToString() + right.ToString(); //文字列の結合

            return Convert.ToDouble(left) + Convert.ToDouble(right);

        }

        /// <summary>
        /// 減算ノードの評価
        /// </summary>
        /// <param name="node">減算ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(SubtractionNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            if (left == null || right == null)
                return null;
            if (left.GetType() == typeof(string) || right.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'{left.ToString()} - {right.ToString()}'は有効な式ではありません。"));
                return null;
            }

            return Convert.ToDouble(left) - Convert.ToDouble(right);
        }

        /// <summary>
        /// 乗算ノードの評価
        /// </summary>
        /// <param name="node">乗算ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(MultiplicationNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            if (left == null || right == null)
                return null;
            if (left.GetType() == typeof(string) || right.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'{left.ToString()} * {right.ToString()}'は有効な式ではありません。"));
                return null;
            }

            return Convert.ToDouble(left) * Convert.ToDouble(right);
        }

        /// <summary>
        /// 除算ノードの評価
        /// </summary>
        /// <param name="node">除算ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(DivisionNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            if (left == null || right == null)
                return null;
            if (left.GetType() == typeof(string) || right.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'{left.ToString()} / {right.ToString()}'は有効な式ではありません。"));
                return null;
            }

            //TODO: 0除算対策
            return Convert.ToDouble(left) / Convert.ToDouble(right);
        }

        /// <summary>
        /// ユーナリ演算ノードの評価
        /// </summary>
        /// <param name="node">ユーナリ演算ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(UnaryNode node)
        {
            var inner = Visit(node.InnerNode);
            if (inner == null)
                return null;
            if (inner.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'- {inner.ToString()}'は有効な式ではありません。"));
                return null;
            }
            return -Convert.ToDouble(Visit(node.InnerNode));
        }

        /// <summary>
        /// 剰余算ノードの評価
        /// </summary>
        /// <param name="node">剰余算ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(ModuloNode node)
        {
            var left = Visit(node.Left);
            var right = Visit(node.Right);
            if (left == null || right == null)
                return null;
            if (left.GetType() == typeof(string) || right.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'{left.ToString()} % {right.ToString()}'は有効な式ではありません。"));
                return null;
            }

            return Convert.ToDouble(left) % Convert.ToDouble(right);
        }

        /// <summary>
        /// 絶対値関数の評価
        /// </summary>
        /// <param name="node">絶対値関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(AbsNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'abs({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Abs(Convert.ToDouble(value));
        }

        /// <summary>
        /// Atan2関数の評価
        /// </summary>
        /// <param name="node">Atan2ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(Atan2Node node)
        {
            var y = Visit(node.Y);
            var x = Visit(node.X);
            if (y == null || x == null)
                return null;
            if (y.GetType() == typeof(string) || x.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'atan2({y.ToString()}, {x.ToString()})'は有効な式ではありません。"));
                return null;
            }

            return Math.Atan2(Convert.ToDouble(y), Convert.ToDouble(x));
        }

        /// <summary>
        /// 切り上げ関数の評価
        /// </summary>
        /// <param name="node">切り上げ関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(CeilNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'ceil({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Ceiling(Convert.ToDouble(value));
        }

        /// <summary>
        /// 余弦関数の評価
        /// </summary>
        /// <param name="node">余弦関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(CosNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'cos({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Cos(Convert.ToDouble(value));
        }

        /// <summary>
        /// 累乗関数の評価
        /// </summary>
        /// <param name="node">累乗関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(ExpNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'exp({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Exp(Convert.ToDouble(value));
        }

        /// <summary>
        /// 切り捨て関数の評価
        /// </summary>
        /// <param name="node">切り捨て関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(FloorNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'floor({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Floor(Convert.ToDouble(value));
        }

        /// <summary>
        /// 自然対数関数の評価
        /// </summary>
        /// <param name="node">自然対数関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(LogNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'log({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Log(Convert.ToDouble(value));
        }

        /// <summary>
        /// べき乗関数の評価
        /// </summary>
        /// <param name="node">べき乗関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(PowNode node)
        {
            var x = Visit(node.X);
            var y = Visit(node.Y);
            if (x == null || y == null)
                return null;
            if (x.GetType() == typeof(string) || y.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'pow({x.ToString()}, {y.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Pow(Convert.ToDouble(x), Convert.ToDouble(y));
        }

        /// <summary>
        /// 乱数関数の評価
        /// </summary>
        /// <param name="node">乱数関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(RandNode node)
        {
            Random random = new Random();

            var value = Visit(node.Value);
            if (value == null)
                return random.NextDouble();
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'rand({value.ToString()})'は有効な式ではありません。"));
                return null;
            }

            return random.Next(Convert.ToInt32(value));
        }

        /// <summary>
        /// 正弦関数の評価
        /// </summary>
        /// <param name="node">正弦関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(SinNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'sin({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Sin(Convert.ToDouble(value));
        }

        /// <summary>
        /// 平方根関数の評価
        /// </summary>
        /// <param name="node">平方根関数ノード</param>
        /// <returns>演算後の数値(Double)</returns>
        public override object Visit(SqrtNode node)
        {
            var value = Visit(node.Value);
            if (value == null)
                return null;
            if (value.GetType() == typeof(string))
            {
                Errors.Add(node.CreateNewError($"'sqrt({value.ToString()})'は有効な式ではありません。"));
                return null;
            }
            return Math.Sqrt(Convert.ToDouble(value));
        }

        /// <summary>
        /// 数値の評価
        /// </summary>
        /// <param name="node">数値ノード</param>
        /// <returns>数値(String)</returns>
        public override object Visit(NumberNode node)
        {
            return double.Parse(node.Value.Text, System.Globalization.NumberStyles.AllowDecimalPoint);
        }

        /// <summary>
        /// Distance変数の評価
        /// 現在の距離程を返します。
        /// </summary>
        /// <param name="node">距離程変数ノード</param>
        /// <returns>現在の距離程(Double)</returns>
        public override object Visit(DistanceVariableNode node)
        {
            return NowDistance;
        }

        /// <summary>
        /// 文字列の評価
        /// </summary>
        /// <param name="node">文字列ノード</param>
        /// <returns>文字列(String)</returns>
        public override object Visit(StringNode node)
        {
            return node.Value.text;
        }

        /// <summary>
        /// 変数の評価
        /// </summary>
        /// <param name="node">変数ノード</param>
        /// <returns>変数に対応する値(Double)</returns>
        public override object Visit(VarNode node)
        {
            return Store.GetVar(node.Key);
        }

        #endregion 数式ノードの評価
    }

    /// <summary>
    /// ASTノードの評価手続きクラス(Include構文対応)
    /// </summary>
    public class EvaluateMapGrammarVisitorWithInclude : EvaluateMapGrammarVisitor
    {

        private readonly string dirAbsolutePath;

        /// <summary>
        /// Include先ファイルの絶対パスを取得します。
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetIncludeAbsolutePath(string path)
        {
            if (string.IsNullOrEmpty(path))
                return path;

            var fileRelativePath = path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
            return Path.GetFullPath(Path.Combine(dirAbsolutePath, fileRelativePath));
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="dirAbsolutePath"></param>
        /// <param name="errors"></param>
        public EvaluateMapGrammarVisitorWithInclude(VariableStore store, string dirAbsolutePath, ICollection<ParseError> errors): base(store, errors)
        {
            this.dirAbsolutePath = dirAbsolutePath;
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="store"></param>
        /// <param name="dirAbsolutePath"></param>
        /// <param name="errors"></param>
        /// <param name="nowDistance"></param>
        public EvaluateMapGrammarVisitorWithInclude(VariableStore store, string dirAbsolutePath, ICollection<ParseError> errors, double nowDistance): base(store, errors, nowDistance)
        {
            this.dirAbsolutePath = dirAbsolutePath;
        }

        public override object Visit(Syntax1Node node)
        {
            var returnData = (SyntaxData)base.Visit(node);
            
            // Include対応
            if (returnData.MapElement[0] == "include")
            {
                var path = GetIncludeAbsolutePath(returnData.Arguments["path"].ToString());
                if (!File.Exists(path))
                {
                    Errors.Add(node.CreateNewError($"指定されたファイル「{path}」は存在しません。"));
                    return returnData;
                }
                var file = new FileInfo(path);
                using (var reader = new FileReader(file))
                {
                    reader.Read(file);
                    var includeText = reader.Text;
                    if (includeText == null)
                    {
                        Errors.Add(node.CreateNewError($"「{path}」の読み込みに失敗しました。"));
                        return returnData;
                    }

                    // Include先構文を評価して追加
                    var parser = new MapGrammarParser();
                    var includeAst = parser.ParseToAst(includeText);
                    Errors.ToList().AddRange(parser.ParserErrors);
                    var evaluator = new EvaluateMapGrammarVisitorWithInclude(Store, dirAbsolutePath, Errors, NowDistance);
                    var includeData = (MapData)evaluator.Visit(includeAst);

                    evaluateData.AddStatements(includeData.Statements);
                    evaluateData.OverwriteListPath(includeData);
                    NowDistance = evaluator.NowDistance;
                }
            }

            return returnData;
        }
    }
}
