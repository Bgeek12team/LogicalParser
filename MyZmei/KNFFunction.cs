using LogicalParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZmei;

public static class KNFFunction
{
    public static string StringValue = "knf";
    public static string CalculateResult(string exp) => new LogicalExpression(exp).GetKNF().ToString();

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
