using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// 変数管理クラス
    /// </summary>
    public class VariableStore
    {
        private Dictionary<string, object> _vars;

        public IReadOnlyDictionary<string, object> Vars { get; }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public VariableStore()
        {
            _vars = new Dictionary<string, object>();
            Vars = new ReadOnlyDictionary<string, object>(_vars);
        }

        /// <summary>
        /// 変数を追加、もしくは上書きします。
        /// </summary>
        /// <param name="key">変数名</param>
        /// <param name="val">変数の値</param>
        public void SetVar(string key, object val)
        {
            if (Vars.ContainsKey(key))
                _vars[key] = val;
            else
                _vars.Add(key, val);
        }

        /// <summary>
        /// 変数を取得します。
        /// </summary>
        /// <param name="key">変数名</param>
        /// <returns>変数の値</returns>
        public object GetVar(string key)
        {
            // TODO: 本家仕様を確認する。変数がない場合は0だっけ？
            if (Vars.ContainsKey(key))     /*変数が登録されてる*/
                return _vars[key];
            else                           /*変数が登録されていない*/
                return 0;
        }

        /// <summary>
        /// 変数をすべてクリアします。
        /// </summary>
        public void ClearVar()
        {
            _vars = new Dictionary<string, object>();
        }
    }
}
