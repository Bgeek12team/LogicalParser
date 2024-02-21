using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalParsing;
public class KNF(LogicalExpression exp)
{
    LogicalExpression LogicalExpression { get; init; } = exp;

    internal static KNF ToKNF(TruthTable truthTable)
    {
        return default;
    }

    public override string ToString()
    {
        return base.ToString();
    }
}
