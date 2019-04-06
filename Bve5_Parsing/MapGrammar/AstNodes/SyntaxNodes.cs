/*
 * このファイルは自動生成doc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */
using Antlr4.Runtime;

namespace Bve5_Parsing.MapGrammar.AstNodes {

    /// <summary>
    /// Curve.Setgauge(Value);
    /// </summary>
    public class CurveSetgaugeNode : SyntaxNode
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
        public object Value { get; set; }
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
    public class CurveSetcenterNode : SyntaxNode
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
        public object X { get; set; }
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
    public class CurveSetfunctionNode : SyntaxNode
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
        public object Id { get; set; }
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
    public class CurveBeginNode : SyntaxNode
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
        public object Radius { get; set; }

        /// <summary>
        /// 引数：カント [m]（省略可能）
        /// </summary>
        public object Cant { get; set; }
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
    public class CurveEndNode : SyntaxNode
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
    public class CurveInterpolateNode : SyntaxNode
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
        public object Radius { get; set; }

        /// <summary>
        /// 引数：カント [m]（省略可能）
        /// </summary>
        public object Cant { get; set; }
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
    public class CurveChangeNode : SyntaxNode
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
        public object Radius { get; set; }
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
    public class GradientBegintransitionNode : SyntaxNode
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
    public class GradientBeginNode : SyntaxNode
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
        public object Gradient { get; set; }
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
    public class GradientEndNode : SyntaxNode
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
    public class GradientInterpolateNode : SyntaxNode
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
        public object Gradient { get; set; }
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
    public class TrackXInterpolateNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：自軌道からの x 座標 [m]（省略可能）
        /// </summary>
        public object X { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との平面曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public object Radius { get; set; }
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
    public class TrackYInterpolateNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：自軌道からの y 座標 [m]（省略可能）
        /// </summary>
        public object Y { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との縦曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public object Radius { get; set; }
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
    public class TrackPositionNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：自軌道からの x 座標 [m]
        /// </summary>
        public object X { get; set; }

        /// <summary>
        /// 引数：自軌道からの y 座標 [m]
        /// </summary>
        public object Y { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との平面曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public object RadiusH { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との縦曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        public object RadiusV { get; set; }
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
    public class TrackCantSetgaugeNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：軌間 [m]
        /// </summary>
        public object Gauge { get; set; }
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
    public class TrackCantSetcenterNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：回転中心の x 座標 [m] (正: 曲線の内側, 負: 曲線の外側)
        /// </summary>
        public object X { get; set; }
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
    public class TrackCantSetfunctionNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：関数番号 (0: サイン半波長逓減, 1: 直線逓減)
        /// </summary>
        public object Id { get; set; }
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
    public class TrackCantBegintransitionNode : SyntaxNode
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
        public string Key { get; set; }

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
    public class TrackCantBeginNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：カント [m] (正: 右に傾ける, 負: 左に傾ける)
        /// </summary>
        public object Cant { get; set; }
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
    public class TrackCantEndNode : SyntaxNode
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
        public string Key { get; set; }

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
    public class TrackCantInterpolateNode : SyntaxNode
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
        public string Key { get; set; }
        #region Args

        /// <summary>
        /// 引数：カント [m] (正: 右に傾ける, 負: 左に傾ける)（省略可能）
        /// </summary>
        public object Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="start"></param>
        /// <param name="stop"></param>
        public TrackCantInterpolateNode(IToken start, IToken stop) : base(start, stop) { }
    }
}