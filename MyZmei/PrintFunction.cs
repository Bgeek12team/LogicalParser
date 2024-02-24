namespace MyZmei;

public class PrintFunction : IFunction
{
    public string StringValue { get; } = "show";
    public string CalculateResult(string exp) => exp;

    public string TrimSelf(Expression tokens)
    {
        string res = "";
        foreach(var tk in tokens.Tokens)
        {
            if (tk.Type != TokenType.FUNCTION)
                res += tk.StringValue + " ";
        }
        return res.Trim();
    }
}
