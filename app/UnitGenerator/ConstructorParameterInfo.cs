using System;
using System.Collections.Generic;
using System.ComponentModel;
using iSukces.Code;

namespace UnitGenerator;

//[ImmutableObject(true)]
public class ConstructorParameterInfo
{
    public ConstructorParameterInfo(string propertyName, CsType propertyType, string? expression, string description,
        Flags1 checkingFlags = Flags1.None)
    {
        PropertyName    = propertyName;
        PropertyType    = propertyType;
        Expression      = expression ?? GetExpr(propertyName, propertyType);
        Description     = description;
        CheckingFlags   = checkingFlags;
    }

    private static string GetExpr(string propertyName, CsType propertyType)
    {
        var arg = propertyName.FirstLower();
        if (propertyType.Declaration == "string")
            arg += ".TrimToNull()";
        return arg;
    }

    public override string ToString()
    {
        return
            $"PropertyName={PropertyName}, PropertyType={PropertyType}, Expression={Expression}, Description={Description}";
    }

    public string PropertyName { get; }

    public string ArgName => PropertyName.FirstLower();

    public string FieldName => "_" + ArgName;

    public CsType PropertyType { get; }

    public string Expression { get; }

    public string             Description          { get; }
    public Flags1             CheckingFlags        { get; }
    public Action<CsProperty> PropertyCreated      { get; init;  }
    public string             PropertyDefaultValue { get; init; }
}

[Flags]
public enum Flags1 : uint
{
    None = 0,
    NotNull = 1,
    NotEmpty = 2,
    NotWhitespace = 4,
    TrimValue = 8,
    Optional = 16,
    DoNotCreateProperty = 32,
    DoNotAssignProperty = 64,
    AddNotNullAttributeToPropertyIfPossible = 128,
    PropertyCanBeNull = 256,
    PropertyIsNeverNull = 512,
    EmitField = 1024,

    NotNullOrWhitespace = NotNull | NotWhitespace,
    NotNullOrEmpty = NotNull | NotEmpty,

    NormalizedString = NotNull | NotNullOrWhitespace | TrimValue
        
}

public class Col1
{
    public Col1(IReadOnlyList<ConstructorParameterInfo> items)
    {
        Items = items;
    }

    public IReadOnlyList<ConstructorParameterInfo> Items   { get; }
    public CsCodeWriter                            Writer1 { get; } = new CsCodeWriter();
    public CsCodeWriter                            Writer2 { get; } = new CsCodeWriter();
}
