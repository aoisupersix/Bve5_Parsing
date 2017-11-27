using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /**
     * AstNodeの定義クラス
     */

    /// <summary>
    /// AST親クラス
    /// </summary>
	internal abstract class MapGrammarAstNodes { }

    /// <summary>
    /// ルートノード
    /// </summary>
    internal class RootNode : MapGrammarAstNodes
    {
        public List<MapGrammarAstNodes> StatementList { get; set; }
        public RootNode()
        {
            StatementList = new List<MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// 距離程ノード
    /// </summary>
    internal class DistanceNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Value { get; set; }
    }

    /// <summary>
    /// ステートメントノード1 MapElement.Function(Args)
    /// </summary>
    internal class Syntax1 : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax1()
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメントノード2 MapElement[key].Function(Args)
    /// </summary>
    internal class Syntax2 : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public string KeyName { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax2()
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメントノード3 MapElement[key].MapElement.Function(Args)
    /// </summary>
    internal class Syntax3 : MapGrammarAstNodes
    {
        public string[] MapElementNames { get; set; }
        public string KeyName { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax3()
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
            MapElementNames = new string[2];
        }
    }

    #region VarAssign AST Nodes

    /// <summary>
    /// 変数宣言AstNode
    /// </summary>
    internal class VarAssignNode : MapGrammarAstNodes
    {
        public string VarName { get; set; }
        public MapGrammarAstNodes Value { get; set; }
    }
    #endregion VarAssign AST Nodes

    #region Expression AST Nodes
    internal abstract class InfixExpressionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Left { get; set; }
        public MapGrammarAstNodes Right { get; set; }
    }

    internal class AdditionNode : InfixExpressionNode { }

    internal class SubtractionNode : InfixExpressionNode { }

    internal class MultiplicationNode : InfixExpressionNode { }

    internal class DivisionNode : InfixExpressionNode { }

    internal class ModuloNode : InfixExpressionNode { }

    internal class NegateNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes InnerNode { get; set; }
    }

    internal class NumberNode : MapGrammarAstNodes
    {
        public double Value { get; set; }
    }

    internal class StringNode : MapGrammarAstNodes
    {
        public string Value { get; set; }
    }

    internal class VarNode : MapGrammarAstNodes
    {
        public string Key { get; set; }
    }
    #endregion Expression AST Nodes
}
