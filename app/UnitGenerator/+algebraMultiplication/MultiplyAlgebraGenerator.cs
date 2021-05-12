using System;
using System.Collections.Generic;
using System.Diagnostics;
using iSukces.Code;
using iSukces.Code.Interfaces;
using JetBrains.Annotations;
using Self = UnitGenerator.MultiplyAlgebraGenerator;

namespace UnitGenerator
{
    public class MultiplyAlgebraGenerator : MultipleFilesGenerator
    {
        public MultiplyAlgebraGenerator(string nameSpace) : base(nameSpace)
        {
        }


        private static CsCodeWriter CreateCodeForFractionalResult(OperatorParams p)
        {
            var cw = Ext.Create<MultiplyAlgebraGenerator>();
            cw.WriteLine("// scenario E");
            var args = new CsArguments(
                $"{p.LeftMethodArgumentName}.Value {p.Oper} {p.RightMethodArgumentName}.Value",
                $"{p.LeftMethodArgumentName}.Unit",
                $"{p.RightMethodArgumentName}.Unit"
            );
            var tResult = p.Result.Value;

            var expression = args.Create(tResult.ValueTypeName);
            cw.WriteLine($"return {expression};");
            return cw;
        }

        private static CsCodeWriter CreateCodeForLeftFractionValue(OperatorParams p,
            [NotNull] FractionUnit leftFraction)
        {
            if (leftFraction == null) throw new ArgumentNullException(nameof(leftFraction));

            var cw = Ext.Create<MultiplyAlgebraGenerator>();
            cw.WriteLine("// " + p);
            var canNormal = leftFraction.DenominatorUnit.Unit == p.Right.Unit
                            && leftFraction.CounterUnit.Unit == p.Result.Unit;
            if (canNormal)
            {
                if (TryHint(p, cw))
                {
                    cw.WriteLine("// scenario D1");
                    return cw;
                }
            }
            else
            {
                if (TryHint(p, cw))
                    return cw;
                cw.WriteLine("// scenario D2");
                return cw.WithThrowNotImplementedException();
            }

            var oper     = new OperatorCodeBuilderInput(p);
            var leftUnit = p.LeftMethodArgumentName + "Unit";
            oper.ConvertRight(leftUnit + ".DenominatorUnit");
            oper.ResultUnit = leftUnit + ".CounterUnit";
            oper.AddVariable(leftUnit, p.LeftMethodArgumentName + ".Unit");
            cw.WriteLine("// scenario D3");
            var builder = new OperatorCodeBuilder(oper);
            builder.WriteCode(cw);
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

            void Add(XUnitTypeName srcUnit, XUnitTypeName targetUnit, string variable)
            {
                var line1 =
                    $"var {variable} = GlobalUnitRegistry.Relations.GetOrThrow<{srcUnit}, {targetUnit}>({p.LeftMethodArgumentName}.Unit);";
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

            cw.WriteLine(
                $"var {p.RightMethodArgumentName}Converted = {p.RightMethodArgumentName}.ConvertTo({rightUnit});");
            cw.WriteLine(
                $"var value = {p.LeftMethodArgumentName}.Value {p.Oper} {p.RightMethodArgumentName}Converted.Value;");
            cw.WriteLine($"return new {tResult}(value, {resultUnit});");
            return cw;
        }

        private static CsCodeWriter CreateCodeForRightFractionValue(FractionUnit rightFraction, OperatorParams p)
        {
            var cw = Ext.Create<MultiplyAlgebraGenerator>();
            Debug.WriteLine(rightFraction);
            var isCnt    = rightFraction.CounterUnit == p.Left;
            var isResult = rightFraction.CounterUnit == p.Result;
            if (!(isCnt ^ isResult))
            {
                if (TryHint(p, cw))
                    return cw;
                cw.WriteLine("// scenario G");
                cw.WithThrowNotImplementedException();
                return cw;
            }

            if (isCnt)
            {
                cw.WriteLine("// scenario A");
                cw.WriteLine(
                    $"// {p.Right.Value.ToLower()} unit will be synchronized with {p.Left.Value.ToLower()} unit");
                cw.WriteLine("var unit = new {2}({0}.Unit, {1}.Unit.DenominatorUnit);",
                    p.LeftMethodArgumentName,
                    p.RightMethodArgumentName,
                    p.Right.Unit);
                cw.WriteLine("var {1}Converted    = {1}.WithCounterUnit({0}.Unit);", p.LeftMethodArgumentName,
                    p.RightMethodArgumentName);
                cw.WriteLine($"var value = {{0}}.Value {p.Oper} {{1}}Converted.Value;", p.LeftMethodArgumentName,
                    p.RightMethodArgumentName);
                cw.WriteLine("return new {0}(value, {1}.Unit.DenominatorUnit);", p.Result.Value,
                    p.RightMethodArgumentName);
            }
            else
            {
                cw.WriteLine("// scenario B");
                cw.WriteLine("var unit = new {2}({1}.Unit.CounterUnit, {0}.Unit);",
                    p.LeftMethodArgumentName,
                    p.RightMethodArgumentName,
                    p.Right.Unit);
                cw.WriteLine("var {1}Converted    = {1}.WithDenominatorUnit({0}.Unit);", p.LeftMethodArgumentName,
                    p.RightMethodArgumentName);
                cw.WriteLine($"var value = {{0}}.Value {p.Oper} {{1}}Converted.Value;", p.LeftMethodArgumentName,
                    p.RightMethodArgumentName);
                cw.WriteLine("return new {0}(value, {1}.Unit.CounterUnit);", p.Result.Value, p.RightMethodArgumentName);
            }

            return cw;
        }

        private static bool TryHint(OperatorParams par, CsCodeWriter cw)
        {
            if (!(par.OperatorHints is null))
            {
                var builderInput = par.GetBuilder();
                if (!(builderInput is null))
                {
                    var builder = new OperatorCodeBuilder(builderInput);
                    cw.WriteLine("// scenario with hint");
                    builder.WriteCode(cw);
                    return true;
                }
            }

            Console.WriteLine("args.Input" + par.DebugIs);

            return false;
        }


        internal void CreateOperators(MultiplicationAlgebra c)
        {
            foreach (var i in c.Items)
                for (var e = 0; e < 4; e++)
                {
                    var el = (NullableArguments)e;
                    CreateOperator(i.Counter, i.Denominator, i.Result, "/", i.AreRelatedUnits, el, i.OperatorHints);
                    CreateOperator(i.Counter, i.Result, i.Denominator, "/", i.AreRelatedUnits, el, i.OperatorHints);
                    CreateOperator(i.Denominator, i.Result, i.Counter, "*", i.AreRelatedUnits, el, i.OperatorHints);
                    CreateOperator(i.Result, i.Denominator, i.Counter, "*", i.AreRelatedUnits, el, i.OperatorHints);
                }
        }

        private void CreateOperator(TypesGroup left, TypesGroup right, TypesGroup result, string op,
            bool areRelatedUnits, NullableArguments nullableArguments, OperatorHints operatorHints)
        {
            var leftValue  = left.Value.ValueTypeName;
            var rightValue = right.Value.ValueTypeName;
            if ((nullableArguments & NullableArguments.Left) != 0)
                leftValue += "?";
            if ((nullableArguments & NullableArguments.Right) != 0)
                rightValue += "?";

            var operatorGenerationKey = new OperatorGenerationKey(leftValue, rightValue, op);

            var tResult = result.Value;

            if (_done.TryGetValue(operatorGenerationKey, out var resultType))
            {
                if (resultType != tResult.ValueTypeName)
                    throw new NotSupportedException();
                return;
            }

            _done[operatorGenerationKey] = tResult.ValueTypeName;

            var info = op == "/" ? OperatorInfo.Div : OperatorInfo.Mul;

            var leftName  = info.Left.Name;
            var rightName = info.Right.Name;

            if (left.Value != right.Value)
            {
                leftName  = left.Value.FirstLower();
                rightName = right.Value.FirstLower();
            }

            var cl = GetClass(operatorGenerationKey.GetOperatorTargetType());
            cl.Kind = CsNamespaceMemberKind.Struct;

            // cw.WriteLine("// " + key + " " + areRelatedUnits);

            var rightFraction = FractionUnitDefs.IsFraction(right);
            var leftFraction  = FractionUnitDefs.IsFraction(left);

            var rightUnit  = "rightUnit";
            var resultUnit = "resultUnit";

            CsCodeWriter PrepareCode()
            {
                if (nullableArguments == NullableArguments.None)
                {
                    var ppp = new OperatorParams(left, right, result, leftName, rightName, op, operatorHints);
                    if (areRelatedUnits)
                        return CreateCodeForRelatedUnits(ppp, ref rightUnit, ref resultUnit);
                    if (leftFraction != null)
                    {
                        if (rightFraction == null)
                            return CreateCodeForLeftFractionValue(ppp, leftFraction);

                        {
                            var cw = Ext.Create<Self>();

                            if (TryHint(ppp, cw))
                            {
                                cw.WriteLine("// scenario F1");
                                return cw;
                            }

                            cw.WriteLine("// scenario F2");
                            cw.WithThrowNotImplementedException();
                            return cw;
                        }
                    }

                    if (rightFraction != null)
                        return CreateCodeForRightFractionValue(rightFraction, ppp);

                    {
                        var cw = Ext.Create<Self>();

                        if (TryHint(ppp, cw))
                        {
                            cw.WriteLine("// scenario F3");
                            return cw;
                        }
 
                    }
                    return CreateCodeForFractionalResult(ppp);
                }

                return NullableArgument.CreateCode(leftName, rightName, op, nullableArguments);
            }

            var cw1 = PrepareCode();

            var method = cl.AddMethod(op, tResult + (nullableArguments == NullableArguments.None ? "" : "?"),
                    info.Description)
                .WithBody(cw1);

            var p = method.AddParam(leftName, leftValue);
            p.Description = info.Left.Desctiption;
            p             = method.AddParam(rightName, rightValue);
            p.Description = info.Right.Desctiption;
        }


        private readonly Dictionary<OperatorGenerationKey, string> _done =
            new Dictionary<OperatorGenerationKey, string>();
    }
}