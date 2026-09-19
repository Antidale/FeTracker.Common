using System.Text.Json;
using System.Text.Json.Serialization;
using FeTracker.Common.Models;

namespace FeTracker.Sni.Converters;

public class V5ObjectiveConverter : JsonConverter<List<V5Objective>>
{
    public override List<V5Objective> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var objDoc))
        {
            return [];
        }

        return objDoc.RootElement.EnumerateArray().Select(x =>
        {
            return x.ValueKind == JsonValueKind.String
                ? new V5Objective { Objective = x.ToString() }
                : x.Deserialize<V5Objective>() ?? new V5Objective();
        })?.ToList() ?? [];
    }

    public override void Write(Utf8JsonWriter writer, List<V5Objective> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}