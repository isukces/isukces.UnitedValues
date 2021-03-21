using System;
using iSukces.Code;
using iSukces.Code.Ammy;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class UnitedValuesGenerator : BaseGenerator<UnitInfo>
    {
        public UnitedValuesGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            cl.Kind = CsNamespaceMemberKind.Struct;
            foreach (var i in Cfg.Interfaces)
                cl.ImplementedInterfaces.Add(i);

            cl.Attributes.Add(new CsAttribute("Serializable"));
            cl.Attributes.Add(
                new CsAttribute("JsonConverter").WithArgumentCode("typeof(" + Cfg.Name + "JsonConverter)"));

            Add_Properties();
            Add_ToString();
            Add_Constructor();
            Add_GetBaseUnitValue();
            Add_Parse();
            Add_Round();
            Add_Comparable();
            Add_Algebra();
            Add_Equals();
            Add_GetHashCode();
            Add_ConvertTo();
        }

        protected override string GetTypename(UnitInfo unit)
        {
            return unit.Name;
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }

        private void Add_Algebra()
        {
            cl.AddOperator("*", "value.Value * number", "value.Unit")
                .WithLeftRightArguments(cl.Name, ValuePropertyType, "value", "number");
            cl.AddOperator("*", "value.Value * number", "value.Unit")
                .WithLeftRightArguments(ValuePropertyType, cl.Name, "number", "value");
            cl.AddOperator("/", "value.Value / number", "value.Unit")
                .WithLeftRightArguments(cl.Name, ValuePropertyType, "value", "number");
            cl.AddOperator("-", "-value.Value", "value.Unit")
                .AddParam("value", cl.Name);

            {
                var cw = new CsCodeWriter();
                cw.WriteLine("right = right.ConvertTo(left.Unit);");
                cw.WriteLine(ReturnValue("left.Value / right.Value"));
                cl.AddMethod("/", ValuePropertyType)
                    .WithLeftRightArguments(cl.Name, cl.Name)
                    .WithBody(cw);
            }
            /*{
                var cw = new CsCodeWriter();
                cw.WriteLine("right = right.ConvertTo(left.Unit);");
                cw.WriteLine(ReturnValue("new " + Cfg.Name + "(right.Value "+i+" left.Value, left.Unit)"));
                cl.AddMethod("/", cl.Name)
                    .WithLeftRightArguments(cl.Name, ValuePropertyType)
                    .WithBody(cw);
            }*/

            foreach(var i in "+,-".Split(',')) 
            {
                var cw = new CsCodeWriter();
                cw.SingleLineIf(
                    "left.Value.Equals(" + ValuePropertyType + ".Zero) && string.IsNullOrEmpty(left.Unit.UnitName)",
                    ReturnValue("right"));
                cw.SingleLineIf(
                    "right.Value.Equals(" + ValuePropertyType + ".Zero) && string.IsNullOrEmpty(right.Unit.UnitName)",
                    ReturnValue("left"));

                cw.WriteLine("right = right.ConvertTo(left.Unit);");
                cw.WriteLine(ReturnValue("new " + Cfg.Name + "(right.Value "+i+" left.Value, left.Unit)"));

                cl.AddMethod(i, Cfg.Name)
                    .WithLeftRightArguments(cl.Name, cl.Name)
                    .WithBody(cw);
            }
        }

        private void Add_Comparable()
        {
            if (!Cfg.IsComparable) return;
            cl.AddMethod("CompareTo", "int")
                .WithBodyFromExpression(
                    "UnitedValuesUtils.Compare<" + Cfg.Name + ", " + Cfg.Unit + ">(this, other)")
                .AddParam("other", cl.Name);

            var operators = "!=,==,>,<,>=,<=";
            foreach (var oper in operators.Split(','))
                cl.AddMethod(oper, "bool")
                    .WithBodyFromExpression("left.CompareTo(right) " + oper + " 0")
                    .WithLeftRightArguments(cl.Name, cl.Name);
        }

        private void Add_Constructor()
        {
            Add_Constructor(GetConstructorProperties());
        }

        private void Add_ConvertTo()
        {
            var cw = new CsCodeWriter();
            cw.SingleLineIf("Unit.Equals(newUnit)", ReturnValue("this"));
            cw.WriteLine("var basic = GetBaseUnitValue();");
            cw.WriteLine("var factor = GlobalUnitRegistry.Factors.Get(newUnit);");
            cw.SingleLineIf("factor is null",
                "throw new Exception(\"Unable to find multiplication for unit \" + newUnit);");
            cw.WriteLine(ReturnValue("new " + cl.Name + "(basic / factor.Value, newUnit)"));

            cl.AddMethod("ConvertTo", cl.Name)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.Unit);
        }


        private void Add_Equals()
        {
            Add_EqualsUniversal(cl.Name, false, OverridingType.None);

            var compareType = MakeGenericType<IUnitedValue<LengthUnit>>(cl, Cfg.Unit);
            Add_EqualsUniversal(compareType, true, OverridingType.None);

            Add_EqualsUniversal("object", false, OverridingType.Override,
                "other is " + compareType + " unitedValue ? Equals(unitedValue) : false");
        }


        private void Add_EqualsUniversal(string compareType, bool nullable, OverridingType overridingType,
            string compareCode = null)
        {
            if (string.IsNullOrEmpty(compareCode))
                compareCode =
                    $"{ValuePropName} == other.{ValuePropName} && {UnitPropName}.Equals(other.{UnitPropName})";
            var cw = new CsCodeWriter();
            if (nullable)
                cw.SingleLineIf("other is null", ReturnValue("false"));
            cw.WriteLine(ReturnValue(compareCode));
            var m = cl.AddMethod("Equals", "bool")
                .WithBody(cw);
            m.Overriding = overridingType;
            m.AddParam("other", compareType);
        }

        private void Add_GetBaseUnitValue()
        {
            var cs = new CsCodeWriter();
            cs.SingleLineIf("Unit.Equals(BaseUnit)", ReturnValue("Value"));
            cs.WriteLine("var factor = GlobalUnitRegistry.Factors.Get(Unit);");
            cs.SingleLineIf("!(factor is null)", ReturnValue("Value * factor.Value"));
            cs.WriteLine("throw new Exception(\"Unable to find multiplication for unit \" + Unit);");
            cl.AddMethod("GetBaseUnitValue", ValuePropertyType)
                .WithBody(cs);
        }

        private void Add_GetHashCode()
        {
            var expression = $"({ValuePropName}.GetHashCode() * 397) ^ {UnitPropName}.GetHashCode()";

            CodeWriter cw = new AmmyCodeWriter();
            cw.Open("unchecked");
            cw.WriteLine(ReturnValue(expression));
            cw.Close();
            cl.AddMethod("GetHashCode", "int")
                .WithOverride()
                .WithBody(cw);
        }

        private void Add_Parse()
        {
            var cs = new CsCodeWriter();
            cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({Cfg.Name}));");
            cs.WriteLine($"return new {Cfg.Name}(parseResult.Value, new {Cfg.Unit}(parseResult.UnitName));");
            cl.AddMethod("Parse", Cfg.Name)
                .WithBody(cs)
                .WithStatic()
                .AddParam<string>("value", cl);
        }

        private void Add_Properties()
        {
            Add_Properties(GetConstructorProperties());

            cl.AddField("BaseUnit", Cfg.Unit)
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue(Cfg.BaseUnit);
            cl.AddField("Zero", Cfg.Name)
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue($"new {cl.Name}(0, BaseUnit)");
        }

        private void Add_Round()
        {
            var cs = new CsCodeWriter();
            cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({Cfg.Name}));");
            cs.WriteLine($"return new {Cfg.Name}(parseResult.Value, new {Cfg.Unit}(parseResult.UnitName));");
            cl.AddMethod("Round", Cfg.Name)
                .WithBodyFromExpression("new " + Cfg.Name + "(Math.Round(Value, decimalPlaces), Unit)")
                .AddParam<int>("decimalPlaces", cl);
        }

        private void Add_ToString()
        {
            cl.AddMethod("ToString", "string", "Returns unit name")
                .WithOverride()
                .WithBodyFromExpression("Value.ToString(CultureInfo.InvariantCulture) + Unit.UnitName");

            var m = cl.AddMethod("ToString", "string", "Returns unit name")
                .WithBodyFromExpression("this.ToStringFormat(format, provider)");
            m.AddParam<string>("format", cl);
            m.AddParam<IFormatProvider>("provider", cl).WithConstValue("null");
        }


        private ConstructorParameterInfo[] GetConstructorProperties()
        {
            return new[]
            {
                new ConstructorParameterInfo(ValuePropName,
                    ValuePropertyType,
                    null,
                    "value"),
                new ConstructorParameterInfo(UnitPropName,
                    Cfg.Unit, null, "unit")
            };
        }


        private const string ValuePropName = "Value";
        private const string UnitPropName = "Unit";

        public const string ValuePropertyType = "decimal";
    }
}