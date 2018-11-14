$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'

Write-Host "root: $root"

$version = [System.Reflection.Assembly]::LoadFile("$root\bin\ICSharpCode.WpfDesign.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\NuGet\WpfDesigner.nuspec) 
$content = $content -replace '\$version\$',$versionStr
$content = $content -replace '\$releasenotes\$',$env:APPVEYOR_REPO_COMMIT_MESSAGE

$content | Out-File $root\nuget\WpfDesigner.compiled.nuspec

NuGet pack $root\nuget\WpfDesigner.compiled.nuspec

$content = (Get-Content $root\NuGet\WpfDesigner.ExpressionBlendInteractionAddon.nuspec) 
$content = $content -replace '\$version\$',$versionStr
$content = $content -replace '\$releasenotes\$',$env:APPVEYOR_REPO_COMMIT_MESSAGE

$content | Out-File $root\nuget\WpfDesigner.ExpressionBlendInteractionAddon.compiled.nuspec

NuGet pack $root\nuget\WpfDesigner.ExpressionBlendInteractionAddon.compiled.nuspec