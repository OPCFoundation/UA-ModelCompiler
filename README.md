# Model Compiler #
The [OPC Foundation](https://opcfoundation.org) Model Compiler will generate C# and ANSI C source code from XML files which include the UA Services, data-types, error codes, etc.; and numerous CSV files that contain NodeIds, error codes, and attributes etc.

## Example Generation ##
The following process will demonstrate how to generate code using the supplied nodeset files:
1. Clone the repository and then build the source in Visual Studio 2015, in Release mode.
2. Open a Command prompt and then launch the BuildStandardTypes.bat
3. After the script completes, navigate to the .\Published folder to view the output.
4. Optionally, modify the BAT file and specify the location of your UA Stack(s) to automatically copy the generated files.

### XML Files ###
#### UA Services example ####
An excerpt of the Core Services.xml file is shown below:
```
<?xml version="1.0" encoding="utf-8" ?>
<opc:TypeDictionary
  xmlns:s0="http://opcfoundation.org/UA/BuiltInTypes/"
  xmlns:s1="http://opcfoundation.org/UA/Core/DataTypes/"
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns:opc="http://opcfoundation.org/UA/TypeDictionary/"
  xmlns="http://opcfoundation.org/UA/Core/"
  TargetNamespace="http://opcfoundation.org/UA/Core/"
>
  <opc:Import Namespace="http://opcfoundation.org/UA/BuiltInTypes/" />
  <opc:ServiceType Name="Read">
    <opc:Request>
      <opc:Parameter Name="RequestHeader" DataType="RequestHeader" />
      <opc:Parameter Name="MaxAge" DataType="Duration" />
      <opc:Parameter Name="TimestampsToReturn" DataType="TimestampsToReturn" />
      <opc:Parameter Name="NodesToRead" DataType="ReadValueId" ValueRank="0" />
    </opc:Request>
    <opc:Response>
      <opc:Parameter Name="ResponseHeader" DataType="ResponseHeader" />
      <opc:Parameter Name="Results" DataType="s0:DataValue" ValueRank="0" />
      <opc:Parameter Name="DiagnosticInfos" DataType="s0:DiagnosticInfo" ValueRank="0" />
    </opc:Response>
  </opc:ServiceType>
```
#### Standard Data Types example ####
Nodeset files are defined in [UA Specifications Part 6](https://opcfoundation.org/developer-tools/specifications-unified-architecture/part-6-mappings/). An excerpt of the standard types nodeset is shown here:
```
?xml version="1.0" encoding="utf-8" ?>
<opc:ModelDesign
  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
  xmlns:xsd="http://www.w3.org/2001/XMLSchema"
  xmlns:opc="http://opcfoundation.org/UA/ModelDesign.xsd"
  xmlns:ua="http://opcfoundation.org/UA/"
  xmlns="http://opcfoundation.org/UA/"
  xmlns:uax="http://opcfoundation.org/UA/2008/02/Types.xsd"
  TargetNamespace="http://opcfoundation.org/UA/"
  TargetNamespaceVersion="1.02"
>
  <opc:Namespaces>
    <opc:Namespace Name="OpcUa" Prefix="Opc.Ua" InternalPrefix="Opc.Ua.Server" XmlNamespace="http://opcfoundation.org/UA/2008/02/Types.xsd">http://opcfoundation.org/UA/</opc:Namespace>
  </opc:Namespaces>

  <opc:Property SymbolicName="NodeVersion" DataType="ua:String" PartNo="3">
    <opc:Description>The version number of the node (used to indicate changes to references of the owning node).</opc:Description>
  </opc:Property>

  <opc:Property SymbolicName="ViewVersion" DataType="ua:UInt32" PartNo="3">
    <opc:Description>The version number of the view.</opc:Description>
  </opc:Property>
```
#### Status Codes example ####
The following excerpt is of the Statuscodes:
```
Bad_UnexpectedError,1
Bad_InternalError,2
Bad_OutOfMemory,3
Bad_ResourceUnavailable,4
Bad_CommunicationError,5
Bad_EncodingError,6
Bad_DecodingError,7
Bad_EncodingLimitsExceeded,8
Bad_UnknownResponse,9
Bad_Timeout,10
```
### Example Code Generation Output ###
The following are just snippets that demonstrate the output of the model compiler for different languages:
#### C# ####
```
using System;
using System.Collections.Generic;

namespace Opc.Ua
{
    #region ISessionServer Interface
    /// <summary>
    /// An interface to a UA server implementation.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.CodeGenerator", "1.0.0.0")]
    public interface ISessionServer : IServerBase
    {
        #if (!OPCUA_EXCLUDE_FindServers)
        /// <summary>
        /// Invokes the FindServers service.
        /// </summary>
        ResponseHeader FindServers(
            RequestHeader                        requestHeader,
            string                               endpointUrl,
            StringCollection                     localeIds,
            StringCollection                     serverUris,
            out ApplicationDescriptionCollection servers);
        #endif
```
#### ANSI C ####
```
#ifndef _OpcUa_ServerApi_H_
#define _OpcUa_ServerApi_H_ 1
#ifdef OPCUA_HAVE_SERVERAPI

#include <opcua_types.h>
#include <opcua_endpoint.h>

OPCUA_BEGIN_EXTERN_C

#ifndef OPCUA_EXCLUDE_FindServers
/*============================================================================
 * Synchronously calls the FindServers service.
 *===========================================================================*/
OpcUa_StatusCode OpcUa_ServerApi_FindServers(
    OpcUa_Endpoint                 hEndpoint,
    OpcUa_Handle                   hContext,
    const OpcUa_RequestHeader*     pRequestHeader,
    const OpcUa_String*            pEndpointUrl,
    OpcUa_Int32                    nNoOfLocaleIds,
    const OpcUa_String*            pLocaleIds,
    OpcUa_Int32                    nNoOfServerUris,
    const OpcUa_String*            pServerUris,
    OpcUa_ResponseHeader*          pResponseHeader,
    OpcUa_Int32*                   pNoOfServers,
    OpcUa_ApplicationDescription** pServers);
```
## Other Repositories ##
This ModelCompiler is used to generate the content of the [Nodeset GitHub repository](https://github.com/OPCFoundation/UA-Nodeset).
