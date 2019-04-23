using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bve5_Parsing.MapGrammar.EvaluateData
{
    /// <summary>
    /// 構文情報を管理するクラス
    /// このクラスは引数名が文字列で分かりづらいため、利用は非推奨です。
    /// 今後はBve5_Parsing.MapGrammar.EvaluateData.Statementを利用して下さい。
    /// </summary>
    public class SyntaxData
    {
        #region フィールド
        /// <summary>
        /// 引数
        /// </summary>
        private Dictionary<string, object> _arguments;
        #endregion

        /// <summary>
        /// 距離程
        /// </summary>
        public double Distance { get; protected internal set; }

        /// <summary>
        /// マップ要素名
        /// </summary>
        public string[] MapElement { get; protected internal set; }

        /// <summary>
        /// キー名
        /// </summary>
        public string Key { get; protected internal set; }

        /// <summary>
        /// 関数名
        /// </summary>
        public string Function { get; protected internal set; }

        /// <summary>
        /// 引数
        /// </summary>
        public ReadOnlyDictionary<string, object> Arguments { get; }

        public SyntaxData()
        {
            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 構文タイプ1のインスタンスを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        /// <param name="mapElement">マップ要素</param>
        /// <param name="function">関数名</param>
        public SyntaxData(double distance, string mapElement, string function)
        {
            Distance = distance;
            MapElement = new string[] { mapElement };
            Function = function;

            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 構文タイプ2のインスタンスを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        /// <param name="mapElement">マップ要素</param>
        /// <param name="key">キー名</param>
        /// <param name="function">関数名</param>
        public SyntaxData(double distance, string mapElement, string key, string function)
        {
            Distance = distance;
            MapElement = new string[] { mapElement };
            Key = key;
            Function = function;

            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 構文タイプ3のインスタンスを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        /// <param name="mapElement">マップ要素</param>
        /// <param name="key">キー名</param>
        /// <param name="function">関数名</param>
        public SyntaxData(double distance, string mapElement1, string mapElement2, string key, string function)
        {
            Distance = distance;
            MapElement = new string[] { mapElement1, mapElement2 };
            Key = key;
            Function = function;

            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 引数を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public SyntaxData SetArg(string key, string val)
        {
            _arguments.Add(key, val);
            return this;
        }

        /// <summary>
        /// 引数を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public SyntaxData SetArg(string key, double val)
        {
            _arguments.Add(key, val);
            return this;
        }

        /// <summary>
        /// 引数を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public SyntaxData SetArg(string key, object val)
        {
            _arguments.Add(key, val);
            return this;
        }

        #region Override
        /// <summary>
        /// 等価チェック
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var s = (SyntaxData)obj;

            return
                s.Distance == Distance &&
                ((s.MapElement == null && MapElement == null) || (s.MapElement != null && MapElement != null && s.MapElement.SequenceEqual(MapElement))) &&
                s.Key == Key &&
                s.Function == Function &&
                s.Arguments.Count() == Arguments.Count &&
                s.Arguments.Keys.ToArray().SequenceEqual(Arguments.Keys.ToArray()) &&
                s.Arguments.Values.ToArray().SequenceEqual(Arguments.Values.ToArray())
                ;
        }

        public override int GetHashCode()
        {
            return
                Distance.GetHashCode() ^
                MapElement.GetHashCode() ^
                Key.GetHashCode() ^
                Function.GetHashCode() ^
                Arguments.GetHashCode()
                ;
        }
        #endregion
    }
}
