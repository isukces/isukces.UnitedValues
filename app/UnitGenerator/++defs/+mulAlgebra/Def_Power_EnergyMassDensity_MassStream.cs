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
                e.SetHandled();
                result.AddVariable("massUnit", "$(right).Unit.CounterUnit");
                result.AddVariable("leftConverted", "$(left).ConvertTo(PowerUnits.Watt)");
                result.AddVariable("rightConverted", "$(right).ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second))");
                result.WithResultUnit<EnergyMassDensityUnit>("EnergyUnits.Joule", "massUnit");
                result.UseValueExpression = "leftConverted.Value / rightConverted.Value";
                return;
            }

            if (input.Is<EnergyMassDensity, MassStream, Power>("*"))
            {
                e.SetHandled();
                result.AddVariable("massUnit", "$(right).Unit.CounterUnit");
                result.AddVariable("leftConverted", "$(left).ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit))");
                result.AddVariable("rightConverted", "$(right).ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second))");
                result.ResultUnit         = "PowerUnits.Watt";
                result.UseValueExpression = "leftConverted.Value * rightConverted.Value";
                return;
            }

            if (input.Is<MassStream, EnergyMassDensity, Power>("*"))
            {
                e.SetHandled();
                result.AddVariable("massUnit", "$(left).Unit.CounterUnit");
                result.AddVariable("leftConverted", "$(right).ConvertTo(new EnergyMassDensityUnit(EnergyUnits.Joule, massUnit))");
                result.AddVariable("rightConverted", "$(left).ConvertTo(new MassStreamUnit(massUnit, TimeUnits.Second))");
                result.ResultUnit         = "PowerUnits.Watt";
                result.UseValueExpression = "leftConverted.Value * rightConverted.Value";
                return;
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
