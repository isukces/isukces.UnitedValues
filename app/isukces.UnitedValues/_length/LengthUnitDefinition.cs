namespace isukces.UnitedValues
{
    public partial struct LengthUnitDefinition
    {

        public static readonly LengthUnitDefinition Meter = new LengthUnitDefinition("m", 1);
        public static readonly LengthUnitDefinition Km = new LengthUnitDefinition("km", 1000);
        public static readonly LengthUnitDefinition Mm = new LengthUnitDefinition("mm", 0.001m);
        public static readonly LengthUnitDefinition Cm = new LengthUnitDefinition("cm", 0.01m);
        public static readonly LengthUnitDefinition Inch = new LengthUnitDefinition("inch", 0.0254m);
        public static readonly LengthUnitDefinition Feet = new LengthUnitDefinition("ft", 0.0254m * 12);
    }
}