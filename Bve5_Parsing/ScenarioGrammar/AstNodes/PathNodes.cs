using Irony.Ast;
using Irony.Parsing;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using System.Collections.Generic;

namespace Bve5_Parsing.ScenarioGrammar.AstNodes
{
    /*
     * FilePath関係のAST木
     */

    /// <summary>
    /// ファイルパス構造体
    /// </summary>
    public struct FilePath
    {
        public string Value { get; set; }
        public double Weight { get; set; }
    }

    /// <summary>
    /// Route, Vehicle構文
    /// </summary>
    public class PathStatementNode : AstNode
    {
        public List<FilePath> Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Value = new List<FilePath>();
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if (nodes.Count > 1)
            {
                //ファイルパスの取得
                FilePathNode filePath = (FilePathNode)nodes[1].AstNode;
                Value.Add(filePath.PathData);
                AddChild("path1=" + Value[0].Value + ",weight=" + Value[0].Weight, nodes[1]);

                if (nodes.Count > 2)
                {
                    for (int i = 0; i < nodes[2].ChildNodes.Count; i++)
                    {
                        FilePathNode nextFilePath = (FilePathNode)nodes[2].ChildNodes[i].AstNode;
                        Value.Add(nextFilePath.PathData);
                        AddChild("path" + (i+2) + "=" + Value[i+1].Value + ",weight=" + Value[i+1].Weight, nodes[2].ChildNodes[i]);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Image構文
    /// </summary>
    public class ImageNode : AstNode
    {
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if (nodes.Count > 1)
            {
                //ファイルパスの取得
                Value = nodes[1].Token.Value.ToString();
                AddChild("Path=" + Value, nodes[1]);
            }
        }
    }

    public class FilePathsNode : AstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            if(nodes.Count > 0)
                AddChild("FilePaths", nodes[0]);
        }
    }

    /// <summary>
    /// FilePath * 重み係数
    /// </summary>
    public class FilePathNode : AstNode
    {
        public FilePath PathData;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            PathData = new FilePath();
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            if(nodes.Count > 1)
            {
                //重み係数あり
                PathData.Value = nodes[0].Token.Value.ToString();
                PathData.Weight = double.Parse(nodes[1].Token.Value.ToString());
            }
            else
            {
                //重み係数なし
                PathData.Value = nodes[0].Token.Value.ToString();
                PathData.Weight = 1;
            }
        }
    }
}