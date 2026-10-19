using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FeTracker.Common.Models;

namespace FeTracker.Sni.Converters;

public class FeVersionConverter : JsonConverter<FeVersion>
{
    public override FeVersion? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDoc = JsonDocument.ParseValue(ref reader);
        var strValue = jsonDoc.RootElement.Deserialize<string?>();
        return string.IsNullOrWhiteSpace(strValue)
            ? new FeVersion("")
            : new FeVersion(strValue);
    }

    public override void Write(Utf8JsonWriter writer, FeVersion value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
