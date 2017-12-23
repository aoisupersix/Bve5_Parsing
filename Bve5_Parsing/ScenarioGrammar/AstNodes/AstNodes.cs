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
        public string Version { get; set; }
        public string Encoding { get; set; }
        public List<ScenarioGrammarAstNodes> StatementList { get; set; }

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

    /// <summary>
    /// 重み付けステートメント
    /// </summary>
    internal class WeightStateNode : StatementNode
    {
        public List<WeightPath> PathList { get; set; }

        public WeightStateNode()
        {
            PathList = new List<WeightPath>();
        }
    }

    /// <summary>
    /// テキストステートメント
    /// </summary>
    internal class TextStateNode : StatementNode
    {
        public string Text { get; set; }
    }

    /// <summary>
    /// 重み付けパス
    /// </summary>
    internal class WeightPath : ScenarioGrammarAstNodes
    {
        public string Path { get; set; }
        public double Weight { get; set; }
    }
}
