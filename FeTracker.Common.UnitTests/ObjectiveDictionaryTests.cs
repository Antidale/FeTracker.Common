using FeTracker.Sni.Classes;
using FeTracker.Sni.Models;
using FluentAssertions;

namespace FeTracker.Common.UnitTests;

public class ObjectiveDictionaryTests
{
    //Theory because I'm not going to explicitly test each and every one of the non-threshold objectives.
    [Theory]
    [InlineData("char_cecil", "0", "Find Cecil")]
    [InlineData("char_cecil", "2", "Find Cecil")]
    public void GettingCharacterObjectivesWork(string lookupKey, string threshold, string expectedResult)
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText(lookupKey, threshold, out var responseValue);

        responseBool.Should().BeTrue();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("its_false", 0)]
    [InlineData("its_false", 30)]
    [InlineData("no_way", 0)]
    [InlineData("we_madeItUp", 99)]
    [InlineData("pure_fiction", 800_000)]
    public void LookupInvalidKey_Returns_False_Out_Key(string lookupKey, int threshold)
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText(lookupKey, threshold.ToString(), out var responseValue);

        responseBool.Should().BeFalse();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be(lookupKey);
    }

    [Theory]
    [InlineData("internal_dkmatter", 30, "Dark Matter Count: 30")]
    [InlineData("internal_gp", 250_000, "GP Count: 250,000")]
    public void ThresholdObjectiveCounts_Are_PlacedInto_OutString(string lookupKey, int threshold, string expectedResult)
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText(lookupKey, threshold.ToString(), out var responseValue);

        responseBool.Should().BeTrue();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("objectives_a", "all", "Group A, Do: all")]
    [InlineData("objectives_e", "2", "Group E, Do: 2")]
    public void GroupObjectives_Update_ObjectiveProperty(string lookupKey, string threshold, string expectedResult)
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText(lookupKey, threshold.ToString(), out var responseValue);

        responseBool.Should().BeTrue();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be(expectedResult);
    }

    [Theory]
    [InlineData("Complete 1 objective to win [sword]Excalibur", "1", "sword", "Excalibur")]
    [InlineData("Complete 2 objectives to win DkMatter", "2", "", "DkMatter")]
    [InlineData("Complete all objectives to win [knife]Spoon", "all", "knife", "Spoon")]
    [InlineData("Complete 1 objective to win a special weapon", "1", "", "a special weapon")]
    // [InlineData("")]
    public void GetReward_Correctly_CreatesRewardObject(string fullText, string first, string second, string third)
    {
        var expectedResult = new Reward(first, second, third);
        var sut = ObjectiveDictionary.GetReward(fullText);
        sut.Should().BeEquivalentTo(expectedResult);
    }
}
