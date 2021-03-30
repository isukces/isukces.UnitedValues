using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class FakeProductUnit : IProductUnit<int, int>
    {
        public string UnitName  { get; }
        public int    LeftUnit  { get; }
        public int    RightUnit { get; }
    }
}