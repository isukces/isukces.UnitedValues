namespace isukces.UnitedValues
{
    public struct WeightUnitDefinition
    {
        public WeightUnitDefinition(string unitName, decimal multiplication)
        {
            UnitName = unitName;
            Multiplication = multiplication;
        }

        public static implicit operator WeightUnit(WeightUnitDefinition x)
            => new WeightUnit(x.UnitName);

        public string UnitName { get; }
        public decimal Multiplication { get; }

        public static readonly WeightUnitDefinition Kg = new WeightUnitDefinition("kg", 1);
        public static readonly WeightUnitDefinition Gram = new WeightUnitDefinition("g", 0.001m);
        public static readonly WeightUnitDefinition Tone = new WeightUnitDefinition("t", 1000);
    }
}