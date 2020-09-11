/* ========================================================================
 * Copyright (c) 2005-2020 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace Opc.Ua.UANodeSet
{
    #region DataType Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <summary>
        /// The identifier for the ModelTableEntry DataType.
        /// </summary>
        public const uint ModelTableEntry = 1;

        /// <summary>
        /// The identifier for the UANodeSet DataType.
        /// </summary>
        public const uint UANodeSet = 202;

        /// <summary>
        /// The identifier for the UAReference DataType.
        /// </summary>
        public const uint UAReference = 203;

        /// <summary>
        /// The identifier for the UANode DataType.
        /// </summary>
        public const uint UANode = 4;

        /// <summary>
        /// The identifier for the UAType DataType.
        /// </summary>
        public const uint UAType = 5;

        /// <summary>
        /// The identifier for the UAObjectType DataType.
        /// </summary>
        public const uint UAObjectType = 6;

        /// <summary>
        /// The identifier for the NamedTranslationType DataType.
        /// </summary>
        public const uint NamedTranslationType = 2;

        /// <summary>
        /// The identifier for the UAVariableType DataType.
        /// </summary>
        public const uint UAVariableType = 8;

        /// <summary>
        /// The identifier for the UADataType DataType.
        /// </summary>
        public const uint UADataType = 9;

        /// <summary>
        /// The identifier for the UAReferenceType DataType.
        /// </summary>
        public const uint UAReferenceType = 10;

        /// <summary>
        /// The identifier for the UAInstance DataType.
        /// </summary>
        public const uint UAInstance = 11;

        /// <summary>
        /// The identifier for the UAObject DataType.
        /// </summary>
        public const uint UAObject = 12;

        /// <summary>
        /// The identifier for the UAVariable DataType.
        /// </summary>
        public const uint UAVariable = 13;

        /// <summary>
        /// The identifier for the UAMethod DataType.
        /// </summary>
        public const uint UAMethod = 15;

        /// <summary>
        /// The identifier for the UAView DataType.
        /// </summary>
        public const uint UAView = 16;
    }
    #endregion

    #region Method Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Open = 31;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Close = 34;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Read = 36;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Write = 39;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition = 41;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition = 44;
    }
    #endregion

    #region Object Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata Object.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata = 17;

        /// <summary>
        /// The identifier for the ModelTableEntry_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint ModelTableEntry_Encoding_DefaultBinary = 50;

        /// <summary>
        /// The identifier for the UANodeSet_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UANodeSet_Encoding_DefaultBinary = 204;

        /// <summary>
        /// The identifier for the UAReference_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAReference_Encoding_DefaultBinary = 205;

        /// <summary>
        /// The identifier for the UANode_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UANode_Encoding_DefaultBinary = 53;

        /// <summary>
        /// The identifier for the UAType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAType_Encoding_DefaultBinary = 54;

        /// <summary>
        /// The identifier for the UAObjectType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAObjectType_Encoding_DefaultBinary = 55;

        /// <summary>
        /// The identifier for the NamedTranslationType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint NamedTranslationType_Encoding_DefaultBinary = 3;

        /// <summary>
        /// The identifier for the UAVariableType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAVariableType_Encoding_DefaultBinary = 57;

        /// <summary>
        /// The identifier for the UADataType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UADataType_Encoding_DefaultBinary = 58;

        /// <summary>
        /// The identifier for the UAReferenceType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAReferenceType_Encoding_DefaultBinary = 59;

        /// <summary>
        /// The identifier for the UAInstance_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAInstance_Encoding_DefaultBinary = 60;

        /// <summary>
        /// The identifier for the UAObject_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAObject_Encoding_DefaultBinary = 61;

        /// <summary>
        /// The identifier for the UAVariable_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAVariable_Encoding_DefaultBinary = 62;

        /// <summary>
        /// The identifier for the UAMethod_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAMethod_Encoding_DefaultBinary = 64;

        /// <summary>
        /// The identifier for the UAView_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint UAView_Encoding_DefaultBinary = 65;

        /// <summary>
        /// The identifier for the ModelTableEntry_Encoding_DefaultXml Object.
        /// </summary>
        public const uint ModelTableEntry_Encoding_DefaultXml = 118;

        /// <summary>
        /// The identifier for the UANodeSet_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UANodeSet_Encoding_DefaultXml = 212;

        /// <summary>
        /// The identifier for the UAReference_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAReference_Encoding_DefaultXml = 213;

        /// <summary>
        /// The identifier for the UANode_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UANode_Encoding_DefaultXml = 121;

        /// <summary>
        /// The identifier for the UAType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAType_Encoding_DefaultXml = 122;

        /// <summary>
        /// The identifier for the UAObjectType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAObjectType_Encoding_DefaultXml = 123;

        /// <summary>
        /// The identifier for the NamedTranslationType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint NamedTranslationType_Encoding_DefaultXml = 74;

        /// <summary>
        /// The identifier for the UAVariableType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAVariableType_Encoding_DefaultXml = 125;

        /// <summary>
        /// The identifier for the UADataType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UADataType_Encoding_DefaultXml = 126;

        /// <summary>
        /// The identifier for the UAReferenceType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAReferenceType_Encoding_DefaultXml = 127;

        /// <summary>
        /// The identifier for the UAInstance_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAInstance_Encoding_DefaultXml = 128;

        /// <summary>
        /// The identifier for the UAObject_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAObject_Encoding_DefaultXml = 129;

        /// <summary>
        /// The identifier for the UAVariable_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAVariable_Encoding_DefaultXml = 130;

        /// <summary>
        /// The identifier for the UAMethod_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAMethod_Encoding_DefaultXml = 132;

        /// <summary>
        /// The identifier for the UAView_Encoding_DefaultXml Object.
        /// </summary>
        public const uint UAView_Encoding_DefaultXml = 133;

        /// <summary>
        /// The identifier for the ModelTableEntry_Encoding_DefaultJson Object.
        /// </summary>
        public const uint ModelTableEntry_Encoding_DefaultJson = 186;

        /// <summary>
        /// The identifier for the UANodeSet_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UANodeSet_Encoding_DefaultJson = 220;

        /// <summary>
        /// The identifier for the UAReference_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAReference_Encoding_DefaultJson = 221;

        /// <summary>
        /// The identifier for the UANode_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UANode_Encoding_DefaultJson = 189;

        /// <summary>
        /// The identifier for the UAType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAType_Encoding_DefaultJson = 190;

        /// <summary>
        /// The identifier for the UAObjectType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAObjectType_Encoding_DefaultJson = 191;

        /// <summary>
        /// The identifier for the NamedTranslationType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint NamedTranslationType_Encoding_DefaultJson = 78;

        /// <summary>
        /// The identifier for the UAVariableType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAVariableType_Encoding_DefaultJson = 193;

        /// <summary>
        /// The identifier for the UADataType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UADataType_Encoding_DefaultJson = 194;

        /// <summary>
        /// The identifier for the UAReferenceType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAReferenceType_Encoding_DefaultJson = 195;

        /// <summary>
        /// The identifier for the UAInstance_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAInstance_Encoding_DefaultJson = 196;

        /// <summary>
        /// The identifier for the UAObject_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAObject_Encoding_DefaultJson = 197;

        /// <summary>
        /// The identifier for the UAVariable_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAVariable_Encoding_DefaultJson = 198;

        /// <summary>
        /// The identifier for the UAMethod_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAMethod_Encoding_DefaultJson = 200;

        /// <summary>
        /// The identifier for the UAView_Encoding_DefaultJson Object.
        /// </summary>
        public const uint UAView_Encoding_DefaultJson = 201;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceUri = 18;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceVersion = 19;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespacePublicationDate = 20;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_IsNamespaceSubset = 21;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_StaticNodeIdTypes = 22;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_StaticNumericNodeIdRange = 23;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_StaticStringNodeIdPattern = 24;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Size = 26;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Writable = 27;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_UserWritable = 28;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_OpenCount = 29;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_InputArguments = 32;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_OutputArguments = 33;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Close_InputArguments = 35;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_InputArguments = 37;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_OutputArguments = 38;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_Write_InputArguments = 40;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 42;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 43;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 45;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_DefaultRolePermissions = 47;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_DefaultUserRolePermissions = 48;

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public const uint OPCUANodeSetNamespaceMetadata_DefaultAccessRestrictions = 49;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema = 66;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_NamespaceUri = 68;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_Deprecated Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_Deprecated = 69;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_ModelTableEntry Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_ModelTableEntry = 70;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UANodeSet Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UANodeSet = 206;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAReference Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAReference = 209;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UANode Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UANode = 79;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAType = 82;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAObjectType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAObjectType = 85;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_NamedTranslationType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_NamedTranslationType = 51;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAVariableType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAVariableType = 91;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UADataType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UADataType = 94;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAReferenceType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAReferenceType = 97;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAInstance Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAInstance = 100;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAObject Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAObject = 103;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAVariable Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAVariable = 106;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAMethod Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAMethod = 112;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAView Variable.
        /// </summary>
        public const uint OpcUaNodeSet_BinarySchema_UAView = 115;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema = 134;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_NamespaceUri = 136;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_Deprecated Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_Deprecated = 137;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_ModelTableEntry Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_ModelTableEntry = 138;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UANodeSet Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UANodeSet = 214;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAReference Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAReference = 217;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UANode Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UANode = 147;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAType = 150;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAObjectType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAObjectType = 153;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_NamedTranslationType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_NamedTranslationType = 75;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAVariableType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAVariableType = 159;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UADataType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UADataType = 162;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAReferenceType Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAReferenceType = 165;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAInstance Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAInstance = 168;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAObject Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAObject = 171;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAVariable Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAVariable = 174;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAMethod Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAMethod = 180;

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAView Variable.
        /// </summary>
        public const uint OpcUaNodeSet_XmlSchema_UAView = 183;
    }
    #endregion

    #region DataType Node Identifiers
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <summary>
        /// The identifier for the ModelTableEntry DataType.
        /// </summary>
        public static readonly ExpandedNodeId ModelTableEntry = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.ModelTableEntry, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANodeSet DataType.
        /// </summary>
        public static readonly ExpandedNodeId UANodeSet = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UANodeSet, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReference DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAReference = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAReference, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANode DataType.
        /// </summary>
        public static readonly ExpandedNodeId UANode = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UANode, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAType DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAType = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObjectType DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAObjectType = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAObjectType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the NamedTranslationType DataType.
        /// </summary>
        public static readonly ExpandedNodeId NamedTranslationType = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.NamedTranslationType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariableType DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAVariableType = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAVariableType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UADataType DataType.
        /// </summary>
        public static readonly ExpandedNodeId UADataType = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UADataType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReferenceType DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAReferenceType = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAReferenceType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAInstance DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAInstance = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAInstance, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObject DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAObject = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAObject, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariable DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAVariable = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAVariable, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAMethod DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAMethod = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAMethod, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAView DataType.
        /// </summary>
        public static readonly ExpandedNodeId UAView = new ExpandedNodeId(Opc.Ua.UANodeSet.DataTypes.UAView, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);
    }
    #endregion

    #region Method Node Identifiers
    /// <summary>
    /// A class that declares constants for all Methods in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Open Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(Opc.Ua.UANodeSet.Methods.OPCUANodeSetNamespaceMetadata_NamespaceFile_Open, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Close Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(Opc.Ua.UANodeSet.Methods.OPCUANodeSetNamespaceMetadata_NamespaceFile_Close, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Read Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(Opc.Ua.UANodeSet.Methods.OPCUANodeSetNamespaceMetadata_NamespaceFile_Read, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Write Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(Opc.Ua.UANodeSet.Methods.OPCUANodeSetNamespaceMetadata_NamespaceFile_Write, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(Opc.Ua.UANodeSet.Methods.OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition Method.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(Opc.Ua.UANodeSet.Methods.OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);
    }
    #endregion

    #region Object Node Identifiers
    /// <summary>
    /// A class that declares constants for all Objects in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata Object.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.OPCUANodeSetNamespaceMetadata, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the ModelTableEntry_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId ModelTableEntry_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.ModelTableEntry_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANodeSet_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UANodeSet_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UANodeSet_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReference_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAReference_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAReference_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANode_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UANode_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UANode_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAType_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObjectType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAObjectType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAObjectType_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the NamedTranslationType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId NamedTranslationType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.NamedTranslationType_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariableType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAVariableType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAVariableType_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UADataType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UADataType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UADataType_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReferenceType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAReferenceType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAReferenceType_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAInstance_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAInstance_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAInstance_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObject_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAObject_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAObject_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariable_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAVariable_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAVariable_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAMethod_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAMethod_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAMethod_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAView_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId UAView_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAView_Encoding_DefaultBinary, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the ModelTableEntry_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId ModelTableEntry_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.ModelTableEntry_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANodeSet_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UANodeSet_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UANodeSet_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReference_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAReference_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAReference_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANode_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UANode_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UANode_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAType_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObjectType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAObjectType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAObjectType_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the NamedTranslationType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId NamedTranslationType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.NamedTranslationType_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariableType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAVariableType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAVariableType_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UADataType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UADataType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UADataType_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReferenceType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAReferenceType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAReferenceType_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAInstance_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAInstance_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAInstance_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObject_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAObject_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAObject_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariable_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAVariable_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAVariable_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAMethod_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAMethod_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAMethod_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAView_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId UAView_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAView_Encoding_DefaultXml, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the ModelTableEntry_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId ModelTableEntry_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.ModelTableEntry_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANodeSet_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UANodeSet_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UANodeSet_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReference_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAReference_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAReference_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UANode_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UANode_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UANode_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAType_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObjectType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAObjectType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAObjectType_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the NamedTranslationType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId NamedTranslationType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.NamedTranslationType_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariableType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAVariableType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAVariableType_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UADataType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UADataType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UADataType_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAReferenceType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAReferenceType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAReferenceType_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAInstance_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAInstance_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAInstance_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAObject_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAObject_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAObject_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAVariable_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAVariable_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAVariable_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAMethod_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAMethod_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAMethod_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the UAView_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId UAView_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.UANodeSet.Objects.UAView_Encoding_DefaultJson, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceUri = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceUri, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceVersion Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceVersion, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespacePublicationDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespacePublicationDate, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_IsNamespaceSubset Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_IsNamespaceSubset, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_StaticNodeIdTypes Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_StaticNodeIdTypes, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_StaticNumericNodeIdRange Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_StaticNumericNodeIdRange, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_StaticStringNodeIdPattern Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_StaticStringNodeIdPattern, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Size Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Size, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Writable Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Writable, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_UserWritable Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_UserWritable, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_OpenCount Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_OpenCount, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_InputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Open_OutputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Close_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Close_InputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_InputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Read_OutputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_Write_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_Write_InputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition_InputArguments Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_DefaultRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_DefaultRolePermissions, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_DefaultUserRolePermissions Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_DefaultUserRolePermissions, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OPCUANodeSetNamespaceMetadata_DefaultAccessRestrictions Variable.
        /// </summary>
        public static readonly ExpandedNodeId OPCUANodeSetNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OPCUANodeSetNamespaceMetadata_DefaultAccessRestrictions, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_NamespaceUri, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_Deprecated = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_Deprecated, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_ModelTableEntry Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_ModelTableEntry = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_ModelTableEntry, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UANodeSet Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UANodeSet = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UANodeSet, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAReference Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAReference = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAReference, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UANode Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UANode = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UANode, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAObjectType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAObjectType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAObjectType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_NamedTranslationType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_NamedTranslationType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_NamedTranslationType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAVariableType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAVariableType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAVariableType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UADataType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UADataType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UADataType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAReferenceType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAReferenceType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAReferenceType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAInstance Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAInstance = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAInstance, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAObject Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAObject = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAObject, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAVariable Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAVariable = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAVariable, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAMethod Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAMethod = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAMethod, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_BinarySchema_UAView Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_BinarySchema_UAView = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_BinarySchema_UAView, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_NamespaceUri, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_Deprecated = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_Deprecated, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_ModelTableEntry Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_ModelTableEntry = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_ModelTableEntry, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UANodeSet Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UANodeSet = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UANodeSet, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAReference Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAReference = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAReference, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UANode Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UANode = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UANode, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAObjectType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAObjectType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAObjectType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_NamedTranslationType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_NamedTranslationType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_NamedTranslationType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAVariableType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAVariableType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAVariableType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UADataType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UADataType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UADataType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAReferenceType Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAReferenceType = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAReferenceType, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAInstance Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAInstance = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAInstance, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAObject Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAObject = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAObject, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAVariable Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAVariable = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAVariable, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAMethod Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAMethod = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAMethod, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);

        /// <summary>
        /// The identifier for the OpcUaNodeSet_XmlSchema_UAView Variable.
        /// </summary>
        public static readonly ExpandedNodeId OpcUaNodeSet_XmlSchema_UAView = new ExpandedNodeId(Opc.Ua.UANodeSet.Variables.OpcUaNodeSet_XmlSchema_UAView, Opc.Ua.UANodeSet.Namespaces.OpcUaNodeSet);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the ModelTableEntry component.
        /// </summary>
        public const string ModelTableEntry = "ModelTableEntry";

        /// <summary>
        /// The BrowseName for the NamedTranslationType component.
        /// </summary>
        public const string NamedTranslationType = "NamedTranslationType";

        /// <summary>
        /// The BrowseName for the OpcUaNodeSet_BinarySchema component.
        /// </summary>
        public const string OpcUaNodeSet_BinarySchema = "Opc.Ua.UANodeSet";

        /// <summary>
        /// The BrowseName for the OpcUaNodeSet_XmlSchema component.
        /// </summary>
        public const string OpcUaNodeSet_XmlSchema = "Opc.Ua.UANodeSet";

        /// <summary>
        /// The BrowseName for the OPCUANodeSetNamespaceMetadata component.
        /// </summary>
        public const string OPCUANodeSetNamespaceMetadata = "http://opcfoundation.org/UA/NodeSet/";

        /// <summary>
        /// The BrowseName for the UADataType component.
        /// </summary>
        public const string UADataType = "UADataType";

        /// <summary>
        /// The BrowseName for the UAInstance component.
        /// </summary>
        public const string UAInstance = "UAInstance";

        /// <summary>
        /// The BrowseName for the UAMethod component.
        /// </summary>
        public const string UAMethod = "UAMethod";

        /// <summary>
        /// The BrowseName for the UANode component.
        /// </summary>
        public const string UANode = "UANode";

        /// <summary>
        /// The BrowseName for the UANodeSet component.
        /// </summary>
        public const string UANodeSet = "UANodeSet";

        /// <summary>
        /// The BrowseName for the UAObject component.
        /// </summary>
        public const string UAObject = "UAObject";

        /// <summary>
        /// The BrowseName for the UAObjectType component.
        /// </summary>
        public const string UAObjectType = "UAObjectType";

        /// <summary>
        /// The BrowseName for the UAReference component.
        /// </summary>
        public const string UAReference = "UAReference";

        /// <summary>
        /// The BrowseName for the UAReferenceType component.
        /// </summary>
        public const string UAReferenceType = "UAReferenceType";

        /// <summary>
        /// The BrowseName for the UAType component.
        /// </summary>
        public const string UAType = "UAType";

        /// <summary>
        /// The BrowseName for the UAVariable component.
        /// </summary>
        public const string UAVariable = "UAVariable";

        /// <summary>
        /// The BrowseName for the UAVariableType component.
        /// </summary>
        public const string UAVariableType = "UAVariableType";

        /// <summary>
        /// The BrowseName for the UAView component.
        /// </summary>
        public const string UAView = "UAView";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUaNodeSet namespace (.NET code namespace is 'Opc.Ua.UANodeSet').
        /// </summary>
        public const string OpcUaNodeSet = "http://opcfoundation.org/UA/NodeSet/";

        /// <summary>
        /// The URI for the OpcUaNodeSetXsd namespace (.NET code namespace is 'Opc.Ua.UANodeSet').
        /// </summary>
        public const string OpcUaNodeSetXsd = "http://opcfoundation.org/UA/NodeSet/Types.xsd";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";
    }
    #endregion
}
