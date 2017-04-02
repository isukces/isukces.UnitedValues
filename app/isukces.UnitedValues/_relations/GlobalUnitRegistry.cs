using System;
using System.Collections.Generic;

namespace isukces.UnitedValues
{
    public static class GlobalUnitRegistry
    {
        public static readonly UnitRelationsDictionary Relations;

        static GlobalUnitRegistry()
        {
            Relations = new UnitRelationsDictionary();
            AreaUnitDefinition.Register(Relations);
            VolumeUnitDefinition.Register(Relations);
        }
    }
}