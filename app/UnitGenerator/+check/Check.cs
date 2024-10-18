using System;
using iSukces.UnitedValues;

namespace UnitGenerator;

public static class Check
{
    public static void Run()
    {
        var t = typeof(UMath).Assembly.GetTypes();
        foreach (var type in t)
        {
            if (type.Namespace=="iSukces.UnitedValues")
                continue;
            throw new Exception($"Type {type.FullName} in namespace {type.Namespace}");
        }
    }
}
