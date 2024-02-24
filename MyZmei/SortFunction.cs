namespace MyZmei;

public class SortFunction : IFunction
{
    public string StringValue { get; } = "sort";
    public string CalculateResult(string exp)
    {
        var l = exp.Trim().Split(' ');
        var b = l.Select(Convert.ToDouble);
        return b.Order().Aggregate("", (a, b) => a + " " + b);
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
