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
 
    }
}