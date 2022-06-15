@ECHO off
SETLOCAL

set MODELCOMPILER=..\..\build\bin\Release\Opc.Ua.ModelCompiler\net5.0\Opc.Ua.ModelCompiler.exe
set MODEL=OpcUaNodeSetModel
set VERSION=v104
set EXCLUDE=Draft
set INPUT=.
set OUTPUT=.

ECHO Building Model %MODEL%
ECHO %MODELCOMPILER% %VERSION% %EXCLUDE% -d2 "%INPUT%\%MODEL%.xml" -cg "%INPUT%\%MODEL%.csv" -o2 "%OUTPUT%"
%MODELCOMPILER% %VERSION% %EXCLUDE% -d2 "%INPUT%\%MODEL%.xml" -cg "%INPUT%\%MODEL%.csv" -o2 "%OUTPUT%"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %MODEL% & EXIT /B 3 )