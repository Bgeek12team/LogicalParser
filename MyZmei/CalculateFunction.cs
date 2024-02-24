﻿namespace MyZmei;

public class CalculateFunction : IFunction
{
    public string StringValue { get; } = "calc";
    public string CalculateResult(string exp)
    {
        var resExp = new ClassLibrary1.Expression(exp);

        if (resExp.ParseTree())
            return resExp.CalculateAt([], []).ToString();
        else
            return "incorrect variables";
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
