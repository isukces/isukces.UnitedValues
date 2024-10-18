using iSukces.UnitedValues;

namespace UnitGenerator;

public class CompositeUnitGeneratorInfo
{
    public CompositeUnitGeneratorInfo(string firstPropertyName, TypesGroup first,
        string secondPropertyName,
        TypesGroup second,
        TypesGroup result)
    {
        FirstPropertyName  = firstPropertyName;
        SecondPropertyName = secondPropertyName;
        First              = first;
        Second             = second;
        Result             = result;
    }

    public static CompositeUnitGeneratorInfo Make(FractionUnit cfg)
    {
        const string counterUnit     = nameof(IFractionalUnit<int, int>.CounterUnit);
        const string denominatorUnit = nameof(IFractionalUnit<int, int>.DenominatorUnit);
        return new CompositeUnitGeneratorInfo(
            counterUnit, cfg.CounterUnit,
            denominatorUnit, cfg.DenominatorUnit,
            cfg.UnitTypes);
    }

    public static CompositeUnitGeneratorInfo Make(ProductUnit cfg)
    {
        const string firstPropertyName  = nameof(IProductUnit<int, int>.LeftUnit);
        const string secondPropertyName = nameof(IProductUnit<int, int>.RightUnit);

        return new CompositeUnitGeneratorInfo(
            firstPropertyName, cfg.CounterUnit,
            secondPropertyName, cfg.DenominatorUnit,
            cfg.UnitTypes);
    }

    public string     FirstPropertyName  { get; }
    public string     SecondPropertyName { get; }
    public TypesGroup First              { get; }
    public TypesGroup Second             { get; }
    public TypesGroup Result             { get; }
}