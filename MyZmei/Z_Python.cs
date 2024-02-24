
namespace MyZmei;

public static class Z_Python
{
    static Zmeya context = new();
    static Stack<Expression> history = new();

    static Dictionary<string, string> lineComands = new()
    {
        { "last", $"{(history.Count > 0 ? history.Pop() : "?")}" }
    };

    public static string Eval(string str)
    {
        if (lineComands.TryGetValue(str, out string? value)) str = value;
        var tokens = Token.Tokenize(str);
        var exp = new Expression(tokens);
        history.Push(exp);
        return context.EvaluateExpression(exp);
    }
}