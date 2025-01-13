using iSukces.Code;
using iSukces.UnitedValues;
using UnitA = iSukces.UnitedValues.Power;
using UnitB = iSukces.UnitedValues.Area;
using UnitC = iSukces.UnitedValues.Irradiance;

namespace UnitGenerator;

internal sealed class Def_Power_Area_Irradiance : AlgebraDefinitionBase
{
    private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
    {
        if (!e.ShouldITryToCreate(nameof(Def_Power_Length_LinearPowerLoss)))
            return;
        e.Result.Comment = e.Input.DebugIs;
        var input  = e.Input;
        var result = e.Result;

        if (input.Is<UnitA, UnitB, UnitC>("/"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment    += " " + nameof(Def_Power_Length_LinearPowerLoss);
            result.ResultUnit =  $"new {ValueC}Unit({ValueA.FirstLower()}.Unit, {ValueB.FirstLower()}.Unit)";
            return;
        }

        if (input.Is<UnitC, UnitB, UnitA>("*"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment += " " + nameof(Def_Power_Length_LinearPowerLoss);
            result.ConvertRight($"{ValueC.FirstLower()}.Unit.DenominatorUnit");
            result.ResultUnit = $"{ValueC.FirstLower()}.Unit.CounterUnit";
        }
    }


    public static void Setup(MultiplicationAlgebra c)
    {
        var hints = new OperatorHints();
        hints.CreateOperatorCode += HandleCreateOperatorCode;
        hints.ImplementingClass  =  nameof(Def_Power_Length_LinearPowerLoss);
        c.WithDiv<UnitA, UnitB, UnitC>(hints);
    }

    private const string ValueA = nameof(Power);
    private const string ValueB = nameof(Area);
    private const string ValueC = nameof(Irradiance);
}
