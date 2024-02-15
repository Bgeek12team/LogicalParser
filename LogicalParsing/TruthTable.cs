using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalParsing;
/// <summary>
/// Таблица истинности (читать блять умеем?)
/// </summary>
/// <param name="Header"></param>
/// <param name="Table"></param>
internal class TruthTable(List<string> header, List<List<bool>> Table)
{
    List<string> Header { get; init; } = header;
    // будет такая хуйня типа выражение A && B || !C
    // Headers = {"A", "B", "C"}
    // Table
    // {false, false, false, true}
    // {false, false, true, false}
    // {false, true, false, true}
    // {false, false, true, false}
    // {true, false, false, true}
    // {true, false, true, false}
    // {true, true, false, true}
    // {true, true, true, true}
    // типа первые n столбцов это переменные в порядке хидера
    // а дальше результат значения выражения
    /// <summary>
    /// Заполняет таблицу истинности для данной функции
    /// </summary>
    /// <param name="function"></param>
    /// <returns></returns>
    internal static TruthTable FillTable(LogicalFunction function)
    {
        return default;
    }
    /// <summary>
    /// Мы считаем 1 ебучий раз таблицу истинности, далее для
    /// днф и кнф мы из нее получаем значения рядов при данных переменных
    /// и делаем ебучую магию
    /// </summary>
    /// <param name="values"></param>
    /// <returns></returns>
    internal bool[] RowFromValues(Dictionary<string, bool> values)
    {
        return default;
    }
}
