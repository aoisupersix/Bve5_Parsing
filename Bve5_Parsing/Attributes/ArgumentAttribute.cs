using System;

namespace Bve5_Parsing.Attributes
{
    /// <summary>
    /// 構文を引数を示すプロパティ属性です。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ArgumentAttribute: Attribute
    {
        /// <summary>
        /// 引数は省略可能か？（デフォルト：false）
        /// </summary>
        public bool Optional { get; set; } = false;
    }
}
