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
        public override ScenarioGrammarAstNodes VisitRoot([NotNull] ScenarioGrammarParser.RootContext context)
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
    }
}
