using System.Collections.Generic;
using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless
{
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
