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
using Opc.Ua.Gds;
using Opc.Ua;

namespace Opc.Ua.Onboarding
{
    #region DataType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypes
    {
        /// <remarks />
        public const uint CertificateAuthorityType = 1164;

        /// <remarks />
        public const uint BaseTicketType = 1165;

        /// <remarks />
        public const uint DeviceIdentityTicketType = 1166;

        /// <remarks />
        public const uint CompositeIdentityTicketType = 1167;

        /// <remarks />
        public const uint TicketListType = 1168;

        /// <remarks />
        public const uint ManagerDescription = 1495;
    }
    #endregion

    #region Method Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Methods
    {
        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open = 17;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close = 20;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read = 22;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write = 25;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition = 27;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition = 30;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_AddIdentity = 5041;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_RemoveIdentity = 5043;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_AddApplication = 5045;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_RemoveApplication = 5047;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_AddEndpoint = 5049;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_RemoveEndpoint = 5051;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_RegisterTickets = 1176;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_UnregisterTickets = 1179;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Open = 1190;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Close = 1193;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Read = 1195;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Write = 1198;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_GetPosition = 1200;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_SetPosition = 1203;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks = 1208;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate = 1211;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_AddCertificate = 1214;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate = 1216;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open = 1226;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close = 1229;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read = 1231;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write = 1234;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition = 1236;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition = 1239;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks = 1244;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate = 1247;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate = 1250;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate = 1252;

        /// <remarks />
        public const uint DeviceRegistrarType_ProvideIdentities = 1260;

        /// <remarks />
        public const uint DeviceRegistrarType_UpdateSoftwareStatus = 1503;

        /// <remarks />
        public const uint DeviceRegistrarType_RegisterDeviceEndpoint = 1263;

        /// <remarks />
        public const uint DeviceRegistrarType_GetManagers = 1505;

        /// <remarks />
        public const uint DeviceRegistrarType_RegisterManagedApplication = 1507;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_RegisterTickets = 1266;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_UnregisterTickets = 1269;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Open = 1280;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Close = 1283;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Read = 1285;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Write = 1288;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_GetPosition = 1290;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_SetPosition = 1293;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks = 1298;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate = 1301;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate = 1304;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate = 1306;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open = 1316;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close = 1319;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read = 1321;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write = 1324;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition = 1326;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition = 1329;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks = 1334;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate = 1337;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate = 1340;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate = 1342;

        /// <remarks />
        public const uint DeviceRegistrar_ProvideIdentities = 1345;

        /// <remarks />
        public const uint DeviceRegistrar_UpdateSoftwareStatus = 1510;

        /// <remarks />
        public const uint DeviceRegistrar_RegisterDeviceEndpoint = 1348;

        /// <remarks />
        public const uint DeviceRegistrar_GetManagers = 1512;

        /// <remarks />
        public const uint DeviceRegistrar_RegisterManagedApplication = 1514;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_RegisterTickets = 1351;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_UnregisterTickets = 1354;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Open = 1365;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Close = 1368;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Read = 1370;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Write = 1373;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_GetPosition = 1375;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_SetPosition = 1378;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks = 1383;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate = 1386;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_AddCertificate = 1389;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate = 1391;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open = 1401;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close = 1404;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read = 1406;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write = 1409;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition = 1411;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition = 1414;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks = 1419;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate = 1422;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate = 1425;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate = 1427;
    }
    #endregion

