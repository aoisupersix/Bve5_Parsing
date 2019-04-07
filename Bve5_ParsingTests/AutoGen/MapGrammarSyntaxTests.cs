/*
 * このファイルは自動生成doc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */
using System;
using Xunit;
using Bve5_Parsing.MapGrammar;
using System.Collections.Generic;

namespace Bve5_ParsingTests
{
    public class MapGrammarSyntaxTests
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

        /// <summary>
        /// Curve.Setgauge(Value);
        /// </summary>
        [Fact]
        public void CurveSetgaugeTest()
        {

            // Curve.Setgauge(value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Setgauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "setgauge").SetArg("value", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.Gauge(Value);
        /// </summary>
        [Fact]
        public void CurveGaugeTest()
        {

            // Curve.Gauge(value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Gauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "gauge").SetArg("value", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.Setcenter(X);
        /// </summary>
        [Fact]
        public void CurveSetcenterTest()
        {

            // Curve.Setcenter(x);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Setcenter(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "setcenter").SetArg("x", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.Setfunction(Id);
        /// </summary>
        [Fact]
        public void CurveSetfunctionTest()
        {

            // Curve.Setfunction(id);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Setfunction(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "setfunction").SetArg("id", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.Begintransition();
        /// </summary>
        [Fact]
        public void CurveBegintransitionTest()
        {

            // Curve.Begintransition();
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begintransition();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "begintransition")
                    }));
        }

