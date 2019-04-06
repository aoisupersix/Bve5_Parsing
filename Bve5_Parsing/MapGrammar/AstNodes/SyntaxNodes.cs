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
}