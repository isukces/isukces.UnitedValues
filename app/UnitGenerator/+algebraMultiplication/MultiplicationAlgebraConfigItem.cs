namespace UnitGenerator
{
    internal class MultiplicationAlgebraConfigItem
    {
        public MultiplicationAlgebraConfigItem(TypesGoup counter, TypesGoup denominator, TypesGoup result,
            bool areRelatedUnits)
        {
            Counter         = counter;
            Denominator     = denominator;
            Result          = result;
            AreRelatedUnits = areRelatedUnits;
        }

        public TypesGoup Counter         { get; }
        public TypesGoup Denominator     { get; }
        public TypesGoup Result          { get; }
        public bool      AreRelatedUnits { get; }
    }
}