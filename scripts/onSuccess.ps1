$files =
(
  "$Env:CONFIGURATION\InterpreterClassLibrary.dll",
  "$Env:CONFIGURATION\OSGViewClassLibrary.lib",
  "$Env:CONFIGURATION\Shoot++.exe"
)

7z a -snl shootpp.zip $files | Out-String