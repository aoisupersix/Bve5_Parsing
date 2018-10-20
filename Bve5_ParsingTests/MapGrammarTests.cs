using System;
using Xunit;
using Bve5_Parsing.MapGrammar;
using System.Collections.Generic;
using System.Collections;

namespace Bve5_ParsingTests
{
    /// <summary>
    /// マップ構文のテストデータ
    /// </summary>
    public class MapGrammarTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "BveTs Map 2.02", new MapData() { Version = "2.02" } };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

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

        [Theory(DisplayName = "ルート(ファイルヘッダ等")]
        [ClassData(typeof(MapGrammarTestData))]
        public void RootTest(string input, MapData result)
        {
            var r = ExecParse(input);

            Assert.NotNull(r);
            Assert.Equal(r, result);
        }
    }
}
