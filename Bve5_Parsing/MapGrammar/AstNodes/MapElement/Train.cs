using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Train
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
            AddArguments("trainkey", nodes, 2, typeof(string));
            AddArguments("filePath", nodes, 3, typeof(string));
            AddArguments("trackkey", nodes, 4, typeof(string));
            AddArguments("direction", nodes, 5, typeof(double)); //1 or -1
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
            AddArguments("filePath", nodes, 3, typeof(string));
            AddArguments("trackkey", nodes, 4, typeof(string));
            AddArguments("direction", nodes, 5, typeof(double)); //1 or -1
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
                AddArguments("hh", nodes, 3, typeof(double));
                AddArguments("mm", nodes, 4, typeof(double));
                AddArguments("ss", nodes, 5, typeof(double));
            }
            else
            {
                //sec
                AddArguments("second", nodes, 3, typeof(double));
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
            AddArguments("decelerate", nodes, 3, typeof(double));
            AddArguments("stopTime", nodes, 4, typeof(double));
            AddArguments("accelerate", nodes, 5, typeof(double));
            AddArguments("speed", nodes, 6, typeof(double));
        }
    }
}