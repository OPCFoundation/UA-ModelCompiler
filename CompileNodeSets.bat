@ECHO off
SETLOCAL

IF "%1"=="" (goto :usage)
IF "%2"=="" (goto :usage)
IF "%3"=="" (goto :usage)

set ROOT=%~dp0
set MODELCOMPILER=%ROOT%build\bin\Release\net6.0\Opc.Ua.ModelCompiler.exe
set NODESETS=%1
set OUTPUT=%2
set TARGET=-uri %3
set DEPENDENCY1=
set DEPENDENCY2=
set DEPENDENCY3=

IF NOT "%4"=="" (set DEPENDENCY1=-uri %4)
IF NOT "%5"=="" (set DEPENDENCY2=-uri %5)
IF NOT "%6"=="" (set DEPENDENCY3=-uri %6)

ECHO Building Model %TARGET%
IF NOT EXIST "%OUTPUT%" MKDIR "%OUTPUT%"
ECHO %MODELCOMPILER% compile-nodesets -input %NODESETS% -o2 %OUTPUT% %TARGET% %DEPENDENCY1% %DEPENDENCY2% %DEPENDENCY3%
%MODELCOMPILER% compile-nodesets -input %NODESETS% -o2 %OUTPUT% %TARGET% %DEPENDENCY1% %DEPENDENCY2% %DEPENDENCY3%
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO Updating License
ECHO ON
CALL UpdateLicense "%OUTPUT%"
@ECHO OFF

GOTO :theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:usage
ECHO.
ECHO Usage: CompileNodeSets.bat [nodesets directory] [generated file directory] [URI] [(dependency URI)*]
GOTO :theEnd

:theEnd
ENDLOCAL