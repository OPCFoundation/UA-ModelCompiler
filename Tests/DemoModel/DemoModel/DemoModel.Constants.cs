/* ========================================================================
 * Copyright (c) 2005-2022 The OPC Foundation, Inc. All rights reserved.
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

namespace DemoModel
{
    #region DataType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <remarks />
        public const uint HeaterStatus = 1;

        /// <remarks />
        public const uint Vector = 3;

        /// <remarks />
        public const uint WorkOrderStatusType = 4;

        /// <remarks />
        public const uint WorkOrderType = 5;

        /// <remarks />
        public const uint SampleUnion = 41;

        /// <remarks />
        public const uint SampleStructureWithOptionalFields = 42;

        /// <remarks />
        public const uint SampleUnionAllowSubtypes = 43;

        /// <remarks />
        public const uint SampleStructureAllowSubtypes = 44;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint Signal = 36;

        /// <remarks />
        public const uint Vector_Encoding_DefaultBinary = 21;

        /// <remarks />
        public const uint WorkOrderStatusType_Encoding_DefaultBinary = 22;

        /// <remarks />
        public const uint WorkOrderType_Encoding_DefaultBinary = 23;

        /// <remarks />
        public const uint SampleUnion_Encoding_DefaultBinary = 45;

        /// <remarks />
        public const uint SampleStructureWithOptionalFields_Encoding_DefaultBinary = 46;

        /// <remarks />
        public const uint SampleUnionAllowSubtypes_Encoding_DefaultBinary = 47;

        /// <remarks />
        public const uint SampleStructureAllowSubtypes_Encoding_DefaultBinary = 48;

        /// <remarks />
        public const uint Vector_Encoding_DefaultXml = 6;

        /// <remarks />
        public const uint WorkOrderStatusType_Encoding_DefaultXml = 7;

        /// <remarks />
        public const uint WorkOrderType_Encoding_DefaultXml = 8;

        /// <remarks />
        public const uint SampleUnion_Encoding_DefaultXml = 62;

        /// <remarks />
        public const uint SampleStructureWithOptionalFields_Encoding_DefaultXml = 63;

        /// <remarks />
        public const uint SampleUnionAllowSubtypes_Encoding_DefaultXml = 64;

        /// <remarks />
        public const uint SampleStructureAllowSubtypes_Encoding_DefaultXml = 65;

        /// <remarks />
        public const uint Vector_Encoding_DefaultJson = 79;

        /// <remarks />
        public const uint WorkOrderStatusType_Encoding_DefaultJson = 80;

        /// <remarks />
        public const uint WorkOrderType_Encoding_DefaultJson = 81;

        /// <remarks />
        public const uint SampleUnion_Encoding_DefaultJson = 82;

        /// <remarks />
        public const uint SampleStructureWithOptionalFields_Encoding_DefaultJson = 83;

        /// <remarks />
        public const uint SampleUnionAllowSubtypes_Encoding_DefaultJson = 84;

        /// <remarks />
        public const uint SampleStructureAllowSubtypes_Encoding_DefaultJson = 85;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint Signal_Red = 37;

        /// <remarks />
        public const uint Signal_Yellow = 38;

        /// <remarks />
        public const uint Signal_Green = 39;

        /// <remarks />
        public const uint HeaterStatus_EnumStrings = 2;

        /// <remarks />
        public const uint DemoModel_BinarySchema = 24;

        /// <remarks />
        public const uint DemoModel_BinarySchema_NamespaceUri = 26;

        /// <remarks />
        public const uint DemoModel_BinarySchema_Deprecated = 49;

        /// <remarks />
        public const uint DemoModel_BinarySchema_Vector = 27;

        /// <remarks />
        public const uint DemoModel_BinarySchema_WorkOrderStatusType = 30;

        /// <remarks />
        public const uint DemoModel_BinarySchema_WorkOrderType = 33;

        /// <remarks />
        public const uint DemoModel_BinarySchema_SampleUnion = 50;

        /// <remarks />
        public const uint DemoModel_BinarySchema_SampleStructureWithOptionalFields = 53;

        /// <remarks />
        public const uint DemoModel_BinarySchema_SampleUnionAllowSubtypes = 56;

        /// <remarks />
        public const uint DemoModel_BinarySchema_SampleStructureAllowSubtypes = 59;

        /// <remarks />
        public const uint DemoModel_XmlSchema = 9;

        /// <remarks />
        public const uint DemoModel_XmlSchema_NamespaceUri = 11;

        /// <remarks />
        public const uint DemoModel_XmlSchema_Deprecated = 66;

        /// <remarks />
        public const uint DemoModel_XmlSchema_Vector = 12;

        /// <remarks />
        public const uint DemoModel_XmlSchema_WorkOrderStatusType = 15;

        /// <remarks />
        public const uint DemoModel_XmlSchema_WorkOrderType = 18;

        /// <remarks />
        public const uint DemoModel_XmlSchema_SampleUnion = 67;

        /// <remarks />
        public const uint DemoModel_XmlSchema_SampleStructureWithOptionalFields = 70;

        /// <remarks />
        public const uint DemoModel_XmlSchema_SampleUnionAllowSubtypes = 73;

        /// <remarks />
        public const uint DemoModel_XmlSchema_SampleStructureAllowSubtypes = 76;
    }
    #endregion

    #region View Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Views
    {
        /// <remarks />
        public const uint TrafficView = 40;
    }
    #endregion

    #region DataType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId HeaterStatus = new ExpandedNodeId(DemoModel.DataTypes.HeaterStatus, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Vector = new ExpandedNodeId(DemoModel.DataTypes.Vector, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderStatusType = new ExpandedNodeId(DemoModel.DataTypes.WorkOrderStatusType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderType = new ExpandedNodeId(DemoModel.DataTypes.WorkOrderType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnion = new ExpandedNodeId(DemoModel.DataTypes.SampleUnion, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureWithOptionalFields = new ExpandedNodeId(DemoModel.DataTypes.SampleStructureWithOptionalFields, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnionAllowSubtypes = new ExpandedNodeId(DemoModel.DataTypes.SampleUnionAllowSubtypes, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureAllowSubtypes = new ExpandedNodeId(DemoModel.DataTypes.SampleStructureAllowSubtypes, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId Signal = new ExpandedNodeId(DemoModel.Objects.Signal, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Vector_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.Vector_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderStatusType_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.WorkOrderStatusType_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderType_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.WorkOrderType_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnion_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.SampleUnion_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureWithOptionalFields_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.SampleStructureWithOptionalFields_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnionAllowSubtypes_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.SampleUnionAllowSubtypes_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureAllowSubtypes_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.SampleStructureAllowSubtypes_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Vector_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.Vector_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderStatusType_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.WorkOrderStatusType_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderType_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.WorkOrderType_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnion_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.SampleUnion_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureWithOptionalFields_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.SampleStructureWithOptionalFields_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnionAllowSubtypes_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.SampleUnionAllowSubtypes_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureAllowSubtypes_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.SampleStructureAllowSubtypes_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Vector_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.Vector_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderStatusType_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.WorkOrderStatusType_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WorkOrderType_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.WorkOrderType_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnion_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.SampleUnion_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureWithOptionalFields_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.SampleStructureWithOptionalFields_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleUnionAllowSubtypes_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.SampleUnionAllowSubtypes_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId SampleStructureAllowSubtypes_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.SampleStructureAllowSubtypes_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId Signal_Red = new ExpandedNodeId(DemoModel.Variables.Signal_Red, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Signal_Yellow = new ExpandedNodeId(DemoModel.Variables.Signal_Yellow, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Signal_Green = new ExpandedNodeId(DemoModel.Variables.Signal_Green, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId HeaterStatus_EnumStrings = new ExpandedNodeId(DemoModel.Variables.HeaterStatus_EnumStrings, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_NamespaceUri = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_NamespaceUri, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_Deprecated = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_Deprecated, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_Vector = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_Vector, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_WorkOrderStatusType = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_WorkOrderStatusType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_WorkOrderType = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_WorkOrderType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_SampleUnion = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_SampleUnion, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_SampleStructureWithOptionalFields = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_SampleStructureWithOptionalFields, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_SampleUnionAllowSubtypes = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_SampleUnionAllowSubtypes, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_SampleStructureAllowSubtypes = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_SampleStructureAllowSubtypes, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_NamespaceUri = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_NamespaceUri, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_Deprecated = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_Deprecated, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_Vector = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_Vector, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_WorkOrderStatusType = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_WorkOrderStatusType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_WorkOrderType = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_WorkOrderType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_SampleUnion = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_SampleUnion, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_SampleStructureWithOptionalFields = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_SampleStructureWithOptionalFields, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_SampleUnionAllowSubtypes = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_SampleUnionAllowSubtypes, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_SampleStructureAllowSubtypes = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_SampleStructureAllowSubtypes, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region View Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ViewIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId TrafficView = new ExpandedNodeId(DemoModel.Views.TrafficView, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string DemoModel_BinarySchema = "DemoModel";

        /// <remarks />
        public const string DemoModel_XmlSchema = "DemoModel";

        /// <remarks />
        public const string Green = "Green";

        /// <remarks />
        public const string HeaterStatus = "HeaterStatus";

        /// <remarks />
        public const string Red = "Red";

        /// <remarks />
        public const string SampleStructureAllowSubtypes = "SampleStructureAllowSubtypes";

        /// <remarks />
        public const string SampleStructureWithOptionalFields = "SampleStructureWithOptionalFields";

        /// <remarks />
        public const string SampleUnion = "SampleUnion";

        /// <remarks />
        public const string SampleUnionAllowSubtypes = "SampleUnionAllowSubtypes";

        /// <remarks />
        public const string Signal = "Signal";

        /// <remarks />
        public const string TrafficView = "TrafficView";

        /// <remarks />
        public const string Vector = "Vector";

        /// <remarks />
        public const string WorkOrderStatusType = "WorkOrderStatusType";

        /// <remarks />
        public const string WorkOrderType = "WorkOrderType";

        /// <remarks />
        public const string Yellow = "Yellow";
    }
    #endregion

    #region Namespace Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the DemoModel namespace (.NET code namespace is 'DemoModel').
        /// </summary>
        public const string DemoModel = "http://www.opcfoundation.org/DemoModel/";

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
