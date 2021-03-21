namespace UnitGenerator
{
    public class ValueGroup
    {
        public ValueGroup(string valueTypeName)
            : this(valueTypeName, valueTypeName + "Unit", valueTypeName + "Units")
        {
        }

        public ValueGroup(string valueTypeName, string unitTypeName, string unitContainerTypeName)
        {
            ValueTypeName         = valueTypeName;
            UnitTypeName          = unitTypeName;
            UnitContainerTypeName = unitContainerTypeName;
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