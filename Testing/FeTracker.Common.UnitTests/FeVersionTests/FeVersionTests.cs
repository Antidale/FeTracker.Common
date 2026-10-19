using System;
using FeTracker.Common.Models;
using FluentAssertions;

namespace FeTracker.Common.UnitTests.FeVersionTests;

public class FeVersionTests
{
    [Fact]
    public void V4Versions_Parses_Correctly()
    {
        var sut = new FeVersion("v4.6.0");

        sut.Version.Should().BeEquivalentTo(new Version(4, 6, 0));
        sut.Host.Should().Be(Host.Main);
    }

    [Fact]
    public void V5Alpha_Parses_Correctly()
    {
        var sut = new FeVersion("v5.0.0-a.3");

        sut.Version.Should().BeEquivalentTo(new Version(5, 0, 0));
        sut.Host.Should().Be(Host.Alpha);
    }

    [Fact]
    public void V4Gale_Parses_Correctly()
    {
        var sut = new FeVersion("v4.7.0.Gale");
        sut.Version.Should().BeEquivalentTo(new Version(4, 7, 0));
        sut.Host.Should().Be(Host.Galeswift);
    }
}
