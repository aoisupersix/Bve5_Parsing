﻿using Bve5_Parsing.MapGrammar.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bve5_Parsing.MapGrammar.EvaluateData
{
    /// <summary>
    /// マップファイルのステートメントを表します。
    /// 各ステートメントは構文ごとにこのクラスを継承して定義されています。
    /// 各構文のキーや引数は、各構文のステートメントを表すクラスにキャストすることで取得できます。
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
        public virtual MapFunctionName? FunctionName => null;

        /// <summary>
        /// マップ副要素名
        /// もし構文に副要素が存在しない場合はnullを返します。
        /// </summary>
        public virtual MapSubElementName? SubElementName => null;

        /// <summary>
        /// キー名
        /// もし構文にキーが存在しない場合はnullを返します。
        /// </summary>
        public virtual string Key { get; set; }

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public abstract bool HasKey { get; }

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public abstract bool HasSubElement { get; }

        /// <summary>
        /// 距離程
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// 新しいステートメントを生成します。
        /// </summary>
        public Statement() { }

        /// <summary>
        /// 距離程を指定して新しいステートメントを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        public Statement(double distance) { Distance = distance; }

        #region 引数
        /// <summary>
        /// 全引数の属性を取得します。
        /// </summary>
        /// <returns></returns>
        protected internal IEnumerable<PropertyInfo> GetArgumentProperties()
        {
            return GetType().GetProperties()
                .Select(p => new
                {
                    Property = p,
                    Attr = p.GetCustomAttributes(typeof(ArgumentAttribute), true)
                        .Select(a => a as ArgumentAttribute)
                        .Where(a => a != null)
                })
                .Where(p => p.Attr.Any())
                .Select(p => p.Property)
                ;
        }
        #endregion

        /// <summary>
        /// ステートメントからSyntaxDataを生成して返します。
        /// </summary>
        /// <param name="evaluator"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public virtual SyntaxData ToSyntaxData()
        {
            var funcName = FunctionName == null ? string.Empty : FunctionName.GetStringValue();
            var syntax = new SyntaxData();
            syntax.Distance = Distance;

            if (HasSubElement)
            {
                //Syntax3
                var subElem = (MapSubElementName)GetType().GetProperty("SubElementName").GetValue(this, null);
                syntax.MapElement = new string[2]
                {
                    ElementName.GetStringValue().ToLower(),
                    subElem.GetStringValue().ToLower()
                };
            }
            else
            {
                //Syntax1 or Syntax2
                syntax.MapElement = new string[1]
                {
                    ElementName.GetStringValue().ToLower()
                };
            }

            if (HasKey)
            {
                syntax.Key = GetType().GetProperty("Key").GetValue(this, null) as string;
            }

            syntax.Function = funcName.ToLower();
            foreach (var argument in GetArgumentProperties())
            {
                var val = argument.GetValue(this, null);
                if (val == null)
                    continue;

                syntax.SetArg(argument.Name.ToLower(), val);
            }

            return syntax;
        }
    }
}
