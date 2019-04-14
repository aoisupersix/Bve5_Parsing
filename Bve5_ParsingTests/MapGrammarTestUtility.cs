using Bve5_Parsing.MapGrammar;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System;
using System.Linq;
using Xunit;

namespace Bve5_ParsingTests
{
    public static class MapGrammarTestUtility
    {
        /// <summary>
        /// 引数に与えられた構文文字列をパースします。
        /// </summary>
        /// <param name="input">マップ構文</param>
        /// <returns>MapData</returns>
        public static MapData ExecParse(string input)
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
        public static void Check(MapData expected, MapData actual)
        {
            Assert.NotNull(expected);
            Assert.Equal(expected.Version, actual.Version);
            Assert.Equal(expected.Encoding, actual.Encoding);
            Assert.Equal(expected.StructureListPath, actual.StructureListPath);
            Assert.Equal(expected.StationListPath, actual.StationListPath);
            Assert.Equal(expected.SignalListPath, actual.SignalListPath);
            Assert.Equal(expected.SoundListPath, actual.SoundListPath);
            Assert.Equal(expected.Sound3DListPath, actual.Sound3DListPath);

            Assert.Equal(expected.Statements.Count(), actual.Statements.Count());
            for (var i = 0; i < expected.Statements.Count(); i++)
            {
                var exp = expected.Statements[i];
                var act = actual.Statements[i];
                Assert.Equal(exp.Distance, act.Distance);
                Assert.Equal(exp.GetType(), act.GetType());
                if (exp.HasKey)
                    Assert.Equal(exp.GetType().GetProperty("Key").GetValue(exp, null), act.GetType().GetProperty("Key").GetValue(act, null));

                var args = exp.GetAllArguments()
                    .Join(
                        act.GetAllArguments(),
                        e => e.Name,
                        a => a.Name,
                        (e, a) => new { exp = e.GetValue(exp, null), act = a.GetValue(act, null) });

                foreach (var arg in args)
                {
                    Assert.Equal(arg.exp, arg.act);
                }
            }
            Assert.Equal(expected, actual);
        }
    }
}
