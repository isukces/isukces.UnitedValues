using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    partial class MultiplicationAlgebraDefs
    {
        private static void Add_Length_PlanarDensity_LinearDensity(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                if (args.Input.Is<PlanarDensity, Length, LinearDensity>("*"))
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
                    Scenario_Mul_Basic_Fract<PlanarDensityUnit, LinearDensityUnit>(cc, nameof(Area),
                        nameof(Length));
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
                }

                Console.WriteLine("args.Input" + args.Input.DebugIs);
                throw new NotSupportedException("args.Input" + args.Input.DebugIs);
            };

            c.WithDiv<LinearDensity, Length, PlanarDensity>(hints);
        }

        private static void Add_LinearDensity_Area_Density(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                if (args.Input.Is<Density, Area, LinearDensity>("*"))
                {
                    var input = args.Result;
                    input.SetComment();
                    Scenario_Mul_Fract_Basic<LinearDensityUnit>(input, nameof(Area), nameof(Length));
                    args.Handled = true;
                    return;
                }

                if (args.Input.Is<Area, Density, LinearDensity>("*"))
                {
                    var input = args.Result;
                    input.SetComment();
                    Scenario_Mul_Basic_Fract<DensityUnit, LinearDensityUnit>(
                        input, nameof(Volume), nameof(Length));
                    args.Handled = true;
                    return;
                }

                Console.WriteLine("args.Input" + args.Input.DebugIs);
            };

            c.WithDiv<LinearDensity, Area, Density>(hints);
        }

        private static void Add_PlanarDensity_Length_Density(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                if (args.Input.Is<Density, Length, PlanarDensity>("*"))
                {
                    var input = args.Result;
                    input.SetComment();
                    Scenario_Mul_Fract_Basic<PlanarDensityUnit>(
                        input, nameof(Length), nameof(Area));
                    args.Handled = true;
                    return;
                }

                if (args.Input.Is<Length, Density, PlanarDensity>("*"))
                {
                    var input = args.Result;
                    input.SetComment();
                    Scenario_Mul_Basic_Fract<DensityUnit, PlanarDensityUnit>(
                        input, nameof(Volume), nameof(Area));
                    args.Handled = true;
                    return;
                }

                Console.WriteLine("args.Input" + args.Input.DebugIs);
            };

            c.WithDiv<PlanarDensity, Length, Density>(hints);
        }
    }
}