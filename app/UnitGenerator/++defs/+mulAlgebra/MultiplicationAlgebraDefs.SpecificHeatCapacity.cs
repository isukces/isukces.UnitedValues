using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    partial class MultiplicationAlgebraDefs
    {

        private static void Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                args.Result.Comment = args.Input.DebugIs;
                HeuristicOperatorGenerator
                    .TryCreate(args, new ClrTypesResolver(typeof(Length).Assembly));
                args.Handled = true;
            };
          
            c.WithDiv<EnergyMassDensity, DeltaKelvinTemperature, SpecificHeatCapacity>(hints);
        }
    }
}