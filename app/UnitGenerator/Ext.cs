using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using iSukces.Code;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;

namespace UnitGenerator;

public static class Ext
{
    extension(CsClass cl)
    {
        public CsMethod AddOperator(string operatorName, CsArguments csArgument, string? resultType = null)
        {
            resultType = resultType.CoalesceNullOrWhiteSpace(cl.Name.Declaration);
            var code = csArgument.Create(resultType);
            return cl.AddMethod(operatorName, (CsType)resultType, "implements " + operatorName + " operator")
                .WithBodyFromExpression(code);
        }

        public CsType GetReferenceNullableType()
        {
            var type = cl.Name;
            if (cl.Kind is CsNamespaceMemberKind.Class or CsNamespaceMemberKind.Interface or CsNamespaceMemberKind.Record)
                type.Nullable = NullableKind.ReferenceNullable;
            return type;
        }
    }

    extension(IAttributable attributable)
    {
        public void AddRelatedUnitSourceAttribute(ITypeNameResolver resolver,
            RelatedUnitSourceUsage flag, int sortOrder)
        {
            var argument = resolver.GetEnumValueCode(flag);
            var csAttribute = new CsAttribute(nameof(RelatedUnitSourceAttribute))
                .WithArgumentCode(argument);
            if (flag != RelatedUnitSourceUsage.DoNotUse)
                csAttribute.WithArgument(sortOrder);
            attributable.WithAttribute(csAttribute);
        }
    }

    extension(CsCodeWriter code)
    {
        public void CheckArgument(string argName, ArgChecking flags,
            ITypeNameResolver resolver)
        {
            if (flags == ArgChecking.None)
                return;

            var canBeNull     = true;
            var argNameToRead = argName + "?";
            if ((flags & ArgChecking.NotNull) != 0)
            {
                var throwCode = new CsArguments($"nameof({argName})")
                    .Throw<NullReferenceException>(resolver);
                code.SingleLineIf($"{argName} is null", throwCode);
                canBeNull     = false;
                argNameToRead = argName;
            }

            if ((flags & ArgChecking.TrimValue) != 0)
            {
                code.WriteLine("{0} = {1}.Trim();", argName, argNameToRead);
                flags &= ~ArgChecking.TrimValue;

                if ((flags & ArgChecking.NotWhitespace) != 0)
                {
                    flags &= ~ArgChecking.NotWhitespace;
                    flags |= ArgChecking.NotEmpty;
                }
            }

            if ((flags & ArgChecking.NotNull) != 0 && canBeNull)
            {
                flags &= ~ArgChecking.NotNull;
                //p.Attributes.Add(CsAttribute.Make<NotNullAttribute>(target));
                var throwCode = new CsArguments($"nameof({argName})")
                    .Throw<NullReferenceException>(resolver);
                code.SingleLineIf($"{argName} is null", throwCode);
            }

            if ((flags & ArgChecking.NotWhitespace) != 0)
            {
                flags &= ~(ArgChecking.NotEmpty | ArgChecking.NotWhitespace);
                // var m = nameof(string.IsNullOrWhiteSpace);
                var throwCode = Utils.ThrowArgumentException(argName, resolver); 
                code.SingleLineIf($"string.IsNullOrWhiteSpace({argName})", throwCode);

                flags &= ~(ArgChecking.NotNullOrWhitespace | ArgChecking.NotNullOrEmpty);
            }

            if ((flags & ArgChecking.NotEmpty) != 0)
            {
                flags &= ~ArgChecking.NotEmpty;
                var throwCode = Utils.ThrowArgumentException(argName, resolver);
                var condition =
                    canBeNull
                        ? $"string.IsNullOrEmpty({argName})"
                        : $"{argName}.Length == 0";

                code.SingleLineIf(condition, throwCode);
            }
        }
    }

    extension(string? a)
    {
        public string CoalesceNullOrWhiteSpace(string b)
        {
            if (string.IsNullOrWhiteSpace(a))
                return b;
            return a;
        }

