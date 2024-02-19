using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogicalParsing;
/// <summary>
/// Таблица истинности (читать блять умеем?)
/// </summary>
/// <param name="Header"></param>
/// <param name="Table"></param>
public class TruthTable(List<string> header, List<List<bool>> table)
{
    List<string> Headers { get; init; } = header;
    List<List<bool>> Table { get; init; } = table;
    // будет такая хуйня типа выражение A && B || !C
    // Headers = {"A", "B", "C"}
    // Table
    // {false, false, false, true}
    // {false, false, true, false}
    // {false, true, false, true}
    // {false, false, true, false}
    // {true, false, false, true}
    // {true, false, true, false}
    // {true, true, false, true}
    // {true, true, true, true}
    // типа первые n столбцов это переменные в порядке хидера
    // а дальше результат значения выражения
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
        var headers = function.GetVariables();
        var table = FillBody(function, headers);
        return new TruthTable(headers, table);
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
            var result = Convert.ToBoolean(func.CalculateAt([], dict));
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
            var result = Convert.ToBoolean(func.CalculateAt([], dict));
            curList.Add(result);
            res.Add(curList);
        }

        RecursiveFillBody(func, dict, res, vars, ind + 1);


        dict[vars[ind]] = v;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append("headers: ");
        foreach (var header in Headers)
        {
            sb.Append(header + " ");
        }
        sb.Remove(sb.Length - 1, 1);
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
