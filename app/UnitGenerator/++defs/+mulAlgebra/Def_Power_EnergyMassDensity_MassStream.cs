using System;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class Def_Power_EnergyMassDensity_MassStream
    {
        private static void HandleCreateOperatorCode(object sender, OperatorHints.CreateOperatorCodeEventArgs e)
        {
            if (!e.ShouldITryToCreate(nameof(Def_Power_EnergyMassDensity_MassStream)))
                return;
            var input = e.Input;
            var result = e.Result;
            if (input.Is<Power, EnergyMassDensity, MassStream>("/"))
            {
                e.SetHandled();
                result.AddVariable("ru", "$(right).Unit");
                result.AddVariable<Energy>("energy", "$(right).Value", "ru.CounterUnit");
                result.AddVariable("time", "energy / power");
                result.WithResultUnit<MassStreamUnit>("ru.DenominatorUnit", "time.Unit");
                result.UseValueExpression = "1 / time.Value";
                return;
            }

            if (input.Is<Power, MassStream, EnergyMassDensity>("/"))
            {
            }

            if (input.Is<EnergyMassDensity, MassStream, Power>("*"))
            {
            }

            if (input.Is<MassStream, EnergyMassDensity, Power>("*"))
            {
            }

            result.SetThrow();
        }

        public static void Setup(MultiplicationAlgebra c)
        {
            var hints = new OperatorHints();
            hints.ImplementingClass  =  nameof(Def_Power_EnergyMassDensity_MassStream);
            hints.CreateOperatorCode += HandleCreateOperatorCode;
            c.WithDiv<Power, EnergyMassDensity, MassStream>(hints);
        }
    }
}
