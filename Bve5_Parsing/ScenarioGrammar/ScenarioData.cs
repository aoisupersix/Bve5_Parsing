using System.Collections.Generic;

namespace Bve5_Parsing.ScenarioGrammar
{
    /// <summary>
    /// 構文解析の結果を格納するクラス
    /// </summary>
    public class ScenarioData
    {
        /// <summary>
        /// シナリオファイルのバージョン
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// シナリオファイルのエンコーディング
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// マップファイルの相対パス
        /// </summary>
        public List<FilePath> Route { get; set; }

        /// <summary>
        /// 車両ファイルの相対パス
        /// </summary>
        public List<FilePath> Vehicle { get; set; }

        /// <summary>
        /// サムネイル画像の相対パス
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// シナリオタイトル
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 路線名
        /// </summary>
        public string RouteTitle { get; set; }

        /// <summary>
        /// 車両名
        /// </summary>
        public string VehicleTitle { get; set; }

        /// <summary>
        /// 路線と車両の作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// シナリオの説明
        /// </summary>
        public string Comment { get; set; }

        public ScenarioData()
        {
            Route = new List<FilePath>();
            Vehicle = new List<FilePath>();
        }
    }

    /// <summary>
    /// ファイルパス構造体
    /// </summary>
    public struct FilePath
    {
        public string Value { get; set; }
        public double Weight { get; set; }
    }
}
