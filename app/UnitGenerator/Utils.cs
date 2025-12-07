using System;
using iSukces.Code.Interfaces;

namespace UnitGenerator;

public static class Utils
{
 
    public static string ThrowArgumentException(string argName, ITypeNameResolver resolver)
    {
        var args      = new CsArguments("null", $"nameof({argName})");
        var exception = args.Create(resolver.GetTypeName<ArgumentException>());
        return $"throw {exception};";
    }
    
    public static string ThrowNullReferenceException(string argName, ITypeNameResolver resolver)
    {
        var args      = new CsArguments($"nameof({argName})");
        var exception = args.Create(resolver.GetTypeName<NullReferenceException>());
        return $"throw {exception};";
    }
    
    
}
