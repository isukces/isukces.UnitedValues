namespace isukces.UnitedValues
{
    public static class GlobalUnitRegistry
    {
        static GlobalUnitRegistry()
        {
            Relations = new UnitRelationsDictionary();
            Factors = new UnitExchangeFactors();

            AreaUnits.Register(Relations);
            VolumeUnits.Register(Relations);
            Factors.RegisterMany(LengthUnits.All);
            Factors.RegisterMany(AreaUnits.All);
            Factors.RegisterMany(VolumeUnits.All);
            Factors.RegisterMany(WeightUnits.All);         
        }

        public static readonly UnitRelationsDictionary Relations;
        public static readonly UnitExchangeFactors Factors;
    }
}