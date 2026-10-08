using System.Text.RegularExpressions;

namespace FeTracker.Common.Helpers;

public static partial class FlagParsingHelper
{
    public static Dictionary<string, List<string>> ParseFlagsToDictionary(string flags)
    {
        Dictionary<string, List<string>> dict = [];
        var sections = flags.Split(" ").ToList();
        sections.ForEach(section =>
        {
            var label = string.Empty;
            var firstChar = section.First().ToString();
            var rest = section[1..];
            if (firstChar == "-")
            {
                var matchResults = GetLabelRegex().Match(section);
                if (matchResults.Success)
                {
                    label = GetSectionLabel(matchResults.Groups.Values.Last().Value);
                }
                else
                {
                    label = GetSectionLabel(firstChar);
                }
            }
            else
            {
                label = GetSectionLabel(firstChar);
            }

            var flags = rest.Split("/").ToList();
            if (dict.TryGetValue(label, out List<string>? currentFlagsList))
            {
                dict[label] = [.. currentFlagsList, .. flags];
            }
            else
            {
                dict.Add(label, flags);
            }
        });
        return dict;
    }

    internal static string GetSectionLabel(string sectionLabel)
    {
        return sectionLabel switch
        {
            "O" => "Objectives",
            "K" => "Key Items",
            "P" => "Pass",
            "C" => "Characters",
            "T" => "Treasures",
            "M" => "Miabs",
            "S" => "Shops",
            "B" => "Bosses",
            "E" => "Encounters",
            "X" => "Experience",
            "G" => "Glitches",
            "Q" => "QoL",
            "-" => "Misc",
            "A" => "Agility",
            "H" => "Harp",
            "F" => "FuSoYa",
            "Z" => "Zeromus",
            "kit" => "Kits",
            "tweak" => "Tweaks",
            "vanilla" => "Vanilla",
            "smith" => "Forge",
            _ => "Uncategorized"
        };
    }

    [GeneratedRegex(@"-([a-z]*)[0-9]?:")]
    internal static partial Regex GetLabelRegex();
}
