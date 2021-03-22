using System;

namespace iSukces.UnitedValues
{
    public class UnknownDerivedUnitFactorException : Exception
    {
        public UnknownDerivedUnitFactorException(Type unitType, IUnit unit)
            : base(GetMessage(unitType, unit))
        {
            UnitType = unitType;
            Unit     = unit;
        }

        private static string GetMessage(Type unitType, IUnit unit)
        {
            return $"Unknown multiplication factor for {unitType.Name} '{unit}'";
        }

        public Type  UnitType { get; }
        public IUnit Unit     { get; }
    }
}