        public string? AddPrefix(string prefix)
        {
            if (string.IsNullOrWhiteSpace(a))
                return null;
            return prefix + a;
        }
    }

    extension(Flags1 flags)
    {
        public ArgChecking ConvertToArgChecking()
        {
            var r = ArgChecking.None;
            if ((flags & Flags1.NotNull) != 0)
                r |= ArgChecking.NotNull;
            if ((flags & Flags1.NotEmpty) != 0)
                r |= ArgChecking.NotEmpty;
            if ((flags & Flags1.NotWhitespace) != 0)
                r |= ArgChecking.NotWhitespace;
            if ((flags & Flags1.TrimValue) != 0)
                r |= ArgChecking.TrimValue;

            return r;
        }
    }


    public static CsCodeWriter Create(Type callerType, [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string? memberName = null, [CallerFilePath] string? filePath = null
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
        [CallerMemberName] string? memberName = null, [CallerFilePath] string? filePath = null
    )
    {
        return Create(typeof(T), lineNumber, memberName, filePath);
    }

    public static string CsEncode(this decimal multiplicator)
    {
        return multiplicator.ToString(CultureInfo.InvariantCulture) + "m";
    }

    public static string CsEncode(this int multiplicator)
    {
        return multiplicator.ToString(CultureInfo.InvariantCulture);
    }

    public static string? GetPowerSuffix(int power)
    {
        switch (power)
        {
            case 1:
                return null;
            case 2:
                return AreaUnits.SquareSign;
            case 3:
                return "³";
            default:
                throw new NotSupportedException();
        }
    }

    public static TValue[] GetStaticFieldsValues<THost, TValue>()
    {
        var l            = new List<TValue>();
        var bindingFlags = BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
        foreach (var i in typeof(THost).GetFields(bindingFlags))
            if (i.FieldType == typeof(TValue))
                l.Add((TValue?)i.GetValue(null));
        return l.ToArray();
    }

    public static bool Implements<T>(this Type type)
    {
        var i = type.GetInterfaces();
        return i.Any(q => q == typeof(T));
    }

    extension(CsCodeWriter cs)
    {
        public void SingleLineIfReturn(string condition, string result)
        {
            cs.SingleLineIf(condition, "return " + result + ";");
        }

        public void Throw<T>(params string[] arguments)
        {
            var exception = new CsArguments(arguments).Create<T>();
            var code      = $"throw {exception};";
            cs.WriteLine(code);
        }
    }

    extension(CsMethod method)
    {
        public CsMethod WithBodyFromAssignment(string variable, string code)
        {
            method.Body = $"{variable} = {code};";
            return method;
        }

        public CsMethod WithBodyFromExpression(string code)
        {
            method.Body = $"return {code};";
            return method;
        }

        public CsMethod WithLeftRightArguments(CsType leftType, CsType rightType,
            string leftName = "left",
            string rightName = "right")
        {
            method.AddParam(leftName, leftType);
            method.AddParam(rightName, rightType);
            return method;
        }
    }

    public static CsCodeWriter WithThrowNotImplementedException(this CsCodeWriter cw, string? message = null)
    {
        if (string.IsNullOrEmpty(message))
            message = "Not implemented yet";
        message = message.CsEncode();
        var code = $"throw new NotImplementedException({message});";
        cw.WriteLine(code);
        return cw;
    }

    extension(CodeWriter cw)
    {
        public CodeWriter WriteAssign(string variable, string value, bool addVar = false)
        {
            var code = (addVar ? "var " : "") + variable + " = " + value + ";";
            cw.WriteLine(code);
            return cw;
        }

        public CodeWriter WriteReturn(string code)
        {
            cw.WriteLine($"return {code};");
            return cw;
        }
    }
}


[Flags]
public enum ArgChecking
{
    None,
    NotNull       = 1,
    NotEmpty      = 2,
    NotWhitespace = 4,
    TrimValue     = 8,


    NotNullOrWhitespace = NotNull | NotWhitespace,
    NotNullOrEmpty      = NotNull | NotEmpty,

    NormalizedString = NotNull | NotNullOrWhitespace | TrimValue,
}
