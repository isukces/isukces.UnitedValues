using System;
using System.Collections.Generic;
using System.Linq;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator;

public class BasicUnitGenerator : BaseGenerator<XUnitTypeName>
{
    public BasicUnitGenerator(string output, string nameSpace)
        : base(output, nameSpace)
    {
    }

    protected override void GenerateOne()
    {
        Related = RelatedUnitGeneratorDefs.All.GetPowers(Cfg);


        Target.Kind = CsNamespaceMemberKind.Class;
        // cl.Description = $"Reprezentuje {unit.Description} w [{unit.Unit}]";
        Add_Constructor();
        Add_Property();
        Add_ImplicitOperator();
        AddCommon_EqualityOperators();
        Add_Equals();
        Add_EqualsOverride();
        Add_GetHashCode();
        Add_ToString(PropertyName);
        Add_IEquatableEquals();


        Target.ImplementedInterfaces.Add(Target.Owner.GetTypeName<IUnit>());
        var t = MakeGenericType<IEquatable<int>>(Target.Owner, Cfg);
        Target.ImplementedInterfaces.Add(t);
        Target.WithAttribute(typeof(SerializableAttribute));

        Add_ConvertOtherPower();
        Add_Decompose();
    }


    protected override string GetTypename(XUnitTypeName cfg)
    {
        return cfg.GetTypename();
    }

    protected override void PrepareFile(CsFile file)
    {
        base.PrepareFile(file);
        file.AddImportNamespace("System.Runtime.CompilerServices");
    }

    private void Add_Constructor()
    {
        Add_Constructor(GetConstructorProperties(0));
        var c2 = GetConstructorProperties(1);
        if (c2 != null)
            Add_Constructor(c2);
    }

    private void Add_ConvertOtherPower()
    {
        var infos = RelatedUnitGeneratorDefs.All;

        var tmp = infos.GetPowers(Cfg);
        if (tmp?.MyInfo is null || tmp.Other.Count == 0)
            return;
        foreach (var i in tmp.Other.Values)
        {
            var targetUnit = new TypesGroup(i.Name);
            if (Cfg == targetUnit.Unit)
                continue;
            var cw = Ext.Create<BasicUnitGenerator>();
            var code = new CsArguments(Target.Name.Declaration, targetUnit.Unit.GetTypename())
                .MakeGenericTypeMethodCall("GlobalUnitRegistry.Relations.GetOrThrow", "this");
            cw.WriteReturn(code);
            var m = Target.AddMethod("Get" + targetUnit.Unit.TypeName, (CsType)targetUnit.Unit.GetTypename()).WithBody(cw);
            m.WithAggressiveInlining(Target);

            m.AddRelatedUnitSourceAttribute(Target, RelatedUnitSourceUsage.ProvidesRelatedUnit, 10);
        }
    }

    private void Add_Decompose()
    {
        if (Related is null || !Related.IsPower2OrHigher)
            return;
        var basicUnit = BaseUnit;

        {
            var type = new CsArguments(Target.GetTypeName<DecomposableUnitItem>().Declaration)
                .MakeGenericType(Target.GetTypeName<IReadOnlyList<int>>(), true);

            var cs = Ext.Create(GetType());
            if (basicUnit is null)
            {
                throw new NotSupportedException();
                /*cs.WriteLine("var decomposer = new UnitDecomposer();");
                cs.WriteLine("decomposer.Add(this, 1);");
                cs.WriteReturn("decomposer.Items");*/
            }
            else
            {
                cs.WriteReturn("new[] { " + nameof(IDerivedDecomposableUnit.GetBasicUnit) + "() }");
            }

            var m = Target.AddMethod(nameof(IDecomposableUnit.Decompose), type);
            m.WithBody(cs);

            Target.ImplementedInterfaces.Add(nameof(IDecomposableUnit));
        }
        // if (basicUnit != null)
        {
            var resultType = Target.GetTypeName<DecomposableUnitItem>();
            var cs         = Ext.Create(GetType());
            cs.WriteAssign("tmp", "Get" + basicUnit.Name + "Unit()", true);
            var args = new CsArguments("tmp", Related.MyInfo.Power.CsEncode()).Create(resultType);
            cs.WriteReturn(args);

            var m = Target.AddMethod(nameof(IDerivedDecomposableUnit.GetBasicUnit), resultType);
            m.WithBody(cs);

            Target.ImplementedInterfaces.Add(nameof(IDerivedDecomposableUnit));
        }
    }

