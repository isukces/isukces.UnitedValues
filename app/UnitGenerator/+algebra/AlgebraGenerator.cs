using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator;

internal class Generator : BaseGenerator<UnitDefinition>
{
    public Generator(string output, string nameSpace) : base(output, nameSpace)
    {
        _nameSpace = nameSpace;
    }


    private static void AddOperatorMethod(CsClass cl, MulDivDefinition i)
    {
        var l     = Gv(i.Left, "left");
        var r     = Gv(i.Right, "right");
        var value = $"{l} {i.Operator} {r}";
        if (!i.Result.Equals(UnitDefinition.Scalar))
            value = $"new {i.Result.ClassName}({value})";
        var m = cl.AddMethod(i.Operator, i.Result.ClassName)
            .WithBody($"return {value};");
        m.AddParam("left", i.Left.ClassName);
        m.AddParam("right", i.Right.ClassName);
        m.Description = i.Description;
    }

    private static string Gv(UnitDefinition u, string name)
    {
        return u.Equals(UnitDefinition.Scalar) ? name : name + ".Value";
    }


    protected override void GenerateOne()
    {
        Target.Kind        = CsNamespaceMemberKind.Struct;
        Target.Description = $"Reprezentuje {Cfg.Description} w [{Cfg.Unit}]";
        {
            var p = Target.AddProperty("Value", (CsType)"double");
            p.IsPropertyReadOnly          = true;
            p.EmitField                   = false;
            p.MakeAutoImplementIfPossible = true;
        }
        {
            var c = Target.AddConstructor("").WithBody("Value = value;");
            c.AddParam("value", (CsType)"double");
        }
        {
            Add_ImplicitOperator((CsType)"double", Cfg.ClassName, "src.Value");
        }
        {
            // operatory mnożenia przez liczbę
            var m = Target.AddMethod("*", Cfg.ClassName)
                .WithBody($"return new {Cfg.ClassName}(number * x.Value);");
            m.AddParam("number", (CsType)"double");
            m.AddParam("x", Cfg.ClassName);
            // odwrócona wersja
            m = Target.AddMethod("*", Cfg.ClassName)
                .WithBody($"return new {Cfg.ClassName}(x.Value * number);");
            m.AddParam("x", Cfg.ClassName);
            m.AddParam("number", (CsType)"double");
            // operator dzielenia
            m = Target.AddMethod("/", Cfg.ClassName)
                .WithBody($"return new {Cfg.ClassName}(x.Value / number);");
            m.AddParam("x", Cfg.ClassName);
            m.AddParam("number", (CsType)"double");

            // operator dzielenia
            m = Target.AddMethod("/", (CsType)"double")
                .WithBody("return x.Value / y.Value;");
            m.AddParam("x", Cfg.ClassName);
            m.AddParam("y", Cfg.ClassName);
        }
        // operatory dodawania/odejmowania
        foreach (var op in "+-")
        {
            var m = Target.AddMethod(op.ToString(), Cfg.ClassName)
                .WithBody($"return new {Cfg.ClassName}(left.Value {op} right.Value);");
            m.AddParam("left", Cfg.ClassName);
            m.AddParam("right", Cfg.ClassName);
        }

        // operator negacji
        {
            var m = Target.AddMethod("-", Cfg.ClassName)
                .WithBody($"return new {Cfg.ClassName}(-x.Value);");
            m.AddParam("x", Cfg.ClassName);
        }
        {
            // operatory mnożenia przez inne jednostki
            foreach (var i in Cfg.MulsAndDivs)
            {
                AddOperatorMethod(Target, i);
                if (i.Operator == "*")
                {
                    var swapped = i.GetSwap();
                    if (!i.Equals(swapped))
                        AddOperatorMethod(Target, swapped);
                }
            }
        }

        MakeToString(Target, $@"$""{{Value}} {Cfg.Unit}""");
    }

    protected override string GetTypename(UnitDefinition cfg)
    {
        return cfg.ClassName.ToString();
    }
    
    private readonly string _nameSpace;
}