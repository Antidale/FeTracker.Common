using System.Text.Json.Serialization;
using FeTracker.Common.Interfaces;
using FeTracker.Sni.Converters;

namespace FeTracker.Sni.Models;

public abstract class ObjectiveBase : IObjective
{
    [JsonPropertyName("objective")]
    public virtual string Objective { get; set; } = string.Empty;
    [JsonPropertyName("threshold")]
    [JsonConverter(typeof(ForceStringConverter))]
    public virtual string Threshold { get; set; } = "0";
}
