@ECHO off
SETLOCAL

set ROOT=%~dp0
set MODELCOMPILER=%ROOT%build\bin\Release\net6.0\Opc.Ua.ModelCompiler.exe
set OUTPUT=%ROOT%..\nodesets
set INPUT=%ROOT%Opc.Ua.ModelCompiler\Design
set CSVINPUT=%ROOT%Opc.Ua.ModelCompiler\CSVs
set SCHEMAINPUT=.\Schemas

IF NOT "%1"=="" (set OUTPUT=%OUTPUT%\%1) else (set OUTPUT=%OUTPUT%\master)
IF NOT "%1"=="" (set INPUT=%INPUT%.%1) else (set INPUT=%INPUT%.v105)
IF NOT "%1"=="" (set VERSION=-version %1) else (set VERSION=-version v105)
IF NOT "%2"=="" set EXCLUDE=-exclude %2
IF "%1"=="v105" (set OUTPUT=..\nodesets\v105)

IF EXIST "%INPUT%\Schemas" (
	set SCHEMAINPUT=%INPUT%\Schemas
)

set ANSIC_TARGET=
set DOTNET_TARGET=.\Stack\Stack\Opc.Ua.Core\
set GDS_TARGET=
set DI_TARGET=
set ADI_TARGET=
set NODESET_TARGET=.\Tests\NodeSetTest
set DEMOMODEL_TARGET=.\Tests\DemoModel\DemoModel\
set ONBOARDING_TARGET=.\Tests\DemoModel\Onboarding\
set GDS_TARGET=.\Tests\DemoModel\GDS\
set SCHEDULER_TARGET=.\Tests\DemoModel\Scheduler\

REM Make sure that all of our output locations exist.
IF NOT EXIST %MODELCOMPILER% GOTO noModelCompiler
IF NOT EXIST %OUTPUT% MKDIR %OUTPUT%
IF NOT EXIST %OUTPUT%\Schema MKDIR %OUTPUT%\Schema
IF NOT EXIST %OUTPUT%\DotNet MKDIR %OUTPUT%\DotNet
IF NOT EXIST %OUTPUT%\AnsiC MKDIR %OUTPUT%\AnsiC

set USEALLOWSUBTYPES=-useAllowSubtypes
set MODELVERSION=

REM Set overrides for older versions. set DOTNET_TARGET=.\Stack\Stack\Opc.Ua.Core\
IF "%1"=="v105" (
	set DOTNET_TARGET=.\Stack\Stack\Opc.Ua.Core\
	set MODELVERSION=-mv 1.05.02 -pd 2022-11-01
	set USEALLOWSUBTYPES=
)

IF "%1"=="v104" (
	set DOTNET_TARGET=.\Stack\Stack\Opc.Ua.Core\
	set USEALLOWSUBTYPES=
	set MODELVERSION=-mv 1.04.11 -pd 2022-03-29
)

IF "%1"=="v103" (
	set USEALLOWSUBTYPES=
	set CSVINPUT=%INPUT%
	set MODELVERSION=-mv 1.03.9 -pd 2022-03-29
)

IF NOT "%3"=="" GOTO skipcore

SET MODELNAME="CORE"
ECHO Building Model %MODELNAME%
ECHO %MODELCOMPILER% compile -d2 "%INPUT%\StandardTypes.xml" %VERSION% %EXCLUDE% -d2 "%INPUT%\UA Core Services.xml" -c "%CSVINPUT%\StandardTypes.csv" -o2 "%OUTPUT%\Schema\\" -stack "%OUTPUT%\DotNet\\" -ansic "%OUTPUT%\AnsiC\\" %USEALLOWSUBTYPES% %MODELVERSION%
%MODELCOMPILER% compile -rc -d2 "%INPUT%\StandardTypes.xml" %VERSION% %EXCLUDE% -d2 "%INPUT%\UA Core Services.xml" -c "%CSVINPUT%\StandardTypes.csv" -o2 "%OUTPUT%\Schema\\" -stack "%OUTPUT%\DotNet\\" -ansic "%OUTPUT%\AnsiC\\" %USEALLOWSUBTYPES% %MODELVERSION%
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %MODELNAME% & EXIT /B 1 )