    #region Object Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Objects
    {
        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata = 1;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin = 5034;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities = 1182;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities = 1218;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration = 1265;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities = 1272;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities = 1308;

        /// <remarks />
        public const uint DeviceRegistrar = 1344;

        /// <remarks />
        public const uint DeviceRegistrar_Administration = 1350;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities = 1357;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities = 1393;

        /// <remarks />
        public const uint CertificateAuthorityType_Encoding_DefaultBinary = 1439;

        /// <remarks />
        public const uint BaseTicketType_Encoding_DefaultBinary = 1440;

        /// <remarks />
        public const uint DeviceIdentityTicketType_Encoding_DefaultBinary = 1441;

        /// <remarks />
        public const uint CompositeIdentityTicketType_Encoding_DefaultBinary = 1442;

        /// <remarks />
        public const uint TicketListType_Encoding_DefaultBinary = 1443;

        /// <remarks />
        public const uint ManagerDescription_Encoding_DefaultBinary = 4206;

        /// <remarks />
        public const uint CertificateAuthorityType_Encoding_DefaultXml = 1463;

        /// <remarks />
        public const uint BaseTicketType_Encoding_DefaultXml = 1464;

        /// <remarks />
        public const uint DeviceIdentityTicketType_Encoding_DefaultXml = 1465;

        /// <remarks />
        public const uint CompositeIdentityTicketType_Encoding_DefaultXml = 1466;

        /// <remarks />
        public const uint TicketListType_Encoding_DefaultXml = 1467;

        /// <remarks />
        public const uint ManagerDescription_Encoding_DefaultXml = 4214;

        /// <remarks />
        public const uint CertificateAuthorityType_Encoding_DefaultJson = 1487;

        /// <remarks />
        public const uint BaseTicketType_Encoding_DefaultJson = 1488;

        /// <remarks />
        public const uint DeviceIdentityTicketType_Encoding_DefaultJson = 1489;

        /// <remarks />
        public const uint CompositeIdentityTicketType_Encoding_DefaultJson = 1490;

        /// <remarks />
        public const uint TicketListType_Encoding_DefaultJson = 1491;

        /// <remarks />
        public const uint ManagerDescription_Encoding_DefaultJson = 4222;
    }
    #endregion

    #region ObjectType Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <remarks />
        public const uint DeviceRegistrarAdminType = 1175;

        /// <remarks />
        public const uint DeviceRegistrarType = 1259;

        /// <remarks />
        public const uint DeviceRegistrationAuditEventType = 1517;

        /// <remarks />
        public const uint DeviceIdentityAcceptedAuditEventType = 1533;

