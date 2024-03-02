namespace LogicalParsing;

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
    public TruthTable GetTruthTable() { return truthTable; }


}