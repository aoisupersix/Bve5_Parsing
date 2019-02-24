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
        public IToken Start { get; set; }
        public IToken Stop { get; set; }

        public MapGrammarAstNodes(IToken start, IToken stop)
        {
            Start = start;
            Stop = stop;
        }

        public ParseError CreateNewWarning(string msg)
        {
            return new ParseError(ParseErrorLevel.Warning, Start.Line, Start.Column, msg);
        }

        public ParseError CreateNewError(string msg)
        {
            return new ParseError(ParseErrorLevel.Error, Start.Line, Start.Column, msg);
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
        public RootNode(IToken start, IToken stop): base(start, stop)
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

        public DistanceNode(IToken start, IToken stop): base(start, stop) { }
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

        public Syntax1Node(IToken start, IToken stop): base(start, stop)
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

        public Syntax2Node(IToken start, IToken stop): base(start, stop)
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

        public Syntax3Node(IToken start, IToken stop): base(start, stop)
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

        public LoadListNode(IToken start, IToken stop): base(start, stop) { }
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

        public VarAssignNode(IToken start, IToken stop): base(start, stop) { }
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

        public InfixExpressionNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 加算ノード
    /// </summary>
    internal class AdditionNode : InfixExpressionNode
    {
        public AdditionNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 減算ノード
    /// </summary>
    internal class SubtractionNode : InfixExpressionNode
    {
        public SubtractionNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 乗算ノード
    /// </summary>
    internal class MultiplicationNode : InfixExpressionNode
    {
        public MultiplicationNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 除算ノード
    /// </summary>
    internal class DivisionNode : InfixExpressionNode
    {
        public DivisionNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 剰余算ノード
    /// </summary>
    internal class ModuloNode : InfixExpressionNode
    {
        public ModuloNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// ユーナリ演算ノード
    /// </summary>
    internal class UnaryNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes InnerNode { get; set; }

        public UnaryNode(IToken start, IToken stop): base(start, stop) { }
    }

    #region 数学関数ノード

    /// <summary>
    /// 数学関数親ノード
    /// </summary>
    internal abstract class SingleArgFunctionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Value { get; set; }

        public SingleArgFunctionNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// ABSノード
    /// </summary>
    internal class AbsNode : SingleArgFunctionNode
    {
        public AbsNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// ATAN2ノード
    /// </summary>
    internal class Atan2Node : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Y { get; set; }
        public MapGrammarAstNodes X { get; set; }

        public Atan2Node(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// CEILノード
    /// </summary>
    internal class CeilNode : SingleArgFunctionNode
    {
        public CeilNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// COSノード
    /// </summary>
    internal class CosNode : SingleArgFunctionNode
    {
        public CosNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// EXPノード
    /// </summary>
    internal class ExpNode : SingleArgFunctionNode
    {
        public ExpNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// FLOORノード
    /// </summary>
    internal class FloorNode : SingleArgFunctionNode
    {
        public FloorNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// LOGノード
    /// </summary>
    internal class LogNode : SingleArgFunctionNode
    {
        public LogNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// POWノード
    /// </summary>
    internal class PowNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes X { get; set; }
        public MapGrammarAstNodes Y { get; set; }

        public PowNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// RANDノード
    /// </summary>
    internal class RandNode : SingleArgFunctionNode
    {
        public RandNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// SINノード
    /// </summary>
    internal class SinNode : SingleArgFunctionNode
    {
        public SinNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// SQRTノード
    /// </summary>
    internal class SqrtNode : SingleArgFunctionNode
    {
        public SqrtNode(IToken start, IToken stop): base(start, stop) { }
    }

    #endregion 数学関数ノード

    /// <summary>
    /// 数値ノード
    /// </summary>
    internal class NumberNode : MapGrammarAstNodes
    {
        public IToken Value { get; set; }

        public NumberNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 距離変数ノード
    /// </summary>
    internal class DistanceVariableNode : MapGrammarAstNodes
    {
        public DistanceVariableNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 文字列ノード
    /// </summary>
    internal class StringNode : MapGrammarAstNodes
    {
        public StringContext Value { get; set; }

        public StringNode(IToken start, IToken stop): base(start, stop) { }
    }

    /// <summary>
    /// 変数ノード
    /// </summary>
    internal class VarNode : MapGrammarAstNodes
    {
        public string Key { get; set; }

        public VarNode(IToken start, IToken stop) : base(start, stop) { }

    }
    #endregion 数式 AST Nodes
}
