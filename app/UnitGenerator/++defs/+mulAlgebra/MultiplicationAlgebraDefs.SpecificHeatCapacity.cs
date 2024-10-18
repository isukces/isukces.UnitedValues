using System;
using iSukces.UnitedValues;

namespace UnitGenerator;

partial class MultiplicationAlgebraDefs
{

    private static void Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity(MultiplicationAlgebra c)
    {
        var hints = new OperatorHints();
        hints.CreateOperatorCode += (sender, args) =>
        {
            args.Result.Comment = args.Input.DebugIs;
            AlgebraDefUtils.CreateHeuristicCode(args);
            args.SetHandled();
        };
        hints.ImplementingClass = nameof(MultiplicationAlgebraDefs); 
          
        c.WithDiv<EnergyMassDensity, DeltaKelvinTemperature, SpecificHeatCapacity>(hints);
    }
}