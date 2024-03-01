﻿using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forms
{
    internal static class ParsingTree
    {
        private static List<string> result;
        public static List<string> ParseTree(string expression)
        {
            result = new List<string>();
            Dictionary<string, double> variables = new Dictionary<string, double>();
            var tokens = Token.Tokenize(expression);
            foreach (var item in tokens)
            {
                if (item.Type == Token.TYPE.VARIABLE)
                {
                    variables.TryAdd(item.TokenString, 1);
                }
            }
            var exp = new Expression(expression);
            //var value = exp.CalculateAt(variables);
            var node = exp.ParseTree(); 
            PrintParsingTree(exp.TreeNode);
            return result;
        }


        private static string[] PrintParsingTree(Node<Token> node, string indent = "", bool last = true)
        {

            if (node == null) return null;

            result.Add(indent);
            if (last)
            {
                result.Add("└─");
                indent += "  ";
            }
            else
            {
                result.Add("├─");
                indent += "| ";
            }

            result.Add(node.Value.TokenString + "\n");

            PrintParsingTree(node.Left, indent, node.Right == null);
            PrintParsingTree(node.Right, indent, true);
            return result.ToArray();
        }
    }
}
