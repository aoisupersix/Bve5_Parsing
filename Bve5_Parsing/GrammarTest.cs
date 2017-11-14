using System;
using System.Collections.Generic;
using Irony.Interpreter;
using Irony.Parsing;
using Irony;

namespace Bve5_Parsing
{
    class GrammarTest
    {
        static void Main(String[] args)
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("MapGrammar_Careless Test");
                Console.WriteLine("====================================");

                string input = "";
                Console.WriteLine("Input your syntax. Enter \"EOF\" to end input.");
                string line = Console.ReadLine();
                while (!line.Equals("EOF"))
                {
                    input += line + Environment.NewLine;
                    line = Console.ReadLine();
                }

                Console.WriteLine("====================================");
                Console.WriteLine("Parser Output:");

                ScriptApp app = new ScriptApp(new LanguageData(new MapGrammar_Careless.MapGrammar_Careless()));

                try
                {
                    MapGrammar_Careless.MapData result = (MapGrammar_Careless.MapData)app.Evaluate(input);

                    //結果表示
                    Console.WriteLine("Version:{0}", result.Version);
                    Console.WriteLine("Encoding:{0}", result.Encoding);
                    Console.WriteLine("StructureListPath:{0}", @result.StructureListPath);
                    Console.WriteLine("StationListPath:{0}", result.StationListPath);
                    Console.WriteLine("SignalListPath:{0}", result.SignalListPath);
                    Console.WriteLine("SoundListPath:{0}", result.SoundListPath);
                    Console.WriteLine("Sound3DListPath:{0}", result.Sound3DListPath);

                    Console.WriteLine("----------------------------");
                    foreach(MapGrammar_Careless.AstNodes.SyntaxData syntaxData in result.Statements)
                    {
                        Console.WriteLine("Distance:{0}", syntaxData.Distance);
                        for(int i = 0; i < syntaxData.MapElement.Length; i++)
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
                catch (ScriptException)
                {
                    Console.WriteLine("Error.");
                    LogMessageList parseTree = app.GetParserMessages();
                    foreach(var err in parseTree)
                    {
                        Console.Error.WriteLine("{0}: {1} {2}", err.Location, err, err.ParserState);
                    }
                }

                Console.WriteLine("End it? Y/N");
                string endInput = Console.ReadLine();
                if (endInput.Equals("Y"))
                {
                    end = true;
                }
            }
        }
    }
}
