using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Bve5_Parsing.MapGrammar.Attributes;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Bve5_Parsing.MapGrammar.AstNodes
{

    /// <summary>
    /// 構文ASTノードのベースとなるノード
    /// </summary>
    public abstract class SyntaxNode : MapGrammarAstNodes
    {
        /// <summary>
        /// マップ要素名
        /// マップ要素名は全ての構文に存在します。
        /// </summary>
        public abstract MapElementName ElementName { get; }

        /// <summary>
        /// マップ関数名
        /// Includeディレクティブのみ関数名が存在しません。
        /// </summary>
        public virtual MapFunctionName? FunctionName => null;

        /// <summary>
        /// マップ副要素名
        /// もし構文に副要素が存在しない場合はnullを返します。
        /// </summary>
        public virtual MapSubElementName? SubElementName => null;

        /// <summary>
        /// キー
        /// もし構文にキーが存在しない場合はnullを返します。
        /// </summary>
        public virtual MapGrammarAstNodes Key { get; set; }

        /// <summary>
        /// キーを指定する構文か？
        /// </summary>
        public abstract bool HasKey { get; }

        /// <summary>
        /// 副要素を指定する構文か？
        /// </summary>
        public abstract bool HasSubElement { get; }

        public SyntaxNode(IToken start, IToken stop) : base(start, stop) { }

        /// <summary>
        /// アトリビュートからASTノードの引数を取得します。
        /// </summary>
        /// <returns></returns>
        protected internal IEnumerable<PropertyInfo> GetAllArguments()
        {
            return GetType().GetProperties()
                .Select(p => new
                {
                    Property = p,
                    Attr = p.GetCustomAttributes(typeof(ArgumentAttribute), true)
                        .Select(a => a as ArgumentAttribute)
                        .Where(a => a != null)
                })
                .Where(p => p.Attr.Any())
                .Select(p => p.Property)
                ;
        }

        /// <summary>
        /// アトリビュートからASTノードの省略不可能な引数を取得します。
        /// </summary>
        /// <returns></returns>
        protected internal IEnumerable<PropertyInfo> GetNonOptionalArguments()
        {
            return GetType().GetProperties()
                .Select(p => new
                {
                    Property = p,
                    Attr = p.GetCustomAttributes(typeof(ArgumentAttribute), true)
                        .Select(a => a as ArgumentAttribute)
                        .Where(a => a != null)
                })
                .Where(p => p.Attr.Any() && false == p.Attr.Single().Optional)
                .Select(p => p.Property)
                ;
        }

        /// <summary>
        /// アトリビュートからASTノードの省略可能引数を取得します。
        /// </summary>
        /// <returns></returns>
        protected internal IEnumerable<PropertyInfo> GetOptionalArguments()
        {
            return GetType().GetProperties()
                .Select(p => new
                {
                    Property = p,
                    Attr = p.GetCustomAttributes(typeof(ArgumentAttribute), true)
                        .Select(a => a as ArgumentAttribute)
                        .Where(a => a != null)
                })
                .Where(p => p.Attr.Any() && p.Attr.Single().Optional)
                .Select(p => p.Property)
                ;
        }

        /// <summary>
        /// メタ情報から対応するAstを生成して返す便利メソッド。
        /// MapGrammarParserの定義ファイル更新時に使えなくなる可能性が高いため、更新時は注意して下さい。
        /// </summary>
        /// <param name="visitor"></param>
        /// <param name="ctx"></param>
        /// <param name="elementName"></param>
        /// <param name="funcName"></param>
        /// <param name="element2Name"></param>
        /// <returns></returns>
        protected internal static SyntaxNode CreateSyntaxAstNode(AbstractParseTreeVisitor<MapGrammarAstNodes> visitor, ParserRuleContext ctx, MapElementName elementName, string funcName, string element2Name = null)
        {
            // 関数名は必ず2文字以上あるので
            if (funcName.Length < 2)
                throw new ArgumentOutOfRangeException("関数名が短すぎます。");

            // ASTのインスタンス取得
            var astClassName = elementName.GetStringValue() + char.ToUpper(funcName[0]) + funcName.Substring(1).ToLower() + "Node";

            if (element2Name != null)
            {
                var ele2 = element2Name.Length <= 1 ? element2Name.ToUpper() : char.ToUpper(element2Name[0]) + element2Name.Substring(1).ToLower();
                astClassName = elementName.GetStringValue() + ele2 + char.ToUpper(funcName[0]) + funcName.Substring(1).ToLower() + "Node";
            }
            var astClassType = Type.GetType(typeof(MapGrammarAstNodes).Namespace + "." + astClassName);

            if (astClassType == null)
                throw new NotSupportedException("対応するAstNodeの取得に失敗しました。");

            var instanceArg = new object[] { ctx.Start, ctx.Stop };
            var node = Activator.CreateInstance(astClassType, instanceArg) as SyntaxNode;

            // キー
            if (node.HasKey)
            {
                var key = ctx.GetType().GetField("key").GetValue(ctx) as IParseTree;
                node.GetType().GetProperty("Key").SetValue(node, visitor.Visit(key), null);
            }

            // 引数の取得
            foreach (var arg in node.GetNonOptionalArguments())
            {
                var argCtxInfo = ctx.GetType().GetField(arg.Name.ToLower());
                var argCtx = argCtxInfo?.GetValue(ctx);
                if (argCtx is IParseTree)
                {
                    arg.SetValue(node, visitor.Visit(argCtx as IParseTree), null);
                    continue;
                }

                // GradientやLegacyに関しては特別対応
                // Gradient -> GradientArgs
                // Start -> StartArgs など
                var argGCtxInfo = ctx.GetType().GetField(arg.Name.ToLower() + "Args");
                var argGCtx = argGCtxInfo?.GetValue(ctx);
                if (argGCtx != null)
                {
                    arg.SetValue(node, visitor.Visit(argGCtx as IParseTree), null);
                    continue;
                }

                throw new NotSupportedException($"引数：{arg.Name}に対応するContextの取得に失敗しました。");
            }

            // 省略可能引数の取得
            foreach (var arg in node.GetOptionalArguments())
            {
                var argCtxInfo = ctx.GetType().GetField(arg.Name.ToLower());
                var argCtx = argCtxInfo?.GetValue(ctx);
                if (argCtx != null)
                    arg.SetValue(node, visitor.Visit(argCtx as IParseTree), null);
                else
                {
                    // "引数名" + Eのコンテキスト名に対応させる
                    var argECtxInfo = ctx.GetType().GetField(arg.Name.ToLower() + "E");
                    var argECtx = argECtxInfo?.GetValue(ctx);
                    if (argECtx != null)
                        arg.SetValue(node, visitor.Visit(argECtx as IParseTree), null);

                    // Gradient -> GradientArgs
                    var argGCtxInfo = ctx.GetType().GetField(arg.Name.ToLower() + "Args");
                    var argGCtx = argGCtxInfo?.GetValue(ctx);
                    if (argGCtx != null)
                        arg.SetValue(node, visitor.Visit(argGCtx as IParseTree), null);
                }
            }

            return node;
        }
        /// <summary>
        /// Astから引数値を取得し、Statementにセットします。
        /// 引数のセット処理をカスタマイズする必要がある場合は、各構文のAstからOverrideしてください。
        /// </summary>
        /// <param name="evaluator"></param>
        /// <param name="statement"></param>
        /// <returns></returns>
        protected virtual Statement SetArgument(EvaluateMapGrammarVisitor evaluator, Statement statement)
        {
            var args = statement.GetArgumentProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public).Join(
                GetAllArguments(),
                state => state.Name,
                ast => ast.Name,
                (state, ast) => new { Statement = state, Ast = ast }
                );

            foreach (var arg in args)
            {
                var argNode = arg.Ast.GetValue(this, null) as MapGrammarAstNodes;
                if (argNode == null)
                    continue;

                var argValue = evaluator.Visit(argNode);
                var argType = Nullable.GetUnderlyingType(arg.Statement.PropertyType) ?? arg.Statement.PropertyType;
                try
                {
                    if (argValue != null)
                    {
                        var convArg = Convert.ChangeType(argValue, argType);
                        arg.Statement.SetValue(statement, convArg, null);
                    }
                }
                catch (Exception e) when (e is InvalidCastException || e is FormatException || e is OverflowException || e is ArgumentNullException)
                {
                    evaluator.ErrorListener.AddNewError(ParseMessageType.InvalidArgument, null, Start, argValue);
                }
            }

            return statement;
        }

        /// <summary>
        /// ASTノードのメタ情報からStatementを生成して返します。
        /// </summary>
        /// <param name="evaluator"></param>
        /// <returns></returns>
        public Statement CreateStatement(EvaluateMapGrammarVisitor evaluator)
        {
            var typeName = $"{typeof(Statement).Namespace}.{GetType().Name.Replace("Node", "")}Statement";
            var type = Type.GetType(typeName);
            var statement = Activator.CreateInstance(type) as Statement;
            statement.Distance = evaluator.NowDistance;

            if (HasKey)
            {
                var key = GetType().GetProperty("Key").GetValue(this, null) as MapGrammarAstNodes;
                if (key != null)
                {
                    var tmp = evaluator.Visit(key);
                    if (tmp != null)
                    {
                        statement.GetType().GetProperty("Key").SetValue(statement, Convert.ToString(tmp), null);
                    }
                }
            }

            return SetArgument(evaluator, statement);
        }
    }
}
