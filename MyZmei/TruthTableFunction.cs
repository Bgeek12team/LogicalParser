using LogicalParsing;

namespace MyZmei;

internal class TruthTableFunction : IFunction
{
    public string StringValue { get; } = "ttable";
    public string CalculateResult(string exp)
    {
        var expr = new ClassLibrary1.Expression(exp);
        return TruthTable.FillTable(expr)?.ToString() ?? "incorrect expression";
    }

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
