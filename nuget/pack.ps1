$root = (split-path -parent $MyInvocation.MyCommand.Definition) + '\..'

Write-Host "root: $root"

$version = [System.Reflection.Assembly]::LoadFile("$root\XamlDesigner\bin\Debug\ICSharpCode.WpfDesign.dll").GetName().Version
$versionStr = "{0}.{1}.{2}" -f ($version.Major, $version.Minor, $version.Build)

Write-Host "Setting .nuspec version tag to $versionStr"

$content = (Get-Content $root\NuGet\WpfDesigner.nuspec) 
$content = $content -replace '\$version\$',$versionStr

$content | Out-File $root\nuget\WpfDesigner.compiled.nuspec

& $nuget pack $root\nuget\WpfDesigner.compiled.nuspec