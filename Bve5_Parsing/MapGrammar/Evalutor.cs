using System;
using System.Collections.Generic;
using Irony.Parsing;

namespace Bve5_Parsing.MapGrammar
{
    public class Evaluator
    {
        ParseTree parseTree;
        public Evaluator(ParseTree tree)
        {
            parseTree = tree;
            ShowTree(0, tree.Root);
        }

        private void ShowTree(int hierarchy, ParseTreeNode node)
        {
            for(int i = 0; i < hierarchy; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("node {0}:{1}", hierarchy, node.ToString());

            foreach(var childNode in node.ChildNodes)
            {
                ShowTree(hierarchy + 1, childNode);
            }
        }
    }
}
