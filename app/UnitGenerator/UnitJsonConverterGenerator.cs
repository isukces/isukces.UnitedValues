using System;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using Newtonsoft.Json;

namespace UnitGenerator
{
    public class UnitJsonConverterGenerator : BaseGenerator<IUnitConfig>
    {
        public UnitJsonConverterGenerator(string output, string nameSpace) : base(output, nameSpace)
        {
        }

        protected override void GenerateOne()
        {
            if (ClassicImpl)
            {
                cl.BaseClass = "JsonConverter";

                Add_CanConvert();
                Add_ReadJson();
                Add_WriteJson();
            }
            else
            {
                cl.BaseClass = "AbstractUnitJsonConverter<" + Cfg.ValueTypeName + ", " + Cfg.UnitTypeName + ">";
                {
                    var cw = new CsCodeWriter();
                    cw.WriteLine("unit = unit?.Trim();");
                    cw.WriteLine(
                        $"return new {Cfg.ValueTypeName}(value, string.IsNullOrEmpty(unit) ? {Cfg.ValueTypeName}.BaseUnit : new {Cfg.UnitTypeName}(unit));");

                    var m = cl.AddMethod("Make", Cfg.ValueTypeName)
                        .WithOverride()
                        .WithVisibility(Visibilities.Protected)
                        .WithBody(cw);
                    m.AddParam("value", UnitedValuesGenerator.ValuePropertyType);
                    m.AddParam("unit", "string");
                }
                {
                    var m = cl.AddMethod("Parse", Cfg.ValueTypeName)
                        .WithOverride()
                        .WithVisibility(Visibilities.Protected)
                        .WithBodyFromExpression(Cfg.ValueTypeName + ".Parse(txt)");
                    m.AddParam("txt", "string");
                }
            }
        }

        protected override string GetTypename(IUnitConfig cfg)
        {
            return cfg.ValueTypeName + "JsonConverter";
        }

        protected override void PrepareFile(CsFile file)
        {
            base.PrepareFile(file);
            file.AddImportNamespace("Newtonsoft.Json");
        }

        private void Add_CanConvert()
        {
            cl.AddMethod("CanConvert", "bool")
                .WithOverride()
                .WithBodyFromExpression($"objectType == typeof({Cfg.UnitTypeName})")
                .AddParam("objectType", "Type");
        }

        private void Add_ReadJson()
        {
            var cw = new CsCodeWriter();
            cw.Open("if (reader.ValueType == typeof(string))");
            cw.SingleLineIf($"objectType == typeof({Cfg.ValueTypeName})",
                ReturnValue($"{Cfg.ValueTypeName}.Parse((string)reader.Value)"));
            cw.Close();
            cw.WriteLine("throw new NotImplementedException();");

            var m = cl.AddMethod("ReadJson", "object")
                .WithOverride()
                .WithBody(cw);
            m.AddParam<JsonReader>("reader", cl);
            m.AddParam<Type>("objectType", cl);
            m.AddParam<object>("existingValue", cl);
            m.AddParam<JsonSerializer>("serializer", cl);
        }

        private void Add_WriteJson()
        {
            var cw = new CsCodeWriter();

            cw.SingleLineIf("value is null",
                "writer.WriteNull();",
                "writer.WriteValue(value.ToString());");

            var m = cl.AddMethod("WriteJson", "void")
                .WithOverride()
                .WithBody(cw);
            m.AddParam<JsonWriter>("writer", cl);
            m.AddParam<object>("value", cl);
            m.AddParam<JsonSerializer>("serializer", cl);
        }

        public bool ClassicImpl { get; set; }
    }
}