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
                /*if (args.Input.Is<PlanarDensity, Length, LinearDensity>("*"))
                {
                    var cc = args.Result;
                    cc.SetComment();
                    Scenario_Mul_Fract_Basic<LinearDensityUnit>(cc, nameof(Length), nameof(Length));
                    args.Handled = true;
                    return;
                }

                if (args.Input.Is<Length, PlanarDensity, LinearDensity>("*"))
                {
                    var cc = args.Result;
                    cc.SetComment();
                    Scenario_Mul_Basic_Fract<PlanarDensityUnit, LinearDensityUnit>(
                        cc, 
                        nameof(Area),
                        new XValueTypeName(nameof(Length)));
                    args.Handled = true;
                    return;
                }

                if (args.Input.Is<LinearDensity, Length, PlanarDensity>("/"))
                {
                    var cc = args.Result;
                    cc.SetComment();
                    cc.AddVariable("lu", "$(left).Unit");
                    cc.AddVariable("areaUnit", "lu.DenominatorUnit.GetAreaUnit()");
                    cc.ConvertRight("lu.DenominatorUnit");
                    cc.WithResultUnit<PlanarDensityUnit>("lu.CounterUnit", "areaUnit");
                    args.Handled = true;
                    return;
                }

                if (args.Input.Is<LinearDensity, PlanarDensity, Length>("/"))
                {
                    var cc = args.Result;
                    cc.SetComment();
                    cc.AddVariable("lu", "$(left).Unit");
                    cc.AddVariable("areaUnit", "lu.DenominatorUnit.GetAreaUnit()");
                    cc.AddVariable("x", new Args("lu.CounterUnit", "areaUnit").Create<PlanarDensityUnit>());
                    cc.ConvertRight("x");
                    cc.ResultUnit = "lu.DenominatorUnit";
                    args.Handled  = true;
                    return;
                }*/
                if (args.Input.Is<EnergyMassDensity, DeltaKelvinTemperature, SpecificHeatCapacity>("/")) {
                  
                    var cc = args.Result;
                    cc.SetThrow();
                    /*
                    cc.SetComment();

                    cc.AddVariable("lu", "$(left).Unit");
                    cc.AddVariable("temperatureUnit", "new KelvinTemperatureUnit(null)");
                    cc.AddVariable("u2", "new MassDetlaKelvinUnit(lu.DenominatorUnit, $(right).Unit)");
                    cc.WithResultUnit<SpecificHeatCapacityUnit>("lu.CounterUnit", "u2");
                    */
                    args.Handled = true;
                    return;
                }

                if (args.Input.Is<EnergyMassDensity, SpecificHeatCapacity, DeltaKelvinTemperature>("/"))
                {
                    var cc = args.Result;
                    cc.SetComment();
                    cc.SetThrow();
                    /*
                    cc.AddVariable("lu", "$(left).Unit");
                    cc.AddVariable("ru", "$(right).Unit");
                    cc.AddVariable("rud", "ru.DenominatorUnit");

                    cc.AddVariable("tmp", new Args("lu.DenominatorUnit", "rud.RightUnit").Create<MassDetlaKelvinUnit>());
                    cc.AddVariable("rightConvertedUnit", new Args("lu.CounterUnit", "tmp").Create<SpecificHeatCapacityUnit>());
                    cc.ConvertRight("rightConvertedUnit");
                    cc.ResultUnit = "ru.DenominatorUnit.RightUnit";
                    */
                    args.Handled = true;
                    
                    return;
                }

                if (args.Input.Is<SpecificHeatCapacity, DeltaKelvinTemperature, EnergyMassDensity>("*"))
                {
                    var cc = args.Result;
                    cc.SetComment();
                    cc.AddVariable("lu", "$(left).Unit");
                    cc.AddVariable("ru", "$(right).Unit");
                    cc.AddVariable("lDenominatorUnit", "lu.DenominatorUnit");
                    cc.ConvertRight("lDenominatorUnit.RightUnit");
                    cc.WithResultUnit<EnergyMassDensityUnit>("lu.CounterUnit", "lDenominatorUnit.LeftUnit");
                    args.Handled  = true;

                    cc.SetThrow();
                    return;
                }
                if (args.Input.Is<DeltaKelvinTemperature, SpecificHeatCapacity, EnergyMassDensity>("*")) {
                  
                    var cc = args.Result;
                    cc.SetComment();
                    cc.AddVariable("ru", "$(right).Unit");
                    cc.AddVariable("rCounterUnit", "ru.CounterUnit");
                    cc.AddVariable("lu", "$(left).Unit");
                    cc.AddVariable("tmp", new Args("ru.DenominatorUnit.LeftUnit", "lu").Create<MassDetlaKelvinUnit>());
                    cc.WithResultUnit<EnergyMassDensityUnit>("rCounterUnit", "ru.DenominatorUnit.LeftUnit");
                    cc.ConvertRight<SpecificHeatCapacityUnit>("rCounterUnit", "tmp");
                    args.Handled = true;
                    return;
                }

                Console.WriteLine("args.Input" + args.Input.DebugIs);
                {
                    var cc = args.Result;
                    args.Handled = true;
                    cc.SetThrow();
                }
                // throw new NotSupportedException("args.Input" + args.Input.DebugIs);
            };
          
            c.WithDiv<EnergyMassDensity, DeltaKelvinTemperature, SpecificHeatCapacity>(hints);
        }
    }
}