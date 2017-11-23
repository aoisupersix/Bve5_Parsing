using System;
using System.Collections.Generic;
using Irony.Interpreter;
using Irony.Parsing;
using Bve5_Parsing.MapGrammar;
using Bve5_Parsing.ScenarioGrammar;
using Irony;

namespace Bve5_Parsing
{
    /*
     * 各構文ライブラリのテスト
     */
    class GrammarTest
    {
        static void Main(String[] args)
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("Syntax Test");
                Console.WriteLine("====================================");

                Console.WriteLine("Select the syntax to test from the numbers below.");
                Console.WriteLine("0: ScenarioGrammar");
                Console.WriteLine("1: MapGrammar");
                string select = Console.ReadLine();

                string input = "";
                Console.WriteLine("Input your syntax. Enter \"EOF\" to end input.");
                string line = Console.ReadLine();
                while (!line.Equals("EOF"))
                {
                    input += line + Environment.NewLine;
                    line = Console.ReadLine();
                }

                Console.WriteLine(input);

                switch (select)
                {
                    case "0":
                        ScenarioGrammarTest(input);
                        break;
                    case "1":
                        MapGrammarTest(input);
                        break;
                    default:
                        Console.WriteLine("選択した値が不正です。");
                        break;
                }

                Console.WriteLine("End it? Y/N");
                string endInput = Console.ReadLine();
                if (endInput.Equals("Y") || endInput.Equals("y"))
                {
                    end = true;
                }
            }
        }

        /// <summary>
        /// シナリオ構文のテスト
        /// </summary>
        /// <param name="input">構文文字列</param>
        static void ScenarioGrammarTest(string input)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("ScenarioGrammar Parser Output:");

            ScriptApp app = new ScriptApp(new LanguageData(new ScenarioGrammar.ScenarioGrammar()));

            try
            {
                ScenarioData result = (ScenarioData)app.Evaluate(input);

                //結果表示
                Console.WriteLine("Version:{0}", result.Version);
                //Console.WriteLine("Encoding:{0}", result.Encoding);

                Console.WriteLine("Route----------------------------");
                foreach(var paths in result.Route)
                {
                    Console.WriteLine("Value:{0}", paths.Value);
                    Console.WriteLine("Weight:{0}", paths.Weight);
                }

                Console.WriteLine("Vehicle----------------------------");
                foreach (var paths in result.Vehicle)
                {
                    Console.WriteLine("Value:{0}", paths.Value);
                    Console.WriteLine("Weight:{0}", paths.Weight);
                }

                Console.WriteLine("Image:{0}", result.Image);
                Console.WriteLine("Title:{0}", result.Title);
                Console.WriteLine("RouteTitle:{0}", result.RouteTitle);
                Console.WriteLine("VehicleTitle:{0}", result.VehicleTitle);
                Console.WriteLine("Author:{0}", result.Author);
                Console.WriteLine("Comment:{0}", result.Comment);

            }
            catch (ScriptException e)
            {
                Console.WriteLine("Error.");

                LogMessageList parseTree = app.GetParserMessages();

                if (parseTree.Count > 0)
                {
                    foreach (var err in parseTree)
                    {
                        Console.Error.WriteLine("{0}: {1}", err.Location, err);
                    }
                }
                else
                {
                    //Other error
                    Console.Error.WriteLine("{0}: {1}", e.Location, e.Message);
                }
            }
        }

        /// <summary>
        /// マップ構文のテスト
        /// </summary>
        /// <param name="input">構文文字列</param>
        static void MapGrammarTest(string input)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("MapGrammar Parser Output:");

            ScriptApp app = new ScriptApp(new LanguageData(new MapGrammar.MapGrammar()));
            Parser parser = app.Parser;
            try
            {
                parser.Parse(input);
                MapData result = (MapData)app.Evaluate(input);

                //結果表示
                Console.WriteLine("Version:{0}", result.Version);
                Console.WriteLine("Encoding:{0}", result.Encoding);
                Console.WriteLine("StructureListPath:{0}", @result.StructureListPath);
                Console.WriteLine("StationListPath:{0}", result.StationListPath);
                Console.WriteLine("SignalListPath:{0}", result.SignalListPath);
                Console.WriteLine("SoundListPath:{0}", result.SoundListPath);
                Console.WriteLine("Sound3DListPath:{0}", result.Sound3DListPath);

                Console.WriteLine("----------------------------");
                foreach (SyntaxData syntaxData in result.Statements)
                {
                    Console.WriteLine("Distance:{0}", syntaxData.Distance);
                    for (int i = 0; i < syntaxData.MapElement.Length; i++)
                    {
                        Console.WriteLine("MapElement[{0}]:{1}", i, syntaxData.MapElement[i]);
                    }
                    Console.WriteLine("Key:{0}", syntaxData.Key);
                    Console.WriteLine("Function:{0}", syntaxData.Function);
                    foreach (KeyValuePair<string, object> kvp in syntaxData.Arguments)
                    {
                        Console.WriteLine("{0}:{1}", kvp.Key, kvp.Value);
                    }
                    Console.WriteLine("----------------------------");
                }

            }
            catch (ScriptException e)
            {
                Console.WriteLine("Error.");

                LogMessageList parseTree = app.GetParserMessages();

                if (parseTree.Count > 0)
                {
                    foreach (var err in parseTree)
                    {
                        Console.Error.WriteLine("{0}: {1}", err.Location, err);
                    }
                }
                else
                {
                    //Other error
                    Console.Error.WriteLine("{0}: {1}", e.Location, e.Message);
                }
            }
            finally
            {
                ParseTree tree = parser.Context.CurrentParseTree;
                Evaluator evaluator = new Evaluator(tree);
            }
        }
    }
}
