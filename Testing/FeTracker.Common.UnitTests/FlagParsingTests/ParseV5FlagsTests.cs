using FeTracker.Common.Helpers;
using FeTracker.Common.Models;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.FlagParsingTests;

public class ParseV5FlagsTests
{
    [Fact]
    public void FlagsToDictionay_Should_ParseLabelsCorrectly()
    {
        var flagset = """     
OA1:collect_ki10/2:quest_forge/do_all:crystal Kmain/miab:above/char/shop Pkey Cstandard/nofree/start:edge/j:abilities Twildish Madd:2,above/mark Sstandard Bstandard/alt:gauntlet/whyburn Etoggle Glife/sylph/backrow Qmsgspeedfix -kit:better -spoon -smith:super
""";
        var sut = new Flags(flagset, "");
        var result = sut.ToDictionary();

        result.Should().NotBeNull();
        result.Keys.Should().BeEquivalentTo(["Objectives", "Key Items", "Pass", "Characters", "Treasures", "Miabs", "Shops", "Bosses", "Encounters", "Glitches", "QoL", "Kits", "Misc", "Forge"]);
    }

    [Fact]
    public void ToDictionary_Creates_CharacterSection_AsExpected()
    {
        var flags = "Cstandard/nofree/start:edge/j:abilities";
        var sut = new Flags(flags, "");
        var result = sut.ToDictionary();
        List<string> expectedValues = ["standard", "nofree", "start:edge", "j:abilities"];

        result.Keys.Should().HaveCount(1);
        result.TryGetValue("Characters", out var resultValues).Should().BeTrue();
        resultValues.Should().HaveCount(4);
        resultValues.Should().BeEquivalentTo(expectedValues);
    }

    [Fact]
    public void ToDictionary_Groups_StarterKits_Together()
    {
        var flags = "-kit:better -kit2:freedom -kit3:yang";
        var sut = new Flags(flags, "");
        var result = sut.ToDictionary();

        result.Keys.Should().HaveCount(1);
        result.TryGetValue("Kits", out var resutlValues).Should().BeTrue();
        resutlValues.Should().HaveCount(3);
        resutlValues.Should().BeEquivalentTo("kit:better", "kit2:freedom", "kit3:yang");
    }

    [Fact]
    public void MultipleOtherMiscTypes_Group_BySubtype()
    {
        var flags = "-kit:better -spoon -smith:super -vanilla:fusoya,agility,hobs";
        var sut = new Flags(flags, "");
        var result = sut.ToDictionary();

        result.Keys.Should().HaveCount(4);
        result.Keys.Should().BeEquivalentTo(["Kits", "Misc", "Forge", "Vanilla"]);
        result["Kits"].Should().BeEquivalentTo(["kit:better"]);
        result["Misc"].Should().BeEquivalentTo(["spoon"]);
        result["Forge"].Should().BeEquivalentTo(["smith:super"]);
        result["Vanilla"].Should().BeEquivalentTo(["vanilla:fusoya,agility,hobs"]);
    }

    [Fact]
    public void ToDictionary_WithEmptyFlags_DoesNotThrow()
    {
        var sut = new Flags("", "");
        var result = sut.ToDictionary();
        result.Keys.Should().HaveCount(0);
    }

}