IF EXIST %INPUT%\DemoModel.xml (
	CALL PublishModel DemoModel DemoModel %1 %2
	CALL UpdateLicense "%OUTPUT%\DemoModel"
)

ECHO Updating License
ECHO ON
CALL UpdateLicense "%OUTPUT%\Schema"
CALL UpdateLicense "%OUTPUT%\DotNet"
CALL UpdateLicense "%OUTPUT%\AnsiC"
@ECHO OFF

ECHO Copying CSV files to %OUTPUT%\Schema\
ECHO ON
TYPE "%CSVINPUT%\StandardTypes.csv" | FINDSTR /V /E Unspecified > "%OUTPUT%\Schema\NodeIds.csv"
COPY "%CSVINPUT%\Attributes.csv" "%OUTPUT%\Schema\AttributeIds.csv"
COPY "%CSVINPUT%\ServerCapabilities.csv" "%OUTPUT%\Schema\ServerCapabilities.csv"
COPY "%CSVINPUT%\AggregateExamples.csv" "%OUTPUT%\Schema\AggregateExamples.csv"
COPY "%OUTPUT%\DotNet\Opc.Ua.StatusCodes.csv" "%OUTPUT%\Schema\StatusCode.csv"
COPY "%SCHEMAINPUT%\UANodeSet.xsd" "%OUTPUT%\Schema\UANodeSet.xsd"
COPY "%SCHEMAINPUT%\SecuredApplication.xsd" "%OUTPUT%\Schema\SecuredApplication.xsd"
COPY "%SCHEMAINPUT%\OPCBinarySchema.xsd" "%OUTPUT%\Schema\OPCBinarySchema.xsd"
DEL /Q "%OUTPUT%\Schema\Opc.Ua.NodeIds.csv"
DEL /Q "%OUTPUT%\Schema\Opc.Ua.NodeIds.Services.csv"
@ECHO OFF

ECHO Moving .NET files to %OUTPUT%\DotNet\
MOVE /Y "%OUTPUT%\Schema\Opc.Ua.Classes.cs" "%OUTPUT%\DotNet\Opc.Ua.Classes.cs"
MOVE /Y "%OUTPUT%\Schema\Opc.Ua.Constants.cs" "%OUTPUT%\DotNet\Opc.Ua.Constants.cs"
MOVE /Y "%OUTPUT%\Schema\Opc.Ua.DataTypes.cs" "%OUTPUT%\DotNet\Opc.Ua.DataTypes.cs"
MOVE /Y "%OUTPUT%\Schema\Opc.Ua.PredefinedNodes.uanodes" "%OUTPUT%\DotNet\Opc.Ua.PredefinedNodes.uanodes"
MOVE /Y "%OUTPUT%\Schema\Opc.Ua.PredefinedNodes.xml" "%OUTPUT%\DotNet\Opc.Ua.PredefinedNodes.xml"
MOVE /Y "%OUTPUT%\Schema\Opc.Ua.NodeSet.xml" "%OUTPUT%\DotNet\Opc.Ua.NodeSet.xml"
@ECHO OFF

IF "%ANSIC_TARGET%" NEQ "" (
	ECHO Copying ANSIC code to %ANSIC_TARGET%
	ECHO ON
	COPY "%OUTPUT%\AnsiC\opcua_statuscodes.h" "%ANSIC_TARGET%\core\"
	COPY "%OUTPUT%\AnsiC\opcua_exclusions.h" "%ANSIC_TARGET%\core\"
	COPY "%OUTPUT%\AnsiC\opcua_attributes.h" "%ANSIC_TARGET%\stackcore\"
	COPY "%OUTPUT%\AnsiC\opcua_browsenames.h" "%ANSIC_TARGET%\stackcore\"
	COPY "%OUTPUT%\AnsiC\opcua_identifiers.h" "%ANSIC_TARGET%\stackcore\"
	COPY "%OUTPUT%\AnsiC\opcua_types.c" "%ANSIC_TARGET%\stackcore\"
	COPY "%OUTPUT%\AnsiC\opcua_types.h" "%ANSIC_TARGET%\stackcore\"
	COPY "%OUTPUT%\AnsiC\opcua_clientapi.h" "%ANSIC_TARGET%\proxystub\clientproxy\"
	COPY "%OUTPUT%\AnsiC\opcua_clientapi.c" "%ANSIC_TARGET%\proxystub\clientproxy\"
	COPY "%OUTPUT%\AnsiC\opcua_serverapi.h" "%ANSIC_TARGET%\proxystub\serverstub\"
	COPY "%OUTPUT%\AnsiC\opcua_serverapi.c" "%ANSIC_TARGET%\proxystub\serverstub\"
	@ECHO OFF
)

