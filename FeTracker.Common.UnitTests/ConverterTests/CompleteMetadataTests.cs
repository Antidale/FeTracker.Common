using System.Text.Json;
using FeTracker.Sni.Models;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.ConverterTests;

public class CompleteMetadataTests
{

    [Fact]
    public void DeserialzeComplexJsonWithoutException()
    {
        var result = JsonSerializer.Deserialize<List<ObjectiveGroup>>(Json);

        result.Should().NotBeNull();
        result.Count.Should().Be(5);
        //Will add more assertions here or specific tests later
    }


    const string Json =
    """
    [
        {
            "key": "objectives_a",
            "name": "Objective Group A",
            "tasks": [
                "quest_traderat",
                "quest_giant",
                "quest_kaipoinn",
                "quest_falcon",
                "quest_sealedcave",
                "quest_baroncastle"
            ],
            "rewards": []
        },
        {
            "key": "objectives_b",
            "name": "Objective Group B",
            "tasks": [
                "quest_cavebahamut",
                "quest_ribbonaltar",
                "quest_masamunealtar"
            ],
            "rewards": []
        },
        {
            "key": "objectives_c",
            "name": "Objective Group C",
            "tasks": [
                {
                    "group": "objectives_a",
                    "req": 4
                },
                {
                    "group": "objectives_b",
                    "req": "all"
                }
            ],
            "rewards": [
                {
                    "description": "Complete 1 objective to win a special weapon",
                    "req": 1
                },
                {
                    "description": "Complete all objectives to win [crystal]Crystal",
                    "req": "all"
                }
            ]
        },
        {
            "key": "objectives_d",
            "name": "Objective Group D",
            "tasks": [
                "boss_bahamut",
                "boss_wyvern",
                "boss_golbez",
                "boss_octomamm",
                "boss_odin",
                "boss_magus",
                "boss_fabulgauntlet",
                "boss_plague"
            ],
            "rewards": []
        },
        {
            "key": "objectives_e",
            "name": "Objective Group E",
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
            ],
            "rewards": [
                {
                    "description": "Complete 1 objective to win [knife]Spoon",
                    "req": 1
                },
                {
                    "description": "Complete 2 objectives to win [ring]Cursed",
                    "req": 2
                },
                {
                    "description": "Complete all objectives to win [armor]Adamant",
                    "req": "all"
                }
            ]
        }
    ]
    """;
}