using System;
using System.Globalization;
using Newtonsoft.Json;

namespace isukces.UnitedValues
{
    public class WeightJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Weight);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.Value is string)
                return Weight.Parse((string)reader.Value);
            if (reader.Value is long)
                return Weight.FromKg((decimal)(long)reader.Value);
            if (reader.Value is double)
                return Weight.FromKg((decimal)(double)reader.Value);
            if (reader.Value == null)
            {
                if (objectType == typeof(Weight?))
                    return null;
                throw new Exception("Unable to convert NULL into Weight");
            }
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var a = (Weight)value;
            var value2 = a.Value.ToString(CultureInfo.InvariantCulture) + a.Unit.UnitName;
            writer.WriteValue(value2);
        }
    }
}