using System.Text.RegularExpressions;

namespace FeTracker.Common.RegexHelpers;

public partial class FlagsRegexHelper
{
    public static string GetV4WinCondition(string flagset)
    {
        var matches = V4WinConditionRegex().Match(flagset);
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
    public static List<int> GetRequiredObjectiveNumbers(string flagset)
    {
        var matches = HardRequiredObjectivesRegex().Match(flagset);
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

    public static string GetRequiredObjectiveCount(string flagset)
    {
        var matches = RequiredObjetiveCountRegex().Match(flagset);
        if (matches.Captures.Count != 0)
        {
            return matches.Captures.First().Value.Split(":").Last();
        }

        return string.Empty;
    }


    [GeneratedRegex(@"win:(crystal|game)", RegexOptions.IgnoreCase)]
    private static partial Regex V4WinConditionRegex();

    [GeneratedRegex(@"hardreq:([0-9,]*)")]
    private static partial Regex HardRequiredObjectivesRegex();

    [GeneratedRegex(@"\/req:(all|[0-9]*)")]
    private static partial Regex RequiredObjetiveCountRegex();

}
