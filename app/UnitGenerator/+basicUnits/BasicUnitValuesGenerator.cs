using System;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public class BasicUnitValuesGenerator : BaseValuesGenerator<BasicUnit>
    {
        public BasicUnitValuesGenerator(string output, string nameSpace)
            : base(output, nameSpace)
        {
        }

        public static void Add_FromMethods(string valueTypeName, TypesGroup types, CsClass target,
            IDerivedUnitDefinition u)
        {
            foreach (var inputType in "decimal,double,int,long".Split(','))
            {
                var arg = "value";
                if (inputType == OtherValuePropertyType)
                    arg = $"({ValuePropertyType}){arg}";

                var args = new Args(arg, types.Container + "." + u.FieldName)
                    .Create(target.Name);
                var valueIn           = $" value in {u.UnitShortCode}";
                var methodName        = "From" + u.FromMethodNameSufix.CoalesceNullOrWhiteSpace(u.FieldName);
                var methodDescription = $"creates {types.Value.FirstLower()} from{valueIn}";
                var m = target.AddMethod(methodName, target.Name, methodDescription)
                    .WithStatic()
                    .WithBodyFromExpression(args);
                m.AddParam("value", inputType).Description = string.Format("{0}{1}", valueTypeName, valueIn);
            }
        }

        protected override void GenerateOne()
        {
            Target.Kind = CsNamespaceMemberKind.Struct;
            foreach (var i in Cfg.Interfaces)
                Target.ImplementedInterfaces.Add(i);

            Target.Attributes.Add(new CsAttribute("Serializable"));
            Target.Attributes.Add(
                new CsAttribute("JsonConverter").WithArgumentCode("typeof(" + Cfg.UnitTypes.Value + "JsonConverter)"));

            AddCommonValues_PropertiesAndConstructor(Cfg.UnitTypes.Unit);

            Add_Properties();
            Add_GetBaseUnitValue();
            Add_Parse();
            Add_Round(Cfg.UnitTypes);
            Add_Comparable();
            Add_Algebra_MulDiv();
            Add_Algebra_MinusUnary();
            Add_Algebra_PlusMinus();
            Add_ConvertTo();
            Add_FromMethods();
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
                    Cfg.UnitTypes.Unit, null, "unit")
            };
        }

        protected override string GetTypename(BasicUnit cfg)
        {
            return cfg.UnitTypes.Value;
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }

        private void Add_Algebra_MinusUnary()
        {
            Target.AddOperator("-", new Args("-value.Value", "value.Unit"))
                .AddParam("value", Target.Name);
        }


        private void Add_Algebra_MulDiv()
        {
            Target.AddOperator("*", new Args("value.Value * number", "value.Unit"))
                .WithLeftRightArguments(Target.Name, ValuePropertyType, "value", "number");
            Target.AddOperator("*", new Args("value.Value * number", "value.Unit"))
                .WithLeftRightArguments(ValuePropertyType, Target.Name, "number", "value");
            Target.AddOperator("/", new Args("value.Value / number", "value.Unit"))
                .WithLeftRightArguments(Target.Name, ValuePropertyType, "value", "number");

            {
                var cw = Ext.Create<BasicUnitValuesGenerator>();
                cw.WriteLine("right = right.ConvertTo(left.Unit);");
                cw.WriteLine(ReturnValue("left.Value / right.Value"));
                Target.AddMethod("/", ValuePropertyType)
                    .WithLeftRightArguments(Target.Name, Target.Name)
                    .WithBody(cw);
            }
        }

        private void Add_Algebra_PlusMinus()
        {
            const string right = "right";
            const string left  = "left";

            var delta = BasicUnitDefs.All.GetDeltaByUnit(Cfg.UnitTypes.Unit);
            if (delta != null)
                if (delta.UnitTypes.Value == Cfg.UnitTypes.Value)
                    delta = null;

            void AddPlusOrMinus(string op, string lt, string rt)
            {
                var resultType = Cfg.UnitTypes.Value;
                if (delta != null && op == "-")
                    resultType = delta.UnitTypes.Value;

                string CreateResultFromVariable(string varName, string srcType, bool addMinus = false)
                {
                    var result = addMinus ? "-" + varName : varName;
                    if (delta is null || srcType == resultType) return result;

                    var unitSource = varName;
                    if (lt != rt)
                    {
                        if (lt == resultType)
                            unitSource = left;
                        else if (rt == resultType)
                            unitSource = right;
                        else
                            throw new NotSupportedException();
                    }

                    result = new Args(result + ".Value", unitSource + ".Unit").Create(resultType);
                    return result;
                }

                var cw = Ext.Create<BasicUnitValuesGenerator>();

                var result1 = CreateResultFromVariable(right, rt, op == "-");
                cw.SingleLineIf(
                    $"{left}.Value.Equals({ValuePropertyType}.Zero) && string.IsNullOrEmpty({left}.Unit.UnitName)",
                    ReturnValue(result1));

                result1 = CreateResultFromVariable(left, lt);
                cw.SingleLineIf(
                    right + ".Value.Equals(" + ValuePropertyType + ".Zero) && string.IsNullOrEmpty(" + right +
                    ".Unit.UnitName)",
                    ReturnValue(result1));

                cw.WriteLine($"{right} = {right}.ConvertTo({left}.Unit);");
                var returnExpression = new Args($"{left}.Value {op} {right}.Value", $"{left}.Unit").Create(resultType);
                cw.WriteLine(ReturnValue(returnExpression));
                Target.AddMethod(op, resultType)
                    .WithLeftRightArguments(lt, rt)
                    .WithBody(cw);
            }

            AddPlusOrMinus("-", Target.Name, Target.Name);
            if (delta != null)
            {
                AddPlusOrMinus("+", Target.Name, delta.UnitTypes.Value);
                AddPlusOrMinus("+", delta.UnitTypes.Value, Target.Name);
            }
            else
            {
                AddPlusOrMinus("+", Target.Name, Target.Name);
            }
        }

        private void Add_Comparable()
        {
            if (!Cfg.IsComparable) return;
            Target.AddMethod("CompareTo", "int")
                .WithBodyFromExpression(
                    "UnitedValuesUtils.Compare<" + Cfg.UnitTypes.Value + ", " + Cfg.UnitTypes.Unit + ">(this, other)")
                .AddParam("other", Target.Name);

            var operators = "!=,==,>,<,>=,<=";
            foreach (var oper in operators.Split(','))
                Target.AddMethod(oper, "bool")
                    .WithBodyFromExpression("left.CompareTo(right) " + oper + " 0")
                    .WithLeftRightArguments(Target.Name, Target.Name);
        }


        private void Add_ConvertTo()
        {
            var cw = Ext.Create(GetType());
            cw.SingleLineIf("Unit.Equals(newUnit)", ReturnValue("this"));
            cw.WriteLine("var basic = GetBaseUnitValue();");
            cw.WriteLine("var factor = GlobalUnitRegistry.Factors.GetThrow(newUnit);");
            cw.WriteLine(ReturnValue("new " + Target.Name + "(basic / factor, newUnit)"));

            Target.AddMethod("ConvertTo", Target.Name)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.UnitTypes.Unit);
        }

        private void Add_FromMethods()
        {
            var tmp = DerivedUnitGeneratorRunner.All;
            var d   = tmp.ByName(Cfg.UnitTypes.Value);

            if (d is null) return;
            foreach (var u in d.Units)
                Add_FromMethods(Cfg.UnitTypes.Value, Cfg.UnitTypes, Target, u);
        }


        private void Add_GetBaseUnitValue()
        {
            var cs = Ext.Create<BasicUnitValuesGenerator>();
            cs.SingleLineIf("Unit.Equals(BaseUnit)", ReturnValue("Value"));
            cs.WriteLine("var factor = GlobalUnitRegistry.Factors.Get(Unit);");
            cs.SingleLineIf("!(factor is null)", ReturnValue("Value * factor.Value"));
            cs.WriteLine("throw new Exception(\"Unable to find multiplication for unit \" + Unit);");
            Target.AddMethod("GetBaseUnitValue", ValuePropertyType)
                .WithBody(cs);
        }

        private void Add_Parse()
        {
            var cs = Ext.Create<BasicUnitValuesGenerator>();
            cs.WriteLine($"var parseResult = CommonParse.Parse(value, typeof({Cfg.UnitTypes.Value}));");
            cs.WriteLine(
                $"return new {Cfg.UnitTypes.Value}(parseResult.Value, new {Cfg.UnitTypes.Unit}(parseResult.UnitName));");
            Target.AddMethod("Parse", Cfg.UnitTypes.Value)
                .WithBody(cs)
                .WithStatic()
                .AddParam<string>("value", Target);
        }

        private void Add_Properties()
        {
            Target.AddField("BaseUnit", Cfg.UnitTypes.Unit)
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue(Cfg.BaseUnit);
            Target.AddField("Zero", Cfg.UnitTypes.Value)
                .WithStatic()
                .WithIsReadOnly()
                .WithConstValue($"new {Target.Name}(0, BaseUnit)");
        }

    }
}