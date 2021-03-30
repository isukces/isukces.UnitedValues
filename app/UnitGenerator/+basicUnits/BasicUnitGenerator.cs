using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class BasicUnitGenerator : BaseGenerator<string>
    {
        public BasicUnitGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }

        private void Add_Decompose()
        {
            var infos = DerivedUnitGeneratorDefs.All;
            var tmp   = infos.GetPowers(Cfg);
            if (tmp?.MyInfo is null || tmp.Other.Count == 0)
                return;
            if (tmp.MyInfo.Power < 2)
                return;
            var basicUnit = tmp.Other.Where(a => a.Key == 1)
                .Select(a => a.Value)
                .SingleOrDefault();
       
            {
                var type = new Args(Target.GetTypeName<DecomposableUnitItem>())
                    .MakeGenericType(Target.GetTypeName<IReadOnlyList<int>>(), true);

                var cs = Ext.Create(GetType());
                if (basicUnit is null)
                {
                    cs.WriteLine("var decomposer = new UnitDecomposer();");
                    cs.WriteLine("decomposer.Add(this, 1);");
                    cs.WriteReturn("decomposer.Items");
                }
                else
                    cs.WriteReturn("new[] { " + nameof(IDerivedDecomposableUnit.GetBasicUnit) + "() }");
                
                
                var m = Target.AddMethod(nameof(IDecomposableUnit.Decompose), type);
                m.WithBody(cs);

                Target.ImplementedInterfaces.Add(nameof(IDecomposableUnit));
            }
            if (basicUnit != null)
            {
                var resultType = Target.GetTypeName<DecomposableUnitItem>();
                var cs         = Ext.Create(GetType());
                cs.WriteAssign("tmp", "Get" + basicUnit.Name + "Unit()", true);
                var args = new Args("tmp", tmp.MyInfo.Power.CsEncode()).Create(resultType);
                cs.WriteReturn(args);

                var m = Target.AddMethod(nameof(IDerivedDecomposableUnit.GetBasicUnit), resultType);
                m.WithBody(cs);

                Target.ImplementedInterfaces.Add(nameof(IDerivedDecomposableUnit));
            }
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
            Add_Decompose();
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
                var cw = Ext.Create<BasicUnitGenerator>();
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