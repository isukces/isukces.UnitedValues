namespace UnitGenerator
{
    internal class MultiplicationAlgebraConfigItem
    {
        public MultiplicationAlgebraConfigItem(TypesGoup counter, TypesGoup denominator, TypesGoup result)
        {
            Counter     = counter;
            Denominator = denominator;
            Result      = result;
        }

        public TypesGoup Counter     { get; }
        public TypesGoup Denominator { get; }
        public TypesGoup Result      { get; }
    }
}