using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using iSukces.UnitedValues;

namespace UnitGenerator;

internal class ConversionMethodScanner
{
    private ConversionMethodScanner(IReadOnlyDictionary<Type, List<MethodInfo>> dictionary)
    {
        Dictionary = dictionary;
    }

    private static Type ExtractUnitType(Type returnType)
    {
        if (!returnType.IsGenericType)
            throw new Exception("Should return UnitDefinition<>");
        if (returnType.GetGenericTypeDefinition()!=typeof(UnitDefinition<>))
            throw new Exception("Should return UnitDefinition<>");
        var unitType = returnType.GetGenericArguments()[0]; 
        if (!unitType.Implements<IUnit>())
            throw new Exception("Should return IUnit");
        return unitType;
    }
    public static ConversionMethodScanner Scan(Assembly resolverAssembly)
    {
        var sink = new List<MethodInfo>();
        foreach (var t in resolverAssembly.GetExportedTypes())
        foreach (var methodInfo in t.GetMethods(BindingFlags.Static | BindingFlags.Public))
        {
            var at = methodInfo.GetCustomAttribute<RelatedUnitSourceAttribute>();
            if (at is null || (at.Usage & RelatedUnitSourceUsage.ProvidesRelatedUnit) == 0)
                continue;
            var returnType = methodInfo.ReturnType;

            /*var gp = returnType.IsGenericType ? returnType.GetGenericArguments() : null;
            if (gp is null)*/
            if (!returnType.IsGenericType)
                throw new Exception("Should return UnitDefinition<>");
            if (returnType.GetGenericTypeDefinition()!=typeof(UnitDefinition<>))
                throw new Exception("Should return UnitDefinition<>");
            var unitType = returnType.GetGenericArguments()[0]; 
            if (!unitType.Implements<IUnit>())
                throw new Exception("Should return IUnit");

            if (methodInfo.GetParameters().Length == 0)
                throw new Exception("Should have parameters");
            sink.Add(methodInfo);
        }

        var dict = sink.GroupBy(a => a)
            .ToDictionary(
                a => ExtractUnitType(a.Key.ReturnType),
                a => a.ToList());
        return new ConversionMethodScanner(dict);
    }

    public IReadOnlyDictionary<Type, List<MethodInfo>> Dictionary { get; }
}
