using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bve5_Parsing.ScenarioGrammar.AstNodes
{
    /**
     * ScenarioGrammarのAstNode定義
     */

    /// <summary>
    /// AST親クラス
    /// </summary>
    internal abstract class ScenarioGrammarAstNodes { }

    /// <summary>
    /// ルートノード
    /// </summary>
    internal class RootNode : ScenarioGrammarAstNodes
    {
        public List<ScenarioGrammarAstNodes> StatementList { get; set; }
        public string Version { get; set; }
        public string Encoding { get; set; }
        public RootNode()
        {
            StatementList = new List<ScenarioGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメント親ノード
    /// </summary>
    internal abstract class StatementNode : ScenarioGrammarAstNodes
    {
        public string StateName { get; set; }
    }
}
