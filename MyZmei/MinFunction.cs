using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZmei;

public class MinFunction : IFunction
{
    public string StringValue { get; } = "min";
    public string CalculateResult(string exp) 
        => exp.Trim().Split(' ').Min(Convert.ToDouble).ToString();

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
