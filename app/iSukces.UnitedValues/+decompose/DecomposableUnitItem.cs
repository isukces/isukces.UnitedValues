namespace iSukces.UnitedValues;

public struct DecomposableUnitItem
{
    public DecomposableUnitItem(IUnit unit, int power)
    {
        Unit  = unit;
        Power = power;
    }

    public override string ToString()
    {
        if (Power == 1)
            return Unit.UnitName;

        return Unit.UnitName + "^" + Power;
    }

    public IUnit Unit  { get; }
    public int   Power { get; }
}