using System;

namespace iSukces.UnitedValues
{
    partial class EnergyUnit
    {
        [RelatedUnitSourceAttribute(RelatedUnitSourceUsage.ProvidesRelatedUnit)]
        public TimeUnit GetSuggestedTimeUnit()
        {
            if (UnitName.EndsWith("Wh", StringComparison.Ordinal))
                return TimeUnits.Hour;
            return TimeUnits.Second;
        }
    }
}