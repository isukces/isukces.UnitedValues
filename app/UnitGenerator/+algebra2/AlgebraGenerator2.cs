using System;
using System.Collections.Generic;
using System.IO;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;
using iSukces.UnitedValues;
using Self = UnitGenerator.AlgebraGenerator2;

namespace UnitGenerator
{
    public class AlgebraGenerator2
    {
    }

    public class AlgebraGenerator2Runner
    {
        public AlgebraGenerator2Runner(string nameSpace)
        {
            _nameSpace = nameSpace;
        }

        public static void Run(string basePath, string nameSpace)
        {
            var tmp = new AlgebraGenerator2Runner(nameSpace);
            var c = new MultiplicationAlgebraConfig()
                .WithMul<Length, Length, Area>()
                .WithMul<Length, Area, Volume>();

            tmp.CreateOperators(c);
            var path = Path.Combine(basePath, "+mulAlgebra");
            tmp.Save(path);
        }

        private void CreateOperator(TypesGoup left, TypesGoup right, TypesGoup result, string op)
        {
            var key = new OperatorGenerationKey(left.Value, right.Value, op);

            var tResult     = result.Value;
            var tLeftUnit   = left.Unit;
            var tRightUnit  = right.Unit;
            var tResultUnit = result.Unit;

            if (_done.TryGetValue(key, out var resultType))
            {
                if (resultType != tResult)
                    throw new NotSupportedException();
                return;
            }

            _done[key] = tResult;

            var info = op == "/" ? OperatorInfo.Div : OperatorInfo.Mul;

            var leftName  = info.Left.Name;
            var rightName = info.Right.Name;

            var cl = GetClass(key.Left);
            cl.Kind = CsNamespaceMemberKind.Struct;

            var cw = CsCodeWriter.Create<Self>();

            void Add(string srcUnit, string targetUnit, string variable)
            {
                var line1 =
                    $"var {variable} = GlobalUnitRegistry.Relations.Get<{srcUnit}, {targetUnit}>({leftName}.Unit);";
                var throwCode = "throw new Exception($\"Unable to convert {" + rightName + ".Unit} into {typeof(" +
                                targetUnit +
                                ")}\");";

                cw.WriteLine(line1);
                cw.SingleLineIf($"{variable} is null", throwCode);
            }

            var rightUnit  = "rightUnit";
            var resultUnit = "resultUnit";
            if (tRightUnit == tResultUnit)
            {
                rightUnit = resultUnit = "newUnit";
                Add(tLeftUnit, tResultUnit, resultUnit);
            }
            else
            {
                Add(tLeftUnit, tRightUnit, rightUnit);
                Add(tLeftUnit, tResultUnit, resultUnit);
            }

            cw.WriteLine($"var {rightName}Converted = {rightName}.ConvertTo({rightUnit}.Item1);");
            cw.WriteLine($"var value          = {leftName}.Value {op} {rightName}Converted.Value;");
            cw.WriteLine($"return new {tResult}(value, {resultUnit}.Item1);");

            var method = cl.AddMethod(op, tResult, info.Description)
                .WithBody(cw);

            var p = method.AddParam(leftName, left.Value);
            p.Description = info.Left.Desctiption;
            p             = method.AddParam(rightName, right.Value);
            p.Description = info.Right.Desctiption;
        }

        private void CreateOperators(MultiplicationAlgebraConfig c)
        {
            foreach (var i in c.Items)
            {
                CreateOperator(i.Counter, i.Denominator, i.Result, "/");
                CreateOperator(i.Counter, i.Result, i.Denominator, "/");
                CreateOperator(i.Denominator, i.Result, i.Counter, "*");
                CreateOperator(i.Result, i.Denominator, i.Counter, "*");
            }
        }

        private CsClass GetClass(string name)
        {
            if (_clases.TryGetValue(name, out var info))
                return info.Cl;
            var file = new CsFile();
            file.AddImportNamespace("System");
            var ns = file.GetOrCreateNamespace(_nameSpace);
            var cl = ns.GetOrCreateClass(name);
            cl.IsPartial  = true;
            info          = new FileHolder(file, ns, cl);
            _clases[name] = info;
            return info.Cl;
        }

        private void Save(string path)
        {
            foreach (var i in _clases.Values)
            {
                var fi = Path.Combine(path, i.Cl.Name + ".auto.cs");
                i.File.SaveIfDifferent(fi);
            }
        }

        private readonly Dictionary<OperatorGenerationKey, string> _done =
            new Dictionary<OperatorGenerationKey, string>();

        private readonly Dictionary<string, FileHolder> _clases = new Dictionary<string, FileHolder>();
        private readonly string _nameSpace;
    }
}