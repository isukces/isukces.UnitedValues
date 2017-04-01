namespace isukces.UnitedValues
{
    public struct LengthUnitDefinition
    {
        public LengthUnitDefinition(string unitName, decimal multiplication)
        {
            UnitName = unitName;
            Multiplication = multiplication;
        }

        public static implicit operator LengthUnit(LengthUnitDefinition x)
            => new LengthUnit(x.UnitName);

        public string UnitName { get; }
        public decimal Multiplication { get; }

        public static readonly LengthUnitDefinition Metr = new LengthUnitDefinition("m", 1);
        public static readonly LengthUnitDefinition Km = new LengthUnitDefinition("km", 1000);
        public static readonly LengthUnitDefinition Mm = new LengthUnitDefinition("mm", 0.001m);
        public static readonly LengthUnitDefinition Cm = new LengthUnitDefinition("cm", 0.01m);
        public static readonly LengthUnitDefinition Inch = new LengthUnitDefinition("inch", 0.0254m);
        public static readonly LengthUnitDefinition Feet = new LengthUnitDefinition("ft", 0.0254m * 12);
    }
}