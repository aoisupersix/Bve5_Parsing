using System.Collections.Generic;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless
{
    public class MapData
    {
        /// <summary>
        /// マップファイルのバージョン
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// マップファイルのエンコーディング
        /// </summary>
        public string Encoding { get; set; }
    }
}
