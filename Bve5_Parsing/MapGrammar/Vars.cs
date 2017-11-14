using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// マップファイル内で使用する変数を管理するクラス
    /// </summary>
    public sealed class Vars
    {
        private static Vars _varsInstance = new Vars();
        private Dictionary<string, double> vars;

        public static Vars GetInstance()
        {
            return _varsInstance;
        }

        private Vars()
        {
            vars = new Dictionary<string, double>();
        }

        /// <summary>
        /// 新たな変数を設定する
        /// </summary>
        /// <param name="name">変数名</param>
        /// <param name="val">変数の値</param>
        public void SetVar(string name, double val)
        {
            if (vars.ContainsKey(name))
                vars[name] = val;
            else
                vars.Add(name, val);
        }

        /// <summary>
        /// 変数の値を返す。変数が存在しない場合は0を返す
        /// </summary>
        /// <param name="name">変数名</param>
        /// <returns>変数の値</returns>
        public double GetVar(string name)
        {
            if (vars.ContainsKey(name))
                return vars[name];
            else
                return 0;
        }

        /// <summary>
        /// 保持している変数の削除を行う
        /// </summary>
        public void Clear()
        {
            vars.Clear();
        }
    }
}
