using System.Text.Json.Serialization;

namespace FeTracker.Common.Models;

public class V5Objective
{
    [JsonPropertyName("objective")]
    public string Objective { get; set; } = string.Empty;
    [JsonPropertyName("threshold")]
    public int Threshold { get; set; } = 0;
}
