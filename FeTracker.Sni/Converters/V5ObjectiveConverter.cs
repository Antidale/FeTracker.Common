using System.Text.Json;
using System.Text.Json.Serialization;
using FeTracker.Common.Interfaces;
using FeTracker.Sni.Models;

namespace FeTracker.Sni.Converters;

public class V5ObjectiveConverter : JsonConverter<List<IObjective>>
{
    public override List<IObjective> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (!JsonDocument.TryParseValue(ref reader, out var objDoc))
        {
            return [];
        }

        return objDoc.RootElement.EnumerateArray().Select<JsonElement, IObjective>(x =>
        {
            if (x.ValueKind == JsonValueKind.String)
                return new TaskObjective { Objective = x.ToString() };

            if (x.TryGetProperty("group", out _))
                return x.Deserialize<GroupObjective>() ?? new GroupObjective();

            return x.Deserialize<TaskObjective>() ?? new TaskObjective();

        })?.ToList() ?? [];
    }

    public override void Write(Utf8JsonWriter writer, List<IObjective> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}