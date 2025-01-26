using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

public class NestedValuesConverter : JsonConverter<List<string>>
{
    public override List<string> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Überprüfen, ob das JSON ein Objekt ist
        if (reader.TokenType == JsonTokenType.StartObject)
        {
            using (var jsonDocument = JsonDocument.ParseValue(ref reader))
            {
                // Hole den Wert von $values
                if (jsonDocument.RootElement.TryGetProperty("$values", out JsonElement valuesElement) && valuesElement.ValueKind == JsonValueKind.Array)
                {
                    var result = new List<string>();
                    foreach (var item in valuesElement.EnumerateArray())
                    {
                        result.Add(item.GetString());
                    }
                    return result;
                }
            }
        }
        throw new JsonException("Expected object with $values property.");
    }

    public override void Write(Utf8JsonWriter writer, List<string> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Serialization is not implemented.");
    }
}
