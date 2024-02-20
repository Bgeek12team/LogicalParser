using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicalParsing;

namespace MyZmei;
internal static class DNFFunction
{
    public static string StringValue = "dnf";
    public static string CalculateResult(string exp) => new LogicalExpression(exp).GetDNF().ToString();

    public static string TrimSelf(Expression tokens)
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
