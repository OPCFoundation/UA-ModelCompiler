@ECHO off
SETLOCAL

set MODELCOMPILER=..\..\build\bin\Release\net5.0\Opc.Ua.ModelCompiler.exe
set MODEL=DemoModel
set VERSION=v104
set INPUT=.
set OUTPUT=.

ECHO Building Model %MODEL%
set COMPILE_CMD=%MODELCOMPILER% compile -version %VERSION% -d2 "%INPUT%\%MODEL%.xml" -cg "%INPUT%\%MODEL%.csv" -o2 "%OUTPUT%"
ECHO %COMPILE_CMD%
%COMPILE_CMD%

IF %ERRORLEVEL% NEQ 0 (
    ECHO Fail to build %MODEL%, return code %ERRORLEVEL% & pause & EXIT /B 3
) ELSE (
    ECHO Build %MODEL% successfully.
)
pause
