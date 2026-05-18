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

namespace Opc.Ua.Gds {}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace Opc.Ua.Onboarding
{
    #region DataType Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class DataTypes
    {
        public const uint CertificateAuthorityType = 1164;

        public const uint BaseTicketType = 1165;

        public const uint DeviceIdentityTicketType = 1166;

        public const uint CompositeIdentityTicketType = 1167;

        public const uint TicketListType = 1168;

        public const uint ManagerDescription = 1495;
    }
    #endregion

    #region Method Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Methods
    {
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open = 17;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close = 20;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read = 22;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write = 25;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition = 27;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition = 30;

        public const uint WellKnownRole_RegistrarAdmin_AddIdentity = 5041;

        public const uint WellKnownRole_RegistrarAdmin_RemoveIdentity = 5043;

        public const uint WellKnownRole_RegistrarAdmin_AddApplication = 5045;

        public const uint WellKnownRole_RegistrarAdmin_RemoveApplication = 5047;

        public const uint WellKnownRole_RegistrarAdmin_AddEndpoint = 5049;

        public const uint WellKnownRole_RegistrarAdmin_RemoveEndpoint = 5051;

        public const uint DeviceRegistrarAdminType_RegisterTickets = 1176;

        public const uint DeviceRegistrarAdminType_UnregisterTickets = 1179;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Open = 1190;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Close = 1193;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Read = 1195;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Write = 1198;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_GetPosition = 1200;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_SetPosition = 1203;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks = 1208;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate = 1211;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_AddCertificate = 1214;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate = 1216;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open = 1226;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close = 1229;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read = 1231;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write = 1234;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition = 1236;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition = 1239;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks = 1244;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate = 1247;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate = 1250;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate = 1252;

        public const uint DeviceRegistrarType_ProvideIdentities = 1260;

        public const uint DeviceRegistrarType_UpdateSoftwareStatus = 1503;

        public const uint DeviceRegistrarType_RegisterDeviceEndpoint = 1263;

        public const uint DeviceRegistrarType_GetManagers = 1505;

        public const uint DeviceRegistrarType_RegisterManagedApplication = 1507;

        public const uint DeviceRegistrarType_Administration_RegisterTickets = 1266;

        public const uint DeviceRegistrarType_Administration_UnregisterTickets = 1269;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Open = 1280;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Close = 1283;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Read = 1285;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Write = 1288;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_GetPosition = 1290;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_SetPosition = 1293;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks = 1298;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate = 1301;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate = 1304;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate = 1306;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open = 1316;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close = 1319;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read = 1321;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write = 1324;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition = 1326;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition = 1329;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks = 1334;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate = 1337;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate = 1340;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate = 1342;

        public const uint DeviceRegistrar_ProvideIdentities = 1345;

        public const uint DeviceRegistrar_UpdateSoftwareStatus = 1510;

        public const uint DeviceRegistrar_RegisterDeviceEndpoint = 1348;

        public const uint DeviceRegistrar_GetManagers = 1512;

        public const uint DeviceRegistrar_RegisterManagedApplication = 1514;

        public const uint DeviceRegistrar_Administration_RegisterTickets = 1351;

        public const uint DeviceRegistrar_Administration_UnregisterTickets = 1354;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Open = 1365;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Close = 1368;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Read = 1370;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Write = 1373;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_GetPosition = 1375;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_SetPosition = 1378;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks = 1383;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate = 1386;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_AddCertificate = 1389;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate = 1391;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open = 1401;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close = 1404;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read = 1406;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write = 1409;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition = 1411;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition = 1414;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks = 1419;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate = 1422;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate = 1425;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate = 1427;
    }
    #endregion

