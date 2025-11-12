param(
    [string] $version = "1.0.0"
)

# dotnet nuget push ~/LocalNuGet/FeTracker.Common.$version.nupkg --api-key $Env:FE_TrackerNugetApiKey
# dotnet nuget push ~/LocalNuGet/FeTracker.AutoTrack.Sni.$version.nupkg --api-key $Env:FE_TrackerNugetApiKey
dotnet nuget push ~/LocalNuGet/FeTracker.Common.RazorComponents.$version.nupkg --api-key $Env:FE_TrackerNugetApiKey