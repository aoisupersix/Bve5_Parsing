using Irony.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes.LightNodes
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
            AddArguments("red", nodes[2]);
            AddArguments("green", nodes[3]);
            AddArguments("blue", nodes[4]);
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
            AddArguments("red", nodes[2]);
            AddArguments("green", nodes[3]);
            AddArguments("blue", nodes[4]);
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
            AddArguments("pitch", nodes[2]);
            AddArguments("yaw", nodes[3]);
        }
    }
}
