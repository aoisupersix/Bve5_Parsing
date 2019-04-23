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

    internal class EvaluateScenarioGrammarVisitor : AstVisitor<object>
    {
        /// <summary>
        /// 評価結果
        /// </summary>
        private ScenarioData evaluateData;

        /// <summary>
        /// ルートノードの評価
        /// </summary>
        /// <param name="node">ルートノード</param>
        /// <returns>解析結果のScenarioData</returns>
        public override object Visit(RootNode node)
        {
            evaluateData = new ScenarioData
            {
                Version = node.Version,
                Encoding = node.Encoding
            };

            //ステートメントの巡回(出力は各ステートメントごとに行う)
            foreach (var statement in node.StatementList)
            {
                if (statement != null)
                    Visit(statement);
            }

            return evaluateData;
        }

        /// <summary>
        /// 重み付けステートメントノードの評価
        /// </summary>
        /// <param name="node">重み付けステートメントノード</param>
        /// <returns>戻り値なし</returns>
        public override object Visit(WeightStateNode node)
        {
            switch (node.StateName)
            {
                case "route":
                    foreach (var path in node.PathList)
                        evaluateData.AddRoute((FilePath)Visit(path));
                    break;
                case "vehicle":
                    foreach (var path in node.PathList)
                        evaluateData.AddVehicle((FilePath)Visit(path));
                    break;
            }

            return null;
        }

        /// <summary>
        /// テキストステートメントノードの評価
        /// </summary>
        /// <param name="node">テキストステートメントノード</param>
        /// <returns>戻り値なし</returns>
        public override object Visit(TextStateNode node)
        {
            switch (node.StateName)
            {
                case "image":
                    evaluateData.Image = node.Text;
                    break;
                case "title":
                    evaluateData.Title = node.Text;
                    break;
                case "routetitle":
                    evaluateData.RouteTitle = node.Text;
                    break;
                case "vehicletitle":
                    evaluateData.VehicleTitle = node.Text;
                    break;
                case "author":
                    evaluateData.Author = node.Text;
                    break;
                case "comment":
                    evaluateData.Comment = node.Text;
                    break;
            }

            return null;
        }

        /// <summary>
        /// 重み付けファイルパスノードの評価
        /// </summary>
        /// <param name="node">重み付けファイルパスノード</param>
        /// <returns>ファイルパス構造体</returns>
        public override object Visit(WeightPathNode node)
        {
            FilePath filePath = new FilePath
            {
                Value = node.Path,
                Weight = node.Weight
            };
            return filePath;
        }
    }
}
