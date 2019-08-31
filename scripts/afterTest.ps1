Write-Host ""
Write-Host "Zipping artifacts."
Write-Host "-----------------------------------------------------------------------"


$files =
(
  "Shoot++\.\externals\binaries\*.dll",
  "Shoot++.\$Env:CONFIGURATION\InterpreterClassLibrary.dll",
  "Shoot++.\$Env:CONFIGURATION\OSGViewClassLibrary.dll",
  "Shoot++.\$Env:CONFIGURATION\Shoot++.exe"
)

7z a -snl shootpp.zip $files | Out-String