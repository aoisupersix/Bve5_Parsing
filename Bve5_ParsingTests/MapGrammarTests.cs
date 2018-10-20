using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bve5_Parsing.MapGrammar;
using System;

namespace Bve5_ParsingTests
{
    [TestClass]
    public class MapGrammarTests
    {
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

        [TestMethod]
        public void RootTests()
        {
            Assert.IsNotNull(ExecParse("BveTs Map 2.02"));
        }
    }
}
