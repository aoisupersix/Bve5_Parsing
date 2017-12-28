using System;
using Antlr4.Runtime.Misc;
using Bve5_Parsing.ScenarioGrammar.SyntaxDefinitions;


namespace Bve5_Parsing.ScenarioGrammar.AstNodes
{
    /// <summary>
    /// CSTを巡回してASTを作成するVisitorクラス
    /// </summary>
    internal class BuildAstVisitor : ScenarioGrammarParserBaseVisitor<ScenarioGrammarAstNodes>
    {
        /// <summary>
        /// ルートの巡回
        /// ステートメントの集合をノードに追加する
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>ルートASTノード</returns>
        public override ScenarioGrammarAstNodes VisitRoot([NotNull] SyntaxDefinitions.ScenarioGrammarParser.RootContext context)
        {
            RootNode node = new RootNode();
            node.Version = context.VERSION().ToString();
            if(context.encoding() != null)
            {
                node.Encoding = context.encoding().text;
            }

            //ステートメントの追加
            foreach(var state in context.statement())
            {
                ScenarioGrammarAstNodes child = base.Visit(state);
                if (child != null)
                    node.StatementList.Add(child);
            }
            return node;
        }

        #region ステートメントの巡回

        /// <summary>
        /// 路線ステートメントの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>RouteASTノード</returns>
        public override ScenarioGrammarAstNodes VisitRouteState([NotNull] SyntaxDefinitions.ScenarioGrammarParser.RouteStateContext context)
        {
            WeightStateNode node = new WeightStateNode();
            node.StateName = context.stateName.Text.ToLower();
            foreach (var weight in context.weight_path())
            {
                ScenarioGrammarAstNodes child = base.Visit(weight);
                if (child != null)
                    node.PathList.Add(child);
            }
            return node;
        }
        #endregion ステートメントの巡回

        /// <summary>
        /// 重み付けファイルパスの巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>WeightPathASTノード</returns>
        public override ScenarioGrammarAstNodes VisitWeight_path([NotNull] SyntaxDefinitions.ScenarioGrammarParser.Weight_pathContext context)
        {
            WeightPathNode node = new WeightPathNode
            {
                Path = context.path.GetText(),
                Weight = double.Parse(context.NUM().GetText())
            };
            return node;
        }

    }
}
