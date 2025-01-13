using System;
using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using UnitGenerator.Local;

namespace UnitGenerator;

public abstract class BaseValuesGenerator<TDef> : BaseGenerator<TDef>
{
    protected BaseValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
    {
    }

    protected void Add_Algebra_MinusUnary()
    {
        Target.AddOperator("-", new CsArguments("-value.Value", "value.Unit"))
            .AddParam("value", Target.Name);
    }


    protected virtual void Add_GetBaseUnitValue()
    {
        var cs = Ext.Create<BasicUnitValuesGenerator>();
        cs.SingleLineIf("Unit.Equals(BaseUnit)", ReturnValue("Value"));
        cs.WriteLine("var factor = GlobalUnitRegistry.Factors.Get(Unit);");
        cs.SingleLineIf("factor is not null", ReturnValue("Value * factor.Value"));
        var exceptionMessage = new CsExpression("Unable to find multiplication for unit ".CsEncode())
                               + new CsExpression("Unit");

        cs.Throw<Exception>(exceptionMessage.ToString());
        Target.AddMethod("GetBaseUnitValue", ValuePropertyType)
            .WithBody(cs);
    }

    protected void Add_Round(TypesGroup names)
    {
        var cs = Ext.Create<BasicUnitValuesGenerator>();
        cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({names.Value}));");
        cs.WriteLine(
            $"return new {names.Value}(parseResult.Value, new {names.Unit}(parseResult.UnitName));");
        Target.AddMethod("Round", (CsType)names.Value.ValueTypeName)
            .WithBodyFromExpression("new " + names.Value + "(Math.Round(Value, decimalPlaces), Unit)")
            .AddParam<int>("decimalPlaces", Target);
    }

    protected void AddCommonValues_PropertiesAndConstructor(ITypeNameProvider unitTypeName)
    {
        AddCommonValues_PropertiesAndConstructor(unitTypeName.GetTypename());
    }

    protected void AddCommonValues_PropertiesAndConstructor(string unitTypeName)
    {
        Add_Properties(GetConstructorProperties());
        Add_Constructor(GetConstructorProperties());

        AddCommonValues_GetHashCode();
        AddCommonValues_ToString();
        AddCommonValues_EqualsMethods(unitTypeName);
    }

    protected abstract Col1 GetConstructorProperties();


    private void AddCommonValues_EqualsMethods(string unitTypeName)
    {
        var compareCode = string.Format(
            "{0} == other.{0} && {1} is not null && {1}.Equals(other.{1})",
            ValuePropName, UnitPropName);
        Add_EqualsUniversal(Target.Name, false, OverridingType.None, compareCode);

        var compareType = (CsType)MakeGenericType<IUnitedValue<LengthUnit>>(Target, unitTypeName);
        compareType.Nullable = NullableKind.ReferenceNullable;
        Add_EqualsUniversal(compareType, true, OverridingType.None, compareCode);

        Add_EqualsUniversal(CsType.ObjectNullable, false, OverridingType.Override,
            GeneratorCommon.EqualExpression(compareType));
    }


    private void AddCommonValues_GetHashCode()
    {
        const string expression = $"({ValuePropName}.GetHashCode() * 397) ^ {UnitPropName}.GetHashCode()";
        Add_GetHashCode(expression);
    }

    private void AddCommonValues_ToString()
    {
        Target.AddMethod("ToString", CsType.String, "Returns unit name")
            .WithOverride()
            .WithBodyFromExpression("Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName");

        var m = Target.AddMethod("ToString", CsType.String, "Returns unit name")
            .WithBodyFromExpression("this.ToStringFormat(format, provider)");
        m.AddParam<string>("format", Target);
        m.AddParam<IFormatProvider>("provider", Target).WithConstValue("null");
    }

    public static CsType ValuePropertyType      = CsType.Decimal;
    public static CsType OtherValuePropertyType = CsType.Double;

    protected const string ValuePropName = "Value";
    protected const string UnitPropName  = "Unit";
}
