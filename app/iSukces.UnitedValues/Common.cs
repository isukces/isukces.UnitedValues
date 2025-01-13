namespace iSukces.UnitedValues;

public class Common
{

    public static string[] SplitUnitNameBySlash(string? unitName)
    {
            unitName = unitName.TrimToNull();
            if (unitName is null)
                return [];
            return unitName.Split('/');
        }
        
    public static string[] SplitUnitNameByTimesSign(string? unitName)
    {
            unitName = unitName.TrimToNull();
            if (unitName is null)
                return [];
            if (unitName.Length == 1)
                return [unitName];
            if (unitName.Length == 2)
                return [unitName[..1], unitName[1..]];
            return unitName.Split(TimesSign[0]);
        }

    public const string TimesSign = "✕";
}