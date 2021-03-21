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
            if (reader.Value is string)
                return Parse((string)reader.Value);
            if (reader.Value is long)
                return Make((long)reader.Value, null);
            if (reader.Value is double)
                return Make((decimal)(double)reader.Value, null);
            if (reader.Value == null)
            {
                if (objectType == typeof(T?))
                    return null;
                throw new Exception("Unable to convert NULL into Length");
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var a = (T)value;
            var value2 = a.Value.ToString(CultureInfo.InvariantCulture) + a.Unit.UnitName;
            writer.WriteValue(value2);
        }

        protected abstract T Make(decimal value, string unit);

        protected abstract T Parse(string txt);
    }
}