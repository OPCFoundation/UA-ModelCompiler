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
set OUTPUT=..\nodesets
set INPUT=.\ModelCompiler\Design

IF NOT "%1"=="" (set OUTPUT=%OUTPUT%\%1) else (set OUTPUT=%OUTPUT%\master)
IF NOT "%1"=="" (set INPUT=%INPUT%.%1) else (set INPUT=%INPUT%.v104)
IF NOT "%1"=="" set VERSION=-version %1
IF NOT "%2"=="" set EXCLUDE=-exclude %2

REM Set the following values to automatically copy the generated source code to your relevant stack locations
REM
REM for example:
REM 	set ANSIC_TARGET=..\..\uastack\Source\Ansi C Stack\
REM 	set DOTNET_TARGET=..\..\uastack\Source\Common\Core\
REM 	set DI_TARGET=..\..\uastack\Source\Common\Core\Stack\Generated\
REM 	set ADI_TARGET=..\..\uastack\Source\Common\Core\Stack\Generated\
REM
REM Leaving these fields empty will skip the operation

set ANSIC_TARGET=
set DOTNET_TARGET=
set GDS_TARGET=
set DI_TARGET=
set ADI_TARGET=

REM Make sure that all of our output locations exist..

IF NOT EXIST %MODELCOMPILER% GOTO noModelCompiler
IF NOT EXIST %OUTPUT% MKDIR %OUTPUT%
IF NOT EXIST %OUTPUT%\Schema MKDIR %OUTPUT%\Schema
IF NOT EXIST %OUTPUT%\DotNet MKDIR %OUTPUT%\DotNet
IF NOT EXIST %OUTPUT%\AnsiC MKDIR %OUTPUT%\AnsiC

REM STEP 1) Generate all of our files first...

SET PARTNAME="StandardTypes"
ECHO Building Model %PARTNAME%
ECHO %MODELCOMPILER% -d2 "%INPUT%\StandardTypes.xml" %VERSION% %EXCLUDE% -d2 "%INPUT%\UA Core Services.xml" -c "%INPUT%\StandardTypes.csv" -o2 "%OUTPUT%\Schema\" -stack "%OUTPUT%\DotNet\" -ansic "%OUTPUT%\AnsiC\"
%MODELCOMPILER% -d2 "%INPUT%\StandardTypes.xml" %VERSION% %EXCLUDE% -d2 "%INPUT%\UA Core Services.xml" -c "%INPUT%\StandardTypes.csv" -o2 "%OUTPUT%\Schema\" -stack "%OUTPUT%\DotNet\" -ansic "%OUTPUT%\AnsiC\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 1 )

CALL PublishModel OpcUaGdsModel GDS %1 %2
CALL PublishModel OpcUaDiModel DI %1 %2

IF "%1"=="v105" (
	CALL PublishModel OpcUaAdiModel ADI "" %2
	CALL PublishModel OpcUaPLCopenModel PLCopen "" %2
	CALL PublishModel MTConnectModel MTConnect "" %2
	CALL PublishModel OpcUaFDIPart5Model FDI "" %2
	CALL PublishModel OpcUaFDIPart7Model FDI "" %2
	CALL PublishModel MDIS MDIS "" %2
	CALL PublishModel SercosModel Sercos "" %2
)

IF "%1"=="v104" (
	CALL PublishModel OpcUaAdiModel ADI %1 %2
	CALL PublishModel OpcUaPLCopenModel PLCopen %1 %2
	CALL PublishModel MTConnectModel MTConnect %1 %2
	CALL PublishModel OpcUaFDIPart5Model FDI %1 %2
	CALL PublishModel OpcUaFDIPart7Model FDI %1 %2
	CALL PublishModel MDIS MDIS %1 %2
	CALL PublishModel SercosModel Sercos %1 %2
)

IF "%1"=="v103" (
	CALL PublishModel OpcUaAdiModel ADI %1 %2
	CALL PublishModel OpcUaPLCopenModel PLCopen %1 %2
	CALL PublishModel MTConnectModel MTConnect %1 %2
	CALL PublishModel OpcUaFDIPart5Model FDI %1 %2
	CALL PublishModel OpcUaFDIPart7Model FDI %1 %2
	CALL PublishModel MDIS MDIS %1 %2
	CALL PublishModel SercosModel Sercos %1 %2
)

REM SET PARTNAME="DemoModel"
REM ECHO Building %PARTNAME%
REM IF NOT EXIST %OUTPUT%\DemoModel MKDIR %OUTPUT%\DemoModel
REM %MODELCOMPILER% -d2 "%INPUT%\DemoModel.xml" -cg "%INPUT%\DemoModel.csv" -o2 "%OUTPUT%\DemoModel\"
REM IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 5 )

REM STEP 2) Copy the generated files to the OUTPUT directory which is how our nodeset files are created...

