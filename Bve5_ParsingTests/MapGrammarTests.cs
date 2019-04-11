using System;
using Xunit;
using Bve5_Parsing.MapGrammar;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

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
            Assert.Equal(expected.Version, actual.Version);
            Assert.Equal(expected.Encoding, actual.Encoding);
            Assert.Equal(expected.StructureListPath, actual.StructureListPath);
            Assert.Equal(expected.StationListPath, actual.StationListPath);
            Assert.Equal(expected.SignalListPath, actual.SignalListPath);
            Assert.Equal(expected.SoundListPath, actual.SoundListPath);
            Assert.Equal(expected.Sound3DListPath, actual.Sound3DListPath);

            Assert.Equal(expected.Statements.Count(), actual.Statements.Count());
            for(var i = 0; i < expected.Statements.Count(); i++)
            {
                // TODO
            }
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

        /// <summary>
        /// Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
        /// </summary>
        [Fact]
        public void RepeaterBeginTest()
        {

            // Repeater[RepeaterKey].Begin(trackkey, x, y, z, rx, ry, rz, tilt, span, interval, 'key1');
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin(1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 'key1');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "repeater", "RepeaterKey", "begin").SetArg("trackkey", 1.0).SetArg("x", 1.0).SetArg("y", 1.0).SetArg("z", 1.0).SetArg("rx", 1.0).SetArg("ry", 1.0).SetArg("rz", 1.0).SetArg("tilt", 1.0).SetArg("span", 1.0).SetArg("interval", 1.0).SetArg("structurekey1", "key1")
                    }));
        }

        /// <summary>
        /// Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval);
        /// </summary>
        [Fact]
        public void RepeaterBegin0Test()
        {

            // Repeater[RepeaterKey].Begin0(trackkey, tilt, span, interval);
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin0(1.0, 1.0, 1.0, 1.0, 'key1', 'key2', 'key3');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "repeater", "RepeaterKey", "begin0").SetArg("trackkey", 1.0).SetArg("tilt", 1.0).SetArg("span", 1.0).SetArg("interval", 1.0).SetArg("structurekey1", "key1").SetArg("structurekey2", "key2").SetArg("structurekey3", "key3")
                    }));
        }

        /// <summary>
        /// Section.Begin();
        /// </summary>
        [Fact]
        public void SectionBeginTest()
        {
            //Section.Begin(signal0);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Begin(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "section", "begin").SetArg("signal0", 0)
                    }));

            //Section.Begin(signal0, signal1, signal2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Begin(0,1,2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "section", "begin").SetArg("signal0", 0).SetArg("signal1", 1).SetArg("signal2", 2)
                    }));
        }

        /// <summary>
        /// Section.Beginnew();
        /// </summary>
        [Fact]
        public void SectionBeginnewTest()
        {
            //Section.Beginnew(signal0);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Beginnew(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "section", "beginnew").SetArg("signal0", 0)
                    }));

            //Section.Beginnew(signal0, signal1, signal2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Beginnew(0,1,2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "section", "beginnew").SetArg("signal0", 0).SetArg("signal1", 1).SetArg("signal2", 2)
                    }));
        }

        /// <summary>
        /// Section.Setspeedlimit();
        /// </summary>
        [Fact]
        public void SectionSetspeedlimitTest()
        {
            //Section.Setspeedlimit(v0);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.SetSpeedLimit(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "section", "setspeedlimit").SetArg("v0", 0)
                    }));

            //Section.Setspeedlimit(v0, v1, v2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.SetSpeedLimit(0, 1, 2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "section", "setspeedlimit").SetArg("v0", 0).SetArg("v1", 1).SetArg("v2", 2)
                    }));
        }

        /// <summary>
        /// Signal.Speedlimit();
        /// </summary>
        [Fact]
        public void SignalSpeedlimitTest()
        {
            //Signal.Speedlimit(v0);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal.SpeedLimit(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "signal", "speedlimit").SetArg("v0", 0)
                    }));

            //Signal.Speedlimit(v0, v1, v2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal.SpeedLimit(0, 1, 2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "signal", "speedlimit").SetArg("v0", 0).SetArg("v1", 1).SetArg("v2", 2)
                    }));
        }

        /// <summary>
        /// Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z?, RX?, RY?, RZ?, Tilt?, Span?);
        /// </summary>
        [Fact]
        public void SignalPutTest()
        {
            //Signal[SignalAspectKey].Put(Section, TrackKey, X, Y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal['Key'].Put(0, 'track', 0, 0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "signal", "Key", "put").SetArg("section", 0).SetArg("trackkey", "track").SetArg("x", 0).SetArg("y", 0)
                    }));

            //Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal['Key'].Put(0, 'track', 0, 1, 2, 3, 4, 5, 6, 7);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "signal", "Key", "put").SetArg("section", 0).SetArg("trackkey", "track").SetArg("x", 0).SetArg("y", 1)
                            .SetArg("z", 2).SetArg("rx", 3).SetArg("ry", 4).SetArg("rz", 5).SetArg("tilt", 6).SetArg("span", 7)
                    }));
        }

        #endregion
    }
}
