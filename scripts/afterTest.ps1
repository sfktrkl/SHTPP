Write-Host ""
Write-Host "Zipping artifacts."
Write-Host "-----------------------------------------------------------------------"


if (Test-Path Shoot++) { Remove-Item Shoot++ -Recurse }
if (Test-Path Shoot++.zip) { Remove-Item Shoot++.zip -Recurse }
New-Item -Name Shoot++ -ItemType "directory"
Copy-Item -Path ..\externals\binaries\*.dll -Destination Shoot++
Copy-Item -Path ..\Release\InterpreterClassLibrary.dll -Destination Shoot++
Copy-Item -Path ..\Release\OSGViewClassLibrary.dll -Destination Shoot++
Copy-Item -Path ..\Release\Shoot++.exe -Destination Shoot++

7z a -snl Shoot++.zip $files Shoot++