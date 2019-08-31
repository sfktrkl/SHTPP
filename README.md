# Introduction

[![Download](https://img.shields.io/static/v1?label=Download&message=CLICK&color=blue)](https://ci.appveyor.com/project/sfktrkl/shootpp/build/artifacts)

[![Build status](https://ci.appveyor.com/api/projects/status/tckmmm81ucdh9mrp/branch/master?svg=true)](https://ci.appveyor.com/project/sfktrkl/shootpp/branch/master)
![GitHub repo size](https://img.shields.io/github/repo-size/sfktrkl/Shootpp)
![GitHub](https://img.shields.io/github/license/sfktrkl/Shootpp)

This is the Shoot++. Have Fun.

This repository includes an interpreter, a viewer (based on OpenSceneGraph) and the c# form application.  

You can download the pre-built files and directly play the game using button on top of the page.  

Or if you need any help playing or building the project instructions are given below.

For further questions: sfktrkl@gmail.com

---

## How to build

First of all you need the external files which are the OpenSceneGraph libraries.

You can simply use the pre-built(Visual Studio 15 2017 - x64) libraries in externals folder by extracting them.  
If you want to build them by yourself go to, https://github.com/openscenegraph/OpenSceneGraph.  

Be sure that extracting them to the appropriate path.  
(externals/lib, externals/include, externals/binariesDebug, externals/binariesRelease)

After taking the binaries you can use copyBinaries.bat inside the scripts to copy binaries to configuration folders.

Then simply you can build and run in the Visual Studio.

## How to play

In this game you have to complete the missions by writing your own code in game's own language.  
Every tutorial and mission has its own explanations, so make sure you read them.  

Since game has its own programming language you may want to use the help inside the game and also the examples below.

## Syntax

### __Comment lines:__  
_Example:_  
__#__ THIS IS A COMMENT LINE  

### __Creating a variable:__  
To create a variable use __$__.  
_Example:_  
$VARIABLE = 5  
SHOOT $VARIABLE 

### __Keywords:__  
__SHOOT__, to return something use this keyword.  
_Example:_  
SHOOT "This is a string"  
SHOOT 10  
SHOOT 10 + 2  

__INPUT__, to take inputs use this keyword.  
_Example:_  
INPUT $NUMBER  
SHOOT $NUMBER  

__IF__, __THEN__ __ELSE__ and __ENDIF__  
These are the keywords to create an if statement.  
_Example:_  
IF 10 + 2 == 12 THEN  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SHOOT 1  
ELSE  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SHOOT 0  
ENDIF  

__LOOP__ and __ENDLOOP__  
These are the keywords to create a loop.  
_Example:_  
$NUMBER = 3  
LOOP $NUMBER == 3 THEN  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SHOOT 1  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;$NUMBER = $NUMBER - 1  
ENDLOOP   

__DEBUG__, to debug any variable, value or expression use this keyword.  
SHOOT keyword also give debug outputs. You can enable or disable these outputs from debug screen.  
_Example:_  
DEBUG 4  
DEBUG 10 + 5  
INPUT $NUMBER  
DEBUG $NUMBER  

### __Operators:__  

__Arithmetic Operators__  
With the order of the precision,  
__*__ Multiplication  
__/__ Division  
__%__ Modulus  
__+__ Addition  
__-__ Subtraction  

__Assignment Operators__  
__=__ Equals

__Comparison Operators__  
__==__ Equal to

