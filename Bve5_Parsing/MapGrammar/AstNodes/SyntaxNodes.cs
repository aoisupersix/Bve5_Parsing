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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setgauge";
        #endregion Property

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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setcenter";
        #endregion Property

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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Setfunction";
        #endregion Property

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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Begin";
        #endregion Property

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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "End";
        #endregion Property


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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Interpolate";
        #endregion Property

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
        #region Property

        /// <summary>
        /// マップ要素名
        /// </summary>
        public override string ElementName => "Curve";

        /// <summary>
        /// 関数名
        /// </summary>
        public override string FunctionName => "Change";
        #endregion Property

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
}