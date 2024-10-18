using System;
using System.Collections.Generic;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using Self = UnitGenerator.InversedUnitGenerator;

namespace UnitGenerator
{
    internal class InversedUnitGenerator : BaseGenerator<InversedUnit>
    {
        public InversedUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }


        protected override void GenerateOne()
        {
            Target.Kind = CsNamespaceMemberKind.Class;

            AddCommon_EqualityOperators();
            Add_Equals();
            Add_GetHashCode(PropName + ".GetHashCode()");
            Add_ToString(PropName);

            Target.ImplementedInterfaces.Add(Target.Owner.GetTypeName<IUnit>());
            var t = MakeGenericType<IEquatable<int>>(Target.Owner, Target.Name.Declaration);
            Target.ImplementedInterfaces.Add(t);
            Target.WithAttribute(typeof(SerializableAttribute));

            Add_Decompose();
            Add_Properties(GetPropertiesInfo(0));
            Add_Constructor(GetPropertiesInfo(0));
            Add_Properties(GetPropertiesInfo(1));
            Add_Constructor(GetPropertiesInfo(1));

            AddGetBaseUnit();
        }

        protected override string GetTypename(InversedUnit cfg)
        {
            return cfg.TargetUnitTypename.Declaration;
        }

        private void Add_Decompose()
        {
            var basicUnit  = Cfg.Source.Unit;
            var resultType = Target.GetTypeName<DecomposableUnitItem>();
            var cs         = Ext.Create(GetType());
            cs.WriteAssign("tmp", "Get" + basicUnit.TypeName + "()", true);
            var args = new CsArguments("tmp", "-1").Create(resultType);
            cs.WriteReturn(args);

            var m = Target.AddMethod(nameof(IDerivedDecomposableUnit.GetBasicUnit), resultType);
            m.WithBody(cs);

            Target.ImplementedInterfaces.Add(nameof(IDerivedDecomposableUnit));
        }

        private void Add_Equals()
        {
            var compareCode =
                $"{PropName}.Equals(other.{PropName})";
            Add_EqualsUniversal(Target.Name, false, OverridingType.None, compareCode);
            Add_EqualsUniversal("object", false, OverridingType.Override,
                "other is " + Target.Name.Declaration + " unitedValue ? Equals(unitedValue) : false");
        }

        private void AddGetBaseUnit()
        {
            var resultType = Cfg.Source.Unit.GetTypename();

            var cw = Ext.Create(GetType());
            cw.SingleLineIf("!(BaseUnit is null)", "return BaseUnit;");
            cw.WriteLine("// poor quality code :(, but should work for simple cases like 1/K");
            cw.SingleLineIf("UnitName.StartsWith(\"1/\")", "return new " + resultType + "(UnitName.Substring(2));");

            cw.WithThrowNotImplementedException();
            var m = Target.AddMethod("Get" + resultType, (CsType)resultType)
                .WithBody(cw);
            m.AddRelatedUnitSourceAttribute(Target, RelatedUnitSourceUsage.ProvidesRelatedUnit, 5);
        }

        private Col1 GetPropertiesInfo(int nr)
        {
            IReadOnlyList<ConstructorParameterInfo> items = new[]
            {
                new ConstructorParameterInfo(PropName,
                    (CsType)"string",
                    null,
                    "name of unit",
                    Flags1.NormalizedString | Flags1.AddNotNullAttributeToPropertyIfPossible)
            };
            if (nr == 0) return new Col1(items);

            items = new[]
            {
                new ConstructorParameterInfo("BaseUnit",
                    (CsType)Cfg.Source.Unit.GetTypename(),
                    null,
                    "base unit",
                    Flags1.NotNull | Flags1.PropertyCanBeNull),
                new ConstructorParameterInfo(PropName,
                    (CsType)"string",
                    null,
                    "name of unit",
                    Flags1.TrimValue | Flags1.Optional | Flags1.DoNotAssignProperty | Flags1.DoNotCreateProperty)
            };

            var a  = new Col1(items);
            var forceValue = new CsExpression("unitName");
            var takeFromBaseUnit = new CsExpression("1/".CsEncode()) + new CsExpression("baseUnit.UnitName");
            var c3 = new CsExpression("string.IsNullOrEmpty(unitName)").Conditional(takeFromBaseUnit, forceValue);
            a.Writer2.WriteAssign("UnitName", c3.Code);
            return a;
        }

        private const string PropName = nameof(IUnitNameContainer.UnitName);
    }
}