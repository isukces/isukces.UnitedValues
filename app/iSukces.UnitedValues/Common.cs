namespace iSukces.UnitedValues
{
    public class Common
    {

        public static string[] SplitUnitNameBySlash(string unitName)
        {
            unitName = unitName.TrimToNull();
            if (unitName is null)
                return new string[0];
            return unitName.Split('/');
        }
        
        public static string[] SplitUnitNameByTimesSign(string unitName)
        {
            unitName = unitName.TrimToNull();
            if (unitName is null)
                return new string[0];
            if (unitName.Length == 1)
                return new[] {unitName};
            if (unitName.Length == 2)
                return new[] {unitName.Substring(0, 1), unitName.Substring(1)};
            return unitName.Split(TimesSign[0]);
        }

        public const string TimesSign = "✕";
    }
}