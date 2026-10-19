using System;
using System.Text.RegularExpressions;
using FeTracker.Common.Enums;

namespace FeTracker.Common.Models;

public partial class FeVersion
{
    public Version Version { get; init; }
    public Host Host { get; init; }
    public string VersionString { get; init; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="versionString">the version string pulled from the ROM metadata</param>
    /// <exception cref="ArgumentException">If no valid Version typ can be constructed</exception>
    public FeVersion(string versionString)
    {
        var matches = GetVersionNumberRegex().Match(versionString);
        if (!matches.Success)
        {
            Version = new Version(0, 0, 0);
            Host = Host.Main;
            return;
        }

        Version = new Version(matches.Groups[1].Value);
        var hostString = matches.Groups.Values.Last().Value;
        Host = hostString switch
        {
            "" => Host.Main,
            "Gale" => Host.Galeswift,
            _ => Host.Alpha
        };

        VersionString = versionString;
    }

    [GeneratedRegex(@"v?(\d*\.\d*\.\d*)[\.-]?(.*)?")]
    private static partial Regex GetVersionNumberRegex();
}
