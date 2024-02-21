﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZmei;

public static class MinFunction
{
    public static string StringValue = "min";
    public static string CalculateResult(string exp) 
        => exp.Trim().Split(' ').Min(Convert.ToDouble).ToString();

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

public static class SortFunction
{
    public static string StringValue = "sort";
    public static string CalculateResult(string exp)
    {
        var l = exp.Trim().Split(' ');
        var b = l.Select(Convert.ToDouble);
        return b.Order().Aggregate("", (a, b) => a + " " + b);
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
