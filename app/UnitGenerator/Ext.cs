using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using iSukces.Code;

namespace UnitGenerator
{
    public static class Ext
    {
        public static CsMethod AddOperator(this CsClass cl, string operatorName, params string[] args)
        {
            var arg = string.Join(", ", args);
            return cl.AddMethod(operatorName, cl.Name, "implements " + operatorName + " operator")
                .WithBodyFromExpression($"new {cl.Name}({arg})");
        }

        public static string CsEncode(decimal multiplicator)
        {
            return multiplicator.ToString(CultureInfo.InvariantCulture) + "m";
        }

        public static TValue[] GetStaticFieldsValues<THost, TValue>()
        {
            var l            = new List<TValue>();
            var bindingFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
            foreach (var i in typeof(THost).GetFields(bindingFlags))
                if (i.FieldType == typeof(TValue))
                    l.Add((TValue)i.GetValue(null));
            return l.ToArray();
        }

        public static CsMethod WithBodyFromAssignment(this CsMethod method, string variable, string code)
        {
            method.Body = $"{variable} = {code};";
            return method;
        }

        public static CsMethod WithBodyFromExpression(this CsMethod method, string code)
        {
            method.Body = $"return {code};";
            return method;
        }

        public static CsMethod WithLeftRightArguments(this CsMethod method, string leftType, string rightType,
            string leftName = "left",
            string rightName = "right")
        {
            method.AddParam(leftName, leftType);
            method.AddParam(rightName, rightType);
            return method;
        }
    }
}