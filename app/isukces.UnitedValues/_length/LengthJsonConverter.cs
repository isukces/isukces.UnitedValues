using System;
using System.Globalization;
using Newtonsoft.Json;

namespace isukces.UnitedValues
{ 
    public class LengthJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Length);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value is string)
                return Length.Parse((string)reader.Value);
            if (reader.Value is long)
                return Length.FromMeter((decimal)(long)reader.Value);
            if (reader.Value is double)
                return Length.FromMeter((decimal)(double)reader.Value);
            if (reader.Value == null)
            {
                if (objectType == typeof(Length?))
                    return null;
                throw new Exception("Unable to convert NULL into Length");
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var a = (Length)value;
            var value2 = a.Value.ToString(CultureInfo.InvariantCulture) +  a.Unit.UnitName; 
            writer.WriteValue(value2);
        }
    }
}