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
                node.Encoding = Visit(context.encoding());
            }
            return node;
        }

        /// <summary>
        /// エンコーディング指定の巡回
        /// </summary>
        /// <param name="context">構文解析の文脈データ</param>
        /// <returns>エンコーディング指定ASTノード</returns>
        public override ScenarioGrammarAstNodes VisitEncoding([NotNull] ScenarioGrammarParser.EncodingContext context)
        {
            return new EncodingNode { Text = "" };
        }
    }
}
