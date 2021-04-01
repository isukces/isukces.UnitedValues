using System;

namespace UnitGenerator
{
    /// <summary>
    ///     Stores path where to find the value of particular type
    /// </summary>
    public class ValueOfSomeTypeExpression
    {
        public ValueOfSomeTypeExpression(ValueOfSomeTypeExpressionRoot root, Type type, ExpressionPath path,
            Kind2 kind2)
        {
            Root  = root;
            Type  = type;
            Path  = path;
            Kind2 = kind2;
        }

        public override string ToString()
        {
            return $"{Path} => {Type.Name}";
        }

        public ValueOfSomeTypeExpression WithPath(ExpressionPath newPath)
        {
            return new ValueOfSomeTypeExpression(Root, Type, newPath, Kind2);
        }

        public ValueOfSomeTypeExpressionRoot Root  { get; }
        public Type                          Type  { get; }
        public ExpressionPath                Path  { get; }
        public Kind2                         Kind2 { get; }
    }

    public enum Kind2
    {
        Method,
        Property
    }
}