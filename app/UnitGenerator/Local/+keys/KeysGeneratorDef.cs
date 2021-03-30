using System;
using System.Reflection;
using iSukces.Code;

namespace UnitGenerator.Local
{
    public class KeysGeneratorDef
    {
        public KeysGeneratorDef(string typeName, Assembly targetAssembly, WrappedTypes wrappedType, string valuePropertyName = "Value")
        {
            TypeName               = typeName;
            TargetAssembly         = targetAssembly;
            WrappedType            = wrappedType;
            ValuePropertyName = valuePropertyName;
        }

        public string GetToStringExpression()
        {
            if (!string.IsNullOrEmpty(ToStringTemplate))
            {
                var format = $"string.Format({{0}}, {ValuePropertyName})";
                return string.Format(format, ToStringTemplate.CsEncode());
            }

            if (WrappedType == WrappedTypes.String)
                return ValuePropertyName;
            return $"{ValuePropertyName}.ToString()";
        }

        public string   TypeName       { get; }
        public Assembly TargetAssembly { get; }

        public string CsWrappedType
        {
            get
            {
                switch (WrappedType)
                {
                    case WrappedTypes.String:
                        return "string";
                    case WrappedTypes.Int:
                        return "int";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public WrappedTypes WrappedType       { get;  }
        public string       ValuePropertyName { get; }


        public string ToStringTemplate { get; set; }

        public string TypeDescription { get; set; }
    }

    public enum WrappedTypes
    {
        String,
        Int
    }
}