IF "%DOTNET_TARGET%" NEQ "" (
	ECHO Copying .NET code to %DOTNET_TARGET%

	COPY "%OUTPUT%\Schema\NodeIds.csv" "%DOTNET_TARGET%\Schema\NodeIds.csv"
	COPY "%OUTPUT%\Schema\AttributeIds.csv" "%DOTNET_TARGET%\Schema\AttributeIds.csv"
	COPY "%OUTPUT%\Schema\ServerCapabilities.csv" "%DOTNET_TARGET%\Schema\ServerCapabilities.csv"
	COPY "%OUTPUT%\Schema\StatusCode.csv" "%DOTNET_TARGET%\Schema\Opc.Ua.StatusCodes.csv"
	COPY "%SCHEMAINPUT%\UANodeSet.xsd" "%DOTNET_TARGET%\Schema\UANodeSet.xsd"
	COPY "%SCHEMAINPUT%\SecuredApplication.xsd" "%DOTNET_TARGET%\Schema\SecuredApplication.xsd"
	COPY "%SCHEMAINPUT%\OPCBinarySchema.xsd" "%DOTNET_TARGET%\Types\Schemas\OPCBinarySchema.xsd"

	CD "%DOTNET_TARGET%\Schema\"
	CALL BuildSchema
	CD %~dp0

	COPY "%OUTPUT%\Schema\Opc.Ua.NodeSet.xml" "%DOTNET_TARGET%\Schema\Opc.Ua.NodeSet.xml"
	COPY "%OUTPUT%\Schema\Opc.Ua.NodeSet2.xml" "%DOTNET_TARGET%\Schema\Opc.Ua.NodeSet2.xml"
	COPY "%OUTPUT%\Schema\Opc.Ua.Types.bsd" "%DOTNET_TARGET%\Schema\Opc.Ua.Types.bsd"
	COPY "%OUTPUT%\Schema\Opc.Ua.Types.xsd" "%DOTNET_TARGET%\Schema\Opc.Ua.Types.xsd"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Endpoints.wsdl" "%DOTNET_TARGET%\Schema\Opc.Ua.Endpoints.wsdl"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Services.wsdl" "%DOTNET_TARGET%\Schema\Opc.Ua.Services.wsdl"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Channels.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Channels.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Client.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Client.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Endpoints.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Endpoints.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Interfaces.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Interfaces.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Messages.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Messages.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.ServerBase.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.ServerBase.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.StatusCodes.cs" "%DOTNET_TARGET%\Types\Generated\Opc.Ua.StatusCodes.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Attributes.cs" "%DOTNET_TARGET%\Types\Generated\Opc.Ua.Attributes.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Classes.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Classes.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.Constants.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Constants.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.DataTypes.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.DataTypes.cs"
	COPY "%OUTPUT%\DotNet\Opc.Ua.PredefinedNodes.uanodes" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.PredefinedNodes.uanodes"
	COPY "%OUTPUT%\DotNet\Opc.Ua.PredefinedNodes.xml" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.PredefinedNodes.xml"
)

IF EXIST "%DEMOMODEL_TARGET%" (
	ECHO Copying .NET code to %DEMOMODEL_TARGET%
	COPY "%OUTPUT%\DemoModel\*.*" "%DEMOMODEL_TARGET%"
)
:skipcore

IF NOT "%3"=="GDS" GOTO skipGDS
CALL PublishModel OpcUaGdsModel GDS %1 %2
CALL UpdateLicense "%OUTPUT%\GDS"

