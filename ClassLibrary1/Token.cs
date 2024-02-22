﻿namespace ClassLibrary1;
/// <summary>
/// Токен, или же лексема, арифметического выражения
/// </summary>
/// <param name="str">строковое представление лексемы</param>
/// <param name="type">тип лексеы</param>
/// <param name="precendency">приоритет лексемы</param>
public partial class Token(string str, Token.TYPE type, int precendency)
{
    /// <summary>
    /// Словарь, связывающий строковое представление лексем
    /// их тип и приоритет
    /// </summary>
    internal static readonly Dictionary<string, (TYPE tokenType, int precendency)> tokenMap = new()
         {
            { "+",    (TYPE.BINARY_OPERATOR, 0) },
            { "-",    (TYPE.BINARY_OPERATOR, 0) },
            { "*",    (TYPE.BINARY_OPERATOR, 1) },
            { "/",    (TYPE.BINARY_OPERATOR, 1) },
            { "%",    (TYPE.BINARY_OPERATOR, 2) },
            { "^",    (TYPE.BINARY_OPERATOR, 2) },
            { "sin",  (TYPE.FUNCTION       , 3) },
            { "cos",  (TYPE.FUNCTION       , 3) },
            { "tg",   (TYPE.FUNCTION       , 3) },
            { "ctg",  (TYPE.FUNCTION       , 3) },
            { "exp",  (TYPE.FUNCTION       , 3) },
            { "ln",   (TYPE.FUNCTION       , 3) },
            { "sqrt", (TYPE.FUNCTION       , 3) },
            { "fact", (TYPE.FUNCTION       , 3) },
            { "(",    (TYPE.L_BRACE        , -4) },
            { ")",    (TYPE.R_BRACE        , -4) },
            { "e",    (TYPE.CONSTANT       , NUMBER_PRECENDENCY)},
            { "pi",   (TYPE.CONSTANT       , NUMBER_PRECENDENCY)},
            { "<",    (TYPE.ARIPTHMETIC_BOOLEAN_OPERATOR, -1)},
            { ">",    (TYPE.ARIPTHMETIC_BOOLEAN_OPERATOR, -1)},
            { "=>",   (TYPE.BOOLEAN_BOOLEAN_OPERATOR, -1)},
            { "=",    (TYPE.ARIPTHMETIC_BOOLEAN_OPERATOR, -1)},
            { "&",    (TYPE.BOOLEAN_BOOLEAN_OPERATOR, -1)},
            { "|",    (TYPE.BOOLEAN_BOOLEAN_OPERATOR, -2)},
            { "!",    (TYPE.BOOLEAN_FUNCTION, 3)},
            { "true", (TYPE.BOOLEAN_CONSTANT, NUMBER_PRECENDENCY)},
            { "false",(TYPE.BOOLEAN_CONSTANT, NUMBER_PRECENDENCY)},

        };

    internal const char COMMA = ',';
    internal const int NUMBER_PRECENDENCY = 11;
    /// <summary>
    /// Тип текущего токена
    /// </summary>
    public TYPE Type { get => type; private set => type = value; }

    /// <summary>
    /// Строка, отображающая токен
    /// </summary>
    public string TokenString { get => str; }
    /// <summary>
    /// Приоритет токена
    /// </summary>
    public int Precendency { get => precendency; }


    public Type ExpectedType { get; set; }
    /// <summary>
    /// Функция, извлекающая из строки массив токенов
    /// </summary>
    /// <param name="str">Обрабатываемая строка</param>
    /// <returns>Массив токенов, представляющий строку</returns>
    public static Token[] Tokenize(string str)
    {
        var tokens = new List<Token>();
        var start = 0;
        while (start < str.Length)
        {
            if (Char.IsWhiteSpace(str[start]))
            {
                start++;
                continue;
            }
            var adj = ParseNum(tokens, str, start);
            if (adj > start)
            {
                start = adj;
                continue;
            }
            if (start > str.Length - 1)
            {
                break;
            }
            var end = start;
            bool findToken = true;
            Token token = new("0", TYPE.INT_NUM, 0);
            while (end < str.Length &&
                !Char.IsWhiteSpace(str[end]) &&
                !Find(ref end, out token, str))
            {
                end++;
                findToken = false;
            }
            if (!findToken)
                tokens.Add(new(str[start.. end], TYPE.VARIABLE, NUMBER_PRECENDENCY));
            if (findToken)
                tokens.Add(token);
            start = end;
        }
        ParseUnary(tokens);

        return [.. tokens];
    }

