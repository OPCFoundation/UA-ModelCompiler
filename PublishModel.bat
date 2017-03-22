@ECHO off
REM ****************************************************************************************************************
REM ** --
REM ** This script demonstrates how to use the model compiler to generate source code from a variety
REM ** of XML files that adhere to the 'Nodeset2.xml' format. Please refer to the UA Specifications Part 6
REM ** for more information.
REM ** --
REM ****************************************************************************************************************
SETLOCAL

set MODELCOMPILER=.\Bin\Release\Opc.Ua.ModelCompiler.exe
set OUTPUT=.\Published
set SOURCE=%1
set TARGET=%2

ECHO Building Model %TARGET%
IF NOT EXIST "%OUTPUT%\%TARGET%" MKDIR "%OUTPUT%\%TARGET%"
ECHO %MODELCOMPILER% -d2 ".\ModelCompiler\Design\%SOURCE%.xml" -cg ".\ModelCompiler\Design\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\"
%MODELCOMPILER% -d2 ".\ModelCompiler\Design\%SOURCE%.xml" -cg ".\ModelCompiler\Design\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO Copying Model files to %OUTPUT%\%TARGET%\%SOURCE%
COPY ".\ModelCompiler\Design\%SOURCE%.xml" "%OUTPUT%\%TARGET%\%SOURCE%.xml"
COPY ".\ModelCompiler\Design\%SOURCE%.csv" "%OUTPUT%\%TARGET%\%SOURCE%.csv"
DEL /f /q "%OUTPUT%\%TARGET%\*NodeSet.xml"
GOTO theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL