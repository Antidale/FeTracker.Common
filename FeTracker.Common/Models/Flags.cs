using System.Text.RegularExpressions;

namespace FeTracker.Common.Models;

public partial class Flags(string flags, string binaryFlags)
{
    public readonly string Flagstring = flags;
    public readonly string BinaryFlags = binaryFlags;

    public string GetV4WinCondition()
    {
        var matches = V4WinConditionRegex().Match(Flagstring);
        if (matches.Captures.Count != 0)
        {
            return matches.Captures.First().Value.Split(":").Last();
        }

        return string.Empty;
    }

    /// <summary>
    /// A method to parse out the objective numbers that are hard required. uses the default 1 based indexing, and not 0 based
    /// </summary>
    /// <param name="flagset">The flagset, or at least the portion of the flagset including the Ohardreq flag</param>
    /// <returns>The actual number values in the flagset. Callers are responsible for any modifications they need to make to match up with any list accessing they do on an objectives list.</returns>
    public List<int> GetRequiredObjectiveNumbers()
    {
        var matches = HardRequiredObjectivesRegex().Match(Flagstring);
        if (matches.Captures.Count != 0)
        {
            var numStrings = matches.Captures.First().Value.Split(":").Last().Split(",").ToList();

            List<int> returnValue = [];
            numStrings.ForEach(str =>
            {
                if (int.TryParse(str, out var intValue))
                {
                    returnValue.Add(intValue);
                }
            });
            return returnValue;

        }
        return [];
    }

    /// <summary>
    /// Parses the flags to determine how many objectives are required to meet the win: condition
    /// </summary>
    /// <returns>a string representation of the number, or the word all</returns>
    public string GetGoalObjectiveCount()
    {
        var matches = RequiredObjetiveCountRegex().Match(Flagstring);
        if (matches.Captures.Count != 0)
        {
            return matches.Captures.First().Value.Split(":").Last();
        }

        return string.Empty;
    }

    public Dictionary<string, List<string>> ToDictionary()
    {
        Dictionary<string, List<string>> dict = [];
        if (string.IsNullOrWhiteSpace(Flagstring)) { return dict; }

        var sections = Flagstring.Split(" ").ToList();
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


    [GeneratedRegex(@"win:(crystal|game)", RegexOptions.IgnoreCase)]
    private static partial Regex V4WinConditionRegex();

    [GeneratedRegex(@"hardreq:([0-9,]*)")]
    private static partial Regex HardRequiredObjectivesRegex();

    [GeneratedRegex(@"\/req:(all|[0-9]*)")]
    private static partial Regex RequiredObjetiveCountRegex();
}
