/*
 * このファイルはdoc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Bve5_Parsing.MapGrammar.Attributes;

namespace Bve5_Parsing.MapGrammar.EvaluateData {

    /// <summary>
    /// Curve.Setgauge(Value);
    /// </summary>
    public partial class CurveSetgaugeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setgauge;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：軌間 [m]
        /// </summary>
        [Argument]
        public double? Value { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveSetgaugeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveSetgaugeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Gauge.Set(Value);
    /// </summary>
    public partial class GaugeSetStatement : CurveSetgaugeStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Gauge;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Set;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public GaugeSetStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public GaugeSetStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Gauge(Value);
    /// </summary>
    public partial class CurveGaugeStatement : CurveSetgaugeStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Gauge;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveGaugeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveGaugeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Setcenter(X);
    /// </summary>
    public partial class CurveSetcenterStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setcenter;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：回転中心の x 座標 [m] (正: 曲線の内側, 負: 曲線の外側)
        /// </summary>
        [Argument]
        public double? X { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveSetcenterStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveSetcenterStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Setfunction(Id);
    /// </summary>
    public partial class CurveSetfunctionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setfunction;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：関数番号 (0: サイン半波長逓減, 1: 直線逓減)
        /// </summary>
        [Argument]
        public double? Id { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveSetfunctionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveSetfunctionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Begintransition();
    /// </summary>
    public partial class CurveBegintransitionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begintransition;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveBegintransitionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveBegintransitionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Begin(Radius, Cant?);
    /// </summary>
    public partial class CurveBeginStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線)
        /// </summary>
        [Argument]
        public double? Radius { get; set; }

        /// <summary>
        /// 引数：カント [m]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveBeginStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveBeginStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Begincircular(Radius, Cant?);
    /// </summary>
    public partial class CurveBegincircularStatement : CurveBeginStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begincircular;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveBegincircularStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveBegincircularStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.End();
    /// </summary>
    public partial class CurveEndStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.End;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveEndStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveEndStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Interpolate(Radius?, Cant?);
    /// </summary>
    public partial class CurveInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線, 0: 直線)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Radius { get; set; }

        /// <summary>
        /// 引数：カント [m]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Curve.Change(Radius);
    /// </summary>
    public partial class CurveChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Curve;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線, 0: 直線)
        /// </summary>
        [Argument]
        public double? Radius { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CurveChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CurveChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Gradient.Begintransition();
    /// </summary>
    public partial class GradientBegintransitionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Gradient;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begintransition;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public GradientBegintransitionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public GradientBegintransitionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Gradient.Begin(Gradient);
    /// </summary>
    public partial class GradientBeginStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Gradient;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：勾配 [‰]
        /// </summary>
        [Argument]
        public double? Gradient { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public GradientBeginStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public GradientBeginStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Gradient.Beginconst(Gradient);
    /// </summary>
    public partial class GradientBeginconstStatement : GradientBeginStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Gradient;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Beginconst;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public GradientBeginconstStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public GradientBeginconstStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Gradient.End();
    /// </summary>
    public partial class GradientEndStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Gradient;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.End;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public GradientEndStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public GradientEndStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Gradient.Interpolate(Gradient?);
    /// </summary>
    public partial class GradientInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Gradient;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：勾配 [‰]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Gradient { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public GradientInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public GradientInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].X.Interpolate(X?, Radius?);
    /// </summary>
    public partial class TrackXInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.X;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：自軌道からの x 座標 [m]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? X { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との平面曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Radius { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackXInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackXInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Y.Interpolate(Y?, Radius?);
    /// </summary>
    public partial class TrackYInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Y;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：自軌道からの y 座標 [m]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Y { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との縦曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Radius { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackYInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackYInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Position(X, Y, RadiusH?, RadiusV?);
    /// </summary>
    public partial class TrackPositionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Position;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：自軌道からの x 座標 [m]
        /// </summary>
        [Argument]
        public double? X { get; set; }

        /// <summary>
        /// 引数：自軌道からの y 座標 [m]
        /// </summary>
        [Argument]
        public double? Y { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との平面曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? RadiusH { get; set; }

        /// <summary>
        /// 引数：現在の距離程以降の自軌道との縦曲線相対半径 [m] (0: 直線)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? RadiusV { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackPositionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackPositionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Setgauge(Gauge);
    /// </summary>
    public partial class TrackCantSetgaugeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setgauge;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：軌間 [m]
        /// </summary>
        [Argument]
        public double? Gauge { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantSetgaugeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantSetgaugeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Gauge(Gauge);
    /// </summary>
    public partial class TrackGaugeStatement : TrackCantSetgaugeStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Gauge;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackGaugeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackGaugeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Setcenter(X);
    /// </summary>
    public partial class TrackCantSetcenterStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setcenter;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：回転中心の x 座標 [m] (正: 曲線の内側, 負: 曲線の外側)
        /// </summary>
        [Argument]
        public double? X { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantSetcenterStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantSetcenterStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Setfunction(Id);
    /// </summary>
    public partial class TrackCantSetfunctionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setfunction;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：関数番号 (0: サイン半波長逓減, 1: 直線逓減)
        /// </summary>
        [Argument]
        public double? Id { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantSetfunctionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantSetfunctionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Begintransition();
    /// </summary>
    public partial class TrackCantBegintransitionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begintransition;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantBegintransitionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantBegintransitionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Begin(Cant);
    /// </summary>
    public partial class TrackCantBeginStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：カント [m] (正: 右に傾ける, 負: 左に傾ける)
        /// </summary>
        [Argument]
        public double? Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantBeginStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantBeginStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.End();
    /// </summary>
    public partial class TrackCantEndStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.End;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantEndStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantEndStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant.Interpolate(Cant?);
    /// </summary>
    public partial class TrackCantInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// マップ副要素名
        /// </summary>
        public override MapSubElementName? SubElementName => MapSubElementName.Cant;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => true;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrackKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：カント [m] (正: 右に傾ける, 負: 左に傾ける)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Track[TrackKey].Cant(Cant?);
    /// </summary>
    public partial class TrackCantStatement : TrackCantInterpolateStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Track;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Cant;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrackCantStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrackCantStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Structure.Load(FilePath);
    /// </summary>
    public partial class StructureLoadStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Structure;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Load;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルからストラクチャーリストファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StructureLoadStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public StructureLoadStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
    /// </summary>
    public partial class StructurePutStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Structure;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Put;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StructureKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        [Argument]
        public double? X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        [Argument]
        public double? Y { get; set; }

        /// <summary>
        /// 引数：軌道からの z 座標 [m]
        /// </summary>
        [Argument]
        public double? Z { get; set; }

        /// <summary>
        /// 引数：軌道に対する x 軸回りの角 [deg]
        /// </summary>
        [Argument]
        public double? RX { get; set; }

        /// <summary>
        /// 引数：軌道に対する y 軸回りの角 [deg]
        /// </summary>
        [Argument]
        public double? RY { get; set; }

        /// <summary>
        /// 引数：軌道に対する z 軸回りの角 [deg]
        /// </summary>
        [Argument]
        public double? RZ { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        [Argument]
        public double? Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        [Argument]
        public double? Span { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StructurePutStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public StructurePutStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Structure[StructureKey].Put0(TrackKey, Tilt, Span);
    /// </summary>
    public partial class StructurePut0Statement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Structure;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Put0;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StructureKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        [Argument]
        public double? Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        [Argument]
        public double? Span { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StructurePut0Statement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public StructurePut0Statement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag?);
    /// </summary>
    public partial class StructurePutbetweenStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Structure;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Putbetween;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StructureKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：一方の軌道の軌道名 (0: 自軌道)
        /// </summary>
        [Argument]
        public string TrackKey1 { get; set; }

        /// <summary>
        /// 引数：他方の軌道の軌道名
        /// </summary>
        [Argument]
        public string TrackKey2 { get; set; }

        /// <summary>
        /// 引数：変形方向 (0: x および y 方向に変形, 1: x 方向のみに変形)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Flag { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StructurePutbetweenStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public StructurePutbetweenStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval, StructureKey);
    /// </summary>
    public partial class RepeaterBeginStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Repeater;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：RepeaterKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        [Argument]
        public double? X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        [Argument]
        public double? Y { get; set; }

        /// <summary>
        /// 引数：軌道からの z 座標 [m]
        /// </summary>
        [Argument]
        public double? Z { get; set; }

        /// <summary>
        /// 引数：軌道に対する x 軸回りの角 [deg]
        /// </summary>
        [Argument]
        public double? RX { get; set; }

        /// <summary>
        /// 引数：軌道に対する y 軸回りの角 [deg]
        /// </summary>
        [Argument]
        public double? RY { get; set; }

        /// <summary>
        /// 引数：軌道に対する z 軸回りの角 [deg]
        /// </summary>
        [Argument]
        public double? RZ { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        [Argument]
        public double? Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        [Argument]
        public double? Span { get; set; }

        /// <summary>
        /// 引数：配置間隔 [m]
        /// </summary>
        [Argument]
        public double? Interval { get; set; }

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）のリスト
        /// </summary>
        protected List<string> _structurekeys = new List<string>();

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）の読み取り専用コレクション
        /// </summary>
        public ReadOnlyCollection<string> StructureKeys => _structurekeys.AsReadOnly();
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public RepeaterBeginStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public RepeaterBeginStatement(double distance) : base(distance) { }

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）を追加します。
        /// </summary>
        public void AddStructureKey(string structurekey)
        {
            _structurekeys.Add(structurekey);
        }

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）に値をセットします。
        /// テスト用
        /// </summary>
        public Statement SetStructureKeys(params string[] structurekeys)
        {
            _structurekeys.AddRange(structurekeys);
            return this;
        }

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）対応
        /// </summary>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _structurekeys.Count; i++)
            {
                syntax.SetArg($"structurekey{i + 1}", _structurekeys[i]);
            }

            return syntax;
        }
    }

    /// <summary>
    /// Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval, StructureKey);
    /// </summary>
    public partial class RepeaterBegin0Statement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Repeater;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin0;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：RepeaterKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：配置先の軌道名 (0: 自軌道)
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)
        /// </summary>
        [Argument]
        public double? Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]
        /// </summary>
        [Argument]
        public double? Span { get; set; }

        /// <summary>
        /// 引数：配置間隔 [m]
        /// </summary>
        [Argument]
        public double? Interval { get; set; }

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）のリスト
        /// </summary>
        protected List<string> _structurekeys = new List<string>();

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）の読み取り専用コレクション
        /// </summary>
        public ReadOnlyCollection<string> StructureKeys => _structurekeys.AsReadOnly();
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public RepeaterBegin0Statement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public RepeaterBegin0Statement(double distance) : base(distance) { }

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）を追加します。
        /// </summary>
        public void AddStructureKey(string structurekey)
        {
            _structurekeys.Add(structurekey);
        }

        /// <summary>
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）に値をセットします。
        /// テスト用
        /// </summary>
        public Statement SetStructureKeys(params string[] structurekeys)
        {
            _structurekeys.AddRange(structurekeys);
            return this;
        }

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長引数：ストラクチャー名 (ストラクチャーリストファイルで定義した文字列）対応
        /// </summary>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _structurekeys.Count; i++)
            {
                syntax.SetArg($"structurekey{i + 1}", _structurekeys[i]);
            }

            return syntax;
        }
    }

    /// <summary>
    /// Repeater[RepeaterKey].End();
    /// </summary>
    public partial class RepeaterEndStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Repeater;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.End;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：RepeaterKey
        /// </summary>
        public override string Key { get; set; }


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public RepeaterEndStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public RepeaterEndStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Background.Change(StructureKey);
    /// </summary>
    public partial class BackgroundChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Background;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：ストラクチャー名
        /// </summary>
        [Argument]
        public string StructureKey { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public BackgroundChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public BackgroundChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Station.Load(FilePath);
    /// </summary>
    public partial class StationLoadStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Station;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Load;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルから停車場リストファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StationLoadStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public StationLoadStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Station[StationKey].Put(Door, Margin1, Margin2);
    /// </summary>
    public partial class StationPutStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Station;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Put;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：StationKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：開くドアの方向 (-1: 左, 1: 右)
        /// </summary>
        [Argument]
        public double? Door { get; set; }

        /// <summary>
        /// 引数：停止位置誤差の後方許容範囲 (負の値で設定)
        /// </summary>
        [Argument]
        public double? Margin1 { get; set; }

        /// <summary>
        /// 引数：停止位置誤差の後方許容範囲
        /// </summary>
        [Argument]
        public double? Margin2 { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public StationPutStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public StationPutStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Section.Begin(Signal);
    /// </summary>
    public partial class SectionBeginStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Section;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 可変長引数：先行列車が n 閉そく先に存在する場合の信号インデックス（0: この閉塞）のリスト
        /// </summary>
        protected List<double?> _signals = new List<double?>();

        /// <summary>
        /// 可変長引数：先行列車が n 閉そく先に存在する場合の信号インデックス（0: この閉塞）の読み取り専用コレクション
        /// </summary>
        public ReadOnlyCollection<double?> Signals => _signals.AsReadOnly();
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SectionBeginStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SectionBeginStatement(double distance) : base(distance) { }

        /// <summary>
        /// 可変長引数：先行列車が n 閉そく先に存在する場合の信号インデックス（0: この閉塞）を追加します。
        /// </summary>
        public void AddSignal(double? signal)
        {
            _signals.Add(signal);
        }

        /// <summary>
        /// 可変長引数：先行列車が n 閉そく先に存在する場合の信号インデックス（0: この閉塞）に値をセットします。
        /// テスト用
        /// </summary>
        public Statement SetSignals(params double?[] signals)
        {
            _signals.AddRange(signals);
            return this;
        }

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長引数：先行列車が n 閉そく先に存在する場合の信号インデックス（0: この閉塞）対応
        /// </summary>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _signals.Count; i++)
            {
                syntax.SetArg($"signal{i + 1}", _signals[i]);
            }

            return syntax;
        }
    }

    /// <summary>
    /// Section.Beginnew(Signal);
    /// </summary>
    public partial class SectionBeginnewStatement : SectionBeginStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Section;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Beginnew;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SectionBeginnewStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SectionBeginnewStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Section.Setspeedlimit(V);
    /// </summary>
    public partial class SectionSetspeedlimitStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Section;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setspeedlimit;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 可変長引数：走行速度 [km/h] （null: 許容速度なし）のリスト
        /// </summary>
        protected List<double?> _vs = new List<double?>();

        /// <summary>
        /// 可変長引数：走行速度 [km/h] （null: 許容速度なし）の読み取り専用コレクション
        /// </summary>
        public ReadOnlyCollection<double?> Vs => _vs.AsReadOnly();
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SectionSetspeedlimitStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SectionSetspeedlimitStatement(double distance) : base(distance) { }

        /// <summary>
        /// 可変長引数：走行速度 [km/h] （null: 許容速度なし）を追加します。
        /// </summary>
        public void AddV(double? v)
        {
            _vs.Add(v);
        }

        /// <summary>
        /// 可変長引数：走行速度 [km/h] （null: 許容速度なし）に値をセットします。
        /// テスト用
        /// </summary>
        public Statement SetVs(params double?[] vs)
        {
            _vs.AddRange(vs);
            return this;
        }

        /// <summary>
        /// StatementからSyntaxDataを生成して返します。
        /// 可変長引数：走行速度 [km/h] （null: 許容速度なし）対応
        /// </summary>
        public override SyntaxData ToSyntaxData()
        {
            var syntax = base.ToSyntaxData();
            for (var i = 0; i < _vs.Count; i++)
            {
                syntax.SetArg($"v{i + 1}", _vs[i]);
            }

            return syntax;
        }
    }

    /// <summary>
    /// Signal.Speedlimit(V);
    /// </summary>
    public partial class SignalSpeedlimitStatement : SectionSetspeedlimitStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Signal;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Speedlimit;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SignalSpeedlimitStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SignalSpeedlimitStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Speedlimit.Setsignal(V);
    /// </summary>
    public partial class SpeedlimitSetsignalStatement : SectionSetspeedlimitStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Speedlimit;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Setsignal;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpeedlimitSetsignalStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SpeedlimitSetsignalStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Signal.Load(FilePath);
    /// </summary>
    public partial class SignalLoadStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Signal;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Load;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルから信号現示リストファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SignalLoadStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SignalLoadStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z?, RX?, RY?, RZ?, Tilt?, Span?);
    /// </summary>
    public partial class SignalPutStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Signal;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Put;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：SignalAspectKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：関連づける閉そくの相対インデックス
        /// </summary>
        [Argument]
        public double? Section { get; set; }

        /// <summary>
        /// 引数：配置先の軌道名
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        [Argument]
        public double? X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        [Argument]
        public double? Y { get; set; }

        /// <summary>
        /// 引数：軌道からの z 座標 [m]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Z { get; set; }

        /// <summary>
        /// 引数：軌道に対する x 軸回りの角 [deg]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? RX { get; set; }

        /// <summary>
        /// 引数：軌道に対する y 軸回りの角 [deg]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? RY { get; set; }

        /// <summary>
        /// 引数：軌道に対する z 軸回りの角 [deg]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? RZ { get; set; }

        /// <summary>
        /// 引数：傾斜オプション (0: 常に水平, 1: 勾配に連動, 2: カントに連動, 3: 勾配とカントに連動)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Tilt { get; set; }

        /// <summary>
        /// 引数：曲線における弦の長さ [m]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Span { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SignalPutStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SignalPutStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Beacon.Put(Type, Section, Senddata);
    /// </summary>
    public partial class BeaconPutStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Beacon;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Put;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：保安装置に送る地上子種別 (整数)
        /// </summary>
        [Argument]
        public double? Type { get; set; }

        /// <summary>
        /// 引数：関連づける閉そくの相対インデックス
        /// </summary>
        [Argument]
        public double? Section { get; set; }

        /// <summary>
        /// 引数：保安装置に送る値 (整数)
        /// </summary>
        [Argument]
        public double? Senddata { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public BeaconPutStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public BeaconPutStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Speedlimit.Begin(V);
    /// </summary>
    public partial class SpeedlimitBeginStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Speedlimit;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Begin;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：走行速度 [km/h]
        /// </summary>
        [Argument]
        public double? V { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpeedlimitBeginStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SpeedlimitBeginStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Speedlimit.End();
    /// </summary>
    public partial class SpeedlimitEndStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Speedlimit;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.End;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SpeedlimitEndStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SpeedlimitEndStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Pretrain.Pass(Time?, Second?);
    /// </summary>
    public partial class PretrainPassStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Pretrain;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Pass;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：時刻を表す文字列 ('hh:mm:ss')（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public string Time { get; set; }

        /// <summary>
        /// 引数：00:00:00 からの経過時間 [sec]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Second { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public PretrainPassStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public PretrainPassStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Light.Ambient(Red, Green, Blue);
    /// </summary>
    public partial class LightAmbientStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Light;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Ambient;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? Red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? Green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? Blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LightAmbientStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LightAmbientStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Light.Diffuse(Red, Green, Blue);
    /// </summary>
    public partial class LightDiffuseStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Light;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Diffuse;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? Red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? Green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? Blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LightDiffuseStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LightDiffuseStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Light.Direction(Pitch, Yaw);
    /// </summary>
    public partial class LightDirectionStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Light;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Direction;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：角度
        /// </summary>
        [Argument]
        public double? Pitch { get; set; }

        /// <summary>
        /// 引数：回転角
        /// </summary>
        [Argument]
        public double? Yaw { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LightDirectionStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LightDirectionStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Fog.Interpolate(Density?, Red?, Green?, Blue?);
    /// </summary>
    public partial class FogInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Fog;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：濃度（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Density { get; set; }

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public FogInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public FogInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Fog.Set(Density?, Red?, Green?, Blue?);
    /// </summary>
    public partial class FogSetStatement : FogInterpolateStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Fog;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Set;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public FogSetStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public FogSetStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Drawdistance.Change(Value);
    /// </summary>
    public partial class DrawdistanceChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Drawdistance;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：距離 [m] (0: [設定] ウィンドウで設定される描画距離を適用)
        /// </summary>
        [Argument]
        public double? Value { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public DrawdistanceChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public DrawdistanceChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Cabilluminance.Interpolate(Value?);
    /// </summary>
    public partial class CabilluminanceInterpolateStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Cabilluminance;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Interpolate;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：昼間画像と夜間画像の混合比 (0: 夜間画像 ~ 1: 昼間画像)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Value { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CabilluminanceInterpolateStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CabilluminanceInterpolateStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Cabilluminance.Set(Value);
    /// </summary>
    public partial class CabilluminanceSetStatement : CabilluminanceInterpolateStatement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Cabilluminance;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Set;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public CabilluminanceSetStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public CabilluminanceSetStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Irregularity.Change(X, Y, R, LX, LY, LR);
    /// </summary>
    public partial class IrregularityChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Irregularity;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：左右変位 (左と右のレールの通り変位の平均に相当) の標準偏差 [m]
        /// </summary>
        [Argument]
        public double? X { get; set; }

        /// <summary>
        /// 引数：上下変位 (左と右のレールの高低変位の平均に相当) の標準偏差 [m]
        /// </summary>
        [Argument]
        public double? Y { get; set; }

        /// <summary>
        /// 引数：ロール変位 (水準変位を軌間で除した値に相当) の標準偏差 [rad]
        /// </summary>
        [Argument]
        public double? R { get; set; }

        /// <summary>
        /// 引数：左右変位の遮断波長 [m]
        /// </summary>
        [Argument]
        public double? LX { get; set; }

        /// <summary>
        /// 引数：上下変位の遮断波長 [m]
        /// </summary>
        [Argument]
        public double? LY { get; set; }

        /// <summary>
        /// 引数：ロール変位の遮断波長 [m]
        /// </summary>
        [Argument]
        public double? LR { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public IrregularityChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public IrregularityChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Adhesion.Change(A, B?, C?);
    /// </summary>
    public partial class AdhesionChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Adhesion;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：走行速度 0 km/h における粘着係数
        /// </summary>
        [Argument]
        public double? A { get; set; }

        /// <summary>
        /// 引数：粘着係数の走行速度に対する変化を表す係数（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? B { get; set; }

        /// <summary>
        /// 引数：粘着係数の走行速度に対する変化を表す係数（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? C { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public AdhesionChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public AdhesionChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Sound.Load(FilePath);
    /// </summary>
    public partial class SoundLoadStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Sound;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Load;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルからサウンドリストファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SoundLoadStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SoundLoadStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Sound[SoundKey].Play();
    /// </summary>
    public partial class SoundPlayStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Sound;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Play;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：SoundKey
        /// </summary>
        public override string Key { get; set; }


        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public SoundPlayStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public SoundPlayStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Sound3d.Load(FilePath);
    /// </summary>
    public partial class Sound3dLoadStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Sound3d;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Load;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：このファイルからサウンドリストファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Sound3dLoadStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public Sound3dLoadStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Sound3d[SoundKey].Put(X, Y);
    /// </summary>
    public partial class Sound3dPutStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Sound3d;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Put;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：SoundKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：軌道からの x 座標 [m]
        /// </summary>
        [Argument]
        public double? X { get; set; }

        /// <summary>
        /// 引数：軌道からの y 座標 [m]
        /// </summary>
        [Argument]
        public double? Y { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public Sound3dPutStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public Sound3dPutStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Rollingnoise.Change(Index);
    /// </summary>
    public partial class RollingnoiseChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Rollingnoise;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：車両サウンドファイルの [Run] セクションで定義したインデックス
        /// </summary>
        [Argument]
        public double? Index { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public RollingnoiseChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public RollingnoiseChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Flangenoise.Change(Index);
    /// </summary>
    public partial class FlangenoiseChangeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Flangenoise;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Change;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：車両サウンドファイルの [Flange] セクションで定義したインデックス
        /// </summary>
        [Argument]
        public double? Index { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public FlangenoiseChangeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public FlangenoiseChangeStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Jointnoise.Play(Index);
    /// </summary>
    public partial class JointnoisePlayStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Jointnoise;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Play;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：車両サウンドファイルの [Joint] セクションで定義したインデックス
        /// </summary>
        [Argument]
        public double? Index { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public JointnoisePlayStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public JointnoisePlayStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Train.Add(TrainKey, FilePath, TrackKey?, Direction?);
    /// </summary>
    public partial class TrainAddStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Train;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Add;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：他列車名 (任意の文字列)
        /// </summary>
        [Argument]
        public string TrainKey { get; set; }

        /// <summary>
        /// 引数：このファイルから他列車ファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }

        /// <summary>
        /// 引数：走行する軌道（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：進行方向 (-1: 対向, 1: 並走)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Direction { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrainAddStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrainAddStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Train[TrainKey].Load(FilePath, TrackKey, Direction);
    /// </summary>
    public partial class TrainLoadStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Train;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Load;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：このファイルから他列車ファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }

        /// <summary>
        /// 引数：走行する軌道
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：進行方向 (-1: 対向, 1: 並走)
        /// </summary>
        [Argument]
        public double? Direction { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrainLoadStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrainLoadStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Train[TrainKey].Enable(Time?, Second?);
    /// </summary>
    public partial class TrainEnableStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Train;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Enable;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：時刻を表す文字列 ('hh:mm:ss')（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public string Time { get; set; }

        /// <summary>
        /// 引数：00:00:00 からの経過時間 [sec]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? Second { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrainEnableStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrainEnableStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
    /// </summary>
    public partial class TrainStopStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Train;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Stop;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：減速度 [km/h/s]
        /// </summary>
        [Argument]
        public double? Decelerate { get; set; }

        /// <summary>
        /// 引数：停車時間 [s]
        /// </summary>
        [Argument]
        public double? StopTime { get; set; }

        /// <summary>
        /// 引数：加速度 [km/h/s]
        /// </summary>
        [Argument]
        public double? Accelerate { get; set; }

        /// <summary>
        /// 引数：加速後の走行速度 [km/h]
        /// </summary>
        [Argument]
        public double? Speed { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrainStopStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrainStopStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Train[TrainKey].Settrack(TrackKey, Direction);
    /// </summary>
    public partial class TrainSettrackStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Train;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Settrack;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => true;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        /// <summary>
        /// Key：TrainKey
        /// </summary>
        public override string Key { get; set; }

        #region Args

        /// <summary>
        /// 引数：走行する軌道
        /// </summary>
        [Argument]
        public string TrackKey { get; set; }

        /// <summary>
        /// 引数：進行方向 (-1: 対向, 1: 並走)
        /// </summary>
        [Argument]
        public double? Direction { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TrainSettrackStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public TrainSettrackStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Legacy.Fog(Fogstart, Fogend, red, green, blue);
    /// </summary>
    public partial class LegacyFogStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Legacy;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Fog;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：視界が100%の距離 [m]
        /// </summary>
        [Argument]
        public double? Fogstart { get; set; }

        /// <summary>
        /// 引数：視界が0%になる距離 [m]
        /// </summary>
        [Argument]
        public double? Fogend { get; set; }

        /// <summary>
        /// 引数：赤成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? red { get; set; }

        /// <summary>
        /// 引数：緑成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? green { get; set; }

        /// <summary>
        /// 引数：青成分 (0 ~ 1)
        /// </summary>
        [Argument]
        public double? blue { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LegacyFogStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LegacyFogStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Legacy.Curve(radius, cant);
    /// </summary>
    public partial class LegacyCurveStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Legacy;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Curve;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：曲線半径 [m] (正: 右曲線, 負: 左曲線)
        /// </summary>
        [Argument]
        public double? radius { get; set; }

        /// <summary>
        /// 引数：カント [m]
        /// </summary>
        [Argument]
        public double? cant { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LegacyCurveStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LegacyCurveStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Legacy.Pitch(rate?);
    /// </summary>
    public partial class LegacyPitchStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Legacy;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Pitch;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：勾配 [‰]（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? rate { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LegacyPitchStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LegacyPitchStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Legacy.Turn(slope?);
    /// </summary>
    public partial class LegacyTurnStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Legacy;

        /// <summary>
        /// 関数名
        /// </summary>
        public override MapFunctionName? FunctionName => MapFunctionName.Turn;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：傾き(+: 右, -: 左)（省略可能）
        /// </summary>
        [Argument(Optional = true)]
        public double? slope { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public LegacyTurnStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public LegacyTurnStatement(double distance) : base(distance) { }
    }

    /// <summary>
    /// Include(FilePath);
    /// </summary>
    public partial class IncludeStatement : Statement
    {
        #region SyntaxInfo

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override MapElementName ElementName => MapElementName.Include;

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public override bool HasKey => false;

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public override bool HasSubElement => false;
        #endregion SyntaxInfo

        #region Args

        /// <summary>
        /// 引数：挿入するMapファイルへの相対パス
        /// </summary>
        [Argument]
        public string FilePath { get; set; }
        #endregion Args

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public IncludeStatement() { }

        /// <summary>
        /// 距離程を指定して新しいインスタンスを生成します。
        /// </summary>
        public IncludeStatement(double distance) : base(distance) { }
    }
}