using System.Collections.Generic;
using iSukces.UnitedValues;

namespace UnitGenerator;

public class InversedUnitDefs
{
    public static InversedUnitsCollection All
    {
        get
        {
            if (_all is null)

                _all = new InversedUnitsCollection(new[]
                {
                    new InversedUnit(typeof(DeltaKelvinTemperature))
                });
            return _all;
        }
    }

    private static InversedUnitsCollection _all;
}