    static bool Find(ref int start, out Token token, string str)
    {
        foreach (var tokenStr in tokenMap.Keys)
            if (str[start..].StartsWith(tokenStr))
            {
                var (tokenType, precendency) = tokenMap[tokenStr];
                token = (new(tokenStr, tokenType, precendency));
                start += tokenStr.Length;
                return true;
            }

        token = null;
        return false;
    }
    /// <summary>
    /// Преобразует бинарные минусы в унарные при необходимости
    /// </summary>
    /// <param name="tokens">Обрабатываемый список токенов</param>
    private static void ParseUnary(List<Token> tokens)
    {
        if (tokens[0].TokenString == "-")
            tokens[0].Type = TYPE.FUNCTION;

        for (var i = 1; i < tokens.Count - 1; i++)
        {
            if (tokens[i].TokenString == "-")
            {
                var prevToken = tokens[i - 1];
                var nextToken = tokens[i + 1];
                var isBinary = prevToken.IsNumber() && nextToken.IsNumber() ||
                               prevToken.Type == TYPE.R_BRACE && nextToken.Type == TYPE.L_BRACE ||
                               prevToken.IsNumber() && nextToken.Type == TYPE.L_BRACE ||
                               prevToken.Type == TYPE.R_BRACE && nextToken.IsNumber();
                if (!isBinary)
                {
                    tokens[i].Type = TYPE.FUNCTION;
                }
            }
        }
    }
    /// <summary>
    /// Проверяет, является ли токен числом в том или ином виде
    /// </summary>
    /// <returns>
    /// True: токен является числом в том или ином виде
    /// False: все иные случаи
    /// </returns>
    public bool IsNumber()
        => this.Type == TYPE.FLOAT_NUM || this.Type == TYPE.INT_NUM ||
           this.Type == TYPE.CONSTANT ||
           (this.Type == TYPE.VARIABLE && !bool.TryParse(this.TokenString, out _));

    public bool IsBoolean() =>
        (this.Type == TYPE.VARIABLE && bool.TryParse(this.TokenString, out _)) ||
        (this.Type == TYPE.BOOLEAN_CONSTANT);

    /// <summary>
    /// Обрабатывает число в списке токенов
    /// </summary>
    /// <param name="tokens">список токенов</param>
    /// <param name="str">Обрабатываемая строка</param>
    /// <param name="start">Индекс, с которого начинается обработка чисел</param>
    /// <returns>Индекс, следующий за последним символом строки</returns>
    private static int ParseNum(List<Token> tokens, string str, int start)
    {
        var end = str.Length;
        while (end > start)
        {
            var parsableSubString = str[start..end];

            if (parsableSubString.Contains(COMMA))
            {
                if (double.TryParse(parsableSubString, out _))
                {
                    tokens.Add(new Token(str[start..end], TYPE.FLOAT_NUM, NUMBER_PRECENDENCY));
                    return end;
                }
            }
            if (int.TryParse(parsableSubString, out _))
            {
                tokens.Add(new Token(str[start..end], TYPE.INT_NUM, NUMBER_PRECENDENCY));
                return end;
            }
            end--;
        }
        return end;
    }
    /// <summary>
    /// Возвращает строковое представление токена
    /// </summary>
    /// <returns>Тип токена и строку, его представляющую</returns>
    public override string ToString()
    {
        var res = $"[ string: {str} ;" +
            $"tokenType: {type} ;" +
            $"precendency: {precendency} ;";

        if (ExpectedType is not null)
            res +=
            $"expected type: {ExpectedType}";

        res += "]";
        return res;
    }
}