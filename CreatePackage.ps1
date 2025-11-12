param(
    [string] $version = "1.0.0"
)

# Load the RazorComponents csproj and update the expected version for the overall Common package
foreach ($path in Get-ChildItem -Recurse "./**/*.csproj") {
    $xml = [xml]::new()
    $xml.PreserveWhitespace = $true
    $xml.Load($path)

    $xml.Project.PropertyGroup.Version = $version
    

    if ($xml.Project.PropertyGroup.Title -eq "FeTracker.Common.RazorComponents") {
        $commonRef = $xml.Project.ItemGroup.PackageReference | Where-Object { $_.Include -eq "FeTracker.Common" }
        $commonRef.Version = $version
        
    }
    $xml.Save($path)
}

# With that update, we can pack them, but do need to do them either individually or pack the base .Common package twice, so that the RazorComponents package has that completed as a dependency
dotnet pack ./FeTracker.Common/FeTracker.Common.csproj -p:Version=$version --output ~/LocalNuGet
dotnet pack ./FeTracker.AutoTrack.Sni/FeTracker.AutoTrack.Sni.csproj -p:Version=$version --output ~/LocalNuGet
dotnet pack ./FeTracker.Common.RazorComponents/FeTracker.Common.RazorComponents.csproj -p:Version=$version --output ~/LocalNuGet