    #region Object Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Objects
    {
        public const uint OPCUAOnboardingNamespaceMetadata = 1;

        public const uint WellKnownRole_RegistrarAdmin = 5034;

        public const uint DeviceRegistrarAdminType_TicketAuthorities = 1182;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities = 1218;

        public const uint DeviceRegistrarType_Administration = 1265;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities = 1272;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities = 1308;

        public const uint DeviceRegistrar = 1344;

        public const uint DeviceRegistrar_Administration = 1350;

        public const uint DeviceRegistrar_Administration_TicketAuthorities = 1357;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities = 1393;

        public const uint CertificateAuthorityType_Encoding_DefaultBinary = 1439;

        public const uint BaseTicketType_Encoding_DefaultBinary = 1440;

        public const uint DeviceIdentityTicketType_Encoding_DefaultBinary = 1441;

        public const uint CompositeIdentityTicketType_Encoding_DefaultBinary = 1442;

        public const uint TicketListType_Encoding_DefaultBinary = 1443;

        public const uint ManagerDescription_Encoding_DefaultBinary = 4206;

        public const uint CertificateAuthorityType_Encoding_DefaultXml = 1463;

        public const uint BaseTicketType_Encoding_DefaultXml = 1464;

        public const uint DeviceIdentityTicketType_Encoding_DefaultXml = 1465;

        public const uint CompositeIdentityTicketType_Encoding_DefaultXml = 1466;

        public const uint TicketListType_Encoding_DefaultXml = 1467;

        public const uint ManagerDescription_Encoding_DefaultXml = 4214;
    }
    #endregion

    #region ObjectType Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectTypes
    {
        public const uint DeviceRegistrarAdminType = 1175;

        public const uint DeviceRegistrarType = 1259;

        public const uint DeviceRegistrationAuditEventType = 1517;

        public const uint DeviceIdentityAcceptedAuditEventType = 1533;

        public const uint DeviceSoftwareUpdatedAuditEventType = 1552;
    }
    #endregion

