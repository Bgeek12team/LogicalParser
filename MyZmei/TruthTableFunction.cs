using LogicalParsing;

namespace MyZmei;

internal static class TruthTableFunction
{
    public static string StringValue = "ttable";
    public static string CalculateResult(string exp)
    {
        var expr = new ClassLibrary1.Expression(exp);
        return TruthTable.FillTable(expr)?.ToString() ?? "incorrect expression";
    }

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
