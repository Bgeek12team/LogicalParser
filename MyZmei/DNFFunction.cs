using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicalParsing;

namespace MyZmei;
internal class DNFFunction : IFunction
{
    public string StringValue { get; } = "dnf";
    public string CalculateResult(string exp) 
        => new LogicalExpression(exp).GetDNF()?.ToString() ?? "incorrect expression";

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
