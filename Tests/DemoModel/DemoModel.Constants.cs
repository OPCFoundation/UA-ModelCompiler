/* ========================================================================
 * Copyright (c) 2005-2021 The OPC Foundation, Inc. All rights reserved.
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
    /// <summary>
    /// A class that declares constants for all DataTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <summary>
        /// The identifier for the HeaterStatus DataType.
        /// </summary>
        public const uint HeaterStatus = 1;

        /// <summary>
        /// The identifier for the Vector DataType.
        /// </summary>
        public const uint Vector = 3;

        /// <summary>
        /// The identifier for the WorkOrderStatusType DataType.
        /// </summary>
        public const uint WorkOrderStatusType = 4;

        /// <summary>
        /// The identifier for the WorkOrderType DataType.
        /// </summary>
        public const uint WorkOrderType = 5;
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
        /// The identifier for the Signal Object.
        /// </summary>
        public const uint Signal = 36;

        /// <summary>
        /// The identifier for the Vector_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint Vector_Encoding_DefaultBinary = 21;

        /// <summary>
        /// The identifier for the WorkOrderStatusType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint WorkOrderStatusType_Encoding_DefaultBinary = 22;

        /// <summary>
        /// The identifier for the WorkOrderType_Encoding_DefaultBinary Object.
        /// </summary>
        public const uint WorkOrderType_Encoding_DefaultBinary = 23;

        /// <summary>
        /// The identifier for the Vector_Encoding_DefaultXml Object.
        /// </summary>
        public const uint Vector_Encoding_DefaultXml = 6;

        /// <summary>
        /// The identifier for the WorkOrderStatusType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint WorkOrderStatusType_Encoding_DefaultXml = 7;

        /// <summary>
        /// The identifier for the WorkOrderType_Encoding_DefaultXml Object.
        /// </summary>
        public const uint WorkOrderType_Encoding_DefaultXml = 8;

        /// <summary>
        /// The identifier for the Vector_Encoding_DefaultJson Object.
        /// </summary>
        public const uint Vector_Encoding_DefaultJson = 43;

        /// <summary>
        /// The identifier for the WorkOrderStatusType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint WorkOrderStatusType_Encoding_DefaultJson = 44;

        /// <summary>
        /// The identifier for the WorkOrderType_Encoding_DefaultJson Object.
        /// </summary>
        public const uint WorkOrderType_Encoding_DefaultJson = 45;
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
        /// The identifier for the Signal_Red Variable.
        /// </summary>
        public const uint Signal_Red = 37;

        /// <summary>
        /// The identifier for the Signal_Yellow Variable.
        /// </summary>
        public const uint Signal_Yellow = 38;

        /// <summary>
        /// The identifier for the Signal_Green Variable.
        /// </summary>
        public const uint Signal_Green = 39;

        /// <summary>
        /// The identifier for the HeaterStatus_EnumStrings Variable.
        /// </summary>
        public const uint HeaterStatus_EnumStrings = 2;

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema Variable.
        /// </summary>
        public const uint DemoModel_BinarySchema = 24;

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public const uint DemoModel_BinarySchema_NamespaceUri = 26;

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_Deprecated Variable.
        /// </summary>
        public const uint DemoModel_BinarySchema_Deprecated = 41;

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_Vector Variable.
        /// </summary>
        public const uint DemoModel_BinarySchema_Vector = 27;

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_WorkOrderStatusType Variable.
        /// </summary>
        public const uint DemoModel_BinarySchema_WorkOrderStatusType = 30;

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_WorkOrderType Variable.
        /// </summary>
        public const uint DemoModel_BinarySchema_WorkOrderType = 33;

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema Variable.
        /// </summary>
        public const uint DemoModel_XmlSchema = 9;

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public const uint DemoModel_XmlSchema_NamespaceUri = 11;

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_Deprecated Variable.
        /// </summary>
        public const uint DemoModel_XmlSchema_Deprecated = 42;

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_Vector Variable.
        /// </summary>
        public const uint DemoModel_XmlSchema_Vector = 12;

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_WorkOrderStatusType Variable.
        /// </summary>
        public const uint DemoModel_XmlSchema_WorkOrderStatusType = 15;

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_WorkOrderType Variable.
        /// </summary>
        public const uint DemoModel_XmlSchema_WorkOrderType = 18;
    }
    #endregion

    #region View Identifiers
    /// <summary>
    /// A class that declares constants for all Views in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Views
    {
        /// <summary>
        /// The identifier for the TrafficView View.
        /// </summary>
        public const uint TrafficView = 40;
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
        /// The identifier for the HeaterStatus DataType.
        /// </summary>
        public static readonly ExpandedNodeId HeaterStatus = new ExpandedNodeId(DemoModel.DataTypes.HeaterStatus, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the Vector DataType.
        /// </summary>
        public static readonly ExpandedNodeId Vector = new ExpandedNodeId(DemoModel.DataTypes.Vector, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderStatusType DataType.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderStatusType = new ExpandedNodeId(DemoModel.DataTypes.WorkOrderStatusType, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderType DataType.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderType = new ExpandedNodeId(DemoModel.DataTypes.WorkOrderType, DemoModel.Namespaces.DemoModel);
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
        /// The identifier for the Signal Object.
        /// </summary>
        public static readonly ExpandedNodeId Signal = new ExpandedNodeId(DemoModel.Objects.Signal, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the Vector_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId Vector_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.Vector_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderStatusType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderStatusType_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.WorkOrderStatusType_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderType_Encoding_DefaultBinary Object.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderType_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.WorkOrderType_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the Vector_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId Vector_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.Vector_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderStatusType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderStatusType_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.WorkOrderStatusType_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderType_Encoding_DefaultXml Object.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderType_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.WorkOrderType_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the Vector_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId Vector_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.Vector_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderStatusType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderStatusType_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.WorkOrderStatusType_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the WorkOrderType_Encoding_DefaultJson Object.
        /// </summary>
        public static readonly ExpandedNodeId WorkOrderType_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.WorkOrderType_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);
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
        /// The identifier for the Signal_Red Variable.
        /// </summary>
        public static readonly ExpandedNodeId Signal_Red = new ExpandedNodeId(DemoModel.Variables.Signal_Red, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the Signal_Yellow Variable.
        /// </summary>
        public static readonly ExpandedNodeId Signal_Yellow = new ExpandedNodeId(DemoModel.Variables.Signal_Yellow, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the Signal_Green Variable.
        /// </summary>
        public static readonly ExpandedNodeId Signal_Green = new ExpandedNodeId(DemoModel.Variables.Signal_Green, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the HeaterStatus_EnumStrings Variable.
        /// </summary>
        public static readonly ExpandedNodeId HeaterStatus_EnumStrings = new ExpandedNodeId(DemoModel.Variables.HeaterStatus_EnumStrings, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_BinarySchema = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_BinarySchema_NamespaceUri = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_NamespaceUri, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_BinarySchema_Deprecated = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_Deprecated, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_Vector Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_BinarySchema_Vector = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_Vector, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_WorkOrderStatusType Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_BinarySchema_WorkOrderStatusType = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_WorkOrderStatusType, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_BinarySchema_WorkOrderType Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_BinarySchema_WorkOrderType = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_WorkOrderType, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_XmlSchema = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_NamespaceUri Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_XmlSchema_NamespaceUri = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_NamespaceUri, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_Deprecated Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_XmlSchema_Deprecated = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_Deprecated, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_Vector Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_XmlSchema_Vector = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_Vector, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_WorkOrderStatusType Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_XmlSchema_WorkOrderStatusType = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_WorkOrderStatusType, DemoModel.Namespaces.DemoModel);

        /// <summary>
        /// The identifier for the DemoModel_XmlSchema_WorkOrderType Variable.
        /// </summary>
        public static readonly ExpandedNodeId DemoModel_XmlSchema_WorkOrderType = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_WorkOrderType, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region View Node Identifiers
    /// <summary>
    /// A class that declares constants for all Views in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ViewIds
    {
        /// <summary>
        /// The identifier for the TrafficView View.
        /// </summary>
        public static readonly ExpandedNodeId TrafficView = new ExpandedNodeId(DemoModel.Views.TrafficView, DemoModel.Namespaces.DemoModel);
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
        /// The BrowseName for the DemoModel_BinarySchema component.
        /// </summary>
        public const string DemoModel_BinarySchema = "DemoModel";

        /// <summary>
        /// The BrowseName for the DemoModel_XmlSchema component.
        /// </summary>
        public const string DemoModel_XmlSchema = "DemoModel";

        /// <summary>
        /// The BrowseName for the Green component.
        /// </summary>
        public const string Green = "Green";

        /// <summary>
        /// The BrowseName for the HeaterStatus component.
        /// </summary>
        public const string HeaterStatus = "HeaterStatus";

        /// <summary>
        /// The BrowseName for the Red component.
        /// </summary>
        public const string Red = "Red";

        /// <summary>
        /// The BrowseName for the Signal component.
        /// </summary>
        public const string Signal = "Signal";

        /// <summary>
        /// The BrowseName for the TrafficView component.
        /// </summary>
        public const string TrafficView = "TrafficView";

        /// <summary>
        /// The BrowseName for the Vector component.
        /// </summary>
        public const string Vector = "Vector";

        /// <summary>
        /// The BrowseName for the WorkOrderStatusType component.
        /// </summary>
        public const string WorkOrderStatusType = "WorkOrderStatusType";

        /// <summary>
        /// The BrowseName for the WorkOrderType component.
        /// </summary>
        public const string WorkOrderType = "WorkOrderType";

        /// <summary>
        /// The BrowseName for the Yellow component.
        /// </summary>
        public const string Yellow = "Yellow";
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
