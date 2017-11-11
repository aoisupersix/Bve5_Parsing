using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.Train
{
    /*
     * TrainのAST木定義
     */

    /// <summary>
    /// Train[key].Add(trainkey, filePath, trackkey, direction)
    /// </summary>
    public class AddNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("trainkey", nodes[3]);
            AddArguments("filePath", nodes[4]);
            AddArguments("trackkey", nodes[5]);
            AddArguments("direction", nodes[6]); //1 or -1
        }
    }

    /// <summary>
    /// Train[key].Enable('hh:mm:ss') | Train[key].Enable(second)
    /// </summary>
    public class EnableNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            if (nodes.Count > 4)
            {
                //hh:mm:ss TODO
                AddArguments("hh", nodes[3]);
                AddArguments("mm", nodes[4]);
                AddArguments("ss", nodes[5]);
            }
            else
            {
                //sec
                AddArguments("second", nodes[3]);
            }
        }
    }

    /// <summary>
    /// Train[key].Stop(decelerate, stopTime, accelerate, speed)
    /// </summary>
    public class StopNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("decelerate", nodes[3]);
            AddArguments("stopTime", nodes[4]);
            AddArguments("accelerate", nodes[5]);
            AddArguments("speed", nodes[6]);
        }
    }
}