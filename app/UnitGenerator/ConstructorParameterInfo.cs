using System;
using System.ComponentModel;
using iSukces.Code;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class ConstructorParameterInfo
    {
        public ConstructorParameterInfo(string propertyName, string propertyType, string expression, string description,
            Flags1 checkNotNull = Flags1.None)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            Expression   = expression ?? GetExpr(propertyName, propertyType);
            Description  = description;
            CheckNotNull = checkNotNull;
        }

        private static string GetExpr(string propertyName, string propertyType)
        {
            var arg = propertyName.FirstLower();
            if (propertyType == "string")
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

        public string PropertyType { get; }

        public string Expression { get; }

        public string Description  { get; }
        public Flags1 CheckNotNull { get; }
    }

    [Flags]
    public enum Flags1
    {
        None = 0,
        NotNull = 1,
        NotEmpty = 2,
        NotWhitespace = 4,
        TrimValue = 8,

        NotNullOrWhitespace = NotNull | NotWhitespace,
        NotNullOrEmpty = NotNull | NotEmpty,

        NormalizedString = NotNull | NotNullOrWhitespace | TrimValue
    }
}