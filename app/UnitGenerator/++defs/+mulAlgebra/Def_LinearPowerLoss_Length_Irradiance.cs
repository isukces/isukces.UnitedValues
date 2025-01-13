using iSukces.Code;
using iSukces.UnitedValues;
using UnitA = iSukces.UnitedValues.LinearPowerLoss;
using UnitB = iSukces.UnitedValues.Length;
using UnitC = iSukces.UnitedValues.Irradiance;
using UnitCUnit = iSukces.UnitedValues.IrradianceUnit;

namespace UnitGenerator;

internal sealed class Def_LinearPowerLoss_Length_Irradiance : AlgebraDefinitionBase
{
    private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
    {
        if (!e.ShouldITryToCreate(nameof(Def_LinearPowerLoss_Length_Irradiance)))
            return;
        e.Result.Comment = e.Input.DebugIs;
        var input  = e.Input;
        var result = e.Result;

        if (input.Is<UnitA, UnitB, UnitC>("/"))
        {
            e.SetHandled();
            result.SetComment();
                
            result.AddVariable("lengthUnit", "linearPowerLoss.Unit.DenominatorUnit");
            result.AddVariable("areaUnit", "lengthUnit.GetAreaUnit()");
            result.AddVariable("powerUnit", $"{ValueA.FirstLower()}.Unit.CounterUnit");
                 
            result.Comment    += " " + nameof(Def_LinearPowerLoss_Length_Irradiance);
            result.ConvertRight("lengthUnit");
            result.WithResultUnit<UnitCUnit>("powerUnit", "areaUnit");
            return;
        }
            
        if (input.Is<UnitA, UnitC, UnitB>("/"))
        {
            e.SetHandled();
            result.SetComment();
            result.AddVariable("resultUnit", "linearPowerLoss.Unit.DenominatorUnit");
            result.AddVariable("areaUnit", "resultUnit.GetAreaUnit()");
            // result.AddVariable<IrradianceUnit>("irradianceUnit", "irradiance.Unit.CounterUnit", "areaUnit");
            result.Comment += " " + nameof(Def_LinearPowerLoss_Length_Irradiance);
                
            result.ConvertRight_WithDenominatorUnit("areaUnit");
                
            result.ResultUnit =  "resultUnit";
            return;
        }

            

        if (input.Is<UnitC, UnitB, UnitA>("*"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment += " " + nameof(Def_LinearPowerLoss_Length_Irradiance);
            result.ConvertRight($"{ValueC.FirstLower()}.Unit.DenominatorUnit.GetLengthUnit()");
            result.WithResultUnit<LinearPowerLossUnit>("irradiance.Unit.CounterUnit", "lengthConverted.Unit");
        }


        if (input.Is<UnitB, UnitC, UnitA>("*"))
        {
            e.SetHandled();
            result.SetComment();
            result.Comment += " " + nameof(Def_LinearPowerLoss_Length_Irradiance);
            result.AddVariable("areaUnit", "length.Unit.GetAreaUnit()");
            result.ConvertRight_WithDenominatorUnit("areaUnit");
            result.WithResultUnit<LinearPowerLossUnit>($"{ValueC.FirstLower()}.Unit.CounterUnit", $"{ValueB.FirstLower()}.Unit");
        }
    }


    public static void Setup(MultiplicationAlgebra c)
    {
        var hints = new OperatorHints();
        hints.CreateOperatorCode += HandleCreateOperatorCode;
        hints.ImplementingClass  =  nameof(Def_LinearPowerLoss_Length_Irradiance);
        c.WithDiv<UnitA, UnitB, UnitC>(hints);
    }

    private const string ValueA = nameof(LinearPowerLoss);
    private const string ValueB = nameof(Length);
    private const string ValueC = nameof(Irradiance);
}
