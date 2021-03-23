namespace UnitGenerator
{
    internal class MultiplicationAlgebraConfigItem
    {
        public MultiplicationAlgebraConfigItem(TypesGroup counter, TypesGroup denominator, TypesGroup result,
            bool areRelatedUnits)
        {
            Counter         = counter;
            Denominator     = denominator;
            Result          = result;
            AreRelatedUnits = areRelatedUnits;
        }

        public TypesGroup Counter         { get; }
        public TypesGroup Denominator     { get; }
        public TypesGroup Result          { get; }
        public bool       AreRelatedUnits { get; }
    }
}