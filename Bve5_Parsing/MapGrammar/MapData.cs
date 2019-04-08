using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// マップ構文の構文解析結果を格納するクラス
    /// </summary>
    public class MapData
    {
        #region フィールド
        private List<SyntaxData> _statements;
        #endregion

        #region プロパティ
        /// <summary>
        /// マップファイルのバージョン
        /// </summary>
        public string Version { get; protected internal set; }

        /// <summary>
        /// マップファイルのエンコーディング
        /// </summary>
        public string Encoding { get; protected internal set; }

        /// <summary>
        /// ストラクチャリストのファイルパス
        /// </summary>
        public string StructureListPath { get; protected internal set; }

        /// <summary>
        /// 停車場リストのファイルパス
        /// </summary>
        public string StationListPath { get; protected internal set; }

        /// <summary>
        /// 信号リストのファイルパス
        /// </summary>
        public string SignalListPath { get; protected internal set; }

        /// <summary>
        /// 音リストのファイルパス
        /// </summary>
        public string SoundListPath { get; protected internal set; }

        /// <summary>
        /// 固定音源リストのファイルパス
        /// </summary>
        public string Sound3DListPath { get; protected internal set; }

        /// <summary>
        /// 構文データ
        /// </summary>
        public ReadOnlyCollection<SyntaxData> Statements { get; }
        #endregion

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public MapData()
        {
            _statements = new List<SyntaxData>();
            Statements = _statements.AsReadOnly();
        }

        /// <summary>
        /// 初期値を代入したインスタンスを生成します。
        /// </summary>
        /// <param name="version">バージョン情報</param>
        /// <param name="encoding">エンコーディング情報</param>
        /// <param name="strListPath">ストラクチャーリストのファイルパス</param>
        /// <param name="staListPath">停車場リストのファイルパス</param>
        /// <param name="sigListPath">信号リストのファイルパス</param>
        /// <param name="souListPath">音リストのファイルパス</param>
        /// <param name="so3ListPath">固定音源リストのファイルパス</param>
        /// <param name="syntaxes">構文</param>
        public MapData(
            string version = null,
            string encoding = null,
            string strListPath = null,
            string staListPath = null,
            string sigListPath = null,
            string souListPath = null,
            string so3ListPath = null,
            IEnumerable<SyntaxData> syntaxes = null
            )
        {
            Version = version;
            Encoding = encoding;
            StructureListPath = strListPath;
            StationListPath = staListPath;
            SignalListPath = sigListPath;
            SoundListPath = souListPath;
            Sound3DListPath = so3ListPath;

            if (syntaxes == null)
                _statements = new List<SyntaxData>();
            else
                _statements = syntaxes.ToList();
            Statements = _statements.AsReadOnly();
        }

        /// <summary>
        /// 構文データを追加します。
        /// </summary>
        /// <param name="data"></param>
        public void AddStatement(SyntaxData data)
        {
            _statements.Add(data);
        }

        /// <summary>
        /// 構文データリストを追加します。
        /// </summary>
        /// <param name="data"></param>
        public void AddStatements(IEnumerable<SyntaxData> data)
        {
            _statements.AddRange(data);
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

        /// <summary>
        /// リストファイルパスを引数に与えられたMapDataで上書きます。
        /// </summary>
        /// <param name="data"></param>
        public void OverwriteListPath(MapData data)
        {
            if (data.StructureListPath != null) { StructureListPath = data.StructureListPath; }
            if (data.StationListPath != null) { StructureListPath = data.StationListPath; }
            if (data.SignalListPath != null) { StructureListPath = data.SignalListPath; }
            if (data.SoundListPath != null) { StructureListPath = data.SoundListPath; }
            if (data.Sound3DListPath != null) { StructureListPath = data.Sound3DListPath; }
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
    }

    /// <summary>
    /// 構文情報を管理するクラス
    /// </summary>
    public class SyntaxData
    {
        #region フィールド
        /// <summary>
        /// 引数
        /// </summary>
        private Dictionary<string, object> _arguments;
        #endregion

        /// <summary>
        /// 距離程
        /// </summary>
        public double Distance { get; protected internal set; }

        /// <summary>
        /// マップ要素名
        /// </summary>
        public string[] MapElement { get; protected internal set; }

        /// <summary>
        /// キー名
        /// </summary>
        public string Key { get; protected internal set; }

        /// <summary>
        /// 関数名
        /// </summary>
        public string Function { get; protected internal set; }

        /// <summary>
        /// 引数
        /// </summary>
        public ReadOnlyDictionary<string, object> Arguments { get; }

        public SyntaxData()
        {
            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 構文タイプ1のインスタンスを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        /// <param name="mapElement">マップ要素</param>
        /// <param name="function">関数名</param>
        public SyntaxData(double distance, string mapElement, string function)
        {
            Distance = distance;
            MapElement = new string[] { mapElement };
            Function = function;

            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 構文タイプ2のインスタンスを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        /// <param name="mapElement">マップ要素</param>
        /// <param name="key">キー名</param>
        /// <param name="function">関数名</param>
        public SyntaxData(double distance, string mapElement, string key, string function)
        {
            Distance = distance;
            MapElement = new string[] { mapElement };
            Key = key;
            Function = function;

            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 構文タイプ3のインスタンスを生成します。
        /// </summary>
        /// <param name="distance">距離程</param>
        /// <param name="mapElement">マップ要素</param>
        /// <param name="key">キー名</param>
        /// <param name="function">関数名</param>
        public SyntaxData(double distance, string mapElement1, string mapElement2, string key, string function)
        {
            Distance = distance;
            MapElement = new string[] { mapElement1, mapElement2 };
            Key = key;
            Function = function;

            _arguments = new Dictionary<string, object>();
            Arguments = new ReadOnlyDictionary<string, object>(_arguments);
        }

        /// <summary>
        /// 引数を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public SyntaxData SetArg(string key, string val)
        {
            _arguments.Add(key, val);
            return this;
        }

        /// <summary>
        /// 引数を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        public SyntaxData SetArg(string key, double val)
        {
            _arguments.Add(key, val);
            return this;
        }

        /// <summary>
        /// 引数を設定します。
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public SyntaxData SetArg(string key, object val)
        {
            _arguments.Add(key, val);
            return this;
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
                s.Arguments.Count() == Arguments.Count &&
                s.Arguments.Keys.ToArray().SequenceEqual(Arguments.Keys.ToArray()) &&
                s.Arguments.Values.ToArray().SequenceEqual(Arguments.Values.ToArray())
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