Write-Host ""
Write-Host "Extract externals."
Write-Host "-----------------------------------------------------------------------"


if (Test-Path externals\binaries) { Remove-Item externals\binaries -Recurse }
if (Test-Path externals\include) { Remove-Item externals\include -Recurse }
if (Test-Path externals\lib) { Remove-Item externals\lib -Recurse }
7z e externals\externals.7z