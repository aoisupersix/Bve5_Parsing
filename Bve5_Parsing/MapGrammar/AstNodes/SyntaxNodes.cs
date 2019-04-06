/*
 * このファイルは自動生成doc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */
using Antlr4.Runtime;

namespace Bve5_Parsing.MapGrammar.AstNodes {

    /// <summary>
    /// Curve.Setgauge(Value);
    /// </summary>
    public partial class CurveSetgaugeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setgauge";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：軌間 [m]
        /// </summary>
        public MapGrammarAstNodes Value { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveSetgaugeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Curve.Setcenter(X);
    /// </summary>
    public partial class CurveSetcenterNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setcenter";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：回転中心の x 座標 [m] (正: 曲線の内側, 負: 曲線の外側)
        /// </summary>
        public MapGrammarAstNodes X { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveSetcenterNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Curve.Setfunction(Id);
    /// </summary>
    public partial class CurveSetfunctionNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setfunction";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：関数番号 (0: サイン半波長逓減, 1: 直線逓減)
        /// </summary>
        public MapGrammarAstNodes Id { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveSetfunctionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Curve.Begin(Radius, Cant?);
    /// </summary>
    public partial class CurveBeginNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線)
        /// </summary>
        public MapGrammarAstNodes Radius { get; set; }

        /// <summary>
        /// 引数：カント [m]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveBeginNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Curve.End();
    /// </summary>
    public partial class CurveEndNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "End";
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveEndNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Curve.Interpolate(Radius?, Cant?);
    /// </summary>
    public partial class CurveInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Interpolate";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線, 0: 直線)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Radius { get; set; }

        /// <summary>
        /// 引数：カント [m]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Curve.Change(Radius);
    /// </summary>
    public partial class CurveChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線, 0: 直線)
        /// </summary>
        public MapGrammarAstNodes Radius { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CurveChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Gradient.Begintransition();
    /// </summary>
    public partial class GradientBegintransitionNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Gradient";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begintransition";
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public GradientBegintransitionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Gradient.Begin(Gradient);
    /// </summary>
    public partial class GradientBeginNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Gradient";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：勾配 [‰]
        /// </summary>
        public MapGrammarAstNodes Gradient { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public GradientBeginNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Gradient.End();
    /// </summary>
    public partial class GradientEndNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Gradient";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "End";
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public GradientEndNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Gradient.Interpolate(Gradient?);
    /// </summary>
    public partial class GradientInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Gradient";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Interpolate";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：勾配 [‰]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Gradient { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public GradientInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].X.Interpolate(X?, Radius?);
    /// </summary>
    public partial class TrackXInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "X_Interpolate";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：自軌道からの x 座標 [m]（省略可能）
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との平面曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Radius { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackXInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Y.Interpolate(Y?, Radius?);
    /// </summary>
    public partial class TrackYInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Y_Interpolate";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：自軌道からの y 座標 [m]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との縦曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Radius { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackYInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Position(X, Y, RadiusH?, RadiusV?);
    /// </summary>
    public partial class TrackPositionNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Position";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：自軌道からの x 座標 [m]
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：自軌道からの y 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との平面曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public MapGrammarAstNodes RadiusH { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との縦曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public MapGrammarAstNodes RadiusV { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackPositionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Setgauge(Gauge);
    /// </summary>
    public partial class TrackCantSetgaugeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_Setgauge";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：軌間 [m]
        /// </summary>
        public MapGrammarAstNodes Gauge { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantSetgaugeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Setcenter(X);
    /// </summary>
    public partial class TrackCantSetcenterNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_Setcenter";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：回転中心の x 座標 [m] (正: 曲線の内側, 負: 曲線の外側)
        /// </summary>
        public MapGrammarAstNodes X { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantSetcenterNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Setfunction(Id);
    /// </summary>
    public partial class TrackCantSetfunctionNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_Setfunction";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：関数番号 (0: サイン半波長逓減, 1: 直線逓減)
        /// </summary>
        public MapGrammarAstNodes Id { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantSetfunctionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Begintransition();
    /// </summary>
    public partial class TrackCantBegintransitionNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_Begintransition";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantBegintransitionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Begin(Cant);
    /// </summary>
    public partial class TrackCantBeginNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_Begin";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：カント [m] (正: 右に傾ける, 負: 左に傾ける)
        /// </summary>
        public MapGrammarAstNodes Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantBeginNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.End();
    /// </summary>
    public partial class TrackCantEndNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_End";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantEndNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Interpolate(Cant?);
    /// </summary>
    public partial class TrackCantInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Track";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Cant_Interpolate";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：カント [m] (正: 右に傾ける, 負: 左に傾ける)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Structure.Load(FilePath);
    /// </summary>
    public partial class StructureLoadNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Structure";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Load";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルからストラクチャーリストファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public StructureLoadNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
    /// </summary>
    public partial class StructurePutNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Structure";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Put";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StructureKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }

        /// <summary>
        /// 引数：軌道からの z 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Z { get; set; }

        /// <summary>
        /// 引数：軌道に対する x 軸回りの角 [deg]
        /// </summary>
        public MapGrammarAstNodes RX { get; set; }

        /// <summary>
        /// 引数：軌道に対する y 軸回りの角 [deg]
        /// </summary>
        public MapGrammarAstNodes RY { get; set; }

        /// <summary>
        /// 引数：軌道に対する z 軸回りの角 [deg]
        /// </summary>
        public MapGrammarAstNodes RZ { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        public MapGrammarAstNodes Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        public MapGrammarAstNodes Span { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public StructurePutNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Structure[StructureKey].Put0(TrackKey, Tilt, Span);
    /// </summary>
    public partial class StructurePut0Node : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Structure";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Put0";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StructureKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        public MapGrammarAstNodes Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        public MapGrammarAstNodes Span { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public StructurePut0Node(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag?);
    /// </summary>
    public partial class StructurePutbetweenNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Structure";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Putbetween";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StructureKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：一方の軌道の軌道名 (0: 自軌道)
        /// </summary>
        public MapGrammarAstNodes TrackKey1 { get; set; }

        /// <summary>
        /// 引数：他方の軌道の軌道名
        /// </summary>
        public MapGrammarAstNodes TrackKey2 { get; set; }

        /// <summary>
        /// 引数：変形方向 (0: x および y 方向に変形, 1: x 方向のみに変形)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Flag { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public StructurePutbetweenNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
    /// </summary>
    public partial class RepeaterBeginNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Repeater";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：RepeaterKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }

        /// <summary>
        /// 引数：軌道からの z 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Z { get; set; }

        /// <summary>
        /// 引数：軌道に対する x 軸回りの角 [deg]
        /// </summary>
        public MapGrammarAstNodes RX { get; set; }

        /// <summary>
        /// 引数：軌道に対する y 軸回りの角 [deg]
        /// </summary>
        public MapGrammarAstNodes RY { get; set; }

        /// <summary>
        /// 引数：軌道に対する z 軸回りの角 [deg]
        /// </summary>
        public MapGrammarAstNodes RZ { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        public MapGrammarAstNodes Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        public MapGrammarAstNodes Span { get; set; }

        /// <summary>
        /// 引数：配置間隔 [m]
        /// </summary>
        public MapGrammarAstNodes Interval { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public RepeaterBeginNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval);
    /// </summary>
    public partial class RepeaterBegin0Node : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Repeater";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin0";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：RepeaterKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        public MapGrammarAstNodes Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        public MapGrammarAstNodes Span { get; set; }

        /// <summary>
        /// 引数：配置間隔 [m]
        /// </summary>
        public MapGrammarAstNodes Interval { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public RepeaterBegin0Node(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Repeater[RepeaterKey].End();
    /// </summary>
    public partial class RepeaterEndNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Repeater";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "End";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：RepeaterKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public RepeaterEndNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Background.Change(StructureKey);
    /// </summary>
    public partial class BackgroundChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Background";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：ストラクチャー名
        /// </summary>
        public MapGrammarAstNodes StructureKey { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public BackgroundChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Station.Load(FilePath);
    /// </summary>
    public partial class StationLoadNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Station";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Load";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルから停車場リストファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public StationLoadNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Station[StationKey].Put(Door, Margin1, Margin2);
    /// </summary>
    public partial class StationPutNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Station";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Put";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StationKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：開くドアの方向 (-1: 左, 1: 右)
        /// </summary>
        public MapGrammarAstNodes Door { get; set; }

        /// <summary>
        /// 引数：停止位置誤差の後方許容範囲 (負の値で設定)
        /// </summary>
        public MapGrammarAstNodes Margin1 { get; set; }

        /// <summary>
        /// 引数：停止位置誤差の後方許容範囲
        /// </summary>
        public MapGrammarAstNodes Margin2 { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public StationPutNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Section.Begin();
    /// </summary>
    public partial class SectionBeginNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Section";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin";
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SectionBeginNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Section.Setspeedlimit();
    /// </summary>
    public partial class SectionSetspeedlimitNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Section";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setspeedlimit";
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SectionSetspeedlimitNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Signal.Load(FilePath);
    /// </summary>
    public partial class SignalLoadNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Signal";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Load";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルから信号現示リストファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SignalLoadNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z?, RX?, RY?, RZ?, Tilt?, Span?);
    /// </summary>
    public partial class SignalPutNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Signal";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Put";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：SignalAspectKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：関連づける閉そくの相対インデックス
        /// </summary>
        public MapGrammarAstNodes Section { get; set; }

        /// <summary>
        /// 引数：配置先の軌道名
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }

        /// <summary>
        /// 引数：軌道からの z 座標 [m]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Z { get; set; }

        /// <summary>
        /// 引数：軌道に対する x 軸回りの角 [deg]（省略可能）
        /// </summary>
        public MapGrammarAstNodes RX { get; set; }

        /// <summary>
        /// 引数：軌道に対する y 軸回りの角 [deg]（省略可能）
        /// </summary>
        public MapGrammarAstNodes RY { get; set; }

        /// <summary>
        /// 引数：軌道に対する z 軸回りの角 [deg]（省略可能）
        /// </summary>
        public MapGrammarAstNodes RZ { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Span { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SignalPutNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Beacon.Put(Type, Section, SendData);
    /// </summary>
    public partial class BeaconPutNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Beacon";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Put";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：保安装置に送る地上子種別 (整数)
        /// </summary>
        public MapGrammarAstNodes Type { get; set; }

        /// <summary>
        /// 引数：関連づける閉そくの相対インデックス
        /// </summary>
        public MapGrammarAstNodes Section { get; set; }

        /// <summary>
        /// 引数：保安装置に送る値 (整数)
        /// </summary>
        public MapGrammarAstNodes SendData { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public BeaconPutNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Speedlimit.Begin(V);
    /// </summary>
    public partial class SpeedlimitBeginNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Speedlimit";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：走行速度 [km/h]
        /// </summary>
        public MapGrammarAstNodes V { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SpeedlimitBeginNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Speedlimit.End();
    /// </summary>
    public partial class SpeedlimitEndNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Speedlimit";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "End";
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SpeedlimitEndNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Pretrain.Pass(Time?, Second?);
    /// </summary>
    public partial class PretrainPassNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Pretrain";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Pass";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：時刻を表す文字列 ('hh:mm:ss')（省略可能）
        /// </summary>
        public MapGrammarAstNodes Time { get; set; }

        /// <summary>
        /// 引数：00:00:00 からの経過時間 [sec]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Second { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public PretrainPassNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Light.Ambient(Red, Green, Blue);
    /// </summary>
    public partial class LightAmbientNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Light";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Ambient";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)
        /// </summary>
        public MapGrammarAstNodes Red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)
        /// </summary>
        public MapGrammarAstNodes Green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)
        /// </summary>
        public MapGrammarAstNodes Blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public LightAmbientNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Light.Diffuse(Red, Green, Blue);
    /// </summary>
    public partial class LightDiffuseNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Light";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Diffuse";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)
        /// </summary>
        public MapGrammarAstNodes Red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)
        /// </summary>
        public MapGrammarAstNodes Green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)
        /// </summary>
        public MapGrammarAstNodes Blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public LightDiffuseNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Fog.Interpolate(Density?, Red?, Green?, Blue?);
    /// </summary>
    public partial class FogInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Fog";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Interpolate";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：濃度（省略可能）
        /// </summary>
        public MapGrammarAstNodes Density { get; set; }

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public FogInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Drawdistance.Change(Value?);
    /// </summary>
    public partial class DrawdistanceChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Drawdistance";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：距離 [m] (0: [設定] ウィンドウで設定される描画距離を適用)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Value { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public DrawdistanceChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Cabilluminance.Interpolate(Value?);
    /// </summary>
    public partial class CabilluminanceInterpolateNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Cabilluminance";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Interpolate";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：昼間画像と夜間画像の混合比 (0: 夜間画像 ~ 1: 昼間画像)（省略可能）
        /// </summary>
        public MapGrammarAstNodes Value { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public CabilluminanceInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Irregularity.Change(X, Y, R, LX, LY, LR);
    /// </summary>
    public partial class IrregularityChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Irregularity";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：左右変位 (左と右のレールの通り変位の平均に相当) の標準偏差 [m]
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：上下変位 (左と右のレールの高低変位の平均に相当) の標準偏差 [m]
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }

        /// <summary>
        /// 引数：ロール変位 (水準変位を軌間で除した値に相当) の標準偏差 [rad]
        /// </summary>
        public MapGrammarAstNodes R { get; set; }

        /// <summary>
        /// 引数：左右変位の遮断波長 [m]
        /// </summary>
        public MapGrammarAstNodes LX { get; set; }

        /// <summary>
        /// 引数：上下変位の遮断波長 [m]
        /// </summary>
        public MapGrammarAstNodes LY { get; set; }

        /// <summary>
        /// 引数：ロール変位の遮断波長 [m]
        /// </summary>
        public MapGrammarAstNodes LR { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public IrregularityChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Adhision.Change(A, B?, C?);
    /// </summary>
    public partial class AdhisionChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Adhision";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：走行速度 0 km/h における粘着係数
        /// </summary>
        public MapGrammarAstNodes A { get; set; }

        /// <summary>
        /// 引数：粘着係数の走行速度に対する変化を表す係数（省略可能）
        /// </summary>
        public MapGrammarAstNodes B { get; set; }

        /// <summary>
        /// 引数：粘着係数の走行速度に対する変化を表す係数（省略可能）
        /// </summary>
        public MapGrammarAstNodes C { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public AdhisionChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Sound.Load(FilePath);
    /// </summary>
    public partial class SoundLoadNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Sound";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Load";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルからサウンドリストファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SoundLoadNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Sound[SoundKey].Play();
    /// </summary>
    public partial class SoundPlayNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Sound";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Play";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：SoundKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public SoundPlayNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Sound3d.Load(FilePath);
    /// </summary>
    public partial class Sound3dLoadNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Sound3d";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Load";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルからサウンドリストファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public Sound3dLoadNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Sound3d[SoundKey].Put(X, Y);
    /// </summary>
    public partial class Sound3dPutNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Sound3d";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Put";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：SoundKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        public MapGrammarAstNodes X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        public MapGrammarAstNodes Y { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public Sound3dPutNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Rollingnoise.Change(Index);
    /// </summary>
    public partial class RollingnoiseChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Rollingnoise";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：車両サウンドファイルの [Run] セクションで定義したインデックス
        /// </summary>
        public MapGrammarAstNodes Index { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public RollingnoiseChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Flangenoise.Change(Index);
    /// </summary>
    public partial class FlangenoiseChangeNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Flangenoise";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：車両サウンドファイルの [Flange] セクションで定義したインデックス
        /// </summary>
        public MapGrammarAstNodes Index { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public FlangenoiseChangeNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Jointnoise.Play(Index);
    /// </summary>
    public partial class JointnoisePlayNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Jointnoise";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Play";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：車両サウンドファイルの [Joint] セクションで定義したインデックス
        /// </summary>
        public MapGrammarAstNodes Index { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public JointnoisePlayNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Train.Add(TrainKey, FilePath, TrackKey, Direction);
    /// </summary>
    public partial class TrainAddNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Train";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Add";
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：他列車名 (任意の文字列)
        /// </summary>
        public MapGrammarAstNodes TrainKey { get; set; }

        /// <summary>
        /// 引数：このファイルから他列車ファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }

        /// <summary>
        /// 引数：走行する軌道
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：進行方向 (-1: 対向, 1: 並走)
        /// </summary>
        public MapGrammarAstNodes Direction { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrainAddNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Train[TrainKey].Load(FilePath, TrackKey, Direction);
    /// </summary>
    public partial class TrainLoadNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Train";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Load";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：このファイルから他列車ファイルへの相対パス
        /// </summary>
        public MapGrammarAstNodes FilePath { get; set; }

        /// <summary>
        /// 引数：走行する軌道
        /// </summary>
        public MapGrammarAstNodes TrackKey { get; set; }

        /// <summary>
        /// 引数：進行方向 (-1: 対向, 1: 並走)
        /// </summary>
        public MapGrammarAstNodes Direction { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrainLoadNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Train[TrainKey].Enable(Time?, Second?);
    /// </summary>
    public partial class TrainEnableNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Train";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Enable";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：時刻を表す文字列 ('hh:mm:ss')（省略可能）
        /// </summary>
        public MapGrammarAstNodes Time { get; set; }

        /// <summary>
        /// 引数：00:00:00 からの経過時間 [sec]（省略可能）
        /// </summary>
        public MapGrammarAstNodes Second { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrainEnableNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
    /// </summary>
    public partial class TrainStopNode : SyntaxNode
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Train";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Stop";
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public MapGrammarAstNodes Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：減速度 [km/h/s]
        /// </summary>
        public MapGrammarAstNodes Decelerate { get; set; }

        /// <summary>
        /// 引数：停車時間 [s]
        /// </summary>
        public MapGrammarAstNodes StopTime { get; set; }

        /// <summary>
        /// 引数：加速度 [km/h/s]
        /// </summary>
        public MapGrammarAstNodes Accelerate { get; set; }

        /// <summary>
        /// 引数：加速後の走行速度 [km/h]
        /// </summary>
        public MapGrammarAstNodes Speed { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrainStopNode(IToken start, IToken stop) : base(start, stop) { }
    }
}