ECHO Copying CSV files to %OUTPUT%\Schema\
ECHO ON
COPY "%INPUT%\StandardTypes.csv" "%OUTPUT%\Schema\NodeIds.csv"
COPY "%INPUT%\UA Attributes.csv" "%OUTPUT%\Schema\AttributeIds.csv"
COPY "%OUTPUT%\DotNet\Opc.Ua.StatusCodes.csv" "%OUTPUT%\Schema\StatusCode.csv"
COPY ".\Core\Schema\UANodeSet.xsd" "%OUTPUT%\Schema\UANodeSet.xsd"
COPY ".\Core\Schema\SecuredApplication.xsd" "%OUTPUT%\Schema\SecuredApplication.xsd"
COPY ".\Core\Types\Schemas\OPCBinarySchema.xsd" "%OUTPUT%\Schema\OPCBinarySchema.xsd"
COPY ".\Core\Schema\ServerCapabilities.csv" "%OUTPUT%\Schema\ServerCapabilities.csv"
@ECHO OFF

REM STEP 2a) Copy code to ANSIC
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

REM STEP 2b) Copy code to .NET
IF "%DOTNET_TARGET%" NEQ "" (
	ECHO Copying .NET code to %DOTNET_TARGET%
	@ECHO OFF
	COPY "%OUTPUT%\Schema\AttributeIds.csv" "%DOTNET_TARGET%\Schema\AttributeIds.csv"
	COPY "%OUTPUT%\Schema\NodeIds.csv" "%DOTNET_TARGET%\Schema\NodeIds.csv"
	COPY "%OUTPUT%\Schema\ServerCapabilities.csv" "%DOTNET_TARGET%\Schema\ServerCapabilities.csv"
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
	COPY "%OUTPUT%\Schema\Opc.Ua.Classes.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Classes.cs"
	COPY "%OUTPUT%\Schema\Opc.Ua.Constants.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.Constants.cs"
	COPY "%OUTPUT%\Schema\Opc.Ua.DataTypes.cs" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.DataTypes.cs"
	COPY "%OUTPUT%\Schema\Opc.Ua.PredefinedNodes.uanodes" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.PredefinedNodes.uanodes"
	COPY "%OUTPUT%\Schema\Opc.Ua.PredefinedNodes.xml" "%DOTNET_TARGET%\Stack\Generated\Opc.Ua.PredefinedNodes.xml"
	ECHO ON
)

REM STEP 2b) Copy code to GDS 
IF "%GDS_TARGET%" NEQ "" (
	ECHO Copying GDS code to %GDS_TARGET%
	@ECHO OFF
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Types.bsd" "%GDS_TARGET%\Stack\Core\Schema\Opc.Ua.Gds.Types.bsd"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Types.xsd" "%GDS_TARGET%\Stack\Core\Schema\Opc.Ua.Gds.Types.xsd"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.NodeSet2.xml" "%GDS_TARGET%\Stack\Core\Schema\Opc.Ua.Gds.NodeSet2.xml"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Constants.cs" "%GDS_TARGET%\Stack\Core\Stack\Generated\Opc.Ua.Gds.Constants.cs"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.DataTypes.cs" "%GDS_TARGET%\Stack\Core\Stack\Generated\Opc.Ua.Gds.DataTypes.cs"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.Classes.cs" "%GDS_TARGET%\GDS\Server\Model\Opc.Ua.Gds.Classes.cs"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.PredefinedNodes.uanodes" "%GDS_TARGET%\GDS\Server\Model\Opc.Ua.Gds.PredefinedNodes.uanodes"
	COPY "%OUTPUT%\GDS\Opc.Ua.Gds.PredefinedNodes.xml" "%GDS_TARGET%\GDS\Server\Model\Opc.Ua.Gds.PredefinedNodes.xml"
	ECHO ON
)

REM STEP 2c) Copy remaining collaboration outputs to their respective locations...
IF "%DI_TARGET%" NEQ "" (
	COPY "%OUTPUT%\DI\*.*" "%DI_TARGET%"
)

IF "%ADI_TARGET%" NEQ "" (
	COPY "%OUTPUT%\ADI\*.*" "%ADI_TARGET%"
)

IF "%PLCOPEN_TARGET%" NEQ "" (
	COPY "%OUTPUT%\ADI\*.*" "%PLCOPEN_TARGET%"
)

ECHO Updating License
ECHO ON
%MODELCOMPILER% -input %OUTPUT% -pattern *.xml -license MITXML -silent
%MODELCOMPILER% -input %OUTPUT% -pattern *.xsd -license MITXML -silent
%MODELCOMPILER% -input %OUTPUT% -pattern *.bsd -license MITXML -silent
%MODELCOMPILER% -input %OUTPUT% -pattern *.cs -license MIT -silent
%MODELCOMPILER% -input %OUTPUT% -pattern *.h -license MIT -silent
%MODELCOMPILER% -input %OUTPUT% -pattern *.c -license MIT -silent
@ECHO OFF

GOTO theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL