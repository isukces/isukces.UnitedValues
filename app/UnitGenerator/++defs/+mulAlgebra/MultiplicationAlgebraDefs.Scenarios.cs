using iSukces.Code;

namespace UnitGenerator;

partial class MultiplicationAlgebraDefs
{
    private static void Scenario_Mul_Basic_Fract<THigh, TResult>(
        OperatorCodeBuilderInput input,
        string rightDenominator,
        XValueTypeName? resultDenominator)
    {
        var v1 = resultDenominator?.FirstLower() + "Unit";
        var v2 = rightDenominator.FirstLower() + "Unit";
        input.AddVariable("rightArgumentUnit", "$(right).Unit");
        if (resultDenominator == input.OperatorParameters.Left.Value)
            v1 = input.Replace("$(left).Unit");
        else
            input.AddVariable(v1, "$(left).Unit.Get" + resultDenominator + "Unit()");

        input.AddVariable(v2, "$(left).Unit.Get" + rightDenominator + "Unit()");
        input.AddVariable<THigh>("x3", "rightArgumentUnit.CounterUnit", v2);
        input.ConvertRight("x3");
        input.WithResultUnit<TResult>("rightArgumentUnit.CounterUnit", v1);
    }

    private static void Scenario_Mul_Fract_Basic<T>(OperatorCodeBuilderInput input, string right,
        string resultDenominator)
    {
        var resultDenominatorUnit = resultDenominator.FirstLower() + "Unit";
        var rUnit                 = right.FirstLower() + "Unit";
        input.AddVariable(resultDenominatorUnit, "$(left).Unit.DenominatorUnit.Get" + resultDenominator + "Unit()");
        if (right != resultDenominator)
            input.AddVariable(rUnit, "$(left).Unit.DenominatorUnit.Get" + right + "Unit()");
        input.WithResultUnit<T>("$(left).Unit.CounterUnit", resultDenominatorUnit);
        input.ConvertRight(rUnit);
    }
}
