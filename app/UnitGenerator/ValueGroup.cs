using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class ValueGroup
    {
        public ValueGroup(string valueTypeName, string unitTypeName = null, string unitContainerTypeName = null)
        {
            valueTypeName = valueTypeName?.TrimToNull();
            ValueTypeName = valueTypeName ?? throw new ArgumentException(nameof(valueTypeName));
            
            UnitTypeName          = unitTypeName?.TrimToNull() ?? valueTypeName + "Unit";
            UnitContainerTypeName = unitContainerTypeName?.TrimToNull() ?? UnitTypeName + "s";
        }

        public override string ToString()
        {
            return
                $"ValueTypeName={ValueTypeName}, UnitTypeName={UnitTypeName}, UnitContainerTypeName={UnitContainerTypeName}";
        }

        public string ValueTypeName { get; }

        public string UnitTypeName { get; }

        public string UnitContainerTypeName { get; }
    }
}