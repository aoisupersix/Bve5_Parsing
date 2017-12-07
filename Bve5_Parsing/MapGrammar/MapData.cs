using System.Collections.Generic;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// マップ構文の構文解析結果を格納するクラス
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
                case "structure":
                    StructureListPath = path;
                    break;
                case "station":
                    StationListPath = path;
                    break;
                case "signal":
                    SignalListPath = path;
                    break;
                case "sound":
                    SoundListPath = path;
                    break;
                case "sound3d":
                    Sound3DListPath = path;
                    break;
            }
        }
    }

    /// <summary>
    /// 構文情報を管理するクラス
    /// </summary>
    public class SyntaxData
    {
        public double Distance { get; set; }
        public string[] MapElement { get; set; }
        public string Key { get; set; }
        public string Function { get; set; }
        public Dictionary<string, object> Arguments { get; set; }

        public SyntaxData()
        {
            Arguments = new Dictionary<string, object>();
        }

    }
}