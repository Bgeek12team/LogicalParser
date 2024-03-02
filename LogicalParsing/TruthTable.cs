using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicalParsing;
/// <summary>
/// Таблица истинности
/// </summary>
/// <param name="Header"></param>
/// <param name="Table"></param>
public class TruthTable(List<string> header, List<List<bool>> table)
{
    public List<string> Headers { get; init; } = header;
    public List<List<bool>> Table { get; init; } = table;

    // 
    /// <summary>
    /// Заполняет таблицу истинности для данной функции
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    public static TruthTable FillTable(Expression function)
    {
        if (!function.ParseTree() || !function.IsBooleanExpression)
            return null;
        var headers = FindVariables(function);
        var table = FillBody(function, headers);
        return new TruthTable(headers, table);
    }

    static List<string> FindVariables(Expression function)
    {
        var res = new List<string>();
        RecursiveFindVariables(function.TreeNode, res);
        return res;
    }

    static void RecursiveFindVariables(Node<Token> node, List<string> list)
    {
        if (node == null)
            return;
        if (node.Value.Type == Token.TYPE.ARIPTHMETIC_BOOLEAN_OPERATOR ||
            (node.Value.Type == Token.TYPE.VARIABLE && node.Value.ExpectedType == typeof(bool)))
        {
            list.Add(node.ToString().Trim());
            return;
        }
        RecursiveFindVariables(node.Left, list);
        RecursiveFindVariables(node.Right, list);
    }

    static List<List<bool>> FillBody(Expression func, List<string> vars)
    {
        Dictionary<string, bool> dict = new();
        foreach (var variable in vars)
            dict.Add(variable, false);

        var res = new List<List<bool>>();
        res.TrimExcess();
        RecursiveFillBody(func, dict,res, vars, 0);
        return res;
    }

    static void RecursiveFillBody
    (Expression func, Dictionary<string, bool> dict, List<List<bool>> res, List<string> vars, int ind)
    {

        if (ind > vars.Count - 1)
            return;

        if (ind == vars.Count - 1)
        {
            var curList = new List<bool>();
            foreach (var variable in vars)
                curList.Add(dict[variable]);

            string exp = func.StringExpression;
            foreach (var kv in dict)
                exp = exp.Replace(kv.Key, kv.Value.ToString());

            var result = Convert.ToBoolean(new Expression(exp).CalculateAt([], dict));
            curList.Add(result);
            res.Add(curList);
        }

        RecursiveFillBody(func, dict, res, vars, ind + 1);

        bool v = !dict[vars[ind]];
        dict[vars[ind]] = v;

        if (ind == vars.Count - 1)
        {
            var curList = new List<bool>();
            foreach (var variable in vars)
                curList.Add(dict[variable]);

            string exp = func.StringExpression;
            foreach (var kv in dict)
                exp = exp.Replace(kv.Key, kv.Value.ToString());

            var result = Convert.ToBoolean(new Expression(exp).CalculateAt([], dict));
            curList.Add(result);
            res.Add(curList);
        }

        RecursiveFillBody(func, dict, res, vars, ind + 1);


        dict[vars[ind]] = v;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("headers: [");
        foreach (var header in Headers)
        {
            sb.Append(header + "], [");
        }
        sb.Remove(sb.Length - 3, 3);
        sb.Append('\n');
        foreach (var row in Table)
        {
            foreach (var variable in row)
            {
                sb.Append(variable + " ");
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append('\n');
        }
        return sb.ToString();
    }
}
