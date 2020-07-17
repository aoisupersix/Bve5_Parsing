using System;
using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bve5_Parsing.MapGrammar.AstNodes
{
    /// <summary>
    /// マップ構文ASTの親となるノード。
    /// 一つのマップファイルに含まれる全構文を子に持ちます。
    /// </summary>
    public class RootNode : MapGrammarAstNodes
    {
        /// <summary>
        /// バージョン情報
        /// マップファイルのヘッダはパースされないので、ASTに変換した後に手動で代入します。
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// ファイルのエンコーディング情報
        /// マップファイルのヘッダはパースされないので、ASTに変換した後に手動で代入します。
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// ステートメントASTノードの内部実装
        /// </summary>
        protected List<MapGrammarAstNodes> _statementList = new List<MapGrammarAstNodes>();

        /// <summary>
        /// ステートメントASTノード
        /// </summary>
        public ReadOnlyCollection<MapGrammarAstNodes> StatementList => _statementList.AsReadOnly();

        public RootNode(IToken start, IToken stop) : base(start, stop) { }

        /// <summary>
        /// ステートメントを追加します。
        /// </summary>
        /// <param name="node"></param>
        public void AddStatementNode(MapGrammarAstNodes node)
        {
            _statementList.Add(node);
        }
    }

    /// <summary>
    /// 距離程ノード
    /// </summary>
    public class DistanceNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Value { get; set; }

        public DistanceNode(IToken start, IToken stop) : base(start, stop) { }
    }

    #region SyntaxNode Partial

    /// <summary>
    /// Repeater.Beginの手動対応
    /// 可変長のstructureKeyへ対応する
    /// </summary>
    public partial class RepeaterBeginNode
    {
        protected override Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            RepeaterBeginStatement repeaterBeginStatement = base.SetArgument(evaluator, statement) as RepeaterBeginStatement;

            foreach (var strKey in StructureKeys)
            {
                repeaterBeginStatement.AddStructureKey(strKey == null ? string.Empty : Convert.ToString(evaluator.Visit(strKey)));
            }

            return repeaterBeginStatement;
        }
    }

    /// <summary>
    /// Repeater.Begin0の手動対応
    /// 可変長のstructureKeyへ対応する
    /// </summary>
    public partial class RepeaterBegin0Node
    {
        protected override Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            RepeaterBegin0Statement repeaterBegin0Statement = base.SetArgument(evaluator, statement) as RepeaterBegin0Statement;

            foreach (var strKey in StructureKeys)
            {
                repeaterBegin0Statement.AddStructureKey(strKey == null ? string.Empty : Convert.ToString(evaluator.Visit(strKey)));
            }

            return repeaterBegin0Statement;
        }
    }

    /// <summary>
    /// Section.Beginの手動対応
    /// 可変長のsignalIndexへ対応する
    /// </summary>
    public partial class SectionBeginNode
    {
        protected override Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            SectionBeginStatement sectionBeginStatement = base.SetArgument(evaluator, statement) as SectionBeginStatement;

            foreach (var sigIdx in Signals)
            {
                if (sigIdx != null)
                {
                    object value = evaluator.Visit(sigIdx);
                    try
                    {
                        sectionBeginStatement.AddSignal(Convert.ToDouble(value));
                    }
                    catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException)
                    {
                        evaluator.ErrorListener.AddNewError(ParseMessageType.InvalidArgument, null, Start, value);
                        sectionBeginStatement.AddSignal(null);
                    }
                }
                else
                {
                    sectionBeginStatement.AddSignal(null);
                }
            }

            return sectionBeginStatement;
        }
    }

    /// <summary>
    /// Section.Setspeedlimitの手動対応
    /// 可変長の速度制限へ対応する
    /// </summary>
    public partial class SectionSetspeedlimitNode
    {
        protected override Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            SectionSetspeedlimitStatement sectionSetspeedlimitStatement = base.SetArgument(evaluator, statement) as SectionSetspeedlimitStatement;

            foreach (var spdLmt in Vs)
            {
                if (spdLmt != null)
                {
                    object value = evaluator.Visit(spdLmt);
                    try
                    {
                        sectionSetspeedlimitStatement.AddV(Convert.ToDouble(value));
                    }
                    catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException)
                    {
                        evaluator.ErrorListener.AddNewError(ParseMessageType.InvalidArgument, null, Start, value);
                        sectionSetspeedlimitStatement.AddV(null);
                    }
                }
                else
                {
                    sectionSetspeedlimitStatement.AddV(null);
                }
            }

            return sectionSetspeedlimitStatement;
        }
    }

    /// <summary>
    /// Pretrain.Passへの手動対応
    /// </summary>
    public partial class PretrainPassNode
    {
        /// <summary>
        /// Pretrain.Passの引数TimeとSecondは型によって振り分ける
        /// </summary>
        /// <param name="evaluator"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        protected override Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            var pretrainPassStatement = statement as PretrainPassStatement;

            if (Time != null)
            {
                var arg = evaluator.Visit(Time); // 必ずTimeに引数が入っている

                if (arg is string)
                {
                    // TODO: Validate
                    double tmp;
                    if (double.TryParse((string)arg, out tmp))
                    {
                        pretrainPassStatement.Second = tmp;
                    }
                    else
                    {
                        pretrainPassStatement.Time = (string)arg;
                    }
                }
                else
                    pretrainPassStatement.Second = Convert.ToDouble(arg);
            }

            return pretrainPassStatement;
        }
    }

    /// <summary>
    /// Train.Enableへの手動対応
    /// </summary>
    public partial class TrainEnableNode
    {
        /// <summary>
        /// Train.Enableの引数TimeとSecondは型によって振り分ける
        /// </summary>
        /// <param name="evaluator"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        protected override Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            var trainEnableStatement = statement as TrainEnableStatement;

            if (Time != null)
            {
                var arg = evaluator.Visit(Time); // 必ずTimeに引数が入っている

                if (arg is string)
                {
                    // TODO: Validate
                    double tmp;
                    if (double.TryParse((string)arg, out tmp))
                    {
                        trainEnableStatement.Second = tmp;
                    }
                    else
                    {
                        trainEnableStatement.Time = (string)arg;
                    }
                }
                else
                    trainEnableStatement.Second = Convert.ToDouble(arg);
            }

            return trainEnableStatement;
        }
    }
    #endregion

    #region 変数宣言 AST Nodes

    /// <summary>
    /// 変数宣言ノード
    /// </summary>
    public class VarAssignNode : MapGrammarAstNodes
    {
        public string VarName { get; set; }
        public MapGrammarAstNodes Value { get; set; }

        public VarAssignNode(IToken start, IToken stop) : base(start, stop) { }
    }
    #endregion 変数宣言 AST Nodes

    #region 数式 AST Nodes

    /// <summary>
    /// 二項演算数式ノード
    /// </summary>
    public abstract class InfixExpressionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Left { get; set; }
        public MapGrammarAstNodes Right { get; set; }

        public InfixExpressionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 加算ノード
    /// </summary>
    public class AdditionNode : InfixExpressionNode
    {
        public AdditionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 減算ノード
    /// </summary>
    public class SubtractionNode : InfixExpressionNode
    {
        public SubtractionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 乗算ノード
    /// </summary>
    public class MultiplicationNode : InfixExpressionNode
    {
        public MultiplicationNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 除算ノード
    /// </summary>
    public class DivisionNode : InfixExpressionNode
    {
        public DivisionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 剰余算ノード
    /// </summary>
    public class ModuloNode : InfixExpressionNode
    {
        public ModuloNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// ユーナリ演算ノード
    /// </summary>
    public class UnaryNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes InnerNode { get; set; }

        public UnaryNode(IToken start, IToken stop) : base(start, stop) { }
    }

    #region 数学関数ノード

    /// <summary>
    /// 数学関数親ノード
    /// </summary>
    public abstract class SingleArgFunctionNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Value { get; set; }

        public SingleArgFunctionNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// ABSノード
    /// </summary>
    public class AbsNode : SingleArgFunctionNode
    {
        public AbsNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// ATAN2ノード
    /// </summary>
    public class Atan2Node : MapGrammarAstNodes
    {
        public MapGrammarAstNodes Y { get; set; }
        public MapGrammarAstNodes X { get; set; }

        public Atan2Node(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// CEILノード
    /// </summary>
    public class CeilNode : SingleArgFunctionNode
    {
        public CeilNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// COSノード
    /// </summary>
    public class CosNode : SingleArgFunctionNode
    {
        public CosNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// EXPノード
    /// </summary>
    public class ExpNode : SingleArgFunctionNode
    {
        public ExpNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// FLOORノード
    /// </summary>
    public class FloorNode : SingleArgFunctionNode
    {
        public FloorNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// LOGノード
    /// </summary>
    public class LogNode : SingleArgFunctionNode
    {
        public LogNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// POWノード
    /// </summary>
    public class PowNode : MapGrammarAstNodes
    {
        public MapGrammarAstNodes X { get; set; }
        public MapGrammarAstNodes Y { get; set; }

        public PowNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// RANDノード
    /// </summary>
    public class RandNode : SingleArgFunctionNode
    {
        public RandNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// SINノード
    /// </summary>
    public class SinNode : SingleArgFunctionNode
    {
        public SinNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// SQRTノード
    /// </summary>
    public class SqrtNode : SingleArgFunctionNode
    {
        public SqrtNode(IToken start, IToken stop) : base(start, stop) { }
    }

    #endregion 数学関数ノード

    /// <summary>
    /// 数値ノード
    /// </summary>
    public class NumberNode : MapGrammarAstNodes
    {
        public IToken Value { get; set; }

        public NumberNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 距離変数ノード
    /// </summary>
    public class DistanceVariableNode : MapGrammarAstNodes
    {
        public DistanceVariableNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 文字列ノード
    /// </summary>
    public class StringNode : MapGrammarAstNodes
    {
        public string Value { get; set; }

        public StringNode(IToken start, IToken stop) : base(start, stop) { }
    }

    /// <summary>
    /// 変数ノード
    /// </summary>
    public class VarNode : MapGrammarAstNodes
    {
        public string Key { get; set; }

        public VarNode(IToken start, IToken stop) : base(start, stop) { }

    }
    #endregion 数式 AST Nodes

    #region 未使用（あとで消す）
    /// <summary>
    /// ステートメントノード1 MapElement.Function(Args)
    /// </summary>
    public class Syntax1Node : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax1Node(IToken start, IToken stop) : base(start, stop)
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメントノード2 MapElement[key].Function(Args)
    /// </summary>
    public class Syntax2Node : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public MapGrammarAstNodes Key { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax2Node(IToken start, IToken stop) : base(start, stop)
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
        }
    }

    /// <summary>
    /// ステートメントノード3 MapElement[key].MapElement.Function(Args)
    /// </summary>
    public class Syntax3Node : MapGrammarAstNodes
    {
        // TODO: タプルの方がいい？
        public string[] MapElementNames { get; set; }
        public MapGrammarAstNodes Key { get; set; }
        public string FunctionName { get; set; }
        public Dictionary<string, MapGrammarAstNodes> Arguments { get; set; }

        public Syntax3Node(IToken start, IToken stop) : base(start, stop)
        {
            Arguments = new Dictionary<string, MapGrammarAstNodes>();
            MapElementNames = new string[2];
        }
    }

    /// <summary>
    /// リストファイルロードノード
    /// </summary>
    public class LoadListNode : MapGrammarAstNodes
    {
        public string MapElementName { get; set; }
        public string Path { get; set; }

        public LoadListNode(IToken start, IToken stop) : base(start, stop) { }
    }
    #endregion
}
