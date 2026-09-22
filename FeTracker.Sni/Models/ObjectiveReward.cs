using System.Text.Json.Serialization;
using FeTracker.Sni.Converters;

namespace FeTracker.Sni.Models;

public class ObjectiveReward
{
    [JsonPropertyName("req")]
    [JsonConverter(typeof(ForceStringConverter))]
    public string Req { get; set; } = string.Empty;
    [JsonPropertyName("reward")]
    public string CompletionReward { get; set; } = string.Empty;
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
}
