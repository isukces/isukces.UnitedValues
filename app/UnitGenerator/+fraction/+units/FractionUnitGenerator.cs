using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using Self=UnitGenerator.FractionUnitGenerator;

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
            var name = new Args(Cfg.CounterUnit.Unit, Cfg.DenominatorUnit.Unit)
                .MakeGenericType(nameof(IFractionalUnit));
            Target.ImplementedInterfaces.Add(name);
            name = "IEquatable<" + Cfg.UnitTypeName + ">";
            Target.ImplementedInterfaces.Add(name);
            

            var pi = new[]
            {
                new ConstructorParameterInfo("CounterUnit", Cfg.CounterUnit.Unit, null, "counter unit"),
                new ConstructorParameterInfo("DenominatorUnit", Cfg.DenominatorUnit.Unit, null, "denominator unit")
            };
            Add_Constructor(pi);
            Add_Properties(pi);
            Add_UnitNameProperty();
            Add_Equals();
            Add_GetHashCode("(CounterUnit.GetHashCode() * 397) ^ DenominatorUnit.GetHashCode()");
            AddCommon_EqualityOperators();
            Add_ToString(PropertyName);

            Add_WithDenominatorUnit();
            Add_WithCounterUnit();
        }

        private void Add_WithDenominatorUnit()
        {
            var cw = Ext.Create<Self>();
            var e  = new Args("CounterUnit", "newUnit").Create(Target.Name);
            cw.WriteLine($"return {e};");
            Target.AddMethod("WithDenominatorUnit", Cfg.UnitTypeName)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.DenominatorUnit.Unit);
        }

        private void Add_WithCounterUnit()
        {
            var cw = Ext.Create<Self>();
            var e  = new Args("newUnit", "DenominatorUnit").Create(Target.Name);
            cw.WriteLine($"return {e};");
            Target.AddMethod("WithCounterUnit", Cfg.UnitTypeName)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.CounterUnit.Unit);
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

        private void Add_UnitNameProperty()
        {
            Target.AddProperty(PropertyName, "string")
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithOwnGetter("CounterUnit.UnitName + \"/\" + DenominatorUnit.UnitName")
                .OwnGetterIsExpression = true;
        }

        private const string PropertyName = nameof(IUnitNameContainer.UnitName);
    }
}