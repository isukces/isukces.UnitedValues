using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{ 
    public partial struct LengthUnit  
    {
        static LengthUnit()
        {
            KnownUnits = new Dictionary<LengthUnit, decimal>();
            AddDefinition(LengthUnitDefinition.Km);
            AddDefinition(LengthUnitDefinition.Meter);
            AddDefinition(LengthUnitDefinition.Mm);

            AddDefinition(LengthUnitDefinition.Cm);
            AddDefinition(LengthUnitDefinition.Feet);
            AddDefinition(LengthUnitDefinition.Inch);
        }        
    }
}