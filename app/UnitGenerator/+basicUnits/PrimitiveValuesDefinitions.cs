namespace UnitGenerator
{
    public class PrimitiveValuesDefinitions
    {
        public static UnitInfo[] All()
        {
            return Ext.GetStaticFieldsValues<PrimitiveValuesDefinitions, UnitInfo>();
        }

        private static readonly UnitInfo Force = new UnitInfo("Force", "Newton", true);
        private static readonly UnitInfo Weight = new UnitInfo("Weight", "Kg", true);

        private static readonly UnitInfo Length = new UnitInfo("Length", "Meter", true);
        private static readonly UnitInfo Area = new UnitInfo("Area", "SquareMeter", false);
        private static readonly UnitInfo Volume = new UnitInfo("Volume", "QubicMeter", false);
    }
}