using System;
using Bve5_Parsing.ScenarioGrammar.AstNodes;

namespace Bve5_Parsing.ScenarioGrammar
{
    /// <summary>
    /// ASTノードの評価クラス定義
    /// </summary>
    /// <typeparam name="T">ASTノードの種類</typeparam>
    internal abstract class AstVisitor<T>
    {
        public abstract T Visit(RootNode node);
        public abstract T Visit(WeightStateNode node);
        public abstract T Visit(TextStateNode node);
        public abstract T Visit(WeightPathNode node);

        /// <summary>
        /// 引数に与えられたASTノードを評価します。
        /// </summary>
        /// <param name="node">評価するASTノード</param>
        /// <returns>評価結果</returns>
        public T Visit(ScenarioGrammarAstNodes node)
        {
            return Visit((dynamic)node);
        }
    }
}
