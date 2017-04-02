namespace isukces.UnitedValues
{
    public partial struct WeightUnitDefinition
    {

        public static readonly WeightUnitDefinition Kg = new WeightUnitDefinition("kg", 1);
        public static readonly WeightUnitDefinition Gram = new WeightUnitDefinition("g", 0.001m);
        public static readonly WeightUnitDefinition Tone = new WeightUnitDefinition("t", 1000, "ton", "tons");
    }
}