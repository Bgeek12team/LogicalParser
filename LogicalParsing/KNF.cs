using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
namespace LogicalParsing;
public class KNF(Expression exp)
{
    Expression LogicalExpression { get; init; } = exp;

    /// <summary>
    /// Метод для получения конъюнкии переменной X или её отрицания в зависимости от 0/1 в булевом значении
    /// </summary>
    /// <param name="value">значение таблицы</param>
    /// <param name="varName">имя переменной</param>
    /// <returns></returns>
    static string GetTerm(bool value, string varName)
    {
        return !value ? varName : "!" + varName;
    }
    internal static KNF ToKNF(TruthTable truthTable)
    {
        StringBuilder cnf = new StringBuilder();
        List<string> cnfTerms = new List<string>();
        var varCount = truthTable.Table[0].Count - 1;

        for (int i = 0; i < truthTable.Table.Count; i++)
        {
            if (!truthTable.Table[i][varCount])
            {
                cnfTerms.Add("(" + string.Join(" | ", 
                    Enumerable.Range(0, varCount)
                    .Select(j => GetTerm(truthTable.Table[i][j], truthTable.Headers[j]))) + ")");
            }
        }
        cnf.AppendJoin(" & ", [.. cnfTerms]);
        return new KNF(new Expression(cnf.ToString()));
    }

    public override string ToString()
    {
        return LogicalExpression.ToString();
    }
}