    private RelatedUnit BaseUnit
    {
        get
        {
            if (Related.Other.Count == 0)
                return null;
            var basicUnit = Related.Other.Where(a => a.Key == 1)
                .Select(a => a.Value)
                .SingleOrDefault();
            return basicUnit;
        }
    }

    private void Add_Equals()
    {
        var m = Target.AddMethod(nameof(Equals), CsType.Bool)
            .WithBodyFromExpression($"String.Equals({PropertyName}, other?.{PropertyName})");
        var csType = (CsType)Cfg.GetTypename();
        csType.Nullable = NullableKind.ReferenceNullable;
        m.AddParam("other", csType);
    }

    private void Add_EqualsOverride()
    {
        // equals override
        //var cw         = new CsCodeWriter();
        var expression = $"obj is {Target.Name.Declaration} tmp && Equals(tmp)";
        //cw.WriteLine(expression);
        var m = Target.AddMethod(nameof(Equals), CsType.Bool)
            .WithOverride()
            .WithBodyAsExpression(expression);
        m.AddParam("obj", CsType.ObjectNullable);
    }

    private void Add_GetHashCode()
    {
        // GetHashCode override
        Target.AddMethod("GetHashCode", CsType.Int32)
            .WithOverride()
            .WithBodyFromExpression($"{PropertyName}?.GetHashCode() ?? 0");
    }

    private void Add_IEquatableEquals()
    {
        Target.AddMethod($"IEquatable<{Target.Name.Declaration}>.Equals", CsType.Bool)
            .WithBodyFromExpression("Equals(other)")
            .WithVisibility(Visibilities.InterfaceDefault)
            .AddParam("other", Target.Name);
    }

    private void Add_ImplicitOperator()
    {
        var pa   = (CsType)MakeGenericType<UnitDefinition<IUnit>>(Target, Cfg);
        // var expr = $"new {Cfg}(src.{PropertyName})";
        var expr = "src.Unit";
        Add_ImplicitOperator(pa, Target.Name, expr);
    }

    private void Add_Property()
    {
        Add_Properties(GetConstructorProperties(0));
        var c = GetConstructorProperties(1);
        if (c != null)
            Add_Properties(c);
    }


    private Col1 GetConstructorProperties(int nr)
    {
        string GetExpressionPlus()
        {
            switch (Cfg.TypeName)
            {
                case "AreaUnit":
                    return @"?.Replace('2', '²')";
                case "VolumeUnit":
                    return @"?.Replace('3', '³')";
                default:
                    return null;
            }
        }

        var expr = PropertyName.FirstLower() + GetExpressionPlus();
        if (nr == 1)
        {
            if (Related is null || !Related.IsPower2OrHigher)
                return null;
            var a = new[]
            {
                new ConstructorParameterInfo("BaseUnit", (CsType)Related.MyInfo.PowerOne.Unit.TypeName, null, "based on",
                    Flags1.NotNull)
                {
                    PropertyCreated = property =>
                    {
                        property.AddRelatedUnitSourceAttribute(Target, RelatedUnitSourceUsage.DoNotUse, 0);
                    }
                },
                new ConstructorParameterInfo(PropertyName, CsType.String, expr, "name of unit",
                    Flags1.Optional | Flags1.DoNotAssignProperty | Flags1.DoNotCreateProperty)
            };
            var h         = new Col1(a);
            var powerChar = Ext.GetPowerSuffix(Related.MyInfo.Power);
            h.Writer2.WriteLine("unitName = unitName?.Trim();");
            h.Writer2.WriteLine(PropertyName + " = string.IsNullOrEmpty(unitName) ? baseUnit.UnitName + " + powerChar.CsEncode() +
                                " : unitName;");
            return h;
        }

        {
            var b = new[]
            {
                new ConstructorParameterInfo(PropertyName, CsType.String, expr, "name of unit",
                    Flags1.NormalizedString)
            };
            return new Col1(b);
        }
    }


    private RelatedUnitsFamily Related { get; set; }


    private const string PropertyName = nameof(IUnitNameContainer.UnitName);
}