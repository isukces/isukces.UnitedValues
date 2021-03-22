using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using iSukces.Code;
using iSukces.Code.CodeWrite;
using iSukces.Code.Interfaces;

namespace UnitGenerator
{
    public class MultiplyAlgebraGenerator
    {
        public MultiplyAlgebraGenerator(string nameSpace)
        {
            _nameSpace = nameSpace;
        }

        private static CsCodeWriter CreateCodeForFractionalResult(OperatorParams p)
        {
            var cw = Ext.Create<MultiplyAlgebraGenerator>();
            cw.WriteLine("// scenario E");
            var args = new[]
            {
                $"{p.LeftName}.Value {p.Oper} {p.RightName}.Value",
                $"{p.LeftName}.Unit",
                $"{p.RightName}.Unit"
            };
            var args2   = string.Join(", ", args);
            var tResult = p.Result.Value;

            var expression = $"new {tResult}({args2})";
            cw.WriteLine($"return {expression};");
            return cw;
        }

        private static CsCodeWriter CreateCodeForLeftFractionValue(OperatorParams p)
        {
            var tResult = p.Result.Value;
            var cw      = Ext.Create<MultiplyAlgebraGenerator>();
            cw.WriteLine(
                $"// {p.Right.Value.ToLower()} unit will be taken from denominator of {p.Left.Value.ToLower()} unit");
            cw.WriteLine("// scenario D");
            cw.WriteLine("var {1}Converted = {1}.ConvertTo({0}.Unit.DenominatorUnit);", p.LeftName, p.RightName);
            cw.WriteLine("var value = {1}Converted.Value * {0}.Value;", p.LeftName, p.RightName);
            cw.WriteLine("return new {2}(value, {0}.Unit.CounterUnit);", p.LeftName, p.RightName, tResult);
            return cw;
        }


        private static CsCodeWriter CreateCodeForRelatedUnits(OperatorParams p, ref string rightUnit,
            ref string resultUnit)
        {
            var tLeftUnit   = p.Left.Unit;
            var tRightUnit  = p.Right.Unit;
            var tResultUnit = p.Result.Unit;
            var tResult     = p.Result.Value;

            var cw = Ext.Create<MultiplyAlgebraGenerator>();
            cw.WriteLine("// scenario C");

            void Add(string srcUnit, string targetUnit, string variable)
            {
                var line1 =
                    $"var {variable} = GlobalUnitRegistry.Relations.GetOrThrow<{srcUnit}, {targetUnit}>({p.LeftName}.Unit);";
                cw.WriteLine(line1);
            }

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

            cw.WriteLine($"var {p.RightName}Converted = {p.RightName}.ConvertTo({rightUnit});");
            cw.WriteLine($"var value = {p.LeftName}.Value {p.Oper} {p.RightName}Converted.Value;");
            cw.WriteLine($"return new {tResult}(value, {resultUnit});");
            return cw;
        }

        private static CsCodeWriter CreateCodeForRightFractionValue(FractionUnitInfo rightFraction, OperatorParams p)
        {
            var cw = Ext.Create<MultiplyAlgebraGenerator>();
            Debug.WriteLine(rightFraction);
            var isCnt    = rightFraction.CounterUnit == p.Left;
            var isResult = rightFraction.CounterUnit == p.Result;
            if (!(isCnt ^ isResult))
                throw new NotImplementedException();
            if (isCnt)
            {
                cw.WriteLine("// scenario A");
                cw.WriteLine(
                    $"// {p.Right.Value.ToLower()} unit will be synchronized with {p.Left.Value.ToLower()} unit");
                cw.WriteLine("var unit = new {2}({0}.Unit, {1}.Unit.DenominatorUnit);",
                    p.LeftName,
                    p.RightName,
                    p.Right.Unit);
                cw.WriteLine("var {1}Converted    = {1}.WithCounterUnit({0}.Unit);", p.LeftName, p.RightName);
                cw.WriteLine("var value = {0}.Value / {1}Converted.Value;", p.LeftName, p.RightName);
                cw.WriteLine("return new {0}(value, {1}.Unit.DenominatorUnit);", p.Result.Value, p.RightName);
            }
            else
            {
                cw.WriteLine("// scenario B");
                cw.WriteLine("var unit = new {2}({1}.Unit.CounterUnit, {0}.Unit);",
                    p.LeftName,
                    p.RightName,
                    p.Right.Unit);
                cw.WriteLine("var {1}Converted    = {1}.WithDenominatorUnit({0}.Unit);", p.LeftName, p.RightName);
                cw.WriteLine("var value = {0}.Value / {1}Converted.Value;", p.LeftName, p.RightName);
                cw.WriteLine("return new {0}(value, {1}.Unit.CounterUnit);", p.Result.Value, p.RightName);
            }

            return cw;
        }

