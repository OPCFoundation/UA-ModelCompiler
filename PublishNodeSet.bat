@ECHO off
SETLOCAL

IF "%1"=="" (goto :usage)
IF "%2"=="" (goto :usage)
IF "%3"=="" (goto :usage)

set ROOT=%~dp0
set MODELCOMPILER=%ROOT%build\bin\Release\net6.0\Opc.Ua.ModelCompiler.exe
set NODESETS=%1
set NAME=%2
set TARGET=-uri %3
set OUTPUT=%ROOT%Tests\DemoModel\Models

IF NOT "%4"=="" set PREFIX=-prefix %4

ECHO Building Model %TARGET%
IF EXIST "%OUTPUT%\%NAME%" RMDIR /S /Q "%OUTPUT%\%NAME%"
IF NOT EXIST "%OUTPUT%" MKDIR "%OUTPUT%"
ECHO %MODELCOMPILER% compile-nodesets -input %NODESETS% -o2 %OUTPUT% %TARGET% %PREFIX%
%MODELCOMPILER% compile-nodesets -input %NODESETS% -o2 %OUTPUT% %TARGET% %PREFIX%
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %TARGET% & EXIT /B 3 )

ECHO Updating License
ECHO ON
CALL UpdateLicense %OUTPUT%
@ECHO OFF

COPY /Y "%OUTPUT%\%NAME%\*.*" "%NODESETS%\%NAME%"

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