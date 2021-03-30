using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class FakeFractionalUnit : IFractionalUnit<int, int>
    {
        public string UnitName        { get; }
        public int    CounterUnit     { get; }
        public int    DenominatorUnit { get; }
    }
}