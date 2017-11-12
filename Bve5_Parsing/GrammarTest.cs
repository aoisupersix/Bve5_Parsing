using System;
using System.Collections.Generic;
using Irony.Interpreter;
using Irony.Parsing;

namespace Bve5_Parsing
{
    class GrammarTest
    {
        static void Main(String[] args)
        {
            Console.WriteLine("ScenariosGrammarTest");
            string scenario = "BveTs Scenario 1.00";

            try
            {
                ScriptApp app = new ScriptApp(new LanguageData(new ScenarioGrammar.ScenarioGrammar()));
                Dictionary<string, string> result = (Dictionary<string, string>)app.Evaluate(scenario);
                foreach (var p in result)
                {
                    Console.WriteLine("Key: {0} -> Val: {1}", p.Key, p.Value);
                }
            }
            catch (ScriptException e)
            {
                Console.Error.WriteLine("{0} {1}", e.Location, e.Message);
            }

            Console.ReadLine();
        }
    }
}
