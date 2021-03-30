using System;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public abstract class BaseValuesGenerator<TDef> : BaseGenerator<TDef>
    {
        protected BaseValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        
        
        protected void Add_Round(TypesGroup names)
        {
            var cs = Ext.Create<BasicUnitValuesGenerator>();
            cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({names.Value}));");
            cs.WriteLine(
                $"return new {names.Value}(parseResult.Value, new {names.Unit}(parseResult.UnitName));");
            Target.AddMethod("Round", names.Value)
                .WithBodyFromExpression("new " + names.Value + "(Math.Round(Value, decimalPlaces), Unit)")
                .AddParam<int>("decimalPlaces", Target);
        }
        
        protected void AddCommonValues_PropertiesAndConstructor(string unitTypeName)
        {
            Add_Properties(GetConstructorProperties());
            Add_Constructor(GetConstructorProperties());

            AddCommonValues_GetHashCode();
            AddCommonValues_ToString();
            AddCommonValues_EqualsMethods(unitTypeName);
        }

        protected abstract ConstructorParameterInfo[] GetConstructorProperties();


        private void AddCommonValues_EqualsMethods(string unitTypeName)
        {
            var compareCode = string.Format(
                "{0} == other.{0} && !({1} is null) && {1}.Equals(other.{1})", 
                ValuePropName, UnitPropName);
            Add_EqualsUniversal(Target.Name, false, OverridingType.None, compareCode);

            var compareType = MakeGenericType<IUnitedValue<LengthUnit>>(Target, unitTypeName);
            Add_EqualsUniversal(compareType, true, OverridingType.None, compareCode);

            Add_EqualsUniversal("object", false, OverridingType.Override,
                $"other is {compareType} unitedValue ? Equals(unitedValue) : false");
        }


        private void AddCommonValues_GetHashCode()
        {
            var expression = $"({ValuePropName}.GetHashCode() * 397) ^ {UnitPropName}?.GetHashCode() ?? 0";
            Add_GetHashCode(expression);
        }

        private void AddCommonValues_ToString()
        {
            Target.AddMethod("ToString", "string", "Returns unit name")
                .WithOverride()
                .WithBodyFromExpression("Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName");

            var m = Target.AddMethod("ToString", "string", "Returns unit name")
                .WithBodyFromExpression("this.ToStringFormat(format, provider)");
            m.AddParam<string>("format", Target);
            m.AddParam<IFormatProvider>("provider", Target).WithConstValue("null");
        }

        public const string ValuePropertyType = "decimal";
        public const string OtherValuePropertyType = "double";

        protected const string ValuePropName = "Value";
        protected const string UnitPropName = "Unit";
    }
}