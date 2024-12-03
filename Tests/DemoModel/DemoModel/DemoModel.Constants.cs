/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
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
        public const uint EnumUnderscoreTest = 68;

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

        /// <remarks />
        public const uint Person = 222;

        /// <remarks />
        public const uint Student = 223;
    }
    #endregion

    #region Method Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <remarks />
        public const uint RestrictedObjectType_Blue = 127;

        /// <remarks />
        public const uint TestObject_Blue = 71;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint Seeker = 95;

        /// <remarks />
        public const uint TestObject = 128;

        /// <remarks />
        public const uint Test_Error = 93;

        /// <remarks />
        public const uint Test_ErrorComponent = 94;

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
        public const uint Person_Encoding_DefaultBinary = 224;

        /// <remarks />
        public const uint Student_Encoding_DefaultBinary = 225;

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
        public const uint Person_Encoding_DefaultXml = 232;

        /// <remarks />
        public const uint Student_Encoding_DefaultXml = 233;

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

        /// <remarks />
        public const uint Person_Encoding_DefaultJson = 240;

        /// <remarks />
        public const uint Student_Encoding_DefaultJson = 241;
    }
    #endregion

    #region ObjectType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <remarks />
        public const uint RestrictedObjectType = 124;

        /// <remarks />
        public const uint WithTwoDimensionalVariableType = 120;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint Seeker_Identities = 10;

        /// <remarks />
        public const uint Seeker_AddIdentity_InputArguments = 25;

        /// <remarks />
        public const uint Seeker_RemoveIdentity_InputArguments = 29;

        /// <remarks />
        public const uint Seeker_AddApplication_InputArguments = 32;

        /// <remarks />
        public const uint Seeker_RemoveApplication_InputArguments = 35;

        /// <remarks />
        public const uint Seeker_AddEndpoint_InputArguments = 52;

        /// <remarks />
        public const uint Seeker_RemoveEndpoint_InputArguments = 55;

        /// <remarks />
        public const uint EnumUnderscoreTest_EnumValues = 69;

        /// <remarks />
        public const uint RestrictedVariableType_Yellow = 123;

        /// <remarks />
        public const uint RestrictedVariableType_X = 210;

        /// <remarks />
        public const uint RestrictedVariableType_Y = 211;

        /// <remarks />
        public const uint RestrictedVariableType_Z = 212;

        /// <remarks />
        public const uint RestrictedObjectType_Red = 125;

        /// <remarks />
        public const uint RestrictedObjectType_Red_Yellow = 57;

        /// <remarks />
        public const uint RestrictedObjectType_Red_X = 213;

        /// <remarks />
        public const uint RestrictedObjectType_Red_Y = 214;

        /// <remarks />
        public const uint RestrictedObjectType_Red_Z = 215;

        /// <remarks />
        public const uint RestrictedObjectType_Pink_Placeholder = 132;

        /// <remarks />
        public const uint RestrictedObjectType_Pink_Placeholder_Yellow = 58;

        /// <remarks />
        public const uint RestrictedObjectType_Pink_Placeholder_X = 216;

        /// <remarks />
        public const uint RestrictedObjectType_Pink_Placeholder_Y = 217;

        /// <remarks />
        public const uint RestrictedObjectType_Pink_Placeholder_Z = 218;

        /// <remarks />
        public const uint TestObject_Red = 60;

        /// <remarks />
        public const uint TestObject_Red_Yellow = 61;

        /// <remarks />
        public const uint TestObject_Red_X = 219;

        /// <remarks />
        public const uint TestObject_Red_Y = 220;

        /// <remarks />
        public const uint TestObject_Red_Z = 221;

        /// <remarks />
        public const uint HeaterStatus_EnumStrings = 2;

        /// <remarks />
        public const uint WithTwoDimensionalVariableType_X = 121;

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
        public const uint DemoModel_BinarySchema_Person = 226;

        /// <remarks />
        public const uint DemoModel_BinarySchema_Student = 229;

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

        /// <remarks />
        public const uint DemoModel_XmlSchema_Person = 234;

        /// <remarks />
        public const uint DemoModel_XmlSchema_Student = 237;
    }
    #endregion

    #region VariableType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableTypes
    {
        /// <remarks />
        public const uint RestrictedVariableType = 122;
    }
    #endregion

    #region DataType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId EnumUnderscoreTest = new ExpandedNodeId(DemoModel.DataTypes.EnumUnderscoreTest, DemoModel.Namespaces.DemoModel);

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

        /// <remarks />
        public static readonly ExpandedNodeId Person = new ExpandedNodeId(DemoModel.DataTypes.Person, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Student = new ExpandedNodeId(DemoModel.DataTypes.Student, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region Method Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Blue = new ExpandedNodeId(DemoModel.Methods.RestrictedObjectType_Blue, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject_Blue = new ExpandedNodeId(DemoModel.Methods.TestObject_Blue, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId Seeker = new ExpandedNodeId(DemoModel.Objects.Seeker, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject = new ExpandedNodeId(DemoModel.Objects.TestObject, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Test_Error = new ExpandedNodeId(DemoModel.Objects.Test_Error, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Test_ErrorComponent = new ExpandedNodeId(DemoModel.Objects.Test_ErrorComponent, DemoModel.Namespaces.DemoModel);

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
        public static readonly ExpandedNodeId Person_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.Person_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Student_Encoding_DefaultBinary = new ExpandedNodeId(DemoModel.Objects.Student_Encoding_DefaultBinary, DemoModel.Namespaces.DemoModel);

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
        public static readonly ExpandedNodeId Person_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.Person_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Student_Encoding_DefaultXml = new ExpandedNodeId(DemoModel.Objects.Student_Encoding_DefaultXml, DemoModel.Namespaces.DemoModel);

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

        /// <remarks />
        public static readonly ExpandedNodeId Person_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.Person_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Student_Encoding_DefaultJson = new ExpandedNodeId(DemoModel.Objects.Student_Encoding_DefaultJson, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType = new ExpandedNodeId(DemoModel.ObjectTypes.RestrictedObjectType, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WithTwoDimensionalVariableType = new ExpandedNodeId(DemoModel.ObjectTypes.WithTwoDimensionalVariableType, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId Seeker_Identities = new ExpandedNodeId(DemoModel.Variables.Seeker_Identities, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Seeker_AddIdentity_InputArguments = new ExpandedNodeId(DemoModel.Variables.Seeker_AddIdentity_InputArguments, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Seeker_RemoveIdentity_InputArguments = new ExpandedNodeId(DemoModel.Variables.Seeker_RemoveIdentity_InputArguments, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Seeker_AddApplication_InputArguments = new ExpandedNodeId(DemoModel.Variables.Seeker_AddApplication_InputArguments, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Seeker_RemoveApplication_InputArguments = new ExpandedNodeId(DemoModel.Variables.Seeker_RemoveApplication_InputArguments, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Seeker_AddEndpoint_InputArguments = new ExpandedNodeId(DemoModel.Variables.Seeker_AddEndpoint_InputArguments, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId Seeker_RemoveEndpoint_InputArguments = new ExpandedNodeId(DemoModel.Variables.Seeker_RemoveEndpoint_InputArguments, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId EnumUnderscoreTest_EnumValues = new ExpandedNodeId(DemoModel.Variables.EnumUnderscoreTest_EnumValues, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedVariableType_Yellow = new ExpandedNodeId(DemoModel.Variables.RestrictedVariableType_Yellow, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedVariableType_X = new ExpandedNodeId(DemoModel.Variables.RestrictedVariableType_X, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedVariableType_Y = new ExpandedNodeId(DemoModel.Variables.RestrictedVariableType_Y, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedVariableType_Z = new ExpandedNodeId(DemoModel.Variables.RestrictedVariableType_Z, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Red = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Red, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Red_Yellow = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Red_Yellow, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Red_X = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Red_X, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Red_Y = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Red_Y, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Red_Z = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Red_Z, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Pink_Placeholder = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Pink_Placeholder, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Pink_Placeholder_Yellow = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Pink_Placeholder_Yellow, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Pink_Placeholder_X = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Pink_Placeholder_X, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Pink_Placeholder_Y = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Pink_Placeholder_Y, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId RestrictedObjectType_Pink_Placeholder_Z = new ExpandedNodeId(DemoModel.Variables.RestrictedObjectType_Pink_Placeholder_Z, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject_Red = new ExpandedNodeId(DemoModel.Variables.TestObject_Red, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject_Red_Yellow = new ExpandedNodeId(DemoModel.Variables.TestObject_Red_Yellow, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject_Red_X = new ExpandedNodeId(DemoModel.Variables.TestObject_Red_X, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject_Red_Y = new ExpandedNodeId(DemoModel.Variables.TestObject_Red_Y, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId TestObject_Red_Z = new ExpandedNodeId(DemoModel.Variables.TestObject_Red_Z, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId HeaterStatus_EnumStrings = new ExpandedNodeId(DemoModel.Variables.HeaterStatus_EnumStrings, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId WithTwoDimensionalVariableType_X = new ExpandedNodeId(DemoModel.Variables.WithTwoDimensionalVariableType_X, DemoModel.Namespaces.DemoModel);

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
        public static readonly ExpandedNodeId DemoModel_BinarySchema_Person = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_Person, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_BinarySchema_Student = new ExpandedNodeId(DemoModel.Variables.DemoModel_BinarySchema_Student, DemoModel.Namespaces.DemoModel);

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

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_Person = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_Person, DemoModel.Namespaces.DemoModel);

        /// <remarks />
        public static readonly ExpandedNodeId DemoModel_XmlSchema_Student = new ExpandedNodeId(DemoModel.Variables.DemoModel_XmlSchema_Student, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region VariableType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId RestrictedVariableType = new ExpandedNodeId(DemoModel.VariableTypes.RestrictedVariableType, DemoModel.Namespaces.DemoModel);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string Blue = "Blue";

        /// <remarks />
        public const string DemoModel_BinarySchema = "DemoModel";

        /// <remarks />
        public const string DemoModel_XmlSchema = "DemoModel";

        /// <remarks />
        public const string EnumUnderscoreTest = "EnumUnderscoreTest";

        /// <remarks />
        public const string HeaterStatus = "HeaterStatus";

        /// <remarks />
        public const string Person = "Person";

        /// <remarks />
        public const string Pink_Placeholder = "<Pink>";

        /// <remarks />
        public const string Red = "Red";

        /// <remarks />
        public const string RestrictedObjectType = "RestrictedObjectType";

        /// <remarks />
        public const string RestrictedVariableType = "RestrictedVariableType";

        /// <remarks />
        public const string SampleStructureAllowSubtypes = "SampleStructureAllowSubtypes";

        /// <remarks />
        public const string SampleStructureWithOptionalFields = "SampleStructureWithOptionalFields";

        /// <remarks />
        public const string SampleUnion = "SampleUnion";

        /// <remarks />
        public const string SampleUnionAllowSubtypes = "SampleUnionAllowSubtypes";

        /// <remarks />
        public const string Seeker = "Seeker";

        /// <remarks />
        public const string Student = "Student";

        /// <remarks />
        public const string Test_Error = "Test_Error";

        /// <remarks />
        public const string Test_ErrorComponent = "Test_ErrorComponent";

        /// <remarks />
        public const string TestObject = "TestObject";

        /// <remarks />
        public const string Vector = "Vector";

        /// <remarks />
        public const string WithTwoDimensionalVariableType = "WithTwoDimensionalVariableType";

        /// <remarks />
        public const string WorkOrderStatusType = "WorkOrderStatusType";

        /// <remarks />
        public const string WorkOrderType = "WorkOrderType";

        /// <remarks />
        public const string X = "X";

        /// <remarks />
        public const string Y = "Y";

        /// <remarks />
        public const string Yellow = "Yellow";

        /// <remarks />
        public const string Z = "Z";
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
        public const string DemoModel = "urn:opcfoundation.org:2024-01:DemoModel";

        /// <summary>
        /// The URI for the DemoModelXsd namespace (.NET code namespace is 'DemoModel').
        /// </summary>
        public const string DemoModelXsd = "urn:opcfoundation.org:2024-01:DemoModelTypes.xsd";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";

        /// <summary>
        /// The URI for the DI namespace (.NET code namespace is 'Opc.Ua.Di').
        /// </summary>
        public const string DI = "http://opcfoundation.org/UA/DI/";
    }
    #endregion
}