    #region Variable Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Variables
    {
        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceUri = 2;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceVersion = 3;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespacePublicationDate = 4;

        public const uint OPCUAOnboardingNamespaceMetadata_IsNamespaceSubset = 5;

        public const uint OPCUAOnboardingNamespaceMetadata_StaticNodeIdTypes = 6;

        public const uint OPCUAOnboardingNamespaceMetadata_StaticNumericNodeIdRange = 7;

        public const uint OPCUAOnboardingNamespaceMetadata_StaticStringNodeIdPattern = 8;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Size = 10;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Writable = 11;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_UserWritable = 12;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_OpenCount = 13;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_InputArguments = 18;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_OutputArguments = 19;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close_InputArguments = 21;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_InputArguments = 23;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_OutputArguments = 24;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write_InputArguments = 26;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = 28;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = 29;

        public const uint OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = 31;

        public const uint OPCUAOnboardingNamespaceMetadata_DefaultRolePermissions = 33;

        public const uint OPCUAOnboardingNamespaceMetadata_DefaultUserRolePermissions = 34;

        public const uint OPCUAOnboardingNamespaceMetadata_DefaultAccessRestrictions = 35;

        public const uint WellKnownRole_RegistrarAdmin_Identities = 5035;

        public const uint WellKnownRole_RegistrarAdmin_ApplicationsExclude = 5036;

        public const uint WellKnownRole_RegistrarAdmin_Applications = 5037;

        public const uint WellKnownRole_RegistrarAdmin_EndpointsExclude = 5038;

        public const uint WellKnownRole_RegistrarAdmin_Endpoints = 5039;

        public const uint WellKnownRole_RegistrarAdmin_CustomConfiguration = 5040;

        public const uint WellKnownRole_RegistrarAdmin_AddIdentity_InputArguments = 5042;

        public const uint WellKnownRole_RegistrarAdmin_RemoveIdentity_InputArguments = 5044;

        public const uint WellKnownRole_RegistrarAdmin_AddApplication_InputArguments = 5046;

        public const uint WellKnownRole_RegistrarAdmin_RemoveApplication_InputArguments = 5048;

        public const uint WellKnownRole_RegistrarAdmin_AddEndpoint_InputArguments = 5050;

        public const uint WellKnownRole_RegistrarAdmin_RemoveEndpoint_InputArguments = 5052;

        public const uint DeviceRegistrarAdminType_RegisterTickets_InputArguments = 1177;

        public const uint DeviceRegistrarAdminType_RegisterTickets_OutputArguments = 1178;

        public const uint DeviceRegistrarAdminType_UnregisterTickets_InputArguments = 1180;

        public const uint DeviceRegistrarAdminType_UnregisterTickets_OutputArguments = 1181;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Size = 1183;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Writable = 1184;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_UserWritable = 1185;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenCount = 1186;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Open_InputArguments = 1191;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Open_OutputArguments = 1192;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Close_InputArguments = 1194;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Read_InputArguments = 1196;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Read_OutputArguments = 1197;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_Write_InputArguments = 1199;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_GetPosition_InputArguments = 1201;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_GetPosition_OutputArguments = 1202;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_SetPosition_InputArguments = 1204;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_LastUpdateTime = 1205;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_InputArguments = 1209;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_OutputArguments = 1210;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_InputArguments = 1212;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_OutputArguments = 1213;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_AddCertificate_InputArguments = 1215;

        public const uint DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate_InputArguments = 1217;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Size = 1219;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Writable = 1220;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_UserWritable = 1221;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenCount = 1222;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_InputArguments = 1227;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_OutputArguments = 1228;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close_InputArguments = 1230;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_InputArguments = 1232;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_OutputArguments = 1233;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write_InputArguments = 1235;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_InputArguments = 1237;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_OutputArguments = 1238;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition_InputArguments = 1240;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_LastUpdateTime = 1241;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = 1245;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = 1246;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = 1248;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = 1249;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate_InputArguments = 1251;

        public const uint DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = 1253;

        public const uint DeviceRegistrarType_ProvideIdentities_InputArguments = 1261;

        public const uint DeviceRegistrarType_ProvideIdentities_OutputArguments = 1262;

        public const uint DeviceRegistrarType_UpdateSoftwareStatus_InputArguments = 1504;

        public const uint DeviceRegistrarType_RegisterDeviceEndpoint_InputArguments = 1264;

        public const uint DeviceRegistrarType_GetManagers_OutputArguments = 1506;

        public const uint DeviceRegistrarType_RegisterManagedApplication_InputArguments = 1508;

        public const uint DeviceRegistrarType_RegisterManagedApplication_OutputArguments = 1509;

        public const uint DeviceRegistrarType_Administration_RegisterTickets_InputArguments = 1267;

        public const uint DeviceRegistrarType_Administration_RegisterTickets_OutputArguments = 1268;

        public const uint DeviceRegistrarType_Administration_UnregisterTickets_InputArguments = 1270;

        public const uint DeviceRegistrarType_Administration_UnregisterTickets_OutputArguments = 1271;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Size = 1273;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Writable = 1274;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_UserWritable = 1275;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenCount = 1276;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Open_InputArguments = 1281;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Open_OutputArguments = 1282;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Close_InputArguments = 1284;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Read_InputArguments = 1286;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Read_OutputArguments = 1287;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_Write_InputArguments = 1289;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_InputArguments = 1291;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_OutputArguments = 1292;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_SetPosition_InputArguments = 1294;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_LastUpdateTime = 1295;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_InputArguments = 1299;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = 1300;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = 1302;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = 1303;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate_InputArguments = 1305;

        public const uint DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate_InputArguments = 1307;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Size = 1309;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Writable = 1310;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_UserWritable = 1311;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenCount = 1312;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_InputArguments = 1317;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_OutputArguments = 1318;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close_InputArguments = 1320;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_InputArguments = 1322;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_OutputArguments = 1323;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write_InputArguments = 1325;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = 1327;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = 1328;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = 1330;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_LastUpdateTime = 1331;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = 1335;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = 1336;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = 1338;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = 1339;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = 1341;

        public const uint DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = 1343;

        public const uint DeviceRegistrar_ProvideIdentities_InputArguments = 1346;

        public const uint DeviceRegistrar_ProvideIdentities_OutputArguments = 1347;

        public const uint DeviceRegistrar_UpdateSoftwareStatus_InputArguments = 1511;

        public const uint DeviceRegistrar_RegisterDeviceEndpoint_InputArguments = 1349;

        public const uint DeviceRegistrar_GetManagers_OutputArguments = 1513;

        public const uint DeviceRegistrar_RegisterManagedApplication_InputArguments = 1515;

        public const uint DeviceRegistrar_RegisterManagedApplication_OutputArguments = 1516;

        public const uint DeviceRegistrar_Administration_RegisterTickets_InputArguments = 1352;

        public const uint DeviceRegistrar_Administration_RegisterTickets_OutputArguments = 1353;

        public const uint DeviceRegistrar_Administration_UnregisterTickets_InputArguments = 1355;

        public const uint DeviceRegistrar_Administration_UnregisterTickets_OutputArguments = 1356;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Size = 1358;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Writable = 1359;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_UserWritable = 1360;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenCount = 1361;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Open_InputArguments = 1366;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Open_OutputArguments = 1367;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Close_InputArguments = 1369;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Read_InputArguments = 1371;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Read_OutputArguments = 1372;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_Write_InputArguments = 1374;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_GetPosition_InputArguments = 1376;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_GetPosition_OutputArguments = 1377;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_SetPosition_InputArguments = 1379;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_LastUpdateTime = 1380;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_InputArguments = 1384;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = 1385;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = 1387;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = 1388;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_AddCertificate_InputArguments = 1390;

        public const uint DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate_InputArguments = 1392;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Size = 1394;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Writable = 1395;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_UserWritable = 1396;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenCount = 1397;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_InputArguments = 1402;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_OutputArguments = 1403;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close_InputArguments = 1405;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_InputArguments = 1407;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_OutputArguments = 1408;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write_InputArguments = 1410;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = 1412;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = 1413;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = 1415;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_LastUpdateTime = 1416;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = 1420;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = 1421;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = 1423;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = 1424;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = 1426;

        public const uint DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = 1428;

        public const uint DeviceRegistrationAuditEventType_ProductInstanceUri = 1532;

        public const uint DeviceIdentityAcceptedAuditEventType_Certificate = 1549;

        public const uint DeviceIdentityAcceptedAuditEventType_Ticket = 1550;

        public const uint DeviceIdentityAcceptedAuditEventType_Composite = 1551;

        public const uint DeviceSoftwareUpdatedAuditEventType_Status = 1563;

        public const uint DeviceSoftwareUpdatedAuditEventType_SoftwareRevision = 1568;

        public const uint OpcUaOnboarding_BinarySchema = 1444;

        public const uint OpcUaOnboarding_BinarySchema_NamespaceUri = 1446;

        public const uint OpcUaOnboarding_BinarySchema_Deprecated = 1447;

        public const uint OpcUaOnboarding_BinarySchema_CertificateAuthorityType = 1448;

        public const uint OpcUaOnboarding_BinarySchema_BaseTicketType = 1451;

        public const uint OpcUaOnboarding_BinarySchema_DeviceIdentityTicketType = 1454;

        public const uint OpcUaOnboarding_BinarySchema_CompositeIdentityTicketType = 1457;

        public const uint OpcUaOnboarding_BinarySchema_TicketListType = 1460;

        public const uint OpcUaOnboarding_BinarySchema_ManagerDescription = 4208;

        public const uint OpcUaOnboarding_XmlSchema = 1468;

        public const uint OpcUaOnboarding_XmlSchema_NamespaceUri = 1470;

        public const uint OpcUaOnboarding_XmlSchema_Deprecated = 1471;

        public const uint OpcUaOnboarding_XmlSchema_CertificateAuthorityType = 1472;

        public const uint OpcUaOnboarding_XmlSchema_BaseTicketType = 1475;

        public const uint OpcUaOnboarding_XmlSchema_DeviceIdentityTicketType = 1478;

        public const uint OpcUaOnboarding_XmlSchema_CompositeIdentityTicketType = 1481;

        public const uint OpcUaOnboarding_XmlSchema_TicketListType = 1484;

        public const uint OpcUaOnboarding_XmlSchema_ManagerDescription = 4216;
    }
    #endregion

