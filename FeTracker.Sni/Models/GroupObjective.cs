using System.Text.Json.Serialization;
using FeTracker.Sni.Converters;

namespace FeTracker.Sni.Models;

public class GroupObjective : ObjectiveBase
{
    [JsonPropertyName("group")]
    public string Group { get; set; } = string.Empty;

    [JsonPropertyName("req")]
    [JsonConverter(typeof(ForceStringConverter))]
    public string Req { get; set; } = string.Empty;

    public override string Objective { get => Group; set => Group = value; }
    public override string Threshold { get => Req; set => Req = value; }

}
