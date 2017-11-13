using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar_Careless.AstNodes.Train
{
    /*
     * TrainのAST木定義
     */

    /// <summary>
    /// Train.Add(trainkey, filePath, trackkey, direction)
    /// </summary>
    public class AddNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("trainkey", nodes, 2);
            AddArguments("filePath", nodes, 3);
            AddArguments("trackkey", nodes, 4);
            AddArguments("direction", nodes, 5); //1 or -1
        }
    }

    /// <summary>
    /// Train[key].Load(filePath, trackkey, direction)
    /// </summary>
    public class LoadNode : Syntax_2
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("filePath", nodes, 3);
            AddArguments("trackkey", nodes, 4);
            AddArguments("direction", nodes, 5); //1 or -1
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
                AddArguments("hh", nodes, 3);
                AddArguments("mm", nodes, 4);
                AddArguments("ss", nodes, 5);
            }
            else
            {
                //sec
                AddArguments("second", nodes, 3);
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
            AddArguments("decelerate", nodes, 3);
            AddArguments("stopTime", nodes, 4);
            AddArguments("accelerate", nodes, 5);
            AddArguments("speed", nodes, 6);
        }
    }
}