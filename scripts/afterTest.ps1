Write-Host ""
Write-Host "Zipping artifacts."
Write-Host "-----------------------------------------------------------------------"


$files =
(
  ".\externals\binaries\*.dll",
  ".\$Env:CONFIGURATION\InterpreterClassLibrary.dll",
  ".\$Env:CONFIGURATION\OSGViewClassLibrary.dll",
  ".\$Env:CONFIGURATION\Shoot++.exe"
)

7z a -snl shootpp.zip $files Shoot++\