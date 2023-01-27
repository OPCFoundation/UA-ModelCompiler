@ECHO off
SETLOCAL

set ROOT=%~dp0
set BUILD=msbuild -v:m
set NODESETS=..\nodesets
set OUTPUT=.\Tests\DemoModel\Models

if NOT "%1"=="" (set NODESETS=%NODESETS%\%1) else (set NODESETS=%NODESETS%\v105)
if NOT "%2"=="" (set OUTPUT=%2) 

set PROJECT=BACnet
set URIS=http://opcfoundation.org/UA/BACnet_V2/
call :GenerateAndBuild

REM set PROJECT=PLCopen
REM set URIS=http://PLCopen.org/OpcUa/IEC61131-3/ http://opcfoundation.org/UA/DI/
REM call "%ROOT%\CompileNodeSets.bat" %NODESETS% %OUTPUT% %URIS%
REM %BUILD% .\Tests\DemoModel\DemoModel.Debug.csproj

REM set PROJECT=IEC61850
REM set URIS=http://opcfoundation.org/UA/IEC61850-6 http://opcfoundation.org/UA/IEC61850-7-4 http://opcfoundation.org/UA/IEC61850-7-3
REM CALL :GenerateAndBuild

goto :theEnd

:GenerateAndBuild
if EXIST "%OUTPUT%\%PROJECT%" (rmdir /Q /S "%OUTPUT%\%PROJECT%")
call "%ROOT%\CompileNodeSets.bat" %NODESETS% %OUTPUT% %URIS%
%BUILD% .\Tests\DemoModel\DemoModel.Debug.csproj
EXIT /B 0

goto :theEnd

:usage
echo.
echo Usage: TestNodeSets.bat [nodesets directory]
goto :theEnd

:theEnd
ENDLOCAL