IF "%GDS_TARGET%" NEQ "" (
	ECHO Copying .NET code to %GDS_TARGET%
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Types.bsd" "%DOTNET_TARGET%\Schema\Opc.Ua.Gds.Types.bsd"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Types.xsd" "%DOTNET_TARGET%\Schema\Opc.Ua.Gds.Types.xsd"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.NodeSet2.xml" "%DOTNET_TARGET%\Schema\Opc.Ua.Gds.NodeSet2.xml"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Constants.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Gds.Constants.cs"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.DataTypes.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Gds.DataTypes.cs"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Classes.cs" "%GDS_TARGET%\Opc.Ua.Gds.Classes.cs"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.PredefinedNodes.uanodes" "%GDS_TARGET%\Opc.Ua.Gds.PredefinedNodes.uanodes"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.PredefinedNodes.xml" "%GDS_TARGET%\Opc.Ua.Gds.PredefinedNodes.xml"
)
:skipGDS

IF NOT "%3"=="DI" GOTO skipDI
CALL PublishModel OpcUaDiModel DI %1 %2
CALL UpdateLicense "%OUTPUT%\DI"

IF EXIST "%DI_TARGET%" (
	ECHO Copying .NET code to %DI_TARGET%
	COPY "%OUTPUT%\DI\*.*" "%DI_TARGET%"
)
:skipDI

IF NOT "%3"=="ADI" GOTO skipADI
CALL PublishModel OpcUaDiModel ADI %1 %2
CALL UpdateLicense "%OUTPUT%\ADI"

IF EXIST "%ADI_TARGET%" (
	ECHO Copying .NET code to %ADI_TARGET%
	COPY "%OUTPUT%\ADI\*.*" "%ADI_TARGET%"
)
:skipADI

IF NOT "%3"=="Onboarding" GOTO skipOnboarding
ECHO Building Model Onboarding
IF NOT EXIST "%OUTPUT%\Onboarding" MKDIR "%OUTPUT%\Onboarding"
ECHO %MODELCOMPILER% compile %VERSION% %EXCLUDE% -d2 "%INPUT%\OpcUaOnboardingModel.xml" -d2 "%INPUT%\OpcUaGdsModel.xml" -c "%CSVINPUT%\OpcUaOnboardingModel.csv" -o2 "%OUTPUT%\Onboarding\\" %USEALLOWSUBTYPES%
%MODELCOMPILER% compile %VERSION% %EXCLUDE% -d2 "%INPUT%\OpcUaOnboardingModel.xml" -d2 "%INPUT%\OpcUaGdsModel.xml" -c "%CSVINPUT%\OpcUaOnboardingModel.csv" -o2 "%OUTPUT%\Onboarding\\" %USEALLOWSUBTYPES%

ECHO Copying Model files to %OUTPUT%
COPY "%INPUT%\OpcUaOnboardingModel.xml" "%OUTPUT%\Onboarding\OpcUaOnboardingModel.xml"
TYPE "%CSVINPUT%\OpcUaOnboardingModel.csv" | FINDSTR /V /E Unspecified > "%OUTPUT%\Onboarding\OpcUaOnboardingModel.csv"
DEL /f /q "%OUTPUT%\Onboarding\*NodeSet.xml"

CALL UpdateLicense "%OUTPUT%\Onboarding"

IF EXIST "%ONBOARDING_TARGET%" (
	ECHO Copying .NET code to %ONBOARDING_TARGET%
	COPY "%OUTPUT%\Onboarding\*.*" "%ONBOARDING_TARGET%"
)
:skipOnboarding

IF NOT "%3"=="Scheduler" GOTO skipScheduler
CALL PublishModel OpcUaSchedulerModel Scheduler %1 %2
CALL UpdateLicense "%OUTPUT%\Scheduler"

IF EXIST "%SCHEDULER_TARGET%" (
	ECHO Copying .NET code to %SCHEDULER_TARGET%
	COPY "%OUTPUT%\Scheduler\*.*" "%SCHEDULER_TARGET%"
)
:skipScheduler 

IF NOT "%3"=="NodeSet" GOTO skipNodeSet
CALL PublishModel OpcUaNodeSetModel NodeSet %1 %2
CALL UpdateLicense "%OUTPUT%\NodeSet"

IF EXIST "%NODESET_TARGET%" (
	ECHO Copying .NET code to %NODESET_TARGET%
	COPY "%OUTPUT%\NodeSet\*.*" "%NODESET_TARGET%"
)
:skipNodeSet

GOTO theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL
