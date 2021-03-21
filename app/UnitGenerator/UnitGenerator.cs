using System;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class UnitGenerator : BaseGenerator<string>
    {
        public UnitGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }


        protected override void GenerateOne()
        {
            cl.Kind = CsNamespaceMemberKind.Struct;
            // cl.Description = $"Reprezentuje {unit.Description} w [{unit.Unit}]";
            Add_Constructor();
            Add_ImplicitOperator();
            Add_EqualityOperators();
            Add_Equals();
            Add_EqualsOverride();
            Add_GetHashCode();
            Add_ToString(PropertyName);
            Add_IEquatableEquals();
            Add_Property();

            cl.ImplementedInterfaces.Add(cl.Owner.GetTypeName<IUnit>());
            var t = MakeGenericType<IEquatable<int>>(cl.Owner, Cfg);
            cl.ImplementedInterfaces.Add(t);
            cl.WithAttribute(typeof(SerializableAttribute));
        }


        protected override string GetTypename(string cfg)
        {
            return cfg;
        }

        private void Add_Constructor()
        {
            Add_Constructor(GetConstructorProperties());
        }


        private void Add_Equals()
        {
            var m = cl.AddMethod("Equals", "bool")
                .WithBodyFromExpression($"String.Equals({PropertyName}, other.{PropertyName})");
            m.AddParam("other", Cfg);
        }

        private void Add_EqualsOverride()
        {
            // equals override
            var cw = new CsCodeWriter();
            cw.WriteLine("if (ReferenceEquals(null, obj)) return false;");
            cw.WriteLine(ReturnValue("obj is " + cl.Name + " tmp && Equals(tmp)"));
            var m = cl.AddMethod("Equals", "bool")
                .WithOverride()
                .WithBody(cw);
            m.AddParam("obj", "object");
        }

        private void Add_GetHashCode()
        {
            // GetHashCode override
            cl.AddMethod("GetHashCode", "int")
                .WithOverride()
                .WithBodyFromExpression("" + PropertyName + "?.GetHashCode() ?? 0");
        }

        private void Add_IEquatableEquals()
        {
            cl.AddMethod($"IEquatable<{cl.Name}>.Equals", "bool")
                .WithBodyFromExpression("Equals(other)")
                .WithVisibility(Visibilities.InterfaceDefault)
                .AddParam("other", cl.Name);
        }

        private void Add_ImplicitOperator()
        {
            var pa = MakeGenericType<UnitDefinition<IUnit>>(cl, Cfg);
            Add_ImplicitOperator(pa, cl.Name, $"new {Cfg}(src.{PropertyName})");
        }

        private void Add_Property()
        {
            Add_Properties(GetConstructorProperties());
        }


        private ConstructorParameterInfo[] GetConstructorProperties()
        {
            string GetExpressionPlus()
            {
                switch (Cfg)
                {
                    case "AreaUnit":
                        return @"?.Replace('2', '²')";
                    case "VolumeUnit":
                        return @"?.Replace('3', '³')";
                    default:
                        return null;
                }
            }

            var expr = PropertyName.FirstLower() + GetExpressionPlus();
            return new[]
            {
                new ConstructorParameterInfo(PropertyName, "string", expr, "name of unit")
            };
        }

        private const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }
}