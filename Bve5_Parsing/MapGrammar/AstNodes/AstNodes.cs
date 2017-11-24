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

    #region VarAssign AST Nodes
    //TODO あとで消す
    internal class VarAssignsNode : MapGrammarAstNodes
    {
        public List<MapGrammarAstNodes> VarAssigns { get; set; }

        internal VarAssignsNode()
        {
            VarAssigns = new List<MapGrammarAstNodes>();
        }
    }

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
