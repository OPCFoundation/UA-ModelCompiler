@ECHO off
REM ****************************************************************************************************************
REM ** Nathan Pocock (nathan.pocock@opcfoundation.org) https://opcfoundation.org/
REM ** --
REM ** This script demonstrates how to use the model compiler to generate source code from a variety
REM ** of XML files that adhere to the 'Nodeset2.xml' format. Please refer to the UA Specifications Part 6
REM ** for more information.
REM ** --
REM ****************************************************************************************************************
SETLOCAL

set MODELCOMPILER=.\Bin\Release\Opc.Ua.ModelCompiler.exe
set OUTPUT=.\Published

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
ECHO Building %PARTNAME%
%MODELCOMPILER% -d2 ".\ModelCompiler\Design\StandardTypes.xml" -d2 ".\ModelCompiler\Design\UA Core Services.xml" -c ".\ModelCompiler\Design\StandardTypes.csv" -o2 "%OUTPUT%\Schema\" -stack "%OUTPUT%\DotNet\" -ansic "%OUTPUT%\AnsiC\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 1 )

SET PARTNAME="GDS"
ECHO Building %PARTNAME%
IF NOT EXIST %OUTPUT%\GDS MKDIR %OUTPUT%\GDS
%MODELCOMPILER% -d2 ".\ModelCompiler\Design\OpcUaGdsModel.xml" -cg ".\ModelCompiler\Design\OpcUaGdsModel.csv" -o2 "%OUTPUT%\GDS\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 2 )

SET PARTNAME="DI"
ECHO Building %PARTNAME%
IF NOT EXIST %OUTPUT%\DI MKDIR %OUTPUT%\DI
%MODELCOMPILER% -d2 ".\ModelCompiler\Design\OpcUaDiModel.xml" -cg ".\ModelCompiler\Design\OpcUaDiModel.csv" -o2 "%OUTPUT%\DI\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 3 )

SET PARTNAME="ADI"
ECHO Building %PARTNAME%
IF NOT EXIST %OUTPUT%\ADI MKDIR %OUTPUT%\ADI
%MODELCOMPILER% -d2 ".\ModelCompiler\Design\OpcUaAdiModel.xml" -cg ".\ModelCompiler\Design\OpcUaAdiModel.csv" -o2 "%OUTPUT%\ADI\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 4 )

SET PARTNAME="PLCopen"
ECHO Building %PARTNAME%
IF NOT EXIST %OUTPUT%\PLCopen MKDIR %OUTPUT%\PLCopen
%MODELCOMPILER% -d2 ".\ModelCompiler\Design\OpcUaPLCopenModel.xml" -cg ".\ModelCompiler\Design\OpcUaPLCopenModel.csv" -o2 "%OUTPUT%\PLCopen\"
IF %ERRORLEVEL% NEQ 0 ( ECHO Failed %PARTNAME% & EXIT /B 5 )

REM STEP 2) Copy the generated files to the OUTPUT directory which is how our nodeset files are created...

ECHO Copying CSV files to %OUTPUT%\Schema\
ECHO ON
COPY ".\ModelCompiler\Design\StandardTypes.csv" "%OUTPUT%\Schema\NodeIds.csv"
COPY ".\ModelCompiler\Design\UA Attributes.csv" "%OUTPUT%\Schema\AttributeIds.csv"
COPY ".\Core\Schema\UANodeSet.xsd" "%OUTPUT%\Schema\UANodeSet.xsd"
COPY ".\Core\Schema\SecuredApplication.xsd" "%OUTPUT%\Schema\SecuredApplication.xsd"
COPY ".\Core\Types\Schemas\OPCBinarySchema.xsd" "%OUTPUT%\Schema\OPCBinarySchema.xsd"
@ECHO OFF

REM STEP 2a) Copy code to ANSIC
IF "%ANSIC_TARGET%" NEQ "" (
	ECHO Copying ANSIC code to %ANSIC_TARGET%
	ECHO ON
	COPY "%OUTPUT%\AnsiC\opcua_statuscodes.h" "%ANSIC_TARGET%\core\"
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

GOTO theEnd

:noModelCompiler
ECHO.
ECHO ModelCompiler not found. Please make sure it is compiled in RELEASE mode.
ECHO Searched for: %MODELCOMPILER%

:theEnd
ENDLOCAL