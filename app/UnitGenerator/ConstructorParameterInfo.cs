using System.ComponentModel;
using iSukces.Code;

namespace UnitGenerator
{
    [ImmutableObject(true)]
    public class ConstructorParameterInfo
    {
        public ConstructorParameterInfo(string propertyName, string propertyType, string expression, string description)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
            Expression   = expression ?? GetExpr(propertyName, propertyType);
            Description  = description;
        }

        private static string GetExpr(string propertyName, string propertyType)
        {
            var arg= propertyName.FirstLower();
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

        public string Description { get; }
    }
}