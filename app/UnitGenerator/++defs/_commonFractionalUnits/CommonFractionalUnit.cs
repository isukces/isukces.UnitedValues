namespace UnitGenerator;

public class CommonFractionalUnit
{
    public CommonFractionalUnit(TypesGroup type, string counterUnit, string denominatorUnit,
        string targetPropertyName)
    {
        Type               = type;
        CounterUnit        = counterUnit;
        DenominatorUnit    = denominatorUnit;
        TargetPropertyName = targetPropertyName;
    }


    public override string ToString()
    {
        return
            $"Type={Type}, CounterUnit={CounterUnit}, DenominatorUnit={DenominatorUnit}, TargetPropertyName={TargetPropertyName}";
    }

    public TypesGroup Type { get; }

    public string CounterUnit { get; }

    public string DenominatorUnit { get; }

    public string TargetPropertyName { get; }
}