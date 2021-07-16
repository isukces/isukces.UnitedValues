#define ADD_COMMENT
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace UnitGenerator
{
    public class OperatorCodeBuilderInput
    {
        public OperatorCodeBuilderInput(OperatorParamsBase operatorParameters)
        {
            OperatorParameters = operatorParameters;
        }

        public void AddVariable(string name, string code, [CallerLineNumber] int l = 0)
        {
            code = Replace(code);
            var v = new VarDefinition(name, code);
            Vars.Add(v);
        }

        public void AddVariable<T>(string name, params string[] a)
        {
            a = a.Select(Replace).ToArray();
            var code = new CsArguments(a).Create<T>();
            AddVariable(name, code);
        }


        public void ConvertRight<T>(params string[] a)
        {
            var type = new CsArguments(a).Create<T>();
            ConvertRight(type);
        }

        public void ConvertRight(string targetType)
        {
            RightValue = $"{OperatorParameters.RightMethodArgumentName}.ConvertTo({targetType})";
        }
        
 

        public void ConvertRight_FromLeftUnit(string propertyOfUnit)
        {
            var targetType = $"{OperatorParameters.LeftMethodArgumentName}.Unit{propertyOfUnit}";
            ConvertRight(targetType);
        }

        public string Replace(string code)
        {
            return ReplaceRegex.Replace(code, m =>
            {
                switch (m.Groups[1].Value)
                {
                    case "left": return OperatorParameters.LeftMethodArgumentName;
                    case "right": return OperatorParameters.RightMethodArgumentName;
                    default:
                        throw new NotSupportedException();
                }
            });
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void SetComment([CallerLineNumberAttribute] int line = 0, [CallerMemberName] string method = null)
        {
#if ADD_COMMENT
            Comment = "hint location " + method + ", line " + line;
#endif
        }
        
        

        public void SetThrow([CallerMemberName] string member = null)
        {
            Throw   = true;
            Comment = "Fill method " + member;
        }

        public void WithResultUnit<T>(params string[] a)
        {
            a          = a.Select(Replace).ToArray();
            ResultUnit = new CsArguments(a).Create<T>();
        }

        public string ResultUnit { get; set; }

        public string             RightValue         { get; set; }
        public OperatorParamsBase OperatorParameters { get; }

        public List<VarDefinition> Vars { get; } = new List<VarDefinition>();

        public string Comment              { get; set; }
        public bool   Throw                { get; set; }
        public string ResultMultiplication { get; set; }

        public string UseValueExpression { get; set; }

        public string UseReturnExpression { get; set; }

        private static readonly Regex ReplaceRegex =
            new Regex(ReplaceFilter, RegexOptions.Multiline | RegexOptions.Compiled);

        private const string ReplaceFilter = @"\$\(([a-z]+)\)";

        public class VarDefinition
        {
            public VarDefinition(string name, string code)
            {
                Name = name;
                Code = code;
            }

            public override string ToString()
            {
                return $"Name={Name}, Code={Code}";
            }

            public string Name { get; }

            public string Code { get; }
        }
    }
}