using System.Collections.Generic;
using System.Linq;

namespace Bve5_Parsing.ScenarioGrammar
{
    /// <summary>
    /// 構文解析の結果を格納するクラス
    /// </summary>
    public class ScenarioData
    {
        private List<FilePath> _route;
        private List<FilePath> _vehicle;

        #region プロパティ
        /// <summary>
        /// シナリオファイルのバージョン
        /// </summary>
        public string Version { get; protected internal set; }

        /// <summary>
        /// シナリオファイルのエンコーディング
        /// </summary>
        public string Encoding { get; protected internal set; }

        /// <summary>
        /// マップファイルの相対パス
        /// </summary>
        public IReadOnlyCollection<FilePath> Route { get; }

        /// <summary>
        /// 車両ファイルの相対パス
        /// </summary>
        public IReadOnlyCollection<FilePath> Vehicle { get; }

        /// <summary>
        /// サムネイル画像の相対パス
        /// </summary>
        public string Image { get; protected internal set; }

        /// <summary>
        /// シナリオタイトル
        /// </summary>
        public string Title { get; protected internal set; }

        /// <summary>
        /// 路線名
        /// </summary>
        public string RouteTitle { get; protected internal set; }

        /// <summary>
        /// 車両名
        /// </summary>
        public string VehicleTitle { get; protected internal set; }

        /// <summary>
        /// 路線と車両の作者
        /// </summary>
        public string Author { get; protected internal set; }

        /// <summary>
        /// シナリオの説明
        /// </summary>
        public string Comment { get; protected internal set; }
        #endregion

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public ScenarioData()
        {
            _route = new List<FilePath>();
            _vehicle = new List<FilePath>();
            Route = _route.AsReadOnly();
            Vehicle = _vehicle.AsReadOnly();
        }

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        /// <param name="version"></param>
        /// <param name="encoding"></param>
        /// <param name="route"></param>
        /// <param name="vehicle"></param>
        /// <param name="image"></param>
        /// <param name="title"></param>
        /// <param name="routeTitle"></param>
        /// <param name="vehicleTitle"></param>
        /// <param name="author"></param>
        /// <param name="comment"></param>
        public ScenarioData(
            string version = null,
            string encoding = null,
            IEnumerable<FilePath> route = null,
            IEnumerable<FilePath> vehicle = null,
            string image = null,
            string title = null,
            string routeTitle = null,
            string vehicleTitle = null,
            string author = null,
            string comment = null)
        {
            Version = version;
            Encoding = encoding;

            if (route == null)
                _route = new List<FilePath>();
            else
                _route = route.ToList();
            Route = _route.AsReadOnly();

            if (vehicle == null)
                _vehicle = new List<FilePath>();
            else
                _vehicle = vehicle.ToList();
            Vehicle = _vehicle.AsReadOnly();

            Image = image;
            Title = title;
            RouteTitle = routeTitle;
            VehicleTitle = vehicleTitle;
            Author = author;
            Comment = comment;
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

            var m = (ScenarioData)obj;

            return
                m.Version == Version &&
                m.Encoding == Encoding &&
                m.Route.SequenceEqual(Route) &&
                m.Vehicle.SequenceEqual(Vehicle) &&
                m.Image == Image &&
                m.Title == Title &&
                m.RouteTitle == RouteTitle &&
                m.VehicleTitle == VehicleTitle &&
                m.Author == Author &&
                m.Comment == Comment
                ;
        }

        public override int GetHashCode()
        {
            return
                Version.GetHashCode() ^
                Encoding.GetHashCode() ^
                Route.GetHashCode() ^
                Vehicle.GetHashCode() ^
                Image.GetHashCode() ^
                Title.GetHashCode() ^
                RouteTitle.GetHashCode() ^
                VehicleTitle.GetHashCode() ^
                Author.GetHashCode() ^
                Comment.GetHashCode()
                ;
        }
        #endregion
    }

    /// <summary>
    /// ファイルパス構造体
    /// </summary>
    public struct FilePath
    {
        public string Value { get; internal set; }
        public double Weight { get; internal set; }
    }
}
