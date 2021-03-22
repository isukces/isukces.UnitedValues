using System;
using System.Collections.Generic;
using System.IO;
using iSukces.UnitedValues;

namespace UnitGenerator
{
    public class FractionUnitGeneratorRunner
    {
        public static IReadOnlyList<FractionUnitInfo> AllFractionUnits
        {
            get { return _x.Value; }
        }

        private static readonly Lazy<IReadOnlyList<FractionUnitInfo>> _x 
            = new Lazy<IReadOnlyList<FractionUnitInfo>>(Ext.GetStaticFieldsValues<FractionUnitGeneratorRunner, FractionUnitInfo>

        );
        public static void Run(string basePath, string nameSpace)
        {
            var infos     = AllFractionUnits;
            var generator = new FractionUnitGenerator(Path.Combine(basePath, "+fractionUnits"), nameSpace);
            generator.Generate(infos);
        }


        public static readonly FractionUnitInfo LinearDensity = FractionUnitInfo.Make<LinearDensity, Weight, Length>();
        public static readonly FractionUnitInfo Density = FractionUnitInfo.Make<Density, Weight, Volume>();
        public static readonly FractionUnitInfo PlanarDensity = FractionUnitInfo.Make<PlanarDensity, Weight, Area>();
        
        public static readonly FractionUnitInfo Pressure = FractionUnitInfo.Make<Pressure, Force, Area>();

        public static FractionUnitInfo IsFraction(TypesGoup right)
        {
            foreach(var i in AllFractionUnits)
                if (i.Names.Value == right.Value)
                    return i;
            return null;
        }
    }
}