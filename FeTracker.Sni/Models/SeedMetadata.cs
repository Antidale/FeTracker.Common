using System.Text.Json.Serialization;
using FeTracker.Sni.Converters;

namespace FeTracker.Sni.Models;

internal class SeedMetadata
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

    [JsonPropertyName("metadata_addr")]
    [JsonConverter(typeof(HexStringToUintConverter))]
    public uint MetadataAddr { get; set; } = 0;

    [JsonPropertyName("metadata_len")]
    [JsonConverter(typeof(HexStringToUintConverter))]
    public uint MetadataLen { get; set; } = 0;

    [JsonPropertyName("framework_version")]
    public string FrameworkVersion { get; set; } = string.Empty;

    public SeedDetail ToSeedDetail()
    {
        return new SeedDetail
        {
            Flags = this.Flags,
            BinaryFlags = this.BinaryFlags,
            Seed = this.Seed,
            Version = this.Version
        };
    }
}
