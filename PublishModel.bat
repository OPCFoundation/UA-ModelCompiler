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
set SOURCE=%1
set TARGET=%2
set OUTPUT=..\nodesets
set INPUT=.\ModelCompiler\Design

IF "%~3"=="" (set V=v104) else (set V=%3)
IF %V%==v104 (set OUTPUT=%OUTPUT%\master) else (set OUTPUT=%OUTPUT%\%V%) 
set INPUT=%INPUT%.%V%
set VERSION=-version %V%
IF NOT "%4"=="" set EXCLUDE=-exclude %2

ECHO Building Model %TARGET%
IF NOT EXIST "%OUTPUT%\%TARGET%" MKDIR "%OUTPUT%\%TARGET%"
ECHO %MODELCOMPILER% %VERSION% %EXCLUDE% -d2 "%INPUT%\%SOURCE%.xml" -cg "%INPUT%\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\"
%MODELCOMPILER% %VERSION% %EXCLUDE% -d2 "%INPUT%\%SOURCE%.xml" -cg "%INPUT%\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO Copying Model files to %OUTPUT%\%TARGET%\%SOURCE%
COPY "%INPUT%\%SOURCE%.xml" "%OUTPUT%\%TARGET%\%SOURCE%.xml"
COPY "%INPUT%\%SOURCE%.csv" "%OUTPUT%\%TARGET%\%SOURCE%.csv"
DEL /f /q "%OUTPUT%\%TARGET%\*NodeSet.xml"
GOTO theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL