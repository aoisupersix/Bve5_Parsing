using Bve5_Parsing.MapGrammar.Attributes;
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
        /// ステートメントが引数を保持しているかどうか
        /// </summary>
        /// <param name="name">引数名</param>
        /// <param name="isIgnoreCase">大文字小文字を無視するかどうか</param>
        /// <param name="includeNullArgument">値がNullの引数を保持していると判定するかどうか</param>
        /// <returns></returns>
        public bool HasArgument(string name, bool isIgnoreCase = false, bool includeNullArgument = false)
        {
            var property = GetArgumentProperty(name, isIgnoreCase);
            if (property == null) return false;
            if (!includeNullArgument) return property.GetValue(this, null) != null;

            return true;
        }

        /// <summary>
        /// 引数値を取得します。
        /// 引数名が存在しない場合はnullを返します。
        /// </summary>
        /// <param name="name">引数名</param>
        /// <param name="isIgnoreCase">大文字小文字を無視するかどうか</param>
        /// <returns></returns>
        public object GetArgumentValue(string name, bool isIgnoreCase = false)
        {
            return GetArgumentProperty(name, isIgnoreCase)?.GetValue(this, null);
        }

        /// <summary>
        /// ステートメントが保持している全ての引数名を取得します。
        /// 引数名はStatement.ToSyntaxData().ArgumentsのKey名とは異なり、CamelCaseで返します。
        /// </summary>
        /// <param name="includeNullArgument">値がNullの引数を含めるかどうか</param>
        /// <returns></returns>
        public IEnumerable<string> GetArgumentNames(bool includeNullArgument = false)
        {
            return GetArgumentProperties()
                .Where(p => includeNullArgument || p.GetValue(this, null) != null)
                .Select(p => p.Name)
                ;
        }

        /// <summary>
        /// ステートメントが保持している全ての引数を辞書型にして取得します。
        /// 引数名はStatement.ToSyntaxData().ArgumentsのKey名とは異なり、CamelCaseで返します。
        /// </summary>
        /// <param name="includeNullArgument">値がNullの引数を含めるかどうか</param>
        /// <returns></returns>
        public Dictionary<string, object> GetArgumentKeyValuePairs(bool includeNullArgument = false)
        {
            return GetArgumentProperties()
                .Where(p => includeNullArgument || p.GetValue(this, null) != null)
                .Select(p => new
                {
                    p.Name,
                    Value = p.GetValue(this, null)
                })
                .ToDictionary(k => k.Name, e => e.Value)
                ;
        }

        /// <summary>
        /// ステートメントが保持している全ての引数を辞書型にして取得します。
        /// 引数値はdouble?とstringで保持しているが、どうせobject型で返すなら全てstringでいいのでは、ということで値がstringの辞書型で返します。
        /// 型を保持したまま返したい場合はGetArgumentKeyValuePairsを使用してください。
        /// 引数名はStatement.ToSyntaxData().ArgumentsのKey名とは異なり、CamelCaseで返します。
        /// </summary>
        /// <param name="includeNullArgument">値がNullの引数を含めるかどうか</param>
        /// <returns></returns>
        public Dictionary<string, string> GetArgumentKeyValuePairsAsString(bool includeNullArgument = false)
        {
            return GetArgumentKeyValuePairs()
                .Select(kv => new KeyValuePair<string, string>(kv.Key, kv.Value.ToString()))
                .ToDictionary(kv => kv.Key, kv => kv.Value)
                ;
        }

        /// <summary>
        /// 引数の属性を取得します。
        /// </summary>
        /// <param name="name">引数名</param>
        /// <param name="isIgnoreCase">大文字小文字を無視するかどうか</param>
        /// <returns></returns>
        protected internal PropertyInfo GetArgumentProperty(string name, bool isIgnoreCase = false)
        {
            return GetArgumentProperties()
                .Where(p => isIgnoreCase ? p.Name.ToLower() == name.ToLower() : p.Name == name)
                .FirstOrDefault();
        }

        /// <summary>
        /// 全引数の属性を取得します。
        /// </summary>
        /// <returns></returns>
        protected internal IEnumerable<PropertyInfo> GetArgumentProperties(BindingFlags flags = BindingFlags.Default)
        {
            return GetType().GetProperties(flags)
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
