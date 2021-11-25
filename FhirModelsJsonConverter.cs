using System;
using Hl7.Fhir.Model;
using Hl7.Fhir.Serialization;
using Newtonsoft.Json;

namespace FhirSwaggerExample
{
    public class FhirModelsJsonConverter : JsonConverter<Base>
    {
        public override void WriteJson(JsonWriter writer, Base value, JsonSerializer serializer)
        {
            var fhirJsonSerializer = new FhirJsonSerializer(new SerializerSettings { Pretty = true, AppendNewLine = true });
            fhirJsonSerializer.Serialize(value, writer);
        }

        public override Base ReadJson(JsonReader reader, Type objectType, Base existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var defaultSettings = new ParserSettings { PermissiveParsing = true };
            var jsonParser = new FhirJsonParser(defaultSettings);
            return jsonParser.Parse(reader);
        }
    }
}