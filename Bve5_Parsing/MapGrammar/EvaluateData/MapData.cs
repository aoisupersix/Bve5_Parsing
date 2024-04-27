using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Bve5_Parsing.MapGrammar.EvaluateData
{
    /// <summary>
    /// マップ構文の構文解析結果を格納するクラス
    /// </summary>
    public class MapData
    {
        #region フィールド
        private List<Statement> _statements;
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
        public ReadOnlyCollection<Statement> Statements { get; }
        #endregion

        /// <summary>
        /// インスタンスを生成します。
        /// </summary>
        public MapData()
        {
            _statements = new List<Statement>();
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
            IEnumerable<Statement> syntaxes = null
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
                _statements = new List<Statement>();
            else
                _statements = syntaxes.ToList();
            Statements = _statements.AsReadOnly();
        }

        /// <summary>
        /// 構文データを追加します。
        /// </summary>
        /// <param name="data"></param>
        public void AddStatement(Statement data)
        {
            _statements.Add(data);
        }

        /// <summary>
        /// 構文データリストを追加します。
        /// </summary>
        /// <param name="data"></param>
        public void AddStatements(IEnumerable<Statement> data)
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
            if (data.StationListPath != null) { StationListPath = data.StationListPath; }
            if (data.SignalListPath != null) { SignalListPath = data.SignalListPath; }
            if (data.SoundListPath != null) { SoundListPath = data.SoundListPath; }
            if (data.Sound3DListPath != null) { Sound3DListPath = data.Sound3DListPath; }
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
                m.Sound3DListPath == Sound3DListPath &&
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
}
