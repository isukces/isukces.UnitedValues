using System;
using System.Linq;
using System.Reflection;

namespace iSukces.UnitedValues.Test;

public class TestUtils
{
    public static T? LoadUnit<T>(string unitPath)
    {
        try
        {
            var parts = unitPath.Split('.');
            var type  = typeof(LengthUnits).Assembly.GetExportedTypes().Single(a => a.Name == parts[0]);
            var field = type.GetFields(BindingFlags.Public | BindingFlags.Static).Single(a => a.Name == parts[1]);
            var value = field.GetValue(null);

            var aa = value.GetType().GetProperty("Unit");
            value = aa.GetValue(value);
            return (T?)value;
        }
        catch (Exception e)
        {
            throw new Exception("Unable to find path " + unitPath);

        }
    }
}
