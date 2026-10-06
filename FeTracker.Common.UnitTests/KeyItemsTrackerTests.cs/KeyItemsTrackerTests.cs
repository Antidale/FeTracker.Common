using System;
using FeTracker.Common.Helpers;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.KeyItemsTrackerTests.cs;

public class KeyItemsTrackerTests
{
    [Fact]
    public void IDunno()
    {
        List<string> objectives = [
            "Defeat the king at the Town of Monsters",
            "Complete Mt. Ordeals",
            "Liberate Baron Castle"
        ];

        var result = KeyItemHelper.RelatedObjectiveLookup[KeyItem.BaronKey].Intersect(objectives).Any();

        result.Should().BeTrue();
    }
}
