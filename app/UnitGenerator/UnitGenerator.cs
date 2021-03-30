using System;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using Self = UnitGenerator.UnitGenerator;

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
            Target.Kind = CsNamespaceMemberKind.Class;
            // cl.Description = $"Reprezentuje {unit.Description} w [{unit.Unit}]";
            Add_Constructor();
            Add_ImplicitOperator();
            AddCommon_EqualityOperators();
            Add_Equals();
            Add_EqualsOverride();
            Add_GetHashCode();
            Add_ToString(PropertyName);
            Add_IEquatableEquals();
            Add_Property();

            Target.ImplementedInterfaces.Add(Target.Owner.GetTypeName<IUnit>());
            var t = MakeGenericType<IEquatable<int>>(Target.Owner, Cfg);
            Target.ImplementedInterfaces.Add(t);
            Target.WithAttribute(typeof(SerializableAttribute));

            Add_ConvertOtherPower();
        }


        protected override string GetTypename(string cfg)
        {
            return cfg;
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("System.Runtime.CompilerServices");
        }

        private void Add_Constructor()
        {
            Add_Constructor(GetConstructorProperties());
        }

        private void Add_ConvertOtherPower()
        {
            var infos = DerivedUnitGeneratorDefs.All;

            var tmp = infos.GetPowers(Cfg);
            if (tmp?.MyInfo is null || tmp.Other.Count == 0)
                return;
            foreach (var i in tmp.Other.Values)
            {
                var targetUnit = new TypesGroup(i.Name);
                if (Cfg == targetUnit.Unit)
                    continue;
                var cw = Ext.Create<Self>();
                var code = "GlobalUnitRegistry.Relations.GetOrThrow<" + Target.Name + ", " + targetUnit.Unit +
                           ">(this)";
                cw.WriteReturn(code);
                var m = Target.AddMethod("Get" + targetUnit.Unit, targetUnit.Unit).WithBody(cw);
                m.WithAggressiveInlining(Target);
            }
        }


        private void Add_Equals()
        {
            var m = Target.AddMethod("Equals", "bool")
                .WithBodyFromExpression($"String.Equals({PropertyName}, other?.{PropertyName})");
            m.AddParam("other", Cfg);
        }

        private void Add_EqualsOverride()
        {
            // equals override
            var cw = new CsCodeWriter();
            cw.WriteLine("if (ReferenceEquals(null, obj)) return false;");
            cw.WriteLine(ReturnValue("obj is " + Target.Name + " tmp && Equals(tmp)"));
            var m = Target.AddMethod("Equals", "bool")
                .WithOverride()
                .WithBody(cw);
            m.AddParam("obj", "object");
        }

        private void Add_GetHashCode()
        {
            // GetHashCode override
            Target.AddMethod("GetHashCode", "int")
                .WithOverride()
                .WithBodyFromExpression("" + PropertyName + "?.GetHashCode() ?? 0");
        }

        private void Add_IEquatableEquals()
        {
            Target.AddMethod($"IEquatable<{Target.Name}>.Equals", "bool")
                .WithBodyFromExpression("Equals(other)")
                .WithVisibility(Visibilities.InterfaceDefault)
                .AddParam("other", Target.Name);
        }

        private void Add_ImplicitOperator()
        {
            var pa = MakeGenericType<UnitDefinition<IUnit>>(Target, Cfg);
            Add_ImplicitOperator(pa, Target.Name, $"new {Cfg}(src.{PropertyName})");
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
            expr += ".TrimToNull()";
            return new[]
            {
                new ConstructorParameterInfo(PropertyName, "string", expr, "name of unit",
                    Flags1.NormalizedString)
            };
        }

        private const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }
}