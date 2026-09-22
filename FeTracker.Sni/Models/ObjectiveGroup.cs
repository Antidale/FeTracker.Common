using System.Text.Json.Serialization;
using FeTracker.Common.Interfaces;
using FeTracker.Sni.Converters;

namespace FeTracker.Sni.Models;

public class ObjectiveGroup
{
    [JsonPropertyName("key")]
    public string Key { get; set; } = string.Empty;
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("tasks")]
    [JsonConverter(typeof(V5ObjectiveConverter))]
    public List<IObjective> Tasks { get; set; } = [];
    [JsonPropertyName("rewards")]
    public List<ObjectiveReward> Rewards { get; set; } = [];
}
