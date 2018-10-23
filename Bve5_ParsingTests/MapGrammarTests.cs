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

        #region 各構文のテスト
        [Fact]
        public void RootTest()
        {
            // メモ：エンコード指定の前後には空白は入れられないはずだが、出来てしまう
            Check(
                ExecParse("BveTs Map 2.02"),
                new MapData() { Version = "2.02" });
            Check(
                ExecParse("BveTs Map 2.02:utf-8"),
                new MapData() { Version = "2.02", Encoding = "utf-8" });
            Check(
                ExecParse("BveTs Map 2.00:utf-8"),
                new MapData() { Version = "2.00", Encoding = "utf-8" });
            Check(
                ExecParse("BVEtS maP 2.02:UtF-8"),
                new MapData() { Version = "2.02", Encoding = "UtF-8" });
            Check(
                ExecParse("BveTs Map 2.02:utf-8\n0;Curve.BeginTransition();"),
                new MapData()
                {
                    Version = "2.02",
                    Encoding = "utf-8",
                    Statements = new List<SyntaxData>() {
                        new SyntaxData(0, "curve", "begintransition")
                    }
                });
        }

        [Fact]
        public void CurveTest()
        {
            // Curve.SetGauge(value)
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.SetGauge(400);"),
                new MapData()
                {
                    Version = "2.02",
                    Statements = new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "setgauge").SetArg("value", 400)
                    }
                });
        }
        #endregion
    }
}
