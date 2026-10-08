using System;
using FeTracker.Common.Helpers;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.FlagParsingTests;

public class GetLabelRegexTests
{
    [Theory]
    [InlineData("-kit2:freedom", "kit")]
    [InlineData("-kit:freedom", "kit")]
    [InlineData("-kit3:better", "kit")]
    public void GetSectionLabel_Parses_Kits_Correctly(string flag, string expectedLabel)
    {
        var result = FlagParsingHelper.GetLabelRegex().Match(flag);
        result.Success.Should().BeTrue();
        result.Groups.Count.Should().Be(2);
        result.Groups.Values.Should().HaveCount(2);
        result.Groups.Values.Last().Value.Should().Be(expectedLabel);
    }

}
