using System.Collections.Generic;
using System.Linq;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// マップ構文の構文解析結果を格納するクラス
    /// </summary>
    public class MapData
    {
        #region プロパティ
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
        #endregion

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public MapData()
        {
            Statements = new List<SyntaxData>();
        }

        #region Override
        /// <summary>
        /// 等価チェック
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var m = (MapData)obj;

            return
                m.Version == Version &&
                m.Encoding == Encoding &&
                m.StructureListPath == StructureListPath &&
                m.StationListPath == StationListPath &&
                m.SignalListPath == SignalListPath &&
                m.SoundListPath == SoundListPath &&
                m.Sound3DListPath == m.Sound3DListPath &&
                m.Statements.SequenceEqual(Statements)
                ;
        }

        public override int GetHashCode()
        {
            return
                Version.GetHashCode() ^
                Encoding.GetHashCode() ^
                StructureListPath.GetHashCode() ^
                StationListPath.GetHashCode() ^
                SignalListPath.GetHashCode() ^
                SoundListPath.GetHashCode() ^
                Sound3DListPath.GetHashCode() ^
                Statements.GetHashCode()
                ;
        }
        #endregion

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

        #region Override
        /// <summary>
        /// 等価チェック
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var s = (SyntaxData)obj;

            return
                s.Distance == Distance &&
                ((s.MapElement == null && MapElement == null ) || (s.MapElement != null && MapElement != null && s.MapElement.SequenceEqual(MapElement))) &&
                s.Key == Key &&
                s.Function == Function &&
                s.Arguments.SequenceEqual(Arguments) //Argumentsは必ずnullではない
                ;
        }

        public override int GetHashCode()
        {
            return
                Distance.GetHashCode() ^
                MapElement.GetHashCode() ^
                Key.GetHashCode() ^
                Function.GetHashCode() ^
                Arguments.GetHashCode()
                ;
        }
        #endregion
    }
}