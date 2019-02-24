using Bve5_Parsing.MapGrammar;
using Bve5_Parsing.ScenarioGrammar;
using System;
using System.Linq;

namespace Bve5_Parsing
{
    /// <summary>
    /// 各種構文解析器の動作確認が出来ます。
    /// </summary>
    class ParseSampleApp
    {
        /// <summary>
        /// 構文解析のテストモード
        /// </summary>
        public enum GrammarTestMode
        {
            DIALOGUE,
            DIRECTLY
        }

        /// <summary>
        /// 構文解析器の種類
        /// </summary>
        public enum GrammarTypes
        {
            MAP,
            SCENARIO
        }

        public const GrammarTestMode TEST_MODE = GrammarTestMode.DIALOGUE;
        public const string INPUT_STRING = "";
        public const GrammarTypes DIRECT_TYPE = GrammarTypes.SCENARIO;

        /// <summary>
        /// テストする構文解析器をユーザに選択させます。
        /// </summary>
        /// <returns>テストする構文解析器</returns>
        private static GrammarTypes SelectGrammarTestType()
        {
            Console.WriteLine("Select the syntax to test from the numbers below.");
            foreach (GrammarTypes type in Enum.GetValues(typeof(GrammarTypes)))
            {
                Console.WriteLine($"{(int)type} : {type.ToString()}");
            }
            int select = int.Parse(Console.ReadLine());

            return (GrammarTypes)select;
        }

        /// <summary>
        /// 構文解析のテストを行う文字列をユーザに入力させます。
        /// </summary>
        /// <returns>解析する文字列</returns>
        private static string InteractiveTest()
        {
            string input = "";
            Console.WriteLine("Input your syntax. Enter \"EOF\" to end input.");
            string line = Console.ReadLine();
            while (!line.ToLower().Equals("eof"))
            {
                input += line + Environment.NewLine;
                line = Console.ReadLine();
            }

            return input;
        }

        /// <summary>
        /// 構文解析のテストメソッドを呼び出します。
        /// </summary>
        /// <param name="input">解析する文字列</param>
        /// <param name="type">構文解析器の種類</param>
        private static void Testing(string input, GrammarTypes type)
        {
            switch (type)
            {
                case GrammarTypes.MAP:
                    MapGrammarTest(input);
                    break;
                case GrammarTypes.SCENARIO:
                    ScenarioGrammarTest(input);
                    break;
            }
        }


        /// <summary>
        /// シナリオ構文のテストを行います。
        /// </summary>
        /// <param name="input">構文文字列</param>
        private static void ScenarioGrammarTest(string input)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("ScenarioGrammar Parser Output:");

            ScenarioGrammarParser parser = new ScenarioGrammarParser();
            ScenarioData data = null;
            try
            {
                data = parser.Parse(input);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message + ":" + e.StackTrace);
            }
        }

        /// <summary>
        /// マップ構文のテストを行います。
        /// </summary>
        /// <param name="input">構文文字列</param>
        private static void MapGrammarTest(string input)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("MapGrammar Parser Output:");

            MapGrammarParser parser = new MapGrammarParser();
            MapData data = null;
            data = parser.Parse(input);

            Console.Error.WriteLine("Errors:###################################");
            foreach(var error in parser.ParserErrors.OrderBy(e => e.Line).ThenBy(e => e.Column))
            {
                Console.Error.WriteLine("[{0}:{1}] {2}: {3}", error.Line, error.Column, error.ErrorLevel, error.Message);
            }
            Console.Error.WriteLine("##########################################");

            //結果の表示
            Console.WriteLine($"Version: {data.Version}");
            Console.WriteLine($"Encoding: {data.Encoding}");
            Console.WriteLine($"StructureListPath: {data.StructureListPath}");
            Console.WriteLine($"StationListPath: {data.StationListPath}");
            Console.WriteLine($"SignalListPath: {data.SignalListPath}");
            Console.WriteLine($"SoundListPath: {data.SoundListPath}");
            Console.WriteLine($"Sound3DListPath: {data.Sound3DListPath}");
            foreach(var statement in data.Statements)
            {
                Console.WriteLine("---------------SyntaxData----------------");
                Console.WriteLine($"Distance: {statement.Distance}");
                for (int i = 0; i < statement.MapElement.Length; i++)
                    Console.WriteLine($"MapElement[{i}]: {statement.MapElement[i]}");
                Console.WriteLine($"Key: {statement.Key}");
                Console.WriteLine($"Function: {statement.Function}");

                Console.WriteLine("Args:");
                foreach(var arg in statement.Arguments)
                {
                    Console.WriteLine($"{arg.Key}: {arg.Value}");
                }
            }
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("################################################");
            Console.WriteLine("# Bve5_Parsing Syntax Testing.                 #");
            Console.WriteLine("################################################");

            bool end = false;
            while (!end)
            {
                switch (TEST_MODE)
                {
                    case GrammarTestMode.DIALOGUE:
                        GrammarTypes type = SelectGrammarTestType();
                        string input = InteractiveTest();
                        Testing(input, type);
                        break;
                    case GrammarTestMode.DIRECTLY:
                        Testing(INPUT_STRING, DIRECT_TYPE);
                        break;
                }

                //終了判定
                Console.WriteLine("End it? Y/N");
                string endInput = Console.ReadLine();
                if (endInput.Equals("Y") || endInput.Equals("y"))
                {
                    end = true;
                }
            }
        }
    }
}
