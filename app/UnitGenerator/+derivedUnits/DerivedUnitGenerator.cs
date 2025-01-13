using System;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using JetBrains.Annotations;

namespace UnitGenerator;

public class DerivedUnitGenerator : BaseGenerator<RelatedUnit>
{
    public DerivedUnitGenerator(string output, string nameSpace)
        : base(output, nameSpace)
    {
    }

    private static (Type, Type) GetFractionalUnit(Type t)
    {
        foreach (var i in t.GetInterfaces())
        {
            if (!i.IsGenericType) continue;
            if (i.GetGenericTypeDefinition() != typeof(IFractionalUnit<,>)) continue;
            var args = i.GetGenericArguments();
            return (args[0], args[1]);
        }

        return (null, null);
    }

    private void Add_AllProperty()
    {
        var cw    = new CsCodeWriter();
        var array = new CsArguments(Cfg.Units.Select(q => q.FieldName).ToArray());
        array.CreateArray(cw, "return ");
        Target.AddProperty("All", (CsType)$"IReadOnlyList<UnitDefinition<{Cfg.Name}Unit>>")
                .WithIsPropertyReadOnly()
                .WithNoEmitField()
                .WithStatic()
                .WithOwnGetter(cw.Code)
                .Description = $"All known {Cfg.Name.FirstLower()} units";
    }

    private void Add_Properties()
    {
        foreach (var i in Cfg.Units)
        {
            var unitTypeName = (CsType)Cfg.Name.ToUnitTypeName().GetTypename();

            var n2 = i.FieldName + unitTypeName.Declaration;
            {
                var constValue = i.UnitConstructor;
                if (string.IsNullOrEmpty(constValue))
                {
                    var args       = i.UnitShortCode.GetCreationArgs(Related);
                    constValue = args.Create(unitTypeName);
                }

                Target.AddField(n2, unitTypeName)
                    .WithIsReadOnly()
                    .WithVisibility(Visibilities.Internal)
                    .WithConstValue(constValue)
                    .WithStatic();
            }
            {
                var args = new[]
                {
                    n2,
                    i.ScaleFactor
                };

                if (i.Aliases != null)
                    args = i.Aliases.Plus(args);

                var unitDefinitionType = new CsArguments(unitTypeName.Declaration)
                    .MakeGenericType("UnitDefinition");

                // public static readonly UnitDefinition<LengthUnit> Km
                // = new UnitDefinition<LengthUnit>("km", 1000m);
                var value = new CsArguments(args).Create(unitDefinitionType);
                Target.AddField(i.FieldName, unitDefinitionType)
                    .WithIsReadOnly()
                    .WithStatic()
                    .WithConstValue(value);
            }
            if (i.AddFromMethod)
            {
                var c = Get(Cfg.Name.ValueTypeName, out var file);
                CsFilesManager.AddGeneratorName(file, GetType().Name);
                var value = new CsArguments("value", Target.Name.Declaration+"."+ i.FieldName + ".Unit").Create(c.Name);
                c.AddMethod("From" + i.FieldName, c.Name).WithBody($"return {value};")
                    .WithParameter(new CsMethodParameter("value", CsType.Decimal));

            }
        }
    }

    private void Add_Register()
    {
        if (Cfg.PrefixRelations.Count == 0)
            return;
        var cw = new CsCodeWriter();
        foreach (var i in Cfg.PrefixRelations)
        foreach (var u in Cfg.Units)
        {
            var o  = u.FieldName.Substring(i.My.Length);
            var p1 = u.FieldName;
            var p2 = i.OtherUnitContainer + "s." + i.Other + o;
            var q  = $"dict.AddRelated<{i.MyUnitContainer}, {i.OtherUnitContainer}>({p1}, {p2});";
            cw.WriteLine(q);
            q = $"dict.AddRelated<{i.OtherUnitContainer}, {i.MyUnitContainer}>({p2}, {p1});";
            cw.WriteLine(q);
        }

        Target.AddMethod("Register", CsType.Void)
            .WithBody(cw)
            .WithStatic()
            .WithVisibility(Visibilities.Internal)
            .AddParam<UnitRelationsDictionary>("dict", Target);
    }

    private void Add_RegisterUnitExchangeFactors()
    {
        Target.WithAttributeFromName(nameof(UnitsContainerAttribute));
        var m = Target.AddMethod("RegisterUnitExchangeFactors", CsType.Void)
            .WithStatic()
            .WithBody("factors.RegisterMany(All);");
        m.AddParam<UnitExchangeFactors>("factors", Target);
    }


    private void Add_TryRecoverUnitFromName()
    {
        var resultTypeName = (CsType)Cfg.Name.ToUnitTypeName().GetTypename();

        var body = c();
        // koniec body
        var m = Target.AddMethod("TryRecoverUnitFromName", resultTypeName).WithStatic().WithBody(body);
        var p = m.AddParam("unitName", CsType.String);
        p.WithAttribute(CsAttribute.Make<NotNullAttribute>(Target));
        return;

        string c()
        {
            var cw = Ext.Create(GetType());

            const ArgChecking flags = ArgChecking.NormalizedString;
            cw.CheckArgument("unitName", flags, Target);
            cw.Open("foreach (var i in All)");
            cw.SingleLineIf("unitName == i.UnitName", "return i.Unit;");
            cw.Close();

            RelatedUnit cfg = Cfg;
            {
                var type = typeof(Power).Assembly.GetTypes().FirstOrDefault(a => a.Name == resultTypeName.Declaration);
                if (type != null)
                {
                    var t = GetFractionalUnit(type);
                    if (t.Item1 != null)
                    {
                        cw.WriteLine("// try to split");
                        cw.WriteLine("var parts = unitName.Split('/');");
                        cw.OpenIf("parts.Length == 2");
                        cw.WriteLine("var counterUnit = "+t.Item1.Name+"s.TryRecoverUnitFromName(parts[0]);");
                        cw.WriteLine("var denominatorUnit = "+t.Item2.Name+"s.TryRecoverUnitFromName(parts[1]);");
                        //cw.WriteLine("return new "+resultTypeName+"(counterUnit, denominatorUnit);");
                        cw.WriteLine("return " + resultTypeName.New("counterUnit", "denominatorUnit") + ";");
                        cw.Close();
                        cw.WriteLine("throw new ArgumentException(nameof(unitName));");
                        return cw.Code;
                    }
                }
            }
            cw.WriteReturn(new CsArguments("unitName").Create(resultTypeName));
            return cw.Code;
        }
    }

    protected override void GenerateOne()
    {
        Related         = RelatedUnitGeneratorDefs.All.GetPowers(Cfg.Name.ToUnitTypeName());
        Target.IsStatic = true;
        Add_AllProperty();
        Add_Properties();
        Add_Register();
        Add_RegisterUnitExchangeFactors();
        Add_TryRecoverUnitFromName();
    }


    protected override string GetTypename(RelatedUnit cfg)
    {
        return cfg.Name.ToUnitTypeName().ToUnitContainerTypeName().TypeName;
    }

    public RelatedUnitsFamily Related { get; set; }
}
