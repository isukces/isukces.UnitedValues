using iSukces.Code;
using iSukces.UnitedValues;
using ValueA = iSukces.UnitedValues.Power;
using ValueB = iSukces.UnitedValues.Length;
using ValueC = iSukces.UnitedValues.LinearPowerLoss;
using UnitC = iSukces.UnitedValues.LinearPowerLossUnit;

namespace UnitGenerator;

sealed class Def_Power_Length_LinearPowerLoss : AlgebraDefinitionBase
{
    private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
    {
        if (!e.ShouldITryToCreate(nameof(Def_Power_Length_LinearPowerLoss)))
            return;
        e.Result.Comment = e.Input.DebugIs;
        var input  = e.Input;
        var result = e.Result;

        if (input.Is<ValueA, ValueB, ValueC>("/"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment += " " + nameof(Def_Power_Length_LinearPowerLoss);
            result.WithResultUnit<UnitC>(
                $"{ValueA.FirstLower()}.Unit",
                $"{ValueB.FirstLower()}.Unit");
            return;
        }

        if (input.Is<ValueC, ValueB, ValueA>("*"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment += " " + nameof(Def_Power_Length_LinearPowerLoss);
            result.AddVariable("tmp", $"{ValueC.FirstLower()}.Unit");
            result.AddVariable("resultUnit", "tmp.CounterUnit");
            result.AddVariable("lengthUnit", "tmp.DenominatorUnit");
            result.ConvertRight("lengthUnit");
            result.ResultUnit = "resultUnit";
        }
    }


    public static void Setup(MultiplicationAlgebra c)
    {
        var hints = new OperatorHints();
        hints.CreateOperatorCode += HandleCreateOperatorCode;
        hints.ImplementingClass  =  nameof(Def_Power_Length_LinearPowerLoss);
        c.WithDiv<ValueA, ValueB, ValueC>(hints);
    }

    private const string ValueA = nameof(Power);
    private const string ValueB = nameof(Length);
    private const string ValueC = nameof(LinearPowerLoss);
}