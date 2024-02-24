namespace LogicalParsing;
/* ПЛАН ДЕЙСТВИЙ
 * 
 * СНАЧАЛА РАЗБИВАЕМ СТРОКУ НА ТОКЕНЫ
 * 
 * ДАЛЕЕ КРАФТИМ LOGICALFUNCTION - ЕЕ ПРИКОЛ В ТОМ ЧТО ЕЕ ЗНАЧЕНИЕ МЫ
 * МОЖЕМ ВЫЧИСЛИТЬ ПРИ ДАННЫХ ЗНАЧЕНИЯХ ПЕРЕМЕННЫХ
 * 
 * ДАЛЕЕ КРАФТИМ TRUTHTABLE - ТАБЛИЦУ ИСТИННОСТИ ФУНКЦИИ
 * 
 * ИЗ НЕЕ МОЖНО ПОЛУЧИТЬ ДНФ И КНФ
 * 
 * НО НАПРЯМУЮ ЭТО ХУЙНЯ ИДЕЯ, ПОЭТОМУ ЭТОТ КЛАСС И СУЩЕСТВУЕТ, ОН
 * ВСЕ ВЫШЕ СОЕДИНЯЕТ ВОЕДИНО
 * И ИЗ НЕГО МЫ И ПОЛУЧАЕМ ДНФ И КНФ
 * 
 * ДАЛЕЕ ДНФ И КНФ В ЧЕЛОВЕЧЕСКОМ ВИДЕ (ТАМ БЛЯТЬ ТУСТРИГ ПЕРЕОПРЕДЕЛЕН
 * НЕ ПОТОМУ ЧТО ТАКОЙ ДОХУЯ ЛЮБИТЕЛЬ ПОЛИМОРФИЗМА, А ПОТОМУ ЧТО ЭТО НА ФОРМУ 
 * ПОЙДЕТ ДАЛЕЕ) 
 * 
 */


public class LogicalExpression(string Expression)
{
    TruthTable truthTable;
    public DNF GetDNF()
    {
        truthTable ??= TruthTable.FillTable(new ClassLibrary1.Expression(Expression));
        if (truthTable != null)
            return DNF.ToDNF(truthTable);
        else
            return null;
    }

    public KNF GetKNF()
    {
        truthTable ??= TruthTable.FillTable(new ClassLibrary1.Expression(Expression));
        if (truthTable != null)
            return KNF.ToKNF(truthTable);
        else
            return null;
    }


}