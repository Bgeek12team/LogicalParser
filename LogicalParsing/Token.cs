using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalParsing;

internal enum TokenType
{
    LEFT_BRACKET, // (
    RIGTH_BRACKET, // )
    VARIABLE, // A B C D или че угодно блять хоть й
    CONSTANT, // true либо false
    UNARY_OPERATOR, // логическое отрицание !
    BINARY_OPERATOR // || , &&, =>, ==
}
internal class Token(TokenType Type, string StringValue, int Precendency) // тип, строковый вид, приоритет
{
    //как блять в арифметическом парсере
    //матвей - твоя работа

    /// <summary>
    /// Из строки делает последовательность лексем
    /// </summary>
    /// <returns></returns>
    internal static Token[] Tokenize(string expression)
    {
        return default;
    }
}
