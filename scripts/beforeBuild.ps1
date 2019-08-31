Write-Host ""
Write-Host "Extract externals."
Write-Host "-----------------------------------------------------------------------"

Resolve-Path ~

if (Test-Path externals\binaries) { Remove-Item externals\binaries -Recurse }
if (Test-Path externals\include) { Remove-Item externals\include -Recurse }
if (Test-Path externals\lib) { Remove-Item externals\lib -Recurse }
7z e -snl externals\externals.7z