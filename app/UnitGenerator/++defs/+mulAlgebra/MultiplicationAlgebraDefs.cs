using System;
using System.Diagnostics;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public partial class MultiplicationAlgebraDefs
    {
        private static void Add1(OperatorCodeBuilderInput result, string name)
        {
            var l = result.OperatorParameters.LeftMethodArgumentName;
            var r = result.OperatorParameters.RightMethodArgumentName;
            result.AddVariable(l + "Value", l + ".GetBaseUnitValue()");
            result.AddVariable(r + "Value", r + ".GetBaseUnitValue()");
            result.AddVariable(name, $"{l}Value {result.OperatorParameters.Oper} {r}Value");
        }

        private static OperatorHints GetBasicOperatorHints()
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += (sender, args) =>
            {
                args.Result.Comment = args.Input.DebugIs;
                Debug.WriteLine("Processing " + args.Input.DebugIs);
                CreateHeuristicCode(args);
                args.Handled = true;
            };
            return hints;
        }

        public static MultiplicationAlgebra Definition
        {
            get
            {
                var hints = GetBasicOperatorHints();

                var c = new MultiplicationAlgebra()
                    .WithMul<Length, Length, Area>(true)
                    .WithMul<Length, Area, Volume>(true)
                    .WithDiv<Mass, Length, LinearDensity>(hints)
                    .WithDiv<Mass, Area, PlanarDensity>(hints)
                    .WithDiv<Mass, Volume, Density>(hints);

                c.WithDiv<LinearDensity, Length, PlanarDensity>(hints);
                c.WithDiv<LinearDensity, Area, Density>(hints);
                c.WithDiv<PlanarDensity, Length, Density>(hints);

                Add_EnergyMassDensity_DeltaKelvinTemperature_SpecificHeatCapacity(c);

                c.WithDiv<Force, Area, Pressure>();
                c.WithDiv<Force, Length, LinearForce>();

                {
                    var hints2 = new OperatorHints();
                    hints2.CreateOperatorCode += (sender, args) =>
                    {
                        args.Handled = true;
                        var input  = args.Input;
                        var result = args.Result;
                        result.Comment = args.Input.DebugIs;

                        if (input.Is<Energy, Power, Time>("/"))
                        {
                            // result.AddVariable("x", "1");
#if true
                            Add1(result, "timeSeconds");
                            /*
                            result.AddVariable("energyValue", "energy.GetBaseUnitValue()");
                            result.AddVariable("powerValue", "power.GetBaseUnitValue()");
                            result.AddVariable("timeSeconds", "energyValue / powerValue");
                            */
                            result.AddVariable("returnType", "energy.Unit.GetSuggestedTimeUnit()");
                            result.AddVariable("time", "Time.FromSecond(timeSeconds).ConvertTo(returnType)");
                            result.UseReturnExpression = "time";
                            return;
#else
                            CreateHeuristicCode(args);
                            return;

#endif
                        }

                        if (input.Is<Energy, Time, Power>("/"))
                        {
                            //result.AddVariable("x", "2");
                            //result.ConvertRight("TimeUnits.Second");
                            CreateHeuristicCode(args);
                            return;
                        }

                        if (input.Is<Time, Power, Energy>("*"))
                        {
                            //result.AddVariable("x", "3");
                            Add1(result, "basicEnergy");
                            result.UseValueExpression = "basicEnergy";
                            result.ResultUnit         = "EnergyUnits.Joule";
                            return;
                        }

                        if (input.Is<Power, Time, Energy>("*"))
                        {
                            result.AddVariable("x", "4");
                            Add1(result, "basicEnergy");
                            result.UseValueExpression = "basicEnergy";
                            result.ResultUnit         = "EnergyUnits.Joule";
                            return;
                        }

                        result.SetThrow();
                    };
                    c.WithDiv<Energy, Time, Power>(hints2);
                }
                {
                    var hints2 = new OperatorHints();
                    hints2.CreateOperatorCode += (sender, args) =>
                    {
                        args.Result.Comment = args.Input.DebugIs;
                        var input = args.Input;
                        Console.WriteLine(input.DebugIs);
                        args.Handled = true;
                        var result = args.Result;
                        if (input.Is<Power, EnergyMassDensity, MassStream>("/"))
                        {
                            result.AddVariable("ru", "$(right).Unit");
                            result.AddVariable<Energy>("energy", "$(right).Value", "ru.CounterUnit");
                            result.AddVariable("time", "energy / power");
                            result.WithResultUnit<MassStreamUnit>("ru.DenominatorUnit", "time.Unit");
                            result.UseValueExpression = "1 / time.Value";
                            return;
                        }

                        result.SetThrow();

                        /*args.Result.Comment = args.Input.DebugIs;
                        HeuristicOperatorGenerator
                            .TryCreate(args, new ClrTypesResolver(typeof(Length).Assembly));
                        */

                        result.SetThrow();
                    };
                    c.WithDiv<Power, EnergyMassDensity, MassStream>(hints2);
                }
                return c;
            }
        }
    }
}

/*
 *
                 if (args.Input.Is<Length, PlanarDensity, LinearDensity>("*"))
                    Debug.Write("");
                if (args.Input.Is<LinearDensity, PlanarDensity, Length>("/"))
                    Debug.Write("");* 
 */