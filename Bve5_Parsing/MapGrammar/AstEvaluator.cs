﻿using Bve5_Parsing.MapGrammar.AstNodes;
using System;

namespace Bve5_Parsing.MapGrammar
{
    /**
     * ASTを辿って木を評価する
     */

    internal abstract class AstVisitor<T>
    {
        public abstract T Visit(RootNode node);
        public abstract T Visit(DistanceNode node);
        public abstract T Visit(Syntax1Node node);
        public abstract T Visit(Syntax2Node node);
        public abstract T Visit(Syntax3Node node);
        public abstract T Visit(LoadListNode node);
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
        /// <summary>
        /// 評価結果
        /// </summary>
        private MapData evaluateData;

        /// <summary>
        /// 現在評価中の距離程
        /// </summary>
        private double nowDistance = 0;

        /// <summary>
        /// ルートノードの評価
        /// </summary>
        /// <param name="node">ルートノード</param>
        /// <returns>解析結果のMapData</returns>
        public override object Visit(RootNode node)
        {
            evaluateData = new MapData();
            foreach(var state in node.StatementList)
            {
                object childData = Visit(state);
                if(childData != null)
                    evaluateData.Statements.Add((SyntaxData)childData);
            }

            return evaluateData;
        }

        public override object Visit(DistanceNode node)
        {
            nowDistance = (double)Visit(node.Value);

            return null;
        }

        /// <summary>
        /// 構文タイプ1の評価
        /// </summary>
        /// <param name="node">Syntax1Node</param>
        /// <returns>解析結果のSyntaxDataクラス</returns>
        public override object Visit(Syntax1Node node)
        {
            SyntaxData returnData = new SyntaxData();
            //構文情報を登録する
            returnData.Distance = nowDistance;
            returnData.MapElement = new string[1];
            returnData.MapElement[0] = node.MapElementName;
            returnData.Function = node.FunctionName;
            foreach(string key in node.Arguments.Keys)
            {
                returnData.Arguments.Add(key, Visit(node.Arguments[key]));
            }

            return returnData;
        }

        /// <summary>
        /// 構文タイプ2の評価
        /// </summary>
        /// <param name="node">Syntax2Node</param>
        /// <returns>解析結果のSyntaxDataクラス</returns>
        public override object Visit(Syntax2Node node)
        {
            SyntaxData returnData = new SyntaxData();
            //構文情報を登録する
            returnData.Distance = nowDistance;
            returnData.MapElement = new string[1];
            returnData.MapElement[0] = node.MapElementName;
            returnData.Key = Visit(node.Key).ToString();
            returnData.Function = node.FunctionName;
            foreach (string key in node.Arguments.Keys)
            {
                returnData.Arguments.Add(key, Visit(node.Arguments[key]));
            }

            return returnData;
        }

        /// <summary>
        /// 構文タイプ3の評価
        /// </summary>
        /// <param name="node">Syntax3Node</param>
        /// <returns>解析結果のSyntaxDataクラス</returns>
        public override object Visit(Syntax3Node node)
        {
            SyntaxData returnData = new SyntaxData();
            //構文情報を登録する
            returnData.Distance = nowDistance;
            returnData.MapElement = node.MapElementNames;
            returnData.Key = Visit(node.Key).ToString();
            returnData.Function = node.FunctionName;
            foreach (string key in node.Arguments.Keys)
            {
                returnData.Arguments.Add(key, Visit(node.Arguments[key]));
            }

            return returnData;
        }

        /// <summary>
        /// リストファイルノードの評価
        /// リストファイルの参照パスを追加する
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override object Visit(LoadListNode node)
        {
            evaluateData.SetListPathToString(node.MapElementName, node.Path);
            return null;
        }

        /// <summary>
        /// 変数宣言ノードの評価
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public override object Visit(VarAssignNode node)
        {
            var val = Visit(node.Value);
            VariableStore.SetVar(node.VarName, val);
            return null;    //変数宣言ステートメントは不要なので捨てる
        }

        #region Evaluate Expression Nodes

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
            return VariableStore.GetVar(node.Key);
        }

        #endregion Evaluate Expression Nodes
    }
}
