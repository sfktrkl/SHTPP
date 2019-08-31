Write-Host ""
Write-Host "Zipping artifacts."
Write-Host "-----------------------------------------------------------------------"


$files =
(
  "Shoot++\InterpreterClassLibrary.dll",
  "Shoot++\OSGViewClassLibrary.dll",
  "Shoot++\Shoot++.exe"
  "Shoot++\externals\binaries\*.dll",
)

7z a -snl shootpp.zip $files | Out-String