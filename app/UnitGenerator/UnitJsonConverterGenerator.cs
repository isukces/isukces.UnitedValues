using System;
using iSukces.Code;
using iSukces.Code.Interfaces;
using Newtonsoft.Json;

namespace UnitGenerator
{
    public class UnitJsonConverterGenerator : BaseGenerator<IUnitInfo>
    {
        public UnitJsonConverterGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            if (ClassicImpl)
            {
                Target.BaseClass = "JsonConverter";
                Add_CanConvert();
                Add_ReadJson();
                Add_WriteJson();
            }
            else
            {
                var tt         = Cfg.UnitTypes;
                var valueTypeName = tt.Value.ValueTypeName;
                Target.BaseClass = new CsArguments(valueTypeName, tt.Unit.TypeName).MakeGenericType("AbstractUnitJsonConverter");
                {
                    var cw = new CsCodeWriter();
                    cw.WriteLine("unit = unit?.Trim();");
                    cw.WriteLine(
                        $"return new {tt.Value}(value, string.IsNullOrEmpty(unit) ? {tt.Value}.BaseUnit : new {tt.Unit}(unit));");

                    var m = Target.AddMethod("Make", valueTypeName)
                        .WithOverride()
                        .WithVisibility(Visibilities.Protected)
                        .WithBody(cw);
                    m.AddParam("value", BasicUnitValuesGenerator.ValuePropertyType);
                    m.AddParam("unit", "string");
                }
                {
                    var m = Target.AddMethod("Parse", valueTypeName)
                        .WithOverride()
                        .WithVisibility(Visibilities.Protected)
                        .WithBodyFromExpression(tt.Value + ".Parse(txt)");
                    m.AddParam("txt", "string");
                }
            }
        }

        protected override string GetTypename(IUnitInfo cfg)
        {
            return cfg.UnitTypes.Value + "JsonConverter";
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }

        private void Add_CanConvert()
        {
            var tt = Cfg.UnitTypes;
            Target.AddMethod("CanConvert", "bool")
                .WithOverride()
                .WithBodyFromExpression($"objectType == typeof({tt.Unit})")
                .AddParam("objectType", "Type");
        }

        private void Add_ReadJson()
        {
            var valueTypeName = Cfg.UnitTypes.Value;
            var cw            = new CsCodeWriter();
            cw.Open("if (reader.ValueType == typeof(string))");
            cw.SingleLineIf($"objectType == typeof({valueTypeName})",
                ReturnValue($"{valueTypeName}.Parse((string)reader.Value)"));
            cw.Close();
            cw.WriteLine("throw new NotImplementedException();");

            var m = Target.AddMethod("ReadJson", "object", "Reads the JSON representation of the object.")
                .WithOverride()
                .WithBody(cw);
            m.AddParam<JsonReader>("reader", Target, "The JsonReader to read from.");
            m.AddParam<Type>("objectType", Target, "Type of the object.");
            m.AddParam<object>("existingValue", Target, "The existing value of object being read.");
            m.AddParam<JsonSerializer>("serializer", Target, "The calling serializer.");
        }

        private void Add_WriteJson()
        {
            var cw = new CsCodeWriter();

            var s                        = "value.ToString()";
            if (Cfg is ProductUnit pu) s = $"(({pu.UnitTypes.Value})value).SerializeToJson()";
            cw.SingleLineIf("value is null",
                "writer.WriteNull();",
                "writer.WriteValue(" + s + ");");

            var m = Target.AddMethod("WriteJson", "void")
                .WithOverride()
                .WithBody(cw);
            m.AddParam<JsonWriter>("writer", Target);
            m.AddParam<object>("value", Target);
            m.AddParam<JsonSerializer>("serializer", Target);
        }

        public bool ClassicImpl { get; set; }
    }
}