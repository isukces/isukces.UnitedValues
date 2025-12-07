using System;
using System.Reflection;

namespace UnitGenerator;

public static class NullableFinder
{
    public static NullableType[] FindArguments(ConstructorInfo constructor)
    {
        var parameters = constructor.GetParameters();
        
        var result = new NullableType[parameters.Length];
        for (var index = 0; index < parameters.Length; index++)
        {
            var parameter = parameters[index];
            result[index] = FindNullable(parameter);
        }

        return result;
    }

    public static NullableType FindNullable(ParameterInfo p)
    {
        var type = p.ParameterType;
        if (type.IsValueType)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return NullableType.Nullable;
            return NullableType.ValueType;
        }


        var ctx  = new NullabilityInfoContext();
        var read = ctx.Create(p).ReadState;
        return read switch
        {
            NullabilityState.NotNull => NullableType.ReferenceNotNull,
            NullabilityState.Nullable => NullableType.ReferenceNullable,
            NullabilityState.Unknown => NullableType.Unknown,
            _ => throw new NotSupportedException($"Type {type.FullName} is not supported")
        };
    }

    /*
    private static NullableType FindNullable(Type type)
    {
        if (type.IsValueType) 
            return NullableType.ValueType;
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            return NullableType.Nullable;
        return NullableType.Unknown;
    }*/
}

public enum NullableType
{
    Unknown,
    Nullable, 
    ValueType,
    ReferenceNullable,
    ReferenceNotNull
}