    #region DataType Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class DataTypeIds
    {
        public static readonly ExpandedNodeId CertificateAuthorityType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.CertificateAuthorityType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId BaseTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.BaseTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.DeviceIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId CompositeIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.CompositeIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId TicketListType = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.TicketListType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId ManagerDescription = new ExpandedNodeId(Opc.Ua.Onboarding.DataTypes.ManagerDescription, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region Method Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class MethodIds
    {
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddIdentity = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_AddIdentity, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveIdentity = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_RemoveIdentity, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_AddApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_RemoveApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_AddEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.WellKnownRole_RegistrarAdmin_RemoveEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_RegisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_RegisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_UnregisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_UnregisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_ProvideIdentities = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_ProvideIdentities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_UpdateSoftwareStatus = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_UpdateSoftwareStatus, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterDeviceEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_RegisterDeviceEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_GetManagers = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_GetManagers, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterManagedApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_RegisterManagedApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_RegisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_RegisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_UnregisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_UnregisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_ProvideIdentities = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_ProvideIdentities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_UpdateSoftwareStatus = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_UpdateSoftwareStatus, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_RegisterDeviceEndpoint = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_RegisterDeviceEndpoint, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_GetManagers = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_GetManagers, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_RegisterManagedApplication = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_RegisterManagedApplication, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_RegisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_RegisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_UnregisterTickets = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_UnregisterTickets, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate = new ExpandedNodeId(Opc.Ua.Onboarding.Methods.DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region Object Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectIds
    {
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.OPCUAOnboardingNamespaceMetadata, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.WellKnownRole_RegistrarAdmin, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarAdminType_TicketAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarAdminType_DeviceIdentityAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarType_Administration, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarType_Administration_TicketAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrarType_Administration_DeviceIdentityAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar_Administration, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar_Administration_TicketAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceRegistrar_Administration_DeviceIdentityAuthorities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId CertificateAuthorityType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CertificateAuthorityType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId BaseTicketType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.BaseTicketType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityTicketType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceIdentityTicketType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId CompositeIdentityTicketType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CompositeIdentityTicketType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId TicketListType_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.TicketListType_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId ManagerDescription_Encoding_DefaultBinary = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.ManagerDescription_Encoding_DefaultBinary, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId CertificateAuthorityType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CertificateAuthorityType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId BaseTicketType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.BaseTicketType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityTicketType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.DeviceIdentityTicketType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId CompositeIdentityTicketType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.CompositeIdentityTicketType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId TicketListType_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.TicketListType_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId ManagerDescription_Encoding_DefaultXml = new ExpandedNodeId(Opc.Ua.Onboarding.Objects.ManagerDescription_Encoding_DefaultXml, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectTypeIds
    {
        public static readonly ExpandedNodeId DeviceRegistrarAdminType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrarAdminType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrarType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrationAuditEventType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceRegistrationAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceIdentityAcceptedAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceSoftwareUpdatedAuditEventType = new ExpandedNodeId(Opc.Ua.Onboarding.ObjectTypes.DeviceSoftwareUpdatedAuditEventType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region Variable Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class VariableIds
    {
        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceVersion = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceVersion, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespacePublicationDate = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespacePublicationDate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_IsNamespaceSubset = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_IsNamespaceSubset, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_StaticNodeIdTypes = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_StaticNodeIdTypes, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_StaticNumericNodeIdRange = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_StaticNumericNodeIdRange, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_StaticStringNodeIdPattern = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_StaticStringNodeIdPattern, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_NamespaceFile_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_DefaultRolePermissions = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_DefaultRolePermissions, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_DefaultUserRolePermissions = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_DefaultUserRolePermissions, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OPCUAOnboardingNamespaceMetadata_DefaultAccessRestrictions = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OPCUAOnboardingNamespaceMetadata_DefaultAccessRestrictions, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_Identities = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_Identities, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_ApplicationsExclude = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_ApplicationsExclude, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_Applications = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_Applications, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_EndpointsExclude = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_EndpointsExclude, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_Endpoints = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_Endpoints, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_CustomConfiguration = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_CustomConfiguration, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddIdentity_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_AddIdentity_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveIdentity_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_RemoveIdentity_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_AddApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_RemoveApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_AddEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_AddEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId WellKnownRole_RegistrarAdmin_RemoveEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.WellKnownRole_RegistrarAdmin_RemoveEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_RegisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_RegisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_RegisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_RegisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_UnregisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_UnregisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_UnregisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_UnregisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_TicketAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarAdminType_DeviceIdentityAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_ProvideIdentities_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_ProvideIdentities_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_ProvideIdentities_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_ProvideIdentities_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_UpdateSoftwareStatus_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_UpdateSoftwareStatus_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterDeviceEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_RegisterDeviceEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_GetManagers_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_GetManagers_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterManagedApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_RegisterManagedApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_RegisterManagedApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_RegisterManagedApplication_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_RegisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_RegisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_RegisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_RegisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_UnregisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_UnregisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_UnregisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_UnregisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_TicketAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrarType_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_ProvideIdentities_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_ProvideIdentities_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_ProvideIdentities_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_ProvideIdentities_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_UpdateSoftwareStatus_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_UpdateSoftwareStatus_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_RegisterDeviceEndpoint_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_RegisterDeviceEndpoint_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_GetManagers_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_GetManagers_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_RegisterManagedApplication_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_RegisterManagedApplication_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_RegisterManagedApplication_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_RegisterManagedApplication_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_RegisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_RegisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_RegisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_RegisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_UnregisterTickets_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_UnregisterTickets_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_UnregisterTickets_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_UnregisterTickets_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_TicketAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Size = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Size, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Writable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Writable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_UserWritable = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_UserWritable, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenCount = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenCount, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Open_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Close_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Read_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_Write_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_GetPosition_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_SetPosition_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_LastUpdateTime = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_LastUpdateTime, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_OpenWithMasks_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_CloseAndUpdate_OutputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_AddCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrar_Administration_DeviceIdentityAuthorities_RemoveCertificate_InputArguments, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceRegistrationAuditEventType_ProductInstanceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceRegistrationAuditEventType_ProductInstanceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType_Certificate = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceIdentityAcceptedAuditEventType_Certificate, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType_Ticket = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceIdentityAcceptedAuditEventType_Ticket, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceIdentityAcceptedAuditEventType_Composite = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceIdentityAcceptedAuditEventType_Composite, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceSoftwareUpdatedAuditEventType_Status = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceSoftwareUpdatedAuditEventType_Status, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId DeviceSoftwareUpdatedAuditEventType_SoftwareRevision = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.DeviceSoftwareUpdatedAuditEventType_SoftwareRevision, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_NamespaceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_Deprecated = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_Deprecated, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_CertificateAuthorityType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_CertificateAuthorityType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_BaseTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_BaseTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_DeviceIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_DeviceIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_CompositeIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_CompositeIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_TicketListType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_TicketListType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_BinarySchema_ManagerDescription = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_BinarySchema_ManagerDescription, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_NamespaceUri = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_NamespaceUri, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_Deprecated = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_Deprecated, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_CertificateAuthorityType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_CertificateAuthorityType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_BaseTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_BaseTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_DeviceIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_DeviceIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_CompositeIdentityTicketType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_CompositeIdentityTicketType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_TicketListType = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_TicketListType, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);

        public static readonly ExpandedNodeId OpcUaOnboarding_XmlSchema_ManagerDescription = new ExpandedNodeId(Opc.Ua.Onboarding.Variables.OpcUaOnboarding_XmlSchema_ManagerDescription, Opc.Ua.Onboarding.Namespaces.OpcUaOnboarding);
    }
    #endregion

    #region BrowseName Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class BrowseNames
    {
        public const string AddApplication = "AddApplication";

        public const string AddEndpoint = "AddEndpoint";

        public const string AddIdentity = "AddIdentity";

        public const string Administration = "Administration";

        public const string Applications = "Applications";

        public const string ApplicationsExclude = "ApplicationsExclude";

        public const string BaseTicketType = "BaseTicketType";

        public const string Certificate = "Certificate";

        public const string CertificateAuthorityType = "CertificateAuthorityType";

        public const string Composite = "Composite";

        public const string CompositeIdentityTicketType = "CompositeIdentityTicketType";

        public const string CustomConfiguration = "CustomConfiguration";

        public const string DeviceIdentityAcceptedAuditEventType = "DeviceIdentityAcceptedAuditEventType";

        public const string DeviceIdentityAuthorities = "DeviceIdentityAuthorities";

        public const string DeviceIdentityTicketType = "DeviceIdentityTicketType";

        public const string DeviceRegistrar = "DeviceRegistrar";

        public const string DeviceRegistrarAdminType = "DeviceRegistrarAdminType";

        public const string DeviceRegistrarType = "DeviceRegistrarType";

        public const string DeviceRegistrationAuditEventType = "DeviceRegistrationAuditEventType";

        public const string DeviceSoftwareUpdatedAuditEventType = "DeviceSoftwareUpdatedAuditEventType";

        public const string Endpoints = "Endpoints";

        public const string EndpointsExclude = "EndpointsExclude";

        public const string GetManagers = "GetManagers";

        public const string ManagerDescription = "ManagerDescription";

        public const string OpcUaOnboarding_BinarySchema = "Opc.Ua.Onboarding";

        public const string OpcUaOnboarding_XmlSchema = "Opc.Ua.Onboarding";

        public const string OPCUAOnboardingNamespaceMetadata = "http://opcfoundation.org/UA/Onboarding/";

        public const string ProductInstanceUri = "ProductInstanceUri";

        public const string ProvideIdentities = "ProvideIdentities";

        public const string RegisterDeviceEndpoint = "RegisterDeviceEndpoint";

        public const string RegisterManagedApplication = "RegisterManagedApplication";

        public const string RegisterTickets = "RegisterTickets";

        public const string RemoveApplication = "RemoveApplication";

        public const string RemoveEndpoint = "RemoveEndpoint";

        public const string RemoveIdentity = "RemoveIdentity";

        public const string SoftwareRevision = "SoftwareRevision";

        public const string Status = "Status";

        public const string Ticket = "Ticket";

        public const string TicketAuthorities = "TicketAuthorities";

        public const string TicketListType = "TicketListType";

        public const string UnregisterTickets = "UnregisterTickets";

        public const string UpdateSoftwareStatus = "UpdateSoftwareStatus";

        public const string WellKnownRole_RegistrarAdmin = "RegistrarAdmin";
    }
    #endregion

    #region Namespace Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
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