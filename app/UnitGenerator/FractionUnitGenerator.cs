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
            cl.Kind = CsNamespaceMemberKind.Struct;
            cl.ImplementedInterfaces.Add("IUnit");
            cl.ImplementedInterfaces.Add("IEquatable<" + Cfg.Unit + ">");

            var pi = new[]
            {
                new ConstructorParameterInfo("CounterUnit", Cfg.CounterUnit, null, "counter unit"),
                new ConstructorParameterInfo("DenominatorUnit", Cfg.DenominatorUnit, null, "denominator unit")
            };
            Add_Constructor(pi);
            Add_Properties(pi);
            Add_Equals();
            Add_GetHashCode("(CounterUnit.GetHashCode() * 397) ^ DenominatorUnit.GetHashCode()");
            Add_EqualityOperators();
            Add_ToString(PropertyName);

            cl.AddProperty(PropertyName, "string")
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithOwnGetter("CounterUnit.UnitName + \"/\" + DenominatorUnit.UnitName")
                .OwnGetterIsExpression = true;
        }


        protected override string GetTypename(FractionUnitInfo cfg)
        {
            return Cfg.Unit;
        }

        private void Add_Equals()
        {
            var compareCode = "CounterUnit.Equals(other.CounterUnit) && DenominatorUnit.Equals(other.DenominatorUnit)";
            Add_EqualsUniversal(cl.Name, false, OverridingType.None, compareCode);
            Add_EqualsUniversal("object", false, OverridingType.Override,
                "other is " + cl.Name + " unitedValue ? Equals(unitedValue) : false");
        }

        private const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }
}