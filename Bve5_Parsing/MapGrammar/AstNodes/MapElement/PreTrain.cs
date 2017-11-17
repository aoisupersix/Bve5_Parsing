using Irony;
using Irony.Ast;
using Irony.Parsing;
using System.Text.RegularExpressions;

namespace Bve5_Parsing.MapGrammar.AstNodes.PreTrain
{
    /*
     * PreTrainのAST木定義
     */

    /// <summary>
    /// PreTrain.Pass('hh:mm:ss') | PreTrain.Pass(second)
    /// </summary>
    public class PassNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            //形式が特殊なため、正規表現を利用して登録する
            ExprNode expr = (ExprNode)nodes[2].AstNode;

            Regex r = new Regex(@"(\d{1,2}):(\d{1,2}):(\d{1,2})");
            Match m = r.Match(expr.Value.ToString());
            if (m.Success)
            {
                //hh:mm:ss
                int hh = int.Parse(m.Groups[1].Value);
                int mm = int.Parse(m.Groups[2].Value);
                int ss = int.Parse(m.Groups[3].Value);
                AddChild("hh:" + hh + "mm:" + mm + "ss:" + ss, nodes[0]);

                //フォーマットの確認
                if(hh >= 0 && hh < 25 && mm >= 0 && mm < 60 && ss >= 0 && ss < 60)
                {
                    Data.Arguments.Add("hh", hh);
                    Data.Arguments.Add("mm", mm);
                    Data.Arguments.Add("ss", ss);
                }
                else
                {
                    LogMessage logMessage = new LogMessage(ErrorLevel.Error, this.Location, "引数に与えられたフォーマットが不正です。:" + hh + ":" + mm + ":" + ss, Context.Language.ParserData.States[Context.Language.ParserData.States.Count - 1]);
                    Context.Messages.Add(logMessage);
                }
            }
            else
            {
                //sec
                AddArguments("second", nodes, 2, typeof(double));
            }
        }
    }
}
