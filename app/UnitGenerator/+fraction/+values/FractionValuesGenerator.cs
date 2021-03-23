using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using Self = UnitGenerator.FractionValuesGenerator;

namespace UnitGenerator
{
    internal class FractionValuesGenerator : BaseValuesGenerator<FractionUnit>
    {
        public FractionValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            Target.Kind = CsNamespaceMemberKind.Struct;
            Add_ImplementedInterfaces();

            Add_ClassAttributes();
            AddCommonValues_PropertiesAndConstructor(Cfg.UnitTypes.Unit);
            AddCommon_EqualityOperators();
            Add_ConvertTo();
            Add_AlternateConstructor();
            Add_Parse();
            Add_GetBaseUnitValue();

            Add_WithCounterUnit();
            Add_WithDenominatorUnit();

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


        protected override string GetTypename(FractionUnit cfg)
        {
            return Cfg.UnitTypes.Value;
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }

        private void Add_AlternateConstructor()
        {
            var cw   = new CsCodeWriter();
            var code = $"new {Cfg.UnitTypes.Unit}(counterUnit, denominatorUnit)";
            cw.WriteLine("{0} = {1};", ValuePropName, ValuePropName.FirstLower());
            cw.WriteLine("{0} = {1};", UnitPropName, code);

            var m = Target.AddConstructor()
                .WithBody(cw);
            m.AddParam(ValuePropName.FirstLower(), ValuePropertyType);
            m.AddParam("counterUnit", Cfg.CounterUnit.Unit);
            m.AddParam("denominatorUnit", Cfg.DenominatorUnit.Unit);
        }

        private void Add_ClassAttributes()
        {
            var attribute = new CsAttribute("Serializable");
            Target.Attributes.Add(attribute);
            attribute = new CsAttribute("JsonConverter")
                .WithArgumentCode($"typeof({Target.Name}JsonConverter)");
            Target.Attributes.Add(attribute);
        }

        private void Add_ConvertTo()
        {
            var cw = new CsCodeWriter();
            cw.SingleLineIf("Unit.Equals(newUnit)", ReturnValue("this"));

            cw.WriteLine("var a = new " + Cfg.CounterUnit.Value + "(Value, Unit.CounterUnit);");
            cw.WriteLine("var b = new " + Cfg.DenominatorUnit.Value + "(1, Unit.DenominatorUnit);");
            cw.WriteLine("a = a.ConvertTo(newUnit.CounterUnit);");
            cw.WriteLine("b = b.ConvertTo(newUnit.DenominatorUnit);");
            cw.WriteLine(ReturnValue("new " + Cfg.UnitTypes.Value + "(a.Value / b.Value, newUnit)"));

            Target.AddMethod("ConvertTo", Target.Name)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.UnitTypes.Unit);
        }

        private void Add_FromMethods()
        {
            var collection  = CommonFractionalUnitDefs.All;
            var commonUnits = collection.GetBy(Cfg.UnitTypes.Unit);
            if (commonUnits.Length == 0) return;
            foreach (var i in commonUnits)
            {
                IDerivedUnitDefinition u = new Dy
                {
                    PropertyName        = i.TargetPropertyName,
                    UnitShortName       = i.GetUnitName(),
                    FromMethodNameSufix = i.TargetPropertyName
                };
                BasicUnitValuesGenerator.Add_FromMethods(
                    i.Type.Value,
                    i.Type,
                    Target,
                    u);
            }
        }

        private void Add_GetBaseUnitValue()
        {
            var cw = new CsCodeWriter();
            cw.WriteLine("throw new System.NotImplementedException();");

            Target.AddMethod("GetBaseUnitValue", ValuePropertyType).WithBody(cw);
        }

        private void Add_ImplementedInterfaces()
        {
            var ii = "IUnitedValue<{0}Unit>, IEquatable<{0}>, IFormattable";
            foreach (var i in ii.Split(','))
                Target.ImplementedInterfaces.Add(string.Format(i.Trim(), Target.Name));
        }

        private void Add_Parse()
        {
            var cw = new CsCodeWriter();
            cw.SingleLineIf("string.IsNullOrEmpty(value)",
                "throw new ArgumentNullException(nameof(value));");

            cw.WriteLine("var r = CommonParse.Parse(value, typeof(" + Target.Name + "));");
            cw.WriteLine("var units = r.UnitName.Split('/');");
            cw.SingleLineIf("units.Length != 2",
                "throw new Exception($\"{r.UnitName} is not valid " + Target.Name + " unit\");");

            cw.WriteLine("var counterUnit = new " + Cfg.CounterUnit.Unit + "(units[0]);");
            cw.WriteLine("var denominatorUnit = new " + Cfg.DenominatorUnit.Unit + "(units[1]);");
            cw.WriteLine(ReturnValue($"new {Target.Name}(r.Value, counterUnit, denominatorUnit)"));

            var m = Target.AddMethod("Parse", Cfg.UnitTypes.Value)
                .WithStatic()
                .WithBody(cw);
            m.AddParam("value", "string");
        }

        private void Add_WithCounterUnit()
        {
            /*
            var cw = Ext.Create<Self>();
            cw.SingleLineIf("Unit.CounterUnit.Equals(newCounterUnit)", "return this;");

            const string valueToConvert = "tmp";
            const string resultUnit     = "resultUnit";
            cw.WriteLine("var {0} = new {1}(Value, Unit.CounterUnit);", valueToConvert, Cfg.CounterUnit.Value);
            cw.WriteLine("{0} = {0}.ConvertTo(newCounterUnit);", valueToConvert);
            cw.WriteLine("var {1} = new {0}(newCounterUnit, Unit.DenominatorUnit);", Cfg.Names.Unit, resultUnit);
            cw.WriteLine("return new {0}({2}.Value, {1});", Cfg.Names.Value, resultUnit, valueToConvert);
            */

            var valueType = Cfg.UnitTypes.Value;
            var unitType  = Cfg.UnitTypes.Unit;
            var cw        = Ext.Create<Self>();
            cw.WriteLine("var oldUnit = Unit.CounterUnit;");
            cw.SingleLineIf("oldUnit == newUnit", "return this;");
            cw.WriteLine("var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);");
            cw.WriteLine("var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);");
            cw.WriteLine("var resultUnit = Unit.WithCounterUnit(newUnit);");
            cw.WriteLine($"return new {valueType}(oldFactor / newFactor * Value, resultUnit);");

            Target.AddMethod("WithCounterUnit", Cfg.UnitTypes.Value)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.CounterUnit.Unit);
        }

        private void Add_WithDenominatorUnit()
        {
            var valueType = Cfg.UnitTypes.Value;
            var cw        = Ext.Create<Self>();
            cw.WriteLine("var oldUnit = Unit.DenominatorUnit;");
            cw.SingleLineIf("oldUnit == newUnit", "return this;");
            cw.WriteLine("var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);");
            cw.WriteLine("var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);");
            cw.WriteLine("var resultUnit = Unit.WithDenominatorUnit(newUnit);");
            cw.WriteLine($"return new {valueType}(newFactor / oldFactor * Value, resultUnit);");

            Target.AddMethod("WithDenominatorUnit", Cfg.UnitTypes.Value)
                .WithBody(cw)
                .AddParam("newUnit", Cfg.DenominatorUnit.Unit);
        }

        private class Dy : IDerivedUnitDefinition
        {
            public string PropertyName        { get; set; }
            public string UnitShortName       { get; set; }
            public string FromMethodNameSufix { get; set; }
        }
    }
}