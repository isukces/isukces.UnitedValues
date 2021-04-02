using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class Def_Power_EnergyMassDensity_MassStream
    {
        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<Power, EnergyMassDensity, MassStream>(hints);
        }

        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            e.Result.Comment = e.Input.DebugIs;
            var input = e.Input;
            Console.WriteLine(input.DebugIs);
            e.Handled = true;
            var result = e.Result;
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
        }
    }
}