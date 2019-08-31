$files =
(
  "$Env:CONFIGURATION\InterpreterClassLibrary.dll",
  "$Env:CONFIGURATION\OSGViewClassLibrary.dll",
  "$Env:CONFIGURATION\Shoot++.exe"
)

7z a -snl shootpp.zip $files | Out-String