        public void Save(string path)
        {
            foreach (var i in _clases.Values)
            {
                var fi = Path.Combine(path, i.Cl.Name + ".auto.cs");
                i.File.SaveIfDifferent(fi);
            }
        }

        internal void CreateOperators(MultiplicationAlgebraConfig c)
        {
            foreach (var i in c.Items)
            {
                CreateOperator(i.Counter, i.Denominator, i.Result, "/", i.AreRelatedUnits);
                CreateOperator(i.Counter, i.Result, i.Denominator, "/", i.AreRelatedUnits);
                CreateOperator(i.Denominator, i.Result, i.Counter, "*", i.AreRelatedUnits);
                CreateOperator(i.Result, i.Denominator, i.Counter, "*", i.AreRelatedUnits);
            }
        }

        private void CreateOperator(TypesGoup left, TypesGoup right, TypesGoup result, string op, bool areRelatedUnits)
        {
            var operatorGenerationKey = new OperatorGenerationKey(left.Value, right.Value, op);

            var tResult = result.Value;

            if (_done.TryGetValue(operatorGenerationKey, out var resultType))
            {
                if (resultType != tResult)
                    throw new NotSupportedException();
                return;
            }

            _done[operatorGenerationKey] = tResult;

            var info = op == "/" ? OperatorInfo.Div : OperatorInfo.Mul;

            var leftName  = info.Left.Name;
            var rightName = info.Right.Name;

            var cl = GetClass(operatorGenerationKey.Left);
            cl.Kind = CsNamespaceMemberKind.Struct;

            // cw.WriteLine("// " + key + " " + areRelatedUnits);

            var rightFraction = FractionUnitGeneratorRunner.IsFraction(right);
            var leftFraction  = FractionUnitGeneratorRunner.IsFraction(left);

            var rightUnit  = "rightUnit";
            var resultUnit = "resultUnit";

            CsCodeWriter PrepareCode()
            {
                var ppp = new OperatorParams(left, right, result, leftName, rightName, op);
                if (areRelatedUnits)
                    return CreateCodeForRelatedUnits(ppp, ref rightUnit, ref resultUnit);
                if (leftFraction != null)
                {
                    if (rightFraction != null)
                        throw new NotSupportedException();
                    return CreateCodeForLeftFractionValue(ppp);
                }

                if (rightFraction != null)
                    return CreateCodeForRightFractionValue(rightFraction, ppp);

                return CreateCodeForFractionalResult(ppp);
            }

            var cw1 = PrepareCode();

            var method = cl.AddMethod(op, tResult, info.Description)
                .WithBody(cw1);

            var p = method.AddParam(leftName, left.Value);
            p.Description = info.Left.Desctiption;
            p             = method.AddParam(rightName, right.Value);
            p.Description = info.Right.Desctiption;
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

        private readonly string _nameSpace;

        private readonly Dictionary<OperatorGenerationKey, string> _done =
            new Dictionary<OperatorGenerationKey, string>();

        private readonly Dictionary<string, FileHolder> _clases = new Dictionary<string, FileHolder>();
    }
}