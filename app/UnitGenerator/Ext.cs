using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using iSukces.Code;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public static class Ext
    {
        public static CsMethod AddOperator(this CsClass cl, string operatorName, params string[] args)
        {
            var arg  = new Args(args);
            var code = arg.Create(cl.Name);
            return cl.AddMethod(operatorName, cl.Name, "implements " + operatorName + " operator")
                .WithBodyFromExpression(code);
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

        public static CsCodeWriter Create<T>([CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null
        )
        {
            var location = new SourceCodeLocation(lineNumber, memberName, filePath)
                .WithGeneratorClass(typeof(T));
            var code = new CsCodeWriter
            {
                Location = location
            };
            
            location = new SourceCodeLocation(0, memberName, filePath)
                .WithGeneratorClass(typeof(T));
            
            code.WriteLine("// generator : " + location.ToString());
            return code;
        }

        public static string CoalesceNullOrWhiteSpace(this string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a))
                return b;
            return a;
        }

        public static string AddPrefix(this string txt, string prefix)
        {
            if (string.IsNullOrWhiteSpace(txt))
                return null;
            return prefix + txt;
        }
    }
}