        /// <summary>
        /// Curve.Begin(Radius, Cant?);
        /// </summary>
        [Fact]
        public void CurveBeginTest()
        {

            // Curve.Begin(radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "begin").SetArg("radius", 1.0)
                    }));

            // Curve.Begin(radius, cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begin(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "begin").SetArg("radius", 1.0).SetArg("cant", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.Begincircular(Radius, Cant?);
        /// </summary>
        [Fact]
        public void CurveBegincircularTest()
        {

            // Curve.Begincircular(radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begincircular(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "begincircular").SetArg("radius", 1.0)
                    }));

            // Curve.Begincircular(radius, cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begincircular(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "begincircular").SetArg("radius", 1.0).SetArg("cant", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.End();
        /// </summary>
        [Fact]
        public void CurveEndTest()
        {

            // Curve.End();
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.End();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "end")
                    }));
        }

        /// <summary>
        /// Curve.Interpolate(Radius?, Cant?);
        /// </summary>
        [Fact]
        public void CurveInterpolateTest()
        {

            // Curve.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "interpolate")
                    }));

            // Curve.Interpolate(radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "interpolate").SetArg("radius", 1.0)
                    }));

            // Curve.Interpolate(radius, cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "interpolate").SetArg("radius", 1.0).SetArg("cant", 1.0)
                    }));
        }

        /// <summary>
        /// Curve.Change(Radius);
        /// </summary>
        [Fact]
        public void CurveChangeTest()
        {

            // Curve.Change(radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "curve", "change").SetArg("radius", 1.0)
                    }));
        }

        /// <summary>
        /// Gradient.Begintransition();
        /// </summary>
        [Fact]
        public void GradientBegintransitionTest()
        {

            // Gradient.Begintransition();
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Begintransition();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "gradient", "begintransition")
                    }));
        }

        /// <summary>
        /// Gradient.Begin(Gradient);
        /// </summary>
        [Fact]
        public void GradientBeginTest()
        {

            // Gradient.Begin(gradient);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "gradient", "begin").SetArg("gradient", 1.0)
                    }));
        }

        /// <summary>
        /// Gradient.Beginconst(Gradient);
        /// </summary>
        [Fact]
        public void GradientBeginconstTest()
        {

            // Gradient.Beginconst(gradient);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Beginconst(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "gradient", "beginconst").SetArg("gradient", 1.0)
                    }));
        }

        /// <summary>
        /// Gradient.End();
        /// </summary>
        [Fact]
        public void GradientEndTest()
        {

            // Gradient.End();
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.End();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "gradient", "end")
                    }));
        }

        /// <summary>
        /// Gradient.Interpolate(Gradient?);
        /// </summary>
        [Fact]
        public void GradientInterpolateTest()
        {

            // Gradient.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "gradient", "interpolate")
                    }));

            // Gradient.Interpolate(gradient);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "gradient", "interpolate").SetArg("gradient", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].X.Interpolate(X?, Radius?);
        /// </summary>
        [Fact]
        public void TrackXInterpolateTest()
        {

            // Track[TrackKey].X.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "x", "TrackKey", "interpolate")
                    }));

            // Track[TrackKey].X.Interpolate(x);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "x", "TrackKey", "interpolate").SetArg("x", 1.0)
                    }));

            // Track[TrackKey].X.Interpolate(x, radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "x", "TrackKey", "interpolate").SetArg("x", 1.0).SetArg("radius", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Y.Interpolate(Y?, Radius?);
        /// </summary>
        [Fact]
        public void TrackYInterpolateTest()
        {

            // Track[TrackKey].Y.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "y", "TrackKey", "interpolate")
                    }));

            // Track[TrackKey].Y.Interpolate(y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "y", "TrackKey", "interpolate").SetArg("y", 1.0)
                    }));

            // Track[TrackKey].Y.Interpolate(y, radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "y", "TrackKey", "interpolate").SetArg("y", 1.0).SetArg("radius", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Position(X, Y, RadiusH?, RadiusV?);
        /// </summary>
        [Fact]
        public void TrackPositionTest()
        {

            // Track[TrackKey].Position(x, y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Position(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "TrackKey", "position").SetArg("x", 1.0).SetArg("y", 1.0)
                    }));

            // Track[TrackKey].Position(x, y, radiush);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Position(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "TrackKey", "position").SetArg("x", 1.0).SetArg("y", 1.0).SetArg("radiush", 1.0)
                    }));

            // Track[TrackKey].Position(x, y, radiush, radiusv);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Position(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "TrackKey", "position").SetArg("x", 1.0).SetArg("y", 1.0).SetArg("radiush", 1.0).SetArg("radiusv", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Setgauge(Gauge);
        /// </summary>
        [Fact]
        public void TrackCantSetgaugeTest()
        {

            // Track[TrackKey].Cant.Setgauge(gauge);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setgauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "setgauge").SetArg("gauge", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Gauge(Gauge);
        /// </summary>
        [Fact]
        public void TrackGaugeTest()
        {

            // Track[TrackKey].Gauge(gauge);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Gauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "TrackKey", "gauge").SetArg("gauge", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Setcenter(X);
        /// </summary>
        [Fact]
        public void TrackCantSetcenterTest()
        {

            // Track[TrackKey].Cant.Setcenter(x);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setcenter(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "setcenter").SetArg("x", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Setfunction(Id);
        /// </summary>
        [Fact]
        public void TrackCantSetfunctionTest()
        {

            // Track[TrackKey].Cant.Setfunction(id);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setfunction(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "setfunction").SetArg("id", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Begintransition();
        /// </summary>
        [Fact]
        public void TrackCantBegintransitionTest()
        {

            // Track[TrackKey].Cant.Begintransition();
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Begintransition();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "begintransition")
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Begin(Cant);
        /// </summary>
        [Fact]
        public void TrackCantBeginTest()
        {

            // Track[TrackKey].Cant.Begin(cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "begin").SetArg("cant", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.End();
        /// </summary>
        [Fact]
        public void TrackCantEndTest()
        {

            // Track[TrackKey].Cant.End();
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.End();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "end")
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Interpolate(Cant?);
        /// </summary>
        [Fact]
        public void TrackCantInterpolateTest()
        {

            // Track[TrackKey].Cant.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "interpolate")
                    }));

            // Track[TrackKey].Cant.Interpolate(cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "cant", "TrackKey", "interpolate").SetArg("cant", 1.0)
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant(Cant?);
        /// </summary>
        [Fact]
        public void TrackCantTest()
        {

            // Track[TrackKey].Cant();
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "TrackKey", "cant")
                    }));

            // Track[TrackKey].Cant(cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "track", "TrackKey", "cant").SetArg("cant", 1.0)
                    }));
        }

        /// <summary>
        /// Structure.Load(FilePath);
        /// </summary>
        [Fact]
        public void StructureLoadTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Structure.Load(FilePath)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
        /// </summary>
        [Fact]
        public void StructurePutTest()
        {

            // Structure[StructureKey].Put(trackkey, x, y, z, rx, ry, rz, tilt, span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Put(1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "structure", "StructureKey", "put").SetArg("trackkey", 1.0).SetArg("x", 1.0).SetArg("y", 1.0).SetArg("z", 1.0).SetArg("rx", 1.0).SetArg("ry", 1.0).SetArg("rz", 1.0).SetArg("tilt", 1.0).SetArg("span", 1.0)
                    }));
        }

        /// <summary>
        /// Structure[StructureKey].Put0(TrackKey, Tilt, Span);
        /// </summary>
        [Fact]
        public void StructurePut0Test()
        {

            // Structure[StructureKey].Put0(trackkey, tilt, span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Put0(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "structure", "StructureKey", "put0").SetArg("trackkey", 1.0).SetArg("tilt", 1.0).SetArg("span", 1.0)
                    }));
        }

        /// <summary>
        /// Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag?);
        /// </summary>
        [Fact]
        public void StructurePutbetweenTest()
        {

            // Structure[StructureKey].Putbetween(trackkey1, trackkey2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Putbetween(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "structure", "StructureKey", "putbetween").SetArg("trackkey1", 1.0).SetArg("trackkey2", 1.0)
                    }));

            // Structure[StructureKey].Putbetween(trackkey1, trackkey2, flag);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Putbetween(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "structure", "StructureKey", "putbetween").SetArg("trackkey1", 1.0).SetArg("trackkey2", 1.0).SetArg("flag", 1.0)
                    }));
        }

        /// <summary>
        /// Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
        /// </summary>
        [Fact]
        public void RepeaterBeginTest()
        {

            // Repeater[RepeaterKey].Begin(trackkey, x, y, z, rx, ry, rz, tilt, span, interval);
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin(1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "repeater", "RepeaterKey", "begin").SetArg("trackkey", 1.0).SetArg("x", 1.0).SetArg("y", 1.0).SetArg("z", 1.0).SetArg("rx", 1.0).SetArg("ry", 1.0).SetArg("rz", 1.0).SetArg("tilt", 1.0).SetArg("span", 1.0).SetArg("interval", 1.0)
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
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin0(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "repeater", "RepeaterKey", "begin0").SetArg("trackkey", 1.0).SetArg("tilt", 1.0).SetArg("span", 1.0).SetArg("interval", 1.0)
                    }));
        }

        /// <summary>
        /// Repeater[RepeaterKey].End();
        /// </summary>
        [Fact]
        public void RepeaterEndTest()
        {

            // Repeater[RepeaterKey].End();
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].End();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "repeater", "RepeaterKey", "end")
                    }));
        }

        /// <summary>
        /// Background.Change(StructureKey);
        /// </summary>
        [Fact]
        public void BackgroundChangeTest()
        {

            // Background.Change(structurekey);
            Check(
                ExecParse("BveTs Map 2.02\n0;Background.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "background", "change").SetArg("structurekey", 1.0)
                    }));
        }

        /// <summary>
        /// Station.Load(FilePath);
        /// </summary>
        [Fact]
        public void StationLoadTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Station.Load(FilePath)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Station[StationKey].Put(Door, Margin1, Margin2);
        /// </summary>
        [Fact]
        public void StationPutTest()
        {

            // Station[StationKey].Put(door, margin1, margin2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Station['StationKey'].Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "station", "StationKey", "put").SetArg("door", 1.0).SetArg("margin1", 1.0).SetArg("margin2", 1.0)
                    }));
        }

        /// <summary>
        /// Section.Begin();
        /// </summary>
        [Fact]
        public void SectionBeginTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Section.Begin()構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Section.Beginnew();
        /// </summary>
        [Fact]
        public void SectionBeginnewTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Section.Beginnew()構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Section.Setspeedlimit();
        /// </summary>
        [Fact]
        public void SectionSetspeedlimitTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Section.Setspeedlimit()構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Signal.Speedlimit();
        /// </summary>
        [Fact]
        public void SignalSpeedlimitTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Signal.Speedlimit()構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Signal.Load(FilePath);
        /// </summary>
        [Fact]
        public void SignalLoadTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Signal.Load(FilePath)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z?, RX?, RY?, RZ?, Tilt?, Span?);
        /// </summary>
        [Fact]
        public void SignalPutTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z?, RX?, RY?, RZ?, Tilt?, Span?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Beacon.Put(Type, Section, Senddata);
        /// </summary>
        [Fact]
        public void BeaconPutTest()
        {

            // Beacon.Put(type, section, senddata);
            Check(
                ExecParse("BveTs Map 2.02\n0;Beacon.Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "beacon", "put").SetArg("type", 1.0).SetArg("section", 1.0).SetArg("senddata", 1.0)
                    }));
        }

        /// <summary>
        /// Speedlimit.Begin(V);
        /// </summary>
        [Fact]
        public void SpeedlimitBeginTest()
        {

            // Speedlimit.Begin(v);
            Check(
                ExecParse("BveTs Map 2.02\n0;Speedlimit.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "speedlimit", "begin").SetArg("v", 1.0)
                    }));
        }

        /// <summary>
        /// Speedlimit.End();
        /// </summary>
        [Fact]
        public void SpeedlimitEndTest()
        {

            // Speedlimit.End();
            Check(
                ExecParse("BveTs Map 2.02\n0;Speedlimit.End();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "speedlimit", "end")
                    }));
        }

        /// <summary>
        /// Pretrain.Pass(Time?, Second?);
        /// </summary>
        [Fact]
        public void PretrainPassTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Pretrain.Pass(Time?, Second?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Light.Ambient(Red, Green, Blue);
        /// </summary>
        [Fact]
        public void LightAmbientTest()
        {

            // Light.Ambient(red, green, blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Light.Ambient(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "light", "ambient").SetArg("red", 1.0).SetArg("green", 1.0).SetArg("blue", 1.0)
                    }));
        }

        /// <summary>
        /// Light.Diffuse(Red, Green, Blue);
        /// </summary>
        [Fact]
        public void LightDiffuseTest()
        {

            // Light.Diffuse(red, green, blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Light.Diffuse(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "light", "diffuse").SetArg("red", 1.0).SetArg("green", 1.0).SetArg("blue", 1.0)
                    }));
        }

        /// <summary>
        /// Fog.Interpolate(Density?, Red?, Green?, Blue?);
        /// </summary>
        [Fact]
        public void FogInterpolateTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Fog.Interpolate(Density?, Red?, Green?, Blue?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Fog.Set(Density?, Red?, Green?, Blue?);
        /// </summary>
        [Fact]
        public void FogSetTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Fog.Set(Density?, Red?, Green?, Blue?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Drawdistance.Change(Value);
        /// </summary>
        [Fact]
        public void DrawdistanceChangeTest()
        {

            // Drawdistance.Change(value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Drawdistance.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "drawdistance", "change").SetArg("value", 1.0)
                    }));
        }

        /// <summary>
        /// Cabilluminance.Interpolate(Value?);
        /// </summary>
        [Fact]
        public void CabilluminanceInterpolateTest()
        {

            // Cabilluminance.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "cabilluminance", "interpolate")
                    }));

            // Cabilluminance.Interpolate(value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "cabilluminance", "interpolate").SetArg("value", 1.0)
                    }));
        }

        /// <summary>
        /// Cabilluminance.Set(Value?);
        /// </summary>
        [Fact]
        public void CabilluminanceSetTest()
        {

            // Cabilluminance.Set();
            Check(
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Set();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "cabilluminance", "set")
                    }));

            // Cabilluminance.Set(value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Set(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "cabilluminance", "set").SetArg("value", 1.0)
                    }));
        }

        /// <summary>
        /// Irregularity.Change(X, Y, R, LX, LY, LR);
        /// </summary>
        [Fact]
        public void IrregularityChangeTest()
        {

            // Irregularity.Change(x, y, r, lx, ly, lr);
            Check(
                ExecParse("BveTs Map 2.02\n0;Irregularity.Change(1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "irregularity", "change").SetArg("x", 1.0).SetArg("y", 1.0).SetArg("r", 1.0).SetArg("lx", 1.0).SetArg("ly", 1.0).SetArg("lr", 1.0)
                    }));
        }

        /// <summary>
        /// Adhesion.Change(A, B?, C?);
        /// </summary>
        [Fact]
        public void AdhesionChangeTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Adhesion.Change(A, B?, C?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Sound.Load(FilePath);
        /// </summary>
        [Fact]
        public void SoundLoadTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Sound.Load(FilePath)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Sound[SoundKey].Play();
        /// </summary>
        [Fact]
        public void SoundPlayTest()
        {

            // Sound[SoundKey].Play();
            Check(
                ExecParse("BveTs Map 2.02\n0;Sound['SoundKey'].Play();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "sound", "SoundKey", "play")
                    }));
        }

        /// <summary>
        /// Sound3d.Load(FilePath);
        /// </summary>
        [Fact]
        public void Sound3dLoadTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Sound3d.Load(FilePath)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Sound3d[SoundKey].Put(X, Y);
        /// </summary>
        [Fact]
        public void Sound3dPutTest()
        {

            // Sound3d[SoundKey].Put(x, y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Sound3d['SoundKey'].Put(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "sound3d", "SoundKey", "put").SetArg("x", 1.0).SetArg("y", 1.0)
                    }));
        }

        /// <summary>
        /// Rollingnoise.Change(Index);
        /// </summary>
        [Fact]
        public void RollingnoiseChangeTest()
        {

            // Rollingnoise.Change(index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Rollingnoise.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "rollingnoise", "change").SetArg("index", 1.0)
                    }));
        }

        /// <summary>
        /// Flangenoise.Change(Index);
        /// </summary>
        [Fact]
        public void FlangenoiseChangeTest()
        {

            // Flangenoise.Change(index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Flangenoise.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "flangenoise", "change").SetArg("index", 1.0)
                    }));
        }

        /// <summary>
        /// Jointnoise.Play(Index);
        /// </summary>
        [Fact]
        public void JointnoisePlayTest()
        {

            // Jointnoise.Play(index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Jointnoise.Play(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "jointnoise", "play").SetArg("index", 1.0)
                    }));
        }

        /// <summary>
        /// Train.Add(TrainKey, FilePath, TrackKey, Direction);
        /// </summary>
        [Fact]
        public void TrainAddTest()
        {

            // Train.Add(trainkey, filepath, trackkey, direction);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train.Add(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "train", "add").SetArg("trainkey", 1.0).SetArg("filepath", 1.0).SetArg("trackkey", 1.0).SetArg("direction", 1.0)
                    }));
        }

        /// <summary>
        /// Train[TrainKey].Load(FilePath, TrackKey, Direction);
        /// </summary>
        [Fact]
        public void TrainLoadTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Train[TrainKey].Load(FilePath, TrackKey, Direction)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Train[TrainKey].Enable(Time?, Second?);
        /// </summary>
        [Fact]
        public void TrainEnableTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Train[TrainKey].Enable(Time?, Second?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
        /// </summary>
        [Fact]
        public void TrainStopTest()
        {

            // Train[TrainKey].Stop(decelerate, stoptime, accelerate, speed);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['TrainKey'].Stop(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<SyntaxData>()
                    {
                        new SyntaxData(0, "train", "TrainKey", "stop").SetArg("decelerate", 1.0).SetArg("stoptime", 1.0).SetArg("accelerate", 1.0).SetArg("speed", 1.0)
                    }));
        }
        #endregion
    }
}
