/*
 * このファイルは自動生成doc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */
using Antlr4.Runtime;
using System;

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
}