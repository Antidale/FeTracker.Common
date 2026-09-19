using System.Text.Json.Serialization;
using FeTracker.Sni.Converters;

namespace FeTracker.Sni.Models;

public class SeedMetadata
{
    [JsonPropertyName("version")]
    public string Version { get; set; } = string.Empty;

    [JsonPropertyName("flags")]
    public string Flags { get; set; } = string.Empty;

    [JsonPropertyName("binary_flags")]
    public string BinaryFlags { get; set; } = string.Empty;

    [JsonPropertyName("seed")]
    public string Seed { get; set; } = string.Empty;

    [JsonPropertyName("objectives")]
    [JsonConverter(typeof(ForceStringConverter))]
    public string Objectives { get; set; } = string.Empty;
}
