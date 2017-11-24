using Bve5_Parsing.MapGrammar.AstNodes;
using System;

namespace Bve5_Parsing.MapGrammar
{
    /**
     * ASTを辿って木を評価する
     */

    internal abstract class AstVisitor<T>
    {
        public abstract T Visit(VarAssignsNode node);
        public abstract T Visit(VarAssignNode node);
        public abstract T Visit(AdditionNode node);
        public abstract T Visit(SubtractionNode node);
        public abstract T Visit(MultiplicationNode node);
        public abstract T Visit(DivisionNode node);
        public abstract T Visit(NegateNode node);
        public abstract T Visit(ModuloNode node);
        public abstract T Visit(NumberNode node);
        public abstract T Visit(StringNode node);
        public abstract T Visit(VarNode node);

        public T Visit(MapGrammarAstNodes node)
        {
            return Visit((dynamic)node);
        }
    }

    internal class EvaluateMapGrammarVisitor : AstVisitor<object>
    {
        public override object Visit(VarAssignsNode node)
        {
            foreach (var varAssign in node.VarAssigns)
            {
                Visit(varAssign);
            }

            return true;
        }

        public override object Visit(VarAssignNode node)
        {
            var val = Visit(node.Value);
            Vars.SetVar(node.VarName, val);
            return val;
        }

        public override object Visit(AdditionNode node)
        {
            if (Visit(node.Left).GetType() == typeof(string) || Visit(node.Right).GetType() == typeof(string))
                return Visit(node.Left).ToString() + Visit(node.Right).ToString();

            return (double)Visit(node.Left) + (double)Visit(node.Right);

        }

        public override object Visit(SubtractionNode node)
        {
            if (Visit(node.Left).GetType() == typeof(string) || Visit(node.Right).GetType() == typeof(string))
                throw new FormatException();
            return (double)Visit(node.Left) - (double)Visit(node.Right);
        }

        public override object Visit(MultiplicationNode node)
        {
            if (Visit(node.Left).GetType() == typeof(string) || Visit(node.Right).GetType() == typeof(string))
                throw new FormatException();
            return (double)Visit(node.Left) * (double)Visit(node.Right);
        }

        public override object Visit(DivisionNode node)
        {
            if (Visit(node.Left).GetType() == typeof(string) || Visit(node.Right).GetType() == typeof(string))
                throw new FormatException();
            return (double)Visit(node.Left) / (double)Visit(node.Right);
        }

        public override object Visit(NegateNode node)
        {
            if (Visit(node.InnerNode).GetType() == typeof(string))
                throw new FormatException();
            return -(double)Visit(node.InnerNode);
        }

        public override object Visit(ModuloNode node)
        {
            if (Visit(node.Left).GetType() == typeof(string) || Visit(node.Right).GetType() == typeof(string))
                throw new FormatException();
            return (double)Visit(node.Left) % (double)Visit(node.Right);
        }

        public override object Visit(NumberNode node)
        {
            return node.Value;
        }

        public override object Visit(StringNode node)
        {
            return node.Value;
        }

        public override object Visit(VarNode node)
        {
            return Vars.GetVar(node.Key);
        }
    }
}
