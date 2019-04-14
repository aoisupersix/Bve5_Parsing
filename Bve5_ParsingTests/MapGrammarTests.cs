using Xunit;
using static Bve5_ParsingTests.MapGrammarTestUtility;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System.Collections.Generic;
using System.Linq;

namespace Bve5_ParsingTests
{
    /// <summary>
    /// マップ構文のテスト
    /// </summary>
    public class MapGrammarTests
    {

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
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegintransitionStatement(0)
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
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin('key', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 'key1');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "key",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1,
                            Interval = 1,
                        }.SetStrKey("key1")
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
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin0('key', 1.0, 1.0, 1.0, 'key1', 'key2', 'key3');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "key",
                            Tilt = 1,
                            Span = 1,
                            Interval = 1,
                        }.SetStrKey(Enumerable.Range(1, 3).Select(n => $"key{n}").ToArray())
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
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginStatement(0).SetSigIdx(0)
                    }));

            //Section.Begin(signal0, signal1, signal2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Begin(0,1,2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginStatement(0).SetSigIdx(0, 1, 2)
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
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginnewStatement(0).SetSigIdx(0)
                    }));

            //Section.Beginnew(signal0, signal1, signal2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Beginnew(0,1,2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginnewStatement(0).SetSigIdx(0,1,2)
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
                    syntaxes: new List<Statement>()
                    {
                        new SectionSetspeedlimitStatement(0).SetSpdLmt(0)
                    }));

            //Section.Setspeedlimit(v0, v1, v2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.SetSpeedLimit(0, 1, 2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SectionSetspeedlimitStatement(0).SetSpdLmt(0,1,2)
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
                    syntaxes: new List<Statement>()
                    {
                        new SignalSpeedlimitStatement(0).SetSpdLmt(0)
                    }));

            //Signal.Speedlimit(v0, v1, v2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal.SpeedLimit(0, 1, 2);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SignalSpeedlimitStatement(0).SetSpdLmt(0,1,2)
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
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "Key",
                            Section = 0,
                            TrackKey = "track",
                            X = 0,
                            Y = 0,
                        }
                    }));

            //Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal['Key'].Put(0, 'track', 0, 1, 2, 3, 4, 5, 6, 7);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "Key",
                            Section = 0,
                            TrackKey = "track",
                            X = 0,
                            Y = 1,
                            Z = 2,
                            RX = 3,
                            RY = 4,
                            RZ = 5,
                            Tilt = 6,
                            Span = 7,
                        }
                    }));
        }

        /// <summary>
        /// Pretrain.Pass(Time?, Second?);
        /// </summary>
        [Fact]
        public void PretrainPassTest()
        {
            //Pretrain.Pass(Time);
            Check(
                ExecParse("BveTs Map 2.02\n0;Pretrain.Pass('12:44:30');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new PretrainPassStatement(0)
                        {
                            Time = "12:44:30"
                        }
                    }));

            //Pretrain.Pass(Second);
            Check(
                ExecParse("BveTs Map 2.02\n0;Pretrain.Pass(100);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new PretrainPassStatement(0)
                        {
                            Second = 100
                        }
                    }));
        }

        /// <summary>
        /// Fog.Interpolate(Density?, Red?, Green?, Blue?);
        /// </summary>
        [Fact]
        public void FogInterpolateTest()
        {
            //Fog.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogInterpolateStatement(0)
                    }));

            //Fog.Interpolate(Density);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Interpolate(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogInterpolateStatement(0)
                        {
                            Density = 0
                        }
                    }));

            //Fog.Interpolate(Density, Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Interpolate(0, 1, 2, 3);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogInterpolateStatement(0)
                        {
                            Density = 0,
                            Red = 1,
                            Green = 2,
                            Blue = 3,
                        }
                    }));
        }

        /// <summary>
        /// Fog.Set(Density?, Red?, Green?, Blue?);
        /// </summary>
        [Fact]
        public void FogSetTest()
        {
            //Fog.Set();
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Set();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogSetStatement(0)
                    }));

            //Fog.Set(Density);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Set(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogSetStatement(0)
                        {
                            Density = 0
                        }
                    }));

            //Fog.Set(Density, Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Set(0, 1, 2, 3);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogSetStatement(0)
                        {
                            Density = 0,
                            Red = 1,
                            Green = 2,
                            Blue = 3,
                        }
                    }));
        }

        /// <summary>
        /// Train[TrainKey].Load(FilePath, TrackKey, Direction);
        /// </summary>
        [Fact]
        public void TrainLoadTest()
        {
            //Train[TrainKey].Load(FilePath, TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['track'].Load('path', 'key', 0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainLoadStatement(0)
                        {
                            Key = "track",
                            FilePath = "path",
                            TrackKey = "key",
                            Direction = 0,
                        }
                    }));
        }

        /// <summary>
        /// Train[TrainKey].Enable(Time?, Second?);
        /// </summary>
        [Fact]
        public void TrainEnableTest()
        {
            //Train[TrainKey].Enable(Time);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['track'].Enable('10:00:00');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainEnableStatement(0)
                        {
                            Key = "track",
                            Time = "10:00:00",
                        }
                    }));

            //Train[TrainKey].Enable(Second);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['track'].Enable(0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainEnableStatement(0)
                        {
                            Key = "track",
                            Second = 0,
                        }
                    }));
        }

        #endregion
    }
}
