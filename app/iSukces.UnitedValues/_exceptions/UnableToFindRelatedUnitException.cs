using System;

namespace iSukces.UnitedValues
{
    public class UnableToFindRelatedUnitException : Exception
    {
        public UnableToFindRelatedUnitException(Type sourceUnitType, Type relatedUnitType, IUnit unit)
            : base(GetMessage(sourceUnitType, relatedUnitType, unit))
        {
            SourceUnitType  = sourceUnitType;
            RelatedUnitType = relatedUnitType;
            Unit            = unit;
        }

        private static string GetMessage(Type sourceType, Type relatedType, IUnit unit)
        {
            return $"Unable to find related {relatedType.Name} for {sourceType.Name} '{unit.UnitName}'.";
        }

        public Type  SourceUnitType  { get; }
        public Type  RelatedUnitType { get; }
        public IUnit Unit            { get; }
    }
}