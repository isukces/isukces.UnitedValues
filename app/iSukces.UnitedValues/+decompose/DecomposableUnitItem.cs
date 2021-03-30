namespace iSukces.UnitedValues
{
    public struct DecomposableUnitItem
    {
        public DecomposableUnitItem(IUnit unit, int power)
        {
            Unit  = unit;
            Power = power;
        }

        public IUnit Unit  { get; }
        public int   Power { get; }

        public static DecomposableUnitItem Make(IUnit unit, int power)
        {
            throw new System.NotImplementedException();
        }
    }
}