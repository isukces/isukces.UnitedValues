using System.Collections.Generic;
using System.IO;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public abstract class BaseGenerator<TDef>
    {
        protected BaseGenerator(string output, string nameSpace)
        {
            _output    = output;
            _nameSpace = nameSpace;
        }

        protected static string MakeGenericType<TGenericType>(ITypeNameResolver reslve, string arg)
        {
            var tn    = reslve.GetTypeName<TGenericType>();
            var parts = tn.Split('<');
            return parts[0] + "<" + arg + ">";
        }

        protected static void MakeToString(CsClass cl, string returnValue)
        {
            var m = cl.AddMethod("ToString", "string").WithBody($"return {returnValue};");
            m.Overriding = OverridingType.Override;
        }

        public void Generate(IEnumerable<TDef> all)
        {
            foreach (var unit in all)
            {
                Cfg = unit;
                var file = new CsFile();
                PrepareFile(file);
                var ns   = file.GetOrCreateNamespace(_nameSpace);
                var name = GetTypename(unit);
                cl           = ns.GetOrCreateClass(name);
                cl.IsPartial = true;
                GenerateOne();
                file.SaveIfDifferent(Path.Combine(_output, name + ".auto.cs"));
            }
        }

        protected void Add_Constructor(params ConstructorParameterInfo[] items)
        {
            var code = new CsCodeWriter();
            var m    = cl.AddConstructor("creates instance of " + cl.Name);
            foreach (var i in items)
            {
                code.WriteLine(i.PropertyName + " = " + i.Expression + ";");
                m.AddParam(i.PropertyName.FirstLower(), i.PropertyType, i.Description);
            }

            m.WithBody(code);
        }


        protected void Add_Properties(params ConstructorParameterInfo[] items)
        {
            foreach (var i in items) Add_Property(i.PropertyName, i.PropertyType, i.Description);
        }

        protected void Add_Property(string name, string type, string description)
        {
            cl.AddProperty(name, type)
                .WithDescription(description)
                .WithNoEmitField()
                .WithMakeAutoImplementIfPossible()
                .WithIsPropertyReadOnly();
        }

        protected abstract void GenerateOne();
        protected abstract string GetTypename(TDef unit);

        protected virtual void PrepareFile(CsFile file)
        {
            file.AddImportNamespace("System");
            file.AddImportNamespace("System.Globalization");
        }

        protected string ReturnValue(string expression)
        {
            return "return " + expression + ";";
        }

        public TDef Cfg { get; set; }

        public CsClass cl { get; set; }

        private readonly string _output;
        private readonly string _nameSpace;
    }
}