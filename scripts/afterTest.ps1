Write-Host ""
Write-Host "Zipping artifacts."
Write-Host "-----------------------------------------------------------------------"


$files =
(
  "$Env:APPVEYOR_REPO_NAME\.\externals\binaries\*.dll",
  "$Env:APPVEYOR_REPO_NAME\InterpreterClassLibrary.dll",
  "$Env:APPVEYOR_REPO_NAME\OSGViewClassLibrary.dll",
  "$Env:APPVEYOR_REPO_NAME\Shoot++.exe"
)

7z a -snl shootpp.zip $files | Out-String