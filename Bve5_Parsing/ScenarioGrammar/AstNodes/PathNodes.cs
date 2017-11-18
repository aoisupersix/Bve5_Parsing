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
    /// FilePath * 重み係数
    /// </summary>
    public class FilePathNode : AstNode
    {
        public string Value { get; private set; }
        public double Weight { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            if(nodes.Count > 1)
            {
                //重み係数あり
                Value = nodes[0].Token.Value.ToString();
                Weight = double.Parse(nodes[1].Token.Value.ToString());
            }
            else
            {
                //重み係数なし
                Value = nodes[0].Token.Value.ToString();
                Weight = 1;
            }
        }
    }
}