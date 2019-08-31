$buildPath = "$Env:APPVEYOR_BUILD_FOLDER\$Env:CONFIGURATION"

vstest.console /logger:Appveyor "$buildPath\InterpreterTests\InterpreterTests.dll"
if ($LASTEXITCODE -ne 0)
{
  Write-Host "Tests are failed."
  throw
}