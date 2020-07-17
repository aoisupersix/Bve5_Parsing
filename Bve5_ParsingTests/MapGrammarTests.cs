using Xunit;
using static Bve5_ParsingTests.MapGrammarTestUtility;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System.Collections.Generic;
using System.Linq;
using Bve5_Parsing.MapGrammar;

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
            Check(
                ExecParse("BveTs Map 2.02"),
                new MapData("2.02"));
            Check(
                ExecParse("BveTs Map 2.02:utf-8"),
                new MapData("2.02", "utf-8"));
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

            Check(
                ExecParse("BveTs Map 2.00"),
                new MapData("2.00"));
            Check(
                ExecParse("BveTs Map 2.00:utf-8"),
                new MapData("2.00", "utf-8"));
            Check(
                ExecParse("BveTs Map 2.00:utf-8"),
                new MapData("2.00", "utf-8"));
            Check(
                ExecParse("BVEtS maP 2.00:UtF-8"),
                new MapData("2.00", "UtF-8"));
            Check(
                ExecParse("BveTs Map 2.00:utf-8\n0;Curve.BeginTransition();"),
                new MapData(
                    version: "2.00", encoding: "utf-8",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegintransitionStatement(0)
                    }));

            Check(
                ExecParse("BveTs Map 1.00"),
                new MapData("1.00"));
            Check(
                ExecParse("BveTs Map 1.00:utf-8"),
                new MapData("1.00", "utf-8"));
            Check(
                ExecParse("BveTs Map 1.00:utf-8"),
                new MapData("1.00", "utf-8"));
            Check(
                ExecParse("BVEtS maP 1.00:UtF-8"),
                new MapData("1.00", "UtF-8"));
            Check(
                ExecParse("BveTs Map 1.00:utf-8\n0;Curve.BeginTransition();"),
                new MapData(
                    version: "1.00", encoding: "utf-8",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegintransitionStatement(0)
                    }));
        }

        [Fact]
        public void WhiteSpaceTest()
        {
            Check(
                ExecParse(@"BveTs Map 2.02
0;
Curve
                .
BeginTransition
(  // This is line comment
　// Left space is U+3000
)
    ;
"),
                new MapData(version: "2.02",
                syntaxes: new List<Statement>()
                {
                    new CurveBegintransitionStatement(0)
                }));

            Check(
                ExecParse(@"BveTs Map 2.00
0;
Curve
                .
BeginTransition
(  // This is line comment
　// Left space is U+3000
)
    ;
"),
                new MapData(version: "2.00",
                syntaxes: new List<Statement>()
                {
                    new CurveBegintransitionStatement(0)
                }));

            Check(
                ExecParse(@"BveTs Map 1.00
0;
Curve
                .
BeginTransition
(  // This is line comment
　// Left space is U+3000
)
    ;
"),
                new MapData(version: "1.00",
                syntaxes: new List<Statement>()
                {
                    new CurveBegintransitionStatement(0)
                }));
        }

        [Fact]
        public void V2InvalidArgumentTest()
        {
            var parser = new MapGrammarParser();
            parser.Parse("BveTs Map 2.02\n0;Curve.Setgauge('test');");
            Assert.Single(parser.ParserErrors); // TODO
        }

        [Fact]
        public void V1InvalidArgumentTest()
        {
            var parser = new MapGrammarParser();
            parser.Parse("BveTs Map 2.02\n0;Curve.Gauge(test);");
            Assert.Single(parser.ParserErrors); // TODO
        }

        [Fact]
        public void V1ArgTest()
        {
            Check(
                ExecParse("BveTs Map 1.00:utf-8\n0;Track[hoge[][]().hoge].Position(4,3);"),
                new MapData(
                    version: "1.00", encoding: "utf-8",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "hoge[][]().hoge",
                            X = 4,
                            Y = 3
                        }
                    }));

            // TODO: 仕様確認 引数中の空白は除外されるのか
            // 現在はLexerの定義て勝手に除外されてしまうので、もし除外されないようにするためにはLexerの定義変更が必要。
            Check(
                ExecParse("BveTs Map 1.00:utf-8\n0;Track[hoge[][]  []hoge].Position(4,3);"),
                new MapData(
                    version: "1.00", encoding: "utf-8",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "hoge[][][]hoge",
                            X = 4,
                            Y = 3
                        }
                    }));

            Check(
                ExecParse("BveTs Map 1.00:utf-8\n0;Structure.Load(this[]is()str.path);"),
                new MapData(
                    version: "1.00", encoding: "utf-8",
                    strListPath: "this[]is()str.path"
                    ));
        }

        #region ロード構文
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

            // Structure.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.00\n0;Structure.Load('path');"),
                new MapData(version: "2.00", strListPath: "path")
                );

            // Structure.Load(filePath);
            Check(
                ExecParse("BveTs Map 1.00\n0;Structure.Load(path);"),
                new MapData(version: "1.00", strListPath: "path")
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

            // Station.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.00\n0;Station.Load('path');"),
                new MapData(version: "2.00", staListPath: "path")
                );

            // Station.Load(filePath);
            Check(
                ExecParse("BveTs Map 1.00\n0;Station.Load(path);"),
                new MapData(version: "1.00", staListPath: "path")
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

            // Signal.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.00\n0;Signal.Load('path');"),
                new MapData(version: "2.00", sigListPath: "path")
                );

            // Signal.Load(filePath);
            Check(
                ExecParse("BveTs Map 1.00\n0;Signal.Load(path);"),
                new MapData(version: "1.00", sigListPath: "path")
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

            // Sound.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.00\n0;Sound.Load('path');"),
                new MapData(version: "2.00", souListPath: "path")
                );

            // Sound.Load(filePath);
            Check(
                ExecParse("BveTs Map 1.00\n0;Sound.Load(path);"),
                new MapData(version: "1.00", souListPath: "path")
                );
        }

        /// <summary>
        /// Sound3d.Load(FilePath);
        /// </summary>
        [Fact]
        public void Sound3dLoadTest()
        {
            // Sound3d.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Sound3D.Load('path');"),
                new MapData(version: "2.02", so3ListPath: "path")
                );

            // Sound3d.Load(filePath);
            Check(
                ExecParse("BveTs Map 2.00\n0;Sound3D.Load('path');"),
                new MapData(version: "2.00", so3ListPath: "path")
                );

            // Sound3d.Load(filePath);
            Check(
                ExecParse("BveTs Map 1.00\n0;Sound3D.Load(path);"),
                new MapData(version: "1.00", so3ListPath: "path")
                );
        }
        #endregion

        #region 各種構文の手動テスト

        /// <summary>
        /// Track[TrackKey].Position(X, Y, RadiusH?, RadiusV?);
        /// </summary>
        [Fact]
        public void TrackPositionTest()
        {

            // Track[TrackKey].Position(X, Y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Position(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1
                        }
                    }));

            // Track[TrackKey].Position(X, Y, RadiusH);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Position(1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1,
                            RadiusH = 1
                        }
                    }));

            // Track[TrackKey].Position(X, Y, RadiusH, RadiusV);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Position(1, 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1,
                            RadiusH = 1,
                            RadiusV = 1
                        }
                    }));

            // Track[TrackKey].Position(X, Y);
            Check(
                ExecParse("BveTs Map 2.00\n0;Track['TrackKey'].Position(1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1
                        }
                    }));

            // Track[TrackKey].Position(X, Y, RadiusH, RadiusV);
            Check(
                ExecParse("BveTs Map 2.00\n0;Track['TrackKey'].Position(1, 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1,
                            RadiusH = 1,
                            RadiusV = 1
                        }
                    }));

            // Track[TrackKey].Position(X, Y);
            Check(
                ExecParse("BveTs Map 1.00\n0;Track[TrackKey].Position(1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1
                        }
                    }));

            // Track[TrackKey].Position(X, Y, RadiusH, RadiusV);
            Check(
                ExecParse("BveTs Map 1.00\n0;Track[TrackKey].Position(1, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackPositionStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Y = 1,
                            RadiusH = 1,
                            RadiusV = 1
                        }
                    }));
        }

        /// <summary>
        /// Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag?);
        /// </summary>
        [Fact]
        public void StructurePutbetweenTest()
        {

            // Structure[StructureKey].Putbetween(TrackKey1, TrackKey2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Putbetween('string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutbetweenStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey1 = "string_test_value",
                            TrackKey2 = "string_test_value"
                        }
                    }));

            // Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Putbetween('string_test_value', 'string_test_value', 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutbetweenStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey1 = "string_test_value",
                            TrackKey2 = "string_test_value",
                            Flag = 1
                        }
                    }));

            // Structure[StructureKey].Putbetween(TrackKey1, TrackKey2);
            Check(
                ExecParse("BveTs Map 2.00\n0;Structure['StructureKey'].Putbetween('string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutbetweenStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey1 = "string_test_value",
                            TrackKey2 = "string_test_value"
                        }
                    }));

            // Structure[StructureKey].Putbetween(TrackKey1, TrackKey2);
            Check(
                ExecParse("BveTs Map 1.00\n0;Structure[StructureKey].Putbetween(string_test_value, string_test_value);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutbetweenStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey1 = "string_test_value",
                            TrackKey2 = "string_test_value"
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

            //Pretrain.Pass(Time);
            Check(
                ExecParse("BveTs Map 2.00\n0;Pretrain.Pass('12:44:30');"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new PretrainPassStatement(0)
                        {
                            Time = "12:44:30"
                        }
                    }));

            //Pretrain.Pass(Second);
            Check(
                ExecParse("BveTs Map 2.00\n0;Pretrain.Pass(100);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new PretrainPassStatement(0)
                        {
                            Second = 100
                        }
                    }));

            //Pretrain.Pass(Time);
            Check(
                ExecParse("BveTs Map 1.00\n0;Pretrain.Pass(12:44:30);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new PretrainPassStatement(0)
                        {
                            Time = "12:44:30"
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

            //Train[TrainKey].Enable(Time);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train['track'].Enable('10:00:00');"),
                new MapData(
                    version: "2.00",
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
                ExecParse("BveTs Map 2.00\n0;Train['track'].Enable(0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainEnableStatement(0)
                        {
                            Key = "track",
                            Second = 0,
                        }
                    }));

            //Train[TrainKey].Enable(Time);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train[track].Enable(10:00:00);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainEnableStatement(0)
                        {
                            Key = "track",
                            Time = "10:00:00",
                        }
                    }));
        }

        /// <summary>
        /// Include FilePath;
        /// </summary>
        [Fact]
        public void IncludeTest()
        {
            //Include FilePath;
            Check(
                ExecParse("BveTs Map 2.02\n0;Include 'path';"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new IncludeStatement(0)
                        {
                            FilePath = "path"
                        }
                    }));

            //Include FilePath;
            Check(
                ExecParse("BveTs Map 2.00\n0;Include 'path';"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new IncludeStatement(0)
                        {
                            FilePath = "path"
                        }
                    }));
        }

        #endregion
    }
}
