using Bve5_Parsing.MapGrammar;
using Bve5_Parsing.MapGrammar.EvaluateData;
using System.Linq;
using Xunit;
using static Bve5_Parsing.MapGrammar.MapGrammarParser;

namespace Bve5_ParsingTests
{
    public class MapGrammarParserTests
    {
        [Fact]
        public void ParseFromStringTest()
        {
            var parser = new MapGrammarParser();
            var input = "BveTs Map 2.02\n0;Curve.Begin(0);";
            var inputWithInclude = "BveTs Map 2.02\ninclude 'test.txt';";
            var inputV1 = "BveTs Map 2.02\n0; Curve.BeginCircular();";
            var noHeaderInput = "0; Curve.Begin(0);";
            var noHeaderInputV1 = "0; Curve.BeginCircular(0);";
            var inputWithVariable = "BveTs Map 2.02\nCurve.Begin($test);";

            // Option指定なし
            MapData data = parser.Parse(input);
            Assert.NotNull(data);
            Assert.Equal("2.02", data.Version);
            Assert.Single(data.Statements);

            // Option.None
            data = parser.Parse(input, MapGrammarParserOption.None);
            Assert.NotNull(data);
            Assert.Equal("2.02", data.Version);
            Assert.Single(data.Statements);

            // Option.ParseIncludeSyntaxRecursively
            // このメソッドでは未対応なのでInclude先はパースされない
            //data = parser.Parse(inputWithInclude, MapGrammarParserOption.ParseIncludeSyntaxRecursively);
            //Assert.NotNull(data);
            //Assert.Equal("2.02", data.Version);
            //Assert.Single(data.Statements);
            //Assert.False(data.Statements[0].FunctionName.HasValue);
            //Assert.Equal(MapElementName.Include, data.Statements[0].ElementName);

            // Option.ParseAsVersion1
            data = parser.Parse(inputV1, MapGrammarParserOption.ParseAsMapVersion1);
            Assert.NotNull(data);
            Assert.Equal("1.00", data.Version);
            Assert.Single(data.Statements);
            Assert.Equal(MapFunctionName.Begincircular, data.Statements[0].FunctionName);

            // Option.ParseAsVersion2
            data = parser.Parse(input, MapGrammarParserOption.ParseAsMapVersion2);
            Assert.NotNull(data);
            Assert.Equal("2.02", data.Version);
            Assert.Single(data.Statements);

            // Option.ParseAsVersion1 and ParseAsVersion2
            // ParseAsVersion2が優先される
            data = parser.Parse(input, MapGrammarParserOption.ParseAsMapVersion1 | MapGrammarParserOption.ParseAsMapVersion2);
            Assert.NotNull(data);
            Assert.Equal("2.02", data.Version);
            Assert.Single(data.Statements);

            // Option.NoHeader
            data = parser.Parse(noHeaderInput, MapGrammarParserOption.NoHeader);
            Assert.NotNull(data);
            Assert.Equal("2.02", data.Version);
            Assert.Single(data.Statements);

            // Option.NoHeader and ParseAsVersion1
            data = parser.Parse(noHeaderInputV1, MapGrammarParserOption.NoHeader | MapGrammarParserOption.ParseAsMapVersion1);
            Assert.NotNull(data);
            Assert.Equal("1.00", data.Version);
            Assert.Single(data.Statements);
            Assert.Equal(MapFunctionName.Begincircular, data.Statements[0].FunctionName);

            // Option.ClearVariable
            parser.Store.SetVar("test", 100);
            data = parser.Parse(inputWithVariable, MapGrammarParserOption.ClearVariables);
            Assert.NotNull(data);
            Assert.Equal("2.02", data.Version);
            Assert.Single(data.Statements);
            Assert.Equal("0", data.Statements[0].ToSyntaxData().Arguments["radius"] as string);
        }
    }
}
