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
	internal abstract class MapGrammarAstNodes
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public MapGrammarAstNodes(int line, int column)
        {
            Line = line;
            Column = column;
        }
    }

    /// <summary>
    /// ルートノード
    /// </summary>
    internal class RootNode : MapGrammarAstNodes
    {
        public List<MapGrammarAstNodes> StatementList { get; set; }
        public IToken Version { get; set; }
        public EncodingContext Encoding { get; set; }
        public RootNode(int line, int column): base(line, column)
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

        public DistanceNode(int line, int column) : base(line, column) { }
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

        public Syntax1Node(int line, int column) : base(line, column)
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

        public Syntax2Node(int line, int column) : base(line, column)
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

        public Syntax3Node(int line, int column) : base(line, column)
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

        public LoadListNode(int line, int column) : base(line, column) { }
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

        public VarAssignNode(int line, int column) : base(line, column) { }
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

        public InfixExpressionNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 加算ノード
    /// </summary>
    internal class AdditionNode : InfixExpressionNode
    {
        public AdditionNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 減算ノード
    /// </summary>
    internal class SubtractionNode : InfixExpressionNode
    {
        public SubtractionNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 乗算ノード
    /// </summary>
    internal class MultiplicationNode : InfixExpressionNode
    {
        public MultiplicationNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 除算ノード
    /// </summary>
    internal class DivisionNode : InfixExpressionNode
    {
        public DivisionNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 剰余算ノード
    /// </summary>
    internal class ModuloNode : InfixExpressionNode
    {
        public ModuloNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// ユーナリ演算ノード
    /// </summary>
    internal class UnaryNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes InnerNode { get; set; }

        public UnaryNode(int line, int column) : base(line, column) { }
    }

    #region 数学関数ノード

    /// <summary>
    /// 数学関数親ノード
    /// </summary>
    internal abstract class SingleArgFunctionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Value { get; set; }

        public SingleArgFunctionNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// ABSノード
    /// </summary>
    internal class AbsNode : SingleArgFunctionNode
    {
        public AbsNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// ATAN2ノード
    /// </summary>
    internal class Atan2Node : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Y { get; set; }
        public MapGrammarAstNodes X { get; set; }

        public Atan2Node(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// CEILノード
    /// </summary>
    internal class CeilNode : SingleArgFunctionNode
    {
        public CeilNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// COSノード
    /// </summary>
    internal class CosNode : SingleArgFunctionNode
    {
        public CosNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// EXPノード
    /// </summary>
    internal class ExpNode : SingleArgFunctionNode
    {
        public ExpNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// FLOORノード
    /// </summary>
    internal class FloorNode : SingleArgFunctionNode
    {
        public FloorNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// LOGノード
    /// </summary>
    internal class LogNode : SingleArgFunctionNode
    {
        public LogNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// POWノード
    /// </summary>
    internal class PowNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes X { get; set; }
        public MapGrammarAstNodes Y { get; set; }

        public PowNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// RANDノード
    /// </summary>
    internal class RandNode : SingleArgFunctionNode
    {
        public RandNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// SINノード
    /// </summary>
    internal class SinNode : SingleArgFunctionNode
    {
        public SinNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// SQRTノード
    /// </summary>
    internal class SqrtNode : SingleArgFunctionNode
    {
        public SqrtNode(int line, int column) : base(line, column) { }
    }

    #endregion 数学関数ノード

    /// <summary>
    /// 数値ノード
    /// </summary>
    internal class NumberNode : MapGrammarAstNodes
    {
        public IToken Value { get; set; }

        public NumberNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 距離変数ノード
    /// </summary>
    internal class DistanceVariableNode : MapGrammarAstNodes
    {
        public DistanceVariableNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 文字列ノード
    /// </summary>
    internal class StringNode : MapGrammarAstNodes
    {
        public StringContext Value { get; set; }

        public StringNode(int line, int column) : base(line, column) { }
    }

    /// <summary>
    /// 変数ノード
    /// </summary>
    internal class VarNode : MapGrammarAstNodes
    {
        public string Key { get; set; }

        public VarNode(int line, int column) : base(line, column) { }
    }
    #endregion 数式 AST Nodes
}
