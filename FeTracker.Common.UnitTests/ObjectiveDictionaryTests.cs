using System;
using FeTracker.Sni.Classes;
using FluentAssertions;

namespace FeTracker.Common.UnitTests;

public class ObjectiveDictionaryTests
{
    //Theory because I'm not going to explicitly test each and every one of the non-threshold objectives
    [Theory]
    [InlineData("char_cecil", "Find Cecil")]
    public void GettingCharacterObjectivesWork(string lookupKey, string expectedResult)
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText(lookupKey, 0, out var responseValue);

        responseBool.Should().BeTrue();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be(expectedResult);
    }

    [Fact]
    public void LookupInvalidKey_Returns_False_Out_Key()
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText("made_thisup", 0, out var responseValue);

        responseBool.Should().BeFalse();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be("made_thisup");
    }

    [Theory]
    [InlineData("internal_dkmatter", 30, "Dark Matter Count: 30")]
    public void ThresholdObjectiveCounts_Are_PlacedInto_OutString(string lookupKey, int threshold, string expectedResult)
    {
        var responseBool = ObjectiveDictionary.TryGetObjectiveText(lookupKey, threshold, out var responseValue);

        responseBool.Should().BeTrue();
        responseValue.Should().NotBeEmpty();
        responseValue.Should().Be(expectedResult);
    }
}
