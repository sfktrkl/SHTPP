if not exist "..\Debug" mkdir "..\Debug"
if not exist "..\Release" mkdir "..\Release"

copy "..\externals\binariesDebug\*.dll" "..\Debug"
copy "..\externals\binariesRelease\*.dll" "..\Release"