using Bve5_Parsing.MapGrammar;
using System;
using System.Collections.Generic;


namespace Bve5_Parsing
{
    /// <summary>
    /// 各種構文解析器のテストを行うクラス
    /// </summary>
    class GrammarTest
    {
        static int testMode = 0;
        static void Main(String[] args)
        {
            if(testMode == 0)
            {
                string input0 = "suman; Curve.Begin(); Curve.BeginTransition(); suman;";
                MapGrammarTest(input0);
                Console.ReadLine();
            }
            else
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
        }

        /// <summary>
        /// シナリオ構文のテスト
        /// </summary>
        /// <param name="input">構文文字列</param>
        static void ScenarioGrammarTest(string input)
        {

        }

        /// <summary>
        /// マップ構文のテスト
        /// </summary>
        /// <param name="input">構文文字列</param>
        static void MapGrammarTest(string input)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("MapGrammar Parser Output:");

            MapGrammarParser parser = new MapGrammarParser();
            MapData data = null;

            data = parser.Parse(input);
        }
    }
}
