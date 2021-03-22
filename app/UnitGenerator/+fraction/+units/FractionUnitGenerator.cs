using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    internal class FractionUnitGenerator : BaseGenerator<FractionUnitInfo>
    {
        public FractionUnitGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Target.Kind = CsNamespaceMemberKind.Struct;
            Target.ImplementedInterfaces.Add("IUnit");
            Target.ImplementedInterfaces.Add("IEquatable<" + Cfg.UnitTypeName + ">");

            var pi = new[]
            {
                new ConstructorParameterInfo("CounterUnit", Cfg.CounterUnit.Unit, null, "counter unit"),
                new ConstructorParameterInfo("DenominatorUnit", Cfg.DenominatorUnit.Unit, null, "denominator unit")
            };
            Add_Constructor(pi);
            Add_Properties(pi);
            Add_Equals();
            Add_GetHashCode("(CounterUnit.GetHashCode() * 397) ^ DenominatorUnit.GetHashCode()");
            AddCommon_EqualityOperators();
            Add_ToString(PropertyName);

            Target.AddProperty(PropertyName, "string")
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithOwnGetter("CounterUnit.UnitName + \"/\" + DenominatorUnit.UnitName")
                .OwnGetterIsExpression = true;
        }


        protected override string GetTypename(FractionUnitInfo cfg)
        {
            return Cfg.UnitTypeName;
        }

        private void Add_Equals()
        {
            var compareCode = "CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit)";
            Add_EqualsUniversal(Target.Name, false, OverridingType.None, compareCode);
            Add_EqualsUniversal("object", false, OverridingType.Override,
                "other is " + Target.Name + " unitedValue ? Equals(unitedValue) : false");
        }

        private const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }
}