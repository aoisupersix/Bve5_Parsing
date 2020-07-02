/*
 * このファイルはdoc/createMapGrammarTemplate.jsによって自動生成されています。
 * 編集は行わないでください。
 */
using System;
using Xunit;
using Bve5_Parsing.MapGrammar;
using Bve5_Parsing.MapGrammar.EvaluateData;
using static Bve5_ParsingTests.MapGrammarTestUtility;
using System.Collections.Generic;

namespace Bve5_ParsingTests
{
    public class MapGrammarSyntaxTests
    {

        #region 各構文のテスト

        /// <summary>
        /// Curve.Setgauge(Value);
        /// </summary>
        [Fact]
        public void CurveSetgaugeTest()
        {

            // Curve.Setgauge(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Setgauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveSetgaugeStatement(0)
                        {
                            Value = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Gauge.Set(Value);
        /// </summary>
        [Fact]
        public void GaugeSetTest()
        {

            // Gauge.Set(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gauge.Set(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GaugeSetStatement(0)
                        {
                            Value = 1.0
                        }
                    }));

            // Gauge.Set(Value);
            Check(
                ExecParse("BveTs Map 2.00\n0;Gauge.Set(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new GaugeSetStatement(0)
                        {
                            Value = 1.0
                        }
                    }));

