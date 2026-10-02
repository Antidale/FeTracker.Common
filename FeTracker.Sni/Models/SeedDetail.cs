using System;

namespace FeTracker.Sni.Models;

public class SeedDetail
{
    public string Version { get; set; } = string.Empty;
    public string Flags { get; set; } = string.Empty;
    public string BinaryFlags { get; set; } = string.Empty;
    public string Seed { get; set; } = string.Empty;
    /// <summary>
    /// Populated when a seed is using 4.x style objectives
    /// </summary>
    public List<string> Objectives { get; set; } = [];

    /// <summary>
    /// Populated when a seed is using 5.0 objectives
    /// </summary>
    public List<ObjectiveGroup> ObjectiveGroups { get; set; } = [];

    /// <summary>
    /// This might dissapear in the future, if it becomes something only purely useful for internal things.
    /// </summary>
    public string FrameworkVersion { get; set; } = string.Empty;

    public SeedDetail() { }

    public SeedDetail WithObjectiveGroups(List<ObjectiveGroup> objectiveGroups)
    {
        ObjectiveGroups = objectiveGroups;
        return this;
    }

    public SeedDetail WithObjectives(List<string> objectives)
    {
        Objectives = objectives;
        return this;
    }

}
