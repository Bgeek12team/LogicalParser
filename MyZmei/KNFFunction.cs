using LogicalParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZmei;

public class KNFFunction : IFunction
{
    public string StringValue { get; } = "knf";
    public string CalculateResult(string exp) 
        => new LogicalExpression(exp).GetKNF()?.ToString() ?? "incorrect expression";

    public string TrimSelf(Expression tokens)
    {
        string res = "";
        foreach (var tk in tokens.Tokens)
        {
            if (tk.Type != TokenType.FUNCTION)
                res += tk.StringValue + " ";
        }
        return res.Trim();
    }
}