            // Gauge.Set(Value);
            Check(
                ExecParse("BveTs Map 1.00\n0;Gauge.Set(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new GaugeSetStatement(0)
                        {
                            Value = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Curve.Gauge(Value);
        /// </summary>
        [Fact]
        public void CurveGaugeTest()
        {

            // Curve.Gauge(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Gauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveGaugeStatement(0)
                        {
                            Value = 1.0
                        }
                    }));

            // Curve.Gauge(Value);
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.Gauge(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveGaugeStatement(0)
                        {
                            Value = 1.0
                        }
                    }));

            // Curve.Gauge(Value);
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.Gauge(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveGaugeStatement(0)
                        {
                            Value = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Curve.Setcenter(X);
        /// </summary>
        [Fact]
        public void CurveSetcenterTest()
        {

            // Curve.Setcenter(X);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Setcenter(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveSetcenterStatement(0)
                        {
                            X = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Curve.Setfunction(Id);
        /// </summary>
        [Fact]
        public void CurveSetfunctionTest()
        {

            // Curve.Setfunction(Id);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Setfunction(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveSetfunctionStatement(0)
                        {
                            Id = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegintransitionStatement(0)
                        {
                        }
                    }));

            // Curve.Begintransition();
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.Begintransition();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegintransitionStatement(0)
                        {
                        }
                    }));

            // Curve.Begintransition();
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.Begintransition();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegintransitionStatement(0)
                        {
                        }
                    }));
        }

        /// <summary>
        /// Curve.Begin(Radius, Cant?);
        /// </summary>
        [Fact]
        public void CurveBeginTest()
        {

            // Curve.Begin(Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBeginStatement(0)
                        {
                            Radius = 1.0
                        }
                    }));

            // Curve.Begin(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begin(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBeginStatement(0)
                        {
                            Radius = 1.0,
                            Cant = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Curve.Begincircular(Radius, Cant?);
        /// </summary>
        [Fact]
        public void CurveBegincircularTest()
        {

            // Curve.Begincircular(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begincircular(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1.0,
                            Cant = 1.0
                        }
                    }));

            // Curve.Begincircular(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.Begincircular(1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1.0,
                            Cant = 1.0
                        }
                    }));

            // Curve.Begincircular(Radius, Cant);
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.Begincircular(1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1.0,
                            Cant = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new CurveEndStatement(0)
                        {
                        }
                    }));

            // Curve.End();
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.End();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveEndStatement(0)
                        {
                        }
                    }));

            // Curve.End();
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.End();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveEndStatement(0)
                        {
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new CurveInterpolateStatement(0)
                        {
                        }
                    }));

            // Curve.Interpolate(Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveInterpolateStatement(0)
                        {
                            Radius = 1.0
                        }
                    }));

            // Curve.Interpolate(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveInterpolateStatement(0)
                        {
                            Radius = 1.0,
                            Cant = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Curve.Change(Radius);
        /// </summary>
        [Fact]
        public void CurveChangeTest()
        {

            // Curve.Change(Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveChangeStatement(0)
                        {
                            Radius = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new GradientBegintransitionStatement(0)
                        {
                        }
                    }));

            // Gradient.Begintransition();
            Check(
                ExecParse("BveTs Map 2.00\n0;Gradient.Begintransition();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBegintransitionStatement(0)
                        {
                        }
                    }));

            // Gradient.Begintransition();
            Check(
                ExecParse("BveTs Map 1.00\n0;Gradient.Begintransition();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBegintransitionStatement(0)
                        {
                        }
                    }));
        }

        /// <summary>
        /// Gradient.Begin(Gradient);
        /// </summary>
        [Fact]
        public void GradientBeginTest()
        {

            // Gradient.Begin(Gradient);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginStatement(0)
                        {
                            Gradient = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Gradient.Beginconst(Gradient);
        /// </summary>
        [Fact]
        public void GradientBeginconstTest()
        {

            // Gradient.Beginconst(Gradient);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Beginconst(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginconstStatement(0)
                        {
                            Gradient = 1.0
                        }
                    }));

            // Gradient.Beginconst(Gradient);
            Check(
                ExecParse("BveTs Map 2.00\n0;Gradient.Beginconst(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginconstStatement(0)
                        {
                            Gradient = 1.0
                        }
                    }));

            // Gradient.Beginconst(Gradient);
            Check(
                ExecParse("BveTs Map 1.00\n0;Gradient.Beginconst(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginconstStatement(0)
                        {
                            Gradient = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new GradientEndStatement(0)
                        {
                        }
                    }));

            // Gradient.End();
            Check(
                ExecParse("BveTs Map 2.00\n0;Gradient.End();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientEndStatement(0)
                        {
                        }
                    }));

            // Gradient.End();
            Check(
                ExecParse("BveTs Map 1.00\n0;Gradient.End();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientEndStatement(0)
                        {
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new GradientInterpolateStatement(0)
                        {
                        }
                    }));

            // Gradient.Interpolate(Gradient);
            Check(
                ExecParse("BveTs Map 2.02\n0;Gradient.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GradientInterpolateStatement(0)
                        {
                            Gradient = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new TrackXInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));

            // Track[TrackKey].X.Interpolate(X);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackXInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1.0
                        }
                    }));

            // Track[TrackKey].X.Interpolate(X, Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackXInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1.0,
                            Radius = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new TrackYInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));

            // Track[TrackKey].Y.Interpolate(Y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackYInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            Y = 1.0
                        }
                    }));

            // Track[TrackKey].Y.Interpolate(Y, Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackYInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            Y = 1.0,
                            Radius = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Position(X, Y, RadiusH?, RadiusV?);
        /// </summary>
        [Fact]
        public void TrackPositionTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Track[TrackKey].Position(X, Y, RadiusH?, RadiusV?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Track[TrackKey].Cant.Setgauge(Gauge);
        /// </summary>
        [Fact]
        public void TrackCantSetgaugeTest()
        {

            // Track[TrackKey].Cant.Setgauge(Gauge);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setgauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantSetgaugeStatement(0)
                        {
                            Key = "TrackKey",
                            Gauge = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Gauge(Gauge);
        /// </summary>
        [Fact]
        public void TrackGaugeTest()
        {

            // Track[TrackKey].Gauge(Gauge);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Gauge(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackGaugeStatement(0)
                        {
                            Key = "TrackKey",
                            Gauge = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Setcenter(X);
        /// </summary>
        [Fact]
        public void TrackCantSetcenterTest()
        {

            // Track[TrackKey].Cant.Setcenter(X);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setcenter(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantSetcenterStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Setfunction(Id);
        /// </summary>
        [Fact]
        public void TrackCantSetfunctionTest()
        {

            // Track[TrackKey].Cant.Setfunction(Id);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setfunction(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantSetfunctionStatement(0)
                        {
                            Key = "TrackKey",
                            Id = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantBegintransitionStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant.Begin(Cant);
        /// </summary>
        [Fact]
        public void TrackCantBeginTest()
        {

            // Track[TrackKey].Cant.Begin(Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantBeginStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantEndStatement(0)
                        {
                            Key = "TrackKey",
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));

            // Track[TrackKey].Cant.Interpolate(Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Track[TrackKey].Cant(Cant?);
        /// </summary>
        [Fact]
        public void TrackCantTest()
        {

            // Track[TrackKey].Cant(Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1.0
                        }
                    }));

            // Track[TrackKey].Cant(Cant);
            Check(
                ExecParse("BveTs Map 2.00\n0;Track['TrackKey'].Cant(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1.0
                        }
                    }));

            // Track[TrackKey].Cant(Cant);
            Check(
                ExecParse("BveTs Map 1.00\n0;Track[TrackKey].Cant(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1.0
                        }
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

            // Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Put('string_test_value', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));

            // Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.00\n0;Structure['StructureKey'].Put('string_test_value', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));

            // Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 1.00\n0;Structure[StructureKey].Put(string_test_value, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Structure[StructureKey].Put0(TrackKey, Tilt, Span);
        /// </summary>
        [Fact]
        public void StructurePut0Test()
        {

            // Structure[StructureKey].Put0(TrackKey, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Put0('string_test_value', 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePut0Statement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));

            // Structure[StructureKey].Put0(TrackKey, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.00\n0;Structure['StructureKey'].Put0('string_test_value', 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePut0Statement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));

            // Structure[StructureKey].Put0(TrackKey, Tilt, Span);
            Check(
                ExecParse("BveTs Map 1.00\n0;Structure[StructureKey].Put0(string_test_value, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePut0Statement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag?);
        /// </summary>
        [Fact]
        public void StructurePutbetweenTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Structure[StructureKey].Putbetween(TrackKey1, TrackKey2, Flag?)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval, StructureKey);
        /// </summary>
        [Fact]
        public void RepeaterBeginTest()
        {

            // Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval, StructureKey);
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin('string_test_value', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0,
                            Interval = 1.0,
                        }
                        .SetStructureKeys("string_test_value", "string_test_value", "string_test_value", "string_test_value", "string_test_value")
                    }));

            // Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval, StructureKey);
            Check(
                ExecParse("BveTs Map 2.00\n0;Repeater['RepeaterKey'].Begin('string_test_value', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0,
                            Interval = 1.0,
                        }
                        .SetStructureKeys("string_test_value", "string_test_value", "string_test_value", "string_test_value", "string_test_value")
                    }));

            // Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval, StructureKey);
            Check(
                ExecParse("BveTs Map 1.00\n0;Repeater[RepeaterKey].Begin(string_test_value, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, string_test_value, string_test_value, string_test_value, string_test_value, string_test_value);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0,
                            Interval = 1.0,
                        }
                        .SetStructureKeys("string_test_value", "string_test_value", "string_test_value", "string_test_value", "string_test_value")
                    }));
        }

        /// <summary>
        /// Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval, StructureKey);
        /// </summary>
        [Fact]
        public void RepeaterBegin0Test()
        {

            // Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval, StructureKey);
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin0('string_test_value', 1.0, 1.0, 1.0, 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            Tilt = 1.0,
                            Span = 1.0,
                            Interval = 1.0,
                        }
                        .SetStructureKeys("string_test_value", "string_test_value", "string_test_value", "string_test_value", "string_test_value")
                    }));

            // Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval, StructureKey);
            Check(
                ExecParse("BveTs Map 2.00\n0;Repeater['RepeaterKey'].Begin0('string_test_value', 1.0, 1.0, 1.0, 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            Tilt = 1.0,
                            Span = 1.0,
                            Interval = 1.0,
                        }
                        .SetStructureKeys("string_test_value", "string_test_value", "string_test_value", "string_test_value", "string_test_value")
                    }));

            // Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval, StructureKey);
            Check(
                ExecParse("BveTs Map 1.00\n0;Repeater[RepeaterKey].Begin0(string_test_value, 1.0, 1.0, 1.0, string_test_value, string_test_value, string_test_value, string_test_value, string_test_value);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            Tilt = 1.0,
                            Span = 1.0,
                            Interval = 1.0,
                        }
                        .SetStructureKeys("string_test_value", "string_test_value", "string_test_value", "string_test_value", "string_test_value")
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
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterEndStatement(0)
                        {
                            Key = "RepeaterKey",
                        }
                    }));

            // Repeater[RepeaterKey].End();
            Check(
                ExecParse("BveTs Map 2.00\n0;Repeater['RepeaterKey'].End();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterEndStatement(0)
                        {
                            Key = "RepeaterKey",
                        }
                    }));

            // Repeater[RepeaterKey].End();
            Check(
                ExecParse("BveTs Map 1.00\n0;Repeater[RepeaterKey].End();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterEndStatement(0)
                        {
                            Key = "RepeaterKey",
                        }
                    }));
        }

        /// <summary>
        /// Background.Change(StructureKey);
        /// </summary>
        [Fact]
        public void BackgroundChangeTest()
        {

            // Background.Change(StructureKey);
            Check(
                ExecParse("BveTs Map 2.02\n0;Background.Change('string_test_value');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new BackgroundChangeStatement(0)
                        {
                            StructureKey = "string_test_value"
                        }
                    }));

            // Background.Change(StructureKey);
            Check(
                ExecParse("BveTs Map 2.00\n0;Background.Change('string_test_value');"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new BackgroundChangeStatement(0)
                        {
                            StructureKey = "string_test_value"
                        }
                    }));

            // Background.Change(StructureKey);
            Check(
                ExecParse("BveTs Map 1.00\n0;Background.Change(string_test_value);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new BackgroundChangeStatement(0)
                        {
                            StructureKey = "string_test_value"
                        }
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

            // Station[StationKey].Put(Door, Margin1, Margin2);
            Check(
                ExecParse("BveTs Map 2.02\n0;Station['StationKey'].Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StationPutStatement(0)
                        {
                            Key = "StationKey",
                            Door = 1.0,
                            Margin1 = 1.0,
                            Margin2 = 1.0
                        }
                    }));

            // Station[StationKey].Put(Door, Margin1, Margin2);
            Check(
                ExecParse("BveTs Map 2.00\n0;Station['StationKey'].Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StationPutStatement(0)
                        {
                            Key = "StationKey",
                            Door = 1.0,
                            Margin1 = 1.0,
                            Margin2 = 1.0
                        }
                    }));

            // Station[StationKey].Put(Door, Margin1, Margin2);
            Check(
                ExecParse("BveTs Map 1.00\n0;Station[StationKey].Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StationPutStatement(0)
                        {
                            Key = "StationKey",
                            Door = 1.0,
                            Margin1 = 1.0,
                            Margin2 = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Section.Begin(Signal);
        /// </summary>
        [Fact]
        public void SectionBeginTest()
        {

            // Section.Begin(Signal);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Begin(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginStatement(0)
                        {
                        }
                        .SetSignals(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));
        }

        /// <summary>
        /// Section.Beginnew(Signal);
        /// </summary>
        [Fact]
        public void SectionBeginnewTest()
        {

            // Section.Beginnew(Signal);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Beginnew(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginnewStatement(0)
                        {
                        }
                        .SetSignals(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));

            // Section.Beginnew(Signal);
            Check(
                ExecParse("BveTs Map 2.00\n0;Section.Beginnew(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginnewStatement(0)
                        {
                        }
                        .SetSignals(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));

            // Section.Beginnew(Signal);
            Check(
                ExecParse("BveTs Map 1.00\n0;Section.Beginnew(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SectionBeginnewStatement(0)
                        {
                        }
                        .SetSignals(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));
        }

        /// <summary>
        /// Section.Setspeedlimit(V);
        /// </summary>
        [Fact]
        public void SectionSetspeedlimitTest()
        {

            // Section.Setspeedlimit(V);
            Check(
                ExecParse("BveTs Map 2.02\n0;Section.Setspeedlimit(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SectionSetspeedlimitStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));
        }

        /// <summary>
        /// Signal.Speedlimit(V);
        /// </summary>
        [Fact]
        public void SignalSpeedlimitTest()
        {

            // Signal.Speedlimit(V);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal.Speedlimit(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SignalSpeedlimitStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));

            // Signal.Speedlimit(V);
            Check(
                ExecParse("BveTs Map 2.00\n0;Signal.Speedlimit(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SignalSpeedlimitStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));

            // Signal.Speedlimit(V);
            Check(
                ExecParse("BveTs Map 1.00\n0;Signal.Speedlimit(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SignalSpeedlimitStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));
        }

        /// <summary>
        /// Speedlimit.Setsignal(V);
        /// </summary>
        [Fact]
        public void SpeedlimitSetsignalTest()
        {

            // Speedlimit.Setsignal(V);
            Check(
                ExecParse("BveTs Map 2.02\n0;Speedlimit.Setsignal(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitSetsignalStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));

            // Speedlimit.Setsignal(V);
            Check(
                ExecParse("BveTs Map 2.00\n0;Speedlimit.Setsignal(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitSetsignalStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));

            // Speedlimit.Setsignal(V);
            Check(
                ExecParse("BveTs Map 1.00\n0;Speedlimit.Setsignal(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitSetsignalStatement(0)
                        {
                        }
                        .SetVs(1.0, 1.0, 1.0, 1.0, 1.0)
                    }));
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

            // Signal[SignalAspectKey].Put(Section, TrackKey, X, Y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal['SignalAspectKey'].Put(1.0, 'string_test_value', 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "SignalAspectKey",
                            Section = 1.0,
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0
                        }
                    }));

            // Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.02\n0;Signal['SignalAspectKey'].Put(1.0, 'string_test_value', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "SignalAspectKey",
                            Section = 1.0,
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));

            // Signal[SignalAspectKey].Put(Section, TrackKey, X, Y);
            Check(
                ExecParse("BveTs Map 2.00\n0;Signal['SignalAspectKey'].Put(1.0, 'string_test_value', 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "SignalAspectKey",
                            Section = 1.0,
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0
                        }
                    }));

            // Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.00\n0;Signal['SignalAspectKey'].Put(1.0, 'string_test_value', 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "SignalAspectKey",
                            Section = 1.0,
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));

            // Signal[SignalAspectKey].Put(Section, TrackKey, X, Y);
            Check(
                ExecParse("BveTs Map 1.00\n0;Signal[SignalAspectKey].Put(1.0, string_test_value, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "SignalAspectKey",
                            Section = 1.0,
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0
                        }
                    }));

            // Signal[SignalAspectKey].Put(Section, TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 1.00\n0;Signal[SignalAspectKey].Put(1.0, string_test_value, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SignalPutStatement(0)
                        {
                            Key = "SignalAspectKey",
                            Section = 1.0,
                            TrackKey = "string_test_value",
                            X = 1.0,
                            Y = 1.0,
                            Z = 1.0,
                            RX = 1.0,
                            RY = 1.0,
                            RZ = 1.0,
                            Tilt = 1.0,
                            Span = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Beacon.Put(Type, Section, Senddata);
        /// </summary>
        [Fact]
        public void BeaconPutTest()
        {

            // Beacon.Put(Type, Section, Senddata);
            Check(
                ExecParse("BveTs Map 2.02\n0;Beacon.Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new BeaconPutStatement(0)
                        {
                            Type = 1.0,
                            Section = 1.0,
                            Senddata = 1.0
                        }
                    }));

            // Beacon.Put(Type, Section, Senddata);
            Check(
                ExecParse("BveTs Map 2.00\n0;Beacon.Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new BeaconPutStatement(0)
                        {
                            Type = 1.0,
                            Section = 1.0,
                            Senddata = 1.0
                        }
                    }));

            // Beacon.Put(Type, Section, Senddata);
            Check(
                ExecParse("BveTs Map 1.00\n0;Beacon.Put(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new BeaconPutStatement(0)
                        {
                            Type = 1.0,
                            Section = 1.0,
                            Senddata = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Speedlimit.Begin(V);
        /// </summary>
        [Fact]
        public void SpeedlimitBeginTest()
        {

            // Speedlimit.Begin(V);
            Check(
                ExecParse("BveTs Map 2.02\n0;Speedlimit.Begin(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitBeginStatement(0)
                        {
                            V = 1.0
                        }
                    }));

            // Speedlimit.Begin(V);
            Check(
                ExecParse("BveTs Map 2.00\n0;Speedlimit.Begin(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitBeginStatement(0)
                        {
                            V = 1.0
                        }
                    }));

            // Speedlimit.Begin(V);
            Check(
                ExecParse("BveTs Map 1.00\n0;Speedlimit.Begin(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitBeginStatement(0)
                        {
                            V = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitEndStatement(0)
                        {
                        }
                    }));

            // Speedlimit.End();
            Check(
                ExecParse("BveTs Map 2.00\n0;Speedlimit.End();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitEndStatement(0)
                        {
                        }
                    }));

            // Speedlimit.End();
            Check(
                ExecParse("BveTs Map 1.00\n0;Speedlimit.End();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitEndStatement(0)
                        {
                        }
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

            // Light.Ambient(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Light.Ambient(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LightAmbientStatement(0)
                        {
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));

            // Light.Ambient(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Light.Ambient(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightAmbientStatement(0)
                        {
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));

            // Light.Ambient(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Light.Ambient(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightAmbientStatement(0)
                        {
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Light.Diffuse(Red, Green, Blue);
        /// </summary>
        [Fact]
        public void LightDiffuseTest()
        {

            // Light.Diffuse(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Light.Diffuse(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LightDiffuseStatement(0)
                        {
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));

            // Light.Diffuse(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Light.Diffuse(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDiffuseStatement(0)
                        {
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));

            // Light.Diffuse(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Light.Diffuse(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDiffuseStatement(0)
                        {
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Light.Direction(Pitch, Yaw);
        /// </summary>
        [Fact]
        public void LightDirectionTest()
        {

            // Light.Direction(Pitch, Yaw);
            Check(
                ExecParse("BveTs Map 2.02\n0;Light.Direction(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LightDirectionStatement(0)
                        {
                            Pitch = 1.0,
                            Yaw = 1.0
                        }
                    }));

            // Light.Direction(Pitch, Yaw);
            Check(
                ExecParse("BveTs Map 2.00\n0;Light.Direction(1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDirectionStatement(0)
                        {
                            Pitch = 1.0,
                            Yaw = 1.0
                        }
                    }));

            // Light.Direction(Pitch, Yaw);
            Check(
                ExecParse("BveTs Map 1.00\n0;Light.Direction(1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDirectionStatement(0)
                        {
                            Pitch = 1.0,
                            Yaw = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Fog.Interpolate(Density?, Red?, Green?, Blue?);
        /// </summary>
        [Fact]
        public void FogInterpolateTest()
        {

            // Fog.Interpolate();
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Interpolate();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogInterpolateStatement(0)
                        {
                        }
                    }));

            // Fog.Interpolate(Density);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogInterpolateStatement(0)
                        {
                            Density = 1.0
                        }
                    }));

            // Fog.Interpolate(Density, Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Interpolate(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogInterpolateStatement(0)
                        {
                            Density = 1.0,
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Fog.Set(Density?, Red?, Green?, Blue?);
        /// </summary>
        [Fact]
        public void FogSetTest()
        {

            // Fog.Set(Density, Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Fog.Set(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FogSetStatement(0)
                        {
                            Density = 1.0,
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));

            // Fog.Set(Density, Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Fog.Set(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new FogSetStatement(0)
                        {
                            Density = 1.0,
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));

            // Fog.Set(Density, Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Fog.Set(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new FogSetStatement(0)
                        {
                            Density = 1.0,
                            Red = 1.0,
                            Green = 1.0,
                            Blue = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Drawdistance.Change(Value);
        /// </summary>
        [Fact]
        public void DrawdistanceChangeTest()
        {

            // Drawdistance.Change(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Drawdistance.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new DrawdistanceChangeStatement(0)
                        {
                            Value = 1.0
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceInterpolateStatement(0)
                        {
                        }
                    }));

            // Cabilluminance.Interpolate(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Interpolate(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceInterpolateStatement(0)
                        {
                            Value = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Cabilluminance.Set(Value);
        /// </summary>
        [Fact]
        public void CabilluminanceSetTest()
        {

            // Cabilluminance.Set(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Set(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceSetStatement(0)
                        {
                            Value = 1.0
                        }
                    }));

            // Cabilluminance.Set(Value);
            Check(
                ExecParse("BveTs Map 2.00\n0;Cabilluminance.Set(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceSetStatement(0)
                        {
                            Value = 1.0
                        }
                    }));

            // Cabilluminance.Set(Value);
            Check(
                ExecParse("BveTs Map 1.00\n0;Cabilluminance.Set(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceSetStatement(0)
                        {
                            Value = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Irregularity.Change(X, Y, R, LX, LY, LR);
        /// </summary>
        [Fact]
        public void IrregularityChangeTest()
        {

            // Irregularity.Change(X, Y, R, LX, LY, LR);
            Check(
                ExecParse("BveTs Map 2.02\n0;Irregularity.Change(1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new IrregularityChangeStatement(0)
                        {
                            X = 1.0,
                            Y = 1.0,
                            R = 1.0,
                            LX = 1.0,
                            LY = 1.0,
                            LR = 1.0
                        }
                    }));

            // Irregularity.Change(X, Y, R, LX, LY, LR);
            Check(
                ExecParse("BveTs Map 2.00\n0;Irregularity.Change(1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new IrregularityChangeStatement(0)
                        {
                            X = 1.0,
                            Y = 1.0,
                            R = 1.0,
                            LX = 1.0,
                            LY = 1.0,
                            LR = 1.0
                        }
                    }));

            // Irregularity.Change(X, Y, R, LX, LY, LR);
            Check(
                ExecParse("BveTs Map 1.00\n0;Irregularity.Change(1.0, 1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new IrregularityChangeStatement(0)
                        {
                            X = 1.0,
                            Y = 1.0,
                            R = 1.0,
                            LX = 1.0,
                            LY = 1.0,
                            LR = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Adhesion.Change(A, B?, C?);
        /// </summary>
        [Fact]
        public void AdhesionChangeTest()
        {

            // Adhesion.Change(A);
            Check(
                ExecParse("BveTs Map 2.02\n0;Adhesion.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1.0
                        }
                    }));

            // Adhesion.Change(A, B, C);
            Check(
                ExecParse("BveTs Map 2.02\n0;Adhesion.Change(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1.0,
                            B = 1.0,
                            C = 1.0
                        }
                    }));

            // Adhesion.Change(A);
            Check(
                ExecParse("BveTs Map 2.00\n0;Adhesion.Change(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1.0
                        }
                    }));

            // Adhesion.Change(A, B, C);
            Check(
                ExecParse("BveTs Map 2.00\n0;Adhesion.Change(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1.0,
                            B = 1.0,
                            C = 1.0
                        }
                    }));

            // Adhesion.Change(A);
            Check(
                ExecParse("BveTs Map 1.00\n0;Adhesion.Change(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1.0
                        }
                    }));

            // Adhesion.Change(A, B, C);
            Check(
                ExecParse("BveTs Map 1.00\n0;Adhesion.Change(1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1.0,
                            B = 1.0,
                            C = 1.0
                        }
                    }));
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
                    syntaxes: new List<Statement>()
                    {
                        new SoundPlayStatement(0)
                        {
                            Key = "SoundKey",
                        }
                    }));

            // Sound[SoundKey].Play();
            Check(
                ExecParse("BveTs Map 2.00\n0;Sound['SoundKey'].Play();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SoundPlayStatement(0)
                        {
                            Key = "SoundKey",
                        }
                    }));

            // Sound[SoundKey].Play();
            Check(
                ExecParse("BveTs Map 1.00\n0;Sound[SoundKey].Play();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SoundPlayStatement(0)
                        {
                            Key = "SoundKey",
                        }
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

            // Sound3d[SoundKey].Put(X, Y);
            Check(
                ExecParse("BveTs Map 2.02\n0;Sound3d['SoundKey'].Put(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new Sound3dPutStatement(0)
                        {
                            Key = "SoundKey",
                            X = 1.0,
                            Y = 1.0
                        }
                    }));

            // Sound3d[SoundKey].Put(X, Y);
            Check(
                ExecParse("BveTs Map 2.00\n0;Sound3d['SoundKey'].Put(1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new Sound3dPutStatement(0)
                        {
                            Key = "SoundKey",
                            X = 1.0,
                            Y = 1.0
                        }
                    }));

            // Sound3d[SoundKey].Put(X, Y);
            Check(
                ExecParse("BveTs Map 1.00\n0;Sound3d[SoundKey].Put(1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new Sound3dPutStatement(0)
                        {
                            Key = "SoundKey",
                            X = 1.0,
                            Y = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Rollingnoise.Change(Index);
        /// </summary>
        [Fact]
        public void RollingnoiseChangeTest()
        {

            // Rollingnoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Rollingnoise.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RollingnoiseChangeStatement(0)
                        {
                            Index = 1.0
                        }
                    }));

            // Rollingnoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.00\n0;Rollingnoise.Change(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RollingnoiseChangeStatement(0)
                        {
                            Index = 1.0
                        }
                    }));

            // Rollingnoise.Change(Index);
            Check(
                ExecParse("BveTs Map 1.00\n0;Rollingnoise.Change(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RollingnoiseChangeStatement(0)
                        {
                            Index = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Flangenoise.Change(Index);
        /// </summary>
        [Fact]
        public void FlangenoiseChangeTest()
        {

            // Flangenoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Flangenoise.Change(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FlangenoiseChangeStatement(0)
                        {
                            Index = 1.0
                        }
                    }));

            // Flangenoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.00\n0;Flangenoise.Change(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new FlangenoiseChangeStatement(0)
                        {
                            Index = 1.0
                        }
                    }));

            // Flangenoise.Change(Index);
            Check(
                ExecParse("BveTs Map 1.00\n0;Flangenoise.Change(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new FlangenoiseChangeStatement(0)
                        {
                            Index = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Jointnoise.Play(Index);
        /// </summary>
        [Fact]
        public void JointnoisePlayTest()
        {

            // Jointnoise.Play(Index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Jointnoise.Play(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new JointnoisePlayStatement(0)
                        {
                            Index = 1.0
                        }
                    }));

            // Jointnoise.Play(Index);
            Check(
                ExecParse("BveTs Map 2.00\n0;Jointnoise.Play(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new JointnoisePlayStatement(0)
                        {
                            Index = 1.0
                        }
                    }));

            // Jointnoise.Play(Index);
            Check(
                ExecParse("BveTs Map 1.00\n0;Jointnoise.Play(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new JointnoisePlayStatement(0)
                        {
                            Index = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Train.Add(TrainKey, FilePath, TrackKey?, Direction?);
        /// </summary>
        [Fact]
        public void TrainAddTest()
        {

            // Train.Add(TrainKey, FilePath);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train.Add('string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainAddStatement(0)
                        {
                            TrainKey = "string_test_value",
                            FilePath = "string_test_value"
                        }
                    }));

            // Train.Add(TrainKey, FilePath, TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train.Add('string_test_value', 'string_test_value', 'string_test_value', 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainAddStatement(0)
                        {
                            TrainKey = "string_test_value",
                            FilePath = "string_test_value",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));

            // Train.Add(TrainKey, FilePath);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train.Add('string_test_value', 'string_test_value');"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainAddStatement(0)
                        {
                            TrainKey = "string_test_value",
                            FilePath = "string_test_value"
                        }
                    }));

            // Train.Add(TrainKey, FilePath, TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train.Add('string_test_value', 'string_test_value', 'string_test_value', 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainAddStatement(0)
                        {
                            TrainKey = "string_test_value",
                            FilePath = "string_test_value",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));

            // Train.Add(TrainKey, FilePath);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train.Add(string_test_value, string_test_value);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainAddStatement(0)
                        {
                            TrainKey = "string_test_value",
                            FilePath = "string_test_value"
                        }
                    }));

            // Train.Add(TrainKey, FilePath, TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train.Add(string_test_value, string_test_value, string_test_value, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainAddStatement(0)
                        {
                            TrainKey = "string_test_value",
                            FilePath = "string_test_value",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Train[TrainKey].Load(FilePath, TrackKey, Direction);
        /// </summary>
        [Fact]
        public void TrainLoadTest()
        {

            // Train[TrainKey].Load(FilePath, TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['TrainKey'].Load('string_test_value', 'string_test_value', 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainLoadStatement(0)
                        {
                            Key = "TrainKey",
                            FilePath = "string_test_value",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));
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

            // Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['TrainKey'].Stop(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainStopStatement(0)
                        {
                            Key = "TrainKey",
                            Decelerate = 1.0,
                            StopTime = 1.0,
                            Accelerate = 1.0,
                            Speed = 1.0
                        }
                    }));

            // Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train['TrainKey'].Stop(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainStopStatement(0)
                        {
                            Key = "TrainKey",
                            Decelerate = 1.0,
                            StopTime = 1.0,
                            Accelerate = 1.0,
                            Speed = 1.0
                        }
                    }));

            // Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train[TrainKey].Stop(1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainStopStatement(0)
                        {
                            Key = "TrainKey",
                            Decelerate = 1.0,
                            StopTime = 1.0,
                            Accelerate = 1.0,
                            Speed = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Train[TrainKey].Settrack(TrackKey, Direction);
        /// </summary>
        [Fact]
        public void TrainSettrackTest()
        {

            // Train[TrainKey].Settrack(TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['TrainKey'].Settrack('string_test_value', 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainSettrackStatement(0)
                        {
                            Key = "TrainKey",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));

            // Train[TrainKey].Settrack(TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train['TrainKey'].Settrack('string_test_value', 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainSettrackStatement(0)
                        {
                            Key = "TrainKey",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));

            // Train[TrainKey].Settrack(TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train[TrainKey].Settrack(string_test_value, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainSettrackStatement(0)
                        {
                            Key = "TrainKey",
                            TrackKey = "string_test_value",
                            Direction = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Fog(Fogstart, Fogend, red, green, blue);
        /// </summary>
        [Fact]
        public void LegacyFogTest()
        {

            // Legacy.Fog(Fogstart, Fogend, red, green, blue);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Fog(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyFogStatement(0)
                        {
                            Fogstart = 1.0,
                            Fogend = 1.0,
                            red = 1.0,
                            green = 1.0,
                            blue = 1.0
                        }
                    }));

            // Legacy.Fog(Fogstart, Fogend, red, green, blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Fog(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyFogStatement(0)
                        {
                            Fogstart = 1.0,
                            Fogend = 1.0,
                            red = 1.0,
                            green = 1.0,
                            blue = 1.0
                        }
                    }));

            // Legacy.Fog(Fogstart, Fogend, red, green, blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Fog(1.0, 1.0, 1.0, 1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyFogStatement(0)
                        {
                            Fogstart = 1.0,
                            Fogend = 1.0,
                            red = 1.0,
                            green = 1.0,
                            blue = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Curve(radius, cant);
        /// </summary>
        [Fact]
        public void LegacyCurveTest()
        {

            // Legacy.Curve(radius, cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Curve(1.0, 1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1.0,
                            cant = 1.0
                        }
                    }));

            // Legacy.Curve(radius, cant);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Curve(1.0, 1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1.0,
                            cant = 1.0
                        }
                    }));

            // Legacy.Curve(radius, cant);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Curve(1.0, 1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1.0,
                            cant = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Pitch(rate?);
        /// </summary>
        [Fact]
        public void LegacyPitchTest()
        {

            // Legacy.Pitch(rate);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Pitch(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                            rate = 1.0
                        }
                    }));

            // Legacy.Pitch(rate);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Pitch(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                            rate = 1.0
                        }
                    }));

            // Legacy.Pitch(rate);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Pitch(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                            rate = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Turn(slope?);
        /// </summary>
        [Fact]
        public void LegacyTurnTest()
        {

            // Legacy.Turn(slope);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Turn(1.0);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                            slope = 1.0
                        }
                    }));

            // Legacy.Turn(slope);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Turn(1.0);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                            slope = 1.0
                        }
                    }));

            // Legacy.Turn(slope);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Turn(1.0);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                            slope = 1.0
                        }
                    }));
        }

        /// <summary>
        /// Include(FilePath);
        /// </summary>
        [Fact]
        public void IncludeTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Include(FilePath)構文のテストは手動で作成してください。
             */
        }
        #endregion
    }
}
