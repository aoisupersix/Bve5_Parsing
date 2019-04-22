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
                ExecParse("BveTs Map 2.02\n0;Curve.Setgauge(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveSetgaugeStatement(0)
                        {
                            Value = 1
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
                ExecParse("BveTs Map 2.02\n0;Gauge.Set(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GaugeSetStatement(0)
                        {
                            Value = 1
                        }
                    }));

            // Gauge.Set(Value);
            Check(
                ExecParse("BveTs Map 2.00\n0;Gauge.Set(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new GaugeSetStatement(0)
                        {
                            Value = 1
                        }
                    }));

            // Gauge.Set(Value);
            Check(
                ExecParse("BveTs Map 1.00\n0;Gauge.Set(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new GaugeSetStatement(0)
                        {
                            Value = 1
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
                ExecParse("BveTs Map 2.02\n0;Curve.Gauge(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveGaugeStatement(0)
                        {
                            Value = 1
                        }
                    }));

            // Curve.Gauge(Value);
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.Gauge(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveGaugeStatement(0)
                        {
                            Value = 1
                        }
                    }));

            // Curve.Gauge(Value);
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.Gauge(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveGaugeStatement(0)
                        {
                            Value = 1
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
                ExecParse("BveTs Map 2.02\n0;Curve.Setcenter(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveSetcenterStatement(0)
                        {
                            X = 1
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
                ExecParse("BveTs Map 2.02\n0;Curve.Setfunction(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveSetfunctionStatement(0)
                        {
                            Id = 1
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
                ExecParse("BveTs Map 2.02\n0;Curve.Begin(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBeginStatement(0)
                        {
                            Radius = 1
                        }
                    }));

            // Curve.Begin(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begin(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBeginStatement(0)
                        {
                            Radius = 1,
                            Cant = 1
                        }
                    }));
        }

        /// <summary>
        /// Curve.Begincircular(Radius, Cant?);
        /// </summary>
        [Fact]
        public void CurveBegincircularTest()
        {

            // Curve.Begincircular(Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begincircular(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1
                        }
                    }));

            // Curve.Begincircular(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Begincircular(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1,
                            Cant = 1
                        }
                    }));

            // Curve.Begincircular(Radius);
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.Begincircular(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1
                        }
                    }));

            // Curve.Begincircular(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.00\n0;Curve.Begincircular(1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1,
                            Cant = 1
                        }
                    }));

            // Curve.Begincircular(Radius);
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.Begincircular(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1
                        }
                    }));

            // Curve.Begincircular(Radius, Cant);
            Check(
                ExecParse("BveTs Map 1.00\n0;Curve.Begincircular(1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CurveBegincircularStatement(0)
                        {
                            Radius = 1,
                            Cant = 1
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
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveInterpolateStatement(0)
                        {
                            Radius = 1
                        }
                    }));

            // Curve.Interpolate(Radius, Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Curve.Interpolate(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveInterpolateStatement(0)
                        {
                            Radius = 1,
                            Cant = 1
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
                ExecParse("BveTs Map 2.02\n0;Curve.Change(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CurveChangeStatement(0)
                        {
                            Radius = 1
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
                ExecParse("BveTs Map 2.02\n0;Gradient.Begin(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginStatement(0)
                        {
                            Gradient = 1
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
                ExecParse("BveTs Map 2.02\n0;Gradient.Beginconst(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginconstStatement(0)
                        {
                            Gradient = 1
                        }
                    }));

            // Gradient.Beginconst(Gradient);
            Check(
                ExecParse("BveTs Map 2.00\n0;Gradient.Beginconst(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginconstStatement(0)
                        {
                            Gradient = 1
                        }
                    }));

            // Gradient.Beginconst(Gradient);
            Check(
                ExecParse("BveTs Map 1.00\n0;Gradient.Beginconst(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new GradientBeginconstStatement(0)
                        {
                            Gradient = 1
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
                ExecParse("BveTs Map 2.02\n0;Gradient.Interpolate(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new GradientInterpolateStatement(0)
                        {
                            Gradient = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackXInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1
                        }
                    }));

            // Track[TrackKey].X.Interpolate(X, Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].X.Interpolate(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackXInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1,
                            Radius = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackYInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            Y = 1
                        }
                    }));

            // Track[TrackKey].Y.Interpolate(Y, Radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Y.Interpolate(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackYInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            Y = 1,
                            Radius = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setgauge(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantSetgaugeStatement(0)
                        {
                            Key = "TrackKey",
                            Gauge = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Gauge(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackGaugeStatement(0)
                        {
                            Key = "TrackKey",
                            Gauge = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setcenter(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantSetcenterStatement(0)
                        {
                            Key = "TrackKey",
                            X = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Setfunction(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantSetfunctionStatement(0)
                        {
                            Key = "TrackKey",
                            Id = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Begin(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantBeginStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1
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
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant.Interpolate(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantInterpolateStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1
                        }
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
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));

            // Track[TrackKey].Cant(Cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Track['TrackKey'].Cant(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1
                        }
                    }));

            // Track[TrackKey].Cant();
            Check(
                ExecParse("BveTs Map 2.00\n0;Track['TrackKey'].Cant();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));

            // Track[TrackKey].Cant(Cant);
            Check(
                ExecParse("BveTs Map 2.00\n0;Track['TrackKey'].Cant(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1
                        }
                    }));

            // Track[TrackKey].Cant();
            Check(
                ExecParse("BveTs Map 1.00\n0;Track[TrackKey].Cant();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                        }
                    }));

            // Track[TrackKey].Cant(Cant);
            Check(
                ExecParse("BveTs Map 1.00\n0;Track[TrackKey].Cant(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrackCantStatement(0)
                        {
                            Key = "TrackKey",
                            Cant = 1
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
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Put('string_test_value', 1, 1, 1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1
                        }
                    }));

            // Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.00\n0;Structure['StructureKey'].Put('string_test_value', 1, 1, 1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1
                        }
                    }));

            // Structure[StructureKey].Put(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span);
            Check(
                ExecParse("BveTs Map 1.00\n0;Structure[StructureKey].Put(string_test_value, 1, 1, 1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePutStatement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1
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
                ExecParse("BveTs Map 2.02\n0;Structure['StructureKey'].Put0('string_test_value', 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePut0Statement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            Tilt = 1,
                            Span = 1
                        }
                    }));

            // Structure[StructureKey].Put0(TrackKey, Tilt, Span);
            Check(
                ExecParse("BveTs Map 2.00\n0;Structure['StructureKey'].Put0('string_test_value', 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePut0Statement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            Tilt = 1,
                            Span = 1
                        }
                    }));

            // Structure[StructureKey].Put0(TrackKey, Tilt, Span);
            Check(
                ExecParse("BveTs Map 1.00\n0;Structure[StructureKey].Put0(string_test_value, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StructurePut0Statement(0)
                        {
                            Key = "StructureKey",
                            TrackKey = "string_test_value",
                            Tilt = 1,
                            Span = 1
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
        /// Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
        /// </summary>
        [Fact]
        public void RepeaterBeginTest()
        {

            // Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin('string_test_value', 1, 1, 1, 1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1,
                            Interval = 1
                        }
                    }));

            // Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
            Check(
                ExecParse("BveTs Map 2.00\n0;Repeater['RepeaterKey'].Begin('string_test_value', 1, 1, 1, 1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1,
                            Interval = 1
                        }
                    }));

            // Repeater[RepeaterKey].Begin(TrackKey, X, Y, Z, RX, RY, RZ, Tilt, Span, Interval);
            Check(
                ExecParse("BveTs Map 1.00\n0;Repeater[RepeaterKey].Begin(string_test_value, 1, 1, 1, 1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBeginStatement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            X = 1,
                            Y = 1,
                            Z = 1,
                            RX = 1,
                            RY = 1,
                            RZ = 1,
                            Tilt = 1,
                            Span = 1,
                            Interval = 1
                        }
                    }));
        }

        /// <summary>
        /// Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval);
        /// </summary>
        [Fact]
        public void RepeaterBegin0Test()
        {

            // Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval);
            Check(
                ExecParse("BveTs Map 2.02\n0;Repeater['RepeaterKey'].Begin0('string_test_value', 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            Tilt = 1,
                            Span = 1,
                            Interval = 1
                        }
                    }));

            // Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval);
            Check(
                ExecParse("BveTs Map 2.00\n0;Repeater['RepeaterKey'].Begin0('string_test_value', 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            Tilt = 1,
                            Span = 1,
                            Interval = 1
                        }
                    }));

            // Repeater[RepeaterKey].Begin0(TrackKey, Tilt, Span, Interval);
            Check(
                ExecParse("BveTs Map 1.00\n0;Repeater[RepeaterKey].Begin0(string_test_value, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RepeaterBegin0Statement(0)
                        {
                            Key = "RepeaterKey",
                            TrackKey = "string_test_value",
                            Tilt = 1,
                            Span = 1,
                            Interval = 1
                        }
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
                ExecParse("BveTs Map 2.02\n0;Station['StationKey'].Put(1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new StationPutStatement(0)
                        {
                            Key = "StationKey",
                            Door = 1,
                            Margin1 = 1,
                            Margin2 = 1
                        }
                    }));

            // Station[StationKey].Put(Door, Margin1, Margin2);
            Check(
                ExecParse("BveTs Map 2.00\n0;Station['StationKey'].Put(1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new StationPutStatement(0)
                        {
                            Key = "StationKey",
                            Door = 1,
                            Margin1 = 1,
                            Margin2 = 1
                        }
                    }));

            // Station[StationKey].Put(Door, Margin1, Margin2);
            Check(
                ExecParse("BveTs Map 1.00\n0;Station[StationKey].Put(1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new StationPutStatement(0)
                        {
                            Key = "StationKey",
                            Door = 1,
                            Margin1 = 1,
                            Margin2 = 1
                        }
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

            // Beacon.Put(Type, Section, Senddata);
            Check(
                ExecParse("BveTs Map 2.02\n0;Beacon.Put(1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new BeaconPutStatement(0)
                        {
                            Type = 1,
                            Section = 1,
                            Senddata = 1
                        }
                    }));

            // Beacon.Put(Type, Section, Senddata);
            Check(
                ExecParse("BveTs Map 2.00\n0;Beacon.Put(1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new BeaconPutStatement(0)
                        {
                            Type = 1,
                            Section = 1,
                            Senddata = 1
                        }
                    }));

            // Beacon.Put(Type, Section, Senddata);
            Check(
                ExecParse("BveTs Map 1.00\n0;Beacon.Put(1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new BeaconPutStatement(0)
                        {
                            Type = 1,
                            Section = 1,
                            Senddata = 1
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
                ExecParse("BveTs Map 2.02\n0;Speedlimit.Begin(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitBeginStatement(0)
                        {
                            V = 1
                        }
                    }));

            // Speedlimit.Begin(V);
            Check(
                ExecParse("BveTs Map 2.00\n0;Speedlimit.Begin(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitBeginStatement(0)
                        {
                            V = 1
                        }
                    }));

            // Speedlimit.Begin(V);
            Check(
                ExecParse("BveTs Map 1.00\n0;Speedlimit.Begin(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new SpeedlimitBeginStatement(0)
                        {
                            V = 1
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
                ExecParse("BveTs Map 2.02\n0;Light.Ambient(1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LightAmbientStatement(0)
                        {
                            Red = 1,
                            Green = 1,
                            Blue = 1
                        }
                    }));

            // Light.Ambient(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Light.Ambient(1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightAmbientStatement(0)
                        {
                            Red = 1,
                            Green = 1,
                            Blue = 1
                        }
                    }));

            // Light.Ambient(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Light.Ambient(1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightAmbientStatement(0)
                        {
                            Red = 1,
                            Green = 1,
                            Blue = 1
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
                ExecParse("BveTs Map 2.02\n0;Light.Diffuse(1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LightDiffuseStatement(0)
                        {
                            Red = 1,
                            Green = 1,
                            Blue = 1
                        }
                    }));

            // Light.Diffuse(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Light.Diffuse(1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDiffuseStatement(0)
                        {
                            Red = 1,
                            Green = 1,
                            Blue = 1
                        }
                    }));

            // Light.Diffuse(Red, Green, Blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Light.Diffuse(1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDiffuseStatement(0)
                        {
                            Red = 1,
                            Green = 1,
                            Blue = 1
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
                ExecParse("BveTs Map 2.02\n0;Light.Direction(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LightDirectionStatement(0)
                        {
                            Pitch = 1,
                            Yaw = 1
                        }
                    }));

            // Light.Direction(Pitch, Yaw);
            Check(
                ExecParse("BveTs Map 2.00\n0;Light.Direction(1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDirectionStatement(0)
                        {
                            Pitch = 1,
                            Yaw = 1
                        }
                    }));

            // Light.Direction(Pitch, Yaw);
            Check(
                ExecParse("BveTs Map 1.00\n0;Light.Direction(1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LightDirectionStatement(0)
                        {
                            Pitch = 1,
                            Yaw = 1
                        }
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

            // Drawdistance.Change(Value);
            Check(
                ExecParse("BveTs Map 2.02\n0;Drawdistance.Change(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new DrawdistanceChangeStatement(0)
                        {
                            Value = 1
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
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Interpolate(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceInterpolateStatement(0)
                        {
                            Value = 1
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
                ExecParse("BveTs Map 2.02\n0;Cabilluminance.Set(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceSetStatement(0)
                        {
                            Value = 1
                        }
                    }));

            // Cabilluminance.Set(Value);
            Check(
                ExecParse("BveTs Map 2.00\n0;Cabilluminance.Set(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceSetStatement(0)
                        {
                            Value = 1
                        }
                    }));

            // Cabilluminance.Set(Value);
            Check(
                ExecParse("BveTs Map 1.00\n0;Cabilluminance.Set(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new CabilluminanceSetStatement(0)
                        {
                            Value = 1
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
                ExecParse("BveTs Map 2.02\n0;Irregularity.Change(1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new IrregularityChangeStatement(0)
                        {
                            X = 1,
                            Y = 1,
                            R = 1,
                            LX = 1,
                            LY = 1,
                            LR = 1
                        }
                    }));

            // Irregularity.Change(X, Y, R, LX, LY, LR);
            Check(
                ExecParse("BveTs Map 2.00\n0;Irregularity.Change(1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new IrregularityChangeStatement(0)
                        {
                            X = 1,
                            Y = 1,
                            R = 1,
                            LX = 1,
                            LY = 1,
                            LR = 1
                        }
                    }));

            // Irregularity.Change(X, Y, R, LX, LY, LR);
            Check(
                ExecParse("BveTs Map 1.00\n0;Irregularity.Change(1, 1, 1, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new IrregularityChangeStatement(0)
                        {
                            X = 1,
                            Y = 1,
                            R = 1,
                            LX = 1,
                            LY = 1,
                            LR = 1
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
                ExecParse("BveTs Map 2.02\n0;Adhesion.Change(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1
                        }
                    }));

            // Adhesion.Change(A, B);
            Check(
                ExecParse("BveTs Map 2.02\n0;Adhesion.Change(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1,
                            B = 1
                        }
                    }));

            // Adhesion.Change(A, B, C);
            Check(
                ExecParse("BveTs Map 2.02\n0;Adhesion.Change(1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1,
                            B = 1,
                            C = 1
                        }
                    }));

            // Adhesion.Change(A);
            Check(
                ExecParse("BveTs Map 2.00\n0;Adhesion.Change(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1
                        }
                    }));

            // Adhesion.Change(A, B);
            Check(
                ExecParse("BveTs Map 2.00\n0;Adhesion.Change(1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1,
                            B = 1
                        }
                    }));

            // Adhesion.Change(A, B, C);
            Check(
                ExecParse("BveTs Map 2.00\n0;Adhesion.Change(1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1,
                            B = 1,
                            C = 1
                        }
                    }));

            // Adhesion.Change(A);
            Check(
                ExecParse("BveTs Map 1.00\n0;Adhesion.Change(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1
                        }
                    }));

            // Adhesion.Change(A, B);
            Check(
                ExecParse("BveTs Map 1.00\n0;Adhesion.Change(1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1,
                            B = 1
                        }
                    }));

            // Adhesion.Change(A, B, C);
            Check(
                ExecParse("BveTs Map 1.00\n0;Adhesion.Change(1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new AdhesionChangeStatement(0)
                        {
                            A = 1,
                            B = 1,
                            C = 1
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
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Sound3d[SoundKey].Put(X, Y)構文のテストは手動で作成してください。
             */
        }

        /// <summary>
        /// Rollingnoise.Change(Index);
        /// </summary>
        [Fact]
        public void RollingnoiseChangeTest()
        {

            // Rollingnoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.02\n0;Rollingnoise.Change(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new RollingnoiseChangeStatement(0)
                        {
                            Index = 1
                        }
                    }));

            // Rollingnoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.00\n0;Rollingnoise.Change(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new RollingnoiseChangeStatement(0)
                        {
                            Index = 1
                        }
                    }));

            // Rollingnoise.Change(Index);
            Check(
                ExecParse("BveTs Map 1.00\n0;Rollingnoise.Change(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new RollingnoiseChangeStatement(0)
                        {
                            Index = 1
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
                ExecParse("BveTs Map 2.02\n0;Flangenoise.Change(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new FlangenoiseChangeStatement(0)
                        {
                            Index = 1
                        }
                    }));

            // Flangenoise.Change(Index);
            Check(
                ExecParse("BveTs Map 2.00\n0;Flangenoise.Change(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new FlangenoiseChangeStatement(0)
                        {
                            Index = 1
                        }
                    }));

            // Flangenoise.Change(Index);
            Check(
                ExecParse("BveTs Map 1.00\n0;Flangenoise.Change(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new FlangenoiseChangeStatement(0)
                        {
                            Index = 1
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
                ExecParse("BveTs Map 2.02\n0;Jointnoise.Play(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new JointnoisePlayStatement(0)
                        {
                            Index = 1
                        }
                    }));

            // Jointnoise.Play(Index);
            Check(
                ExecParse("BveTs Map 2.00\n0;Jointnoise.Play(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new JointnoisePlayStatement(0)
                        {
                            Index = 1
                        }
                    }));

            // Jointnoise.Play(Index);
            Check(
                ExecParse("BveTs Map 1.00\n0;Jointnoise.Play(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new JointnoisePlayStatement(0)
                        {
                            Index = 1
                        }
                    }));
        }

        /// <summary>
        /// Train.Add(TrainKey, FilePath, TrackKey?, Direction?);
        /// </summary>
        [Fact]
        public void TrainAddTest()
        {
            /*
             * THIS TEST IS SKIPPED.
             * この構文のテストは諸事情によりテストの自動生成から外されました。
             * Train.Add(TrainKey, FilePath, TrackKey?, Direction?)構文のテストは手動で作成してください。
             */
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

            // Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
            Check(
                ExecParse("BveTs Map 2.02\n0;Train['TrainKey'].Stop(1, 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainStopStatement(0)
                        {
                            Key = "TrainKey",
                            Decelerate = 1,
                            StopTime = 1,
                            Accelerate = 1,
                            Speed = 1
                        }
                    }));

            // Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train['TrainKey'].Stop(1, 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainStopStatement(0)
                        {
                            Key = "TrainKey",
                            Decelerate = 1,
                            StopTime = 1,
                            Accelerate = 1,
                            Speed = 1
                        }
                    }));

            // Train[TrainKey].Stop(Decelerate, StopTime, Accelerate, Speed);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train[TrainKey].Stop(1, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainStopStatement(0)
                        {
                            Key = "TrainKey",
                            Decelerate = 1,
                            StopTime = 1,
                            Accelerate = 1,
                            Speed = 1
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
                ExecParse("BveTs Map 2.02\n0;Train['TrainKey'].Settrack('string_test_value', 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new TrainSettrackStatement(0)
                        {
                            Key = "TrainKey",
                            TrackKey = "string_test_value",
                            Direction = 1
                        }
                    }));

            // Train[TrainKey].Settrack(TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 2.00\n0;Train['TrainKey'].Settrack('string_test_value', 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainSettrackStatement(0)
                        {
                            Key = "TrainKey",
                            TrackKey = "string_test_value",
                            Direction = 1
                        }
                    }));

            // Train[TrainKey].Settrack(TrackKey, Direction);
            Check(
                ExecParse("BveTs Map 1.00\n0;Train[TrainKey].Settrack(string_test_value, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new TrainSettrackStatement(0)
                        {
                            Key = "TrainKey",
                            TrackKey = "string_test_value",
                            Direction = 1
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
                ExecParse("BveTs Map 2.02\n0;Legacy.Fog(1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyFogStatement(0)
                        {
                            Fogstart = 1,
                            Fogend = 1,
                            red = 1,
                            green = 1,
                            blue = 1
                        }
                    }));

            // Legacy.Fog(Fogstart, Fogend, red, green, blue);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Fog(1, 1, 1, 1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyFogStatement(0)
                        {
                            Fogstart = 1,
                            Fogend = 1,
                            red = 1,
                            green = 1,
                            blue = 1
                        }
                    }));

            // Legacy.Fog(Fogstart, Fogend, red, green, blue);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Fog(1, 1, 1, 1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyFogStatement(0)
                        {
                            Fogstart = 1,
                            Fogend = 1,
                            red = 1,
                            green = 1,
                            blue = 1
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Curve(radius, cant?);
        /// </summary>
        [Fact]
        public void LegacyCurveTest()
        {

            // Legacy.Curve(radius);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Curve(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1
                        }
                    }));

            // Legacy.Curve(radius, cant);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Curve(1, 1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1,
                            cant = 1
                        }
                    }));

            // Legacy.Curve(radius);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Curve(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1
                        }
                    }));

            // Legacy.Curve(radius, cant);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Curve(1, 1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1,
                            cant = 1
                        }
                    }));

            // Legacy.Curve(radius);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Curve(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1
                        }
                    }));

            // Legacy.Curve(radius, cant);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Curve(1, 1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyCurveStatement(0)
                        {
                            radius = 1,
                            cant = 1
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Pitch(rate?);
        /// </summary>
        [Fact]
        public void LegacyPitchTest()
        {

            // Legacy.Pitch();
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Pitch();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                        }
                    }));

            // Legacy.Pitch(rate);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Pitch(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                            rate = 1
                        }
                    }));

            // Legacy.Pitch();
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Pitch();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                        }
                    }));

            // Legacy.Pitch(rate);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Pitch(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                            rate = 1
                        }
                    }));

            // Legacy.Pitch();
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Pitch();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                        }
                    }));

            // Legacy.Pitch(rate);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Pitch(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyPitchStatement(0)
                        {
                            rate = 1
                        }
                    }));
        }

        /// <summary>
        /// Legacy.Turn(slope?);
        /// </summary>
        [Fact]
        public void LegacyTurnTest()
        {

            // Legacy.Turn();
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Turn();"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                        }
                    }));

            // Legacy.Turn(slope);
            Check(
                ExecParse("BveTs Map 2.02\n0;Legacy.Turn(1);"),
                new MapData(
                    version: "2.02",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                            slope = 1
                        }
                    }));

            // Legacy.Turn();
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Turn();"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                        }
                    }));

            // Legacy.Turn(slope);
            Check(
                ExecParse("BveTs Map 2.00\n0;Legacy.Turn(1);"),
                new MapData(
                    version: "2.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                            slope = 1
                        }
                    }));

            // Legacy.Turn();
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Turn();"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                        }
                    }));

            // Legacy.Turn(slope);
            Check(
                ExecParse("BveTs Map 1.00\n0;Legacy.Turn(1);"),
                new MapData(
                    version: "1.00",
                    syntaxes: new List<Statement>()
                    {
                        new LegacyTurnStatement(0)
                        {
                            slope = 1
                        }
                    }));
        }
        #endregion
    }
}
