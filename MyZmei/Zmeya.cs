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
    string ReplaceVariables(string str)
    {
        bool flag = false;
        while (!flag)
        {
            flag = true;
            foreach (var key in variables.Keys)
            {
                if (str.Contains($"{key.Name}"))
                {
                    str = str.Replace(key.Name, " " + variables[key].Value + " ");
                    flag = false;
                }
            }
        }
        return str;
    }
    string Evaluate(Expression expr)
    {
        if (expr.Tokens.Length < 1)
            return "i need something to evaluate";
        foreach(var function in Token.functions)
        {
            if (expr.Tokens[0].StringValue == function.StringValue)
            {
                var str = function.TrimSelf(expr);
                str = ReplaceVariables(str);
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
