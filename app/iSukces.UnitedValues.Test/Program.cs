using System;
using System.Reflection;
using Xunit;

namespace iSukces.UnitedValues.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var length = new Length(1, LengthUnits.Meter);
            var t = typeof(LengthUnit);

            foreach (var i in typeof(Program).Assembly.GetTypes())
            {
                var methods = i.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |
                                           BindingFlags.NonPublic);
                foreach (var method in methods)
                {
                    var a = method.GetCustomAttribute<FactAttribute>();
                    if (a == null)
                        continue;
                    object instance = null;
                    if (!method.IsStatic)
                        instance = Activator.CreateInstance(method.ReflectedType);
                    method.Invoke(instance, null);

                }
            }
        }
    }
}