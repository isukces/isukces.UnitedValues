using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.UnitedValues;

namespace UnitGenerator
{
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

        private ValueOfSomeTypeExpression[] GetInternal(Type type, bool onlyLeft)
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
        }


        private ValueOfSomeTypeExpression[] FindByDerivedTypes(string methodName, params Type[] types)
        {
            for (var attempt = 0; attempt < 2; attempt++)
                foreach (var c in types)
                    try
                    {
                        var els = GetTypeSources(c, attempt == 0);
                        if (els.Any())
                        {
                            var part = methodName + "()";
                            return els.Select(a => a.WithPath(a.Path + part)).ToArray();
                        }
                    }
                    catch
                    {
                    }

            return new ValueOfSomeTypeExpression[0];
        }

        private ValueOfSomeTypeExpression[] GetTypeSources(Type type, bool onlyLeft)
        {
            var result = GetInternal(type, onlyLeft);
            result = Filter(result, onlyLeft);
            return result;
        }

        private readonly Dictionary<Type, ValueOfSomeTypeExpression[]> _dict;
    }
}