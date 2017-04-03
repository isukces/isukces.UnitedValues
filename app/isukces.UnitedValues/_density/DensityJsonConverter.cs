using System;
using Newtonsoft.Json;

namespace isukces.UnitedValues
{
    public class DensityJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
            =>
                objectType == typeof(Density) || objectType == typeof(PlanarDensity) ||
                objectType == typeof(LinearDensity);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.ValueType == typeof(string))
            {
                if (objectType == typeof(Density))
                    return Density.Parse((string)reader.Value);
                if (objectType == typeof(PlanarDensity))
                    return PlanarDensity.Parse((string)reader.Value);
                if (objectType == typeof(LinearDensity))
                    return LinearDensity.Parse((string)reader.Value);
            }

            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null)
                writer.WriteValue(value.ToString());
            else
                writer.WriteNull();
        }
    }
}