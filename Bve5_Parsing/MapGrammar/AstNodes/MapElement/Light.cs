using Irony.Ast;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar.AstNodes.Light
{
    /*
     * LightのAST木定義
     */

    /// <summary>
    /// Light.Ambient(red, green, blue)
    /// </summary>
    public class AmbientNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録 0~1 TODO
            AddArguments("red", nodes, 2, typeof(double));
            AddArguments("green", nodes, 3, typeof(double));
            AddArguments("blue", nodes, 4, typeof(double));
        }
    }

    /// <summary>
    /// Light.Diffuse(red, green, blue)
    /// </summary>
    public class DiffuseNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録 0~1 TODO
            AddArguments("red", nodes, 2, typeof(double));
            AddArguments("green", nodes, 3, typeof(double));
            AddArguments("blue", nodes, 4, typeof(double));
        }
    }

    /// <summary>
    /// Light.Direction(pitch, yaw)
    /// </summary>
    public class DirectionNode : Syntax_1
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //引数の登録
            AddArguments("pitch", nodes, 2, typeof(double));
            AddArguments("yaw", nodes, 3, typeof(double));
        }
    }
}
