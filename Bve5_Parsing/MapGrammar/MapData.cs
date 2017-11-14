using System.Collections.Generic;
using Bve5_Parsing.MapGrammar.AstNodes;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// 構文解析の結果を格納するクラス
    /// </summary>
    public class MapData
    {
        /// <summary>
        /// マップファイルのバージョン
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// マップファイルのエンコーディング
        /// </summary>
        public string Encoding { get; set; }

        /// <summary>
        /// ストラクチャリストのファイルパス
        /// </summary>
        public string StructureListPath { get; set; }
        
        /// <summary>
        /// 停車場リストのファイルパス
        /// </summary>
        public string StationListPath { get; set; }

        /// <summary>
        /// 信号リストのファイルパス
        /// </summary>
        public string SignalListPath { get; set; }

        /// <summary>
        /// 音リストのファイルパス
        /// </summary>
        public string SoundListPath { get; set; }

        /// <summary>
        /// 固定音源リストのファイルパス
        /// </summary>
        public string Sound3DListPath { get; set; }

        /// <summary>
        /// 構文
        /// </summary>
        public List<SyntaxData> Statements { get; set; }

        public MapData()
        {
            Statements = new List<SyntaxData>();
        }

        /// <summary>
        /// 文字列から対応するリストファイルのパスを設定する
        /// </summary>
        /// <param name="elementName">LoadListFileNodeのelementName</param>
        /// <param name="path">設定するファイルパス</param>
        public void SetListPathToString(string elementName, string path)
        {
            switch (elementName)
            {
                case "Structure":
                    StructureListPath = path;
                    break;
                case "Station":
                    StationListPath = path;
                    break;
                case "Signal":
                    SignalListPath = path;
                    break;
                case "Sound":
                    SoundListPath = path;
                    break;
                case "Sound3D":
                    Sound3DListPath = path;
                    break;
            }
        }
    }
}
