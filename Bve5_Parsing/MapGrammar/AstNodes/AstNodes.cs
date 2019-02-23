using Antlr4.Runtime;
using System.Collections.Generic;
using static Bve5_Parsing.MapGrammar.SyntaxDefinitions.MapGrammarParser;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /**
     * AstNodeの定義
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
        public IToken Version { get; set; }
        public EncodingContext Encoding { get; set; }
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

    #region ステートメント AST Nodes

    /// <summary>
    /// ステートメントノード1 MapElement.Function(Args)
    /// </summary>
    internal class Syntax1Node : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax1Node()
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメントノード2 MapElement[key].Function(Args)
    /// </summary>
    internal class Syntax2Node : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public MapGrammarAstNodes Key { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax2Node()
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメントノード3 MapElement[key].MapElement.Function(Args)
    /// </summary>
    internal class Syntax3Node : MapGrammarAstNodes
    {
        // TODO: タプルの方がいい？
        public string[] MapElementNames { get; set; }
        public MapGrammarAstNodes Key { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax3Node()
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
            MapElementNames = new string[2];
        }
    }

    /// <summary>
    /// リストファイルロードノード
    /// </summary>
    internal class LoadListNode : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public StringContext Path { get; set; }
    }

    #endregion ステートメント AST Nodes


    #region 変数宣言 AST Nodes

    /// <summary>
    /// 変数宣言ノード
    /// </summary>
    internal class VarAssignNode : MapGrammarAstNodes
    {
        public string VarName { get; set; }
        public MapGrammarAstNodes Value { get; set; }
    }
    #endregion 変数宣言 AST Nodes

    #region 数式 AST Nodes

    /// <summary>
    /// 二項演算数式ノード
    /// </summary>
    internal abstract class InfixExpressionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Left { get; set; }
        public MapGrammarAstNodes Right { get; set; }
    }

    /// <summary>
    /// 加算ノード
    /// </summary>
    internal class AdditionNode : InfixExpressionNode { }

    /// <summary>
    /// 減算ノード
    /// </summary>
    internal class SubtractionNode : InfixExpressionNode { }

    /// <summary>
    /// 乗算ノード
    /// </summary>
    internal class MultiplicationNode : InfixExpressionNode { }

    /// <summary>
    /// 除算ノード
    /// </summary>
    internal class DivisionNode : InfixExpressionNode { }

    /// <summary>
    /// 剰余算ノード
    /// </summary>
    internal class ModuloNode : InfixExpressionNode { }

    /// <summary>
    /// ユーナリ演算ノード
    /// </summary>
    internal class UnaryNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes InnerNode { get; set; }
    }

    #region 数学関数ノード

    /// <summary>
    /// 数学関数親ノード
    /// </summary>
    internal abstract class SingleArgFunctionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Value { get; set; }
    }

    /// <summary>
    /// ABSノード
    /// </summary>
    internal class AbsNode : SingleArgFunctionNode { }

    /// <summary>
    /// ATAN2ノード
    /// </summary>
    internal class Atan2Node : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Y { get; set; }
        public MapGrammarAstNodes X { get; set; }
    }

    /// <summary>
    /// CEILノード
    /// </summary>
    internal class CeilNode : SingleArgFunctionNode { }

    /// <summary>
    /// COSノード
    /// </summary>
    internal class CosNode : SingleArgFunctionNode { }

    /// <summary>
    /// EXPノード
    /// </summary>
    internal class ExpNode : SingleArgFunctionNode { }

    /// <summary>
    /// FLOORノード
    /// </summary>
    internal class FloorNode : SingleArgFunctionNode { }

    /// <summary>
    /// LOGノード
    /// </summary>
    internal class LogNode : SingleArgFunctionNode { }

    /// <summary>
    /// POWノード
    /// </summary>
    internal class PowNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes X { get; set; }
        public MapGrammarAstNodes Y { get; set; }
    }

    /// <summary>
    /// RANDノード
    /// </summary>
    internal class RandNode : SingleArgFunctionNode { }

    /// <summary>
    /// SINノード
    /// </summary>
    internal class SinNode : SingleArgFunctionNode { }

    /// <summary>
    /// SQRTノード
    /// </summary>
    internal class SqrtNode : SingleArgFunctionNode { }

    #endregion 数学関数ノード

    /// <summary>
    /// 数値ノード
    /// </summary>
    internal class NumberNode : MapGrammarAstNodes
    {
        public IToken Value { get; set; }
    }

    /// <summary>
    /// 距離変数ノード
    /// </summary>
    internal class DistanceVariableNode : MapGrammarAstNodes{ }

    /// <summary>
    /// 文字列ノード
    /// </summary>
    internal class StringNode : MapGrammarAstNodes
    {
        public StringContext Value { get; set; }
    }

    /// <summary>
    /// 変数ノード
    /// </summary>
    internal class VarNode : MapGrammarAstNodes
    {
        public string Key { get; set; }
    }
    #endregion 数式 AST Nodes
}
