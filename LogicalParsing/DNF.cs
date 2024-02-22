using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace LogicalParsing;
public class DNF(Expression exp)
{
    public Expression LogicalExpression { get; init; } = exp;
    internal static DNF ToDNF(TruthTable truthTable)
    {
        var res = new StringBuilder();
        List<string> dnfTerms = [];

        foreach (List<bool> tupl in truthTable.Table)
            if (tupl[tupl.Count - 1])
            {
                string term = "(";
                for (int i = 0; i < tupl.Count - 1; i++)
                {
                    term += !tupl[i] ? "!" + truthTable.Headers[i] : truthTable.Headers[i];
                    if (i != truthTable.Headers.Count - 1)
                        term += " & ";
                }
                term += ")";
                dnfTerms.Add(term);
            }
        res.AppendJoin(" | ", [.. dnfTerms]);
        return new DNF(new Expression(res.ToString()));
    }

    public override string ToString()
    {
        return LogicalExpression.ToString();
    }
}
