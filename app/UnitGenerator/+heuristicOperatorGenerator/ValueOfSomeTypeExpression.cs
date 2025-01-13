using System;

namespace UnitGenerator;

/// <summary>
///     Stores path where to find the value of particular type
/// </summary>
public class ValueOfSomeTypeExpression
{
    public ValueOfSomeTypeExpression(ValueOfSomeTypeExpressionRoot root, Type type, TreeExpression path,
        Kind2 kind2)
    {
        Root       = root;
        Type       = type;
        Expression = path;
        Kind2      = kind2;
    }

    public override string ToString()
    {
        return $"{Expression} => {Type.Name}";
    }

    public ValueOfSomeTypeExpression WithExpression(TreeExpression newPath)
    {
        return new ValueOfSomeTypeExpression(Root, Type, newPath, Kind2);
    }

    public ValueOfSomeTypeExpressionRoot Root       { get; }
    public Type                          Type       { get; }
    public TreeExpression                Expression { get; }
    public Kind2                         Kind2      { get; }
}

public enum Kind2
{
    Method,
    Constructor,
    Property
}
