using System.Text.Json;
using System.Text.Json.Serialization;
using FeTracker.Common.Models;
using FeTracker.Sni.Converters;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.ConverterTests;

public class V5ObjectiveConvterTests
{
    [Fact]
    public void CanConvertListString()
    {
        List<string> expectedObjectives =
        [
            "quest_traderat",
            "quest_giant",
            "quest_kaipoinn",
            "quest_falcon",
            "quest_sealedcave",
            "quest_baroncastle"
        ];

        var result = JsonSerializer.Deserialize<TestHelper>(SimpleJson);

        result.Should().NotBeNull();
        result.V5Objectives.Count.Should().Be(6);
        result.V5Objectives.Select(x => x.Objective).Should().BeEquivalentTo(expectedObjectives);
    }

    [Fact]
    public void CanConvertListObjective()
    {
        List<V5Objective> expectedObjectives =
        [
            new V5Objective{ Objective = "internal_gp", Threshold = 100000},
            new V5Objective{ Objective = "internal_gp", Threshold = 250000},
            new V5Objective{ Objective = "internal_gp", Threshold = 500000}
        ];
        var result = JsonSerializer.Deserialize<TestHelper>(ObjectiveJson);

        result.Should().NotBeNull();
        result.V5Objectives.Count.Should().Be(3);
        result.V5Objectives.Should().BeEquivalentTo(expectedObjectives);
    }

    private class TestHelper
    {
        [JsonPropertyName("tasks")]
        [JsonConverter(typeof(V5ObjectiveConverter))]
        public List<V5Objective> V5Objectives { get; set; } = [];
    }

    const string SimpleJson =
    """
    {
        "tasks": [
            "quest_traderat",
            "quest_giant",
            "quest_kaipoinn",
            "quest_falcon",
            "quest_sealedcave",
            "quest_baroncastle"
        ]
    }
    """;

    const string ObjectiveJson =
    """
    {
        "tasks": [
            {
                "objective": "internal_gp",
                "threshold": 100000
            },
            {
                "objective": "internal_gp",
                "threshold": 250000
            },
            {
                "objective": "internal_gp",
                "threshold": 500000
            }
        ]
    }
    """;
}
