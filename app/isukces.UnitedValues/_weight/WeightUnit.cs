using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public partial struct WeightUnit
    {
        static WeightUnit()
        {
            KnownUnits = new Dictionary<WeightUnit, decimal>();
            AddDefinition(WeightUnitDefinition.Kg);
            AddDefinition(WeightUnitDefinition.Tone);
            AddDefinition(WeightUnitDefinition.Gram);
        }
    }
}