using System;
using System.Globalization;
using Newtonsoft.Json;

namespace iSukces.UnitedValues
{
    public abstract class AbstractUnitJsonConverter<T, TUnit> : JsonConverter
        where T : struct, IUnitedValue<TUnit>
        where TUnit : IEquatable<TUnit>, IUnit
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(T);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            switch (reader.Value)
            {
                case string value:
                    return Parse(value);
                case long value:
                    return Make(value, null);
                case double value:
                    return Make((decimal)value, null);
                case null when objectType == typeof(T?):
                    return null;
                case null:
                    throw new Exception("Unable to convert NULL into Length");
                default:
                    throw new NotImplementedException();
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var tValue      = (T)value;
            var value2 = tValue.Value.ToString(CultureInfo.InvariantCulture) + tValue.Unit.UnitName;
            writer.WriteValue(value2);
        }

        protected abstract T Make(decimal value, string unit);

        protected abstract T Parse(string txt);
    }
}