using System;
using Antlr4.Runtime;
using Bve5_Parsing.MapGrammar.AstNodes;
using Bve5_Parsing.MapGrammar.SyntaxDefinitions;

namespace Bve5_Parsing.MapGrammar
{
    /// <summary>
    /// MapGrammarの解析を行うクラス
    /// </summary>
    public class MapGrammarParser
    {
        /// <summary>
        /// 構文解析を行います。
        /// </summary>
        /// <param name="input">解析する文字列</param>
        public void Parse(string input)
        {
            VariableStore.ClearVar(); //変数の初期化
            AntlrInputStream inputStream = new AntlrInputStream(input);
            MapGrammarLexer lexer = new MapGrammarLexer(inputStream);
            CommonTokenStream commonTokneStream = new CommonTokenStream(lexer);
            SyntaxDefinitions.MapGrammarParser parser = new SyntaxDefinitions.MapGrammarParser(commonTokneStream);

            parser.AddErrorListener(new ErrorListener());
            parser.ErrorHandler = new MapGrammarErrorStrategy();

            try
            {
                var cst = parser.root();       
                var ast = new BuildAstVisitor().VisitRoot(cst);

                MapData value = (MapData)new EvaluateMapGrammarVisitor().Visit(ast);
                
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message, e.StackTrace);
            }
        }
    }
}
