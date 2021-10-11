@ECHO off
SETLOCAL

set ROOT=%~dp0
set MODELCOMPILER=%ROOT%build\bin\Release\net5.0\Opc.Ua.ModelCompiler.exe
set SOURCE=%1
set TARGET=%2
set OUTPUT=%ROOT%..\nodesets
set INPUT=%ROOT%Opc.Ua.ModelCompiler\Design
set CSVINPUT=%ROOT%Opc.Ua.ModelCompiler\CSVs

IF NOT "%3"=="" (set INPUT=%INPUT%.%3) else (set INPUT=%INPUT%.v105)
IF NOT "%3"=="" (set OUTPUT=%OUTPUT%\%3) else (set OUTPUT=%OUTPUT%\master)
IF NOT "%3"=="" set VERSION=-version %3
IF NOT "%4"=="" set EXCLUDE=-exclude %4

IF "%3"=="v105" set OUTPUT=%ROOT%..\nodesets\master
IF "%3"=="v103" set CSVINPUT=%INPUT%

ECHO Building Model %TARGET%
IF NOT EXIST "%OUTPUT%\%TARGET%" MKDIR "%OUTPUT%\%TARGET%"
ECHO %MODELCOMPILER% %VERSION% %EXCLUDE% -d2 "%INPUT%\%SOURCE%.xml" -cg "%CSVINPUT%\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\\" %USEALLOWSUBTYPES%
%MODELCOMPILER% %VERSION% %EXCLUDE% -d2 "%INPUT%\%SOURCE%.xml" -cg "%CSVINPUT%\%SOURCE%.csv" -o2 "%OUTPUT%\%TARGET%\\" %USEALLOWSUBTYPES%
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO Copying Model files to %OUTPUT%\%TARGET%\%SOURCE%
COPY "%INPUT%\%SOURCE%.xml" "%OUTPUT%\%TARGET%\%SOURCE%.xml"
TYPE "%CSVINPUT%\%SOURCE%.csv" | FINDSTR /V /E Unspecified > "%OUTPUT%\%TARGET%\%SOURCE%.csv"
DEL /f /q "%OUTPUT%\%TARGET%\*NodeSet.xml"
GOTO theEnd

ECHO Updating License
ECHO ON
CALL UpdateLicense "%OUTPUT%\%TARGET%"
@ECHO OFF

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL