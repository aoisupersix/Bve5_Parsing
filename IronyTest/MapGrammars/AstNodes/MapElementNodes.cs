using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Irony.Ast;
using Irony.Interpreter;
using Irony.Interpreter.Ast;
using Irony.Parsing;

namespace IronyTest.MapGrammars.AstNodes
{
    /// <summary>
    /// 構文情報を管理する構造体
    /// </summary>
    public struct SyntaxData
    {
        public string[] mapElement;
        public string key;
        public string function;
        public object[] arguments;
    }

    /// <summary>
    /// 定義ファイルの読み込み構文
    /// </summary>
    public class LoadListFileNode : AstNode
    {
        public string ElementName { get; private set; }
        public string FilePath { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            ElementName = nodes[0].Term.ToString();
            FilePath = (string)nodes[2].Token.Value;
            //括弧を削除
            FilePath = FilePath.Substring(0, FilePath.Length - 1);

            AddChild("Element-" + ElementName, nodes[0]);
            AddChild("FilePath-" + FilePath, nodes[2]);
        }
    }

    /// <summary>
    /// マップ要素.関数(引数,引数,...);
    /// </summary>
    public class Syntax_1 : AstNode
    {
        public SyntaxData Data;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data.mapElement = new string[1];
            Data.mapElement[0] = nodes[0].Term.ToString();
            Data.function = nodes[1].Term.ToString();

            //引数の登録
            if (nodes.Count > 2)
            {
                ArgNode arg = (ArgNode)nodes[2].ChildNodes[0].AstNode;
                Data.arguments = arg.Arg;
                AddChild("Args", nodes[2]);
            }
        }
    }

    /// <summary>
    /// マップ要素[キー].関数(引数,引数,...);
    /// </summary>
    public class Syntax_2 : AstNode
    {
        public SyntaxData Data;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data.mapElement = new string[1];
            Data.mapElement[0] = nodes[0].Term.ToString();
            Data.key = (string)nodes[1].Token.Value;
            Data.function = nodes[2].Term.ToString();

            AddChild(Data.mapElement[0] + "[" + Data.key + "]." + Data.function, nodes[0]);

            //引数の登録
            if (nodes.Count > 3)
            {
                ArgNode arg = (ArgNode)nodes[3].ChildNodes[0].AstNode;
                Data.arguments = arg.Arg;
                AddChild("Args", nodes[3]);
            }
        }
    }

    /// <summary>
    /// マップ要素[キー].マップ要素.関数(引数,引数,...);
    /// </summary>
    public class Syntax_3 : AstNode
    {
        public SyntaxData Data;

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();

            //マップ要素、キー、関数の登録
            Data.mapElement = new string[2];
            Data.mapElement[0] = nodes[0].Term.ToString();
            Data.mapElement[1] = nodes[2].Term.ToString();
            Data.key = (string)nodes[1].Token.Value;
            Data.function = nodes[3].Term.ToString();

            AddChild(Data.mapElement[0] + "[" + Data.key + "]." + Data.mapElement[1] + "." + Data.function, nodes[0]);

            //引数の登録
            if (nodes.Count > 4)
            {
                ArgNode arg = (ArgNode)nodes[4].ChildNodes[0].AstNode;
                Data.arguments = arg.Arg;
                AddChild("Args", nodes[4]);
            }
        }
    }

}
