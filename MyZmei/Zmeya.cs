namespace MyZmei;

public class Zmeya
{
    internal static Dictionary<VariableName, VariableValue> variables = [];
    public string EvaluateExpression(Expression expr) 
    {
        if (expr.ExpressionType == ExpressionTypes.ASSIGNMENT)
        {
            return ParseAssignment(expr);
        }
        else
        {
            return Evaluate(expr);
        }
            
    }
    string ReplaceVariables(Expression str)
    {
        bool flag = true;
        var res = str.ToString();
        Dictionary<string, bool> usedVariables = variables.Keys.ToDictionary(v => v.Name, v => false);
        res = res.Replace(str.Tokens[0].StringValue, "");
        while (flag)
        {
            flag = false;
            foreach (var tk in str.Tokens[1..])
            {
                if (tk.Type == TokenType.VARIABLE_NAME)
                {
                    foreach (var variable in variables.Keys)
                    {
                        if (tk.StringValue.Equals(variable.Name) &&
                            !usedVariables[tk.StringValue])
                        {
                            res = res.Replace(tk.StringValue, variables[variable].Value);
                            flag = true;
                            usedVariables[tk.StringValue] = true;
                        }
                    }
                }
            }
        }
    
        return res;
    }
    string Evaluate(Expression expr)
    {
        if (expr.Tokens.Length < 1)
            return "i need something to evaluate";
        foreach(var function in Token.functions)
        {
            if (expr.Tokens[0].StringValue == function.StringValue)
            {
                var str = ReplaceVariables(expr);
                return function.CalculateResult(str);
            }
        }
        return "unknown function";
    }

    string ParseAssignment(Expression expr)
    {
        if (expr.Tokens.Length < 4)
            return "incorrect assignment";

        var potentialName = new VariableName(expr.Tokens[1].StringValue);
        var assignedString = "";
        for (int i = 3; i < expr.Tokens.Length; i++)
        {
            if (expr.Tokens[i].Type == TokenType.SEPARATOR)
                break;
            assignedString += expr.Tokens[i].StringValue + " ";
        }
        var value = new VariableValue(assignedString);
        var found = false;
        foreach (var name in variables.Keys)
        {
            if (name.Equals(potentialName))
            {
                variables[name] = value;
                found = true;
            }
        }
        if (found)
            return $"reassigned {potentialName.Name} : {value.Value}";
        variables.Add(potentialName, value);
        return $"assigned {potentialName.Name} : {value.Value}";

    }
}
