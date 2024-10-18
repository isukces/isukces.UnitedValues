namespace UnitGenerator;

public class MultiplicationAlgebraItem
{
    public MultiplicationAlgebraItem(TypesGroup counter, TypesGroup denominator, TypesGroup result,
        bool areRelatedUnits, OperatorHints operatorHints)
    {
        Counter         = counter;
        Denominator     = denominator;
        Result          = result;
        AreRelatedUnits = areRelatedUnits;
        OperatorHints   = operatorHints;
    }

    public TypesGroup    Counter         { get; }
    public TypesGroup    Denominator     { get; }
    public TypesGroup    Result          { get; }
    public bool          AreRelatedUnits { get; }
    public OperatorHints OperatorHints   { get; }
}