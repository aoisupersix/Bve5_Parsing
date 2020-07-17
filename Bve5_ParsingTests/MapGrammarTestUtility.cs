using System.Linq;
using System.Reflection;
using Bve5_Parsing.MapGrammar;
using Bve5_Parsing.MapGrammar.EvaluateData;
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
            var data = mParser.Parse(input);
            Assert.Empty(mParser.ParserErrors);
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

                var args = exp.GetArgumentProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                    .Join(
                        act.GetArgumentProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public),
                        e => e.Name,
                        a => a.Name,
                        (e, a) => new { exp = e.GetValue(exp, null), act = a.GetValue(act, null) });

                foreach (var arg in args)
                {
                    Assert.Equal(arg.exp, arg.act);
                }

                if (exp is RepeaterBeginStatement)
                {
                    var expCast = (RepeaterBeginStatement)exp;
                    var actCast = (RepeaterBeginStatement)act;
                    Assert.Equal(expCast.StructureKeys.Count, actCast.StructureKeys.Count);

                    for (int j = 0; j < expCast.StructureKeys.Count; j++)
                    {
                        Assert.Equal(expCast.StructureKeys[j], actCast.StructureKeys[j]);
                    }
                }

                if (exp is RepeaterBegin0Statement)
                {
                    var expCast = (RepeaterBegin0Statement)exp;
                    var actCast = (RepeaterBegin0Statement)act;
                    Assert.Equal(expCast.StructureKeys.Count, actCast.StructureKeys.Count);

                    for (int j = 0; j < expCast.StructureKeys.Count; j++)
                    {
                        Assert.Equal(expCast.StructureKeys[j], actCast.StructureKeys[j]);
                    }
                }

                if (exp is SectionBeginStatement)
                {
                    var expCast = (SectionBeginStatement)exp;
                    var actCast = (SectionBeginStatement)act;
                    Assert.Equal(expCast.Signals.Count, actCast.Signals.Count);

                    for (int j = 0; j < expCast.Signals.Count; j++)
                    {
                        Assert.Equal(expCast.Signals[j], actCast.Signals[j]);
                    }
                }

                if (exp is SectionBeginnewStatement)
                {
                    var expCast = (SectionBeginnewStatement)exp;
                    var actCast = (SectionBeginnewStatement)act;
                    Assert.Equal(expCast.Signals.Count, actCast.Signals.Count);

                    for (int j = 0; j < expCast.Signals.Count; j++)
                    {
                        Assert.Equal(expCast.Signals[j], actCast.Signals[j]);
                    }
                }

                if (exp is SectionSetspeedlimitStatement)
                {
                    var expCast = (SectionSetspeedlimitStatement)exp;
                    var actCast = (SectionSetspeedlimitStatement)act;
                    Assert.Equal(expCast.Vs.Count, actCast.Vs.Count);

                    for (int j = 0; j < expCast.Vs.Count; j++)
                    {
                        Assert.Equal(expCast.Vs[j], actCast.Vs[j]);
                    }
                }

                if (exp is SignalSpeedlimitStatement)
                {
                    var expCast = (SignalSpeedlimitStatement)exp;
                    var actCast = (SignalSpeedlimitStatement)act;
                    Assert.Equal(expCast.Vs.Count, actCast.Vs.Count);

                    for (int j = 0; j < expCast.Vs.Count; j++)
                    {
                        Assert.Equal(expCast.Vs[j], actCast.Vs[j]);
                    }
                }
            }
        }
    }
}
