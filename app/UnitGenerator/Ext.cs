using System;
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
        public static CsMethod AddOperator(this CsClass cl, string operatorName, Args arg, string resultType = null)
        {
            resultType = resultType.CoalesceNullOrWhiteSpace(cl.Name);
            var code = arg.Create(resultType);
            return cl.AddMethod(operatorName, resultType, "implements " + operatorName + " operator")
                .WithBodyFromExpression(code);
        }

        public static string AddPrefix(this string txt, string prefix)
        {
            if (string.IsNullOrWhiteSpace(txt))
                return null;
            return prefix + txt;
        }

        public static string CoalesceNullOrWhiteSpace(this string a, string b)
        {
            if (string.IsNullOrWhiteSpace(a))
                return b;
            return a;
        }


        public static CsCodeWriter Create(Type callerType, [CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null
        )
        {
            var location = new SourceCodeLocation(lineNumber, memberName, filePath)
                .WithGeneratorClass(callerType);
            var code = new CsCodeWriter
            {
                Location = location
            };

            location = new SourceCodeLocation(0, memberName, filePath)
                .WithGeneratorClass(callerType);

            code.WriteLine("// generator : " + location);
            return code;
        }

        public static CsCodeWriter Create<T>([CallerLineNumber] int lineNumber = 0,
            [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null
        )
        {
            return Create(typeof(T), lineNumber, memberName, filePath);
        }

        public static string CsEncode(this decimal multiplicator)
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

        public static CsCodeWriter WithThrowNotImplementedException(this CsCodeWriter cw)
        {
            const string code = @"throw new NotImplementedException(""Not implemented yet"");";
            cw.WriteLine(code);
            return cw;
        }

        public static CodeWriter WriteAssign(this CodeWriter cw, string variable, string value, bool addVar=false)
        {
            var code= (addVar?"var ":"")+variable + " = " + value + ";";
            cw.WriteLine(code);
            return cw;
        }
        
        public static CodeWriter WriteReturn(this CodeWriter cw, string code)
        {
            cw.WriteLine($"return {code};");
            return cw;
        }
    }
}