using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public class BasicUnitedValuesGenerator : BaseValuesGenerator<UnitInfo>
    {
        public BasicUnitedValuesGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Target.Kind = CsNamespaceMemberKind.Struct;
            foreach (var i in Cfg.Interfaces)
                Target.ImplementedInterfaces.Add(i);

            Target.Attributes.Add(new CsAttribute("Serializable"));
            Target.Attributes.Add(
                new CsAttribute("JsonConverter").WithArgumentCode("typeof(" + Cfg.ValueTypeName + "JsonConverter)"));

            AddCommonValues_PropertiesAndConstructor(Cfg.UnitTypeName);

            Add_Properties();
            Add_GetBaseUnitValue();
            Add_Parse();
            Add_Round();
            Add_Comparable();
            Add_Algebra();
            Add_ConvertTo();
        }


        protected override ConstructorParameterInfo[] GetConstructorProperties()
        {
            return new[]
            {
                new ConstructorParameterInfo(ValuePropName,
                    ValuePropertyType,
                    null,
                    "value"),
                new ConstructorParameterInfo(UnitPropName,
                    Cfg.UnitTypeName, null, "unit")
            };
        }

        protected override string GetTypename(UnitInfo cfg)
        {
            return cfg.ValueTypeName;
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }

        private void Add_Algebra()
        {
            Target.AddOperator("*", "value.Value * number", "value.Unit")
                .WithLeftRightArguments(Target.Name, ValuePropertyType, "value", "number");
            Target.AddOperator("*", "value.Value * number", "value.Unit")
                .WithLeftRightArguments(ValuePropertyType, Target.Name, "number", "value");
            Target.AddOperator("/", "value.Value / number", "value.Unit")
                .WithLeftRightArguments(Target.Name, ValuePropertyType, "value", "number");
            Target.AddOperator("-", "-value.Value", "value.Unit")
                .AddParam("value", Target.Name);

            {
                var cw = Ext.Create<BasicUnitedValuesGenerator>();
                cw.WriteLine("right = right.ConvertTo(left.Unit);");
                cw.WriteLine(ReturnValue("left.Value / right.Value"));
                Target.AddMethod("/", ValuePropertyType)
                    .WithLeftRightArguments(Target.Name, Target.Name)
                    .WithBody(cw);
            }

            foreach (var i in "+,-".Split(','))
            {
                var cw               = Ext.Create<BasicUnitedValuesGenerator>();
                var minusIfNecessary = i == "-" ? "-" : "";
                cw.SingleLineIf(
                    "left.Value.Equals(" + ValuePropertyType + ".Zero) && string.IsNullOrEmpty(left.Unit.UnitName)",
                    ReturnValue(minusIfNecessary + "right"));
                cw.SingleLineIf(
                    "right.Value.Equals(" + ValuePropertyType + ".Zero) && string.IsNullOrEmpty(right.Unit.UnitName)",
                    ReturnValue("left"));

                cw.WriteLine("right = right.ConvertTo(left.Unit);");
                cw.WriteLine(ReturnValue("new " + Cfg.ValueTypeName + "(left.Value " + i + " right.Value, left.Unit)"));

                Target.AddMethod(i, Cfg.ValueTypeName)
                    .WithLeftRightArguments(Target.Name, Target.Name)
                    .WithBody(cw);
            }
        }

        private void Add_Comparable()
        {
            if (!Cfg.IsComparable) return;
            Target.AddMethod("CompareTo", "int")
                .WithBodyFromExpression(
                    "UnitedValuesUtils.Compare<" + Cfg.ValueTypeName + ", " + Cfg.UnitTypeName + ">(this, other)")
                .AddParam("other", Target.Name);

            var operators = "!=,==,>,<,>=,<=";
            foreach (var oper in operators.Split(','))
                Target.AddMethod(oper, "bool")
                    .WithBodyFromExpression("left.CompareTo(right) " + oper + " 0")
                    .WithLeftRightArguments(Target.Name, Target.Name);
        }


        private void Add_ConvertTo()
        {
            var cw = Ext.Create<BasicUnitedValuesGenerator>();
            cw.SingleLineIf("Unit.Equals(newUnit)", ReturnValue("this"));
            cw.WriteLine("var basic = GetBaseUnitValue();");
            cw.WriteLine("var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);");
            cw.WriteLine(ReturnValue("new " + Target.Name + "(basic / factor, newUnit)"));

            Target.AddMethod("ConvertTo", Target.Name)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.UnitTypeName);
        }

        private void Add_GetBaseUnitValue()
        {
            var cs = Ext.Create<BasicUnitedValuesGenerator>();
            cs.SingleLineIf("Unit.Equals(BaseUnit)", ReturnValue("Value"));
            cs.WriteLine("var factor = GlobalUnitRegistry.Factors.Get(Unit);");
            cs.SingleLineIf("!(factor is null)", ReturnValue("Value * factor.Value"));
            cs.WriteLine("throw new Exception(\"Unable to find multiplication for unit \" + Unit);");
            Target.AddMethod("GetBaseUnitValue", ValuePropertyType)
                .WithBody(cs);
        }

        private void Add_Parse()
        {
            var cs = Ext.Create<BasicUnitedValuesGenerator>();
            cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({Cfg.ValueTypeName}));");
            cs.WriteLine(
                $"return new {Cfg.ValueTypeName}(parseResult.Value, new {Cfg.UnitTypeName}(parseResult.UnitName));");
            Target.AddMethod("Parse", Cfg.ValueTypeName)
                .WithBody(cs)
                .WithStatic()
                .AddParam<string>("value", Target);
        }

        private void Add_Properties()
        {
            Target.AddField("BaseUnit", Cfg.UnitTypeName)
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue(Cfg.BaseUnit);
            Target.AddField("Zero", Cfg.ValueTypeName)
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue($"new {Target.Name}(0, BaseUnit)");
        }

        private void Add_Round()
        {
            var cs = Ext.Create<BasicUnitedValuesGenerator>();
            cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({Cfg.ValueTypeName}));");
            cs.WriteLine(
                $"return new {Cfg.ValueTypeName}(parseResult.Value, new {Cfg.UnitTypeName}(parseResult.UnitName));");
            Target.AddMethod("Round", Cfg.ValueTypeName)
                .WithBodyFromExpression("new " + Cfg.ValueTypeName + "(Math.Round(Value, decimalPlaces), Unit)")
                .AddParam<int>("decimalPlaces", Target);
        }
    }
}