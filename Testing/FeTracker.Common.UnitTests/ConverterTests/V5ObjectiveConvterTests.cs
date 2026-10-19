using System.Text.Json;
using System.Text.Json.Serialization;
using FeTracker.Common.Interfaces;
using FeTracker.Sni.Converters;
using FeTracker.Sni.Models;
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
        List<IObjective> expectedObjectives =
        [
            new GroupObjective { Group = "objectives_a", Req = 4.ToString()},
            new TaskObjective { Objective = "internal_gp", Threshold = 250000.ToString()},
            new TaskObjective { Objective = "internal_gp", Threshold = 500000.ToString()}
        ];
        var result = JsonSerializer.Deserialize<TestHelper>(ObjectiveJson);

        result.Should().NotBeNull();
        result.V5Objectives.Count.Should().Be(3);
        result.V5Objectives.Should().BeEquivalentTo(expectedObjectives);
        result.V5Objectives.First().Objective.Should().Be("objectives_a");
    }

    private class TestHelper
    {
        [JsonPropertyName("tasks")]
        [JsonConverter(typeof(V5ObjectiveConverter))]
        public List<IObjective> V5Objectives { get; set; } = [];
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
                "group": "objectives_a",
                "req": 4
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