        /// <remarks />
        public const uint DeviceSoftwareUpdatedAuditEventType = 1552;
    }
    #endregion

    #region Variable Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceUri = 2;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceVersion = 3;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespacePublicationDate = 4;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_IsNamespaceSubset = 5;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_StaticNodeIdTypes = 6;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_StaticNumericNodeIdRange = 7;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_StaticStringNodeIdPattern = 8;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Size = 10;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Writable = 11;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_UserWritable = 12;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_OpenCount = 13;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_InputArguments = 18;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_OutputArguments = 19;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close_InputArguments = 21;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_InputArguments = 23;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_OutputArguments = 24;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write_InputArguments = 26;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 28;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 29;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 31;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_DefaultRolePermissions = 33;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_DefaultUserRolePermissions = 34;

        /// <remarks />
        public const uint OPCUAOnboardingNamespaceMetadata_DefaultAccessRestrictions = 35;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_Identities = 5035;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_ApplicationsExclude = 5036;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_Applications = 5037;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_EndpointsExclude = 5038;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_Endpoints = 5039;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_CustomConfiguration = 5040;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_AddIdentity_InputArguments = 5042;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_RemoveIdentity_InputArguments = 5044;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_AddApplication_InputArguments = 5046;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_RemoveApplication_InputArguments = 5048;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_AddEndpoint_InputArguments = 5050;

        /// <remarks />
        public const uint WellKnownRole_RegistrarAdmin_RemoveEndpoint_InputArguments = 5052;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_RegisterTickets_InputArguments = 1177;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_RegisterTickets_OutputArguments = 1178;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_UnregisterTickets_InputArguments = 1180;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_UnregisterTickets_OutputArguments = 1181;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Size = 1183;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Writable = 1184;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_UserWritable = 1185;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenCount = 1186;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Open_InputArguments = 1191;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Open_OutputArguments = 1192;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Close_InputArguments = 1194;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Read_InputArguments = 1196;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Read_OutputArguments = 1197;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_Write_InputArguments = 1199;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_GetPosition_InputArguments = 1201;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_GetPosition_OutputArguments = 1202;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_SetPosition_InputArguments = 1204;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_LastUpdateTime = 1205;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_InputArguments = 1209;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_OutputArguments = 1210;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_InputArguments = 1212;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_OutputArguments = 1213;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_AddCertificate_InputArguments = 1215;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate_InputArguments = 1217;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Size = 1219;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Writable = 1220;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_UserWritable = 1221;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenCount = 1222;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_InputArguments = 1227;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_OutputArguments = 1228;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close_InputArguments = 1230;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_InputArguments = 1232;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_OutputArguments = 1233;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write_InputArguments = 1235;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_InputArguments = 1237;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_OutputArguments = 1238;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition_InputArguments = 1240;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_LastUpdateTime = 1241;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = 1245;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = 1246;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = 1248;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = 1249;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate_InputArguments = 1251;

        /// <remarks />
        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = 1253;

        /// <remarks />
        public const uint DeviceRegistrarType_ProvideIdentities_InputArguments = 1261;

        /// <remarks />
        public const uint DeviceRegistrarType_ProvideIdentities_OutputArguments = 1262;

        /// <remarks />
        public const uint DeviceRegistrarType_UpdateSoftwareStatus_InputArguments = 1504;

        /// <remarks />
        public const uint DeviceRegistrarType_RegisterDeviceEndpoint_InputArguments = 1264;

        /// <remarks />
        public const uint DeviceRegistrarType_GetManagers_OutputArguments = 1506;

        /// <remarks />
        public const uint DeviceRegistrarType_RegisterManagedApplication_InputArguments = 1508;

        /// <remarks />
        public const uint DeviceRegistrarType_RegisterManagedApplication_OutputArguments = 1509;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_RegisterTickets_InputArguments = 1267;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_RegisterTickets_OutputArguments = 1268;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_UnregisterTickets_InputArguments = 1270;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_UnregisterTickets_OutputArguments = 1271;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Size = 1273;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Writable = 1274;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_UserWritable = 1275;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenCount = 1276;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Open_InputArguments = 1281;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Open_OutputArguments = 1282;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Close_InputArguments = 1284;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Read_InputArguments = 1286;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Read_OutputArguments = 1287;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Write_InputArguments = 1289;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_InputArguments = 1291;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_OutputArguments = 1292;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_SetPosition_InputArguments = 1294;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_LastUpdateTime = 1295;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_InputArguments = 1299;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = 1300;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = 1302;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = 1303;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate_InputArguments = 1305;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate_InputArguments = 1307;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Size = 1309;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Writable = 1310;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_UserWritable = 1311;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenCount = 1312;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_InputArguments = 1317;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_OutputArguments = 1318;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close_InputArguments = 1320;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_InputArguments = 1322;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_OutputArguments = 1323;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write_InputArguments = 1325;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = 1327;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = 1328;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = 1330;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_LastUpdateTime = 1331;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = 1335;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = 1336;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = 1338;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = 1339;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = 1341;

        /// <remarks />
        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = 1343;

        /// <remarks />
        public const uint DeviceRegistrar_ProvideIdentities_InputArguments = 1346;

        /// <remarks />
        public const uint DeviceRegistrar_ProvideIdentities_OutputArguments = 1347;

        /// <remarks />
        public const uint DeviceRegistrar_UpdateSoftwareStatus_InputArguments = 1511;

        /// <remarks />
        public const uint DeviceRegistrar_RegisterDeviceEndpoint_InputArguments = 1349;

        /// <remarks />
        public const uint DeviceRegistrar_GetManagers_OutputArguments = 1513;

        /// <remarks />
        public const uint DeviceRegistrar_RegisterManagedApplication_InputArguments = 1515;

        /// <remarks />
        public const uint DeviceRegistrar_RegisterManagedApplication_OutputArguments = 1516;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_RegisterTickets_InputArguments = 1352;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_RegisterTickets_OutputArguments = 1353;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_UnregisterTickets_InputArguments = 1355;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_UnregisterTickets_OutputArguments = 1356;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Size = 1358;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Writable = 1359;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_UserWritable = 1360;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenCount = 1361;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Open_InputArguments = 1366;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Open_OutputArguments = 1367;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Close_InputArguments = 1369;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Read_InputArguments = 1371;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Read_OutputArguments = 1372;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_Write_InputArguments = 1374;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_GetPosition_InputArguments = 1376;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_GetPosition_OutputArguments = 1377;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_SetPosition_InputArguments = 1379;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_LastUpdateTime = 1380;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_InputArguments = 1384;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = 1385;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = 1387;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = 1388;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_AddCertificate_InputArguments = 1390;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate_InputArguments = 1392;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Size = 1394;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Writable = 1395;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_UserWritable = 1396;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenCount = 1397;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_InputArguments = 1402;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_OutputArguments = 1403;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close_InputArguments = 1405;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_InputArguments = 1407;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_OutputArguments = 1408;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write_InputArguments = 1410;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = 1412;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = 1413;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = 1415;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_LastUpdateTime = 1416;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = 1420;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = 1421;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = 1423;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = 1424;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = 1426;

        /// <remarks />
        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = 1428;

        /// <remarks />
        public const uint DeviceRegistrationAuditEventType_ProductInstanceUri = 1532;

        /// <remarks />
        public const uint DeviceIdentityAcceptedAuditEventType_Certificate = 1549;

        /// <remarks />
        public const uint DeviceIdentityAcceptedAuditEventType_Ticket = 1550;

        /// <remarks />
        public const uint DeviceIdentityAcceptedAuditEventType_Composite = 1551;

        /// <remarks />
        public const uint DeviceSoftwareUpdatedAuditEventType_Status = 1563;

        /// <remarks />
        public const uint DeviceSoftwareUpdatedAuditEventType_SoftwareRevision = 1568;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema = 1444;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_NamespaceUri = 1446;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_Deprecated = 1447;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_CertificateAuthorityType = 1448;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_BaseTicketType = 1451;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_DeviceIdentityTicketType = 1454;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_CompositeIdentityTicketType = 1457;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_TicketListType = 1460;

        /// <remarks />
        public const uint OpcUaOnboarding_BinarySchema_ManagerDescription = 4208;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema = 1468;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_NamespaceUri = 1470;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_Deprecated = 1471;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_CertificateAuthorityType = 1472;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_BaseTicketType = 1475;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_DeviceIdentityTicketType = 1478;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_CompositeIdentityTicketType = 1481;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_TicketListType = 1484;

        /// <remarks />
        public const uint OpcUaOnboarding_XmlSchema_ManagerDescription = 4216;
    }
    #endregion

    #region DataType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class DataTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId CertificateAuthorityType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.CertificateAuthorityType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId BaseTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.BaseTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.DeviceIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CompositeIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.CompositeIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId TicketListType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.TicketListType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId ManagerDescription = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.ManagerDescription, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region Method Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class MethodIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddIdentity = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_AddIdentity, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveIdentity = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_RemoveIdentity, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_AddApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_RemoveApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_AddEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_RemoveEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_RegisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_RegisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_UnregisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_UnregisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_ProvideIdentities = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_ProvideIdentities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_UpdateSoftwareStatus = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_UpdateSoftwareStatus, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterDeviceEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_RegisterDeviceEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_GetManagers = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_GetManagers, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterManagedApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_RegisterManagedApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_RegisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_RegisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_UnregisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_UnregisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_ProvideIdentities = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_ProvideIdentities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_UpdateSoftwareStatus = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_UpdateSoftwareStatus, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_RegisterDeviceEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_RegisterDeviceEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_GetManagers = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_GetManagers, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_RegisterManagedApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_RegisterManagedApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_RegisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_RegisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_UnregisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_UnregisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region Object Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.OPCUAOnboardingNamespaceMetadata, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.WellKnownRole_RegistrarAdmin, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarAdminType_TicketAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarAdminType_DeviceIdentityAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarType_Administration, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarType_Administration_TicketAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarType_Administration_DeviceIdentityAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar_Administration, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar_Administration_TicketAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar_Administration_DeviceIdentityAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CertificateAuthorityType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CertificateAuthorityType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId BaseTicketType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.BaseTicketType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityTicketType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceIdentityTicketType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CompositeIdentityTicketType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CompositeIdentityTicketType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId TicketListType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.TicketListType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId ManagerDescription_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.ManagerDescription_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CertificateAuthorityType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CertificateAuthorityType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId BaseTicketType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.BaseTicketType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityTicketType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceIdentityTicketType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CompositeIdentityTicketType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CompositeIdentityTicketType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId TicketListType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.TicketListType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId ManagerDescription_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.ManagerDescription_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CertificateAuthorityType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CertificateAuthorityType_Encoding_DefaultJson, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId BaseTicketType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.BaseTicketType_Encoding_DefaultJson, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityTicketType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceIdentityTicketType_Encoding_DefaultJson, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId CompositeIdentityTicketType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CompositeIdentityTicketType_Encoding_DefaultJson, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId TicketListType_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.TicketListType_Encoding_DefaultJson, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId ManagerDescription_Encoding_DefaultJson = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.ManagerDescription_Encoding_DefaultJson, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrarAdminType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrarType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrationAuditEventType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrationAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceIdentityAcceptedAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceSoftwareUpdatedAuditEventType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceSoftwareUpdatedAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region Variable Node Identifiers
    /// <remarks />
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceVersion, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespacePublicationDate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_IsNamespaceSubset, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_StaticNodeIdTypes, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_StaticNumericNodeIdRange, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_StaticStringNodeIdPattern, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_DefaultRolePermissions, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_DefaultUserRolePermissions, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_DefaultAccessRestrictions, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_Identities = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_Identities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_ApplicationsExclude = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_ApplicationsExclude, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_Applications = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_Applications, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_EndpointsExclude = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_EndpointsExclude, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_Endpoints = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_Endpoints, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_CustomConfiguration = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_CustomConfiguration, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddIdentity_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_AddIdentity_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveIdentity_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_RemoveIdentity_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_AddApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_RemoveApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_AddEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_RemoveEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_RegisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_RegisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_RegisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_RegisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_UnregisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_UnregisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_UnregisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_UnregisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_ProvideIdentities_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_ProvideIdentities_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_ProvideIdentities_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_ProvideIdentities_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_UpdateSoftwareStatus_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_UpdateSoftwareStatus_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterDeviceEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_RegisterDeviceEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_GetManagers_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_GetManagers_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterManagedApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_RegisterManagedApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterManagedApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_RegisterManagedApplication_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_RegisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_RegisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_RegisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_RegisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_UnregisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_UnregisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_UnregisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_UnregisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_ProvideIdentities_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_ProvideIdentities_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_ProvideIdentities_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_ProvideIdentities_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_UpdateSoftwareStatus_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_UpdateSoftwareStatus_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_RegisterDeviceEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_RegisterDeviceEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_GetManagers_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_GetManagers_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_RegisterManagedApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_RegisterManagedApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_RegisterManagedApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_RegisterManagedApplication_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_RegisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_RegisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_RegisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_RegisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_UnregisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_UnregisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_UnregisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_UnregisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceRegistrationAuditEventType_ProductInstanceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrationAuditEventType_ProductInstanceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType_Certificate = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceIdentityAcceptedAuditEventType_Certificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType_Ticket = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceIdentityAcceptedAuditEventType_Ticket, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType_Composite = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceIdentityAcceptedAuditEventType_Composite, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceSoftwareUpdatedAuditEventType_Status = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceSoftwareUpdatedAuditEventType_Status, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId DeviceSoftwareUpdatedAuditEventType_SoftwareRevision = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceSoftwareUpdatedAuditEventType_SoftwareRevision, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_NamespaceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_Deprecated = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_Deprecated, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_CertificateAuthorityType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_CertificateAuthorityType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_BaseTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_BaseTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_DeviceIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_DeviceIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_CompositeIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_CompositeIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_TicketListType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_TicketListType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_ManagerDescription = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_ManagerDescription, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_NamespaceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_Deprecated = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_Deprecated, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_CertificateAuthorityType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_CertificateAuthorityType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_BaseTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_BaseTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_DeviceIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_DeviceIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_CompositeIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_CompositeIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_TicketListType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_TicketListType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        /// <remarks />
        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_ManagerDescription = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_ManagerDescription, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region BrowseName Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class BrowseNames
    {
        /// <remarks />
        public const string AddApplication = "AddApplication";

        /// <remarks />
        public const string AddEndpoint = "AddEndpoint";

        /// <remarks />
        public const string AddIdentity = "AddIdentity";

        /// <remarks />
        public const string Administration = "Administration";

        /// <remarks />
        public const string Applications = "Applications";

        /// <remarks />
        public const string ApplicationsExclude = "ApplicationsExclude";

        /// <remarks />
        public const string BaseTicketType = "BaseTicketType";

        /// <remarks />
        public const string Certificate = "Certificate";

        /// <remarks />
        public const string CertificateAuthorityType = "CertificateAuthorityType";

        /// <remarks />
        public const string Composite = "Composite";

        /// <remarks />
        public const string CompositeIdentityTicketType = "CompositeIdentityTicketType";

        /// <remarks />
        public const string CustomConfiguration = "CustomConfiguration";

        /// <remarks />
        public const string DeviceIdentityAcceptedAuditEventType = "DeviceIdentityAcceptedAuditEventType";

        /// <remarks />
        public const string DeviceIdentityAuthorities = "DeviceIdentityAuthorities";

        /// <remarks />
        public const string DeviceIdentityTicketType = "DeviceIdentityTicketType";

        /// <remarks />
        public const string DeviceRegistrar = "DeviceRegistrar";

        /// <remarks />
        public const string DeviceRegistrarAdminType = "DeviceRegistrarAdminType";

        /// <remarks />
        public const string DeviceRegistrarType = "DeviceRegistrarType";

        /// <remarks />
        public const string DeviceRegistrationAuditEventType = "DeviceRegistrationAuditEventType";

        /// <remarks />
        public const string DeviceSoftwareUpdatedAuditEventType = "DeviceSoftwareUpdatedAuditEventType";

        /// <remarks />
        public const string Endpoints = "Endpoints";

        /// <remarks />
        public const string EndpointsExclude = "EndpointsExclude";

        /// <remarks />
        public const string GetManagers = "GetManagers";

        /// <remarks />
        public const string ManagerDescription = "ManagerDescription";

        /// <remarks />
        public const string ModelVersion = "ModelVersion";

        /// <remarks />
        public const string OpcUaOnboarding_BinarySchema = "Opc.Ua.Onboarding";

        /// <remarks />
        public const string OpcUaOnboarding_XmlSchema = "Opc.Ua.Onboarding";

        /// <remarks />
        public const string OPCUAOnboardingNamespaceMetadata = "http://opcfoundation.org/UA/Onboarding/";

        /// <remarks />
        public const string ProductInstanceUri = "ProductInstanceUri";

        /// <remarks />
        public const string ProvideIdentities = "ProvideIdentities";

        /// <remarks />
        public const string RegisterDeviceEndpoint = "RegisterDeviceEndpoint";

        /// <remarks />
        public const string RegisterManagedApplication = "RegisterManagedApplication";

        /// <remarks />
        public const string RegisterTickets = "RegisterTickets";

        /// <remarks />
        public const string RemoveApplication = "RemoveApplication";

        /// <remarks />
        public const string RemoveEndpoint = "RemoveEndpoint";

        /// <remarks />
        public const string RemoveIdentity = "RemoveIdentity";

        /// <remarks />
        public const string SoftwareRevision = "SoftwareRevision";

        /// <remarks />
        public const string Status = "Status";

        /// <remarks />
        public const string Ticket = "Ticket";

        /// <remarks />
        public const string TicketAuthorities = "TicketAuthorities";

        /// <remarks />
        public const string TicketListType = "TicketListType";

        /// <remarks />
        public const string UnregisterTickets = "UnregisterTickets";

        /// <remarks />
        public const string UpdateSoftwareStatus = "UpdateSoftwareStatus";

        /// <remarks />
        public const string WellKnownRole_RegistrarAdmin = "RegistrarAdmin";
    }
    #endregion

    #region Namespace Declarations
    /// <remarks />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the OpcUaOnboarding namespace (.NET code namespace is 'Opc.Ua.Onboarding').
        /// </summary>
        public const string OpcUaOnboarding = "http://opcfoundation.org/UA/Onboarding/";

        /// <summary>
        /// The URI for the OpcUaOnboardingXsd namespace (.NET code namespace is 'Opc.Ua.Onboarding').
        /// </summary>
        public const string OpcUaOnboardingXsd = "http://opcfoundation.org/UA/Onboarding/Types.xsd";

        /// <summary>
        /// The URI for the OpcUaGds namespace (.NET code namespace is 'Opc.Ua.Gds').
        /// </summary>
        public const string OpcUaGds = "http://opcfoundation.org/UA/GDS/";

        /// <summary>
        /// The URI for the OpcUaGdsXsd namespace (.NET code namespace is 'Opc.Ua.Gds').
        /// </summary>
        public const string OpcUaGdsXsd = "http://opcfoundation.org/UA/GDS/Types.xsd";

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
