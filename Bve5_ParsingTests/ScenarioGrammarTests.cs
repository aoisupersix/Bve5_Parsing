using System;
using Xunit;
using Bve5_Parsing.ScenarioGrammar;
using System.Collections.Generic;
using System.Collections;

namespace Bve5_ParsingTests
{
    /// <summary>
    /// シナリオ構文のテスト
    /// </summary>
    public class ScenarioGrammarTests
    {
        /// <summary>
        /// 引数に与えられた構文文字列をパースします。
        /// </summary>
        /// <param name="input">マップ構文</param>
        /// <returns>MapData</returns>
        private ScenarioData ExecParse(string input)
        {
            var mParser = new ScenarioGrammarParser();
            ScenarioData data = null;
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

        /// <summary>
        /// Assert.NotNullとAssert.Equalを実行します。
        /// </summary>
        /// <param name="expected">パーサによって生成されたScenarioData</param>
        /// <param name="actual">確認用</param>
        private void Check(ScenarioData expected, ScenarioData actual)
        {
            Assert.NotNull(expected);
            Assert.Equal(expected, actual);
        }

        #region 各構文のテスト
        [Fact]
        public void RootTest()
        {
            // メモ：エンコード指定の前後には空白は入れられないはずだが、出来てしまう
            Check(
                ExecParse("BveTs Scenario 1.00"),
                new ScenarioData("1.00"));
            Check(
                ExecParse("BveTs Scenario 1.00:shift_jis"),
                new ScenarioData("1.00", "shift_jis"));
            Check(
                ExecParse("bVETS sCeNARIO 1.00:ShiFt_Jis"),
                new ScenarioData("1.00", "ShiFt_Jis"));
        }
        #endregion
    }
}
