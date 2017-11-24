using System.Collections.Generic;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// 変数の管理クラス
    /// </summary>
    public static class Vars
    {
        public static Dictionary<string, object> VarDictionary { get; private set; }

        /// <summary>
        /// 変数を追加、もしくは上書きします。
        /// </summary>
        /// <param name="key">変数名</param>
        /// <param name="val">変数の値</param>
        public static void SetVar(string key, object val)
        {
            if (VarDictionary.ContainsKey(key))
                VarDictionary[key] = val;
            else
                VarDictionary.Add(key, val);
        }

        /// <summary>
        /// 変数を取得します。
        /// </summary>
        /// <param name="key">変数名</param>
        /// <returns>変数の値</returns>
        public static object GetVar(string key)
        {
            if (VarDictionary.ContainsKey(key))     /*変数が登録されてる*/
                return VarDictionary[key];
            else                                    /*変数が登録されていない*/
                return 0;
        }

        public static void ClearVar()
        {
            VarDictionary = new Dictionary<string, object>();
        }
    }
}
