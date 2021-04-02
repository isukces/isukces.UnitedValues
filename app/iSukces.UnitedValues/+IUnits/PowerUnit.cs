using System;
using System.Linq;

namespace iSukces.UnitedValues
{
    partial class PowerUnit
    {
        [RelatedUnitSourceAttribute(RelatedUnitSourceUsage.ProvidesRelatedUnit)]
        public static UnitDefinition<PowerUnit> CratePowerUnitFromEnergyAndTime(EnergyUnit energy, TimeUnit time)
        {
            var energyFactor = GlobalUnitRegistry.Factors.GetThrow(energy);

            var tmp = PowerUnits.All.Where(a => a.Multiplication == energyFactor).Take(1).ToArray();
            if (time == TimeUnits.Second)
                if (tmp.Length > 0)
                    return new UnitDefinition<PowerUnit>(tmp[0].Unit, 1);

            var timeFactor = GlobalUnitRegistry.Factors.GetThrow(time);

            if (tmp.Length > 0)
                return new UnitDefinition<PowerUnit>(tmp[0].Unit, 1);
            var search = energyFactor / timeFactor;

            tmp = PowerUnits.All.Where(a => a.Multiplication == search).Take(1).ToArray();
            if (tmp.Length > 0)
                return new UnitDefinition<PowerUnit>(tmp[0].Unit, 1); 
             return new UnitDefinition<PowerUnit>(PowerUnits.Watt, search);
        }
    }
}