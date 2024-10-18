namespace iSukces.UnitedValues;

public static class PrivateExtensions
{
    public static string TrimToNull(this string txt)
    {
            if (txt is null || txt.Length == 0)
                return null;
            return txt.Trim();
        }
    public static string TrimToEmpty(this string txt)
    {
            if (txt is null || txt.Length == 0)
                return string.Empty;
            return txt.Trim();
        }
}