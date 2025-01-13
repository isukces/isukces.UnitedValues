using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using iSukces.UnitedValues;

namespace UnitGenerator;

internal class TypeFinder
{
    public TypeFinder(Dictionary<Type, ValueOfSomeTypeExpression[]> dict)
    {
        _dict = dict;
    }

    public static TypeFinder Make(List<ValueOfSomeTypeExpression> sink)
    {
        var dict = sink.GroupBy(a => a.Type)
            .ToDictionary(a => a.Key, a => a.ToArray());
        return new TypeFinder(dict);
    }

    private static ValueOfSomeTypeExpression[] Filter(ValueOfSomeTypeExpression[] f, bool onlyLeft)
    {
        if (onlyLeft)
            return f.Where(a => a.Root == ValueOfSomeTypeExpressionRoot.Left).ToArray();
        return f;
    }

    public IReadOnlyList<ValueOfSomeTypeExpression> FindParameters(MethodBase method,
        Func<Type, ICodeSource>? alternateConstruc, out bool dependsOnLeftArgument)
    {
        var list = new List<ValueOfSomeTypeExpression>();
        dependsOnLeftArgument = false;

        foreach (var i in method.GetParameters())
        {
            var type    = i.ParameterType;
            var sources = GetTypeSources(type);
            var el      = sources[0];
            if (el.Root == ValueOfSomeTypeExpressionRoot.Right)
            {
                // try to construct;
                // var constructed = Construct(new XUnitTypeName(type.Name));

                var constructed = alternateConstruc?.Invoke(type);
                //Construct(new XUnitTypeName(type.Name));

                if (constructed != null)
                    if (constructed.DependsOnLeftArgument)
                    {
                        // hasLeft = true;
                        // el      = constructed.Code;
                    }
            }
            else
                dependsOnLeftArgument = true;

            list.Add(el);
        }

        return list;
    }


    public ValueOfSomeTypeExpression[] GetTypeSources(Type type)
    {
        try
        {
            var a = GetTypeSources(type, true);
            if (a.Any())
                return a;
        }
        catch
        {
        }

        return GetTypeSources(type, false);
    }


    private ValueOfSomeTypeExpression[] Bla(Type type, Func<ValueOfSomeTypeExpression[]> find)
    {
        if (!underSearching.Add(type))
            return new ValueOfSomeTypeExpression[0];
        try
        {
            return find();
        }
        finally
        {
            underSearching.Remove(type);
        }
    }


    private ValueOfSomeTypeExpression[] FindByDerivedTypes(string methodName, params Type[] types)
    {
        for (var attempt = 0; attempt < 2; attempt++)
            foreach (var c in types)
            {
                var els = GetTypeSources(c, attempt == 0);
                if (!els.Any()) continue;
                    
                  
                var result= els.Select(a =>
                {
                    if (a.Expression.Kind != Kind2.Property)
                    {
                        /*var path    = a.Expression.Path + part;
                            var express = new TreeExpression(path, null, Kind2.Method);
                            return a.WithExpression(express);*/
                        return null;

                    }
                    var part    = methodName + "()";
                    var path    = a.Expression.Path + part;
                    var express = new TreeExpression(path, null, Kind2.Method);
                    return a.WithExpression(express);
                }).ToArray();
                if (result.All(q => q != null))
                    return result;
            }

        return new ValueOfSomeTypeExpression[0];
    }

    private ValueOfSomeTypeExpression[] GetInternal(Type type, bool onlyLeft)
    {
        return Bla(type, () =>
        {
            if (_dict.TryGetValue(type, out var sources))
            {
                sources = Filter(sources, onlyLeft);
                if (sources.Any())
                    return sources;
            }

            switch (type.Name)
            {
                // if (type.Implements<IDerivedDecomposableUnit>())
                case nameof(AreaUnit):
                {
                    var tmp = FindByDerivedTypes("Get" + type.Name, typeof(LengthUnit), typeof(VolumeUnit));
                    if (tmp.Any())
                        return tmp;
                    return new ValueOfSomeTypeExpression[0];
                }
                case nameof(VolumeUnit):
                {
                    var tmp = FindByDerivedTypes("Get" + type.Name, typeof(LengthUnit), typeof(AreaUnit));
                    if (tmp.Any())
                        return tmp;
                    return new ValueOfSomeTypeExpression[0];
                }
                case nameof(LengthUnit):
                {
                    var tmp = FindByDerivedTypes("Get" + type.Name, typeof(VolumeUnit), typeof(AreaUnit));
                    if (tmp.Any())
                        return tmp;
                    return new ValueOfSomeTypeExpression[0];
                }
                default:
                    return new ValueOfSomeTypeExpression[0];
            }
        });
    }

    private ValueOfSomeTypeExpression[] GetTypeSources(Type type, bool onlyLeft)
    {
        var result = GetInternal(type, onlyLeft);
        result = Filter(result, onlyLeft);
        return result;
    }

    private readonly HashSet<Type> underSearching = new HashSet<Type>();

    private readonly Dictionary<Type, ValueOfSomeTypeExpression[]> _dict;
}
