using System.Text.Json;
using System.Text.Json.Serialization;
using FeTracker.Sni.Converters;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.ConverterTests;

public class ForcedStringConverterTests
{

    [Fact]
    public void ConvertsIntToString()
    {
        var result = JsonSerializer.Deserialize<List<TestHelper>>(Json);

        result.Should().NotBeNull();
        result.Count.Should().Be(2);
        result.First().Req.Should().Be("2");
        result.Last().Req.Should().Be("all");
    }

    [Fact]
    public void HandlesEmptyArrayJson()
    {
        var result = JsonSerializer.Deserialize<List<TestHelper>>("[]");

        result.Should().NotBeNull();
        result.Count.Should().Be(0);
    }

    const string Json =
        """
        [
            {
                "description": "Complete 2 objectives to win [ring]Cursed",
                "req": 2
            },
            {
                "description": "Complete all objectives to win [armor]Adamant",
                "req": "all"
            }
        ]
        """;
    private class TestHelper
    {
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("req")]
        [JsonConverter(typeof(ForceStringConverter))]
        public string Req { get; set; } = string.Empty;


    }
}
