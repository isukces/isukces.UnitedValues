// ReSharper disable All
// generator: MultiplyAlgebraGenerator
using System;

namespace iSukces.UnitedValues
{
    public partial struct VolumeStream
    {
        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity operator /(VolumeStream volumeStream, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCodeForLeftFractionValue
            // Velocity operator /(VolumeStream volumeStream, Area area)
            // scenario with hint
            // .Is<VolumeStream, Area, Velocity>("/")
            var volumeStreamUnit = volumeStream.Unit;
            var tmp1 = volumeStreamUnit.CounterUnit;
            var resultUnit = new VelocityUnit(tmp1.GetLengthUnit(), volumeStreamUnit.DenominatorUnit);
            var areaConverted = area.ConvertTo(tmp1.GetAreaUnit());
            var value = volumeStream.Value / areaConverted.Value;
            return new Velocity(value, resultUnit);
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area operator /(VolumeStream volumeStream, Velocity velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateOperator
            // scenario with hint
            // .Is<VolumeStream, Velocity, Area>("/")
            var volumeStreamUnit = volumeStream.Unit;
            var tmp1 = volumeStreamUnit.CounterUnit;
            var targetRightUnit = new VelocityUnit(tmp1.GetLengthUnit(), volumeStreamUnit.DenominatorUnit);
            var velocityConverted = velocity.ConvertTo(targetRightUnit);
            var value = volumeStream.Value / velocityConverted.Value;
            return new Area(value, tmp1.GetAreaUnit());
            // scenario F1
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity? operator /(VolumeStream? volumeStream, Area area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null)
                return null;
            return volumeStream.Value / area;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(VolumeStream? volumeStream, Velocity velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null)
                return null;
            return volumeStream.Value / velocity;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity? operator /(VolumeStream volumeStream, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (area is null)
                return null;
            return volumeStream / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(VolumeStream volumeStream, Velocity? velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (velocity is null)
                return null;
            return volumeStream / velocity.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="area">a divisor (denominator) - a value which dividend is divided by</param>
        public static Velocity? operator /(VolumeStream? volumeStream, Area? area)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null || area is null)
                return null;
            return volumeStream.Value / area.Value;
        }

        /// <summary>
        /// Division operation, calculates value dividend/divisor with unit that derives from dividend unit
        /// </summary>
        /// <param name="volumeStream">a dividend (counter) - a value that is being divided</param>
        /// <param name="velocity">a divisor (denominator) - a value which dividend is divided by</param>
        public static Area? operator /(VolumeStream? volumeStream, Velocity? velocity)
        {
            // generator : MultiplyAlgebraGenerator.CreateCode
            if (volumeStream is null || velocity is null)
                return null;
            return volumeStream.Value / velocity.Value;
        }

    }
}
