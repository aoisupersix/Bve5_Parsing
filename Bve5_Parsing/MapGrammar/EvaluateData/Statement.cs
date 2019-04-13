using System;
using System.Collections.Generic;
using System.Text;

namespace Bve5_Parsing.MapGrammar.EvaluateData
{
    /// <summary>
    /// ステートメントのベースクラス
    /// </summary>
    public abstract class Statement
    {
        /// <summary>
        /// マップ要素名
        /// </summary>
        public abstract MapElementName ElementName { get; }

        /// <summary>
        /// マップ関数名
        /// </summary>
        public abstract MapFunctionName FunctionName { get; }

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public abstract bool HasKey { get; }

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public abstract bool HasSubElement { get; }
    }
}
