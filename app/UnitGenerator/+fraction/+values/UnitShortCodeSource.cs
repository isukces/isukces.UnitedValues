using System;
using System.Linq;
using iSukces.Code;

namespace UnitGenerator
{
    public class UnitShortCodeSource
    {
        public static UnitShortCodeSource MakeDirect(string directValue)
        {
            return new UnitShortCodeSource
            {
                _directValue = directValue
            };
        }

        public static UnitShortCodeSource MakePower(UnitShortCodeSource baseSource, int baseSourcePower)
        {
            return new UnitShortCodeSource
            {
                _baseSource      = baseSource,
                _baseSourcePower = baseSourcePower
            };
        }

        public CsArguments GetCreationArgs(RelatedUnitsFamily related)
        {
            var constructorArgument = TryGetConstructorArgumentFromPowerOneUnit(related);
            if (constructorArgument is null)
                constructorArgument = EffectiveValue.CsEncode();
            return new CsArguments(constructorArgument);
        }

        public override string ToString()
        {
            return EffectiveValue;
        }


        private string TryGetConstructorArgumentFromPowerOneUnit(RelatedUnitsFamily related)
        {
            if (_baseSource == null || _baseSourcePower < 2)
                return null;
            var unitOne = related.Other[1];
            var search  = _baseSource.EffectiveValue;
            var unitOneUnit = unitOne.Units
                .SingleOrDefault(a => a.UnitShortCode.EffectiveValue == search);

            var powerOneContainer = related.MyInfo.PowerOne.Container;
            if (unitOneUnit != null)
                return powerOneContainer.GetTypename() + "." + unitOneUnit.FieldName;
            return null;
        }

        public string EffectiveValue
        {
            get
            {
                if (_baseSourcePower > 1)
                    return _baseSource + Ext.GetPowerSuffix(_baseSourcePower);
                if (_baseSource != null)
                    return _baseSource.EffectiveValue;
                return _directValue;
            }
        }

        public UnitShortCodeSourceFlags Flags
        {
            get
            {
                var flags = UnitShortCodeSourceFlags.None;
                if (_baseSource != null)
                {
                    flags |= UnitShortCodeSourceFlags.HasBaseDefinition;
                    if (_baseSourcePower > 1)
                        flags |= UnitShortCodeSourceFlags.HasPowerHigherThanOne;
                }
                else
                {
                    flags |= UnitShortCodeSourceFlags.Direct;
                }

                return flags;
            }
        }

        public UnitShortCodeSource _baseSource;
        public int _baseSourcePower;
        private string _directValue;
    }

    [Flags]
    public enum UnitShortCodeSourceFlags
    {
        None = 0,
        Direct = 1,
        HasBaseDefinition = 2,
        HasPowerHigherThanOne = 4
    }
}