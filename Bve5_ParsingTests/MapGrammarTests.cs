using System;
using Xunit;
using Bve5_Parsing.MapGrammar;
using System.Collections.Generic;
using System.Collections;

namespace Bve5_ParsingTests
{
    /// <summary>
    /// マップ構文のテスト
    /// </summary>
    public class MapGrammarTests
    {
        /// <summary>
        /// 引数に与えられた構文文字列をパースします。
        /// </summary>
        /// <param name="input">マップ構文</param>
        /// <returns>MapData</returns>
        private MapData ExecParse(string input)
        {
            var mParser = new MapGrammarParser();
            MapData data = null;
            try
            {
                data = mParser.Parse(input);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message + ":" + e.StackTrace);
            }

            return data;
        }

        /// <summary>
        /// Assert.NotNullとAssert.Equalを実行します。
        /// </summary>
        /// <param name="expected">パーサによって生成されたMapData</param>
        /// <param name="actual">確認用</param>
        private void Check(MapData expected, MapData actual)
        {
            Assert.NotNull(expected);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void RootTest()
        {
            // メモ：エンコード指定の前後には空白は入れられないはずだが、出来てしまう
            Check(
                ExecParse("BveTs Map 2.02"),
                new MapData("2.02"));
            Check(
                ExecParse("BveTs Map 2.02:utf-8"),
                new MapData("2.02", "utf-8"));
            Check(
                ExecParse("BveTs Map 2.00:utf-8"),
                new MapData("2.00","utf-8"));
            Check(
                ExecParse("BVEtS maP 2.02:UtF-8"),
                new MapData("2.02", "UtF-8"));
            Check(
                ExecParse("BveTs Map 2.02:utf-8\n0;Curve.BeginTransition();"),
                new MapData(
                    version: "2.02", encoding: "utf-8",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "begintransition")
                    }));
        }

        #region 各構文の手動テスト
        /// <summary>
        /// Structure.Load(FilePath);
        /// </summary>
        [Fact]
        public void StructureLoadTest()
        {

            // Structure.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure.Load('path');"),
                new MapData(version: "2.02", strListPath: "path")
                );
        }

        /// <summary>
        /// Station.Load(FilePath);
        /// </summary>
        [Fact]
        public void StationLoadTest()
        {

            // Station.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Station.Load('path');"),
                new MapData(version: "2.02", staListPath: "path")
                );
        }

        /// <summary>
        /// Signal.Load(FilePath);
        /// </summary>
        [Fact]
        public void SignalLoadTest()
        {

            // Signal.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal.Load('path');"),
                new MapData(version: "2.02", sigListPath: "path")
                );
        }

        /// <summary>
        /// Sound.Load(FilePath);
        /// </summary>
        [Fact]
        public void SoundLoadTest()
        {
            // Sound.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Sound.Load('path');"),
                new MapData(version: "2.02", souListPath: "path")
                );
        }

        /// <summary>
        /// Sound3d.Load(FilePath);
        /// </summary>
        [Fact]
        public void Sound3dLoadTest()
        {
            // Structure.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Sound3D.Load('path');"),
                new MapData(version: "2.02", so3ListPath: "path")
                );
        }
        #endregion
    }
}
