using System;
using Irony.Interpreter;
using Irony.Parsing;
using Irony.Interpreter.Ast;
using Irony.Ast;

namespace IronyTest
{
    [Language("SimpleGrammar")]
    class SimpleGrammar : InterpretedLanguageGrammar
    {
        public SimpleGrammar() : base(true)
        {
            NumberLiteral Number = new NumberLiteral("Number");
            KeyTerm Comma = ToTerm(",");

            NonTerminal Numbers = new NonTerminal("Numbers", typeof(NumbersNode));
            Numbers.Rule = Number + Comma + Number;

            Root = Numbers;

            LanguageFlags = LanguageFlags.CreateAst;
        }
    }

    public class NumbersNode : AstNode
    {
        public AstNode Left { get; private set; }
        public AstNode Right { get; private set; }
        public AstNode Plus { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            ParseTreeNodeList nodes = treeNode.GetMappedChildNodes();
            Left = AddChild("Left", nodes[0]);
            Right = AddChild("Right", nodes[2]);
        }

        protected override object DoEvaluate(ScriptThread thread)
        {
            thread.CurrentNode = this;

            int[] result = new int[2];
            result[0] = (int)Left.Evaluate(thread);
            result[1] = (int)Right.Evaluate(thread);

            thread.CurrentNode = Parent;

            return result;
        }
    }
}