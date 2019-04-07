using System;

namespace Bve5_Parsing.Attributes
{
    /// <summary>
    /// 非推奨の構文を示すクラス属性です。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DeprecatedAttribute : Attribute
    {
    }
}
