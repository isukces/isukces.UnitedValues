using iSukces.Code;
using iSukces.Code.AutoCode;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public abstract class BaseCompositeValuesGenerator<T> : BaseValuesGenerator<T>
        where T : IUnitInfo
    {
        protected BaseCompositeValuesGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected abstract void Add_FromMethods();

        protected abstract void Add_Parse();

        protected void Add_Parse(string splitMethodName)
        {
            string ArrayItemCode(ref int columnIndex)
            {
                return $"units[{(columnIndex++).CsEncode()}]";
            }

            Args GetConstructorArguments(TypesGroup tg, ref int columnIndex)
            {
                var aa        = ProductUnitDefs.All;
                var a4        = aa.ByValueTypeName(tg.Value);
                var arguments = ArrayItemCode(ref columnIndex);
                if (a4 is null) return new Args(arguments);

                return new Args(
                    new Args(arguments).Create(a4.CounterUnit.Unit.TypeName),
                    new Args(ArrayItemCode(ref columnIndex)).Create(a4.DenominatorUnit.Unit.TypeName)
                );
            }

            Args licznik, mianownik;
            {
                var columnIndex = 0;
                if (Cfg is FractionUnit fu)
                {
                    licznik   = GetConstructorArguments(fu.CounterUnit, ref columnIndex);
                    mianownik = GetConstructorArguments(fu.DenominatorUnit, ref columnIndex);
                }
                else
                {
                    licznik   = new Args(ArrayItemCode(ref columnIndex));
                    mianownik = new Args(ArrayItemCode(ref columnIndex));
                }
            }

            var cw = Ext.Create(GetType());
            cw.SingleLineIf("string.IsNullOrEmpty(value)",
                "throw new ArgumentNullException(nameof(value));");

            cw.WriteLine("var r = CommonParse.Parse(value, typeof(" + Target.Name + "));");

            cw.WriteLine("var units = " + splitMethodName + "(r.UnitName);");
            var sum = mianownik.Arguments.Length + licznik.Arguments.Length;
            cw.SingleLineIf("units.Length != " + sum.CsEncode(),
                "throw new Exception($\"{r.UnitName} is not valid " + Target.Name + " unit\");");

            cw.WriteAssign("counterUnit", new Args("units[0]").Create(GenInfo.First.Unit), true);
            //cw.WriteLine("var counterUnit = new " + GenInfo.First.Unit + "(units[0]);");
            cw.WriteAssign("denominatorUnit", mianownik.Create(GenInfo.Second.Unit), true);
            // cw.WriteLine("var denominatorUnit = new " + GenInfo.Second.Unit + "(units[1]);");
            cw.WriteLine(ReturnValue($"new {Target.Name}(r.Value, counterUnit, denominatorUnit)"));

            var m = Target.AddMethod("Parse", GenInfo.Result.Value.ValueTypeName)
                .WithStatic()
                .WithBody(cw);
            m.AddParam("value", "string");
        }


        protected override void GenerateOne()
        {
            GenInfo     = GetInfo();
            Target.Kind = CsNamespaceMemberKind.Struct;
            Add_ImplementedInterfaces();

            Add_ClassAttributes();
            AddCommonValues_PropertiesAndConstructor(GenInfo.Result.Unit);
            AddCommon_EqualityOperators();
            Add_ConvertTo();
            Add_AlternateConstructor();
            Add_Parse();
            Add_GetBaseUnitValue();

            Add_WithCounterUnit();
            Add_WithDenominatorUnit();

            Add_FromMethods();
            Add_Round(Cfg.UnitTypes);
        }

        protected abstract CompositeUnitGeneratorInfo GetInfo();

        private void Add_AlternateConstructor()
        {
            var f    = GenInfo.FirstPropertyName.FirstLower();
            var s    = GenInfo.SecondPropertyName.FirstLower();
            var cw   = new CsCodeWriter();
            var code = new Args(f, s).Create(GenInfo.Result.Unit);
            cw.WriteLine("{0} = {1};", ValuePropName, ValuePropName.FirstLower());
            cw.WriteLine("{0} = {1};", UnitPropName, code);

            var m = Target.AddConstructor()
                .WithBody(cw);
            m.AddParam(ValuePropName.FirstLower(), ValuePropertyType);
            m.AddParam(f, GenInfo.First.Unit.GetTypename());
            m.AddParam(s, GenInfo.Second.Unit.GetTypename());
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
            var cw = Ext.Create(GetType());
            cw.SingleLineIf("Unit.Equals(newUnit)", ReturnValue("this"));

            cw.WriteLine("var a = new " + GenInfo.First.Value + "(Value, Unit." + GenInfo.FirstPropertyName + ");");
            cw.WriteLine("var b = new " + GenInfo.Second.Value + "(1, Unit." + GenInfo.SecondPropertyName + ");");
            cw.WriteLine("a = a.ConvertTo(newUnit." + GenInfo.FirstPropertyName + ");");
            cw.WriteLine("b = b.ConvertTo(newUnit." + GenInfo.SecondPropertyName + ");");
            cw.WriteLine(ReturnValue("new " + GenInfo.Result.Value + "(a.Value / b.Value, newUnit)"));

            Target.AddMethod("ConvertTo", Target.Name)
                .WithBody(cw)
                .AddParam("newUnit", GenInfo.Result.Unit.GetTypename());
        }

        protected override void Add_GetBaseUnitValue()
        {
            var cw = Ext.Create(GetType());
            cw.WriteLine("throw new System.NotImplementedException();");
            Target.AddMethod("GetBaseUnitValue", ValuePropertyType).WithBody(cw);
        }

        private void Add_ImplementedInterfaces()
        {
            var ii = "IUnitedValue<{0}Unit>, IEquatable<{0}>, IFormattable";
            foreach (var i in ii.Split(','))
                Target.ImplementedInterfaces.Add(string.Format(i.Trim(), Target.Name));
        }

        private void Add_WithCounterUnit()
        {
            var valueType = GenInfo.Result.Value;
            var unitType  = GenInfo.Result.Unit;
            var cw        = Ext.Create(GetType());
            cw.WriteLine("var oldUnit = Unit." + GenInfo.FirstPropertyName + ";");
            cw.SingleLineIf("oldUnit == newUnit", "return this;");
            cw.WriteLine("var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);");
            cw.WriteLine("var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);");
            cw.WriteLine("var resultUnit = Unit.With" + GenInfo.FirstPropertyName + "(newUnit);");
            cw.WriteLine($"return new {valueType}(oldFactor / newFactor * Value, resultUnit);");

            Target.AddMethod("With" + GenInfo.FirstPropertyName, GenInfo.Result.Value.ValueTypeName)
                .WithBody(cw)
                .AddParam("newUnit", GenInfo.First.Unit.GetTypename());
        }

        private void Add_WithDenominatorUnit()
        {
            var valueType = GenInfo.Result.Value;
            var cw        = Ext.Create(GetType());
            cw.WriteLine("var oldUnit = Unit." + GenInfo.SecondPropertyName + ";");
            cw.SingleLineIf("oldUnit == newUnit", "return this;");
            cw.WriteLine("var oldFactor = GlobalUnitRegistry.Factors.GetThrow(oldUnit);");
            cw.WriteLine("var newFactor = GlobalUnitRegistry.Factors.GetThrow(newUnit);");
            cw.WriteLine("var resultUnit = Unit.With" + GenInfo.SecondPropertyName + "(newUnit);");
            cw.WriteLine($"return new {valueType}(newFactor / oldFactor * Value, resultUnit);");

            Target.AddMethod("With" + GenInfo.SecondPropertyName + "", GenInfo.Result.Value.ValueTypeName)
                .WithBody(cw)
                .AddParam("newUnit", GenInfo.Second.Unit.GetTypename());
        }

        protected CompositeUnitGeneratorInfo GenInfo { get; private set; }
    }
}