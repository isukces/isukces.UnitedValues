using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using iSukces.UnitedValues;

namespace UnitGenerator;

public static class Check
{
    public static void Run()
    {
        var t = typeof(UMath).Assembly.GetExportedTypes();
        foreach (var type in t)
        {
            if (type.Namespace == "iSukces.UnitedValues")
                continue;
            if (type.GetCustomAttribute<CompilerGeneratedAttribute>() is null)
                throw new Exception($"Type {type.FullName} in namespace {type.Namespace}");
        }
    }
}

