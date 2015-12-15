/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
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
using Opc.Ua.Di;
using Opc.Ua;

namespace Opc.Ua.Adi
{
    #region AnalyserDeviceState Class
    #if (!OPCUA_EXCLUDE_AnalyserDeviceState)
    /// <summary>
    /// Stores an instance of the AnalyserDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserDeviceState : DeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAaAAAAQW5hbHlzZXJEZXZpY2VUeXBlSW5zdGFuY2UB" +
           "AekDAQHpAwH/////DwAAACRggAoBAAAAAgAMAAAAUGFyYW1ldGVyU2V0AQGJEwMAAAAAFwAAAEZsYXQg" +
           "bGlzdCBvZiBQYXJhbWV0ZXJzAC8AOokTAAD/////DAAAADVgiQoCAAAAAQAQAAAARGlhZ25vc3RpY1N0" +
           "YXR1cwEBeBcDAAAAACUAAABHZW5lcmFsIGhlYWx0aCBzdGF0dXMgb2YgdGhlIGFuYWx5c2VyAC8BAD0J" +
           "eBcAAAEBugv/////AQEBAAAAACMBAQGMEwAAAAA1YIkKAgAAAAEAEgAAAE91dE9mU3BlY2lmaWNhdGlv" +
           "bgEBexcDAAAAAGQAAABEZXZpY2UgYmVpbmcgb3BlcmF0ZWQgb3V0IG9mIFNwZWNpZmljYXRpb24uIFVu" +
           "Y2VydGFpbiB2YWx1ZSBkdWUgdG8gcHJvY2VzcyBhbmQgZW52aXJvbm1lbnQgaW5mbHVlbmNlAC8BAEUJ" +
           "excAAAAB/////wEBAQAAAAAjAQEBjBMCAAAAFWCJCgIAAAAAAAoAAABGYWxzZVN0YXRlAQF+FwAuAER+" +
           "FwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQF/FwAuAER/FwAAABX/////" +
           "AQH/////AAAAADVgiQoCAAAAAQANAAAARnVuY3Rpb25DaGVjawEBgBcDAAAAAEUAAABMb2NhbCBvcGVy" +
           "YXRpb24sIGNvbmZpZ3VyYXRpb24gaXMgY2hhbmdpbmcsIHN1YnN0aXR1dGUgdmFsdWUgZW50ZXJlZC4A" +
           "LwEARQmAFwAAAAH/////AQEBAAAAACMBAQGMEwIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAYMX" +
           "AC4ARIMXAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAYQXAC4ARIQXAAAA" +
           "Ff////8BAf////8AAAAANWCJCgIAAAABAAwAAABTZXJpYWxOdW1iZXIBAYUXAwAAAABNAAAASWRlbnRp" +
           "ZmllciB0aGF0IHVuaXF1ZWx5IGlkZW50aWZpZXMsIHdpdGhpbiBhIG1hbnVmYWN0dXJlciwgYSBkZXZp" +
           "Y2UgaW5zdGFuY2UALwEAPQmFFwAAAAz/////AQECAAAAACMBAQGcHwAjAQEBjRMAAAAANWCJCgIAAAAB" +
           "AAwAAABNYW51ZmFjdHVyZXIBAYgXAwAAAAAwAAAATmFtZSBvZiB0aGUgY29tcGFueSB0aGF0IG1hbnVm" +
           "YWN0dXJlZCB0aGUgZGV2aWNlAC8BAD0JiBcAAAAV/////wEBAgAAAAAjAQEBnB8AIwEBAY0TAAAAADVg" +
           "iQoCAAAAAQAFAAAATW9kZWwBAYsXAwAAAAAYAAAATW9kZWwgbmFtZSBvZiB0aGUgZGV2aWNlAC8BAD0J" +
           "ixcAAAAV/////wEBAgAAAAAjAQEBnB8AIwEBAY0TAAAAADVgiQoCAAAAAQAMAAAARGV2aWNlTWFudWFs" +
           "AQGOFwMAAAAAWgAAAEFkZHJlc3MgKHBhdGhuYW1lIGluIHRoZSBmaWxlIHN5c3RlbSBvciBhIFVSTCB8" +
           "IFdlYiBhZGRyZXNzKSBvZiB1c2VyIG1hbnVhbCBmb3IgdGhlIGRldmljZQAvAQA9CY4XAAAADP////8B" +
           "AQEAAAAAIwEBAY0TAAAAADVgiQoCAAAAAQAOAAAARGV2aWNlUmV2aXNpb24BAZEXAwAAAAAkAAAAT3Zl" +
           "cmFsbCByZXZpc2lvbiBsZXZlbCBvZiB0aGUgZGV2aWNlAC8BAD0JkRcAAAAM/////wEBAQAAAAAjAQEB" +
           "jRMAAAAANWCJCgIAAAABABAAAABTb2Z0d2FyZVJldmlzaW9uAQGUFwMAAAAANQAAAFJldmlzaW9uIGxl" +
           "dmVsIG9mIHRoZSBzb2Z0d2FyZS9maXJtd2FyZSBvZiB0aGUgZGV2aWNlAC8BAD0JlBcAAAAM/////wEB" +
           "AQAAAAAjAQEBjRMAAAAANWCJCgIAAAABABAAAABIYXJkd2FyZVJldmlzaW9uAQGXFwMAAAAALAAAAFJl" +
           "dmlzaW9uIGxldmVsIG9mIHRoZSBoYXJkd2FyZSBvZiB0aGUgZGV2aWNlAC8BAD0JlxcAAAAM/////wEB" +
           "AQAAAAAjAQEBjRMAAAAANWCJCgIAAAABAA8AAABSZXZpc2lvbkNvdW50ZXIBAZoXAwAAAABpAAAAQW4g" +
           "aW5jcmVtZW50YWwgY291bnRlciBpbmRpY2F0aW5nIHRoZSBudW1iZXIgb2YgdGltZXMgdGhlIHN0YXRp" +
           "YyBkYXRhIHdpdGhpbiB0aGUgRGV2aWNlIGhhcyBiZWVuIG1vZGlmaWVkAC8BAD0JmhcAAAAH/////wEB" +
           "AQAAAAAjAQEBjRMAAAAANWCJCgIAAAABAAoAAABNQUNBZGRyZXNzAQGgFwMAAAAAHAAAAEFuYWx5c2Vy" +
           "IHByaW1hcnkgTUFDIGFkZHJlc3MALwEAPQmgFwAAAAz/////AQH/////AAAAACRggAoBAAAAAgAJAAAA" +
           "TWV0aG9kU2V0AQGKEwMAAAAAFAAAAEZsYXQgbGlzdCBvZiBNZXRob2RzAC8AOooTAAD/////CgAAAARh" +
           "ggoEAAAAAQAQAAAAR2V0Q29uZmlndXJhdGlvbgEBnh8ALwEBnh+eHwAAAQH/////AQAAABVgqQoCAAAA" +
           "AAAPAAAAT3V0cHV0QXJndW1lbnRzAQGfHwAuAESfHwAAlgEAAAABACoBARkAAAAKAAAAQ29uZmlnRGF0" +
           "YQAP/////wAAAAAAAQAoAQEAAAABAf////8AAAAABGGCCgQAAAABABAAAABTZXRDb25maWd1cmF0aW9u" +
           "AQGgHwAvAQGgH6AfAAABAf////8CAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBoR8ALgBE" +
           "oR8AAJYBAAAAAQAqAQEZAAAACgAAAENvbmZpZ0RhdGEAD/////8AAAAAAAEAKAEBAAAAAQH/////AAAA" +
           "ABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQGiHwAuAESiHwAAlgEAAAABACoBAR8AAAAQAAAA" +
           "Q29uZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAABGGCCgQAAAABABMAAABH" +
           "ZXRDb25maWdEYXRhRGlnZXN0AQGjHwAvAQGjH6MfAAABAf////8BAAAAFWCpCgIAAAAAAA8AAABPdXRw" +
           "dXRBcmd1bWVudHMBAaQfAC4ARKQfAACWAQAAAAEAKgEBHwAAABAAAABDb25maWdEYXRhRGlnZXN0AAz/" +
           "////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEAFwAAAENvbXBhcmVDb25maWdEYXRhRGln" +
           "ZXN0AQGlHwAvAQGlH6UfAAABAf////8CAAAAFWCpCgIAAAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBph8A" +
           "LgBEph8AAJYBAAAAAQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP////8AAAAAAAEAKAEBAAAA" +
           "AQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQGnHwAuAESnHwAAlgEAAAABACoB" +
           "ARYAAAAHAAAASXNFcXVhbAAB/////wAAAAAAAQAoAQEAAAABAf////8AAAAAJGGCCgQAAAABABAAAABS" +
           "ZXNldEFsbENoYW5uZWxzAQGoHwMAAAAAPAAAAFJlc2V0IGFsbCBBbmFseXNlckNoYW5uZWxzIGJlbG9u" +
           "Z2luZyB0byB0aGlzIEFuYWx5c2VyRGV2aWNlLgAvAQGoH6gfAAABAf////8AAAAAJGGCCgQAAAABABAA" +
           "AABTdGFydEFsbENoYW5uZWxzAQGpHwMAAAAAPAAAAFN0YXJ0IGFsbCBBbmFseXNlckNoYW5uZWxzIGJl" +
           "bG9uZ2luZyB0byB0aGlzIEFuYWx5c2VyRGV2aWNlLgAvAQGpH6kfAAABAf////8AAAAAJGGCCgQAAAAB" +
           "AA8AAABTdG9wQWxsQ2hhbm5lbHMBAaofAwAAAAA7AAAAU3RvcCBhbGwgQW5hbHlzZXJDaGFubmVscyBi" +
           "ZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRldmljZS4ALwEBqh+qHwAAAQH/////AAAAACRhggoEAAAA" +
           "AQAQAAAAQWJvcnRBbGxDaGFubmVscwEBqx8DAAAAADwAAABBYm9ydCBhbGwgQW5hbHlzZXJDaGFubmVs" +
           "cyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRldmljZS4ALwEBqx+rHwAAAQH/////AAAAACRhggoE" +
           "AAAAAQANAAAAR290b09wZXJhdGluZwEBrB8DAAAAAI0AAABBbmFseXNlckRldmljZVN0YXRlTWFjaGlu" +
           "ZSB0byBnbyB0byBPcGVyYXRpbmcgc3RhdGUsIGZvcmNpbmcgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgdG8g" +
           "bGVhdmUgdGhlIFNsYXZlTW9kZSBzdGF0ZSBhbmQgZ28gdG8gdGhlIE9wZXJhdGluZyBzdGF0ZS4ALwEB" +
           "rB+sHwAAAQH/////AAAAACRhggoEAAAAAQAPAAAAR290b01haW50ZW5hbmNlAQGtHwMAAAAAZwAAAEFu" +
           "YWx5c2VyRGV2aWNlU3RhdGVNYWNoaW5lIHRvIGdvIHRvIE1haW50ZW5hbmNlIHN0YXRlLCBmb3JjaW5n" +
           "IGFsbCBBbmFseXNlckNoYW5uZWxzIHRvIFNsYXZlTW9kZSBzdGF0ZS4ALwEBrR+tHwAAAQH/////AAAA" +
           "ACRggAoBAAAAAQAOAAAASWRlbnRpZmljYXRpb24BAZwfAwAAAABGAAAAVXNlZCB0byBvcmdhbml6ZSBw" +
           "YXJhbWV0ZXJzIGZvciBpZGVudGlmaWNhdGlvbiBvZiB0aGlzIFRvcG9sb2d5RWxlbWVudAAvAQLtA5wf" +
           "AAADAAAAACMAAQGIFwAjAAEBixcAIwABAYUXAAAAADVgiQoCAAAAAgAMAAAAU2VyaWFsTnVtYmVyAQFx" +
           "FwMAAAAATQAAAElkZW50aWZpZXIgdGhhdCB1bmlxdWVseSBpZGVudGlmaWVzLCB3aXRoaW4gYSBtYW51" +
           "ZmFjdHVyZXIsIGEgZGV2aWNlIGluc3RhbmNlAC4ARHEXAAAADP////8BAf////8AAAAANWCJCgIAAAAC" +
           "AA8AAABSZXZpc2lvbkNvdW50ZXIBAZ0fAwAAAABpAAAAQW4gaW5jcmVtZW50YWwgY291bnRlciBpbmRp" +
           "Y2F0aW5nIHRoZSBudW1iZXIgb2YgdGltZXMgdGhlIHN0YXRpYyBkYXRhIHdpdGhpbiB0aGUgRGV2aWNl" +
           "IGhhcyBiZWVuIG1vZGlmaWVkAC4ARJ0fAAAABv////8BAf////8AAAAANWCJCgIAAAACAAwAAABNYW51" +
           "ZmFjdHVyZXIBAXIXAwAAAAAYAAAATW9kZWwgbmFtZSBvZiB0aGUgZGV2aWNlAC4ARHIXAAAAFf////8B" +
           "Af////8AAAAANWCJCgIAAAACAAUAAABNb2RlbAEBcxcDAAAAADAAAABOYW1lIG9mIHRoZSBjb21wYW55" +
           "IHRoYXQgbWFudWZhY3R1cmVkIHRoZSBkZXZpY2UALgBEcxcAAAAV/////wEB/////wAAAAA1YIkKAgAA" +
           "AAIADAAAAERldmljZU1hbnVhbAEBdBcDAAAAAFoAAABBZGRyZXNzIChwYXRobmFtZSBpbiB0aGUgZmls" +
           "ZSBzeXN0ZW0gb3IgYSBVUkwgfCBXZWIgYWRkcmVzcykgb2YgdXNlciBtYW51YWwgZm9yIHRoZSBkZXZp" +
           "Y2UALgBEdBcAAAAM/////wEB/////wAAAAA1YIkKAgAAAAIADgAAAERldmljZVJldmlzaW9uAQF1FwMA" +
           "AAAAJAAAAE92ZXJhbGwgcmV2aXNpb24gbGV2ZWwgb2YgdGhlIGRldmljZQAuAER1FwAAAAz/////AQH/" +
           "////AAAAADVgiQoCAAAAAgAQAAAAU29mdHdhcmVSZXZpc2lvbgEBdhcDAAAAADUAAABSZXZpc2lvbiBs" +
           "ZXZlbCBvZiB0aGUgc29mdHdhcmUvZmlybXdhcmUgb2YgdGhlIGRldmljZQAuAER2FwAAAAz/////AQH/" +
           "////AAAAADVgiQoCAAAAAgAQAAAASGFyZHdhcmVSZXZpc2lvbgEBdxcDAAAAACwAAABSZXZpc2lvbiBs" +
           "ZXZlbCBvZiB0aGUgaGFyZHdhcmUgb2YgdGhlIGRldmljZQAuAER3FwAAAAz/////AQH/////AAAAAARg" +
           "gAoBAAAAAQANAAAAQ29uZmlndXJhdGlvbgEBixMALwEC7QOLEwAA/////wAAAAAEYIAKAQAAAAEABgAA" +
           "AFN0YXR1cwEBjBMALwEC7QOMEwAAAwAAAAAjAAEBeBcAIwABAXsXACMAAQGAFwAAAAAEYIAKAQAAAAEA" +
           "DwAAAEZhY3RvcnlTZXR0aW5ncwEBjRMALwEC7QONEwAACAAAAAAjAAEBhRcAIwABAYgXACMAAQGLFwAj" +
           "AAEBjhcAIwABAZEXACMAAQGUFwAjAAEBlxcAIwABAZoXAAAAAARggAoBAAAAAQAUAAAAQW5hbHlzZXJT" +
           "dGF0ZU1hY2hpbmUBAY4TAC8BAeoDjhMAAAIAAAAALwABAa0fAC8AAQGsHxAAAAAVYIkKAgAAAAAADAAA" +
           "AEN1cnJlbnRTdGF0ZQEBoxcALwEAyAqjFwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQB" +
           "AaQXAC4ARKQXAAAAEf////8BAf////8AAAAAJGCACgEAAAABAAcAAABQb3dlcnVwAQGPEwMAAAAAUQAA" +
           "AFRoZSBBbmFseXNlckRldmljZSBpcyBpbiBpdHMgcG93ZXItdXAgc2VxdWVuY2UgYW5kIGNhbm5vdCBw" +
           "ZXJmb3JtIGFueSBvdGhlciB0YXNrLgAvAQAFCY8TAAABAAAAADMBAQGUEwAAAAAkYIAKAQAAAAEACQAA" +
           "AE9wZXJhdGluZwEBkBMDAAAAACwAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gdGhlIE9wZXJhdGlu" +
           "ZyBtb2RlLgAvAQADCZATAAAGAAAAADQBAQGUEwAzAQEBlRMAMwEBAZYTADQBAQGXEwA0AQEBmRMAMwEB" +
           "AZsTAAAAACRggAoBAAAAAQAFAAAATG9jYWwBAZETAwAAAAB6AAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlz" +
           "IGluIHRoZSBMb2NhbCBtb2RlLiBUaGlzIG1vZGUgaXMgbm9ybWFsbHkgdXNlZCB0byBwZXJmb3JtIGxv" +
           "Y2FsIHBoeXNpY2FsIG1haW50ZW5hbmNlIG9uIHRoZSBhbmFseXNlci4ALwEAAwmREwAABQAAAAA0AQEB" +
           "lRMAMwEBAZcTADMBAQGYEwA0AQEBmhMAMwEBAZwTAAAAACRggAoBAAAAAQALAAAATWFpbnRlbmFuY2UB" +
           "AZITAwAAAACFAAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRoZSBNYWludGVuYW5jZSBtb2RlLiBU" +
           "aGlzIG1vZGUgaXMgdXNlZCB0byBwZXJmb3JtIHJlbW90ZSBtYWludGVuYW5jZSBvbiB0aGUgYW5hbHlz" +
           "ZXIgbGlrZSBmaXJtd2FyZSB1cGdyYWRlLgAvAQADCZITAAAFAAAAADQBAQGWEwA0AQEBmBMAMwEBAZkT" +
           "ADMBAQGaEwAzAQEBnRMAAAAAJGCACgEAAAABAAgAAABTaHV0ZG93bgEBkxMDAAAAAFMAAABUaGUgQW5h" +
           "bHlzZXJEZXZpY2UgaXMgaW4gaXRzIHBvd2VyLWRvd24gc2VxdWVuY2UgYW5kIGNhbm5vdCBwZXJmb3Jt" +
           "IGFueSBvdGhlciB0YXNrLgAvAQADCZMTAAADAAAAADQBAQGbEwA0AQEBnBMANAEBAZ0TAAAAAARggAoB" +
           "AAAAAQAcAAAAUG93ZXJ1cFRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBlBMALwEABgmUEwAAAgAAAAAzAAEB" +
           "jxMANAABAZATAAAAAARggAoBAAAAAQAaAAAAT3BlcmF0aW5nVG9Mb2NhbFRyYW5zaXRpb24BAZUTAC8B" +
           "AAYJlRMAAAIAAAAAMwABAZATADQAAQGREwAAAAAEYIAKAQAAAAEAIAAAAE9wZXJhdGluZ1RvTWFpbnRl" +
           "bmFuY2VUcmFuc2l0aW9uAQGWEwAvAQAGCZYTAAADAAAAADMAAQGQEwA0AAEBkhMANQABAa0fAAAAAARg" +
           "gAoBAAAAAQAaAAAATG9jYWxUb09wZXJhdGluZ1RyYW5zaXRpb24BAZcTAC8BAAYJlxMAAAIAAAAAMwAB" +
           "AZETADQAAQGQEwAAAAAEYIAKAQAAAAEAHAAAAExvY2FsVG9NYWludGVuYW5jZVRyYW5zaXRpb24BAZgT" +
           "AC8BAAYJmBMAAAIAAAAAMwABAZETADQAAQGSEwAAAAAEYIAKAQAAAAEAIAAAAE1haW50ZW5hbmNlVG9P" +
           "cGVyYXRpbmdUcmFuc2l0aW9uAQGZEwAvAQAGCZkTAAADAAAAADMAAQGSEwA0AAEBkBMANQABAawfAAAA" +
           "AARggAoBAAAAAQAcAAAATWFpbnRlbmFuY2VUb0xvY2FsVHJhbnNpdGlvbgEBmhMALwEABgmaEwAAAgAA" +
           "AAAzAAEBkhMANAABAZETAAAAAARggAoBAAAAAQAdAAAAT3BlcmF0aW5nVG9TaHV0ZG93blRyYW5zaXRp" +
           "b24BAZsTAC8BAAYJmxMAAAIAAAAAMwABAZATADQAAQGTEwAAAAAEYIAKAQAAAAEAGQAAAExvY2FsVG9T" +
           "aHV0ZG93blRyYW5zaXRpb24BAZwTAC8BAAYJnBMAAAIAAAAAMwABAZETADQAAQGTEwAAAAAEYIAKAQAA" +
           "AAEAHwAAAE1haW50ZW5hbmNlVG9TaHV0ZG93blRyYW5zaXRpb24BAZ0TAC8BAAYJnRMAAAIAAAAAMwAB" +
           "AZITADQAAQGTEwAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Configuration Object.
        /// </summary>
        public FunctionalGroupState Configuration
        {
            get
            { 
                return m_configuration;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_configuration, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_configuration = value;
            }
        }

        /// <summary>
        /// A description for the Status Object.
        /// </summary>
        public FunctionalGroupState Status
        {
            get
            { 
                return m_status;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_status, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_status = value;
            }
        }

        /// <summary>
        /// A description for the FactorySettings Object.
        /// </summary>
        public FunctionalGroupState FactorySettings
        {
            get
            { 
                return m_factorySettings;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_factorySettings, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_factorySettings = value;
            }
        }

        /// <summary>
        /// A description for the AnalyserStateMachine Object.
        /// </summary>
        public AnalyserDeviceStateMachineState AnalyserStateMachine
        {
            get
            { 
                return m_analyserStateMachine;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyserStateMachine, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyserStateMachine = value;
            }
        }

        /// <summary>
        /// A description for the <ChannelIdentifier> Object.
        /// </summary>
        public AnalyserChannelState ChannelIdentifier
        {
            get
            { 
                return m_channelIdentifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_channelIdentifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_channelIdentifier = value;
            }
        }

        /// <summary>
        /// A description for the <AccessorySlotIdentifier> Object.
        /// </summary>
        public AccessorySlotState AccessorySlotIdentifier
        {
            get
            { 
                return m_accessorySlotIdentifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_accessorySlotIdentifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_accessorySlotIdentifier = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_configuration != null)
            {
                children.Add(m_configuration);
            }

            if (m_status != null)
            {
                children.Add(m_status);
            }

            if (m_factorySettings != null)
            {
                children.Add(m_factorySettings);
            }

            if (m_analyserStateMachine != null)
            {
                children.Add(m_analyserStateMachine);
            }

            if (m_channelIdentifier != null)
            {
                children.Add(m_channelIdentifier);
            }

            if (m_accessorySlotIdentifier != null)
            {
                children.Add(m_accessorySlotIdentifier);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Configuration:
                {
                    if (createOrReplace)
                    {
                        if (Configuration == null)
                        {
                            if (replacement == null)
                            {
                                Configuration = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Configuration = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Configuration;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Status:
                {
                    if (createOrReplace)
                    {
                        if (Status == null)
                        {
                            if (replacement == null)
                            {
                                Status = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Status = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Status;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.FactorySettings:
                {
                    if (createOrReplace)
                    {
                        if (FactorySettings == null)
                        {
                            if (replacement == null)
                            {
                                FactorySettings = new FunctionalGroupState(this);
                            }
                            else
                            {
                                FactorySettings = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = FactorySettings;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyserStateMachine:
                {
                    if (createOrReplace)
                    {
                        if (AnalyserStateMachine == null)
                        {
                            if (replacement == null)
                            {
                                AnalyserStateMachine = new AnalyserDeviceStateMachineState(this);
                            }
                            else
                            {
                                AnalyserStateMachine = (AnalyserDeviceStateMachineState)replacement;
                            }
                        }
                    }

                    instance = AnalyserStateMachine;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FunctionalGroupState m_configuration;
        private FunctionalGroupState m_status;
        private FunctionalGroupState m_factorySettings;
        private AnalyserDeviceStateMachineState m_analyserStateMachine;
        private AnalyserChannelState m_channelIdentifier;
        private AccessorySlotState m_accessorySlotIdentifier;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserDeviceTypeGetConfigurationMethodMethodState Class
    #if (!OPCUA_EXCLUDE_AnalyserDeviceTypeGetConfigurationMethodMethodState)
    /// <summary>
    /// Stores an instance of the AnalyserDeviceTypeGetConfigurationMethod Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserDeviceTypeGetConfigurationMethodMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserDeviceTypeGetConfigurationMethodMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new AnalyserDeviceTypeGetConfigurationMethodMethodState(parent);
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRhggoEAAAAAQAoAAAAQW5hbHlzZXJEZXZpY2VUeXBlR2V0Q29uZmln" +
           "dXJhdGlvbk1ldGhvZAEBSx8ALwEBSx9LHwAAAQH/////AQAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJn" +
           "dW1lbnRzAQHCFwAuAETCFwAAlgEAAAABACoBARkAAAAKAAAAQ29uZmlnRGF0YQAP/////wAAAAAAAQAo" +
           "AQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion
        
        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public AnalyserDeviceTypeGetConfigurationMethodMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;
            
            byte[] configData = (byte[])outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    ref configData);
            }
            
            outputArguments[0] = configData;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult AnalyserDeviceTypeGetConfigurationMethodMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        ref byte[] configData);
    #endif
    #endregion

    #region AnalyserDeviceTypeSetConfigurationMethodMethodState Class
    #if (!OPCUA_EXCLUDE_AnalyserDeviceTypeSetConfigurationMethodMethodState)
    /// <summary>
    /// Stores an instance of the AnalyserDeviceTypeSetConfigurationMethod Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserDeviceTypeSetConfigurationMethodMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserDeviceTypeSetConfigurationMethodMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new AnalyserDeviceTypeSetConfigurationMethodMethodState(parent);
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRhggoEAAAAAQAoAAAAQW5hbHlzZXJEZXZpY2VUeXBlU2V0Q29uZmln" +
           "dXJhdGlvbk1ldGhvZAEBTB8ALwEBTB9MHwAAAQH/////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1" +
           "bWVudHMBAcMXAC4ARMMXAACWAQAAAAEAKgEBGQAAAAoAAABDb25maWdEYXRhAA//////AAAAAAABACgB" +
           "AQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBxBcALgBExBcAAJYBAAAA" +
           "AQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP////8AAAAAAAEAKAEBAAAAAQH/////AAAAAA==";
        #endregion
        #endif
        #endregion
        
        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public AnalyserDeviceTypeSetConfigurationMethodMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;
            
            byte[] configData = (byte[])inputArguments[0];
            
            string configDataDigest = (string)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    configData,
                    ref configDataDigest);
            }
            
            outputArguments[0] = configDataDigest;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult AnalyserDeviceTypeSetConfigurationMethodMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        byte[] configData,
        ref string configDataDigest);
    #endif
    #endregion

    #region AnalyserDeviceTypeGetConfigDataDigestMethodMethodState Class
    #if (!OPCUA_EXCLUDE_AnalyserDeviceTypeGetConfigDataDigestMethodMethodState)
    /// <summary>
    /// Stores an instance of the AnalyserDeviceTypeGetConfigDataDigestMethod Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserDeviceTypeGetConfigDataDigestMethodMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserDeviceTypeGetConfigDataDigestMethodMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new AnalyserDeviceTypeGetConfigDataDigestMethodMethodState(parent);
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRhggoEAAAAAQArAAAAQW5hbHlzZXJEZXZpY2VUeXBlR2V0Q29uZmln" +
           "RGF0YURpZ2VzdE1ldGhvZAEBTR8ALwEBTR9NHwAAAQH/////AQAAABVgqQoCAAAAAAAPAAAAT3V0cHV0" +
           "QXJndW1lbnRzAQHFFwAuAETFFwAAlgEAAAABACoBAR8AAAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM////" +
           "/wAAAAAAAQAoAQEAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion
        
        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public AnalyserDeviceTypeGetConfigDataDigestMethodMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;
            
            string configDataDigest = (string)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    ref configDataDigest);
            }
            
            outputArguments[0] = configDataDigest;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult AnalyserDeviceTypeGetConfigDataDigestMethodMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        ref string configDataDigest);
    #endif
    #endregion

    #region AnalyserDeviceTypeCompareConfigDataDigestMethodMethodState Class
    #if (!OPCUA_EXCLUDE_AnalyserDeviceTypeCompareConfigDataDigestMethodMethodState)
    /// <summary>
    /// Stores an instance of the AnalyserDeviceTypeCompareConfigDataDigestMethod Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserDeviceTypeCompareConfigDataDigestMethodMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserDeviceTypeCompareConfigDataDigestMethodMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new AnalyserDeviceTypeCompareConfigDataDigestMethodMethodState(parent);
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRhggoEAAAAAQAvAAAAQW5hbHlzZXJEZXZpY2VUeXBlQ29tcGFyZUNv" +
           "bmZpZ0RhdGFEaWdlc3RNZXRob2QBAU4fAC8BAU4fTh8AAAEB/////wIAAAAVYKkKAgAAAAAADgAAAElu" +
           "cHV0QXJndW1lbnRzAQHGFwAuAETGFwAAlgEAAAABACoBAR8AAAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM" +
           "/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAccX" +
           "AC4ARMcXAACWAQAAAAEAKgEBFgAAAAcAAABJc0VxdWFsAAH/////AAAAAAABACgBAQAAAAEB/////wAA" +
           "AAA=";
        #endregion
        #endif
        #endregion
        
        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public AnalyserDeviceTypeCompareConfigDataDigestMethodMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;
            
            string configDataDigest = (string)inputArguments[0];
            
            bool isEqual = (bool)outputArguments[0];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    configDataDigest,
                    ref isEqual);
            }
            
            outputArguments[0] = isEqual;

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult AnalyserDeviceTypeCompareConfigDataDigestMethodMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        string configDataDigest,
        ref bool isEqual);
    #endif
    #endregion

    #region AnalyserDeviceStateMachineState Class
    #if (!OPCUA_EXCLUDE_AnalyserDeviceStateMachineState)
    /// <summary>
    /// Stores an instance of the AnalyserDeviceStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserDeviceStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserDeviceStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserDeviceStateMachineType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAmAAAAQW5hbHlzZXJEZXZpY2VTdGF0ZU1hY2hpbmVU" +
           "eXBlSW5zdGFuY2UBAeoDAQHqAwECAAAAAC8AAQGtHwAvAAEBrB8QAAAAFWCJCgIAAAAAAAwAAABDdXJy" +
           "ZW50U3RhdGUBAcgXAC8BAMgKyBcAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQHJFwAu" +
           "AETJFwAAABH/////AQH/////AAAAACRggAoBAAAAAQAHAAAAUG93ZXJ1cAEBnhMDAAAAAFEAAABUaGUg" +
           "QW5hbHlzZXJEZXZpY2UgaXMgaW4gaXRzIHBvd2VyLXVwIHNlcXVlbmNlIGFuZCBjYW5ub3QgcGVyZm9y" +
           "bSBhbnkgb3RoZXIgdGFzay4ALwEABQmeEwAAAQAAAAAzAQEBoxMBAAAAFWCpCgIAAAAAAAsAAABTdGF0" +
           "ZU51bWJlcgEB0hcALgBE0hcAAAcAAAAAAAf/////AQH/////AAAAACRggAoBAAAAAQAJAAAAT3BlcmF0" +
           "aW5nAQGfEwMAAAAALAAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0aGUgT3BlcmF0aW5nIG1vZGUu" +
           "AC8BAAMJnxMAAAYAAAAANAEBAaMTADMBAQGkEwAzAQEBpRMANAEBAaYTADQBAQGoEwAzAQEBqhMBAAAA" +
           "FWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEB0xcALgBE0xcAAAcAAAAAAAf/////AQH/////AAAAACRg" +
           "gAoBAAAAAQAFAAAATG9jYWwBAaATAwAAAAB6AAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRoZSBM" +
           "b2NhbCBtb2RlLiBUaGlzIG1vZGUgaXMgbm9ybWFsbHkgdXNlZCB0byBwZXJmb3JtIGxvY2FsIHBoeXNp" +
           "Y2FsIG1haW50ZW5hbmNlIG9uIHRoZSBhbmFseXNlci4ALwEAAwmgEwAABQAAAAA0AQEBpBMAMwEBAaYT" +
           "ADMBAQGnEwA0AQEBqRMAMwEBAasTAQAAABVgqQoCAAAAAAALAAAAU3RhdGVOdW1iZXIBAdQXAC4ARNQX" +
           "AAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEACwAAAE1haW50ZW5hbmNlAQGhEwMAAAAAhQAA" +
           "AFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0aGUgTWFpbnRlbmFuY2UgbW9kZS4gVGhpcyBtb2RlIGlz" +
           "IHVzZWQgdG8gcGVyZm9ybSByZW1vdGUgbWFpbnRlbmFuY2Ugb24gdGhlIGFuYWx5c2VyIGxpa2UgZmly" +
           "bXdhcmUgdXBncmFkZS4ALwEAAwmhEwAABQAAAAA0AQEBpRMANAEBAacTADMBAQGoEwAzAQEBqRMAMwEB" +
           "AawTAQAAABVgqQoCAAAAAAALAAAAU3RhdGVOdW1iZXIBAdUXAC4ARNUXAAAHAAAAAAAH/////wEB////" +
           "/wAAAAAkYIAKAQAAAAEACAAAAFNodXRkb3duAQGiEwMAAAAAUwAAAFRoZSBBbmFseXNlckRldmljZSBp" +
           "cyBpbiBpdHMgcG93ZXItZG93biBzZXF1ZW5jZSBhbmQgY2Fubm90IHBlcmZvcm0gYW55IG90aGVyIHRh" +
           "c2suAC8BAAMJohMAAAMAAAAANAEBAaoTADQBAQGrEwA0AQEBrBMBAAAAFWCpCgIAAAAAAAsAAABTdGF0" +
           "ZU51bWJlcgEB1hcALgBE1hcAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAcAAAAUG93ZXJ1" +
           "cFRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBoxMALwEABgmjEwAAAgAAAAAzAAEBnhMANAABAZ8TAQAAABVg" +
           "qQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEB1xcALgBE1xcAAAcAAAAAAAf/////AQH/////AAAA" +
           "AARggAoBAAAAAQAaAAAAT3BlcmF0aW5nVG9Mb2NhbFRyYW5zaXRpb24BAaQTAC8BAAYJpBMAAAIAAAAA" +
           "MwABAZ8TADQAAQGgEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAdgXAC4ARNgXAAAH" +
           "AAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAIAAAAE9wZXJhdGluZ1RvTWFpbnRlbmFuY2VUcmFu" +
           "c2l0aW9uAQGlEwAvAQAGCaUTAAADAAAAADMAAQGfEwA0AAEBoRMANQABAa0fAQAAABVgqQoCAAAAAAAQ" +
           "AAAAVHJhbnNpdGlvbk51bWJlcgEB2RcALgBE2RcAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAA" +
           "AQAaAAAATG9jYWxUb09wZXJhdGluZ1RyYW5zaXRpb24BAaYTAC8BAAYJphMAAAIAAAAAMwABAaATADQA" +
           "AQGfEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAdoXAC4ARNoXAAAHAAAAAAAH////" +
           "/wEB/////wAAAAAEYIAKAQAAAAEAHAAAAExvY2FsVG9NYWludGVuYW5jZVRyYW5zaXRpb24BAacTAC8B" +
           "AAYJpxMAAAIAAAAAMwABAaATADQAAQGhEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIB" +
           "AdsXAC4ARNsXAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAIAAAAE1haW50ZW5hbmNlVG9P" +
           "cGVyYXRpbmdUcmFuc2l0aW9uAQGoEwAvAQAGCagTAAADAAAAADMAAQGhEwA0AAEBnxMANQABAawfAQAA" +
           "ABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEB3BcALgBE3BcAAAcAAAAAAAf/////AQH/////" +
           "AAAAAARggAoBAAAAAQAcAAAATWFpbnRlbmFuY2VUb0xvY2FsVHJhbnNpdGlvbgEBqRMALwEABgmpEwAA" +
           "AgAAAAAzAAEBoRMANAABAaATAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEB3RcALgBE" +
           "3RcAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAdAAAAT3BlcmF0aW5nVG9TaHV0ZG93blRy" +
           "YW5zaXRpb24BAaoTAC8BAAYJqhMAAAIAAAAAMwABAZ8TADQAAQGiEwEAAAAVYKkKAgAAAAAAEAAAAFRy" +
           "YW5zaXRpb25OdW1iZXIBAd4XAC4ARN4XAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAGQAA" +
           "AExvY2FsVG9TaHV0ZG93blRyYW5zaXRpb24BAasTAC8BAAYJqxMAAAIAAAAAMwABAaATADQAAQGiEwEA" +
           "AAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAd8XAC4ARN8XAAAHAAAAAAAH/////wEB////" +
           "/wAAAAAEYIAKAQAAAAEAHwAAAE1haW50ZW5hbmNlVG9TaHV0ZG93blRyYW5zaXRpb24BAawTAC8BAAYJ" +
           "rBMAAAIAAAAAMwABAaETADQAAQGiEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAeAX" +
           "AC4AROAXAAAHAAAAAAAH/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// The AnalyserDevice is in its power-up sequence and cannot perform any other task.
        /// </summary>
        public StateMachineInitialStateState Powerup
        {
            get
            { 
                return m_powerup;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_powerup, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_powerup = value;
            }
        }

        /// <summary>
        /// The AnalyserDevice is in the Operating mode.
        /// </summary>
        public StateMachineStateState Operating
        {
            get
            { 
                return m_operating;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operating, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operating = value;
            }
        }

        /// <summary>
        /// The AnalyserDevice is in the Local mode. This mode is normally used to perform local physical maintenance on the analyser.
        /// </summary>
        public StateMachineStateState Local
        {
            get
            { 
                return m_local;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_local, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_local = value;
            }
        }

        /// <summary>
        /// The AnalyserDevice is in the Maintenance mode. This mode is used to perform remote maintenance on the analyser like firmware upgrade.
        /// </summary>
        public StateMachineStateState Maintenance
        {
            get
            { 
                return m_maintenance;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenance, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenance = value;
            }
        }

        /// <summary>
        /// The AnalyserDevice is in its power-down sequence and cannot perform any other task.
        /// </summary>
        public StateMachineStateState Shutdown
        {
            get
            { 
                return m_shutdown;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_shutdown, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_shutdown = value;
            }
        }

        /// <summary>
        /// A description for the PowerupToOperatingTransition Object.
        /// </summary>
        public StateMachineTransitionState PowerupToOperatingTransition
        {
            get
            { 
                return m_powerupToOperatingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_powerupToOperatingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_powerupToOperatingTransition = value;
            }
        }

        /// <summary>
        /// A description for the OperatingToLocalTransition Object.
        /// </summary>
        public StateMachineTransitionState OperatingToLocalTransition
        {
            get
            { 
                return m_operatingToLocalTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingToLocalTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingToLocalTransition = value;
            }
        }

        /// <summary>
        /// A description for the OperatingToMaintenanceTransition Object.
        /// </summary>
        public StateMachineTransitionState OperatingToMaintenanceTransition
        {
            get
            { 
                return m_operatingToMaintenanceTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingToMaintenanceTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingToMaintenanceTransition = value;
            }
        }

        /// <summary>
        /// A description for the LocalToOperatingTransition Object.
        /// </summary>
        public StateMachineTransitionState LocalToOperatingTransition
        {
            get
            { 
                return m_localToOperatingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localToOperatingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localToOperatingTransition = value;
            }
        }

        /// <summary>
        /// A description for the LocalToMaintenanceTransition Object.
        /// </summary>
        public StateMachineTransitionState LocalToMaintenanceTransition
        {
            get
            { 
                return m_localToMaintenanceTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localToMaintenanceTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localToMaintenanceTransition = value;
            }
        }

        /// <summary>
        /// A description for the MaintenanceToOperatingTransition Object.
        /// </summary>
        public StateMachineTransitionState MaintenanceToOperatingTransition
        {
            get
            { 
                return m_maintenanceToOperatingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenanceToOperatingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenanceToOperatingTransition = value;
            }
        }

        /// <summary>
        /// A description for the MaintenanceToLocalTransition Object.
        /// </summary>
        public StateMachineTransitionState MaintenanceToLocalTransition
        {
            get
            { 
                return m_maintenanceToLocalTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenanceToLocalTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenanceToLocalTransition = value;
            }
        }

        /// <summary>
        /// A description for the OperatingToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState OperatingToShutdownTransition
        {
            get
            { 
                return m_operatingToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingToShutdownTransition = value;
            }
        }

        /// <summary>
        /// A description for the LocalToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState LocalToShutdownTransition
        {
            get
            { 
                return m_localToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localToShutdownTransition = value;
            }
        }

        /// <summary>
        /// A description for the MaintenanceToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState MaintenanceToShutdownTransition
        {
            get
            { 
                return m_maintenanceToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenanceToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenanceToShutdownTransition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_powerup != null)
            {
                children.Add(m_powerup);
            }

            if (m_operating != null)
            {
                children.Add(m_operating);
            }

            if (m_local != null)
            {
                children.Add(m_local);
            }

            if (m_maintenance != null)
            {
                children.Add(m_maintenance);
            }

            if (m_shutdown != null)
            {
                children.Add(m_shutdown);
            }

            if (m_powerupToOperatingTransition != null)
            {
                children.Add(m_powerupToOperatingTransition);
            }

            if (m_operatingToLocalTransition != null)
            {
                children.Add(m_operatingToLocalTransition);
            }

            if (m_operatingToMaintenanceTransition != null)
            {
                children.Add(m_operatingToMaintenanceTransition);
            }

            if (m_localToOperatingTransition != null)
            {
                children.Add(m_localToOperatingTransition);
            }

            if (m_localToMaintenanceTransition != null)
            {
                children.Add(m_localToMaintenanceTransition);
            }

            if (m_maintenanceToOperatingTransition != null)
            {
                children.Add(m_maintenanceToOperatingTransition);
            }

            if (m_maintenanceToLocalTransition != null)
            {
                children.Add(m_maintenanceToLocalTransition);
            }

            if (m_operatingToShutdownTransition != null)
            {
                children.Add(m_operatingToShutdownTransition);
            }

            if (m_localToShutdownTransition != null)
            {
                children.Add(m_localToShutdownTransition);
            }

            if (m_maintenanceToShutdownTransition != null)
            {
                children.Add(m_maintenanceToShutdownTransition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Powerup:
                {
                    if (createOrReplace)
                    {
                        if (Powerup == null)
                        {
                            if (replacement == null)
                            {
                                Powerup = new StateMachineInitialStateState(this);
                            }
                            else
                            {
                                Powerup = (StateMachineInitialStateState)replacement;
                            }
                        }
                    }

                    instance = Powerup;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Operating:
                {
                    if (createOrReplace)
                    {
                        if (Operating == null)
                        {
                            if (replacement == null)
                            {
                                Operating = new StateMachineStateState(this);
                            }
                            else
                            {
                                Operating = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Operating;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Local:
                {
                    if (createOrReplace)
                    {
                        if (Local == null)
                        {
                            if (replacement == null)
                            {
                                Local = new StateMachineStateState(this);
                            }
                            else
                            {
                                Local = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Local;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Maintenance:
                {
                    if (createOrReplace)
                    {
                        if (Maintenance == null)
                        {
                            if (replacement == null)
                            {
                                Maintenance = new StateMachineStateState(this);
                            }
                            else
                            {
                                Maintenance = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Maintenance;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Shutdown:
                {
                    if (createOrReplace)
                    {
                        if (Shutdown == null)
                        {
                            if (replacement == null)
                            {
                                Shutdown = new StateMachineStateState(this);
                            }
                            else
                            {
                                Shutdown = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Shutdown;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PowerupToOperatingTransition:
                {
                    if (createOrReplace)
                    {
                        if (PowerupToOperatingTransition == null)
                        {
                            if (replacement == null)
                            {
                                PowerupToOperatingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PowerupToOperatingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PowerupToOperatingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.OperatingToLocalTransition:
                {
                    if (createOrReplace)
                    {
                        if (OperatingToLocalTransition == null)
                        {
                            if (replacement == null)
                            {
                                OperatingToLocalTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                OperatingToLocalTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = OperatingToLocalTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.OperatingToMaintenanceTransition:
                {
                    if (createOrReplace)
                    {
                        if (OperatingToMaintenanceTransition == null)
                        {
                            if (replacement == null)
                            {
                                OperatingToMaintenanceTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                OperatingToMaintenanceTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = OperatingToMaintenanceTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.LocalToOperatingTransition:
                {
                    if (createOrReplace)
                    {
                        if (LocalToOperatingTransition == null)
                        {
                            if (replacement == null)
                            {
                                LocalToOperatingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                LocalToOperatingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = LocalToOperatingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.LocalToMaintenanceTransition:
                {
                    if (createOrReplace)
                    {
                        if (LocalToMaintenanceTransition == null)
                        {
                            if (replacement == null)
                            {
                                LocalToMaintenanceTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                LocalToMaintenanceTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = LocalToMaintenanceTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.MaintenanceToOperatingTransition:
                {
                    if (createOrReplace)
                    {
                        if (MaintenanceToOperatingTransition == null)
                        {
                            if (replacement == null)
                            {
                                MaintenanceToOperatingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                MaintenanceToOperatingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = MaintenanceToOperatingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.MaintenanceToLocalTransition:
                {
                    if (createOrReplace)
                    {
                        if (MaintenanceToLocalTransition == null)
                        {
                            if (replacement == null)
                            {
                                MaintenanceToLocalTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                MaintenanceToLocalTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = MaintenanceToLocalTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.OperatingToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (OperatingToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                OperatingToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                OperatingToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = OperatingToShutdownTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.LocalToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (LocalToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                LocalToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                LocalToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = LocalToShutdownTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.MaintenanceToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (MaintenanceToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                MaintenanceToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                MaintenanceToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = MaintenanceToShutdownTransition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private StateMachineInitialStateState m_powerup;
        private StateMachineStateState m_operating;
        private StateMachineStateState m_local;
        private StateMachineStateState m_maintenance;
        private StateMachineStateState m_shutdown;
        private StateMachineTransitionState m_powerupToOperatingTransition;
        private StateMachineTransitionState m_operatingToLocalTransition;
        private StateMachineTransitionState m_operatingToMaintenanceTransition;
        private StateMachineTransitionState m_localToOperatingTransition;
        private StateMachineTransitionState m_localToMaintenanceTransition;
        private StateMachineTransitionState m_maintenanceToOperatingTransition;
        private StateMachineTransitionState m_maintenanceToLocalTransition;
        private StateMachineTransitionState m_operatingToShutdownTransition;
        private StateMachineTransitionState m_localToShutdownTransition;
        private StateMachineTransitionState m_maintenanceToShutdownTransition;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannelState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelState : TopologyElementState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannelType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAbAAAAQW5hbHlzZXJDaGFubmVsVHlwZUluc3RhbmNl" +
           "AQHrAwEB6wMB/////wUAAAAkYIAKAQAAAAIADAAAAFBhcmFtZXRlclNldAEBrRMDAAAAABcAAABGbGF0" +
           "IGxpc3Qgb2YgUGFyYW1ldGVycwAvADqtEwAA/////wQAAAA1YIkKAgAAAAEACQAAAENoYW5uZWxJZAEB" +
           "4RcDAAAAABoAAABDaGFubmVsIElkIGRlZmluZWQgYnkgdXNlcgAvAQA9CeEXAAAADP////8BAf////8A" +
           "AAAANWCJCgIAAAABAAkAAABJc0VuYWJsZWQBAbwfAwAAAAA1AAAAVHJ1ZSBpZiB0aGUgY2hhbm5lbCBp" +
           "cyBlbmFibGVkIGFuZCBhY2NlcHRpbmcgY29tbWFuZHMALwEAPQm8HwAAAAH/////AQEBAAAAACMBAQGv" +
           "EwAAAAA1YIkKAgAAAAEAEAAAAERpYWdub3N0aWNTdGF0dXMBAeQXAwAAAAAdAAAAQW5hbHlzZXJDaGFu" +
           "bmVsIGhlYWx0aCBzdGF0dXMALwEAPQnkFwAAAQG6C/////8BAQEAAAAAIwEBAbATAAAAADVgiQoCAAAA" +
           "AQAMAAAAQWN0aXZlU3RyZWFtAQHnFwMAAAAAJgAAAEFjdGl2ZSBzdHJlYW0gZm9yIHRoaXMgQW5hbHlz" +
           "ZXJDaGFubmVsAC8BAD0J5xcAAAAM/////wEBAQAAAAAjAQEBsBMAAAAAJGCACgEAAAACAAkAAABNZXRo" +
           "b2RTZXQBAa4TAwAAAAAUAAAARmxhdCBsaXN0IG9mIE1ldGhvZHMALwA6rhMAAP////8MAAAABGGCCgQA" +
           "AAABABYAAABTdGFydFNpbmdsZUFjcXVpc2l0aW9uAQGvHwAvAQGvH68fAAABAf////8BAAAAFWCpCgIA" +
           "AAAAAA4AAABJbnB1dEFyZ3VtZW50cwEBsB8ALgBEsB8AAJYDAAAAAQAqAQEfAAAADgAAAEV4ZWN1dGlv" +
           "bkN5Y2xlAQGiJP////8AAAAAAAEAKgEBJAAAABUAAABFeGVjdXRpb25DeWNsZVN1YmNvZGUAB/////8A" +
           "AAAAAAEAKgEBHQAAAA4AAABTZWxlY3RlZFN0cmVhbQAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAA" +
           "JGGCCgQAAAABAA0AAABHb3RvT3BlcmF0aW5nAQGxHwMAAAAAMgAAAFRyYW5zaXRpb25zIHRoZSBBbmFs" +
           "eXNlckNoYW5uZWwgdG8gT3BlcmF0aW5nIG1vZGUuAC8BAbEfsR8AAAEB/////wAAAAAkYYIKBAAAAAEA" +
           "DwAAAEdvdG9NYWludGVuYW5jZQEBsh8DAAAAADQAAABUcmFuc2l0aW9ucyB0aGUgQW5hbHlzZXJDaGFu" +
           "bmVsIHRvIE1haW50ZW5hbmNlIG1vZGUuAC8BAbIfsh8AAAEB/////wAAAAAkYYIKBAAAAAEABQAAAFJl" +
           "c2V0AQGzHwMAAAAAKQAAAENhdXNlcyB0cmFuc2l0aW9uIHRvIHRoZSBSZXNldHRpbmcgc3RhdGUuAC8B" +
           "AbMfsx8AAAEB/////wAAAAAkYYIKBAAAAAEABQAAAFN0YXJ0AQG0HwMAAAAAKAAAAENhdXNlcyB0cmFu" +
           "c2l0aW9uIHRvIHRoZSBTdGFydGluZyBzdGF0ZS4ALwEBtB+0HwAAAQH/////AAAAACRhggoEAAAAAQAE" +
           "AAAAU3RvcAEBtR8DAAAAACgAAABDYXVzZXMgdHJhbnNpdGlvbiB0byB0aGUgU3RvcHBpbmcgc3RhdGUu" +
           "AC8BAbUftR8AAAEB/////wAAAAAkYYIKBAAAAAEABAAAAEhvbGQBAbYfAwAAAAAnAAAAQ2F1c2VzIHRy" +
           "YW5zaXRpb24gdG8gdGhlIEhvbGRpbmcgc3RhdGUuAC8BAbYfth8AAAEB/////wAAAAAkYYIKBAAAAAEA" +
           "BgAAAFVuaG9sZAEBtx8DAAAAACkAAABDYXVzZXMgdHJhbnNpdGlvbiB0byB0aGUgVW5ob2xkaW5nIHN0" +
           "YXRlLgAvAQG3H7cfAAABAf////8AAAAAJGGCCgQAAAABAAcAAABTdXNwZW5kAQG4HwMAAAAAKgAAAENh" +
           "dXNlcyB0cmFuc2l0aW9uIHRvIHRoZSBTdXNwZW5kaW5nIHN0YXRlLgAvAQG4H7gfAAABAf////8AAAAA" +
           "JGGCCgQAAAABAAkAAABVbnN1c3BlbmQBAbkfAwAAAAAsAAAAQ2F1c2VzIHRyYW5zaXRpb24gdG8gdGhl" +
           "IFVuc3VzcGVuZGluZyBzdGF0ZS4ALwEBuR+5HwAAAQH/////AAAAACRhggoEAAAAAQAFAAAAQWJvcnQB" +
           "AbofAwAAAAAoAAAAQ2F1c2VzIHRyYW5zaXRpb24gdG8gdGhlIEFib3J0aW5nIHN0YXRlLgAvAQG6H7of" +
           "AAABAf////8AAAAAJGGCCgQAAAABAAUAAABDbGVhcgEBux8DAAAAACgAAABDYXVzZXMgdHJhbnNpdGlv" +
           "biB0byB0aGUgQ2xlYXJpbmcgc3RhdGUuAC8BAbsfux8AAAEB/////wAAAAAEYIAKAQAAAAEADQAAAENv" +
           "bmZpZ3VyYXRpb24BAa8TAC8BAu0DrxMAAAEAAAAAIwABAbwfAAAAAARggAoBAAAAAQAGAAAAU3RhdHVz" +
           "AQGwEwAvAQLtA7ATAAACAAAAACMAAQHkFwAjAAEB5xcAAAAAhGCACgEAAAABABMAAABDaGFubmVsU3Rh" +
           "dGVNYWNoaW5lAQGxEwAvAQHvA7ETAAABAgAAAAAvAAEBsR8ALwABAbIfDwAAABVgiQoCAAAAAAAMAAAA" +
           "Q3VycmVudFN0YXRlAQHqFwAvAQDICuoXAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEB" +
           "6xcALgBE6xcAAAAR/////wEB/////wAAAAAkYIAKAQAAAAEACQAAAFNsYXZlTW9kZQEBshMDAAAAAFwA" +
           "AABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gTG9jYWwgb3IgTWFpbnRlbmFuY2UgbW9kZSBhbmQgYWxs" +
           "IEFuYWx5c2VyQ2hhbm5lbHMgYXJlIGluIFNsYXZlTW9kZQAvAQAFCbITAAAEAAAAADMBAQG3EwA0AQEB" +
           "vhMANAEBAb8TADQBAQHAEwAAAACkYIAKAQAAAAEACQAAAE9wZXJhdGluZwEBsxMDAAAAAC0AAABUaGUg" +
           "QW5hbHlzZXJDaGFubmVsIGlzIGluIHRoZSBPcGVyYXRpbmcgbW9kZS4ALwEB7AOzEwAAAQYAAAAANAEB" +
           "AbcTADMBAQG4EwAzAQEBuRMANAEBAboTADQBAQG8EwAzAQEBvhMBAAAABGCACgEAAAABABgAAABPcGVy" +
           "YXRpbmdTdWJTdGF0ZU1hY2hpbmUBAbQTAC8BAfADtBMAAAoAAAAALwABAbMfAC8AAQG0HwAvAAEBrx8A" +
           "LwABAbUfAC8AAQG2HwAvAAEBtx8ALwABAbgfAC8AAQG5HwAvAAEBuh8ALwABAbsfSAAAABVgiQoCAAAA" +
           "AAAMAAAAQ3VycmVudFN0YXRlAQG/HwAvAQDICr8fAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIA" +
           "AABJZAEBwB8ALgBEwB8AAAAR/////wEB/////wAAAAAkYIAKAQAAAAEABwAAAFN0b3BwZWQBAckfAwAA" +
           "AABIAAAAVGhpcyBpcyB0aGUgaW5pdGlhbCBzdGF0ZSBhZnRlciBBbmFseXNlckRldmljZVN0YXRlTWFj" +
           "aGluZSBzdGF0ZSBQb3dlcnVwAC8BAAUJyR8AAAUAAAAAMwEBAWogADQBAQF8IAA0AQEBmiAANAEBAaAg" +
           "ADMBAQG6IAAAAAAkYIAKAQAAAAEACQAAAFJlc2V0dGluZwEByx8DAAAAAFsAAABUaGlzIHN0YXRlIGlz" +
           "IHRoZSByZXN1bHQgb2YgYSBSZXNldCBvciBTZXRDb25maWd1cmF0aW9uIE1ldGhvZCBjYWxsIGZyb20g" +
           "dGhlIFN0b3BwZWQgc3RhdGUuAC8BAAMJyx8AAAYAAAAANAEBAWogADMBAQFsIAA0AQEBbCAAMwEBAW4g" +
           "ADMBAQGiIAAzAQEBvCAAAAAAJGCACgEAAAABAAQAAABJZGxlAQHNHwMAAAAAYwAAAFRoZSBSZXNldHRp" +
           "bmcgc3RhdGUgaXMgY29tcGxldGVkLCBhbGwgcGFyYW1ldGVycyBoYXZlIGJlZW4gY29tbWl0dGVkIGFu" +
           "ZCByZWFkeSB0byBzdGFydCBhY3F1aXNpdGlvbgAvAQADCc0fAAAEAAAAADQBAQFuIAAzAQEBcCAAMwEB" +
           "AaQgADMBAQG+IAAAAAAkYIAKAQAAAAEACAAAAFN0YXJ0aW5nAQHPHwMAAAAAeAAAAFRoZSBhbmFseXNl" +
           "ciBoYXMgcmVjZWl2ZWQgdGhlIFN0YXJ0IG9yIFNpbmdsZUFjcXVpc2l0aW9uU3RhcnQgTWV0aG9kIGNh" +
           "bGwgYW5kIGl0IGlzIHByZXBhcmluZyB0byBlbnRlciBpbiBFeGVjdXRlIHN0YXRlLgAvAQADCc8fAAAG" +
           "AAAAADQBAQFwIAAzAQEBciAANAEBAXIgADMBAQF0IAAzAQEBpiAAMwEBAcAgAAAAACRggAoBAAAAAQAH" +
           "AAAARXhlY3V0ZQEB0R8DAAAAADkAAABBbGwgcmVwZXRpdGl2ZSBhY3F1aXNpdGlvbiBjeWNsZXMgYXJl" +
           "IGRvbmUgaW4gdGhpcyBzdGF0ZToALwEBBCPRHwAACAAAAAA0AQEBdCAAMwEBAXYgADMBAQF+IAA0AQEB" +
           "iiAAMwEBAYwgADQBAQGYIAAzAQEBqCAAMwEBAcIgAQAAAARggAoBAAAAAQAfAAAAT3BlcmF0aW5nRXhl" +
           "Y3V0ZVN1YlN0YXRlTWFjaGluZQEB0x8ALwEB8QPTHwAA/////zsAAAAVYIkKAgAAAAAADAAAAEN1cnJl" +
           "bnRTdGF0ZQEB1B8ALwEAyArUHwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAdUfAC4A" +
           "RNUfAAAAEf////8BAf////8AAAAAJGCACgEAAAABABQAAABTZWxlY3RFeGVjdXRpb25DeWNsZQEB3h8D" +
           "AAAAAEgAAABUaGlzIHBzZXVkby1zdGF0ZSBpcyB1c2VkIHRvIGRlY2lkZSB3aGljaCBleGVjdXRpb24g" +
           "cGF0aCBzaGFsbCBiZSB0YWtlbi4ALwEABQneHwAABgAAAAAzAQEBBiAAMwEBARYgADMBAQEmIAAzAQEB" +
           "NiAAMwEBAT4gADQBAQFQIAAAAAAkYIAKAQAAAAEAGQAAAFdhaXRGb3JDYWxpYnJhdGlvblRyaWdnZXIB" +
           "AeAfAwAAAABVAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFkeSB0byBwZXJm" +
           "b3JtIHRoZSBDYWxpYnJhdGlvbiBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCeAfAAACAAAAADQBAQEGIAAz" +
           "AQEBCCAAAAAAJGCACgEAAAABABgAAABFeHRyYWN0Q2FsaWJyYXRpb25TYW1wbGUBAeIfAwAAAABbAAAA" +
           "Q29sbGVjdCAvIHNldHVwIHRoZSBzYW1wbGluZyBzeXN0ZW0gdG8gcGVyZm9ybSB0aGUgYWNxdWlzaXRp" +
           "b24gY3ljbGUgb2YgYSBDYWxpYnJhdGlvbiBjeWNsZQAvAQADCeIfAAAEAAAAADQBAQEIIAAzAQEBCiAA" +
           "NAEBAQogADMBAQEMIAAAAAAkYIAKAQAAAAEAGAAAAFByZXBhcmVDYWxpYnJhdGlvblNhbXBsZQEB5B8D" +
           "AAAAAEUAAABQcmVwYXJlIHRoZSBDYWxpYnJhdGlvbiBzYW1wbGUgZm9yIHRoZSBBbmFseXNlQ2FsaWJy" +
           "YXRpb25TYW1wbGUgc3RhdGUALwEAAwnkHwAABAAAAAA0AQEBDCAAMwEBAQ4gADQBAQEOIAAzAQEBECAA" +
           "AAAAJGCACgEAAAABABgAAABBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGUBAeYfAwAAAAAuAAAAUGVyZm9y" +
           "bSB0aGUgYW5hbHlzaXMgb2YgdGhlIENhbGlicmF0aW9uIFNhbXBsZQAvAQADCeYfAAAEAAAAADQBAQEQ" +
           "IAAzAQEBEiAANAEBARIgADMBAQEUIAAAAAAkYIAKAQAAAAEAGAAAAFdhaXRGb3JWYWxpZGF0aW9uVHJp" +
           "Z2dlcgEB6B8DAAAAAFQAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRv" +
           "IHBlcmZvcm0gdGhlIFZhbGlkYXRpb24gYWNxdWlzaXRpb24gY3ljbGUALwEAAwnoHwAAAgAAAAA0AQEB" +
           "FiAAMwEBARggAAAAACRggAoBAAAAAQAXAAAARXh0cmFjdFZhbGlkYXRpb25TYW1wbGUBAeofAwAAAABa" +
           "AAAAQ29sbGVjdCAvIHNldHVwIHRoZSBzYW1wbGluZyBzeXN0ZW0gdG8gcGVyZm9ybSB0aGUgYWNxdWlz" +
           "aXRpb24gY3ljbGUgb2YgYSBWYWxpZGF0aW9uIGN5Y2xlAC8BAAMJ6h8AAAQAAAAANAEBARggADMBAQEa" +
           "IAA0AQEBGiAAMwEBARwgAAAAACRggAoBAAAAAQAXAAAAUHJlcGFyZVZhbGlkYXRpb25TYW1wbGUBAewf" +
           "AwAAAABDAAAAUHJlcGFyZSB0aGUgVmFsaWRhdGlvbiBzYW1wbGUgZm9yIHRoZSBBbmFseXNlVmFsaWRh" +
           "dGlvblNhbXBsZSBzdGF0ZQAvAQADCewfAAAEAAAAADQBAQEcIAAzAQEBHiAANAEBAR4gADMBAQEgIAAA" +
           "AAAkYIAKAQAAAAEAFwAAAEFuYWx5c2VWYWxpZGF0aW9uU2FtcGxlAQHuHwMAAAAALQAAAFBlcmZvcm0g" +
           "dGhlIGFuYWx5c2lzIG9mIHRoZSBWYWxpZGF0aW9uIFNhbXBsZQAvAQADCe4fAAAEAAAAADQBAQEgIAAz" +
           "AQEBIiAANAEBASIgADMBAQEkIAAAAAAkYIAKAQAAAAEAFAAAAFdhaXRGb3JTYW1wbGVUcmlnZ2VyAQHw" +
           "HwMAAAAAUAAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9y" +
           "bSB0aGUgU2FtcGxlIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJ8B8AAAIAAAAANAEBASYgADMBAQEoIAAA" +
           "AAAkYIAKAQAAAAEADQAAAEV4dHJhY3RTYW1wbGUBAfIfAwAAAAAjAAAAQ29sbGVjdCB0aGUgU2FtcGxl" +
           "IGZyb20gdGhlIHByb2Nlc3MALwEAAwnyHwAABAAAAAA0AQEBKCAAMwEBASogADQBAQEqIAAzAQEBLCAA" +
           "AAAAJGCACgEAAAABAA0AAABQcmVwYXJlU2FtcGxlAQH0HwMAAAAALgAAAFByZXBhcmUgdGhlIFNhbXBs" +
           "ZSBmb3IgdGhlIEFuYWx5c2VTYW1wbGUgc3RhdGUALwEAAwn0HwAABAAAAAA0AQEBLCAAMwEBAS4gADQB" +
           "AQEuIAAzAQEBMCAAAAAAJGCACgEAAAABAA0AAABBbmFseXNlU2FtcGxlAQH2HwMAAAAAIgAAAFBlcmZv" +
           "cm0gdGhlIGFuYWx5c2lzIG9mIHRoZSBTYW1wbGUALwEAAwn2HwAABAAAAAA0AQEBMCAAMwEBATIgADQB" +
           "AQEyIAAzAQEBNCAAAAAAJGCACgEAAAABABgAAABXYWl0Rm9yRGlhZ25vc3RpY1RyaWdnZXIBAfgfAwAA" +
           "AABJAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFkeSB0byBwZXJmb3JtIHRo" +
           "ZSBkaWFnbm9zdGljIGN5Y2xlLAAvAQADCfgfAAACAAAAADQBAQE2IAAzAQEBOCAAAAAAJGCACgEAAAAB" +
           "AAoAAABEaWFnbm9zdGljAQH6HwMAAAAAHQAAAFBlcmZvcm0gdGhlIGRpYWdub3N0aWMgY3ljbGUuAC8B" +
           "AAMJ+h8AAAQAAAAANAEBATggADMBAQE6IAA0AQEBOiAAMwEBATwgAAAAACRggAoBAAAAAQAWAAAAV2Fp" +
           "dEZvckNsZWFuaW5nVHJpZ2dlcgEB/B8DAAAAAEcAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFu" +
           "bmVsIGlzIHJlYWR5IHRvIHBlcmZvcm0gdGhlIGNsZWFuaW5nIGN5Y2xlLAAvAQADCfwfAAACAAAAADQB" +
           "AQE+IAAzAQEBQCAAAAAAJGCACgEAAAABAAgAAABDbGVhbmluZwEB/h8DAAAAABsAAABQZXJmb3JtIHRo" +
           "ZSBjbGVhbmluZyBjeWNsZS4ALwEAAwn+HwAABAAAAAA0AQEBQCAAMwEBAUIgADQBAQFCIAAzAQEBRCAA" +
           "AAAAJGCACgEAAAABAA4AAABQdWJsaXNoUmVzdWx0cwEBACADAAAAADUAAABQdWJsaXNoIHRoZSByZXN1" +
           "bHRzIG9mIHRoZSBwcmV2aW91cyBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCQAgAAAHAAAAADQBAQEUIAA0" +
           "AQEBJCAANAEBATQgADQBAQE8IAA0AQEBRCAAMwEBAUYgADMBAQFIIAAAAAAkYIAKAQAAAAEADwAAAEVq" +
           "ZWN0R3JhYlNhbXBsZQEBAiADAAAAAG8AAABUaGUgU2FtcGxlIHRoYXQgd2FzIGp1c3QgYW5hbHlzZWQg" +
           "aXMgZWplY3RlZCBmcm9tIHRoZSBzeXN0ZW0gdG8gYWxsb3cgdGhlIG9wZXJhdG9yIG9yIGFub3RoZXIg" +
           "c3lzdGVtIHRvIGdyYWIgaXQALwEAAwkCIAAABAAAAAA0AQEBSCAAMwEBAUogADQBAQFKIAAzAQEBTCAA" +
           "AAAAJGCACgEAAAABABUAAABDbGVhbnVwU2FtcGxpbmdTeXN0ZW0BAQQgAwAAAABEAAAAQ2xlYW51cCB0" +
           "aGUgc2FtcGxpbmcgc3ViLXN5c3RlbSB0byBiZSByZWFkeSBmb3IgdGhlIG5leHQgYWNxdWlzaXRpb24A" +
           "LwEAAwkEIAAABQAAAAA0AQEBRiAANAEBAUwgADMBAQFOIAA0AQEBTiAAMwEBAVAgAAAAAARggAoBAAAA" +
           "AQA5AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JDYWxpYnJhdGlvblRyaWdnZXJUcmFuc2l0" +
           "aW9uAQEGIAAvAQAGCQYgAAACAAAAADMAAQHeHwA0AAEB4B8AAAAABGCACgEAAAABAD0AAABXYWl0Rm9y" +
           "Q2FsaWJyYXRpb25UcmlnZ2VyVG9FeHRyYWN0Q2FsaWJyYXRpb25TYW1wbGVUcmFuc2l0aW9uAQEIIAAv" +
           "AQAGCQggAAACAAAAADMAAQHgHwA0AAEB4h8AAAAABGCACgEAAAABACIAAABFeHRyYWN0Q2FsaWJyYXRp" +
           "b25TYW1wbGVUcmFuc2l0aW9uAQEKIAAvAQAGCQogAAACAAAAADMAAQHiHwA0AAEB4h8AAAAABGCACgEA" +
           "AAABADwAAABFeHRyYWN0Q2FsaWJyYXRpb25TYW1wbGVUb1ByZXBhcmVDYWxpYnJhdGlvblNhbXBsZVRy" +
           "YW5zaXRpb24BAQwgAC8BAAYJDCAAAAIAAAAAMwABAeIfADQAAQHkHwAAAAAEYIAKAQAAAAEAIgAAAFBy" +
           "ZXBhcmVDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BAQ4gAC8BAAYJDiAAAAIAAAAAMwABAeQfADQA" +
           "AQHkHwAAAAAEYIAKAQAAAAEAPAAAAFByZXBhcmVDYWxpYnJhdGlvblNhbXBsZVRvQW5hbHlzZUNhbGli" +
           "cmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBECAALwEABgkQIAAAAgAAAAAzAAEB5B8ANAABAeYfAAAAAARg" +
           "gAoBAAAAAQAiAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBEiAALwEABgkSIAAA" +
           "AgAAAAAzAAEB5h8ANAABAeYfAAAAAARggAoBAAAAAQAyAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxl" +
           "VG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BARQgAC8BAAYJFCAAAAIAAAAAMwABAeYfADQAAQEAIAAA" +
           "AAAEYIAKAQAAAAEAOAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yVmFsaWRhdGlvblRyaWdn" +
           "ZXJUcmFuc2l0aW9uAQEWIAAvAQAGCRYgAAACAAAAADMAAQHeHwA0AAEB6B8AAAAABGCACgEAAAABADsA" +
           "AABXYWl0Rm9yVmFsaWRhdGlvblRyaWdnZXJUb0V4dHJhY3RWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlv" +
           "bgEBGCAALwEABgkYIAAAAgAAAAAzAAEB6B8ANAABAeofAAAAAARggAoBAAAAAQAhAAAARXh0cmFjdFZh" +
           "bGlkYXRpb25TYW1wbGVUcmFuc2l0aW9uAQEaIAAvAQAGCRogAAACAAAAADMAAQHqHwA0AAEB6h8AAAAA" +
           "BGCACgEAAAABADoAAABFeHRyYWN0VmFsaWRhdGlvblNhbXBsZVRvUHJlcGFyZVZhbGlkYXRpb25TYW1w" +
           "bGVUcmFuc2l0aW9uAQEcIAAvAQAGCRwgAAACAAAAADMAAQHqHwA0AAEB7B8AAAAABGCACgEAAAABACEA" +
           "AABQcmVwYXJlVmFsaWRhdGlvblNhbXBsZVRyYW5zaXRpb24BAR4gAC8BAAYJHiAAAAIAAAAAMwABAewf" +
           "ADQAAQHsHwAAAAAEYIAKAQAAAAEAOgAAAFByZXBhcmVWYWxpZGF0aW9uU2FtcGxlVG9BbmFseXNlVmFs" +
           "aWRhdGlvblNhbXBsZVRyYW5zaXRpb24BASAgAC8BAAYJICAAAAIAAAAAMwABAewfADQAAQHuHwAAAAAE" +
           "YIAKAQAAAAEAIQAAAEFuYWx5c2VWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBIiAALwEABgkiIAAA" +
           "AgAAAAAzAAEB7h8ANAABAe4fAAAAAARggAoBAAAAAQAxAAAAQW5hbHlzZVZhbGlkYXRpb25TYW1wbGVU" +
           "b1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEBJCAALwEABgkkIAAAAgAAAAAzAAEB7h8ANAABAQAgAAAA" +
           "AARggAoBAAAAAQA0AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JTYW1wbGVUcmlnZ2VyVHJh" +
           "bnNpdGlvbgEBJiAALwEABgkmIAAAAgAAAAAzAAEB3h8ANAABAfAfAAAAAARggAoBAAAAAQAtAAAAV2Fp" +
           "dEZvclNhbXBsZVRyaWdnZXJUb0V4dHJhY3RTYW1wbGVUcmFuc2l0aW9uAQEoIAAvAQAGCSggAAACAAAA" +
           "ADMAAQHwHwA0AAEB8h8AAAAABGCACgEAAAABABcAAABFeHRyYWN0U2FtcGxlVHJhbnNpdGlvbgEBKiAA" +
           "LwEABgkqIAAAAgAAAAAzAAEB8h8ANAABAfIfAAAAAARggAoBAAAAAQAmAAAARXh0cmFjdFNhbXBsZVRv" +
           "UHJlcGFyZVNhbXBsZVRyYW5zaXRpb24BASwgAC8BAAYJLCAAAAIAAAAAMwABAfIfADQAAQH0HwAAAAAE" +
           "YIAKAQAAAAEAFwAAAFByZXBhcmVTYW1wbGVUcmFuc2l0aW9uAQEuIAAvAQAGCS4gAAACAAAAADMAAQH0" +
           "HwA0AAEB9B8AAAAABGCACgEAAAABACYAAABQcmVwYXJlU2FtcGxlVG9BbmFseXNlU2FtcGxlVHJhbnNp" +
           "dGlvbgEBMCAALwEABgkwIAAAAgAAAAAzAAEB9B8ANAABAfYfAAAAAARggAoBAAAAAQAXAAAAQW5hbHlz" +
           "ZVNhbXBsZVRyYW5zaXRpb24BATIgAC8BAAYJMiAAAAIAAAAAMwABAfYfADQAAQH2HwAAAAAEYIAKAQAA" +
           "AAEAJwAAAEFuYWx5c2VTYW1wbGVUb1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEBNCAALwEABgk0IAAA" +
           "AgAAAAAzAAEB9h8ANAABAQAgAAAAAARggAoBAAAAAQA4AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dh" +
           "aXRGb3JEaWFnbm9zdGljVHJpZ2dlclRyYW5zaXRpb24BATYgAC8BAAYJNiAAAAIAAAAAMwABAd4fADQA" +
           "AQH4HwAAAAAEYIAKAQAAAAEALgAAAFdhaXRGb3JEaWFnbm9zdGljVHJpZ2dlclRvRGlhZ25vc3RpY1Ry" +
           "YW5zaXRpb24BATggAC8BAAYJOCAAAAIAAAAAMwABAfgfADQAAQH6HwAAAAAEYIAKAQAAAAEAFAAAAERp" +
           "YWdub3N0aWNUcmFuc2l0aW9uAQE6IAAvAQAGCTogAAACAAAAADMAAQH6HwA0AAEB+h8AAAAABGCACgEA" +
           "AAABACQAAABEaWFnbm9zdGljVG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BATwgAC8BAAYJPCAAAAIA" +
           "AAAAMwABAfofADQAAQEAIAAAAAAEYIAKAQAAAAEANgAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0" +
           "Rm9yQ2xlYW5pbmdUcmlnZ2VyVHJhbnNpdGlvbgEBPiAALwEABgk+IAAAAgAAAAAzAAEB3h8ANAABAfwf" +
           "AAAAAARggAoBAAAAAQAqAAAAV2FpdEZvckNsZWFuaW5nVHJpZ2dlclRvQ2xlYW5pbmdUcmFuc2l0aW9u" +
           "AQFAIAAvAQAGCUAgAAACAAAAADMAAQH8HwA0AAEB/h8AAAAABGCACgEAAAABABIAAABDbGVhbmluZ1Ry" +
           "YW5zaXRpb24BAUIgAC8BAAYJQiAAAAIAAAAAMwABAf4fADQAAQH+HwAAAAAEYIAKAQAAAAEAIgAAAENs" +
           "ZWFuaW5nVG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BAUQgAC8BAAYJRCAAAAIAAAAAMwABAf4fADQA" +
           "AQEAIAAAAAAEYIAKAQAAAAEALwAAAFB1Ymxpc2hSZXN1bHRzVG9DbGVhbnVwU2FtcGxpbmdTeXN0ZW1U" +
           "cmFuc2l0aW9uAQFGIAAvAQAGCUYgAAACAAAAADMAAQEAIAA0AAEBBCAAAAAABGCACgEAAAABACkAAABQ" +
           "dWJsaXNoUmVzdWx0c1RvRWplY3RHcmFiU2FtcGxlVHJhbnNpdGlvbgEBSCAALwEABglIIAAAAgAAAAAz" +
           "AAEBACAANAABAQIgAAAAAARggAoBAAAAAQAZAAAARWplY3RHcmFiU2FtcGxlVHJhbnNpdGlvbgEBSiAA" +
           "LwEABglKIAAAAgAAAAAzAAEBAiAANAABAQIgAAAAAARggAoBAAAAAQAwAAAARWplY3RHcmFiU2FtcGxl" +
           "VG9DbGVhbnVwU2FtcGxpbmdTeXN0ZW1UcmFuc2l0aW9uAQFMIAAvAQAGCUwgAAACAAAAADMAAQECIAA0" +
           "AAEBBCAAAAAABGCACgEAAAABAB8AAABDbGVhbnVwU2FtcGxpbmdTeXN0ZW1UcmFuc2l0aW9uAQFOIAAv" +
           "AQAGCU4gAAACAAAAADMAAQEEIAA0AAEBBCAAAAAABGCACgEAAAABADUAAABDbGVhbnVwU2FtcGxpbmdT" +
           "eXN0ZW1Ub1NlbGVjdEV4ZWN1dGlvbkN5Y2xlVHJhbnNpdGlvbgEBUCAALwEABglQIAAAAgAAAAAzAAEB" +
           "BCAANAABAd4fAAAAACRggAoBAAAAAQAKAAAAQ29tcGxldGluZwEBUiADAAAAAEQAAABUaGlzIHN0YXRl" +
           "IGlzIGFuIGF1dG9tYXRpYyBvciBjb21tYW5kZWQgZXhpdCBmcm9tIHRoZSBFeGVjdXRlIHN0YXRlLgAv" +
           "AQADCVIgAAAGAAAAADQBAQF2IAAzAQEBeCAANAEBAXggADMBAQF6IAAzAQEBqiAAMwEBAcQgAAAAACRg" +
           "gAoBAAAAAQAIAAAAQ29tcGxldGUBAVQgAwAAAABmAAAAQXQgdGhpcyBwb2ludCwgdGhlIENvbXBsZXRp" +
           "bmcgc3RhdGUgaXMgZG9uZSBhbmQgaXQgdHJhbnNpdGlvbnMgYXV0b21hdGljYWxseSB0byBTdG9wcGVk" +
           "IHN0YXRlIHRvIHdhaXQuAC8BAAMJVCAAAAQAAAAANAEBAXogADMBAQF8IAAzAQEBrCAAMwEBAcYgAAAA" +
           "ACRggAoBAAAAAQAKAAAAU3VzcGVuZGluZwEBViADAAAAAGAAAABUaGlzIHN0YXRlIGlzIGEgcmVzdWx0" +
           "IG9mIGEgY2hhbmdlIGluIG1vbml0b3JlZCBjb25kaXRpb25zIGR1ZSB0byBwcm9jZXNzIGNvbmRpdGlv" +
           "bnMgb3IgZmFjdG9ycy4ALwEAAwlWIAAABwAAAAA0AQEBjCAAMwEBAY4gADQBAQGOIAAzAQEBkCAANAEB" +
           "AZYgADMBAQGuIAAzAQEByCAAAAAAJGCACgEAAAABAAkAAABTdXNwZW5kZWQBAVggAwAAAACnAAAAVGhl" +
           "IGFuYWx5c2VyIG9yIGNoYW5uZWwgbWF5IGJlIHJ1bm5pbmcgYnV0IG5vIHJlc3VsdHMgYXJlIGJlaW5n" +
           "IGdlbmVyYXRlZCB3aGlsZSB0aGUgYW5hbHlzZXIgb3IgY2hhbm5lbCBpcyB3YWl0aW5nIGZvciBleHRl" +
           "cm5hbCBwcm9jZXNzIGNvbmRpdGlvbnMgdG8gcmV0dXJuIHRvIG5vcm1hbC4ALwEAAwlYIAAABAAAAAA0" +
           "AQEBkCAAMwEBAZIgADMBAQGwIAAzAQEByiAAAAAAJGCACgEAAAABAAwAAABVbnN1c3BlbmRpbmcBAVog" +
           "AwAAAACIAAAAVGhpcyBzdGF0ZSBpcyBhIHJlc3VsdCBvZiBhIGRldmljZSByZXF1ZXN0IGZyb20gU3Vz" +
           "cGVuZGVkIHN0YXRlIHRvIHRyYW5zaXRpb24gYmFjayB0byB0aGUgRXhlY3V0ZSBzdGF0ZSBieSBjYWxs" +
           "aW5nIHRoZSBVbnN1c3BlbmQgTWV0aG9kLgAvAQADCVogAAAHAAAAADQBAQGSIAAzAQEBlCAANAEBAZQg" +
           "ADMBAQGWIAAzAQEBmCAAMwEBAbIgADMBAQHMIAAAAAAkYIAKAQAAAAEABwAAAEhvbGRpbmcBAVwgAwAA" +
           "AAB8AAAAQnJpbmdzIHRoZSBhbmFseXNlciBvciBjaGFubmVsIHRvIGEgY29udHJvbGxlZCBzdG9wIG9y" +
           "IHRvIGEgc3RhdGUgd2hpY2ggcmVwcmVzZW50cyBIZWxkIGZvciB0aGUgcGFydGljdWxhciB1bml0IGNv" +
           "bnRyb2wgbW9kZQAvAQADCVwgAAAHAAAAADQBAQF+IAAzAQEBgCAANAEBAYAgADMBAQGCIAA0AQEBiCAA" +
           "MwEBAbQgADMBAQHOIAAAAAAkYIAKAQAAAAEABAAAAEhlbGQBAV4gAwAAAABrAAAAVGhlIEhlbGQgc3Rh" +
           "dGUgaG9sZHMgdGhlIGFuYWx5c2VyIG9yIGNoYW5uZWwncyBvcGVyYXRpb24uIEF0IHRoaXMgc3RhdGUs" +
           "IG5vIGFjcXVpc2l0aW9uIGN5Y2xlIGlzIHBlcmZvcm1lZC4ALwEAAwleIAAABAAAAAA0AQEBgiAAMwEB" +
           "AYQgADMBAQG2IAAzAQEB0CAAAAAAJGCACgEAAAABAAkAAABVbmhvbGRpbmcBAWAgAwAAAABVAAAAVGhl" +
           "IFVuaG9sZGluZyBzdGF0ZSBpcyBhIHJlc3BvbnNlIHRvIGFuIG9wZXJhdG9yIGNvbW1hbmQgdG8gcmVz" +
           "dW1lIHRoZSBFeGVjdXRlIHN0YXRlLgAvAQADCWAgAAAHAAAAADQBAQGEIAAzAQEBhiAANAEBAYYgADMB" +
           "AQGIIAAzAQEBiiAAMwEBAbggADMBAQHSIAAAAAAkYIAKAQAAAAEACAAAAFN0b3BwaW5nAQFiIAMAAAAA" +
           "LAAAAEluaXRpYXRlZCBieSBhIFN0b3AgTWV0aG9kIGNhbGwsIHRoaXMgc3RhdGU6AC8BAAMJYiAAAA4A" +
           "AAAAMwEBAZogADQBAQGiIAA0AQEBpCAANAEBAaYgADQBAQGoIAA0AQEBqiAANAEBAawgADQBAQGuIAA0" +
           "AQEBsCAANAEBAbIgADQBAQG0IAA0AQEBtiAANAEBAbggADMBAQHUIAAAAAAkYIAKAQAAAAEACAAAAEFi" +
           "b3J0aW5nAQFkIAMAAAAAdwAAAFRoZSBBYm9ydGluZyBzdGF0ZSBjYW4gYmUgZW50ZXJlZCBhdCBhbnkg" +
           "dGltZSBpbiByZXNwb25zZSB0byB0aGUgQWJvcnQgY29tbWFuZCBvciBvbiB0aGUgb2NjdXJyZW5jZSBv" +
           "ZiBhIG1hY2hpbmUgZmF1bHQuAC8BAAMJZCAAAA8AAAAAMwEBAZwgADQBAQG6IAA0AQEBvCAANAEBAb4g" +
           "ADQBAQHAIAA0AQEBwiAANAEBAcQgADQBAQHGIAA0AQEByCAANAEBAcogADQBAQHMIAA0AQEBziAANAEB" +
           "AdAgADQBAQHSIAA0AQEB1CAAAAAAJGCACgEAAAABAAcAAABBYm9ydGVkAQFmIAMAAAAAUAAAAFRoaXMg" +
           "c3RhdGUgbWFpbnRhaW5zIG1hY2hpbmUgc3RhdHVzIGluZm9ybWF0aW9uIHJlbGV2YW50IHRvIHRoZSBB" +
           "Ym9ydCBjb25kaXRpb24uAC8BAAMJZiAAAAIAAAAANAEBAZwgADMBAQGeIAAAAAAkYIAKAQAAAAEACAAA" +
           "AENsZWFyaW5nAQFoIAMAAAAAfAAAAENsZWFycyBmYXVsdHMgdGhhdCBtYXkgaGF2ZSBvY2N1cnJlZCB3" +
           "aGVuIEFib3J0aW5nIGFuZCBhcmUgcHJlc2VudCBpbiB0aGUgQWJvcnRlZCBzdGF0ZSBiZWZvcmUgcHJv" +
           "Y2VlZGluZyB0byBhIFN0b3BwZWQgc3RhdGUALwEAAwloIAAAAgAAAAA0AQEBniAAMwEBAaAgAAAAAARg" +
           "gAoBAAAAAQAcAAAAU3RvcHBlZFRvUmVzZXR0aW5nVHJhbnNpdGlvbgEBaiAALwEABglqIAAABAAAAAAz" +
           "AAEByR8ANAABAcsfADUAAQGzHwA1AAEBoB8AAAAABGCACgEAAAABABMAAABSZXNldHRpbmdUcmFuc2l0" +
           "aW9uAQFsIAAvAQAGCWwgAAACAAAAADMAAQHLHwA0AAEByx8AAAAABGCACgEAAAABABkAAABSZXNldHRp" +
           "bmdUb0lkbGVUcmFuc2l0aW9uAQFuIAAvAQAGCW4gAAACAAAAADMAAQHLHwA0AAEBzR8AAAAABGCACgEA" +
           "AAABABgAAABJZGxlVG9TdGFydGluZ1RyYW5zaXRpb24BAXAgAC8BAAYJcCAAAAQAAAAAMwABAc0fADQA" +
           "AQHPHwA1AAEBtB8ANQABAa8fAAAAAARggAoBAAAAAQASAAAAU3RhcnRpbmdUcmFuc2l0aW9uAQFyIAAv" +
           "AQAGCXIgAAACAAAAADMAAQHPHwA0AAEBzx8AAAAABGCACgEAAAABABsAAABTdGFydGluZ1RvRXhlY3V0" +
           "ZVRyYW5zaXRpb24BAXQgAC8BAAYJdCAAAAIAAAAAMwABAc8fADQAAQHRHwAAAAAEYIAKAQAAAAEAHQAA" +
           "AEV4ZWN1dGVUb0NvbXBsZXRpbmdUcmFuc2l0aW9uAQF2IAAvAQAGCXYgAAACAAAAADMAAQHRHwA0AAEB" +
           "UiAAAAAABGCACgEAAAABABQAAABDb21wbGV0aW5nVHJhbnNpdGlvbgEBeCAALwEABgl4IAAAAgAAAAAz" +
           "AAEBUiAANAABAVIgAAAAAARggAoBAAAAAQAeAAAAQ29tcGxldGluZ1RvQ29tcGxldGVUcmFuc2l0aW9u" +
           "AQF6IAAvAQAGCXogAAACAAAAADMAAQFSIAA0AAEBVCAAAAAABGCACgEAAAABABsAAABDb21wbGV0ZVRv" +
           "U3RvcHBlZFRyYW5zaXRpb24BAXwgAC8BAAYJfCAAAAIAAAAAMwABAVQgADQAAQHJHwAAAAAEYIAKAQAA" +
           "AAEAGgAAAEV4ZWN1dGVUb0hvbGRpbmdUcmFuc2l0aW9uAQF+IAAvAQAGCX4gAAADAAAAADMAAQHRHwA0" +
           "AAEBXCAANQABAbYfAAAAAARggAoBAAAAAQARAAAASG9sZGluZ1RyYW5zaXRpb24BAYAgAC8BAAYJgCAA" +
           "AAIAAAAAMwABAVwgADQAAQFcIAAAAAAEYIAKAQAAAAEAFwAAAEhvbGRpbmdUb0hlbGRUcmFuc2l0aW9u" +
           "AQGCIAAvAQAGCYIgAAACAAAAADMAAQFcIAA0AAEBXiAAAAAABGCACgEAAAABABkAAABIZWxkVG9Vbmhv" +
           "bGRpbmdUcmFuc2l0aW9uAQGEIAAvAQAGCYQgAAADAAAAADMAAQFeIAA0AAEBYCAANQABAbcfAAAAAARg" +
           "gAoBAAAAAQATAAAAVW5ob2xkaW5nVHJhbnNpdGlvbgEBhiAALwEABgmGIAAAAgAAAAAzAAEBYCAANAAB" +
           "AWAgAAAAAARggAoBAAAAAQAcAAAAVW5ob2xkaW5nVG9Ib2xkaW5nVHJhbnNpdGlvbgEBiCAALwEABgmI" +
           "IAAAAwAAAAAzAAEBYCAANAABAVwgADUAAQG2HwAAAAAEYIAKAQAAAAEAHAAAAFVuaG9sZGluZ1RvRXhl" +
           "Y3V0ZVRyYW5zaXRpb24BAYogAC8BAAYJiiAAAAIAAAAAMwABAWAgADQAAQHRHwAAAAAEYIAKAQAAAAEA" +
           "HQAAAEV4ZWN1dGVUb1N1c3BlbmRpbmdUcmFuc2l0aW9uAQGMIAAvAQAGCYwgAAADAAAAADMAAQHRHwA0" +
           "AAEBViAANQABAbgfAAAAAARggAoBAAAAAQAUAAAAU3VzcGVuZGluZ1RyYW5zaXRpb24BAY4gAC8BAAYJ" +
           "jiAAAAIAAAAAMwABAVYgADQAAQFWIAAAAAAEYIAKAQAAAAEAHwAAAFN1c3BlbmRpbmdUb1N1c3BlbmRl" +
           "ZFRyYW5zaXRpb24BAZAgAC8BAAYJkCAAAAIAAAAAMwABAVYgADQAAQFYIAAAAAAEYIAKAQAAAAEAIQAA" +
           "AFN1c3BlbmRlZFRvVW5zdXNwZW5kaW5nVHJhbnNpdGlvbgEBkiAALwEABgmSIAAAAwAAAAAzAAEBWCAA" +
           "NAABAVogADUAAQG5HwAAAAAEYIAKAQAAAAEAFgAAAFVuc3VzcGVuZGluZ1RyYW5zaXRpb24BAZQgAC8B" +
           "AAYJlCAAAAIAAAAAMwABAVogADQAAQFaIAAAAAAEYIAKAQAAAAEAIgAAAFVuc3VzcGVuZGluZ1RvU3Vz" +
           "cGVuZGluZ1RyYW5zaXRpb24BAZYgAC8BAAYJliAAAAMAAAAAMwABAVogADQAAQFWIAA1AAEBuB8AAAAA" +
           "BGCACgEAAAABAB8AAABVbnN1c3BlbmRpbmdUb0V4ZWN1dGVUcmFuc2l0aW9uAQGYIAAvAQAGCZggAAAC" +
           "AAAAADMAAQFaIAA0AAEB0R8AAAAABGCACgEAAAABABsAAABTdG9wcGluZ1RvU3RvcHBlZFRyYW5zaXRp" +
           "b24BAZogAC8BAAYJmiAAAAIAAAAAMwABAWIgADQAAQHJHwAAAAAEYIAKAQAAAAEAGwAAAEFib3J0aW5n" +
           "VG9BYm9ydGVkVHJhbnNpdGlvbgEBnCAALwEABgmcIAAAAgAAAAAzAAEBZCAANAABAWYgAAAAAARggAoB" +
           "AAAAAQAbAAAAQWJvcnRlZFRvQ2xlYXJpbmdUcmFuc2l0aW9uAQGeIAAvAQAGCZ4gAAADAAAAADMAAQFm" +
           "IAA0AAEBaCAANQABAbsfAAAAAARggAoBAAAAAQAbAAAAQ2xlYXJpbmdUb1N0b3BwZWRUcmFuc2l0aW9u" +
           "AQGgIAAvAQAGCaAgAAACAAAAADMAAQFoIAA0AAEByR8AAAAABGCACgEAAAABAB0AAABSZXNldHRpbmdU" +
           "b1N0b3BwaW5nVHJhbnNpdGlvbgEBoiAALwEABgmiIAAAAwAAAAAzAAEByx8ANAABAWIgADUAAQG1HwAA" +
           "AAAEYIAKAQAAAAEAGAAAAElkbGVUb1N0b3BwaW5nVHJhbnNpdGlvbgEBpCAALwEABgmkIAAAAwAAAAAz" +
           "AAEBzR8ANAABAWIgADUAAQG1HwAAAAAEYIAKAQAAAAEAHAAAAFN0YXJ0aW5nVG9TdG9wcGluZ1RyYW5z" +
           "aXRpb24BAaYgAC8BAAYJpiAAAAMAAAAAMwABAc8fADQAAQFiIAA1AAEBtR8AAAAABGCACgEAAAABABsA" +
           "AABFeGVjdXRlVG9TdG9wcGluZ1RyYW5zaXRpb24BAaggAC8BAAYJqCAAAAMAAAAAMwABAdEfADQAAQFi" +
           "IAA1AAEBtR8AAAAABGCACgEAAAABAB4AAABDb21wbGV0aW5nVG9TdG9wcGluZ1RyYW5zaXRpb24BAaog" +
           "AC8BAAYJqiAAAAMAAAAAMwABAVIgADQAAQFiIAA1AAEBtR8AAAAABGCACgEAAAABABwAAABDb21wbGV0" +
           "ZVRvU3RvcHBpbmdUcmFuc2l0aW9uAQGsIAAvAQAGCawgAAADAAAAADMAAQFUIAA0AAEBYiAANQABAbUf" +
           "AAAAAARggAoBAAAAAQAeAAAAU3VzcGVuZGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9uAQGuIAAvAQAGCa4g" +
           "AAADAAAAADMAAQFWIAA0AAEBYiAANQABAbUfAAAAAARggAoBAAAAAQAdAAAAU3VzcGVuZGVkVG9TdG9w" +
           "cGluZ1RyYW5zaXRpb24BAbAgAC8BAAYJsCAAAAMAAAAAMwABAVggADQAAQFiIAA1AAEBtR8AAAAABGCA" +
           "CgEAAAABACAAAABVbnN1c3BlbmRpbmdUb1N0b3BwaW5nVHJhbnNpdGlvbgEBsiAALwEABgmyIAAAAwAA" +
           "AAAzAAEBWiAANAABAWIgADUAAQG1HwAAAAAEYIAKAQAAAAEAGwAAAEhvbGRpbmdUb1N0b3BwaW5nVHJh" +
           "bnNpdGlvbgEBtCAALwEABgm0IAAAAwAAAAAzAAEBXCAANAABAWIgADUAAQG1HwAAAAAEYIAKAQAAAAEA" +
           "GAAAAEhlbGRUb1N0b3BwaW5nVHJhbnNpdGlvbgEBtiAALwEABgm2IAAAAwAAAAAzAAEBXiAANAABAWIg" +
           "ADUAAQG1HwAAAAAEYIAKAQAAAAEAHQAAAFVuaG9sZGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9uAQG4IAAv" +
           "AQAGCbggAAADAAAAADMAAQFgIAA0AAEBYiAANQABAbUfAAAAAARggAoBAAAAAQAbAAAAU3RvcHBlZFRv" +
           "QWJvcnRpbmdUcmFuc2l0aW9uAQG6IAAvAQAGCbogAAADAAAAADMAAQHJHwA0AAEBZCAANQABAbofAAAA" +
           "AARggAoBAAAAAQAdAAAAUmVzZXR0aW5nVG9BYm9ydGluZ1RyYW5zaXRpb24BAbwgAC8BAAYJvCAAAAMA" +
           "AAAAMwABAcsfADQAAQFkIAA1AAEBuh8AAAAABGCACgEAAAABABgAAABJZGxlVG9BYm9ydGluZ1RyYW5z" +
           "aXRpb24BAb4gAC8BAAYJviAAAAMAAAAAMwABAc0fADQAAQFkIAA1AAEBuh8AAAAABGCACgEAAAABABwA" +
           "AABTdGFydGluZ1RvQWJvcnRpbmdUcmFuc2l0aW9uAQHAIAAvAQAGCcAgAAADAAAAADMAAQHPHwA0AAEB" +
           "ZCAANQABAbofAAAAAARggAoBAAAAAQAbAAAARXhlY3V0ZVRvQWJvcnRpbmdUcmFuc2l0aW9uAQHCIAAv" +
           "AQAGCcIgAAADAAAAADMAAQHRHwA0AAEBZCAANQABAbofAAAAAARggAoBAAAAAQAeAAAAQ29tcGxldGlu" +
           "Z1RvQWJvcnRpbmdUcmFuc2l0aW9uAQHEIAAvAQAGCcQgAAADAAAAADMAAQFSIAA0AAEBZCAANQABAbof" +
           "AAAAAARggAoBAAAAAQAcAAAAQ29tcGxldGVUb0Fib3J0aW5nVHJhbnNpdGlvbgEBxiAALwEABgnGIAAA" +
           "AwAAAAAzAAEBVCAANAABAWQgADUAAQG6HwAAAAAEYIAKAQAAAAEAHgAAAFN1c3BlbmRpbmdUb0Fib3J0" +
           "aW5nVHJhbnNpdGlvbgEByCAALwEABgnIIAAAAwAAAAAzAAEBViAANAABAWQgADUAAQG6HwAAAAAEYIAK" +
           "AQAAAAEAHQAAAFN1c3BlbmRlZFRvQWJvcnRpbmdUcmFuc2l0aW9uAQHKIAAvAQAGCcogAAADAAAAADMA" +
           "AQFYIAA0AAEBZCAANQABAbofAAAAAARggAoBAAAAAQAgAAAAVW5zdXNwZW5kaW5nVG9BYm9ydGluZ1Ry" +
           "YW5zaXRpb24BAcwgAC8BAAYJzCAAAAMAAAAAMwABAVogADQAAQFkIAA1AAEBuh8AAAAABGCACgEAAAAB" +
           "ABsAAABIb2xkaW5nVG9BYm9ydGluZ1RyYW5zaXRpb24BAc4gAC8BAAYJziAAAAMAAAAAMwABAVwgADQA" +
           "AQFkIAA1AAEBuh8AAAAABGCACgEAAAABABgAAABIZWxkVG9BYm9ydGluZ1RyYW5zaXRpb24BAdAgAC8B" +
           "AAYJ0CAAAAMAAAAAMwABAV4gADQAAQFkIAA1AAEBuh8AAAAABGCACgEAAAABAB0AAABVbmhvbGRpbmdU" +
           "b0Fib3J0aW5nVHJhbnNpdGlvbgEB0iAALwEABgnSIAAAAwAAAAAzAAEBYCAANAABAWQgADUAAQG6HwAA" +
           "AAAEYIAKAQAAAAEAHAAAAFN0b3BwaW5nVG9BYm9ydGluZ1RyYW5zaXRpb24BAdQgAC8BAAYJ1CAAAAMA" +
           "AAAAMwABAWIgADQAAQFkIAA1AAEBuh8AAAAAJGCACgEAAAABAAUAAABMb2NhbAEBtRMDAAAAAHsAAABU" +
           "aGUgQW5hbHlzZXJDaGFubmVsIGlzIGluIHRoZSBMb2NhbCBtb2RlLiBUaGlzIG1vZGUgaXMgbm9ybWFs" +
           "bHkgdXNlZCB0byBwZXJmb3JtIGxvY2FsIHBoeXNpY2FsIG1haW50ZW5hbmNlIG9uIHRoZSBhbmFseXNl" +
           "ci4ALwEB7QO1EwAABQAAAAA0AQEBuBMAMwEBAboTADMBAQG7EwA0AQEBvRMAMwEBAb8TAAAAACRggAoB" +
           "AAAAAQALAAAATWFpbnRlbmFuY2UBAbYTAwAAAACGAAAAVGhlIEFuYWx5c2VyQ2hhbm5lbCBpcyBpbiB0" +
           "aGUgTWFpbnRlbmFuY2UgbW9kZS4gVGhpcyBtb2RlIGlzIHVzZWQgdG8gcGVyZm9ybSByZW1vdGUgbWFp" +
           "bnRlbmFuY2Ugb24gdGhlIGFuYWx5c2VyIGxpa2UgZmlybXdhcmUgdXBncmFkZS4ALwEB7gO2EwAABQAA" +
           "AAA0AQEBuRMANAEBAbsTADMBAQG8EwAzAQEBvRMAMwEBAcATAAAAAARggAoBAAAAAQAeAAAAU2xhdmVN" +
           "b2RlVG9PcGVyYXRpbmdUcmFuc2l0aW9uAQG3EwAvAQAGCbcTAAACAAAAADMAAQGyEwA0AAEBsxMAAAAA" +
           "BGCACgEAAAABABoAAABPcGVyYXRpbmdUb0xvY2FsVHJhbnNpdGlvbgEBuBMALwEABgm4EwAAAgAAAAAz" +
           "AAEBsxMANAABAbUTAAAAAARggAoBAAAAAQAgAAAAT3BlcmF0aW5nVG9NYWludGVuYW5jZVRyYW5zaXRp" +
           "b24BAbkTAC8BAAYJuRMAAAMAAAAAMwABAbMTADQAAQG2EwA1AAEBsh8AAAAABGCACgEAAAABABoAAABM" +
           "b2NhbFRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBuhMALwEABgm6EwAAAgAAAAAzAAEBtRMANAABAbMTAAAA" +
           "AARggAoBAAAAAQAcAAAATG9jYWxUb01haW50ZW5hbmNlVHJhbnNpdGlvbgEBuxMALwEABgm7EwAAAgAA" +
           "AAAzAAEBtRMANAABAbYTAAAAAARggAoBAAAAAQAgAAAATWFpbnRlbmFuY2VUb09wZXJhdGluZ1RyYW5z" +
           "aXRpb24BAbwTAC8BAAYJvBMAAAMAAAAAMwABAbYTADQAAQGzEwA1AAEBsR8AAAAABGCACgEAAAABABwA" +
           "AABNYWludGVuYW5jZVRvTG9jYWxUcmFuc2l0aW9uAQG9EwAvAQAGCb0TAAACAAAAADMAAQG2EwA0AAEB" +
           "tRMAAAAABGCACgEAAAABAB4AAABPcGVyYXRpbmdUb1NsYXZlTW9kZVRyYW5zaXRpb24BAb4TAC8BAAYJ" +
           "vhMAAAIAAAAAMwABAbMTADQAAQGyEwAAAAAEYIAKAQAAAAEAGgAAAExvY2FsVG9TbGF2ZU1vZGVUcmFu" +
           "c2l0aW9uAQG/EwAvAQAGCb8TAAACAAAAADMAAQG1EwA0AAEBshMAAAAABGCACgEAAAABACAAAABNYWlu" +
           "dGVuYW5jZVRvU2xhdmVNb2RlVHJhbnNpdGlvbgEBwBMALwEABgnAEwAAAgAAAAAzAAEBthMANAABAbIT" +
           "AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Configuration Object.
        /// </summary>
        public FunctionalGroupState Configuration
        {
            get
            { 
                return m_configuration;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_configuration, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_configuration = value;
            }
        }

        /// <summary>
        /// A description for the Status Object.
        /// </summary>
        public FunctionalGroupState Status
        {
            get
            { 
                return m_status;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_status, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_status = value;
            }
        }

        /// <summary>
        /// A description for the ChannelStateMachine Object.
        /// </summary>
        public AnalyserChannelStateMachineState ChannelStateMachine
        {
            get
            { 
                return m_channelStateMachine;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_channelStateMachine, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_channelStateMachine = value;
            }
        }

        /// <summary>
        /// A description for the <GroupIdentifier> Object.
        /// </summary>
        public FunctionalGroupState GroupIdentifier
        {
            get
            { 
                return m_groupIdentifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_groupIdentifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_groupIdentifier = value;
            }
        }

        /// <summary>
        /// A description for the <StreamIdentifier> Object.
        /// </summary>
        public StreamState StreamIdentifier
        {
            get
            { 
                return m_streamIdentifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_streamIdentifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_streamIdentifier = value;
            }
        }

        /// <summary>
        /// A description for the <AccessorySlotIdentifier> Object.
        /// </summary>
        public AccessorySlotState AccessorySlotIdentifier
        {
            get
            { 
                return m_accessorySlotIdentifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_accessorySlotIdentifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_accessorySlotIdentifier = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_configuration != null)
            {
                children.Add(m_configuration);
            }

            if (m_status != null)
            {
                children.Add(m_status);
            }

            if (m_channelStateMachine != null)
            {
                children.Add(m_channelStateMachine);
            }

            if (m_groupIdentifier != null)
            {
                children.Add(m_groupIdentifier);
            }

            if (m_streamIdentifier != null)
            {
                children.Add(m_streamIdentifier);
            }

            if (m_accessorySlotIdentifier != null)
            {
                children.Add(m_accessorySlotIdentifier);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Configuration:
                {
                    if (createOrReplace)
                    {
                        if (Configuration == null)
                        {
                            if (replacement == null)
                            {
                                Configuration = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Configuration = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Configuration;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Status:
                {
                    if (createOrReplace)
                    {
                        if (Status == null)
                        {
                            if (replacement == null)
                            {
                                Status = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Status = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Status;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ChannelStateMachine:
                {
                    if (createOrReplace)
                    {
                        if (ChannelStateMachine == null)
                        {
                            if (replacement == null)
                            {
                                ChannelStateMachine = new AnalyserChannelStateMachineState(this);
                            }
                            else
                            {
                                ChannelStateMachine = (AnalyserChannelStateMachineState)replacement;
                            }
                        }
                    }

                    instance = ChannelStateMachine;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FunctionalGroupState m_configuration;
        private FunctionalGroupState m_status;
        private AnalyserChannelStateMachineState m_channelStateMachine;
        private FunctionalGroupState m_groupIdentifier;
        private StreamState m_streamIdentifier;
        private AccessorySlotState m_accessorySlotIdentifier;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannelTypeStartSingleAcquisitionMethodMethodState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelTypeStartSingleAcquisitionMethodMethodState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelTypeStartSingleAcquisitionMethod Method.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelTypeStartSingleAcquisitionMethodMethodState : MethodState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelTypeStartSingleAcquisitionMethodMethodState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Constructs an instance of a node.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns>The new node.</returns>
        public new static NodeState Construct(NodeState parent)
        {
            return new AnalyserChannelTypeStartSingleAcquisitionMethodMethodState(parent);
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRhggoEAAAAAQAvAAAAQW5hbHlzZXJDaGFubmVsVHlwZVN0YXJ0U2lu" +
           "Z2xlQWNxdWlzaXRpb25NZXRob2QBAVQfAC8BAVQfVB8AAAEB/////wEAAAAVYKkKAgAAAAAADgAAAElu" +
           "cHV0QXJndW1lbnRzAQEDGAAuAEQDGAAAlgMAAAABACoBAR8AAAAOAAAARXhlY3V0aW9uQ3ljbGUBAaIk" +
           "/////wAAAAAAAQAqAQEkAAAAFQAAAEV4ZWN1dGlvbkN5Y2xlU3ViY29kZQAH/////wAAAAAAAQAqAQEd" +
           "AAAADgAAAFNlbGVjdGVkU3RyZWFtAAz/////AAAAAAABACgBAQAAAAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion
        
        #region Event Callbacks
        /// <summary>
        /// Raised when the the method is called.
        /// </summary>
        public AnalyserChannelTypeStartSingleAcquisitionMethodMethodStateMethodCallHandler OnCall;
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Invokes the method, returns the result and output argument.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="objectId">The id of the object.</param>
        /// <param name="inputArguments">The input arguments which have been already validated.</param>
        /// <param name="outputArguments">The output arguments which have initialized with thier default values.</param>
        /// <returns></returns>
        protected override ServiceResult Call(
            ISystemContext context,
            NodeId objectId,
            IList<object> inputArguments,
            IList<object> outputArguments)
        {
            if (OnCall == null)
            {
                return base.Call(context, objectId, inputArguments, outputArguments);
            }

            ServiceResult result = null;
            
            ExecutionCycleEnumeration executionCycle = (ExecutionCycleEnumeration)inputArguments[0];
            uint executionCycleSubcode = (uint)inputArguments[1];
            string selectedStream = (string)inputArguments[2];

            if (OnCall != null)
            {
                result = OnCall(
                    context,
                    this,
                    objectId,
                    executionCycle,
                    executionCycleSubcode,
                    selectedStream);
            }

            return result;
        }
        #endregion

        #region Private Fields
        #endregion
    }

    /// <summary>
    /// Used to receive notifications when the method is called.
    /// </summary>
    /// <exclude />
    public delegate ServiceResult AnalyserChannelTypeStartSingleAcquisitionMethodMethodStateMethodCallHandler(
        ISystemContext context,
        MethodState method,
        NodeId objectId,
        ExecutionCycleEnumeration executionCycle,
        uint executionCycleSubcode,
        string selectedStream);
    #endif
    #endregion

    #region AnalyserChannelOperatingStateState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelOperatingStateState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelOperatingStateType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelOperatingStateState : StateMachineStateState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelOperatingStateState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannelOperatingStateType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQApAAAAQW5hbHlzZXJDaGFubmVsT3BlcmF0aW5nU3Rh" +
           "dGVUeXBlSW5zdGFuY2UBAewDAQHsAwH/////AQAAAARggAoBAAAAAQAYAAAAT3BlcmF0aW5nU3ViU3Rh" +
           "dGVNYWNoaW5lAQHBEwAvAQHwA8ETAAAKAAAAAC8AAQGzHwAvAAEBtB8ALwABAa8fAC8AAQG1HwAvAAEB" +
           "th8ALwABAbcfAC8AAQG4HwAvAAEBuR8ALwABAbofAC8AAQG7H0gAAAAVYIkKAgAAAAAADAAAAEN1cnJl" +
           "bnRTdGF0ZQEB1iAALwEAyArWIAAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAdcgAC4A" +
           "RNcgAAAAEf////8BAf////8AAAAAJGCACgEAAAABAAcAAABTdG9wcGVkAQHgIAMAAAAASAAAAFRoaXMg" +
           "aXMgdGhlIGluaXRpYWwgc3RhdGUgYWZ0ZXIgQW5hbHlzZXJEZXZpY2VTdGF0ZU1hY2hpbmUgc3RhdGUg" +
           "UG93ZXJ1cAAvAQAFCeAgAAAFAAAAADMBAQGBIQA0AQEBkyEANAEBAbEhADQBAQG3IQAzAQEB0SEAAAAA" +
           "JGCACgEAAAABAAkAAABSZXNldHRpbmcBAeIgAwAAAABbAAAAVGhpcyBzdGF0ZSBpcyB0aGUgcmVzdWx0" +
           "IG9mIGEgUmVzZXQgb3IgU2V0Q29uZmlndXJhdGlvbiBNZXRob2QgY2FsbCBmcm9tIHRoZSBTdG9wcGVk" +
           "IHN0YXRlLgAvAQADCeIgAAAGAAAAADQBAQGBIQAzAQEBgyEANAEBAYMhADMBAQGFIQAzAQEBuSEAMwEB" +
           "AdMhAAAAACRggAoBAAAAAQAEAAAASWRsZQEB5CADAAAAAGMAAABUaGUgUmVzZXR0aW5nIHN0YXRlIGlz" +
           "IGNvbXBsZXRlZCwgYWxsIHBhcmFtZXRlcnMgaGF2ZSBiZWVuIGNvbW1pdHRlZCBhbmQgcmVhZHkgdG8g" +
           "c3RhcnQgYWNxdWlzaXRpb24ALwEAAwnkIAAABAAAAAA0AQEBhSEAMwEBAYchADMBAQG7IQAzAQEB1SEA" +
           "AAAAJGCACgEAAAABAAgAAABTdGFydGluZwEB5iADAAAAAHgAAABUaGUgYW5hbHlzZXIgaGFzIHJlY2Vp" +
           "dmVkIHRoZSBTdGFydCBvciBTaW5nbGVBY3F1aXNpdGlvblN0YXJ0IE1ldGhvZCBjYWxsIGFuZCBpdCBp" +
           "cyBwcmVwYXJpbmcgdG8gZW50ZXIgaW4gRXhlY3V0ZSBzdGF0ZS4ALwEAAwnmIAAABgAAAAA0AQEBhyEA" +
           "MwEBAYkhADQBAQGJIQAzAQEBiyEAMwEBAb0hADMBAQHXIQAAAAAkYIAKAQAAAAEABwAAAEV4ZWN1dGUB" +
           "AeggAwAAAAA5AAAAQWxsIHJlcGV0aXRpdmUgYWNxdWlzaXRpb24gY3ljbGVzIGFyZSBkb25lIGluIHRo" +
           "aXMgc3RhdGU6AC8BAQQj6CAAAAgAAAAANAEBAYshADMBAQGNIQAzAQEBlSEANAEBAaEhADMBAQGjIQA0" +
           "AQEBryEAMwEBAb8hADMBAQHZIQEAAAAEYIAKAQAAAAEAHwAAAE9wZXJhdGluZ0V4ZWN1dGVTdWJTdGF0" +
           "ZU1hY2hpbmUBAeogAC8BAfED6iAAAP////87AAAAFWCJCgIAAAAAAAwAAABDdXJyZW50U3RhdGUBAesg" +
           "AC8BAMgK6yAAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQHsIAAuAETsIAAAABH/////" +
           "AQH/////AAAAACRggAoBAAAAAQAUAAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGUBAfUgAwAAAABIAAAAVGhp" +
           "cyBwc2V1ZG8tc3RhdGUgaXMgdXNlZCB0byBkZWNpZGUgd2hpY2ggZXhlY3V0aW9uIHBhdGggc2hhbGwg" +
           "YmUgdGFrZW4uAC8BAAUJ9SAAAAYAAAAAMwEBAR0hADMBAQEtIQAzAQEBPSEAMwEBAU0hADMBAQFVIQA0" +
           "AQEBZyEAAAAAJGCACgEAAAABABkAAABXYWl0Rm9yQ2FsaWJyYXRpb25UcmlnZ2VyAQH3IAMAAAAAVQAA" +
           "AFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9ybSB0aGUgQ2Fs" +
           "aWJyYXRpb24gYWNxdWlzaXRpb24gY3ljbGUALwEAAwn3IAAAAgAAAAA0AQEBHSEAMwEBAR8hAAAAACRg" +
           "gAoBAAAAAQAYAAAARXh0cmFjdENhbGlicmF0aW9uU2FtcGxlAQH5IAMAAAAAWwAAAENvbGxlY3QgLyBz" +
           "ZXR1cCB0aGUgc2FtcGxpbmcgc3lzdGVtIHRvIHBlcmZvcm0gdGhlIGFjcXVpc2l0aW9uIGN5Y2xlIG9m" +
           "IGEgQ2FsaWJyYXRpb24gY3ljbGUALwEAAwn5IAAABAAAAAA0AQEBHyEAMwEBASEhADQBAQEhIQAzAQEB" +
           "IyEAAAAAJGCACgEAAAABABgAAABQcmVwYXJlQ2FsaWJyYXRpb25TYW1wbGUBAfsgAwAAAABFAAAAUHJl" +
           "cGFyZSB0aGUgQ2FsaWJyYXRpb24gc2FtcGxlIGZvciB0aGUgQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxl" +
           "IHN0YXRlAC8BAAMJ+yAAAAQAAAAANAEBASMhADMBAQElIQA0AQEBJSEAMwEBASchAAAAACRggAoBAAAA" +
           "AQAYAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxlAQH9IAMAAAAALgAAAFBlcmZvcm0gdGhlIGFuYWx5" +
           "c2lzIG9mIHRoZSBDYWxpYnJhdGlvbiBTYW1wbGUALwEAAwn9IAAABAAAAAA0AQEBJyEAMwEBASkhADQB" +
           "AQEpIQAzAQEBKyEAAAAAJGCACgEAAAABABgAAABXYWl0Rm9yVmFsaWRhdGlvblRyaWdnZXIBAf8gAwAA" +
           "AABUAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFkeSB0byBwZXJmb3JtIHRo" +
           "ZSBWYWxpZGF0aW9uIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJ/yAAAAIAAAAANAEBAS0hADMBAQEvIQAA" +
           "AAAkYIAKAQAAAAEAFwAAAEV4dHJhY3RWYWxpZGF0aW9uU2FtcGxlAQEBIQMAAAAAWgAAAENvbGxlY3Qg" +
           "LyBzZXR1cCB0aGUgc2FtcGxpbmcgc3lzdGVtIHRvIHBlcmZvcm0gdGhlIGFjcXVpc2l0aW9uIGN5Y2xl" +
           "IG9mIGEgVmFsaWRhdGlvbiBjeWNsZQAvAQADCQEhAAAEAAAAADQBAQEvIQAzAQEBMSEANAEBATEhADMB" +
           "AQEzIQAAAAAkYIAKAQAAAAEAFwAAAFByZXBhcmVWYWxpZGF0aW9uU2FtcGxlAQEDIQMAAAAAQwAAAFBy" +
           "ZXBhcmUgdGhlIFZhbGlkYXRpb24gc2FtcGxlIGZvciB0aGUgQW5hbHlzZVZhbGlkYXRpb25TYW1wbGUg" +
           "c3RhdGUALwEAAwkDIQAABAAAAAA0AQEBMyEAMwEBATUhADQBAQE1IQAzAQEBNyEAAAAAJGCACgEAAAAB" +
           "ABcAAABBbmFseXNlVmFsaWRhdGlvblNhbXBsZQEBBSEDAAAAAC0AAABQZXJmb3JtIHRoZSBhbmFseXNp" +
           "cyBvZiB0aGUgVmFsaWRhdGlvbiBTYW1wbGUALwEAAwkFIQAABAAAAAA0AQEBNyEAMwEBATkhADQBAQE5" +
           "IQAzAQEBOyEAAAAAJGCACgEAAAABABQAAABXYWl0Rm9yU2FtcGxlVHJpZ2dlcgEBByEDAAAAAFAAAABX" +
           "YWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRvIHBlcmZvcm0gdGhlIFNhbXBs" +
           "ZSBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCQchAAACAAAAADQBAQE9IQAzAQEBPyEAAAAAJGCACgEAAAAB" +
           "AA0AAABFeHRyYWN0U2FtcGxlAQEJIQMAAAAAIwAAAENvbGxlY3QgdGhlIFNhbXBsZSBmcm9tIHRoZSBw" +
           "cm9jZXNzAC8BAAMJCSEAAAQAAAAANAEBAT8hADMBAQFBIQA0AQEBQSEAMwEBAUMhAAAAACRggAoBAAAA" +
           "AQANAAAAUHJlcGFyZVNhbXBsZQEBCyEDAAAAAC4AAABQcmVwYXJlIHRoZSBTYW1wbGUgZm9yIHRoZSBB" +
           "bmFseXNlU2FtcGxlIHN0YXRlAC8BAAMJCyEAAAQAAAAANAEBAUMhADMBAQFFIQA0AQEBRSEAMwEBAUch" +
           "AAAAACRggAoBAAAAAQANAAAAQW5hbHlzZVNhbXBsZQEBDSEDAAAAACIAAABQZXJmb3JtIHRoZSBhbmFs" +
           "eXNpcyBvZiB0aGUgU2FtcGxlAC8BAAMJDSEAAAQAAAAANAEBAUchADMBAQFJIQA0AQEBSSEAMwEBAUsh" +
           "AAAAACRggAoBAAAAAQAYAAAAV2FpdEZvckRpYWdub3N0aWNUcmlnZ2VyAQEPIQMAAAAASQAAAFdhaXQg" +
           "dW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9ybSB0aGUgZGlhZ25vc3Rp" +
           "YyBjeWNsZSwALwEAAwkPIQAAAgAAAAA0AQEBTSEAMwEBAU8hAAAAACRggAoBAAAAAQAKAAAARGlhZ25v" +
           "c3RpYwEBESEDAAAAAB0AAABQZXJmb3JtIHRoZSBkaWFnbm9zdGljIGN5Y2xlLgAvAQADCREhAAAEAAAA" +
           "ADQBAQFPIQAzAQEBUSEANAEBAVEhADMBAQFTIQAAAAAkYIAKAQAAAAEAFgAAAFdhaXRGb3JDbGVhbmlu" +
           "Z1RyaWdnZXIBARMhAwAAAABHAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFk" +
           "eSB0byBwZXJmb3JtIHRoZSBjbGVhbmluZyBjeWNsZSwALwEAAwkTIQAAAgAAAAA0AQEBVSEAMwEBAVch" +
           "AAAAACRggAoBAAAAAQAIAAAAQ2xlYW5pbmcBARUhAwAAAAAbAAAAUGVyZm9ybSB0aGUgY2xlYW5pbmcg" +
           "Y3ljbGUuAC8BAAMJFSEAAAQAAAAANAEBAVchADMBAQFZIQA0AQEBWSEAMwEBAVshAAAAACRggAoBAAAA" +
           "AQAOAAAAUHVibGlzaFJlc3VsdHMBARchAwAAAAA1AAAAUHVibGlzaCB0aGUgcmVzdWx0cyBvZiB0aGUg" +
           "cHJldmlvdXMgYWNxdWlzaXRpb24gY3ljbGUALwEAAwkXIQAABwAAAAA0AQEBKyEANAEBATshADQBAQFL" +
           "IQA0AQEBUyEANAEBAVshADMBAQFdIQAzAQEBXyEAAAAAJGCACgEAAAABAA8AAABFamVjdEdyYWJTYW1w" +
           "bGUBARkhAwAAAABvAAAAVGhlIFNhbXBsZSB0aGF0IHdhcyBqdXN0IGFuYWx5c2VkIGlzIGVqZWN0ZWQg" +
           "ZnJvbSB0aGUgc3lzdGVtIHRvIGFsbG93IHRoZSBvcGVyYXRvciBvciBhbm90aGVyIHN5c3RlbSB0byBn" +
           "cmFiIGl0AC8BAAMJGSEAAAQAAAAANAEBAV8hADMBAQFhIQA0AQEBYSEAMwEBAWMhAAAAACRggAoBAAAA" +
           "AQAVAAAAQ2xlYW51cFNhbXBsaW5nU3lzdGVtAQEbIQMAAAAARAAAAENsZWFudXAgdGhlIHNhbXBsaW5n" +
           "IHN1Yi1zeXN0ZW0gdG8gYmUgcmVhZHkgZm9yIHRoZSBuZXh0IGFjcXVpc2l0aW9uAC8BAAMJGyEAAAUA" +
           "AAAANAEBAV0hADQBAQFjIQAzAQEBZSEANAEBAWUhADMBAQFnIQAAAAAEYIAKAQAAAAEAOQAAAFNlbGVj" +
           "dEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yQ2FsaWJyYXRpb25UcmlnZ2VyVHJhbnNpdGlvbgEBHSEALwEA" +
           "BgkdIQAAAgAAAAAzAAEB9SAANAABAfcgAAAAAARggAoBAAAAAQA9AAAAV2FpdEZvckNhbGlicmF0aW9u" +
           "VHJpZ2dlclRvRXh0cmFjdENhbGlicmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBHyEALwEABgkfIQAAAgAA" +
           "AAAzAAEB9yAANAABAfkgAAAAAARggAoBAAAAAQAiAAAARXh0cmFjdENhbGlicmF0aW9uU2FtcGxlVHJh" +
           "bnNpdGlvbgEBISEALwEABgkhIQAAAgAAAAAzAAEB+SAANAABAfkgAAAAAARggAoBAAAAAQA8AAAARXh0" +
           "cmFjdENhbGlicmF0aW9uU2FtcGxlVG9QcmVwYXJlQ2FsaWJyYXRpb25TYW1wbGVUcmFuc2l0aW9uAQEj" +
           "IQAvAQAGCSMhAAACAAAAADMAAQH5IAA0AAEB+yAAAAAABGCACgEAAAABACIAAABQcmVwYXJlQ2FsaWJy" +
           "YXRpb25TYW1wbGVUcmFuc2l0aW9uAQElIQAvAQAGCSUhAAACAAAAADMAAQH7IAA0AAEB+yAAAAAABGCA" +
           "CgEAAAABADwAAABQcmVwYXJlQ2FsaWJyYXRpb25TYW1wbGVUb0FuYWx5c2VDYWxpYnJhdGlvblNhbXBs" +
           "ZVRyYW5zaXRpb24BASchAC8BAAYJJyEAAAIAAAAAMwABAfsgADQAAQH9IAAAAAAEYIAKAQAAAAEAIgAA" +
           "AEFuYWx5c2VDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BASkhAC8BAAYJKSEAAAIAAAAAMwABAf0g" +
           "ADQAAQH9IAAAAAAEYIAKAQAAAAEAMgAAAEFuYWx5c2VDYWxpYnJhdGlvblNhbXBsZVRvUHVibGlzaFJl" +
           "c3VsdHNUcmFuc2l0aW9uAQErIQAvAQAGCSshAAACAAAAADMAAQH9IAA0AAEBFyEAAAAABGCACgEAAAAB" +
           "ADgAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvclZhbGlkYXRpb25UcmlnZ2VyVHJhbnNpdGlv" +
           "bgEBLSEALwEABgktIQAAAgAAAAAzAAEB9SAANAABAf8gAAAAAARggAoBAAAAAQA7AAAAV2FpdEZvclZh" +
           "bGlkYXRpb25UcmlnZ2VyVG9FeHRyYWN0VmFsaWRhdGlvblNhbXBsZVRyYW5zaXRpb24BAS8hAC8BAAYJ" +
           "LyEAAAIAAAAAMwABAf8gADQAAQEBIQAAAAAEYIAKAQAAAAEAIQAAAEV4dHJhY3RWYWxpZGF0aW9uU2Ft" +
           "cGxlVHJhbnNpdGlvbgEBMSEALwEABgkxIQAAAgAAAAAzAAEBASEANAABAQEhAAAAAARggAoBAAAAAQA6" +
           "AAAARXh0cmFjdFZhbGlkYXRpb25TYW1wbGVUb1ByZXBhcmVWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlv" +
           "bgEBMyEALwEABgkzIQAAAgAAAAAzAAEBASEANAABAQMhAAAAAARggAoBAAAAAQAhAAAAUHJlcGFyZVZh" +
           "bGlkYXRpb25TYW1wbGVUcmFuc2l0aW9uAQE1IQAvAQAGCTUhAAACAAAAADMAAQEDIQA0AAEBAyEAAAAA" +
           "BGCACgEAAAABADoAAABQcmVwYXJlVmFsaWRhdGlvblNhbXBsZVRvQW5hbHlzZVZhbGlkYXRpb25TYW1w" +
           "bGVUcmFuc2l0aW9uAQE3IQAvAQAGCTchAAACAAAAADMAAQEDIQA0AAEBBSEAAAAABGCACgEAAAABACEA" +
           "AABBbmFseXNlVmFsaWRhdGlvblNhbXBsZVRyYW5zaXRpb24BATkhAC8BAAYJOSEAAAIAAAAAMwABAQUh" +
           "ADQAAQEFIQAAAAAEYIAKAQAAAAEAMQAAAEFuYWx5c2VWYWxpZGF0aW9uU2FtcGxlVG9QdWJsaXNoUmVz" +
           "dWx0c1RyYW5zaXRpb24BATshAC8BAAYJOyEAAAIAAAAAMwABAQUhADQAAQEXIQAAAAAEYIAKAQAAAAEA" +
           "NAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yU2FtcGxlVHJpZ2dlclRyYW5zaXRpb24BAT0h" +
           "AC8BAAYJPSEAAAIAAAAAMwABAfUgADQAAQEHIQAAAAAEYIAKAQAAAAEALQAAAFdhaXRGb3JTYW1wbGVU" +
           "cmlnZ2VyVG9FeHRyYWN0U2FtcGxlVHJhbnNpdGlvbgEBPyEALwEABgk/IQAAAgAAAAAzAAEBByEANAAB" +
           "AQkhAAAAAARggAoBAAAAAQAXAAAARXh0cmFjdFNhbXBsZVRyYW5zaXRpb24BAUEhAC8BAAYJQSEAAAIA" +
           "AAAAMwABAQkhADQAAQEJIQAAAAAEYIAKAQAAAAEAJgAAAEV4dHJhY3RTYW1wbGVUb1ByZXBhcmVTYW1w" +
           "bGVUcmFuc2l0aW9uAQFDIQAvAQAGCUMhAAACAAAAADMAAQEJIQA0AAEBCyEAAAAABGCACgEAAAABABcA" +
           "AABQcmVwYXJlU2FtcGxlVHJhbnNpdGlvbgEBRSEALwEABglFIQAAAgAAAAAzAAEBCyEANAABAQshAAAA" +
           "AARggAoBAAAAAQAmAAAAUHJlcGFyZVNhbXBsZVRvQW5hbHlzZVNhbXBsZVRyYW5zaXRpb24BAUchAC8B" +
           "AAYJRyEAAAIAAAAAMwABAQshADQAAQENIQAAAAAEYIAKAQAAAAEAFwAAAEFuYWx5c2VTYW1wbGVUcmFu" +
           "c2l0aW9uAQFJIQAvAQAGCUkhAAACAAAAADMAAQENIQA0AAEBDSEAAAAABGCACgEAAAABACcAAABBbmFs" +
           "eXNlU2FtcGxlVG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BAUshAC8BAAYJSyEAAAIAAAAAMwABAQ0h" +
           "ADQAAQEXIQAAAAAEYIAKAQAAAAEAOAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yRGlhZ25v" +
           "c3RpY1RyaWdnZXJUcmFuc2l0aW9uAQFNIQAvAQAGCU0hAAACAAAAADMAAQH1IAA0AAEBDyEAAAAABGCA" +
           "CgEAAAABAC4AAABXYWl0Rm9yRGlhZ25vc3RpY1RyaWdnZXJUb0RpYWdub3N0aWNUcmFuc2l0aW9uAQFP" +
           "IQAvAQAGCU8hAAACAAAAADMAAQEPIQA0AAEBESEAAAAABGCACgEAAAABABQAAABEaWFnbm9zdGljVHJh" +
           "bnNpdGlvbgEBUSEALwEABglRIQAAAgAAAAAzAAEBESEANAABAREhAAAAAARggAoBAAAAAQAkAAAARGlh" +
           "Z25vc3RpY1RvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQFTIQAvAQAGCVMhAAACAAAAADMAAQERIQA0" +
           "AAEBFyEAAAAABGCACgEAAAABADYAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvckNsZWFuaW5n" +
           "VHJpZ2dlclRyYW5zaXRpb24BAVUhAC8BAAYJVSEAAAIAAAAAMwABAfUgADQAAQETIQAAAAAEYIAKAQAA" +
           "AAEAKgAAAFdhaXRGb3JDbGVhbmluZ1RyaWdnZXJUb0NsZWFuaW5nVHJhbnNpdGlvbgEBVyEALwEABglX" +
           "IQAAAgAAAAAzAAEBEyEANAABARUhAAAAAARggAoBAAAAAQASAAAAQ2xlYW5pbmdUcmFuc2l0aW9uAQFZ" +
           "IQAvAQAGCVkhAAACAAAAADMAAQEVIQA0AAEBFSEAAAAABGCACgEAAAABACIAAABDbGVhbmluZ1RvUHVi" +
           "bGlzaFJlc3VsdHNUcmFuc2l0aW9uAQFbIQAvAQAGCVshAAACAAAAADMAAQEVIQA0AAEBFyEAAAAABGCA" +
           "CgEAAAABAC8AAABQdWJsaXNoUmVzdWx0c1RvQ2xlYW51cFNhbXBsaW5nU3lzdGVtVHJhbnNpdGlvbgEB" +
           "XSEALwEABgldIQAAAgAAAAAzAAEBFyEANAABARshAAAAAARggAoBAAAAAQApAAAAUHVibGlzaFJlc3Vs" +
           "dHNUb0VqZWN0R3JhYlNhbXBsZVRyYW5zaXRpb24BAV8hAC8BAAYJXyEAAAIAAAAAMwABARchADQAAQEZ" +
           "IQAAAAAEYIAKAQAAAAEAGQAAAEVqZWN0R3JhYlNhbXBsZVRyYW5zaXRpb24BAWEhAC8BAAYJYSEAAAIA" +
           "AAAAMwABARkhADQAAQEZIQAAAAAEYIAKAQAAAAEAMAAAAEVqZWN0R3JhYlNhbXBsZVRvQ2xlYW51cFNh" +
           "bXBsaW5nU3lzdGVtVHJhbnNpdGlvbgEBYyEALwEABgljIQAAAgAAAAAzAAEBGSEANAABARshAAAAAARg" +
           "gAoBAAAAAQAfAAAAQ2xlYW51cFNhbXBsaW5nU3lzdGVtVHJhbnNpdGlvbgEBZSEALwEABgllIQAAAgAA" +
           "AAAzAAEBGyEANAABARshAAAAAARggAoBAAAAAQA1AAAAQ2xlYW51cFNhbXBsaW5nU3lzdGVtVG9TZWxl" +
           "Y3RFeGVjdXRpb25DeWNsZVRyYW5zaXRpb24BAWchAC8BAAYJZyEAAAIAAAAAMwABARshADQAAQH1IAAA" +
           "AAAkYIAKAQAAAAEACgAAAENvbXBsZXRpbmcBAWkhAwAAAABEAAAAVGhpcyBzdGF0ZSBpcyBhbiBhdXRv" +
           "bWF0aWMgb3IgY29tbWFuZGVkIGV4aXQgZnJvbSB0aGUgRXhlY3V0ZSBzdGF0ZS4ALwEAAwlpIQAABgAA" +
           "AAA0AQEBjSEAMwEBAY8hADQBAQGPIQAzAQEBkSEAMwEBAcEhADMBAQHbIQAAAAAkYIAKAQAAAAEACAAA" +
           "AENvbXBsZXRlAQFrIQMAAAAAZgAAAEF0IHRoaXMgcG9pbnQsIHRoZSBDb21wbGV0aW5nIHN0YXRlIGlz" +
           "IGRvbmUgYW5kIGl0IHRyYW5zaXRpb25zIGF1dG9tYXRpY2FsbHkgdG8gU3RvcHBlZCBzdGF0ZSB0byB3" +
           "YWl0LgAvAQADCWshAAAEAAAAADQBAQGRIQAzAQEBkyEAMwEBAcMhADMBAQHdIQAAAAAkYIAKAQAAAAEA" +
           "CgAAAFN1c3BlbmRpbmcBAW0hAwAAAABgAAAAVGhpcyBzdGF0ZSBpcyBhIHJlc3VsdCBvZiBhIGNoYW5n" +
           "ZSBpbiBtb25pdG9yZWQgY29uZGl0aW9ucyBkdWUgdG8gcHJvY2VzcyBjb25kaXRpb25zIG9yIGZhY3Rv" +
           "cnMuAC8BAAMJbSEAAAcAAAAANAEBAaMhADMBAQGlIQA0AQEBpSEAMwEBAachADQBAQGtIQAzAQEBxSEA" +
           "MwEBAd8hAAAAACRggAoBAAAAAQAJAAAAU3VzcGVuZGVkAQFvIQMAAAAApwAAAFRoZSBhbmFseXNlciBv" +
           "ciBjaGFubmVsIG1heSBiZSBydW5uaW5nIGJ1dCBubyByZXN1bHRzIGFyZSBiZWluZyBnZW5lcmF0ZWQg" +
           "d2hpbGUgdGhlIGFuYWx5c2VyIG9yIGNoYW5uZWwgaXMgd2FpdGluZyBmb3IgZXh0ZXJuYWwgcHJvY2Vz" +
           "cyBjb25kaXRpb25zIHRvIHJldHVybiB0byBub3JtYWwuAC8BAAMJbyEAAAQAAAAANAEBAachADMBAQGp" +
           "IQAzAQEBxyEAMwEBAeEhAAAAACRggAoBAAAAAQAMAAAAVW5zdXNwZW5kaW5nAQFxIQMAAAAAiAAAAFRo" +
           "aXMgc3RhdGUgaXMgYSByZXN1bHQgb2YgYSBkZXZpY2UgcmVxdWVzdCBmcm9tIFN1c3BlbmRlZCBzdGF0" +
           "ZSB0byB0cmFuc2l0aW9uIGJhY2sgdG8gdGhlIEV4ZWN1dGUgc3RhdGUgYnkgY2FsbGluZyB0aGUgVW5z" +
           "dXNwZW5kIE1ldGhvZC4ALwEAAwlxIQAABwAAAAA0AQEBqSEAMwEBAashADQBAQGrIQAzAQEBrSEAMwEB" +
           "Aa8hADMBAQHJIQAzAQEB4yEAAAAAJGCACgEAAAABAAcAAABIb2xkaW5nAQFzIQMAAAAAfAAAAEJyaW5n" +
           "cyB0aGUgYW5hbHlzZXIgb3IgY2hhbm5lbCB0byBhIGNvbnRyb2xsZWQgc3RvcCBvciB0byBhIHN0YXRl" +
           "IHdoaWNoIHJlcHJlc2VudHMgSGVsZCBmb3IgdGhlIHBhcnRpY3VsYXIgdW5pdCBjb250cm9sIG1vZGUA" +
           "LwEAAwlzIQAABwAAAAA0AQEBlSEAMwEBAZchADQBAQGXIQAzAQEBmSEANAEBAZ8hADMBAQHLIQAzAQEB" +
           "5SEAAAAAJGCACgEAAAABAAQAAABIZWxkAQF1IQMAAAAAawAAAFRoZSBIZWxkIHN0YXRlIGhvbGRzIHRo" +
           "ZSBhbmFseXNlciBvciBjaGFubmVsJ3Mgb3BlcmF0aW9uLiBBdCB0aGlzIHN0YXRlLCBubyBhY3F1aXNp" +
           "dGlvbiBjeWNsZSBpcyBwZXJmb3JtZWQuAC8BAAMJdSEAAAQAAAAANAEBAZkhADMBAQGbIQAzAQEBzSEA" +
           "MwEBAechAAAAACRggAoBAAAAAQAJAAAAVW5ob2xkaW5nAQF3IQMAAAAAVQAAAFRoZSBVbmhvbGRpbmcg" +
           "c3RhdGUgaXMgYSByZXNwb25zZSB0byBhbiBvcGVyYXRvciBjb21tYW5kIHRvIHJlc3VtZSB0aGUgRXhl" +
           "Y3V0ZSBzdGF0ZS4ALwEAAwl3IQAABwAAAAA0AQEBmyEAMwEBAZ0hADQBAQGdIQAzAQEBnyEAMwEBAaEh" +
           "ADMBAQHPIQAzAQEB6SEAAAAAJGCACgEAAAABAAgAAABTdG9wcGluZwEBeSEDAAAAACwAAABJbml0aWF0" +
           "ZWQgYnkgYSBTdG9wIE1ldGhvZCBjYWxsLCB0aGlzIHN0YXRlOgAvAQADCXkhAAAOAAAAADMBAQGxIQA0" +
           "AQEBuSEANAEBAbshADQBAQG9IQA0AQEBvyEANAEBAcEhADQBAQHDIQA0AQEBxSEANAEBAcchADQBAQHJ" +
           "IQA0AQEByyEANAEBAc0hADQBAQHPIQAzAQEB6yEAAAAAJGCACgEAAAABAAgAAABBYm9ydGluZwEBeyED" +
           "AAAAAHcAAABUaGUgQWJvcnRpbmcgc3RhdGUgY2FuIGJlIGVudGVyZWQgYXQgYW55IHRpbWUgaW4gcmVz" +
           "cG9uc2UgdG8gdGhlIEFib3J0IGNvbW1hbmQgb3Igb24gdGhlIG9jY3VycmVuY2Ugb2YgYSBtYWNoaW5l" +
           "IGZhdWx0LgAvAQADCXshAAAPAAAAADMBAQGzIQA0AQEB0SEANAEBAdMhADQBAQHVIQA0AQEB1yEANAEB" +
           "AdkhADQBAQHbIQA0AQEB3SEANAEBAd8hADQBAQHhIQA0AQEB4yEANAEBAeUhADQBAQHnIQA0AQEB6SEA" +
           "NAEBAeshAAAAACRggAoBAAAAAQAHAAAAQWJvcnRlZAEBfSEDAAAAAFAAAABUaGlzIHN0YXRlIG1haW50" +
           "YWlucyBtYWNoaW5lIHN0YXR1cyBpbmZvcm1hdGlvbiByZWxldmFudCB0byB0aGUgQWJvcnQgY29uZGl0" +
           "aW9uLgAvAQADCX0hAAACAAAAADQBAQGzIQAzAQEBtSEAAAAAJGCACgEAAAABAAgAAABDbGVhcmluZwEB" +
           "fyEDAAAAAHwAAABDbGVhcnMgZmF1bHRzIHRoYXQgbWF5IGhhdmUgb2NjdXJyZWQgd2hlbiBBYm9ydGlu" +
           "ZyBhbmQgYXJlIHByZXNlbnQgaW4gdGhlIEFib3J0ZWQgc3RhdGUgYmVmb3JlIHByb2NlZWRpbmcgdG8g" +
           "YSBTdG9wcGVkIHN0YXRlAC8BAAMJfyEAAAIAAAAANAEBAbUhADMBAQG3IQAAAAAEYIAKAQAAAAEAHAAA" +
           "AFN0b3BwZWRUb1Jlc2V0dGluZ1RyYW5zaXRpb24BAYEhAC8BAAYJgSEAAAQAAAAAMwABAeAgADQAAQHi" +
           "IAA1AAEBsx8ANQABAaAfAAAAAARggAoBAAAAAQATAAAAUmVzZXR0aW5nVHJhbnNpdGlvbgEBgyEALwEA" +
           "BgmDIQAAAgAAAAAzAAEB4iAANAABAeIgAAAAAARggAoBAAAAAQAZAAAAUmVzZXR0aW5nVG9JZGxlVHJh" +
           "bnNpdGlvbgEBhSEALwEABgmFIQAAAgAAAAAzAAEB4iAANAABAeQgAAAAAARggAoBAAAAAQAYAAAASWRs" +
           "ZVRvU3RhcnRpbmdUcmFuc2l0aW9uAQGHIQAvAQAGCYchAAAEAAAAADMAAQHkIAA0AAEB5iAANQABAbQf" +
           "ADUAAQGvHwAAAAAEYIAKAQAAAAEAEgAAAFN0YXJ0aW5nVHJhbnNpdGlvbgEBiSEALwEABgmJIQAAAgAA" +
           "AAAzAAEB5iAANAABAeYgAAAAAARggAoBAAAAAQAbAAAAU3RhcnRpbmdUb0V4ZWN1dGVUcmFuc2l0aW9u" +
           "AQGLIQAvAQAGCYshAAACAAAAADMAAQHmIAA0AAEB6CAAAAAABGCACgEAAAABAB0AAABFeGVjdXRlVG9D" +
           "b21wbGV0aW5nVHJhbnNpdGlvbgEBjSEALwEABgmNIQAAAgAAAAAzAAEB6CAANAABAWkhAAAAAARggAoB" +
           "AAAAAQAUAAAAQ29tcGxldGluZ1RyYW5zaXRpb24BAY8hAC8BAAYJjyEAAAIAAAAAMwABAWkhADQAAQFp" +
           "IQAAAAAEYIAKAQAAAAEAHgAAAENvbXBsZXRpbmdUb0NvbXBsZXRlVHJhbnNpdGlvbgEBkSEALwEABgmR" +
           "IQAAAgAAAAAzAAEBaSEANAABAWshAAAAAARggAoBAAAAAQAbAAAAQ29tcGxldGVUb1N0b3BwZWRUcmFu" +
           "c2l0aW9uAQGTIQAvAQAGCZMhAAACAAAAADMAAQFrIQA0AAEB4CAAAAAABGCACgEAAAABABoAAABFeGVj" +
           "dXRlVG9Ib2xkaW5nVHJhbnNpdGlvbgEBlSEALwEABgmVIQAAAwAAAAAzAAEB6CAANAABAXMhADUAAQG2" +
           "HwAAAAAEYIAKAQAAAAEAEQAAAEhvbGRpbmdUcmFuc2l0aW9uAQGXIQAvAQAGCZchAAACAAAAADMAAQFz" +
           "IQA0AAEBcyEAAAAABGCACgEAAAABABcAAABIb2xkaW5nVG9IZWxkVHJhbnNpdGlvbgEBmSEALwEABgmZ" +
           "IQAAAgAAAAAzAAEBcyEANAABAXUhAAAAAARggAoBAAAAAQAZAAAASGVsZFRvVW5ob2xkaW5nVHJhbnNp" +
           "dGlvbgEBmyEALwEABgmbIQAAAwAAAAAzAAEBdSEANAABAXchADUAAQG3HwAAAAAEYIAKAQAAAAEAEwAA" +
           "AFVuaG9sZGluZ1RyYW5zaXRpb24BAZ0hAC8BAAYJnSEAAAIAAAAAMwABAXchADQAAQF3IQAAAAAEYIAK" +
           "AQAAAAEAHAAAAFVuaG9sZGluZ1RvSG9sZGluZ1RyYW5zaXRpb24BAZ8hAC8BAAYJnyEAAAMAAAAAMwAB" +
           "AXchADQAAQFzIQA1AAEBth8AAAAABGCACgEAAAABABwAAABVbmhvbGRpbmdUb0V4ZWN1dGVUcmFuc2l0" +
           "aW9uAQGhIQAvAQAGCaEhAAACAAAAADMAAQF3IQA0AAEB6CAAAAAABGCACgEAAAABAB0AAABFeGVjdXRl" +
           "VG9TdXNwZW5kaW5nVHJhbnNpdGlvbgEBoyEALwEABgmjIQAAAwAAAAAzAAEB6CAANAABAW0hADUAAQG4" +
           "HwAAAAAEYIAKAQAAAAEAFAAAAFN1c3BlbmRpbmdUcmFuc2l0aW9uAQGlIQAvAQAGCaUhAAACAAAAADMA" +
           "AQFtIQA0AAEBbSEAAAAABGCACgEAAAABAB8AAABTdXNwZW5kaW5nVG9TdXNwZW5kZWRUcmFuc2l0aW9u" +
           "AQGnIQAvAQAGCachAAACAAAAADMAAQFtIQA0AAEBbyEAAAAABGCACgEAAAABACEAAABTdXNwZW5kZWRU" +
           "b1Vuc3VzcGVuZGluZ1RyYW5zaXRpb24BAakhAC8BAAYJqSEAAAMAAAAAMwABAW8hADQAAQFxIQA1AAEB" +
           "uR8AAAAABGCACgEAAAABABYAAABVbnN1c3BlbmRpbmdUcmFuc2l0aW9uAQGrIQAvAQAGCashAAACAAAA" +
           "ADMAAQFxIQA0AAEBcSEAAAAABGCACgEAAAABACIAAABVbnN1c3BlbmRpbmdUb1N1c3BlbmRpbmdUcmFu" +
           "c2l0aW9uAQGtIQAvAQAGCa0hAAADAAAAADMAAQFxIQA0AAEBbSEANQABAbgfAAAAAARggAoBAAAAAQAf" +
           "AAAAVW5zdXNwZW5kaW5nVG9FeGVjdXRlVHJhbnNpdGlvbgEBryEALwEABgmvIQAAAgAAAAAzAAEBcSEA" +
           "NAABAeggAAAAAARggAoBAAAAAQAbAAAAU3RvcHBpbmdUb1N0b3BwZWRUcmFuc2l0aW9uAQGxIQAvAQAG" +
           "CbEhAAACAAAAADMAAQF5IQA0AAEB4CAAAAAABGCACgEAAAABABsAAABBYm9ydGluZ1RvQWJvcnRlZFRy" +
           "YW5zaXRpb24BAbMhAC8BAAYJsyEAAAIAAAAAMwABAXshADQAAQF9IQAAAAAEYIAKAQAAAAEAGwAAAEFi" +
           "b3J0ZWRUb0NsZWFyaW5nVHJhbnNpdGlvbgEBtSEALwEABgm1IQAAAwAAAAAzAAEBfSEANAABAX8hADUA" +
           "AQG7HwAAAAAEYIAKAQAAAAEAGwAAAENsZWFyaW5nVG9TdG9wcGVkVHJhbnNpdGlvbgEBtyEALwEABgm3" +
           "IQAAAgAAAAAzAAEBfyEANAABAeAgAAAAAARggAoBAAAAAQAdAAAAUmVzZXR0aW5nVG9TdG9wcGluZ1Ry" +
           "YW5zaXRpb24BAbkhAC8BAAYJuSEAAAMAAAAAMwABAeIgADQAAQF5IQA1AAEBtR8AAAAABGCACgEAAAAB" +
           "ABgAAABJZGxlVG9TdG9wcGluZ1RyYW5zaXRpb24BAbshAC8BAAYJuyEAAAMAAAAAMwABAeQgADQAAQF5" +
           "IQA1AAEBtR8AAAAABGCACgEAAAABABwAAABTdGFydGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9uAQG9IQAv" +
           "AQAGCb0hAAADAAAAADMAAQHmIAA0AAEBeSEANQABAbUfAAAAAARggAoBAAAAAQAbAAAARXhlY3V0ZVRv" +
           "U3RvcHBpbmdUcmFuc2l0aW9uAQG/IQAvAQAGCb8hAAADAAAAADMAAQHoIAA0AAEBeSEANQABAbUfAAAA" +
           "AARggAoBAAAAAQAeAAAAQ29tcGxldGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9uAQHBIQAvAQAGCcEhAAAD" +
           "AAAAADMAAQFpIQA0AAEBeSEANQABAbUfAAAAAARggAoBAAAAAQAcAAAAQ29tcGxldGVUb1N0b3BwaW5n" +
           "VHJhbnNpdGlvbgEBwyEALwEABgnDIQAAAwAAAAAzAAEBayEANAABAXkhADUAAQG1HwAAAAAEYIAKAQAA" +
           "AAEAHgAAAFN1c3BlbmRpbmdUb1N0b3BwaW5nVHJhbnNpdGlvbgEBxSEALwEABgnFIQAAAwAAAAAzAAEB" +
           "bSEANAABAXkhADUAAQG1HwAAAAAEYIAKAQAAAAEAHQAAAFN1c3BlbmRlZFRvU3RvcHBpbmdUcmFuc2l0" +
           "aW9uAQHHIQAvAQAGCcchAAADAAAAADMAAQFvIQA0AAEBeSEANQABAbUfAAAAAARggAoBAAAAAQAgAAAA" +
           "VW5zdXNwZW5kaW5nVG9TdG9wcGluZ1RyYW5zaXRpb24BAckhAC8BAAYJySEAAAMAAAAAMwABAXEhADQA" +
           "AQF5IQA1AAEBtR8AAAAABGCACgEAAAABABsAAABIb2xkaW5nVG9TdG9wcGluZ1RyYW5zaXRpb24BAcsh" +
           "AC8BAAYJyyEAAAMAAAAAMwABAXMhADQAAQF5IQA1AAEBtR8AAAAABGCACgEAAAABABgAAABIZWxkVG9T" +
           "dG9wcGluZ1RyYW5zaXRpb24BAc0hAC8BAAYJzSEAAAMAAAAAMwABAXUhADQAAQF5IQA1AAEBtR8AAAAA" +
           "BGCACgEAAAABAB0AAABVbmhvbGRpbmdUb1N0b3BwaW5nVHJhbnNpdGlvbgEBzyEALwEABgnPIQAAAwAA" +
           "AAAzAAEBdyEANAABAXkhADUAAQG1HwAAAAAEYIAKAQAAAAEAGwAAAFN0b3BwZWRUb0Fib3J0aW5nVHJh" +
           "bnNpdGlvbgEB0SEALwEABgnRIQAAAwAAAAAzAAEB4CAANAABAXshADUAAQG6HwAAAAAEYIAKAQAAAAEA" +
           "HQAAAFJlc2V0dGluZ1RvQWJvcnRpbmdUcmFuc2l0aW9uAQHTIQAvAQAGCdMhAAADAAAAADMAAQHiIAA0" +
           "AAEBeyEANQABAbofAAAAAARggAoBAAAAAQAYAAAASWRsZVRvQWJvcnRpbmdUcmFuc2l0aW9uAQHVIQAv" +
           "AQAGCdUhAAADAAAAADMAAQHkIAA0AAEBeyEANQABAbofAAAAAARggAoBAAAAAQAcAAAAU3RhcnRpbmdU" +
           "b0Fib3J0aW5nVHJhbnNpdGlvbgEB1yEALwEABgnXIQAAAwAAAAAzAAEB5iAANAABAXshADUAAQG6HwAA" +
           "AAAEYIAKAQAAAAEAGwAAAEV4ZWN1dGVUb0Fib3J0aW5nVHJhbnNpdGlvbgEB2SEALwEABgnZIQAAAwAA" +
           "AAAzAAEB6CAANAABAXshADUAAQG6HwAAAAAEYIAKAQAAAAEAHgAAAENvbXBsZXRpbmdUb0Fib3J0aW5n" +
           "VHJhbnNpdGlvbgEB2yEALwEABgnbIQAAAwAAAAAzAAEBaSEANAABAXshADUAAQG6HwAAAAAEYIAKAQAA" +
           "AAEAHAAAAENvbXBsZXRlVG9BYm9ydGluZ1RyYW5zaXRpb24BAd0hAC8BAAYJ3SEAAAMAAAAAMwABAWsh" +
           "ADQAAQF7IQA1AAEBuh8AAAAABGCACgEAAAABAB4AAABTdXNwZW5kaW5nVG9BYm9ydGluZ1RyYW5zaXRp" +
           "b24BAd8hAC8BAAYJ3yEAAAMAAAAAMwABAW0hADQAAQF7IQA1AAEBuh8AAAAABGCACgEAAAABAB0AAABT" +
           "dXNwZW5kZWRUb0Fib3J0aW5nVHJhbnNpdGlvbgEB4SEALwEABgnhIQAAAwAAAAAzAAEBbyEANAABAXsh" +
           "ADUAAQG6HwAAAAAEYIAKAQAAAAEAIAAAAFVuc3VzcGVuZGluZ1RvQWJvcnRpbmdUcmFuc2l0aW9uAQHj" +
           "IQAvAQAGCeMhAAADAAAAADMAAQFxIQA0AAEBeyEANQABAbofAAAAAARggAoBAAAAAQAbAAAASG9sZGlu" +
           "Z1RvQWJvcnRpbmdUcmFuc2l0aW9uAQHlIQAvAQAGCeUhAAADAAAAADMAAQFzIQA0AAEBeyEANQABAbof" +
           "AAAAAARggAoBAAAAAQAYAAAASGVsZFRvQWJvcnRpbmdUcmFuc2l0aW9uAQHnIQAvAQAGCechAAADAAAA" +
           "ADMAAQF1IQA0AAEBeyEANQABAbofAAAAAARggAoBAAAAAQAdAAAAVW5ob2xkaW5nVG9BYm9ydGluZ1Ry" +
           "YW5zaXRpb24BAekhAC8BAAYJ6SEAAAMAAAAAMwABAXchADQAAQF7IQA1AAEBuh8AAAAABGCACgEAAAAB" +
           "ABwAAABTdG9wcGluZ1RvQWJvcnRpbmdUcmFuc2l0aW9uAQHrIQAvAQAGCeshAAADAAAAADMAAQF5IQA0" +
           "AAEBeyEANQABAbofAAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the OperatingSubStateMachine Object.
        /// </summary>
        public AnalyserChannel_OperatingModeSubStateMachineState OperatingSubStateMachine
        {
            get
            { 
                return m_operatingSubStateMachine;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingSubStateMachine, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingSubStateMachine = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_operatingSubStateMachine != null)
            {
                children.Add(m_operatingSubStateMachine);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.OperatingSubStateMachine:
                {
                    if (createOrReplace)
                    {
                        if (OperatingSubStateMachine == null)
                        {
                            if (replacement == null)
                            {
                                OperatingSubStateMachine = new AnalyserChannel_OperatingModeSubStateMachineState(this);
                            }
                            else
                            {
                                OperatingSubStateMachine = (AnalyserChannel_OperatingModeSubStateMachineState)replacement;
                            }
                        }
                    }

                    instance = OperatingSubStateMachine;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalyserChannel_OperatingModeSubStateMachineState m_operatingSubStateMachine;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannelLocalStateState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelLocalStateState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelLocalStateType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelLocalStateState : StateMachineStateState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelLocalStateState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannelLocalStateType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQAlAAAAQW5hbHlzZXJDaGFubmVsTG9jYWxTdGF0ZVR5" +
           "cGVJbnN0YW5jZQEB7QMBAe0D/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannelMaintenanceStateState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelMaintenanceStateState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelMaintenanceStateType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelMaintenanceStateState : StateMachineStateState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelMaintenanceStateState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannelMaintenanceStateType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQArAAAAQW5hbHlzZXJDaGFubmVsTWFpbnRlbmFuY2VT" +
           "dGF0ZVR5cGVJbnN0YW5jZQEB7gMBAe4D/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannelStateMachineState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelStateMachineState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannelStateMachineType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAnAAAAQW5hbHlzZXJDaGFubmVsU3RhdGVNYWNoaW5l" +
           "VHlwZUluc3RhbmNlAQHvAwEB7wMBAgAAAAAvAAEBsR8ALwABAbIfDwAAABVgiQoCAAAAAAAMAAAAQ3Vy" +
           "cmVudFN0YXRlAQEHGAAvAQDICgcYAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEBCBgA" +
           "LgBECBgAAAAR/////wEB/////wAAAAAkYIAKAQAAAAEACQAAAFNsYXZlTW9kZQEBwhMDAAAAAFwAAABU" +
           "aGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gTG9jYWwgb3IgTWFpbnRlbmFuY2UgbW9kZSBhbmQgYWxsIEFu" +
           "YWx5c2VyQ2hhbm5lbHMgYXJlIGluIFNsYXZlTW9kZQAvAQAFCcITAAAEAAAAADMBAQHHEwA0AQEBzhMA" +
           "NAEBAc8TADQBAQHQEwEAAAAVYKkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQERGAAuAEQRGAAABwAAAAAA" +
           "B/////8BAf////8AAAAApGCACgEAAAABAAkAAABPcGVyYXRpbmcBAcMTAwAAAAAtAAAAVGhlIEFuYWx5" +
           "c2VyQ2hhbm5lbCBpcyBpbiB0aGUgT3BlcmF0aW5nIG1vZGUuAC8BAewDwxMAAAEGAAAAADQBAQHHEwAz" +
           "AQEByBMAMwEBAckTADQBAQHKEwA0AQEBzBMAMwEBAc4TAgAAABVgqQoCAAAAAAALAAAAU3RhdGVOdW1i" +
           "ZXIBARIYAC4ARBIYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAGAAAAE9wZXJhdGluZ1N1" +
           "YlN0YXRlTWFjaGluZQEBxBMALwEB8APEEwAACgAAAAAvAAEBsx8ALwABAbQfAC8AAQGvHwAvAAEBtR8A" +
           "LwABAbYfAC8AAQG3HwAvAAEBuB8ALwABAbkfAC8AAQG6HwAvAAEBux9IAAAAFWCJCgIAAAAAAAwAAABD" +
           "dXJyZW50U3RhdGUBAe0hAC8BAMgK7SEAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQHu" +
           "IQAuAETuIQAAABH/////AQH/////AAAAACRggAoBAAAAAQAHAAAAU3RvcHBlZAEB9yEDAAAAAEgAAABU" +
           "aGlzIGlzIHRoZSBpbml0aWFsIHN0YXRlIGFmdGVyIEFuYWx5c2VyRGV2aWNlU3RhdGVNYWNoaW5lIHN0" +
           "YXRlIFBvd2VydXAALwEABQn3IQAABQAAAAAzAQEBmCIANAEBAaoiADQBAQHIIgA0AQEBziIAMwEBAegi" +
           "AAAAACRggAoBAAAAAQAJAAAAUmVzZXR0aW5nAQH5IQMAAAAAWwAAAFRoaXMgc3RhdGUgaXMgdGhlIHJl" +
           "c3VsdCBvZiBhIFJlc2V0IG9yIFNldENvbmZpZ3VyYXRpb24gTWV0aG9kIGNhbGwgZnJvbSB0aGUgU3Rv" +
           "cHBlZCBzdGF0ZS4ALwEAAwn5IQAABgAAAAA0AQEBmCIAMwEBAZoiADQBAQGaIgAzAQEBnCIAMwEBAdAi" +
           "ADMBAQHqIgAAAAAkYIAKAQAAAAEABAAAAElkbGUBAfshAwAAAABjAAAAVGhlIFJlc2V0dGluZyBzdGF0" +
           "ZSBpcyBjb21wbGV0ZWQsIGFsbCBwYXJhbWV0ZXJzIGhhdmUgYmVlbiBjb21taXR0ZWQgYW5kIHJlYWR5" +
           "IHRvIHN0YXJ0IGFjcXVpc2l0aW9uAC8BAAMJ+yEAAAQAAAAANAEBAZwiADMBAQGeIgAzAQEB0iIAMwEB" +
           "AewiAAAAACRggAoBAAAAAQAIAAAAU3RhcnRpbmcBAf0hAwAAAAB4AAAAVGhlIGFuYWx5c2VyIGhhcyBy" +
           "ZWNlaXZlZCB0aGUgU3RhcnQgb3IgU2luZ2xlQWNxdWlzaXRpb25TdGFydCBNZXRob2QgY2FsbCBhbmQg" +
           "aXQgaXMgcHJlcGFyaW5nIHRvIGVudGVyIGluIEV4ZWN1dGUgc3RhdGUuAC8BAAMJ/SEAAAYAAAAANAEB" +
           "AZ4iADMBAQGgIgA0AQEBoCIAMwEBAaIiADMBAQHUIgAzAQEB7iIAAAAAJGCACgEAAAABAAcAAABFeGVj" +
           "dXRlAQH/IQMAAAAAOQAAAEFsbCByZXBldGl0aXZlIGFjcXVpc2l0aW9uIGN5Y2xlcyBhcmUgZG9uZSBp" +
           "biB0aGlzIHN0YXRlOgAvAQEEI/8hAAAIAAAAADQBAQGiIgAzAQEBpCIAMwEBAawiADQBAQG4IgAzAQEB" +
           "uiIANAEBAcYiADMBAQHWIgAzAQEB8CIBAAAABGCACgEAAAABAB8AAABPcGVyYXRpbmdFeGVjdXRlU3Vi" +
           "U3RhdGVNYWNoaW5lAQEBIgAvAQHxAwEiAAD/////OwAAABVgiQoCAAAAAAAMAAAAQ3VycmVudFN0YXRl" +
           "AQECIgAvAQDICgIiAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEBAyIALgBEAyIAAAAR" +
           "/////wEB/////wAAAAAkYIAKAQAAAAEAFAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlAQEMIgMAAAAASAAA" +
           "AFRoaXMgcHNldWRvLXN0YXRlIGlzIHVzZWQgdG8gZGVjaWRlIHdoaWNoIGV4ZWN1dGlvbiBwYXRoIHNo" +
           "YWxsIGJlIHRha2VuLgAvAQAFCQwiAAAGAAAAADMBAQE0IgAzAQEBRCIAMwEBAVQiADMBAQFkIgAzAQEB" +
           "bCIANAEBAX4iAAAAACRggAoBAAAAAQAZAAAAV2FpdEZvckNhbGlicmF0aW9uVHJpZ2dlcgEBDiIDAAAA" +
           "AFUAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRvIHBlcmZvcm0gdGhl" +
           "IENhbGlicmF0aW9uIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJDiIAAAIAAAAANAEBATQiADMBAQE2IgAA" +
           "AAAkYIAKAQAAAAEAGAAAAEV4dHJhY3RDYWxpYnJhdGlvblNhbXBsZQEBECIDAAAAAFsAAABDb2xsZWN0" +
           "IC8gc2V0dXAgdGhlIHNhbXBsaW5nIHN5c3RlbSB0byBwZXJmb3JtIHRoZSBhY3F1aXNpdGlvbiBjeWNs" +
           "ZSBvZiBhIENhbGlicmF0aW9uIGN5Y2xlAC8BAAMJECIAAAQAAAAANAEBATYiADMBAQE4IgA0AQEBOCIA" +
           "MwEBAToiAAAAACRggAoBAAAAAQAYAAAAUHJlcGFyZUNhbGlicmF0aW9uU2FtcGxlAQESIgMAAAAARQAA" +
           "AFByZXBhcmUgdGhlIENhbGlicmF0aW9uIHNhbXBsZSBmb3IgdGhlIEFuYWx5c2VDYWxpYnJhdGlvblNh" +
           "bXBsZSBzdGF0ZQAvAQADCRIiAAAEAAAAADQBAQE6IgAzAQEBPCIANAEBATwiADMBAQE+IgAAAAAkYIAK" +
           "AQAAAAEAGAAAAEFuYWx5c2VDYWxpYnJhdGlvblNhbXBsZQEBFCIDAAAAAC4AAABQZXJmb3JtIHRoZSBh" +
           "bmFseXNpcyBvZiB0aGUgQ2FsaWJyYXRpb24gU2FtcGxlAC8BAAMJFCIAAAQAAAAANAEBAT4iADMBAQFA" +
           "IgA0AQEBQCIAMwEBAUIiAAAAACRggAoBAAAAAQAYAAAAV2FpdEZvclZhbGlkYXRpb25UcmlnZ2VyAQEW" +
           "IgMAAAAAVAAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9y" +
           "bSB0aGUgVmFsaWRhdGlvbiBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCRYiAAACAAAAADQBAQFEIgAzAQEB" +
           "RiIAAAAAJGCACgEAAAABABcAAABFeHRyYWN0VmFsaWRhdGlvblNhbXBsZQEBGCIDAAAAAFoAAABDb2xs" +
           "ZWN0IC8gc2V0dXAgdGhlIHNhbXBsaW5nIHN5c3RlbSB0byBwZXJmb3JtIHRoZSBhY3F1aXNpdGlvbiBj" +
           "eWNsZSBvZiBhIFZhbGlkYXRpb24gY3ljbGUALwEAAwkYIgAABAAAAAA0AQEBRiIAMwEBAUgiADQBAQFI" +
           "IgAzAQEBSiIAAAAAJGCACgEAAAABABcAAABQcmVwYXJlVmFsaWRhdGlvblNhbXBsZQEBGiIDAAAAAEMA" +
           "AABQcmVwYXJlIHRoZSBWYWxpZGF0aW9uIHNhbXBsZSBmb3IgdGhlIEFuYWx5c2VWYWxpZGF0aW9uU2Ft" +
           "cGxlIHN0YXRlAC8BAAMJGiIAAAQAAAAANAEBAUoiADMBAQFMIgA0AQEBTCIAMwEBAU4iAAAAACRggAoB" +
           "AAAAAQAXAAAAQW5hbHlzZVZhbGlkYXRpb25TYW1wbGUBARwiAwAAAAAtAAAAUGVyZm9ybSB0aGUgYW5h" +
           "bHlzaXMgb2YgdGhlIFZhbGlkYXRpb24gU2FtcGxlAC8BAAMJHCIAAAQAAAAANAEBAU4iADMBAQFQIgA0" +
           "AQEBUCIAMwEBAVIiAAAAACRggAoBAAAAAQAUAAAAV2FpdEZvclNhbXBsZVRyaWdnZXIBAR4iAwAAAABQ" +
           "AAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFkeSB0byBwZXJmb3JtIHRoZSBT" +
           "YW1wbGUgYWNxdWlzaXRpb24gY3ljbGUALwEAAwkeIgAAAgAAAAA0AQEBVCIAMwEBAVYiAAAAACRggAoB" +
           "AAAAAQANAAAARXh0cmFjdFNhbXBsZQEBICIDAAAAACMAAABDb2xsZWN0IHRoZSBTYW1wbGUgZnJvbSB0" +
           "aGUgcHJvY2VzcwAvAQADCSAiAAAEAAAAADQBAQFWIgAzAQEBWCIANAEBAVgiADMBAQFaIgAAAAAkYIAK" +
           "AQAAAAEADQAAAFByZXBhcmVTYW1wbGUBASIiAwAAAAAuAAAAUHJlcGFyZSB0aGUgU2FtcGxlIGZvciB0" +
           "aGUgQW5hbHlzZVNhbXBsZSBzdGF0ZQAvAQADCSIiAAAEAAAAADQBAQFaIgAzAQEBXCIANAEBAVwiADMB" +
           "AQFeIgAAAAAkYIAKAQAAAAEADQAAAEFuYWx5c2VTYW1wbGUBASQiAwAAAAAiAAAAUGVyZm9ybSB0aGUg" +
           "YW5hbHlzaXMgb2YgdGhlIFNhbXBsZQAvAQADCSQiAAAEAAAAADQBAQFeIgAzAQEBYCIANAEBAWAiADMB" +
           "AQFiIgAAAAAkYIAKAQAAAAEAGAAAAFdhaXRGb3JEaWFnbm9zdGljVHJpZ2dlcgEBJiIDAAAAAEkAAABX" +
           "YWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRvIHBlcmZvcm0gdGhlIGRpYWdu" +
           "b3N0aWMgY3ljbGUsAC8BAAMJJiIAAAIAAAAANAEBAWQiADMBAQFmIgAAAAAkYIAKAQAAAAEACgAAAERp" +
           "YWdub3N0aWMBASgiAwAAAAAdAAAAUGVyZm9ybSB0aGUgZGlhZ25vc3RpYyBjeWNsZS4ALwEAAwkoIgAA" +
           "BAAAAAA0AQEBZiIAMwEBAWgiADQBAQFoIgAzAQEBaiIAAAAAJGCACgEAAAABABYAAABXYWl0Rm9yQ2xl" +
           "YW5pbmdUcmlnZ2VyAQEqIgMAAAAARwAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMg" +
           "cmVhZHkgdG8gcGVyZm9ybSB0aGUgY2xlYW5pbmcgY3ljbGUsAC8BAAMJKiIAAAIAAAAANAEBAWwiADMB" +
           "AQFuIgAAAAAkYIAKAQAAAAEACAAAAENsZWFuaW5nAQEsIgMAAAAAGwAAAFBlcmZvcm0gdGhlIGNsZWFu" +
           "aW5nIGN5Y2xlLgAvAQADCSwiAAAEAAAAADQBAQFuIgAzAQEBcCIANAEBAXAiADMBAQFyIgAAAAAkYIAK" +
           "AQAAAAEADgAAAFB1Ymxpc2hSZXN1bHRzAQEuIgMAAAAANQAAAFB1Ymxpc2ggdGhlIHJlc3VsdHMgb2Yg" +
           "dGhlIHByZXZpb3VzIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJLiIAAAcAAAAANAEBAUIiADQBAQFSIgA0" +
           "AQEBYiIANAEBAWoiADQBAQFyIgAzAQEBdCIAMwEBAXYiAAAAACRggAoBAAAAAQAPAAAARWplY3RHcmFi" +
           "U2FtcGxlAQEwIgMAAAAAbwAAAFRoZSBTYW1wbGUgdGhhdCB3YXMganVzdCBhbmFseXNlZCBpcyBlamVj" +
           "dGVkIGZyb20gdGhlIHN5c3RlbSB0byBhbGxvdyB0aGUgb3BlcmF0b3Igb3IgYW5vdGhlciBzeXN0ZW0g" +
           "dG8gZ3JhYiBpdAAvAQADCTAiAAAEAAAAADQBAQF2IgAzAQEBeCIANAEBAXgiADMBAQF6IgAAAAAkYIAK" +
           "AQAAAAEAFQAAAENsZWFudXBTYW1wbGluZ1N5c3RlbQEBMiIDAAAAAEQAAABDbGVhbnVwIHRoZSBzYW1w" +
           "bGluZyBzdWItc3lzdGVtIHRvIGJlIHJlYWR5IGZvciB0aGUgbmV4dCBhY3F1aXNpdGlvbgAvAQADCTIi" +
           "AAAFAAAAADQBAQF0IgA0AQEBeiIAMwEBAXwiADQBAQF8IgAzAQEBfiIAAAAABGCACgEAAAABADkAAABT" +
           "ZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvckNhbGlicmF0aW9uVHJpZ2dlclRyYW5zaXRpb24BATQi" +
           "AC8BAAYJNCIAAAIAAAAAMwABAQwiADQAAQEOIgAAAAAEYIAKAQAAAAEAPQAAAFdhaXRGb3JDYWxpYnJh" +
           "dGlvblRyaWdnZXJUb0V4dHJhY3RDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BATYiAC8BAAYJNiIA" +
           "AAIAAAAAMwABAQ4iADQAAQEQIgAAAAAEYIAKAQAAAAEAIgAAAEV4dHJhY3RDYWxpYnJhdGlvblNhbXBs" +
           "ZVRyYW5zaXRpb24BATgiAC8BAAYJOCIAAAIAAAAAMwABARAiADQAAQEQIgAAAAAEYIAKAQAAAAEAPAAA" +
           "AEV4dHJhY3RDYWxpYnJhdGlvblNhbXBsZVRvUHJlcGFyZUNhbGlicmF0aW9uU2FtcGxlVHJhbnNpdGlv" +
           "bgEBOiIALwEABgk6IgAAAgAAAAAzAAEBECIANAABARIiAAAAAARggAoBAAAAAQAiAAAAUHJlcGFyZUNh" +
           "bGlicmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBPCIALwEABgk8IgAAAgAAAAAzAAEBEiIANAABARIiAAAA" +
           "AARggAoBAAAAAQA8AAAAUHJlcGFyZUNhbGlicmF0aW9uU2FtcGxlVG9BbmFseXNlQ2FsaWJyYXRpb25T" +
           "YW1wbGVUcmFuc2l0aW9uAQE+IgAvAQAGCT4iAAACAAAAADMAAQESIgA0AAEBFCIAAAAABGCACgEAAAAB" +
           "ACIAAABBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGVUcmFuc2l0aW9uAQFAIgAvAQAGCUAiAAACAAAAADMA" +
           "AQEUIgA0AAEBFCIAAAAABGCACgEAAAABADIAAABBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGVUb1B1Ymxp" +
           "c2hSZXN1bHRzVHJhbnNpdGlvbgEBQiIALwEABglCIgAAAgAAAAAzAAEBFCIANAABAS4iAAAAAARggAoB" +
           "AAAAAQA4AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JWYWxpZGF0aW9uVHJpZ2dlclRyYW5z" +
           "aXRpb24BAUQiAC8BAAYJRCIAAAIAAAAAMwABAQwiADQAAQEWIgAAAAAEYIAKAQAAAAEAOwAAAFdhaXRG" +
           "b3JWYWxpZGF0aW9uVHJpZ2dlclRvRXh0cmFjdFZhbGlkYXRpb25TYW1wbGVUcmFuc2l0aW9uAQFGIgAv" +
           "AQAGCUYiAAACAAAAADMAAQEWIgA0AAEBGCIAAAAABGCACgEAAAABACEAAABFeHRyYWN0VmFsaWRhdGlv" +
           "blNhbXBsZVRyYW5zaXRpb24BAUgiAC8BAAYJSCIAAAIAAAAAMwABARgiADQAAQEYIgAAAAAEYIAKAQAA" +
           "AAEAOgAAAEV4dHJhY3RWYWxpZGF0aW9uU2FtcGxlVG9QcmVwYXJlVmFsaWRhdGlvblNhbXBsZVRyYW5z" +
           "aXRpb24BAUoiAC8BAAYJSiIAAAIAAAAAMwABARgiADQAAQEaIgAAAAAEYIAKAQAAAAEAIQAAAFByZXBh" +
           "cmVWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBTCIALwEABglMIgAAAgAAAAAzAAEBGiIANAABARoi" +
           "AAAAAARggAoBAAAAAQA6AAAAUHJlcGFyZVZhbGlkYXRpb25TYW1wbGVUb0FuYWx5c2VWYWxpZGF0aW9u" +
           "U2FtcGxlVHJhbnNpdGlvbgEBTiIALwEABglOIgAAAgAAAAAzAAEBGiIANAABARwiAAAAAARggAoBAAAA" +
           "AQAhAAAAQW5hbHlzZVZhbGlkYXRpb25TYW1wbGVUcmFuc2l0aW9uAQFQIgAvAQAGCVAiAAACAAAAADMA" +
           "AQEcIgA0AAEBHCIAAAAABGCACgEAAAABADEAAABBbmFseXNlVmFsaWRhdGlvblNhbXBsZVRvUHVibGlz" +
           "aFJlc3VsdHNUcmFuc2l0aW9uAQFSIgAvAQAGCVIiAAACAAAAADMAAQEcIgA0AAEBLiIAAAAABGCACgEA" +
           "AAABADQAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvclNhbXBsZVRyaWdnZXJUcmFuc2l0aW9u" +
           "AQFUIgAvAQAGCVQiAAACAAAAADMAAQEMIgA0AAEBHiIAAAAABGCACgEAAAABAC0AAABXYWl0Rm9yU2Ft" +
           "cGxlVHJpZ2dlclRvRXh0cmFjdFNhbXBsZVRyYW5zaXRpb24BAVYiAC8BAAYJViIAAAIAAAAAMwABAR4i" +
           "ADQAAQEgIgAAAAAEYIAKAQAAAAEAFwAAAEV4dHJhY3RTYW1wbGVUcmFuc2l0aW9uAQFYIgAvAQAGCVgi" +
           "AAACAAAAADMAAQEgIgA0AAEBICIAAAAABGCACgEAAAABACYAAABFeHRyYWN0U2FtcGxlVG9QcmVwYXJl" +
           "U2FtcGxlVHJhbnNpdGlvbgEBWiIALwEABglaIgAAAgAAAAAzAAEBICIANAABASIiAAAAAARggAoBAAAA" +
           "AQAXAAAAUHJlcGFyZVNhbXBsZVRyYW5zaXRpb24BAVwiAC8BAAYJXCIAAAIAAAAAMwABASIiADQAAQEi" +
           "IgAAAAAEYIAKAQAAAAEAJgAAAFByZXBhcmVTYW1wbGVUb0FuYWx5c2VTYW1wbGVUcmFuc2l0aW9uAQFe" +
           "IgAvAQAGCV4iAAACAAAAADMAAQEiIgA0AAEBJCIAAAAABGCACgEAAAABABcAAABBbmFseXNlU2FtcGxl" +
           "VHJhbnNpdGlvbgEBYCIALwEABglgIgAAAgAAAAAzAAEBJCIANAABASQiAAAAAARggAoBAAAAAQAnAAAA" +
           "QW5hbHlzZVNhbXBsZVRvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQFiIgAvAQAGCWIiAAACAAAAADMA" +
           "AQEkIgA0AAEBLiIAAAAABGCACgEAAAABADgAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvckRp" +
           "YWdub3N0aWNUcmlnZ2VyVHJhbnNpdGlvbgEBZCIALwEABglkIgAAAgAAAAAzAAEBDCIANAABASYiAAAA" +
           "AARggAoBAAAAAQAuAAAAV2FpdEZvckRpYWdub3N0aWNUcmlnZ2VyVG9EaWFnbm9zdGljVHJhbnNpdGlv" +
           "bgEBZiIALwEABglmIgAAAgAAAAAzAAEBJiIANAABASgiAAAAAARggAoBAAAAAQAUAAAARGlhZ25vc3Rp" +
           "Y1RyYW5zaXRpb24BAWgiAC8BAAYJaCIAAAIAAAAAMwABASgiADQAAQEoIgAAAAAEYIAKAQAAAAEAJAAA" +
           "AERpYWdub3N0aWNUb1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEBaiIALwEABglqIgAAAgAAAAAzAAEB" +
           "KCIANAABAS4iAAAAAARggAoBAAAAAQA2AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JDbGVh" +
           "bmluZ1RyaWdnZXJUcmFuc2l0aW9uAQFsIgAvAQAGCWwiAAACAAAAADMAAQEMIgA0AAEBKiIAAAAABGCA" +
           "CgEAAAABACoAAABXYWl0Rm9yQ2xlYW5pbmdUcmlnZ2VyVG9DbGVhbmluZ1RyYW5zaXRpb24BAW4iAC8B" +
           "AAYJbiIAAAIAAAAAMwABASoiADQAAQEsIgAAAAAEYIAKAQAAAAEAEgAAAENsZWFuaW5nVHJhbnNpdGlv" +
           "bgEBcCIALwEABglwIgAAAgAAAAAzAAEBLCIANAABASwiAAAAAARggAoBAAAAAQAiAAAAQ2xlYW5pbmdU" +
           "b1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEBciIALwEABglyIgAAAgAAAAAzAAEBLCIANAABAS4iAAAA" +
           "AARggAoBAAAAAQAvAAAAUHVibGlzaFJlc3VsdHNUb0NsZWFudXBTYW1wbGluZ1N5c3RlbVRyYW5zaXRp" +
           "b24BAXQiAC8BAAYJdCIAAAIAAAAAMwABAS4iADQAAQEyIgAAAAAEYIAKAQAAAAEAKQAAAFB1Ymxpc2hS" +
           "ZXN1bHRzVG9FamVjdEdyYWJTYW1wbGVUcmFuc2l0aW9uAQF2IgAvAQAGCXYiAAACAAAAADMAAQEuIgA0" +
           "AAEBMCIAAAAABGCACgEAAAABABkAAABFamVjdEdyYWJTYW1wbGVUcmFuc2l0aW9uAQF4IgAvAQAGCXgi" +
           "AAACAAAAADMAAQEwIgA0AAEBMCIAAAAABGCACgEAAAABADAAAABFamVjdEdyYWJTYW1wbGVUb0NsZWFu" +
           "dXBTYW1wbGluZ1N5c3RlbVRyYW5zaXRpb24BAXoiAC8BAAYJeiIAAAIAAAAAMwABATAiADQAAQEyIgAA" +
           "AAAEYIAKAQAAAAEAHwAAAENsZWFudXBTYW1wbGluZ1N5c3RlbVRyYW5zaXRpb24BAXwiAC8BAAYJfCIA" +
           "AAIAAAAAMwABATIiADQAAQEyIgAAAAAEYIAKAQAAAAEANQAAAENsZWFudXBTYW1wbGluZ1N5c3RlbVRv" +
           "U2VsZWN0RXhlY3V0aW9uQ3ljbGVUcmFuc2l0aW9uAQF+IgAvAQAGCX4iAAACAAAAADMAAQEyIgA0AAEB" +
           "DCIAAAAAJGCACgEAAAABAAoAAABDb21wbGV0aW5nAQGAIgMAAAAARAAAAFRoaXMgc3RhdGUgaXMgYW4g" +
           "YXV0b21hdGljIG9yIGNvbW1hbmRlZCBleGl0IGZyb20gdGhlIEV4ZWN1dGUgc3RhdGUuAC8BAAMJgCIA" +
           "AAYAAAAANAEBAaQiADMBAQGmIgA0AQEBpiIAMwEBAagiADMBAQHYIgAzAQEB8iIAAAAAJGCACgEAAAAB" +
           "AAgAAABDb21wbGV0ZQEBgiIDAAAAAGYAAABBdCB0aGlzIHBvaW50LCB0aGUgQ29tcGxldGluZyBzdGF0" +
           "ZSBpcyBkb25lIGFuZCBpdCB0cmFuc2l0aW9ucyBhdXRvbWF0aWNhbGx5IHRvIFN0b3BwZWQgc3RhdGUg" +
           "dG8gd2FpdC4ALwEAAwmCIgAABAAAAAA0AQEBqCIAMwEBAaoiADMBAQHaIgAzAQEB9CIAAAAAJGCACgEA" +
           "AAABAAoAAABTdXNwZW5kaW5nAQGEIgMAAAAAYAAAAFRoaXMgc3RhdGUgaXMgYSByZXN1bHQgb2YgYSBj" +
           "aGFuZ2UgaW4gbW9uaXRvcmVkIGNvbmRpdGlvbnMgZHVlIHRvIHByb2Nlc3MgY29uZGl0aW9ucyBvciBm" +
           "YWN0b3JzLgAvAQADCYQiAAAHAAAAADQBAQG6IgAzAQEBvCIANAEBAbwiADMBAQG+IgA0AQEBxCIAMwEB" +
           "AdwiADMBAQH2IgAAAAAkYIAKAQAAAAEACQAAAFN1c3BlbmRlZAEBhiIDAAAAAKcAAABUaGUgYW5hbHlz" +
           "ZXIgb3IgY2hhbm5lbCBtYXkgYmUgcnVubmluZyBidXQgbm8gcmVzdWx0cyBhcmUgYmVpbmcgZ2VuZXJh" +
           "dGVkIHdoaWxlIHRoZSBhbmFseXNlciBvciBjaGFubmVsIGlzIHdhaXRpbmcgZm9yIGV4dGVybmFsIHBy" +
           "b2Nlc3MgY29uZGl0aW9ucyB0byByZXR1cm4gdG8gbm9ybWFsLgAvAQADCYYiAAAEAAAAADQBAQG+IgAz" +
           "AQEBwCIAMwEBAd4iADMBAQH4IgAAAAAkYIAKAQAAAAEADAAAAFVuc3VzcGVuZGluZwEBiCIDAAAAAIgA" +
           "AABUaGlzIHN0YXRlIGlzIGEgcmVzdWx0IG9mIGEgZGV2aWNlIHJlcXVlc3QgZnJvbSBTdXNwZW5kZWQg" +
           "c3RhdGUgdG8gdHJhbnNpdGlvbiBiYWNrIHRvIHRoZSBFeGVjdXRlIHN0YXRlIGJ5IGNhbGxpbmcgdGhl" +
           "IFVuc3VzcGVuZCBNZXRob2QuAC8BAAMJiCIAAAcAAAAANAEBAcAiADMBAQHCIgA0AQEBwiIAMwEBAcQi" +
           "ADMBAQHGIgAzAQEB4CIAMwEBAfoiAAAAACRggAoBAAAAAQAHAAAASG9sZGluZwEBiiIDAAAAAHwAAABC" +
           "cmluZ3MgdGhlIGFuYWx5c2VyIG9yIGNoYW5uZWwgdG8gYSBjb250cm9sbGVkIHN0b3Agb3IgdG8gYSBz" +
           "dGF0ZSB3aGljaCByZXByZXNlbnRzIEhlbGQgZm9yIHRoZSBwYXJ0aWN1bGFyIHVuaXQgY29udHJvbCBt" +
           "b2RlAC8BAAMJiiIAAAcAAAAANAEBAawiADMBAQGuIgA0AQEBriIAMwEBAbAiADQBAQG2IgAzAQEB4iIA" +
           "MwEBAfwiAAAAACRggAoBAAAAAQAEAAAASGVsZAEBjCIDAAAAAGsAAABUaGUgSGVsZCBzdGF0ZSBob2xk" +
           "cyB0aGUgYW5hbHlzZXIgb3IgY2hhbm5lbCdzIG9wZXJhdGlvbi4gQXQgdGhpcyBzdGF0ZSwgbm8gYWNx" +
           "dWlzaXRpb24gY3ljbGUgaXMgcGVyZm9ybWVkLgAvAQADCYwiAAAEAAAAADQBAQGwIgAzAQEBsiIAMwEB" +
           "AeQiADMBAQH+IgAAAAAkYIAKAQAAAAEACQAAAFVuaG9sZGluZwEBjiIDAAAAAFUAAABUaGUgVW5ob2xk" +
           "aW5nIHN0YXRlIGlzIGEgcmVzcG9uc2UgdG8gYW4gb3BlcmF0b3IgY29tbWFuZCB0byByZXN1bWUgdGhl" +
           "IEV4ZWN1dGUgc3RhdGUuAC8BAAMJjiIAAAcAAAAANAEBAbIiADMBAQG0IgA0AQEBtCIAMwEBAbYiADMB" +
           "AQG4IgAzAQEB5iIAMwEBAQAjAAAAACRggAoBAAAAAQAIAAAAU3RvcHBpbmcBAZAiAwAAAAAsAAAASW5p" +
           "dGlhdGVkIGJ5IGEgU3RvcCBNZXRob2QgY2FsbCwgdGhpcyBzdGF0ZToALwEAAwmQIgAADgAAAAAzAQEB" +
           "yCIANAEBAdAiADQBAQHSIgA0AQEB1CIANAEBAdYiADQBAQHYIgA0AQEB2iIANAEBAdwiADQBAQHeIgA0" +
           "AQEB4CIANAEBAeIiADQBAQHkIgA0AQEB5iIAMwEBAQIjAAAAACRggAoBAAAAAQAIAAAAQWJvcnRpbmcB" +
           "AZIiAwAAAAB3AAAAVGhlIEFib3J0aW5nIHN0YXRlIGNhbiBiZSBlbnRlcmVkIGF0IGFueSB0aW1lIGlu" +
           "IHJlc3BvbnNlIHRvIHRoZSBBYm9ydCBjb21tYW5kIG9yIG9uIHRoZSBvY2N1cnJlbmNlIG9mIGEgbWFj" +
           "aGluZSBmYXVsdC4ALwEAAwmSIgAADwAAAAAzAQEByiIANAEBAegiADQBAQHqIgA0AQEB7CIANAEBAe4i" +
           "ADQBAQHwIgA0AQEB8iIANAEBAfQiADQBAQH2IgA0AQEB+CIANAEBAfoiADQBAQH8IgA0AQEB/iIANAEB" +
           "AQAjADQBAQECIwAAAAAkYIAKAQAAAAEABwAAAEFib3J0ZWQBAZQiAwAAAABQAAAAVGhpcyBzdGF0ZSBt" +
           "YWludGFpbnMgbWFjaGluZSBzdGF0dXMgaW5mb3JtYXRpb24gcmVsZXZhbnQgdG8gdGhlIEFib3J0IGNv" +
           "bmRpdGlvbi4ALwEAAwmUIgAAAgAAAAA0AQEByiIAMwEBAcwiAAAAACRggAoBAAAAAQAIAAAAQ2xlYXJp" +
           "bmcBAZYiAwAAAAB8AAAAQ2xlYXJzIGZhdWx0cyB0aGF0IG1heSBoYXZlIG9jY3VycmVkIHdoZW4gQWJv" +
           "cnRpbmcgYW5kIGFyZSBwcmVzZW50IGluIHRoZSBBYm9ydGVkIHN0YXRlIGJlZm9yZSBwcm9jZWVkaW5n" +
           "IHRvIGEgU3RvcHBlZCBzdGF0ZQAvAQADCZYiAAACAAAAADQBAQHMIgAzAQEBziIAAAAABGCACgEAAAAB" +
           "ABwAAABTdG9wcGVkVG9SZXNldHRpbmdUcmFuc2l0aW9uAQGYIgAvAQAGCZgiAAAEAAAAADMAAQH3IQA0" +
           "AAEB+SEANQABAbMfADUAAQGgHwAAAAAEYIAKAQAAAAEAEwAAAFJlc2V0dGluZ1RyYW5zaXRpb24BAZoi" +
           "AC8BAAYJmiIAAAIAAAAAMwABAfkhADQAAQH5IQAAAAAEYIAKAQAAAAEAGQAAAFJlc2V0dGluZ1RvSWRs" +
           "ZVRyYW5zaXRpb24BAZwiAC8BAAYJnCIAAAIAAAAAMwABAfkhADQAAQH7IQAAAAAEYIAKAQAAAAEAGAAA" +
           "AElkbGVUb1N0YXJ0aW5nVHJhbnNpdGlvbgEBniIALwEABgmeIgAABAAAAAAzAAEB+yEANAABAf0hADUA" +
           "AQG0HwA1AAEBrx8AAAAABGCACgEAAAABABIAAABTdGFydGluZ1RyYW5zaXRpb24BAaAiAC8BAAYJoCIA" +
           "AAIAAAAAMwABAf0hADQAAQH9IQAAAAAEYIAKAQAAAAEAGwAAAFN0YXJ0aW5nVG9FeGVjdXRlVHJhbnNp" +
           "dGlvbgEBoiIALwEABgmiIgAAAgAAAAAzAAEB/SEANAABAf8hAAAAAARggAoBAAAAAQAdAAAARXhlY3V0" +
           "ZVRvQ29tcGxldGluZ1RyYW5zaXRpb24BAaQiAC8BAAYJpCIAAAIAAAAAMwABAf8hADQAAQGAIgAAAAAE" +
           "YIAKAQAAAAEAFAAAAENvbXBsZXRpbmdUcmFuc2l0aW9uAQGmIgAvAQAGCaYiAAACAAAAADMAAQGAIgA0" +
           "AAEBgCIAAAAABGCACgEAAAABAB4AAABDb21wbGV0aW5nVG9Db21wbGV0ZVRyYW5zaXRpb24BAagiAC8B" +
           "AAYJqCIAAAIAAAAAMwABAYAiADQAAQGCIgAAAAAEYIAKAQAAAAEAGwAAAENvbXBsZXRlVG9TdG9wcGVk" +
           "VHJhbnNpdGlvbgEBqiIALwEABgmqIgAAAgAAAAAzAAEBgiIANAABAfchAAAAAARggAoBAAAAAQAaAAAA" +
           "RXhlY3V0ZVRvSG9sZGluZ1RyYW5zaXRpb24BAawiAC8BAAYJrCIAAAMAAAAAMwABAf8hADQAAQGKIgA1" +
           "AAEBth8AAAAABGCACgEAAAABABEAAABIb2xkaW5nVHJhbnNpdGlvbgEBriIALwEABgmuIgAAAgAAAAAz" +
           "AAEBiiIANAABAYoiAAAAAARggAoBAAAAAQAXAAAASG9sZGluZ1RvSGVsZFRyYW5zaXRpb24BAbAiAC8B" +
           "AAYJsCIAAAIAAAAAMwABAYoiADQAAQGMIgAAAAAEYIAKAQAAAAEAGQAAAEhlbGRUb1VuaG9sZGluZ1Ry" +
           "YW5zaXRpb24BAbIiAC8BAAYJsiIAAAMAAAAAMwABAYwiADQAAQGOIgA1AAEBtx8AAAAABGCACgEAAAAB" +
           "ABMAAABVbmhvbGRpbmdUcmFuc2l0aW9uAQG0IgAvAQAGCbQiAAACAAAAADMAAQGOIgA0AAEBjiIAAAAA" +
           "BGCACgEAAAABABwAAABVbmhvbGRpbmdUb0hvbGRpbmdUcmFuc2l0aW9uAQG2IgAvAQAGCbYiAAADAAAA" +
           "ADMAAQGOIgA0AAEBiiIANQABAbYfAAAAAARggAoBAAAAAQAcAAAAVW5ob2xkaW5nVG9FeGVjdXRlVHJh" +
           "bnNpdGlvbgEBuCIALwEABgm4IgAAAgAAAAAzAAEBjiIANAABAf8hAAAAAARggAoBAAAAAQAdAAAARXhl" +
           "Y3V0ZVRvU3VzcGVuZGluZ1RyYW5zaXRpb24BAboiAC8BAAYJuiIAAAMAAAAAMwABAf8hADQAAQGEIgA1" +
           "AAEBuB8AAAAABGCACgEAAAABABQAAABTdXNwZW5kaW5nVHJhbnNpdGlvbgEBvCIALwEABgm8IgAAAgAA" +
           "AAAzAAEBhCIANAABAYQiAAAAAARggAoBAAAAAQAfAAAAU3VzcGVuZGluZ1RvU3VzcGVuZGVkVHJhbnNp" +
           "dGlvbgEBviIALwEABgm+IgAAAgAAAAAzAAEBhCIANAABAYYiAAAAAARggAoBAAAAAQAhAAAAU3VzcGVu" +
           "ZGVkVG9VbnN1c3BlbmRpbmdUcmFuc2l0aW9uAQHAIgAvAQAGCcAiAAADAAAAADMAAQGGIgA0AAEBiCIA" +
           "NQABAbkfAAAAAARggAoBAAAAAQAWAAAAVW5zdXNwZW5kaW5nVHJhbnNpdGlvbgEBwiIALwEABgnCIgAA" +
           "AgAAAAAzAAEBiCIANAABAYgiAAAAAARggAoBAAAAAQAiAAAAVW5zdXNwZW5kaW5nVG9TdXNwZW5kaW5n" +
           "VHJhbnNpdGlvbgEBxCIALwEABgnEIgAAAwAAAAAzAAEBiCIANAABAYQiADUAAQG4HwAAAAAEYIAKAQAA" +
           "AAEAHwAAAFVuc3VzcGVuZGluZ1RvRXhlY3V0ZVRyYW5zaXRpb24BAcYiAC8BAAYJxiIAAAIAAAAAMwAB" +
           "AYgiADQAAQH/IQAAAAAEYIAKAQAAAAEAGwAAAFN0b3BwaW5nVG9TdG9wcGVkVHJhbnNpdGlvbgEByCIA" +
           "LwEABgnIIgAAAgAAAAAzAAEBkCIANAABAfchAAAAAARggAoBAAAAAQAbAAAAQWJvcnRpbmdUb0Fib3J0" +
           "ZWRUcmFuc2l0aW9uAQHKIgAvAQAGCcoiAAACAAAAADMAAQGSIgA0AAEBlCIAAAAABGCACgEAAAABABsA" +
           "AABBYm9ydGVkVG9DbGVhcmluZ1RyYW5zaXRpb24BAcwiAC8BAAYJzCIAAAMAAAAAMwABAZQiADQAAQGW" +
           "IgA1AAEBux8AAAAABGCACgEAAAABABsAAABDbGVhcmluZ1RvU3RvcHBlZFRyYW5zaXRpb24BAc4iAC8B" +
           "AAYJziIAAAIAAAAAMwABAZYiADQAAQH3IQAAAAAEYIAKAQAAAAEAHQAAAFJlc2V0dGluZ1RvU3RvcHBp" +
           "bmdUcmFuc2l0aW9uAQHQIgAvAQAGCdAiAAADAAAAADMAAQH5IQA0AAEBkCIANQABAbUfAAAAAARggAoB" +
           "AAAAAQAYAAAASWRsZVRvU3RvcHBpbmdUcmFuc2l0aW9uAQHSIgAvAQAGCdIiAAADAAAAADMAAQH7IQA0" +
           "AAEBkCIANQABAbUfAAAAAARggAoBAAAAAQAcAAAAU3RhcnRpbmdUb1N0b3BwaW5nVHJhbnNpdGlvbgEB" +
           "1CIALwEABgnUIgAAAwAAAAAzAAEB/SEANAABAZAiADUAAQG1HwAAAAAEYIAKAQAAAAEAGwAAAEV4ZWN1" +
           "dGVUb1N0b3BwaW5nVHJhbnNpdGlvbgEB1iIALwEABgnWIgAAAwAAAAAzAAEB/yEANAABAZAiADUAAQG1" +
           "HwAAAAAEYIAKAQAAAAEAHgAAAENvbXBsZXRpbmdUb1N0b3BwaW5nVHJhbnNpdGlvbgEB2CIALwEABgnY" +
           "IgAAAwAAAAAzAAEBgCIANAABAZAiADUAAQG1HwAAAAAEYIAKAQAAAAEAHAAAAENvbXBsZXRlVG9TdG9w" +
           "cGluZ1RyYW5zaXRpb24BAdoiAC8BAAYJ2iIAAAMAAAAAMwABAYIiADQAAQGQIgA1AAEBtR8AAAAABGCA" +
           "CgEAAAABAB4AAABTdXNwZW5kaW5nVG9TdG9wcGluZ1RyYW5zaXRpb24BAdwiAC8BAAYJ3CIAAAMAAAAA" +
           "MwABAYQiADQAAQGQIgA1AAEBtR8AAAAABGCACgEAAAABAB0AAABTdXNwZW5kZWRUb1N0b3BwaW5nVHJh" +
           "bnNpdGlvbgEB3iIALwEABgneIgAAAwAAAAAzAAEBhiIANAABAZAiADUAAQG1HwAAAAAEYIAKAQAAAAEA" +
           "IAAAAFVuc3VzcGVuZGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9uAQHgIgAvAQAGCeAiAAADAAAAADMAAQGI" +
           "IgA0AAEBkCIANQABAbUfAAAAAARggAoBAAAAAQAbAAAASG9sZGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9u" +
           "AQHiIgAvAQAGCeIiAAADAAAAADMAAQGKIgA0AAEBkCIANQABAbUfAAAAAARggAoBAAAAAQAYAAAASGVs" +
           "ZFRvU3RvcHBpbmdUcmFuc2l0aW9uAQHkIgAvAQAGCeQiAAADAAAAADMAAQGMIgA0AAEBkCIANQABAbUf" +
           "AAAAAARggAoBAAAAAQAdAAAAVW5ob2xkaW5nVG9TdG9wcGluZ1RyYW5zaXRpb24BAeYiAC8BAAYJ5iIA" +
           "AAMAAAAAMwABAY4iADQAAQGQIgA1AAEBtR8AAAAABGCACgEAAAABABsAAABTdG9wcGVkVG9BYm9ydGlu" +
           "Z1RyYW5zaXRpb24BAegiAC8BAAYJ6CIAAAMAAAAAMwABAfchADQAAQGSIgA1AAEBuh8AAAAABGCACgEA" +
           "AAABAB0AAABSZXNldHRpbmdUb0Fib3J0aW5nVHJhbnNpdGlvbgEB6iIALwEABgnqIgAAAwAAAAAzAAEB" +
           "+SEANAABAZIiADUAAQG6HwAAAAAEYIAKAQAAAAEAGAAAAElkbGVUb0Fib3J0aW5nVHJhbnNpdGlvbgEB" +
           "7CIALwEABgnsIgAAAwAAAAAzAAEB+yEANAABAZIiADUAAQG6HwAAAAAEYIAKAQAAAAEAHAAAAFN0YXJ0" +
           "aW5nVG9BYm9ydGluZ1RyYW5zaXRpb24BAe4iAC8BAAYJ7iIAAAMAAAAAMwABAf0hADQAAQGSIgA1AAEB" +
           "uh8AAAAABGCACgEAAAABABsAAABFeGVjdXRlVG9BYm9ydGluZ1RyYW5zaXRpb24BAfAiAC8BAAYJ8CIA" +
           "AAMAAAAAMwABAf8hADQAAQGSIgA1AAEBuh8AAAAABGCACgEAAAABAB4AAABDb21wbGV0aW5nVG9BYm9y" +
           "dGluZ1RyYW5zaXRpb24BAfIiAC8BAAYJ8iIAAAMAAAAAMwABAYAiADQAAQGSIgA1AAEBuh8AAAAABGCA" +
           "CgEAAAABABwAAABDb21wbGV0ZVRvQWJvcnRpbmdUcmFuc2l0aW9uAQH0IgAvAQAGCfQiAAADAAAAADMA" +
           "AQGCIgA0AAEBkiIANQABAbofAAAAAARggAoBAAAAAQAeAAAAU3VzcGVuZGluZ1RvQWJvcnRpbmdUcmFu" +
           "c2l0aW9uAQH2IgAvAQAGCfYiAAADAAAAADMAAQGEIgA0AAEBkiIANQABAbofAAAAAARggAoBAAAAAQAd" +
           "AAAAU3VzcGVuZGVkVG9BYm9ydGluZ1RyYW5zaXRpb24BAfgiAC8BAAYJ+CIAAAMAAAAAMwABAYYiADQA" +
           "AQGSIgA1AAEBuh8AAAAABGCACgEAAAABACAAAABVbnN1c3BlbmRpbmdUb0Fib3J0aW5nVHJhbnNpdGlv" +
           "bgEB+iIALwEABgn6IgAAAwAAAAAzAAEBiCIANAABAZIiADUAAQG6HwAAAAAEYIAKAQAAAAEAGwAAAEhv" +
           "bGRpbmdUb0Fib3J0aW5nVHJhbnNpdGlvbgEB/CIALwEABgn8IgAAAwAAAAAzAAEBiiIANAABAZIiADUA" +
           "AQG6HwAAAAAEYIAKAQAAAAEAGAAAAEhlbGRUb0Fib3J0aW5nVHJhbnNpdGlvbgEB/iIALwEABgn+IgAA" +
           "AwAAAAAzAAEBjCIANAABAZIiADUAAQG6HwAAAAAEYIAKAQAAAAEAHQAAAFVuaG9sZGluZ1RvQWJvcnRp" +
           "bmdUcmFuc2l0aW9uAQEAIwAvAQAGCQAjAAADAAAAADMAAQGOIgA0AAEBkiIANQABAbofAAAAAARggAoB" +
           "AAAAAQAcAAAAU3RvcHBpbmdUb0Fib3J0aW5nVHJhbnNpdGlvbgEBAiMALwEABgkCIwAAAwAAAAAzAAEB" +
           "kCIANAABAZIiADUAAQG6HwAAAAAkYIAKAQAAAAEABQAAAExvY2FsAQHFEwMAAAAAewAAAFRoZSBBbmFs" +
           "eXNlckNoYW5uZWwgaXMgaW4gdGhlIExvY2FsIG1vZGUuIFRoaXMgbW9kZSBpcyBub3JtYWxseSB1c2Vk" +
           "IHRvIHBlcmZvcm0gbG9jYWwgcGh5c2ljYWwgbWFpbnRlbmFuY2Ugb24gdGhlIGFuYWx5c2VyLgAvAQHt" +
           "A8UTAAAFAAAAADQBAQHIEwAzAQEByhMAMwEBAcsTADQBAQHNEwAzAQEBzxMBAAAAFWCpCgIAAAAAAAsA" +
           "AABTdGF0ZU51bWJlcgEBExgALgBEExgAAAcAAAAAAAf/////AQH/////AAAAACRggAoBAAAAAQALAAAA" +
           "TWFpbnRlbmFuY2UBAcYTAwAAAACGAAAAVGhlIEFuYWx5c2VyQ2hhbm5lbCBpcyBpbiB0aGUgTWFpbnRl" +
           "bmFuY2UgbW9kZS4gVGhpcyBtb2RlIGlzIHVzZWQgdG8gcGVyZm9ybSByZW1vdGUgbWFpbnRlbmFuY2Ug" +
           "b24gdGhlIGFuYWx5c2VyIGxpa2UgZmlybXdhcmUgdXBncmFkZS4ALwEB7gPGEwAABQAAAAA0AQEByRMA" +
           "NAEBAcsTADMBAQHMEwAzAQEBzRMAMwEBAdATAQAAABVgqQoCAAAAAAALAAAAU3RhdGVOdW1iZXIBARQY" +
           "AC4ARBQYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHgAAAFNsYXZlTW9kZVRvT3BlcmF0" +
           "aW5nVHJhbnNpdGlvbgEBxxMALwEABgnHEwAAAgAAAAAzAAEBwhMANAABAcMTAQAAABVgqQoCAAAAAAAQ" +
           "AAAAVHJhbnNpdGlvbk51bWJlcgEBFRgALgBEFRgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAA" +
           "AQAaAAAAT3BlcmF0aW5nVG9Mb2NhbFRyYW5zaXRpb24BAcgTAC8BAAYJyBMAAAIAAAAAMwABAcMTADQA" +
           "AQHFEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBARYYAC4ARBYYAAAHAAAAAAAH////" +
           "/wEB/////wAAAAAEYIAKAQAAAAEAIAAAAE9wZXJhdGluZ1RvTWFpbnRlbmFuY2VUcmFuc2l0aW9uAQHJ" +
           "EwAvAQAGCckTAAADAAAAADMAAQHDEwA0AAEBxhMANQABAbIfAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNp" +
           "dGlvbk51bWJlcgEBFxgALgBEFxgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAaAAAATG9j" +
           "YWxUb09wZXJhdGluZ1RyYW5zaXRpb24BAcoTAC8BAAYJyhMAAAIAAAAAMwABAcUTADQAAQHDEwEAAAAV" +
           "YKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBARgYAC4ARBgYAAAHAAAAAAAH/////wEB/////wAA" +
           "AAAEYIAKAQAAAAEAHAAAAExvY2FsVG9NYWludGVuYW5jZVRyYW5zaXRpb24BAcsTAC8BAAYJyxMAAAIA" +
           "AAAAMwABAcUTADQAAQHGEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBARkYAC4ARBkY" +
           "AAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAIAAAAE1haW50ZW5hbmNlVG9PcGVyYXRpbmdU" +
           "cmFuc2l0aW9uAQHMEwAvAQAGCcwTAAADAAAAADMAAQHGEwA0AAEBwxMANQABAbEfAQAAABVgqQoCAAAA" +
           "AAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBGhgALgBEGhgAAAcAAAAAAAf/////AQH/////AAAAAARggAoB" +
           "AAAAAQAcAAAATWFpbnRlbmFuY2VUb0xvY2FsVHJhbnNpdGlvbgEBzRMALwEABgnNEwAAAgAAAAAzAAEB" +
           "xhMANAABAcUTAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBGxgALgBEGxgAAAcAAAAA" +
           "AAf/////AQH/////AAAAAARggAoBAAAAAQAeAAAAT3BlcmF0aW5nVG9TbGF2ZU1vZGVUcmFuc2l0aW9u" +
           "AQHOEwAvAQAGCc4TAAACAAAAADMAAQHDEwA0AAEBwhMBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9u" +
           "TnVtYmVyAQEcGAAuAEQcGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABoAAABMb2NhbFRv" +
           "U2xhdmVNb2RlVHJhbnNpdGlvbgEBzxMALwEABgnPEwAAAgAAAAAzAAEBxRMANAABAcITAQAAABVgqQoC" +
           "AAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBHRgALgBEHRgAAAcAAAAAAAf/////AQH/////AAAAAARg" +
           "gAoBAAAAAQAgAAAATWFpbnRlbmFuY2VUb1NsYXZlTW9kZVRyYW5zaXRpb24BAdATAC8BAAYJ0BMAAAIA" +
           "AAAAMwABAcYTADQAAQHCEwEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAR4YAC4ARB4Y" +
           "AAAHAAAAAAAH/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// The AnalyserDevice is in Local or Maintenance mode and all AnalyserChannels are in SlaveMode
        /// </summary>
        public StateMachineInitialStateState SlaveMode
        {
            get
            { 
                return m_slaveMode;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_slaveMode, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_slaveMode = value;
            }
        }

        /// <summary>
        /// The AnalyserChannel is in the Operating mode.
        /// </summary>
        public AnalyserChannelOperatingStateState Operating
        {
            get
            { 
                return m_operating;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operating, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operating = value;
            }
        }

        /// <summary>
        /// The AnalyserChannel is in the Local mode. This mode is normally used to perform local physical maintenance on the analyser.
        /// </summary>
        public AnalyserChannelLocalStateState Local
        {
            get
            { 
                return m_local;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_local, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_local = value;
            }
        }

        /// <summary>
        /// The AnalyserChannel is in the Maintenance mode. This mode is used to perform remote maintenance on the analyser like firmware upgrade.
        /// </summary>
        public AnalyserChannelMaintenanceStateState Maintenance
        {
            get
            { 
                return m_maintenance;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenance, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenance = value;
            }
        }

        /// <summary>
        /// A description for the SlaveModeToOperatingTransition Object.
        /// </summary>
        public StateMachineTransitionState SlaveModeToOperatingTransition
        {
            get
            { 
                return m_slaveModeToOperatingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_slaveModeToOperatingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_slaveModeToOperatingTransition = value;
            }
        }

        /// <summary>
        /// A description for the OperatingToLocalTransition Object.
        /// </summary>
        public StateMachineTransitionState OperatingToLocalTransition
        {
            get
            { 
                return m_operatingToLocalTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingToLocalTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingToLocalTransition = value;
            }
        }

        /// <summary>
        /// A description for the OperatingToMaintenanceTransition Object.
        /// </summary>
        public StateMachineTransitionState OperatingToMaintenanceTransition
        {
            get
            { 
                return m_operatingToMaintenanceTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingToMaintenanceTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingToMaintenanceTransition = value;
            }
        }

        /// <summary>
        /// A description for the LocalToOperatingTransition Object.
        /// </summary>
        public StateMachineTransitionState LocalToOperatingTransition
        {
            get
            { 
                return m_localToOperatingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localToOperatingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localToOperatingTransition = value;
            }
        }

        /// <summary>
        /// A description for the LocalToMaintenanceTransition Object.
        /// </summary>
        public StateMachineTransitionState LocalToMaintenanceTransition
        {
            get
            { 
                return m_localToMaintenanceTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localToMaintenanceTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localToMaintenanceTransition = value;
            }
        }

        /// <summary>
        /// A description for the MaintenanceToOperatingTransition Object.
        /// </summary>
        public StateMachineTransitionState MaintenanceToOperatingTransition
        {
            get
            { 
                return m_maintenanceToOperatingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenanceToOperatingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenanceToOperatingTransition = value;
            }
        }

        /// <summary>
        /// A description for the MaintenanceToLocalTransition Object.
        /// </summary>
        public StateMachineTransitionState MaintenanceToLocalTransition
        {
            get
            { 
                return m_maintenanceToLocalTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenanceToLocalTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenanceToLocalTransition = value;
            }
        }

        /// <summary>
        /// A description for the OperatingToSlaveModeTransition Object.
        /// </summary>
        public StateMachineTransitionState OperatingToSlaveModeTransition
        {
            get
            { 
                return m_operatingToSlaveModeTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingToSlaveModeTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingToSlaveModeTransition = value;
            }
        }

        /// <summary>
        /// A description for the LocalToSlaveModeTransition Object.
        /// </summary>
        public StateMachineTransitionState LocalToSlaveModeTransition
        {
            get
            { 
                return m_localToSlaveModeTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_localToSlaveModeTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_localToSlaveModeTransition = value;
            }
        }

        /// <summary>
        /// A description for the MaintenanceToSlaveModeTransition Object.
        /// </summary>
        public StateMachineTransitionState MaintenanceToSlaveModeTransition
        {
            get
            { 
                return m_maintenanceToSlaveModeTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_maintenanceToSlaveModeTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_maintenanceToSlaveModeTransition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_slaveMode != null)
            {
                children.Add(m_slaveMode);
            }

            if (m_operating != null)
            {
                children.Add(m_operating);
            }

            if (m_local != null)
            {
                children.Add(m_local);
            }

            if (m_maintenance != null)
            {
                children.Add(m_maintenance);
            }

            if (m_slaveModeToOperatingTransition != null)
            {
                children.Add(m_slaveModeToOperatingTransition);
            }

            if (m_operatingToLocalTransition != null)
            {
                children.Add(m_operatingToLocalTransition);
            }

            if (m_operatingToMaintenanceTransition != null)
            {
                children.Add(m_operatingToMaintenanceTransition);
            }

            if (m_localToOperatingTransition != null)
            {
                children.Add(m_localToOperatingTransition);
            }

            if (m_localToMaintenanceTransition != null)
            {
                children.Add(m_localToMaintenanceTransition);
            }

            if (m_maintenanceToOperatingTransition != null)
            {
                children.Add(m_maintenanceToOperatingTransition);
            }

            if (m_maintenanceToLocalTransition != null)
            {
                children.Add(m_maintenanceToLocalTransition);
            }

            if (m_operatingToSlaveModeTransition != null)
            {
                children.Add(m_operatingToSlaveModeTransition);
            }

            if (m_localToSlaveModeTransition != null)
            {
                children.Add(m_localToSlaveModeTransition);
            }

            if (m_maintenanceToSlaveModeTransition != null)
            {
                children.Add(m_maintenanceToSlaveModeTransition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.SlaveMode:
                {
                    if (createOrReplace)
                    {
                        if (SlaveMode == null)
                        {
                            if (replacement == null)
                            {
                                SlaveMode = new StateMachineInitialStateState(this);
                            }
                            else
                            {
                                SlaveMode = (StateMachineInitialStateState)replacement;
                            }
                        }
                    }

                    instance = SlaveMode;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Operating:
                {
                    if (createOrReplace)
                    {
                        if (Operating == null)
                        {
                            if (replacement == null)
                            {
                                Operating = new AnalyserChannelOperatingStateState(this);
                            }
                            else
                            {
                                Operating = (AnalyserChannelOperatingStateState)replacement;
                            }
                        }
                    }

                    instance = Operating;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Local:
                {
                    if (createOrReplace)
                    {
                        if (Local == null)
                        {
                            if (replacement == null)
                            {
                                Local = new AnalyserChannelLocalStateState(this);
                            }
                            else
                            {
                                Local = (AnalyserChannelLocalStateState)replacement;
                            }
                        }
                    }

                    instance = Local;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Maintenance:
                {
                    if (createOrReplace)
                    {
                        if (Maintenance == null)
                        {
                            if (replacement == null)
                            {
                                Maintenance = new AnalyserChannelMaintenanceStateState(this);
                            }
                            else
                            {
                                Maintenance = (AnalyserChannelMaintenanceStateState)replacement;
                            }
                        }
                    }

                    instance = Maintenance;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SlaveModeToOperatingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SlaveModeToOperatingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SlaveModeToOperatingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SlaveModeToOperatingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SlaveModeToOperatingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.OperatingToLocalTransition:
                {
                    if (createOrReplace)
                    {
                        if (OperatingToLocalTransition == null)
                        {
                            if (replacement == null)
                            {
                                OperatingToLocalTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                OperatingToLocalTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = OperatingToLocalTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.OperatingToMaintenanceTransition:
                {
                    if (createOrReplace)
                    {
                        if (OperatingToMaintenanceTransition == null)
                        {
                            if (replacement == null)
                            {
                                OperatingToMaintenanceTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                OperatingToMaintenanceTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = OperatingToMaintenanceTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.LocalToOperatingTransition:
                {
                    if (createOrReplace)
                    {
                        if (LocalToOperatingTransition == null)
                        {
                            if (replacement == null)
                            {
                                LocalToOperatingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                LocalToOperatingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = LocalToOperatingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.LocalToMaintenanceTransition:
                {
                    if (createOrReplace)
                    {
                        if (LocalToMaintenanceTransition == null)
                        {
                            if (replacement == null)
                            {
                                LocalToMaintenanceTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                LocalToMaintenanceTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = LocalToMaintenanceTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.MaintenanceToOperatingTransition:
                {
                    if (createOrReplace)
                    {
                        if (MaintenanceToOperatingTransition == null)
                        {
                            if (replacement == null)
                            {
                                MaintenanceToOperatingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                MaintenanceToOperatingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = MaintenanceToOperatingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.MaintenanceToLocalTransition:
                {
                    if (createOrReplace)
                    {
                        if (MaintenanceToLocalTransition == null)
                        {
                            if (replacement == null)
                            {
                                MaintenanceToLocalTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                MaintenanceToLocalTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = MaintenanceToLocalTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.OperatingToSlaveModeTransition:
                {
                    if (createOrReplace)
                    {
                        if (OperatingToSlaveModeTransition == null)
                        {
                            if (replacement == null)
                            {
                                OperatingToSlaveModeTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                OperatingToSlaveModeTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = OperatingToSlaveModeTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.LocalToSlaveModeTransition:
                {
                    if (createOrReplace)
                    {
                        if (LocalToSlaveModeTransition == null)
                        {
                            if (replacement == null)
                            {
                                LocalToSlaveModeTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                LocalToSlaveModeTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = LocalToSlaveModeTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.MaintenanceToSlaveModeTransition:
                {
                    if (createOrReplace)
                    {
                        if (MaintenanceToSlaveModeTransition == null)
                        {
                            if (replacement == null)
                            {
                                MaintenanceToSlaveModeTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                MaintenanceToSlaveModeTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = MaintenanceToSlaveModeTransition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private StateMachineInitialStateState m_slaveMode;
        private AnalyserChannelOperatingStateState m_operating;
        private AnalyserChannelLocalStateState m_local;
        private AnalyserChannelMaintenanceStateState m_maintenance;
        private StateMachineTransitionState m_slaveModeToOperatingTransition;
        private StateMachineTransitionState m_operatingToLocalTransition;
        private StateMachineTransitionState m_operatingToMaintenanceTransition;
        private StateMachineTransitionState m_localToOperatingTransition;
        private StateMachineTransitionState m_localToMaintenanceTransition;
        private StateMachineTransitionState m_maintenanceToOperatingTransition;
        private StateMachineTransitionState m_maintenanceToLocalTransition;
        private StateMachineTransitionState m_operatingToSlaveModeTransition;
        private StateMachineTransitionState m_localToSlaveModeTransition;
        private StateMachineTransitionState m_maintenanceToSlaveModeTransition;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannelOperatingExecuteStateState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannelOperatingExecuteStateState)
    /// <summary>
    /// Stores an instance of the AnalyserChannelOperatingExecuteStateType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannelOperatingExecuteStateState : StateMachineStateState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannelOperatingExecuteStateState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannelOperatingExecuteStateType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAwAAAAQW5hbHlzZXJDaGFubmVsT3BlcmF0aW5nRXhl" +
           "Y3V0ZVN0YXRlVHlwZUluc3RhbmNlAQEEIwEBBCMB/////wEAAAAEYIAKAQAAAAEAHwAAAE9wZXJhdGlu" +
           "Z0V4ZWN1dGVTdWJTdGF0ZU1hY2hpbmUBAQYjAC8BAfEDBiMAAP////87AAAAFWCJCgIAAAAAAAwAAABD" +
           "dXJyZW50U3RhdGUBAQcjAC8BAMgKByMAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQEI" +
           "IwAuAEQIIwAAABH/////AQH/////AAAAACRggAoBAAAAAQAUAAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGUB" +
           "AREjAwAAAABIAAAAVGhpcyBwc2V1ZG8tc3RhdGUgaXMgdXNlZCB0byBkZWNpZGUgd2hpY2ggZXhlY3V0" +
           "aW9uIHBhdGggc2hhbGwgYmUgdGFrZW4uAC8BAAUJESMAAAYAAAAAMwEBATkjADMBAQFJIwAzAQEBWSMA" +
           "MwEBAWkjADMBAQFxIwA0AQEBgyMAAAAAJGCACgEAAAABABkAAABXYWl0Rm9yQ2FsaWJyYXRpb25Ucmln" +
           "Z2VyAQETIwMAAAAAVQAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8g" +
           "cGVyZm9ybSB0aGUgQ2FsaWJyYXRpb24gYWNxdWlzaXRpb24gY3ljbGUALwEAAwkTIwAAAgAAAAA0AQEB" +
           "OSMAMwEBATsjAAAAACRggAoBAAAAAQAYAAAARXh0cmFjdENhbGlicmF0aW9uU2FtcGxlAQEVIwMAAAAA" +
           "WwAAAENvbGxlY3QgLyBzZXR1cCB0aGUgc2FtcGxpbmcgc3lzdGVtIHRvIHBlcmZvcm0gdGhlIGFjcXVp" +
           "c2l0aW9uIGN5Y2xlIG9mIGEgQ2FsaWJyYXRpb24gY3ljbGUALwEAAwkVIwAABAAAAAA0AQEBOyMAMwEB" +
           "AT0jADQBAQE9IwAzAQEBPyMAAAAAJGCACgEAAAABABgAAABQcmVwYXJlQ2FsaWJyYXRpb25TYW1wbGUB" +
           "ARcjAwAAAABFAAAAUHJlcGFyZSB0aGUgQ2FsaWJyYXRpb24gc2FtcGxlIGZvciB0aGUgQW5hbHlzZUNh" +
           "bGlicmF0aW9uU2FtcGxlIHN0YXRlAC8BAAMJFyMAAAQAAAAANAEBAT8jADMBAQFBIwA0AQEBQSMAMwEB" +
           "AUMjAAAAACRggAoBAAAAAQAYAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxlAQEZIwMAAAAALgAAAFBl" +
           "cmZvcm0gdGhlIGFuYWx5c2lzIG9mIHRoZSBDYWxpYnJhdGlvbiBTYW1wbGUALwEAAwkZIwAABAAAAAA0" +
           "AQEBQyMAMwEBAUUjADQBAQFFIwAzAQEBRyMAAAAAJGCACgEAAAABABgAAABXYWl0Rm9yVmFsaWRhdGlv" +
           "blRyaWdnZXIBARsjAwAAAABUAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFk" +
           "eSB0byBwZXJmb3JtIHRoZSBWYWxpZGF0aW9uIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJGyMAAAIAAAAA" +
           "NAEBAUkjADMBAQFLIwAAAAAkYIAKAQAAAAEAFwAAAEV4dHJhY3RWYWxpZGF0aW9uU2FtcGxlAQEdIwMA" +
           "AAAAWgAAAENvbGxlY3QgLyBzZXR1cCB0aGUgc2FtcGxpbmcgc3lzdGVtIHRvIHBlcmZvcm0gdGhlIGFj" +
           "cXVpc2l0aW9uIGN5Y2xlIG9mIGEgVmFsaWRhdGlvbiBjeWNsZQAvAQADCR0jAAAEAAAAADQBAQFLIwAz" +
           "AQEBTSMANAEBAU0jADMBAQFPIwAAAAAkYIAKAQAAAAEAFwAAAFByZXBhcmVWYWxpZGF0aW9uU2FtcGxl" +
           "AQEfIwMAAAAAQwAAAFByZXBhcmUgdGhlIFZhbGlkYXRpb24gc2FtcGxlIGZvciB0aGUgQW5hbHlzZVZh" +
           "bGlkYXRpb25TYW1wbGUgc3RhdGUALwEAAwkfIwAABAAAAAA0AQEBTyMAMwEBAVEjADQBAQFRIwAzAQEB" +
           "UyMAAAAAJGCACgEAAAABABcAAABBbmFseXNlVmFsaWRhdGlvblNhbXBsZQEBISMDAAAAAC0AAABQZXJm" +
           "b3JtIHRoZSBhbmFseXNpcyBvZiB0aGUgVmFsaWRhdGlvbiBTYW1wbGUALwEAAwkhIwAABAAAAAA0AQEB" +
           "UyMAMwEBAVUjADQBAQFVIwAzAQEBVyMAAAAAJGCACgEAAAABABQAAABXYWl0Rm9yU2FtcGxlVHJpZ2dl" +
           "cgEBIyMDAAAAAFAAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRvIHBl" +
           "cmZvcm0gdGhlIFNhbXBsZSBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCSMjAAACAAAAADQBAQFZIwAzAQEB" +
           "WyMAAAAAJGCACgEAAAABAA0AAABFeHRyYWN0U2FtcGxlAQElIwMAAAAAIwAAAENvbGxlY3QgdGhlIFNh" +
           "bXBsZSBmcm9tIHRoZSBwcm9jZXNzAC8BAAMJJSMAAAQAAAAANAEBAVsjADMBAQFdIwA0AQEBXSMAMwEB" +
           "AV8jAAAAACRggAoBAAAAAQANAAAAUHJlcGFyZVNhbXBsZQEBJyMDAAAAAC4AAABQcmVwYXJlIHRoZSBT" +
           "YW1wbGUgZm9yIHRoZSBBbmFseXNlU2FtcGxlIHN0YXRlAC8BAAMJJyMAAAQAAAAANAEBAV8jADMBAQFh" +
           "IwA0AQEBYSMAMwEBAWMjAAAAACRggAoBAAAAAQANAAAAQW5hbHlzZVNhbXBsZQEBKSMDAAAAACIAAABQ" +
           "ZXJmb3JtIHRoZSBhbmFseXNpcyBvZiB0aGUgU2FtcGxlAC8BAAMJKSMAAAQAAAAANAEBAWMjADMBAQFl" +
           "IwA0AQEBZSMAMwEBAWcjAAAAACRggAoBAAAAAQAYAAAAV2FpdEZvckRpYWdub3N0aWNUcmlnZ2VyAQEr" +
           "IwMAAAAASQAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9y" +
           "bSB0aGUgZGlhZ25vc3RpYyBjeWNsZSwALwEAAwkrIwAAAgAAAAA0AQEBaSMAMwEBAWsjAAAAACRggAoB" +
           "AAAAAQAKAAAARGlhZ25vc3RpYwEBLSMDAAAAAB0AAABQZXJmb3JtIHRoZSBkaWFnbm9zdGljIGN5Y2xl" +
           "LgAvAQADCS0jAAAEAAAAADQBAQFrIwAzAQEBbSMANAEBAW0jADMBAQFvIwAAAAAkYIAKAQAAAAEAFgAA" +
           "AFdhaXRGb3JDbGVhbmluZ1RyaWdnZXIBAS8jAwAAAABHAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIg" +
           "Y2hhbm5lbCBpcyByZWFkeSB0byBwZXJmb3JtIHRoZSBjbGVhbmluZyBjeWNsZSwALwEAAwkvIwAAAgAA" +
           "AAA0AQEBcSMAMwEBAXMjAAAAACRggAoBAAAAAQAIAAAAQ2xlYW5pbmcBATEjAwAAAAAbAAAAUGVyZm9y" +
           "bSB0aGUgY2xlYW5pbmcgY3ljbGUuAC8BAAMJMSMAAAQAAAAANAEBAXMjADMBAQF1IwA0AQEBdSMAMwEB" +
           "AXcjAAAAACRggAoBAAAAAQAOAAAAUHVibGlzaFJlc3VsdHMBATMjAwAAAAA1AAAAUHVibGlzaCB0aGUg" +
           "cmVzdWx0cyBvZiB0aGUgcHJldmlvdXMgYWNxdWlzaXRpb24gY3ljbGUALwEAAwkzIwAABwAAAAA0AQEB" +
           "RyMANAEBAVcjADQBAQFnIwA0AQEBbyMANAEBAXcjADMBAQF5IwAzAQEBeyMAAAAAJGCACgEAAAABAA8A" +
           "AABFamVjdEdyYWJTYW1wbGUBATUjAwAAAABvAAAAVGhlIFNhbXBsZSB0aGF0IHdhcyBqdXN0IGFuYWx5" +
           "c2VkIGlzIGVqZWN0ZWQgZnJvbSB0aGUgc3lzdGVtIHRvIGFsbG93IHRoZSBvcGVyYXRvciBvciBhbm90" +
           "aGVyIHN5c3RlbSB0byBncmFiIGl0AC8BAAMJNSMAAAQAAAAANAEBAXsjADMBAQF9IwA0AQEBfSMAMwEB" +
           "AX8jAAAAACRggAoBAAAAAQAVAAAAQ2xlYW51cFNhbXBsaW5nU3lzdGVtAQE3IwMAAAAARAAAAENsZWFu" +
           "dXAgdGhlIHNhbXBsaW5nIHN1Yi1zeXN0ZW0gdG8gYmUgcmVhZHkgZm9yIHRoZSBuZXh0IGFjcXVpc2l0" +
           "aW9uAC8BAAMJNyMAAAUAAAAANAEBAXkjADQBAQF/IwAzAQEBgSMANAEBAYEjADMBAQGDIwAAAAAEYIAK" +
           "AQAAAAEAOQAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yQ2FsaWJyYXRpb25UcmlnZ2VyVHJh" +
           "bnNpdGlvbgEBOSMALwEABgk5IwAAAgAAAAAzAAEBESMANAABARMjAAAAAARggAoBAAAAAQA9AAAAV2Fp" +
           "dEZvckNhbGlicmF0aW9uVHJpZ2dlclRvRXh0cmFjdENhbGlicmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEB" +
           "OyMALwEABgk7IwAAAgAAAAAzAAEBEyMANAABARUjAAAAAARggAoBAAAAAQAiAAAARXh0cmFjdENhbGli" +
           "cmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBPSMALwEABgk9IwAAAgAAAAAzAAEBFSMANAABARUjAAAAAARg" +
           "gAoBAAAAAQA8AAAARXh0cmFjdENhbGlicmF0aW9uU2FtcGxlVG9QcmVwYXJlQ2FsaWJyYXRpb25TYW1w" +
           "bGVUcmFuc2l0aW9uAQE/IwAvAQAGCT8jAAACAAAAADMAAQEVIwA0AAEBFyMAAAAABGCACgEAAAABACIA" +
           "AABQcmVwYXJlQ2FsaWJyYXRpb25TYW1wbGVUcmFuc2l0aW9uAQFBIwAvAQAGCUEjAAACAAAAADMAAQEX" +
           "IwA0AAEBFyMAAAAABGCACgEAAAABADwAAABQcmVwYXJlQ2FsaWJyYXRpb25TYW1wbGVUb0FuYWx5c2VD" +
           "YWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BAUMjAC8BAAYJQyMAAAIAAAAAMwABARcjADQAAQEZIwAA" +
           "AAAEYIAKAQAAAAEAIgAAAEFuYWx5c2VDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BAUUjAC8BAAYJ" +
           "RSMAAAIAAAAAMwABARkjADQAAQEZIwAAAAAEYIAKAQAAAAEAMgAAAEFuYWx5c2VDYWxpYnJhdGlvblNh" +
           "bXBsZVRvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQFHIwAvAQAGCUcjAAACAAAAADMAAQEZIwA0AAEB" +
           "MyMAAAAABGCACgEAAAABADgAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvclZhbGlkYXRpb25U" +
           "cmlnZ2VyVHJhbnNpdGlvbgEBSSMALwEABglJIwAAAgAAAAAzAAEBESMANAABARsjAAAAAARggAoBAAAA" +
           "AQA7AAAAV2FpdEZvclZhbGlkYXRpb25UcmlnZ2VyVG9FeHRyYWN0VmFsaWRhdGlvblNhbXBsZVRyYW5z" +
           "aXRpb24BAUsjAC8BAAYJSyMAAAIAAAAAMwABARsjADQAAQEdIwAAAAAEYIAKAQAAAAEAIQAAAEV4dHJh" +
           "Y3RWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBTSMALwEABglNIwAAAgAAAAAzAAEBHSMANAABAR0j" +
           "AAAAAARggAoBAAAAAQA6AAAARXh0cmFjdFZhbGlkYXRpb25TYW1wbGVUb1ByZXBhcmVWYWxpZGF0aW9u" +
           "U2FtcGxlVHJhbnNpdGlvbgEBTyMALwEABglPIwAAAgAAAAAzAAEBHSMANAABAR8jAAAAAARggAoBAAAA" +
           "AQAhAAAAUHJlcGFyZVZhbGlkYXRpb25TYW1wbGVUcmFuc2l0aW9uAQFRIwAvAQAGCVEjAAACAAAAADMA" +
           "AQEfIwA0AAEBHyMAAAAABGCACgEAAAABADoAAABQcmVwYXJlVmFsaWRhdGlvblNhbXBsZVRvQW5hbHlz" +
           "ZVZhbGlkYXRpb25TYW1wbGVUcmFuc2l0aW9uAQFTIwAvAQAGCVMjAAACAAAAADMAAQEfIwA0AAEBISMA" +
           "AAAABGCACgEAAAABACEAAABBbmFseXNlVmFsaWRhdGlvblNhbXBsZVRyYW5zaXRpb24BAVUjAC8BAAYJ" +
           "VSMAAAIAAAAAMwABASEjADQAAQEhIwAAAAAEYIAKAQAAAAEAMQAAAEFuYWx5c2VWYWxpZGF0aW9uU2Ft" +
           "cGxlVG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BAVcjAC8BAAYJVyMAAAIAAAAAMwABASEjADQAAQEz" +
           "IwAAAAAEYIAKAQAAAAEANAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yU2FtcGxlVHJpZ2dl" +
           "clRyYW5zaXRpb24BAVkjAC8BAAYJWSMAAAIAAAAAMwABAREjADQAAQEjIwAAAAAEYIAKAQAAAAEALQAA" +
           "AFdhaXRGb3JTYW1wbGVUcmlnZ2VyVG9FeHRyYWN0U2FtcGxlVHJhbnNpdGlvbgEBWyMALwEABglbIwAA" +
           "AgAAAAAzAAEBIyMANAABASUjAAAAAARggAoBAAAAAQAXAAAARXh0cmFjdFNhbXBsZVRyYW5zaXRpb24B" +
           "AV0jAC8BAAYJXSMAAAIAAAAAMwABASUjADQAAQElIwAAAAAEYIAKAQAAAAEAJgAAAEV4dHJhY3RTYW1w" +
           "bGVUb1ByZXBhcmVTYW1wbGVUcmFuc2l0aW9uAQFfIwAvAQAGCV8jAAACAAAAADMAAQElIwA0AAEBJyMA" +
           "AAAABGCACgEAAAABABcAAABQcmVwYXJlU2FtcGxlVHJhbnNpdGlvbgEBYSMALwEABglhIwAAAgAAAAAz" +
           "AAEBJyMANAABAScjAAAAAARggAoBAAAAAQAmAAAAUHJlcGFyZVNhbXBsZVRvQW5hbHlzZVNhbXBsZVRy" +
           "YW5zaXRpb24BAWMjAC8BAAYJYyMAAAIAAAAAMwABAScjADQAAQEpIwAAAAAEYIAKAQAAAAEAFwAAAEFu" +
           "YWx5c2VTYW1wbGVUcmFuc2l0aW9uAQFlIwAvAQAGCWUjAAACAAAAADMAAQEpIwA0AAEBKSMAAAAABGCA" +
           "CgEAAAABACcAAABBbmFseXNlU2FtcGxlVG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BAWcjAC8BAAYJ" +
           "ZyMAAAIAAAAAMwABASkjADQAAQEzIwAAAAAEYIAKAQAAAAEAOAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xl" +
           "VG9XYWl0Rm9yRGlhZ25vc3RpY1RyaWdnZXJUcmFuc2l0aW9uAQFpIwAvAQAGCWkjAAACAAAAADMAAQER" +
           "IwA0AAEBKyMAAAAABGCACgEAAAABAC4AAABXYWl0Rm9yRGlhZ25vc3RpY1RyaWdnZXJUb0RpYWdub3N0" +
           "aWNUcmFuc2l0aW9uAQFrIwAvAQAGCWsjAAACAAAAADMAAQErIwA0AAEBLSMAAAAABGCACgEAAAABABQA" +
           "AABEaWFnbm9zdGljVHJhbnNpdGlvbgEBbSMALwEABgltIwAAAgAAAAAzAAEBLSMANAABAS0jAAAAAARg" +
           "gAoBAAAAAQAkAAAARGlhZ25vc3RpY1RvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQFvIwAvAQAGCW8j" +
           "AAACAAAAADMAAQEtIwA0AAEBMyMAAAAABGCACgEAAAABADYAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRv" +
           "V2FpdEZvckNsZWFuaW5nVHJpZ2dlclRyYW5zaXRpb24BAXEjAC8BAAYJcSMAAAIAAAAAMwABAREjADQA" +
           "AQEvIwAAAAAEYIAKAQAAAAEAKgAAAFdhaXRGb3JDbGVhbmluZ1RyaWdnZXJUb0NsZWFuaW5nVHJhbnNp" +
           "dGlvbgEBcyMALwEABglzIwAAAgAAAAAzAAEBLyMANAABATEjAAAAAARggAoBAAAAAQASAAAAQ2xlYW5p" +
           "bmdUcmFuc2l0aW9uAQF1IwAvAQAGCXUjAAACAAAAADMAAQExIwA0AAEBMSMAAAAABGCACgEAAAABACIA" +
           "AABDbGVhbmluZ1RvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQF3IwAvAQAGCXcjAAACAAAAADMAAQEx" +
           "IwA0AAEBMyMAAAAABGCACgEAAAABAC8AAABQdWJsaXNoUmVzdWx0c1RvQ2xlYW51cFNhbXBsaW5nU3lz" +
           "dGVtVHJhbnNpdGlvbgEBeSMALwEABgl5IwAAAgAAAAAzAAEBMyMANAABATcjAAAAAARggAoBAAAAAQAp" +
           "AAAAUHVibGlzaFJlc3VsdHNUb0VqZWN0R3JhYlNhbXBsZVRyYW5zaXRpb24BAXsjAC8BAAYJeyMAAAIA" +
           "AAAAMwABATMjADQAAQE1IwAAAAAEYIAKAQAAAAEAGQAAAEVqZWN0R3JhYlNhbXBsZVRyYW5zaXRpb24B" +
           "AX0jAC8BAAYJfSMAAAIAAAAAMwABATUjADQAAQE1IwAAAAAEYIAKAQAAAAEAMAAAAEVqZWN0R3JhYlNh" +
           "bXBsZVRvQ2xlYW51cFNhbXBsaW5nU3lzdGVtVHJhbnNpdGlvbgEBfyMALwEABgl/IwAAAgAAAAAzAAEB" +
           "NSMANAABATcjAAAAAARggAoBAAAAAQAfAAAAQ2xlYW51cFNhbXBsaW5nU3lzdGVtVHJhbnNpdGlvbgEB" +
           "gSMALwEABgmBIwAAAgAAAAAzAAEBNyMANAABATcjAAAAAARggAoBAAAAAQA1AAAAQ2xlYW51cFNhbXBs" +
           "aW5nU3lzdGVtVG9TZWxlY3RFeGVjdXRpb25DeWNsZVRyYW5zaXRpb24BAYMjAC8BAAYJgyMAAAIAAAAA" +
           "MwABATcjADQAAQERIwAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the OperatingExecuteSubStateMachine Object.
        /// </summary>
        public AnalyserChannel_OperatingModeExecuteSubStateMachineState OperatingExecuteSubStateMachine
        {
            get
            { 
                return m_operatingExecuteSubStateMachine;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_operatingExecuteSubStateMachine, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_operatingExecuteSubStateMachine = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_operatingExecuteSubStateMachine != null)
            {
                children.Add(m_operatingExecuteSubStateMachine);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.OperatingExecuteSubStateMachine:
                {
                    if (createOrReplace)
                    {
                        if (OperatingExecuteSubStateMachine == null)
                        {
                            if (replacement == null)
                            {
                                OperatingExecuteSubStateMachine = new AnalyserChannel_OperatingModeExecuteSubStateMachineState(this);
                            }
                            else
                            {
                                OperatingExecuteSubStateMachine = (AnalyserChannel_OperatingModeExecuteSubStateMachineState)replacement;
                            }
                        }
                    }

                    instance = OperatingExecuteSubStateMachine;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private AnalyserChannel_OperatingModeExecuteSubStateMachineState m_operatingExecuteSubStateMachine;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannel_OperatingModeSubStateMachineState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannel_OperatingModeSubStateMachineState)
    /// <summary>
    /// Stores an instance of the AnalyserChannel_OperatingModeSubStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannel_OperatingModeSubStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannel_OperatingModeSubStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannel_OperatingModeSubStateMachineType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQA4AAAAQW5hbHlzZXJDaGFubmVsX09wZXJhdGluZ01v" +
           "ZGVTdWJTdGF0ZU1hY2hpbmVUeXBlSW5zdGFuY2UBAfADAQHwAwEKAAAAAC8AAQGzHwAvAAEBtB8ALwAB" +
           "Aa8fAC8AAQG1HwAvAAEBth8ALwABAbcfAC8AAQG4HwAvAAEBuR8ALwABAbofAC8AAQG7H0gAAAAVYIkK" +
           "AgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEBHxgALwEAyAofGAAAABX/////AQH/////AQAAABVgiQoCAAAA" +
           "AAACAAAASWQBASAYAC4ARCAYAAAAEf////8BAf////8AAAAAJGCACgEAAAABAAcAAABTdG9wcGVkAQHR" +
           "EwMAAAAASAAAAFRoaXMgaXMgdGhlIGluaXRpYWwgc3RhdGUgYWZ0ZXIgQW5hbHlzZXJEZXZpY2VTdGF0" +
           "ZU1hY2hpbmUgc3RhdGUgUG93ZXJ1cAAvAQAFCdETAAAFAAAAADMBAQFIFAA0AQEBURQANAEBAWAUADQB" +
           "AQFjFAAzAQEBcBQBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBKRgALgBEKRgAAAcAAAAAAAf/" +
           "////AQH/////AAAAACRggAoBAAAAAQAJAAAAUmVzZXR0aW5nAQHSEwMAAAAAWwAAAFRoaXMgc3RhdGUg" +
           "aXMgdGhlIHJlc3VsdCBvZiBhIFJlc2V0IG9yIFNldENvbmZpZ3VyYXRpb24gTWV0aG9kIGNhbGwgZnJv" +
           "bSB0aGUgU3RvcHBlZCBzdGF0ZS4ALwEAAwnSEwAABgAAAAA0AQEBSBQAMwEBAUkUADQBAQFJFAAzAQEB" +
           "ShQAMwEBAWQUADMBAQFxFAEAAAAVYKkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQEqGAAuAEQqGAAABwAA" +
           "AAAAB/////8BAf////8AAAAAJGCACgEAAAABAAQAAABJZGxlAQHTEwMAAAAAYwAAAFRoZSBSZXNldHRp" +
           "bmcgc3RhdGUgaXMgY29tcGxldGVkLCBhbGwgcGFyYW1ldGVycyBoYXZlIGJlZW4gY29tbWl0dGVkIGFu" +
           "ZCByZWFkeSB0byBzdGFydCBhY3F1aXNpdGlvbgAvAQADCdMTAAAEAAAAADQBAQFKFAAzAQEBSxQAMwEB" +
           "AWUUADMBAQFyFAEAAAAVYKkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQErGAAuAEQrGAAABwAAAAAAB///" +
           "//8BAf////8AAAAAJGCACgEAAAABAAgAAABTdGFydGluZwEB1BMDAAAAAHgAAABUaGUgYW5hbHlzZXIg" +
           "aGFzIHJlY2VpdmVkIHRoZSBTdGFydCBvciBTaW5nbGVBY3F1aXNpdGlvblN0YXJ0IE1ldGhvZCBjYWxs" +
           "IGFuZCBpdCBpcyBwcmVwYXJpbmcgdG8gZW50ZXIgaW4gRXhlY3V0ZSBzdGF0ZS4ALwEAAwnUEwAABgAA" +
           "AAA0AQEBSxQAMwEBAUwUADQBAQFMFAAzAQEBTRQAMwEBAWYUADMBAQFzFAEAAAAVYKkKAgAAAAAACwAA" +
           "AFN0YXRlTnVtYmVyAQEsGAAuAEQsGAAABwAAAAAAB/////8BAf////8AAAAAJGCACgEAAAABAAcAAABF" +
           "eGVjdXRlAQHVEwMAAAAAOQAAAEFsbCByZXBldGl0aXZlIGFjcXVpc2l0aW9uIGN5Y2xlcyBhcmUgZG9u" +
           "ZSBpbiB0aGlzIHN0YXRlOgAvAQEEI9UTAAAIAAAAADQBAQFNFAAzAQEBThQAMwEBAVIUADQBAQFYFAAz" +
           "AQEBWRQANAEBAV8UADMBAQFnFAAzAQEBdBQCAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBnRgA" +
           "LgBEnRgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAfAAAAT3BlcmF0aW5nRXhlY3V0ZVN1" +
           "YlN0YXRlTWFjaGluZQEBhSMALwEB8QOFIwAA/////zsAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0" +
           "ZQEBhiMALwEAyAqGIwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAYcjAC4ARIcjAAAA" +
           "Ef////8BAf////8AAAAAJGCACgEAAAABABQAAABTZWxlY3RFeGVjdXRpb25DeWNsZQEBkCMDAAAAAEgA" +
           "AABUaGlzIHBzZXVkby1zdGF0ZSBpcyB1c2VkIHRvIGRlY2lkZSB3aGljaCBleGVjdXRpb24gcGF0aCBz" +
           "aGFsbCBiZSB0YWtlbi4ALwEABQmQIwAABgAAAAAzAQEBuCMAMwEBAcgjADMBAQHYIwAzAQEB6CMAMwEB" +
           "AfAjADQBAQECJAAAAAAkYIAKAQAAAAEAGQAAAFdhaXRGb3JDYWxpYnJhdGlvblRyaWdnZXIBAZIjAwAA" +
           "AABVAAAAV2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFkeSB0byBwZXJmb3JtIHRo" +
           "ZSBDYWxpYnJhdGlvbiBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCZIjAAACAAAAADQBAQG4IwAzAQEBuiMA" +
           "AAAAJGCACgEAAAABABgAAABFeHRyYWN0Q2FsaWJyYXRpb25TYW1wbGUBAZQjAwAAAABbAAAAQ29sbGVj" +
           "dCAvIHNldHVwIHRoZSBzYW1wbGluZyBzeXN0ZW0gdG8gcGVyZm9ybSB0aGUgYWNxdWlzaXRpb24gY3lj" +
           "bGUgb2YgYSBDYWxpYnJhdGlvbiBjeWNsZQAvAQADCZQjAAAEAAAAADQBAQG6IwAzAQEBvCMANAEBAbwj" +
           "ADMBAQG+IwAAAAAkYIAKAQAAAAEAGAAAAFByZXBhcmVDYWxpYnJhdGlvblNhbXBsZQEBliMDAAAAAEUA" +
           "AABQcmVwYXJlIHRoZSBDYWxpYnJhdGlvbiBzYW1wbGUgZm9yIHRoZSBBbmFseXNlQ2FsaWJyYXRpb25T" +
           "YW1wbGUgc3RhdGUALwEAAwmWIwAABAAAAAA0AQEBviMAMwEBAcAjADQBAQHAIwAzAQEBwiMAAAAAJGCA" +
           "CgEAAAABABgAAABBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGUBAZgjAwAAAAAuAAAAUGVyZm9ybSB0aGUg" +
           "YW5hbHlzaXMgb2YgdGhlIENhbGlicmF0aW9uIFNhbXBsZQAvAQADCZgjAAAEAAAAADQBAQHCIwAzAQEB" +
           "xCMANAEBAcQjADMBAQHGIwAAAAAkYIAKAQAAAAEAGAAAAFdhaXRGb3JWYWxpZGF0aW9uVHJpZ2dlcgEB" +
           "miMDAAAAAFQAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRvIHBlcmZv" +
           "cm0gdGhlIFZhbGlkYXRpb24gYWNxdWlzaXRpb24gY3ljbGUALwEAAwmaIwAAAgAAAAA0AQEByCMAMwEB" +
           "AcojAAAAACRggAoBAAAAAQAXAAAARXh0cmFjdFZhbGlkYXRpb25TYW1wbGUBAZwjAwAAAABaAAAAQ29s" +
           "bGVjdCAvIHNldHVwIHRoZSBzYW1wbGluZyBzeXN0ZW0gdG8gcGVyZm9ybSB0aGUgYWNxdWlzaXRpb24g" +
           "Y3ljbGUgb2YgYSBWYWxpZGF0aW9uIGN5Y2xlAC8BAAMJnCMAAAQAAAAANAEBAcojADMBAQHMIwA0AQEB" +
           "zCMAMwEBAc4jAAAAACRggAoBAAAAAQAXAAAAUHJlcGFyZVZhbGlkYXRpb25TYW1wbGUBAZ4jAwAAAABD" +
           "AAAAUHJlcGFyZSB0aGUgVmFsaWRhdGlvbiBzYW1wbGUgZm9yIHRoZSBBbmFseXNlVmFsaWRhdGlvblNh" +
           "bXBsZSBzdGF0ZQAvAQADCZ4jAAAEAAAAADQBAQHOIwAzAQEB0CMANAEBAdAjADMBAQHSIwAAAAAkYIAK" +
           "AQAAAAEAFwAAAEFuYWx5c2VWYWxpZGF0aW9uU2FtcGxlAQGgIwMAAAAALQAAAFBlcmZvcm0gdGhlIGFu" +
           "YWx5c2lzIG9mIHRoZSBWYWxpZGF0aW9uIFNhbXBsZQAvAQADCaAjAAAEAAAAADQBAQHSIwAzAQEB1CMA" +
           "NAEBAdQjADMBAQHWIwAAAAAkYIAKAQAAAAEAFAAAAFdhaXRGb3JTYW1wbGVUcmlnZ2VyAQGiIwMAAAAA" +
           "UAAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9ybSB0aGUg" +
           "U2FtcGxlIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJoiMAAAIAAAAANAEBAdgjADMBAQHaIwAAAAAkYIAK" +
           "AQAAAAEADQAAAEV4dHJhY3RTYW1wbGUBAaQjAwAAAAAjAAAAQ29sbGVjdCB0aGUgU2FtcGxlIGZyb20g" +
           "dGhlIHByb2Nlc3MALwEAAwmkIwAABAAAAAA0AQEB2iMAMwEBAdwjADQBAQHcIwAzAQEB3iMAAAAAJGCA" +
           "CgEAAAABAA0AAABQcmVwYXJlU2FtcGxlAQGmIwMAAAAALgAAAFByZXBhcmUgdGhlIFNhbXBsZSBmb3Ig" +
           "dGhlIEFuYWx5c2VTYW1wbGUgc3RhdGUALwEAAwmmIwAABAAAAAA0AQEB3iMAMwEBAeAjADQBAQHgIwAz" +
           "AQEB4iMAAAAAJGCACgEAAAABAA0AAABBbmFseXNlU2FtcGxlAQGoIwMAAAAAIgAAAFBlcmZvcm0gdGhl" +
           "IGFuYWx5c2lzIG9mIHRoZSBTYW1wbGUALwEAAwmoIwAABAAAAAA0AQEB4iMAMwEBAeQjADQBAQHkIwAz" +
           "AQEB5iMAAAAAJGCACgEAAAABABgAAABXYWl0Rm9yRGlhZ25vc3RpY1RyaWdnZXIBAaojAwAAAABJAAAA" +
           "V2FpdCB1bnRpbCB0aGUgYW5hbHlzZXIgY2hhbm5lbCBpcyByZWFkeSB0byBwZXJmb3JtIHRoZSBkaWFn" +
           "bm9zdGljIGN5Y2xlLAAvAQADCaojAAACAAAAADQBAQHoIwAzAQEB6iMAAAAAJGCACgEAAAABAAoAAABE" +
           "aWFnbm9zdGljAQGsIwMAAAAAHQAAAFBlcmZvcm0gdGhlIGRpYWdub3N0aWMgY3ljbGUuAC8BAAMJrCMA" +
           "AAQAAAAANAEBAeojADMBAQHsIwA0AQEB7CMAMwEBAe4jAAAAACRggAoBAAAAAQAWAAAAV2FpdEZvckNs" +
           "ZWFuaW5nVHJpZ2dlcgEBriMDAAAAAEcAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlz" +
           "IHJlYWR5IHRvIHBlcmZvcm0gdGhlIGNsZWFuaW5nIGN5Y2xlLAAvAQADCa4jAAACAAAAADQBAQHwIwAz" +
           "AQEB8iMAAAAAJGCACgEAAAABAAgAAABDbGVhbmluZwEBsCMDAAAAABsAAABQZXJmb3JtIHRoZSBjbGVh" +
           "bmluZyBjeWNsZS4ALwEAAwmwIwAABAAAAAA0AQEB8iMAMwEBAfQjADQBAQH0IwAzAQEB9iMAAAAAJGCA" +
           "CgEAAAABAA4AAABQdWJsaXNoUmVzdWx0cwEBsiMDAAAAADUAAABQdWJsaXNoIHRoZSByZXN1bHRzIG9m" +
           "IHRoZSBwcmV2aW91cyBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCbIjAAAHAAAAADQBAQHGIwA0AQEB1iMA" +
           "NAEBAeYjADQBAQHuIwA0AQEB9iMAMwEBAfgjADMBAQH6IwAAAAAkYIAKAQAAAAEADwAAAEVqZWN0R3Jh" +
           "YlNhbXBsZQEBtCMDAAAAAG8AAABUaGUgU2FtcGxlIHRoYXQgd2FzIGp1c3QgYW5hbHlzZWQgaXMgZWpl" +
           "Y3RlZCBmcm9tIHRoZSBzeXN0ZW0gdG8gYWxsb3cgdGhlIG9wZXJhdG9yIG9yIGFub3RoZXIgc3lzdGVt" +
           "IHRvIGdyYWIgaXQALwEAAwm0IwAABAAAAAA0AQEB+iMAMwEBAfwjADQBAQH8IwAzAQEB/iMAAAAAJGCA" +
           "CgEAAAABABUAAABDbGVhbnVwU2FtcGxpbmdTeXN0ZW0BAbYjAwAAAABEAAAAQ2xlYW51cCB0aGUgc2Ft" +
           "cGxpbmcgc3ViLXN5c3RlbSB0byBiZSByZWFkeSBmb3IgdGhlIG5leHQgYWNxdWlzaXRpb24ALwEAAwm2" +
           "IwAABQAAAAA0AQEB+CMANAEBAf4jADMBAQEAJAA0AQEBACQAMwEBAQIkAAAAAARggAoBAAAAAQA5AAAA" +
           "U2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JDYWxpYnJhdGlvblRyaWdnZXJUcmFuc2l0aW9uAQG4" +
           "IwAvAQAGCbgjAAACAAAAADMAAQGQIwA0AAEBkiMAAAAABGCACgEAAAABAD0AAABXYWl0Rm9yQ2FsaWJy" +
           "YXRpb25UcmlnZ2VyVG9FeHRyYWN0Q2FsaWJyYXRpb25TYW1wbGVUcmFuc2l0aW9uAQG6IwAvAQAGCboj" +
           "AAACAAAAADMAAQGSIwA0AAEBlCMAAAAABGCACgEAAAABACIAAABFeHRyYWN0Q2FsaWJyYXRpb25TYW1w" +
           "bGVUcmFuc2l0aW9uAQG8IwAvAQAGCbwjAAACAAAAADMAAQGUIwA0AAEBlCMAAAAABGCACgEAAAABADwA" +
           "AABFeHRyYWN0Q2FsaWJyYXRpb25TYW1wbGVUb1ByZXBhcmVDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRp" +
           "b24BAb4jAC8BAAYJviMAAAIAAAAAMwABAZQjADQAAQGWIwAAAAAEYIAKAQAAAAEAIgAAAFByZXBhcmVD" +
           "YWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BAcAjAC8BAAYJwCMAAAIAAAAAMwABAZYjADQAAQGWIwAA" +
           "AAAEYIAKAQAAAAEAPAAAAFByZXBhcmVDYWxpYnJhdGlvblNhbXBsZVRvQW5hbHlzZUNhbGlicmF0aW9u" +
           "U2FtcGxlVHJhbnNpdGlvbgEBwiMALwEABgnCIwAAAgAAAAAzAAEBliMANAABAZgjAAAAAARggAoBAAAA" +
           "AQAiAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBxCMALwEABgnEIwAAAgAAAAAz" +
           "AAEBmCMANAABAZgjAAAAAARggAoBAAAAAQAyAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxlVG9QdWJs" +
           "aXNoUmVzdWx0c1RyYW5zaXRpb24BAcYjAC8BAAYJxiMAAAIAAAAAMwABAZgjADQAAQGyIwAAAAAEYIAK" +
           "AQAAAAEAOAAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yVmFsaWRhdGlvblRyaWdnZXJUcmFu" +
           "c2l0aW9uAQHIIwAvAQAGCcgjAAACAAAAADMAAQGQIwA0AAEBmiMAAAAABGCACgEAAAABADsAAABXYWl0" +
           "Rm9yVmFsaWRhdGlvblRyaWdnZXJUb0V4dHJhY3RWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEByiMA" +
           "LwEABgnKIwAAAgAAAAAzAAEBmiMANAABAZwjAAAAAARggAoBAAAAAQAhAAAARXh0cmFjdFZhbGlkYXRp" +
           "b25TYW1wbGVUcmFuc2l0aW9uAQHMIwAvAQAGCcwjAAACAAAAADMAAQGcIwA0AAEBnCMAAAAABGCACgEA" +
           "AAABADoAAABFeHRyYWN0VmFsaWRhdGlvblNhbXBsZVRvUHJlcGFyZVZhbGlkYXRpb25TYW1wbGVUcmFu" +
           "c2l0aW9uAQHOIwAvAQAGCc4jAAACAAAAADMAAQGcIwA0AAEBniMAAAAABGCACgEAAAABACEAAABQcmVw" +
           "YXJlVmFsaWRhdGlvblNhbXBsZVRyYW5zaXRpb24BAdAjAC8BAAYJ0CMAAAIAAAAAMwABAZ4jADQAAQGe" +
           "IwAAAAAEYIAKAQAAAAEAOgAAAFByZXBhcmVWYWxpZGF0aW9uU2FtcGxlVG9BbmFseXNlVmFsaWRhdGlv" +
           "blNhbXBsZVRyYW5zaXRpb24BAdIjAC8BAAYJ0iMAAAIAAAAAMwABAZ4jADQAAQGgIwAAAAAEYIAKAQAA" +
           "AAEAIQAAAEFuYWx5c2VWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEB1CMALwEABgnUIwAAAgAAAAAz" +
           "AAEBoCMANAABAaAjAAAAAARggAoBAAAAAQAxAAAAQW5hbHlzZVZhbGlkYXRpb25TYW1wbGVUb1B1Ymxp" +
           "c2hSZXN1bHRzVHJhbnNpdGlvbgEB1iMALwEABgnWIwAAAgAAAAAzAAEBoCMANAABAbIjAAAAAARggAoB" +
           "AAAAAQA0AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JTYW1wbGVUcmlnZ2VyVHJhbnNpdGlv" +
           "bgEB2CMALwEABgnYIwAAAgAAAAAzAAEBkCMANAABAaIjAAAAAARggAoBAAAAAQAtAAAAV2FpdEZvclNh" +
           "bXBsZVRyaWdnZXJUb0V4dHJhY3RTYW1wbGVUcmFuc2l0aW9uAQHaIwAvAQAGCdojAAACAAAAADMAAQGi" +
           "IwA0AAEBpCMAAAAABGCACgEAAAABABcAAABFeHRyYWN0U2FtcGxlVHJhbnNpdGlvbgEB3CMALwEABgnc" +
           "IwAAAgAAAAAzAAEBpCMANAABAaQjAAAAAARggAoBAAAAAQAmAAAARXh0cmFjdFNhbXBsZVRvUHJlcGFy" +
           "ZVNhbXBsZVRyYW5zaXRpb24BAd4jAC8BAAYJ3iMAAAIAAAAAMwABAaQjADQAAQGmIwAAAAAEYIAKAQAA" +
           "AAEAFwAAAFByZXBhcmVTYW1wbGVUcmFuc2l0aW9uAQHgIwAvAQAGCeAjAAACAAAAADMAAQGmIwA0AAEB" +
           "piMAAAAABGCACgEAAAABACYAAABQcmVwYXJlU2FtcGxlVG9BbmFseXNlU2FtcGxlVHJhbnNpdGlvbgEB" +
           "4iMALwEABgniIwAAAgAAAAAzAAEBpiMANAABAagjAAAAAARggAoBAAAAAQAXAAAAQW5hbHlzZVNhbXBs" +
           "ZVRyYW5zaXRpb24BAeQjAC8BAAYJ5CMAAAIAAAAAMwABAagjADQAAQGoIwAAAAAEYIAKAQAAAAEAJwAA" +
           "AEFuYWx5c2VTYW1wbGVUb1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEB5iMALwEABgnmIwAAAgAAAAAz" +
           "AAEBqCMANAABAbIjAAAAAARggAoBAAAAAQA4AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JE" +
           "aWFnbm9zdGljVHJpZ2dlclRyYW5zaXRpb24BAegjAC8BAAYJ6CMAAAIAAAAAMwABAZAjADQAAQGqIwAA" +
           "AAAEYIAKAQAAAAEALgAAAFdhaXRGb3JEaWFnbm9zdGljVHJpZ2dlclRvRGlhZ25vc3RpY1RyYW5zaXRp" +
           "b24BAeojAC8BAAYJ6iMAAAIAAAAAMwABAaojADQAAQGsIwAAAAAEYIAKAQAAAAEAFAAAAERpYWdub3N0" +
           "aWNUcmFuc2l0aW9uAQHsIwAvAQAGCewjAAACAAAAADMAAQGsIwA0AAEBrCMAAAAABGCACgEAAAABACQA" +
           "AABEaWFnbm9zdGljVG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BAe4jAC8BAAYJ7iMAAAIAAAAAMwAB" +
           "AawjADQAAQGyIwAAAAAEYIAKAQAAAAEANgAAAFNlbGVjdEV4ZWN1dGlvbkN5Y2xlVG9XYWl0Rm9yQ2xl" +
           "YW5pbmdUcmlnZ2VyVHJhbnNpdGlvbgEB8CMALwEABgnwIwAAAgAAAAAzAAEBkCMANAABAa4jAAAAAARg" +
           "gAoBAAAAAQAqAAAAV2FpdEZvckNsZWFuaW5nVHJpZ2dlclRvQ2xlYW5pbmdUcmFuc2l0aW9uAQHyIwAv" +
           "AQAGCfIjAAACAAAAADMAAQGuIwA0AAEBsCMAAAAABGCACgEAAAABABIAAABDbGVhbmluZ1RyYW5zaXRp" +
           "b24BAfQjAC8BAAYJ9CMAAAIAAAAAMwABAbAjADQAAQGwIwAAAAAEYIAKAQAAAAEAIgAAAENsZWFuaW5n" +
           "VG9QdWJsaXNoUmVzdWx0c1RyYW5zaXRpb24BAfYjAC8BAAYJ9iMAAAIAAAAAMwABAbAjADQAAQGyIwAA" +
           "AAAEYIAKAQAAAAEALwAAAFB1Ymxpc2hSZXN1bHRzVG9DbGVhbnVwU2FtcGxpbmdTeXN0ZW1UcmFuc2l0" +
           "aW9uAQH4IwAvAQAGCfgjAAACAAAAADMAAQGyIwA0AAEBtiMAAAAABGCACgEAAAABACkAAABQdWJsaXNo" +
           "UmVzdWx0c1RvRWplY3RHcmFiU2FtcGxlVHJhbnNpdGlvbgEB+iMALwEABgn6IwAAAgAAAAAzAAEBsiMA" +
           "NAABAbQjAAAAAARggAoBAAAAAQAZAAAARWplY3RHcmFiU2FtcGxlVHJhbnNpdGlvbgEB/CMALwEABgn8" +
           "IwAAAgAAAAAzAAEBtCMANAABAbQjAAAAAARggAoBAAAAAQAwAAAARWplY3RHcmFiU2FtcGxlVG9DbGVh" +
           "bnVwU2FtcGxpbmdTeXN0ZW1UcmFuc2l0aW9uAQH+IwAvAQAGCf4jAAACAAAAADMAAQG0IwA0AAEBtiMA" +
           "AAAABGCACgEAAAABAB8AAABDbGVhbnVwU2FtcGxpbmdTeXN0ZW1UcmFuc2l0aW9uAQEAJAAvAQAGCQAk" +
           "AAACAAAAADMAAQG2IwA0AAEBtiMAAAAABGCACgEAAAABADUAAABDbGVhbnVwU2FtcGxpbmdTeXN0ZW1U" +
           "b1NlbGVjdEV4ZWN1dGlvbkN5Y2xlVHJhbnNpdGlvbgEBAiQALwEABgkCJAAAAgAAAAAzAAEBtiMANAAB" +
           "AZAjAAAAACRggAoBAAAAAQAKAAAAQ29tcGxldGluZwEBPBQDAAAAAEQAAABUaGlzIHN0YXRlIGlzIGFu" +
           "IGF1dG9tYXRpYyBvciBjb21tYW5kZWQgZXhpdCBmcm9tIHRoZSBFeGVjdXRlIHN0YXRlLgAvAQADCTwU" +
           "AAAGAAAAADQBAQFOFAAzAQEBTxQANAEBAU8UADMBAQFQFAAzAQEBaBQAMwEBAXUUAQAAABVgqQoCAAAA" +
           "AAALAAAAU3RhdGVOdW1iZXIBAZ4YAC4ARJ4YAAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEA" +
           "CAAAAENvbXBsZXRlAQE9FAMAAAAAZgAAAEF0IHRoaXMgcG9pbnQsIHRoZSBDb21wbGV0aW5nIHN0YXRl" +
           "IGlzIGRvbmUgYW5kIGl0IHRyYW5zaXRpb25zIGF1dG9tYXRpY2FsbHkgdG8gU3RvcHBlZCBzdGF0ZSB0" +
           "byB3YWl0LgAvAQADCT0UAAAEAAAAADQBAQFQFAAzAQEBURQAMwEBAWkUADMBAQF2FAEAAAAVYKkKAgAA" +
           "AAAACwAAAFN0YXRlTnVtYmVyAQGfGAAuAESfGAAABwAAAAAAB/////8BAf////8AAAAAJGCACgEAAAAB" +
           "AAoAAABTdXNwZW5kaW5nAQE+FAMAAAAAYAAAAFRoaXMgc3RhdGUgaXMgYSByZXN1bHQgb2YgYSBjaGFu" +
           "Z2UgaW4gbW9uaXRvcmVkIGNvbmRpdGlvbnMgZHVlIHRvIHByb2Nlc3MgY29uZGl0aW9ucyBvciBmYWN0" +
           "b3JzLgAvAQADCT4UAAAHAAAAADQBAQFZFAAzAQEBWhQANAEBAVoUADMBAQFbFAA0AQEBXhQAMwEBAWoU" +
           "ADMBAQF3FAEAAAAVYKkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQGgGAAuAESgGAAABwAAAAAAB/////8B" +
           "Af////8AAAAAJGCACgEAAAABAAkAAABTdXNwZW5kZWQBAT8UAwAAAACnAAAAVGhlIGFuYWx5c2VyIG9y" +
           "IGNoYW5uZWwgbWF5IGJlIHJ1bm5pbmcgYnV0IG5vIHJlc3VsdHMgYXJlIGJlaW5nIGdlbmVyYXRlZCB3" +
           "aGlsZSB0aGUgYW5hbHlzZXIgb3IgY2hhbm5lbCBpcyB3YWl0aW5nIGZvciBleHRlcm5hbCBwcm9jZXNz" +
           "IGNvbmRpdGlvbnMgdG8gcmV0dXJuIHRvIG5vcm1hbC4ALwEAAwk/FAAABAAAAAA0AQEBWxQAMwEBAVwU" +
           "ADMBAQFrFAAzAQEBeBQBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBoRgALgBEoRgAAAcAAAAA" +
           "AAf/////AQH/////AAAAACRggAoBAAAAAQAMAAAAVW5zdXNwZW5kaW5nAQFAFAMAAAAAiAAAAFRoaXMg" +
           "c3RhdGUgaXMgYSByZXN1bHQgb2YgYSBkZXZpY2UgcmVxdWVzdCBmcm9tIFN1c3BlbmRlZCBzdGF0ZSB0" +
           "byB0cmFuc2l0aW9uIGJhY2sgdG8gdGhlIEV4ZWN1dGUgc3RhdGUgYnkgY2FsbGluZyB0aGUgVW5zdXNw" +
           "ZW5kIE1ldGhvZC4ALwEAAwlAFAAABwAAAAA0AQEBXBQAMwEBAV0UADQBAQFdFAAzAQEBXhQAMwEBAV8U" +
           "ADMBAQFsFAAzAQEBeRQBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBohgALgBEohgAAAcAAAAA" +
           "AAf/////AQH/////AAAAACRggAoBAAAAAQAHAAAASG9sZGluZwEBQRQDAAAAAHwAAABCcmluZ3MgdGhl" +
           "IGFuYWx5c2VyIG9yIGNoYW5uZWwgdG8gYSBjb250cm9sbGVkIHN0b3Agb3IgdG8gYSBzdGF0ZSB3aGlj" +
           "aCByZXByZXNlbnRzIEhlbGQgZm9yIHRoZSBwYXJ0aWN1bGFyIHVuaXQgY29udHJvbCBtb2RlAC8BAAMJ" +
           "QRQAAAcAAAAANAEBAVIUADMBAQFTFAA0AQEBUxQAMwEBAVQUADQBAQFXFAAzAQEBbRQAMwEBAXoUAQAA" +
           "ABVgqQoCAAAAAAALAAAAU3RhdGVOdW1iZXIBAaMYAC4ARKMYAAAHAAAAAAAH/////wEB/////wAAAAAk" +
           "YIAKAQAAAAEABAAAAEhlbGQBAUIUAwAAAABrAAAAVGhlIEhlbGQgc3RhdGUgaG9sZHMgdGhlIGFuYWx5" +
           "c2VyIG9yIGNoYW5uZWwncyBvcGVyYXRpb24uIEF0IHRoaXMgc3RhdGUsIG5vIGFjcXVpc2l0aW9uIGN5" +
           "Y2xlIGlzIHBlcmZvcm1lZC4ALwEAAwlCFAAABAAAAAA0AQEBVBQAMwEBAVUUADMBAQFuFAAzAQEBexQB" +
           "AAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBpBgALgBEpBgAAAcAAAAAAAf/////AQH/////AAAA" +
           "ACRggAoBAAAAAQAJAAAAVW5ob2xkaW5nAQFDFAMAAAAAVQAAAFRoZSBVbmhvbGRpbmcgc3RhdGUgaXMg" +
           "YSByZXNwb25zZSB0byBhbiBvcGVyYXRvciBjb21tYW5kIHRvIHJlc3VtZSB0aGUgRXhlY3V0ZSBzdGF0" +
           "ZS4ALwEAAwlDFAAABwAAAAA0AQEBVRQAMwEBAVYUADQBAQFWFAAzAQEBVxQAMwEBAVgUADMBAQFvFAAz" +
           "AQEBfBQBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBpRgALgBEpRgAAAcAAAAAAAf/////AQH/" +
           "////AAAAACRggAoBAAAAAQAIAAAAU3RvcHBpbmcBAUQUAwAAAAAsAAAASW5pdGlhdGVkIGJ5IGEgU3Rv" +
           "cCBNZXRob2QgY2FsbCwgdGhpcyBzdGF0ZToALwEAAwlEFAAADgAAAAAzAQEBYBQANAEBAWQUADQBAQFl" +
           "FAA0AQEBZhQANAEBAWcUADQBAQFoFAA0AQEBaRQANAEBAWoUADQBAQFrFAA0AQEBbBQANAEBAW0UADQB" +
           "AQFuFAA0AQEBbxQAMwEBAX0UAQAAABVgqQoCAAAAAAALAAAAU3RhdGVOdW1iZXIBAaYYAC4ARKYYAAAH" +
           "AAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEACAAAAEFib3J0aW5nAQFFFAMAAAAAdwAAAFRoZSBB" +
           "Ym9ydGluZyBzdGF0ZSBjYW4gYmUgZW50ZXJlZCBhdCBhbnkgdGltZSBpbiByZXNwb25zZSB0byB0aGUg" +
           "QWJvcnQgY29tbWFuZCBvciBvbiB0aGUgb2NjdXJyZW5jZSBvZiBhIG1hY2hpbmUgZmF1bHQuAC8BAAMJ" +
           "RRQAAA8AAAAAMwEBAWEUADQBAQFwFAA0AQEBcRQANAEBAXIUADQBAQFzFAA0AQEBdBQANAEBAXUUADQB" +
           "AQF2FAA0AQEBdxQANAEBAXgUADQBAQF5FAA0AQEBehQANAEBAXsUADQBAQF8FAA0AQEBfRQBAAAAFWCp" +
           "CgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBpxgALgBEpxgAAAcAAAAAAAf/////AQH/////AAAAACRggAoB" +
           "AAAAAQAHAAAAQWJvcnRlZAEBRhQDAAAAAFAAAABUaGlzIHN0YXRlIG1haW50YWlucyBtYWNoaW5lIHN0" +
           "YXR1cyBpbmZvcm1hdGlvbiByZWxldmFudCB0byB0aGUgQWJvcnQgY29uZGl0aW9uLgAvAQADCUYUAAAC" +
           "AAAAADQBAQFhFAAzAQEBYhQBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBqBgALgBEqBgAAAcA" +
           "AAAAAAf/////AQH/////AAAAACRggAoBAAAAAQAIAAAAQ2xlYXJpbmcBAUcUAwAAAAB8AAAAQ2xlYXJz" +
           "IGZhdWx0cyB0aGF0IG1heSBoYXZlIG9jY3VycmVkIHdoZW4gQWJvcnRpbmcgYW5kIGFyZSBwcmVzZW50" +
           "IGluIHRoZSBBYm9ydGVkIHN0YXRlIGJlZm9yZSBwcm9jZWVkaW5nIHRvIGEgU3RvcHBlZCBzdGF0ZQAv" +
           "AQADCUcUAAACAAAAADQBAQFiFAAzAQEBYxQBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBqRgA" +
           "LgBEqRgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAcAAAAU3RvcHBlZFRvUmVzZXR0aW5n" +
           "VHJhbnNpdGlvbgEBSBQALwEABglIFAAABAAAAAAzAAEB0RMANAABAdITADUAAQGzHwA1AAEBoB8BAAAA" +
           "FWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQGqGAAuAESqGAAABwAAAAAAB/////8BAf////8A" +
           "AAAABGCACgEAAAABABMAAABSZXNldHRpbmdUcmFuc2l0aW9uAQFJFAAvAQAGCUkUAAACAAAAADMAAQHS" +
           "EwA0AAEB0hMBAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQGrGAAuAESrGAAABwAAAAAA" +
           "B/////8BAf////8AAAAABGCACgEAAAABABkAAABSZXNldHRpbmdUb0lkbGVUcmFuc2l0aW9uAQFKFAAv" +
           "AQAGCUoUAAACAAAAADMAAQHSEwA0AAEB0xMBAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVy" +
           "AQGsGAAuAESsGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABgAAABJZGxlVG9TdGFydGlu" +
           "Z1RyYW5zaXRpb24BAUsUAC8BAAYJSxQAAAQAAAAAMwABAdMTADQAAQHUEwA1AAEBtB8ANQABAa8fAQAA" +
           "ABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEBrRgALgBErRgAAAcAAAAAAAf/////AQH/////" +
           "AAAAAARggAoBAAAAAQASAAAAU3RhcnRpbmdUcmFuc2l0aW9uAQFMFAAvAQAGCUwUAAACAAAAADMAAQHU" +
           "EwA0AAEB1BMBAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQGuGAAuAESuGAAABwAAAAAA" +
           "B/////8BAf////8AAAAABGCACgEAAAABABsAAABTdGFydGluZ1RvRXhlY3V0ZVRyYW5zaXRpb24BAU0U" +
           "AC8BAAYJTRQAAAIAAAAAMwABAdQTADQAAQHVEwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1i" +
           "ZXIBAa8YAC4ARK8YAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHQAAAEV4ZWN1dGVUb0Nv" +
           "bXBsZXRpbmdUcmFuc2l0aW9uAQFOFAAvAQAGCU4UAAACAAAAADMAAQHVEwA0AAEBPBQBAAAAFWCpCgIA" +
           "AAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQGwGAAuAESwGAAABwAAAAAAB/////8BAf////8AAAAABGCA" +
           "CgEAAAABABQAAABDb21wbGV0aW5nVHJhbnNpdGlvbgEBTxQALwEABglPFAAAAgAAAAAzAAEBPBQANAAB" +
           "ATwUAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEBsRgALgBEsRgAAAcAAAAAAAf/////" +
           "AQH/////AAAAAARggAoBAAAAAQAeAAAAQ29tcGxldGluZ1RvQ29tcGxldGVUcmFuc2l0aW9uAQFQFAAv" +
           "AQAGCVAUAAACAAAAADMAAQE8FAA0AAEBPRQBAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVy" +
           "AQGyGAAuAESyGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABsAAABDb21wbGV0ZVRvU3Rv" +
           "cHBlZFRyYW5zaXRpb24BAVEUAC8BAAYJURQAAAIAAAAAMwABAT0UADQAAQHREwEAAAAVYKkKAgAAAAEA" +
           "EAAAAFRyYW5zaXRpb25OdW1iZXIBAbMYAC4ARLMYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAA" +
           "AAEAGgAAAEV4ZWN1dGVUb0hvbGRpbmdUcmFuc2l0aW9uAQFSFAAvAQAGCVIUAAADAAAAADMAAQHVEwA0" +
           "AAEBQRQANQABAbYfAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEBtBgALgBEtBgAAAcA" +
           "AAAAAAf/////AQH/////AAAAAARggAoBAAAAAQARAAAASG9sZGluZ1RyYW5zaXRpb24BAVMUAC8BAAYJ" +
           "UxQAAAIAAAAAMwABAUEUADQAAQFBFAEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAbUY" +
           "AC4ARLUYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAFwAAAEhvbGRpbmdUb0hlbGRUcmFu" +
           "c2l0aW9uAQFUFAAvAQAGCVQUAAACAAAAADMAAQFBFAA0AAEBQhQBAAAAFWCpCgIAAAABABAAAABUcmFu" +
           "c2l0aW9uTnVtYmVyAQG2GAAuAES2GAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABkAAABI" +
           "ZWxkVG9VbmhvbGRpbmdUcmFuc2l0aW9uAQFVFAAvAQAGCVUUAAADAAAAADMAAQFCFAA0AAEBQxQANQAB" +
           "AbcfAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEBtxgALgBEtxgAAAcAAAAAAAf/////" +
           "AQH/////AAAAAARggAoBAAAAAQATAAAAVW5ob2xkaW5nVHJhbnNpdGlvbgEBVhQALwEABglWFAAAAgAA" +
           "AAAzAAEBQxQANAABAUMUAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEBuBgALgBEuBgA" +
           "AAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAcAAAAVW5ob2xkaW5nVG9Ib2xkaW5nVHJhbnNp" +
           "dGlvbgEBVxQALwEABglXFAAAAwAAAAAzAAEBQxQANAABAUEUADUAAQG2HwEAAAAVYKkKAgAAAAEAEAAA" +
           "AFRyYW5zaXRpb25OdW1iZXIBAbkYAC4ARLkYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEA" +
           "HAAAAFVuaG9sZGluZ1RvRXhlY3V0ZVRyYW5zaXRpb24BAVgUAC8BAAYJWBQAAAIAAAAAMwABAUMUADQA" +
           "AQHVEwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAboYAC4ARLoYAAAHAAAAAAAH////" +
           "/wEB/////wAAAAAEYIAKAQAAAAEAHQAAAEV4ZWN1dGVUb1N1c3BlbmRpbmdUcmFuc2l0aW9uAQFZFAAv" +
           "AQAGCVkUAAADAAAAADMAAQHVEwA0AAEBPhQANQABAbgfAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlv" +
           "bk51bWJlcgEBuxgALgBEuxgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAUAAAAU3VzcGVu" +
           "ZGluZ1RyYW5zaXRpb24BAVoUAC8BAAYJWhQAAAIAAAAAMwABAT4UADQAAQE+FAEAAAAVYKkKAgAAAAEA" +
           "EAAAAFRyYW5zaXRpb25OdW1iZXIBAbwYAC4ARLwYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAA" +
           "AAEAHwAAAFN1c3BlbmRpbmdUb1N1c3BlbmRlZFRyYW5zaXRpb24BAVsUAC8BAAYJWxQAAAIAAAAAMwAB" +
           "AT4UADQAAQE/FAEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAb0YAC4ARL0YAAAHAAAA" +
           "AAAH/////wEB/////wAAAAAEYIAKAQAAAAEAIQAAAFN1c3BlbmRlZFRvVW5zdXNwZW5kaW5nVHJhbnNp" +
           "dGlvbgEBXBQALwEABglcFAAAAwAAAAAzAAEBPxQANAABAUAUADUAAQG5HwEAAAAVYKkKAgAAAAEAEAAA" +
           "AFRyYW5zaXRpb25OdW1iZXIBAb4YAC4ARL4YAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEA" +
           "FgAAAFVuc3VzcGVuZGluZ1RyYW5zaXRpb24BAV0UAC8BAAYJXRQAAAIAAAAAMwABAUAUADQAAQFAFAEA" +
           "AAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAb8YAC4ARL8YAAAHAAAAAAAH/////wEB////" +
           "/wAAAAAEYIAKAQAAAAEAIgAAAFVuc3VzcGVuZGluZ1RvU3VzcGVuZGluZ1RyYW5zaXRpb24BAV4UAC8B" +
           "AAYJXhQAAAMAAAAAMwABAUAUADQAAQE+FAA1AAEBuB8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9u" +
           "TnVtYmVyAQHAGAAuAETAGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABAB8AAABVbnN1c3Bl" +
           "bmRpbmdUb0V4ZWN1dGVUcmFuc2l0aW9uAQFfFAAvAQAGCV8UAAACAAAAADMAAQFAFAA0AAEB1RMBAAAA" +
           "FWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHBGAAuAETBGAAABwAAAAAAB/////8BAf////8A" +
           "AAAABGCACgEAAAABABsAAABTdG9wcGluZ1RvU3RvcHBlZFRyYW5zaXRpb24BAWAUAC8BAAYJYBQAAAIA" +
           "AAAAMwABAUQUADQAAQHREwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAcIYAC4ARMIY" +
           "AAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAGwAAAEFib3J0aW5nVG9BYm9ydGVkVHJhbnNp" +
           "dGlvbgEBYRQALwEABglhFAAAAgAAAAAzAAEBRRQANAABAUYUAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNp" +
           "dGlvbk51bWJlcgEBwxgALgBEwxgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAbAAAAQWJv" +
           "cnRlZFRvQ2xlYXJpbmdUcmFuc2l0aW9uAQFiFAAvAQAGCWIUAAADAAAAADMAAQFGFAA0AAEBRxQANQAB" +
           "AbsfAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEBxBgALgBExBgAAAcAAAAAAAf/////" +
           "AQH/////AAAAAARggAoBAAAAAQAbAAAAQ2xlYXJpbmdUb1N0b3BwZWRUcmFuc2l0aW9uAQFjFAAvAQAG" +
           "CWMUAAACAAAAADMAAQFHFAA0AAEB0RMBAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHF" +
           "GAAuAETFGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABAB0AAABSZXNldHRpbmdUb1N0b3Bw" +
           "aW5nVHJhbnNpdGlvbgEBZBQALwEABglkFAAAAwAAAAAzAAEB0hMANAABAUQUADUAAQG1HwEAAAAVYKkK" +
           "AgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAcYYAC4ARMYYAAAHAAAAAAAH/////wEB/////wAAAAAE" +
           "YIAKAQAAAAEAGAAAAElkbGVUb1N0b3BwaW5nVHJhbnNpdGlvbgEBZRQALwEABgllFAAAAwAAAAAzAAEB" +
           "0xMANAABAUQUADUAAQG1HwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAccYAC4ARMcY" +
           "AAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHAAAAFN0YXJ0aW5nVG9TdG9wcGluZ1RyYW5z" +
           "aXRpb24BAWYUAC8BAAYJZhQAAAMAAAAAMwABAdQTADQAAQFEFAA1AAEBtR8BAAAAFWCpCgIAAAABABAA" +
           "AABUcmFuc2l0aW9uTnVtYmVyAQHIGAAuAETIGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAAB" +
           "ABsAAABFeGVjdXRlVG9TdG9wcGluZ1RyYW5zaXRpb24BAWcUAC8BAAYJZxQAAAMAAAAAMwABAdUTADQA" +
           "AQFEFAA1AAEBtR8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHJGAAuAETJGAAABwAA" +
           "AAAAB/////8BAf////8AAAAABGCACgEAAAABAB4AAABDb21wbGV0aW5nVG9TdG9wcGluZ1RyYW5zaXRp" +
           "b24BAWgUAC8BAAYJaBQAAAMAAAAAMwABATwUADQAAQFEFAA1AAEBtR8BAAAAFWCpCgIAAAABABAAAABU" +
           "cmFuc2l0aW9uTnVtYmVyAQHKGAAuAETKGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABwA" +
           "AABDb21wbGV0ZVRvU3RvcHBpbmdUcmFuc2l0aW9uAQFpFAAvAQAGCWkUAAADAAAAADMAAQE9FAA0AAEB" +
           "RBQANQABAbUfAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEByxgALgBEyxgAAAcAAAAA" +
           "AAf/////AQH/////AAAAAARggAoBAAAAAQAeAAAAU3VzcGVuZGluZ1RvU3RvcHBpbmdUcmFuc2l0aW9u" +
           "AQFqFAAvAQAGCWoUAAADAAAAADMAAQE+FAA0AAEBRBQANQABAbUfAQAAABVgqQoCAAAAAQAQAAAAVHJh" +
           "bnNpdGlvbk51bWJlcgEBzBgALgBEzBgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAdAAAA" +
           "U3VzcGVuZGVkVG9TdG9wcGluZ1RyYW5zaXRpb24BAWsUAC8BAAYJaxQAAAMAAAAAMwABAT8UADQAAQFE" +
           "FAA1AAEBtR8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHNGAAuAETNGAAABwAAAAAA" +
           "B/////8BAf////8AAAAABGCACgEAAAABACAAAABVbnN1c3BlbmRpbmdUb1N0b3BwaW5nVHJhbnNpdGlv" +
           "bgEBbBQALwEABglsFAAAAwAAAAAzAAEBQBQANAABAUQUADUAAQG1HwEAAAAVYKkKAgAAAAEAEAAAAFRy" +
           "YW5zaXRpb25OdW1iZXIBAc4YAC4ARM4YAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAGwAA" +
           "AEhvbGRpbmdUb1N0b3BwaW5nVHJhbnNpdGlvbgEBbRQALwEABgltFAAAAwAAAAAzAAEBQRQANAABAUQU" +
           "ADUAAQG1HwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAc8YAC4ARM8YAAAHAAAAAAAH" +
           "/////wEB/////wAAAAAEYIAKAQAAAAEAGAAAAEhlbGRUb1N0b3BwaW5nVHJhbnNpdGlvbgEBbhQALwEA" +
           "BgluFAAAAwAAAAAzAAEBQhQANAABAUQUADUAAQG1HwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25O" +
           "dW1iZXIBAdAYAC4ARNAYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHQAAAFVuaG9sZGlu" +
           "Z1RvU3RvcHBpbmdUcmFuc2l0aW9uAQFvFAAvAQAGCW8UAAADAAAAADMAAQFDFAA0AAEBRBQANQABAbUf" +
           "AQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEB0RgALgBE0RgAAAcAAAAAAAf/////AQH/" +
           "////AAAAAARggAoBAAAAAQAbAAAAU3RvcHBlZFRvQWJvcnRpbmdUcmFuc2l0aW9uAQFwFAAvAQAGCXAU" +
           "AAADAAAAADMAAQHREwA0AAEBRRQANQABAbofAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJl" +
           "cgEB0hgALgBE0hgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAdAAAAUmVzZXR0aW5nVG9B" +
           "Ym9ydGluZ1RyYW5zaXRpb24BAXEUAC8BAAYJcRQAAAMAAAAAMwABAdITADQAAQFFFAA1AAEBuh8BAAAA" +
           "FWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHTGAAuAETTGAAABwAAAAAAB/////8BAf////8A" +
           "AAAABGCACgEAAAABABgAAABJZGxlVG9BYm9ydGluZ1RyYW5zaXRpb24BAXIUAC8BAAYJchQAAAMAAAAA" +
           "MwABAdMTADQAAQFFFAA1AAEBuh8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHUGAAu" +
           "AETUGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABwAAABTdGFydGluZ1RvQWJvcnRpbmdU" +
           "cmFuc2l0aW9uAQFzFAAvAQAGCXMUAAADAAAAADMAAQHUEwA0AAEBRRQANQABAbofAQAAABVgqQoCAAAA" +
           "AQAQAAAAVHJhbnNpdGlvbk51bWJlcgEB1RgALgBE1RgAAAcAAAAAAAf/////AQH/////AAAAAARggAoB" +
           "AAAAAQAbAAAARXhlY3V0ZVRvQWJvcnRpbmdUcmFuc2l0aW9uAQF0FAAvAQAGCXQUAAADAAAAADMAAQHV" +
           "EwA0AAEBRRQANQABAbofAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEB1hgALgBE1hgA" +
           "AAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAeAAAAQ29tcGxldGluZ1RvQWJvcnRpbmdUcmFu" +
           "c2l0aW9uAQF1FAAvAQAGCXUUAAADAAAAADMAAQE8FAA0AAEBRRQANQABAbofAQAAABVgqQoCAAAAAQAQ" +
           "AAAAVHJhbnNpdGlvbk51bWJlcgEB1xgALgBE1xgAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAA" +
           "AQAcAAAAQ29tcGxldGVUb0Fib3J0aW5nVHJhbnNpdGlvbgEBdhQALwEABgl2FAAAAwAAAAAzAAEBPRQA" +
           "NAABAUUUADUAAQG6HwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAdgYAC4ARNgYAAAH" +
           "AAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHgAAAFN1c3BlbmRpbmdUb0Fib3J0aW5nVHJhbnNp" +
           "dGlvbgEBdxQALwEABgl3FAAAAwAAAAAzAAEBPhQANAABAUUUADUAAQG6HwEAAAAVYKkKAgAAAAEAEAAA" +
           "AFRyYW5zaXRpb25OdW1iZXIBAdkYAC4ARNkYAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEA" +
           "HQAAAFN1c3BlbmRlZFRvQWJvcnRpbmdUcmFuc2l0aW9uAQF4FAAvAQAGCXgUAAADAAAAADMAAQE/FAA0" +
           "AAEBRRQANQABAbofAQAAABVgqQoCAAAAAQAQAAAAVHJhbnNpdGlvbk51bWJlcgEB2hgALgBE2hgAAAcA" +
           "AAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAgAAAAVW5zdXNwZW5kaW5nVG9BYm9ydGluZ1RyYW5z" +
           "aXRpb24BAXkUAC8BAAYJeRQAAAMAAAAAMwABAUAUADQAAQFFFAA1AAEBuh8BAAAAFWCpCgIAAAABABAA" +
           "AABUcmFuc2l0aW9uTnVtYmVyAQHbGAAuAETbGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAAB" +
           "ABsAAABIb2xkaW5nVG9BYm9ydGluZ1RyYW5zaXRpb24BAXoUAC8BAAYJehQAAAMAAAAAMwABAUEUADQA" +
           "AQFFFAA1AAEBuh8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9uTnVtYmVyAQHcGAAuAETcGAAABwAA" +
           "AAAAB/////8BAf////8AAAAABGCACgEAAAABABgAAABIZWxkVG9BYm9ydGluZ1RyYW5zaXRpb24BAXsU" +
           "AC8BAAYJexQAAAMAAAAAMwABAUIUADQAAQFFFAA1AAEBuh8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0" +
           "aW9uTnVtYmVyAQHdGAAuAETdGAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABAB0AAABVbmhv" +
           "bGRpbmdUb0Fib3J0aW5nVHJhbnNpdGlvbgEBfBQALwEABgl8FAAAAwAAAAAzAAEBQxQANAABAUUUADUA" +
           "AQG6HwEAAAAVYKkKAgAAAAEAEAAAAFRyYW5zaXRpb25OdW1iZXIBAd4YAC4ARN4YAAAHAAAAAAAH////" +
           "/wEB/////wAAAAAEYIAKAQAAAAEAHAAAAFN0b3BwaW5nVG9BYm9ydGluZ1RyYW5zaXRpb24BAX0UAC8B" +
           "AAYJfRQAAAMAAAAAMwABAUQUADQAAQFFFAA1AAEBuh8BAAAAFWCpCgIAAAABABAAAABUcmFuc2l0aW9u" +
           "TnVtYmVyAQHfGAAuAETfGAAABwAAAAAAB/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// This is the initial state after AnalyserDeviceStateMachine state Powerup
        /// </summary>
        public StateMachineInitialStateState Stopped
        {
            get
            { 
                return m_stopped;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_stopped, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stopped = value;
            }
        }

        /// <summary>
        /// This state is the result of a Reset or SetConfiguration Method call from the Stopped state.
        /// </summary>
        public StateMachineStateState Resetting
        {
            get
            { 
                return m_resetting;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_resetting, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resetting = value;
            }
        }

        /// <summary>
        /// The Resetting state is completed, all parameters have been committed and ready to start acquisition
        /// </summary>
        public StateMachineStateState Idle
        {
            get
            { 
                return m_idle;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_idle, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_idle = value;
            }
        }

        /// <summary>
        /// The analyser has received the Start or SingleAcquisitionStart Method call and it is preparing to enter in Execute state.
        /// </summary>
        public StateMachineStateState Starting
        {
            get
            { 
                return m_starting;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_starting, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_starting = value;
            }
        }

        /// <summary>
        /// All repetitive acquisition cycles are done in this state:
        /// </summary>
        public AnalyserChannelOperatingExecuteStateState Execute
        {
            get
            { 
                return m_execute;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_execute, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_execute = value;
            }
        }

        /// <summary>
        /// This state is an automatic or commanded exit from the Execute state.
        /// </summary>
        public StateMachineStateState Completing
        {
            get
            { 
                return m_completing;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completing, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completing = value;
            }
        }

        /// <summary>
        /// At this point, the Completing state is done and it transitions automatically to Stopped state to wait.
        /// </summary>
        public StateMachineStateState Complete
        {
            get
            { 
                return m_complete;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_complete, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_complete = value;
            }
        }

        /// <summary>
        /// This state is a result of a change in monitored conditions due to process conditions or factors.
        /// </summary>
        public StateMachineStateState Suspending
        {
            get
            { 
                return m_suspending;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspending, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspending = value;
            }
        }

        /// <summary>
        /// The analyser or channel may be running but no results are being generated while the analyser or channel is waiting for external process conditions to return to normal.
        /// </summary>
        public StateMachineStateState Suspended
        {
            get
            { 
                return m_suspended;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspended, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspended = value;
            }
        }

        /// <summary>
        /// This state is a result of a device request from Suspended state to transition back to the Execute state by calling the Unsuspend Method.
        /// </summary>
        public StateMachineStateState Unsuspending
        {
            get
            { 
                return m_unsuspending;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unsuspending, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unsuspending = value;
            }
        }

        /// <summary>
        /// Brings the analyser or channel to a controlled stop or to a state which represents Held for the particular unit control mode
        /// </summary>
        public StateMachineStateState Holding
        {
            get
            { 
                return m_holding;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_holding, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_holding = value;
            }
        }

        /// <summary>
        /// The Held state holds the analyser or channel's operation. At this state, no acquisition cycle is performed.
        /// </summary>
        public StateMachineStateState Held
        {
            get
            { 
                return m_held;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_held, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_held = value;
            }
        }

        /// <summary>
        /// The Unholding state is a response to an operator command to resume the Execute state.
        /// </summary>
        public StateMachineStateState Unholding
        {
            get
            { 
                return m_unholding;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unholding, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unholding = value;
            }
        }

        /// <summary>
        /// Initiated by a Stop Method call, this state:
        /// </summary>
        public StateMachineStateState Stopping
        {
            get
            { 
                return m_stopping;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_stopping, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stopping = value;
            }
        }

        /// <summary>
        /// The Aborting state can be entered at any time in response to the Abort command or on the occurrence of a machine fault.
        /// </summary>
        public StateMachineStateState Aborting
        {
            get
            { 
                return m_aborting;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_aborting, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_aborting = value;
            }
        }

        /// <summary>
        /// This state maintains machine status information relevant to the Abort condition.
        /// </summary>
        public StateMachineStateState Aborted
        {
            get
            { 
                return m_aborted;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_aborted, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_aborted = value;
            }
        }

        /// <summary>
        /// Clears faults that may have occurred when Aborting and are present in the Aborted state before proceeding to a Stopped state
        /// </summary>
        public StateMachineStateState Clearing
        {
            get
            { 
                return m_clearing;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_clearing, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_clearing = value;
            }
        }

        /// <summary>
        /// A description for the StoppedToResettingTransition Object.
        /// </summary>
        public StateMachineTransitionState StoppedToResettingTransition
        {
            get
            { 
                return m_stoppedToResettingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_stoppedToResettingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stoppedToResettingTransition = value;
            }
        }

        /// <summary>
        /// A description for the ResettingTransition Object.
        /// </summary>
        public StateMachineTransitionState ResettingTransition
        {
            get
            { 
                return m_resettingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_resettingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resettingTransition = value;
            }
        }

        /// <summary>
        /// A description for the ResettingToIdleTransition Object.
        /// </summary>
        public StateMachineTransitionState ResettingToIdleTransition
        {
            get
            { 
                return m_resettingToIdleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_resettingToIdleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resettingToIdleTransition = value;
            }
        }

        /// <summary>
        /// A description for the IdleToStartingTransition Object.
        /// </summary>
        public StateMachineTransitionState IdleToStartingTransition
        {
            get
            { 
                return m_idleToStartingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_idleToStartingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_idleToStartingTransition = value;
            }
        }

        /// <summary>
        /// A description for the StartingTransition Object.
        /// </summary>
        public StateMachineTransitionState StartingTransition
        {
            get
            { 
                return m_startingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_startingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startingTransition = value;
            }
        }

        /// <summary>
        /// A description for the StartingToExecuteTransition Object.
        /// </summary>
        public StateMachineTransitionState StartingToExecuteTransition
        {
            get
            { 
                return m_startingToExecuteTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_startingToExecuteTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startingToExecuteTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExecuteToCompletingTransition Object.
        /// </summary>
        public StateMachineTransitionState ExecuteToCompletingTransition
        {
            get
            { 
                return m_executeToCompletingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_executeToCompletingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_executeToCompletingTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompletingTransition Object.
        /// </summary>
        public StateMachineTransitionState CompletingTransition
        {
            get
            { 
                return m_completingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completingTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompletingToCompleteTransition Object.
        /// </summary>
        public StateMachineTransitionState CompletingToCompleteTransition
        {
            get
            { 
                return m_completingToCompleteTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completingToCompleteTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completingToCompleteTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompleteToStoppedTransition Object.
        /// </summary>
        public StateMachineTransitionState CompleteToStoppedTransition
        {
            get
            { 
                return m_completeToStoppedTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completeToStoppedTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completeToStoppedTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExecuteToHoldingTransition Object.
        /// </summary>
        public StateMachineTransitionState ExecuteToHoldingTransition
        {
            get
            { 
                return m_executeToHoldingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_executeToHoldingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_executeToHoldingTransition = value;
            }
        }

        /// <summary>
        /// A description for the HoldingTransition Object.
        /// </summary>
        public StateMachineTransitionState HoldingTransition
        {
            get
            { 
                return m_holdingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_holdingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_holdingTransition = value;
            }
        }

        /// <summary>
        /// A description for the HoldingToHeldTransition Object.
        /// </summary>
        public StateMachineTransitionState HoldingToHeldTransition
        {
            get
            { 
                return m_holdingToHeldTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_holdingToHeldTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_holdingToHeldTransition = value;
            }
        }

        /// <summary>
        /// A description for the HeldToUnholdingTransition Object.
        /// </summary>
        public StateMachineTransitionState HeldToUnholdingTransition
        {
            get
            { 
                return m_heldToUnholdingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_heldToUnholdingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_heldToUnholdingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnholdingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnholdingTransition
        {
            get
            { 
                return m_unholdingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unholdingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unholdingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnholdingToHoldingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnholdingToHoldingTransition
        {
            get
            { 
                return m_unholdingToHoldingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unholdingToHoldingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unholdingToHoldingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnholdingToExecuteTransition Object.
        /// </summary>
        public StateMachineTransitionState UnholdingToExecuteTransition
        {
            get
            { 
                return m_unholdingToExecuteTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unholdingToExecuteTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unholdingToExecuteTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExecuteToSuspendingTransition Object.
        /// </summary>
        public StateMachineTransitionState ExecuteToSuspendingTransition
        {
            get
            { 
                return m_executeToSuspendingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_executeToSuspendingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_executeToSuspendingTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendingTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendingTransition
        {
            get
            { 
                return m_suspendingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendingTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendingToSuspendedTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendingToSuspendedTransition
        {
            get
            { 
                return m_suspendingToSuspendedTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendingToSuspendedTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendingToSuspendedTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendedToUnsuspendingTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendedToUnsuspendingTransition
        {
            get
            { 
                return m_suspendedToUnsuspendingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendedToUnsuspendingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendedToUnsuspendingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnsuspendingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnsuspendingTransition
        {
            get
            { 
                return m_unsuspendingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unsuspendingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unsuspendingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnsuspendingToSuspendingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnsuspendingToSuspendingTransition
        {
            get
            { 
                return m_unsuspendingToSuspendingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unsuspendingToSuspendingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unsuspendingToSuspendingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnsuspendingToExecuteTransition Object.
        /// </summary>
        public StateMachineTransitionState UnsuspendingToExecuteTransition
        {
            get
            { 
                return m_unsuspendingToExecuteTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unsuspendingToExecuteTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unsuspendingToExecuteTransition = value;
            }
        }

        /// <summary>
        /// A description for the StoppingToStoppedTransition Object.
        /// </summary>
        public StateMachineTransitionState StoppingToStoppedTransition
        {
            get
            { 
                return m_stoppingToStoppedTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_stoppingToStoppedTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stoppingToStoppedTransition = value;
            }
        }

        /// <summary>
        /// A description for the AbortingToAbortedTransition Object.
        /// </summary>
        public StateMachineTransitionState AbortingToAbortedTransition
        {
            get
            { 
                return m_abortingToAbortedTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_abortingToAbortedTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_abortingToAbortedTransition = value;
            }
        }

        /// <summary>
        /// A description for the AbortedToClearingTransition Object.
        /// </summary>
        public StateMachineTransitionState AbortedToClearingTransition
        {
            get
            { 
                return m_abortedToClearingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_abortedToClearingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_abortedToClearingTransition = value;
            }
        }

        /// <summary>
        /// A description for the ClearingToStoppedTransition Object.
        /// </summary>
        public StateMachineTransitionState ClearingToStoppedTransition
        {
            get
            { 
                return m_clearingToStoppedTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_clearingToStoppedTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_clearingToStoppedTransition = value;
            }
        }

        /// <summary>
        /// A description for the ResettingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState ResettingToStoppingTransition
        {
            get
            { 
                return m_resettingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_resettingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resettingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the IdleToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState IdleToStoppingTransition
        {
            get
            { 
                return m_idleToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_idleToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_idleToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the StartingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState StartingToStoppingTransition
        {
            get
            { 
                return m_startingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_startingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExecuteToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState ExecuteToStoppingTransition
        {
            get
            { 
                return m_executeToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_executeToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_executeToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompletingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState CompletingToStoppingTransition
        {
            get
            { 
                return m_completingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompleteToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState CompleteToStoppingTransition
        {
            get
            { 
                return m_completeToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completeToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completeToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendingToStoppingTransition
        {
            get
            { 
                return m_suspendingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendedToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendedToStoppingTransition
        {
            get
            { 
                return m_suspendedToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendedToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendedToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnsuspendingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnsuspendingToStoppingTransition
        {
            get
            { 
                return m_unsuspendingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unsuspendingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unsuspendingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the HoldingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState HoldingToStoppingTransition
        {
            get
            { 
                return m_holdingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_holdingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_holdingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the HeldToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState HeldToStoppingTransition
        {
            get
            { 
                return m_heldToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_heldToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_heldToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnholdingToStoppingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnholdingToStoppingTransition
        {
            get
            { 
                return m_unholdingToStoppingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unholdingToStoppingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unholdingToStoppingTransition = value;
            }
        }

        /// <summary>
        /// A description for the StoppedToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState StoppedToAbortingTransition
        {
            get
            { 
                return m_stoppedToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_stoppedToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stoppedToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the ResettingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState ResettingToAbortingTransition
        {
            get
            { 
                return m_resettingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_resettingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_resettingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the IdleToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState IdleToAbortingTransition
        {
            get
            { 
                return m_idleToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_idleToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_idleToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the StartingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState StartingToAbortingTransition
        {
            get
            { 
                return m_startingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_startingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_startingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExecuteToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState ExecuteToAbortingTransition
        {
            get
            { 
                return m_executeToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_executeToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_executeToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompletingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState CompletingToAbortingTransition
        {
            get
            { 
                return m_completingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the CompleteToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState CompleteToAbortingTransition
        {
            get
            { 
                return m_completeToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_completeToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_completeToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendingToAbortingTransition
        {
            get
            { 
                return m_suspendingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the SuspendedToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState SuspendedToAbortingTransition
        {
            get
            { 
                return m_suspendedToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_suspendedToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_suspendedToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnsuspendingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnsuspendingToAbortingTransition
        {
            get
            { 
                return m_unsuspendingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unsuspendingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unsuspendingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the HoldingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState HoldingToAbortingTransition
        {
            get
            { 
                return m_holdingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_holdingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_holdingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the HeldToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState HeldToAbortingTransition
        {
            get
            { 
                return m_heldToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_heldToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_heldToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the UnholdingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState UnholdingToAbortingTransition
        {
            get
            { 
                return m_unholdingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_unholdingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unholdingToAbortingTransition = value;
            }
        }

        /// <summary>
        /// A description for the StoppingToAbortingTransition Object.
        /// </summary>
        public StateMachineTransitionState StoppingToAbortingTransition
        {
            get
            { 
                return m_stoppingToAbortingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_stoppingToAbortingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_stoppingToAbortingTransition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_stopped != null)
            {
                children.Add(m_stopped);
            }

            if (m_resetting != null)
            {
                children.Add(m_resetting);
            }

            if (m_idle != null)
            {
                children.Add(m_idle);
            }

            if (m_starting != null)
            {
                children.Add(m_starting);
            }

            if (m_execute != null)
            {
                children.Add(m_execute);
            }

            if (m_completing != null)
            {
                children.Add(m_completing);
            }

            if (m_complete != null)
            {
                children.Add(m_complete);
            }

            if (m_suspending != null)
            {
                children.Add(m_suspending);
            }

            if (m_suspended != null)
            {
                children.Add(m_suspended);
            }

            if (m_unsuspending != null)
            {
                children.Add(m_unsuspending);
            }

            if (m_holding != null)
            {
                children.Add(m_holding);
            }

            if (m_held != null)
            {
                children.Add(m_held);
            }

            if (m_unholding != null)
            {
                children.Add(m_unholding);
            }

            if (m_stopping != null)
            {
                children.Add(m_stopping);
            }

            if (m_aborting != null)
            {
                children.Add(m_aborting);
            }

            if (m_aborted != null)
            {
                children.Add(m_aborted);
            }

            if (m_clearing != null)
            {
                children.Add(m_clearing);
            }

            if (m_stoppedToResettingTransition != null)
            {
                children.Add(m_stoppedToResettingTransition);
            }

            if (m_resettingTransition != null)
            {
                children.Add(m_resettingTransition);
            }

            if (m_resettingToIdleTransition != null)
            {
                children.Add(m_resettingToIdleTransition);
            }

            if (m_idleToStartingTransition != null)
            {
                children.Add(m_idleToStartingTransition);
            }

            if (m_startingTransition != null)
            {
                children.Add(m_startingTransition);
            }

            if (m_startingToExecuteTransition != null)
            {
                children.Add(m_startingToExecuteTransition);
            }

            if (m_executeToCompletingTransition != null)
            {
                children.Add(m_executeToCompletingTransition);
            }

            if (m_completingTransition != null)
            {
                children.Add(m_completingTransition);
            }

            if (m_completingToCompleteTransition != null)
            {
                children.Add(m_completingToCompleteTransition);
            }

            if (m_completeToStoppedTransition != null)
            {
                children.Add(m_completeToStoppedTransition);
            }

            if (m_executeToHoldingTransition != null)
            {
                children.Add(m_executeToHoldingTransition);
            }

            if (m_holdingTransition != null)
            {
                children.Add(m_holdingTransition);
            }

            if (m_holdingToHeldTransition != null)
            {
                children.Add(m_holdingToHeldTransition);
            }

            if (m_heldToUnholdingTransition != null)
            {
                children.Add(m_heldToUnholdingTransition);
            }

            if (m_unholdingTransition != null)
            {
                children.Add(m_unholdingTransition);
            }

            if (m_unholdingToHoldingTransition != null)
            {
                children.Add(m_unholdingToHoldingTransition);
            }

            if (m_unholdingToExecuteTransition != null)
            {
                children.Add(m_unholdingToExecuteTransition);
            }

            if (m_executeToSuspendingTransition != null)
            {
                children.Add(m_executeToSuspendingTransition);
            }

            if (m_suspendingTransition != null)
            {
                children.Add(m_suspendingTransition);
            }

            if (m_suspendingToSuspendedTransition != null)
            {
                children.Add(m_suspendingToSuspendedTransition);
            }

            if (m_suspendedToUnsuspendingTransition != null)
            {
                children.Add(m_suspendedToUnsuspendingTransition);
            }

            if (m_unsuspendingTransition != null)
            {
                children.Add(m_unsuspendingTransition);
            }

            if (m_unsuspendingToSuspendingTransition != null)
            {
                children.Add(m_unsuspendingToSuspendingTransition);
            }

            if (m_unsuspendingToExecuteTransition != null)
            {
                children.Add(m_unsuspendingToExecuteTransition);
            }

            if (m_stoppingToStoppedTransition != null)
            {
                children.Add(m_stoppingToStoppedTransition);
            }

            if (m_abortingToAbortedTransition != null)
            {
                children.Add(m_abortingToAbortedTransition);
            }

            if (m_abortedToClearingTransition != null)
            {
                children.Add(m_abortedToClearingTransition);
            }

            if (m_clearingToStoppedTransition != null)
            {
                children.Add(m_clearingToStoppedTransition);
            }

            if (m_resettingToStoppingTransition != null)
            {
                children.Add(m_resettingToStoppingTransition);
            }

            if (m_idleToStoppingTransition != null)
            {
                children.Add(m_idleToStoppingTransition);
            }

            if (m_startingToStoppingTransition != null)
            {
                children.Add(m_startingToStoppingTransition);
            }

            if (m_executeToStoppingTransition != null)
            {
                children.Add(m_executeToStoppingTransition);
            }

            if (m_completingToStoppingTransition != null)
            {
                children.Add(m_completingToStoppingTransition);
            }

            if (m_completeToStoppingTransition != null)
            {
                children.Add(m_completeToStoppingTransition);
            }

            if (m_suspendingToStoppingTransition != null)
            {
                children.Add(m_suspendingToStoppingTransition);
            }

            if (m_suspendedToStoppingTransition != null)
            {
                children.Add(m_suspendedToStoppingTransition);
            }

            if (m_unsuspendingToStoppingTransition != null)
            {
                children.Add(m_unsuspendingToStoppingTransition);
            }

            if (m_holdingToStoppingTransition != null)
            {
                children.Add(m_holdingToStoppingTransition);
            }

            if (m_heldToStoppingTransition != null)
            {
                children.Add(m_heldToStoppingTransition);
            }

            if (m_unholdingToStoppingTransition != null)
            {
                children.Add(m_unholdingToStoppingTransition);
            }

            if (m_stoppedToAbortingTransition != null)
            {
                children.Add(m_stoppedToAbortingTransition);
            }

            if (m_resettingToAbortingTransition != null)
            {
                children.Add(m_resettingToAbortingTransition);
            }

            if (m_idleToAbortingTransition != null)
            {
                children.Add(m_idleToAbortingTransition);
            }

            if (m_startingToAbortingTransition != null)
            {
                children.Add(m_startingToAbortingTransition);
            }

            if (m_executeToAbortingTransition != null)
            {
                children.Add(m_executeToAbortingTransition);
            }

            if (m_completingToAbortingTransition != null)
            {
                children.Add(m_completingToAbortingTransition);
            }

            if (m_completeToAbortingTransition != null)
            {
                children.Add(m_completeToAbortingTransition);
            }

            if (m_suspendingToAbortingTransition != null)
            {
                children.Add(m_suspendingToAbortingTransition);
            }

            if (m_suspendedToAbortingTransition != null)
            {
                children.Add(m_suspendedToAbortingTransition);
            }

            if (m_unsuspendingToAbortingTransition != null)
            {
                children.Add(m_unsuspendingToAbortingTransition);
            }

            if (m_holdingToAbortingTransition != null)
            {
                children.Add(m_holdingToAbortingTransition);
            }

            if (m_heldToAbortingTransition != null)
            {
                children.Add(m_heldToAbortingTransition);
            }

            if (m_unholdingToAbortingTransition != null)
            {
                children.Add(m_unholdingToAbortingTransition);
            }

            if (m_stoppingToAbortingTransition != null)
            {
                children.Add(m_stoppingToAbortingTransition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Stopped:
                {
                    if (createOrReplace)
                    {
                        if (Stopped == null)
                        {
                            if (replacement == null)
                            {
                                Stopped = new StateMachineInitialStateState(this);
                            }
                            else
                            {
                                Stopped = (StateMachineInitialStateState)replacement;
                            }
                        }
                    }

                    instance = Stopped;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Resetting:
                {
                    if (createOrReplace)
                    {
                        if (Resetting == null)
                        {
                            if (replacement == null)
                            {
                                Resetting = new StateMachineStateState(this);
                            }
                            else
                            {
                                Resetting = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Resetting;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Idle:
                {
                    if (createOrReplace)
                    {
                        if (Idle == null)
                        {
                            if (replacement == null)
                            {
                                Idle = new StateMachineStateState(this);
                            }
                            else
                            {
                                Idle = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Idle;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Starting:
                {
                    if (createOrReplace)
                    {
                        if (Starting == null)
                        {
                            if (replacement == null)
                            {
                                Starting = new StateMachineStateState(this);
                            }
                            else
                            {
                                Starting = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Starting;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Execute:
                {
                    if (createOrReplace)
                    {
                        if (Execute == null)
                        {
                            if (replacement == null)
                            {
                                Execute = new AnalyserChannelOperatingExecuteStateState(this);
                            }
                            else
                            {
                                Execute = (AnalyserChannelOperatingExecuteStateState)replacement;
                            }
                        }
                    }

                    instance = Execute;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Completing:
                {
                    if (createOrReplace)
                    {
                        if (Completing == null)
                        {
                            if (replacement == null)
                            {
                                Completing = new StateMachineStateState(this);
                            }
                            else
                            {
                                Completing = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Completing;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Complete:
                {
                    if (createOrReplace)
                    {
                        if (Complete == null)
                        {
                            if (replacement == null)
                            {
                                Complete = new StateMachineStateState(this);
                            }
                            else
                            {
                                Complete = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Complete;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Suspending:
                {
                    if (createOrReplace)
                    {
                        if (Suspending == null)
                        {
                            if (replacement == null)
                            {
                                Suspending = new StateMachineStateState(this);
                            }
                            else
                            {
                                Suspending = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Suspending;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Suspended:
                {
                    if (createOrReplace)
                    {
                        if (Suspended == null)
                        {
                            if (replacement == null)
                            {
                                Suspended = new StateMachineStateState(this);
                            }
                            else
                            {
                                Suspended = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Suspended;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Unsuspending:
                {
                    if (createOrReplace)
                    {
                        if (Unsuspending == null)
                        {
                            if (replacement == null)
                            {
                                Unsuspending = new StateMachineStateState(this);
                            }
                            else
                            {
                                Unsuspending = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Unsuspending;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Holding:
                {
                    if (createOrReplace)
                    {
                        if (Holding == null)
                        {
                            if (replacement == null)
                            {
                                Holding = new StateMachineStateState(this);
                            }
                            else
                            {
                                Holding = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Holding;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Held:
                {
                    if (createOrReplace)
                    {
                        if (Held == null)
                        {
                            if (replacement == null)
                            {
                                Held = new StateMachineStateState(this);
                            }
                            else
                            {
                                Held = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Held;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Unholding:
                {
                    if (createOrReplace)
                    {
                        if (Unholding == null)
                        {
                            if (replacement == null)
                            {
                                Unholding = new StateMachineStateState(this);
                            }
                            else
                            {
                                Unholding = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Unholding;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Stopping:
                {
                    if (createOrReplace)
                    {
                        if (Stopping == null)
                        {
                            if (replacement == null)
                            {
                                Stopping = new StateMachineStateState(this);
                            }
                            else
                            {
                                Stopping = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Stopping;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Aborting:
                {
                    if (createOrReplace)
                    {
                        if (Aborting == null)
                        {
                            if (replacement == null)
                            {
                                Aborting = new StateMachineStateState(this);
                            }
                            else
                            {
                                Aborting = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Aborting;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Aborted:
                {
                    if (createOrReplace)
                    {
                        if (Aborted == null)
                        {
                            if (replacement == null)
                            {
                                Aborted = new StateMachineStateState(this);
                            }
                            else
                            {
                                Aborted = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Aborted;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Clearing:
                {
                    if (createOrReplace)
                    {
                        if (Clearing == null)
                        {
                            if (replacement == null)
                            {
                                Clearing = new StateMachineStateState(this);
                            }
                            else
                            {
                                Clearing = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Clearing;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StoppedToResettingTransition:
                {
                    if (createOrReplace)
                    {
                        if (StoppedToResettingTransition == null)
                        {
                            if (replacement == null)
                            {
                                StoppedToResettingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StoppedToResettingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StoppedToResettingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ResettingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ResettingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ResettingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ResettingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ResettingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ResettingToIdleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ResettingToIdleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ResettingToIdleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ResettingToIdleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ResettingToIdleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.IdleToStartingTransition:
                {
                    if (createOrReplace)
                    {
                        if (IdleToStartingTransition == null)
                        {
                            if (replacement == null)
                            {
                                IdleToStartingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                IdleToStartingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = IdleToStartingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StartingTransition:
                {
                    if (createOrReplace)
                    {
                        if (StartingTransition == null)
                        {
                            if (replacement == null)
                            {
                                StartingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StartingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StartingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StartingToExecuteTransition:
                {
                    if (createOrReplace)
                    {
                        if (StartingToExecuteTransition == null)
                        {
                            if (replacement == null)
                            {
                                StartingToExecuteTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StartingToExecuteTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StartingToExecuteTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExecuteToCompletingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExecuteToCompletingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExecuteToCompletingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExecuteToCompletingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExecuteToCompletingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompletingTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompletingTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompletingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompletingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompletingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompletingToCompleteTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompletingToCompleteTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompletingToCompleteTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompletingToCompleteTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompletingToCompleteTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompleteToStoppedTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompleteToStoppedTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompleteToStoppedTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompleteToStoppedTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompleteToStoppedTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExecuteToHoldingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExecuteToHoldingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExecuteToHoldingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExecuteToHoldingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExecuteToHoldingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HoldingTransition:
                {
                    if (createOrReplace)
                    {
                        if (HoldingTransition == null)
                        {
                            if (replacement == null)
                            {
                                HoldingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HoldingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HoldingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HoldingToHeldTransition:
                {
                    if (createOrReplace)
                    {
                        if (HoldingToHeldTransition == null)
                        {
                            if (replacement == null)
                            {
                                HoldingToHeldTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HoldingToHeldTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HoldingToHeldTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HeldToUnholdingTransition:
                {
                    if (createOrReplace)
                    {
                        if (HeldToUnholdingTransition == null)
                        {
                            if (replacement == null)
                            {
                                HeldToUnholdingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HeldToUnholdingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HeldToUnholdingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnholdingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnholdingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnholdingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnholdingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnholdingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnholdingToHoldingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnholdingToHoldingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnholdingToHoldingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnholdingToHoldingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnholdingToHoldingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnholdingToExecuteTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnholdingToExecuteTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnholdingToExecuteTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnholdingToExecuteTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnholdingToExecuteTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExecuteToSuspendingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExecuteToSuspendingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExecuteToSuspendingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExecuteToSuspendingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExecuteToSuspendingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendingToSuspendedTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendingToSuspendedTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendingToSuspendedTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendingToSuspendedTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendingToSuspendedTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendedToUnsuspendingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendedToUnsuspendingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendedToUnsuspendingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendedToUnsuspendingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendedToUnsuspendingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnsuspendingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnsuspendingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnsuspendingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnsuspendingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnsuspendingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnsuspendingToSuspendingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnsuspendingToSuspendingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnsuspendingToSuspendingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnsuspendingToSuspendingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnsuspendingToSuspendingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnsuspendingToExecuteTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnsuspendingToExecuteTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnsuspendingToExecuteTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnsuspendingToExecuteTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnsuspendingToExecuteTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StoppingToStoppedTransition:
                {
                    if (createOrReplace)
                    {
                        if (StoppingToStoppedTransition == null)
                        {
                            if (replacement == null)
                            {
                                StoppingToStoppedTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StoppingToStoppedTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StoppingToStoppedTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AbortingToAbortedTransition:
                {
                    if (createOrReplace)
                    {
                        if (AbortingToAbortedTransition == null)
                        {
                            if (replacement == null)
                            {
                                AbortingToAbortedTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AbortingToAbortedTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AbortingToAbortedTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AbortedToClearingTransition:
                {
                    if (createOrReplace)
                    {
                        if (AbortedToClearingTransition == null)
                        {
                            if (replacement == null)
                            {
                                AbortedToClearingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AbortedToClearingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AbortedToClearingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ClearingToStoppedTransition:
                {
                    if (createOrReplace)
                    {
                        if (ClearingToStoppedTransition == null)
                        {
                            if (replacement == null)
                            {
                                ClearingToStoppedTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ClearingToStoppedTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ClearingToStoppedTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ResettingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ResettingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ResettingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ResettingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ResettingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.IdleToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (IdleToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                IdleToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                IdleToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = IdleToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StartingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (StartingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                StartingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StartingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StartingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExecuteToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExecuteToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExecuteToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExecuteToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExecuteToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompletingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompletingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompletingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompletingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompletingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompleteToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompleteToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompleteToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompleteToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompleteToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendedToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendedToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendedToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendedToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendedToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnsuspendingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnsuspendingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnsuspendingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnsuspendingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnsuspendingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HoldingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (HoldingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                HoldingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HoldingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HoldingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HeldToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (HeldToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                HeldToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HeldToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HeldToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnholdingToStoppingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnholdingToStoppingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnholdingToStoppingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnholdingToStoppingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnholdingToStoppingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StoppedToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (StoppedToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                StoppedToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StoppedToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StoppedToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ResettingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ResettingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ResettingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ResettingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ResettingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.IdleToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (IdleToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                IdleToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                IdleToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = IdleToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StartingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (StartingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                StartingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StartingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StartingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExecuteToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExecuteToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExecuteToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExecuteToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExecuteToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompletingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompletingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompletingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompletingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompletingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CompleteToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (CompleteToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                CompleteToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CompleteToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CompleteToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SuspendedToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (SuspendedToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                SuspendedToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SuspendedToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SuspendedToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnsuspendingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnsuspendingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnsuspendingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnsuspendingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnsuspendingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HoldingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (HoldingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                HoldingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HoldingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HoldingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.HeldToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (HeldToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                HeldToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                HeldToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = HeldToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.UnholdingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (UnholdingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                UnholdingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                UnholdingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = UnholdingToAbortingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.StoppingToAbortingTransition:
                {
                    if (createOrReplace)
                    {
                        if (StoppingToAbortingTransition == null)
                        {
                            if (replacement == null)
                            {
                                StoppingToAbortingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                StoppingToAbortingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = StoppingToAbortingTransition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private StateMachineInitialStateState m_stopped;
        private StateMachineStateState m_resetting;
        private StateMachineStateState m_idle;
        private StateMachineStateState m_starting;
        private AnalyserChannelOperatingExecuteStateState m_execute;
        private StateMachineStateState m_completing;
        private StateMachineStateState m_complete;
        private StateMachineStateState m_suspending;
        private StateMachineStateState m_suspended;
        private StateMachineStateState m_unsuspending;
        private StateMachineStateState m_holding;
        private StateMachineStateState m_held;
        private StateMachineStateState m_unholding;
        private StateMachineStateState m_stopping;
        private StateMachineStateState m_aborting;
        private StateMachineStateState m_aborted;
        private StateMachineStateState m_clearing;
        private StateMachineTransitionState m_stoppedToResettingTransition;
        private StateMachineTransitionState m_resettingTransition;
        private StateMachineTransitionState m_resettingToIdleTransition;
        private StateMachineTransitionState m_idleToStartingTransition;
        private StateMachineTransitionState m_startingTransition;
        private StateMachineTransitionState m_startingToExecuteTransition;
        private StateMachineTransitionState m_executeToCompletingTransition;
        private StateMachineTransitionState m_completingTransition;
        private StateMachineTransitionState m_completingToCompleteTransition;
        private StateMachineTransitionState m_completeToStoppedTransition;
        private StateMachineTransitionState m_executeToHoldingTransition;
        private StateMachineTransitionState m_holdingTransition;
        private StateMachineTransitionState m_holdingToHeldTransition;
        private StateMachineTransitionState m_heldToUnholdingTransition;
        private StateMachineTransitionState m_unholdingTransition;
        private StateMachineTransitionState m_unholdingToHoldingTransition;
        private StateMachineTransitionState m_unholdingToExecuteTransition;
        private StateMachineTransitionState m_executeToSuspendingTransition;
        private StateMachineTransitionState m_suspendingTransition;
        private StateMachineTransitionState m_suspendingToSuspendedTransition;
        private StateMachineTransitionState m_suspendedToUnsuspendingTransition;
        private StateMachineTransitionState m_unsuspendingTransition;
        private StateMachineTransitionState m_unsuspendingToSuspendingTransition;
        private StateMachineTransitionState m_unsuspendingToExecuteTransition;
        private StateMachineTransitionState m_stoppingToStoppedTransition;
        private StateMachineTransitionState m_abortingToAbortedTransition;
        private StateMachineTransitionState m_abortedToClearingTransition;
        private StateMachineTransitionState m_clearingToStoppedTransition;
        private StateMachineTransitionState m_resettingToStoppingTransition;
        private StateMachineTransitionState m_idleToStoppingTransition;
        private StateMachineTransitionState m_startingToStoppingTransition;
        private StateMachineTransitionState m_executeToStoppingTransition;
        private StateMachineTransitionState m_completingToStoppingTransition;
        private StateMachineTransitionState m_completeToStoppingTransition;
        private StateMachineTransitionState m_suspendingToStoppingTransition;
        private StateMachineTransitionState m_suspendedToStoppingTransition;
        private StateMachineTransitionState m_unsuspendingToStoppingTransition;
        private StateMachineTransitionState m_holdingToStoppingTransition;
        private StateMachineTransitionState m_heldToStoppingTransition;
        private StateMachineTransitionState m_unholdingToStoppingTransition;
        private StateMachineTransitionState m_stoppedToAbortingTransition;
        private StateMachineTransitionState m_resettingToAbortingTransition;
        private StateMachineTransitionState m_idleToAbortingTransition;
        private StateMachineTransitionState m_startingToAbortingTransition;
        private StateMachineTransitionState m_executeToAbortingTransition;
        private StateMachineTransitionState m_completingToAbortingTransition;
        private StateMachineTransitionState m_completeToAbortingTransition;
        private StateMachineTransitionState m_suspendingToAbortingTransition;
        private StateMachineTransitionState m_suspendedToAbortingTransition;
        private StateMachineTransitionState m_unsuspendingToAbortingTransition;
        private StateMachineTransitionState m_holdingToAbortingTransition;
        private StateMachineTransitionState m_heldToAbortingTransition;
        private StateMachineTransitionState m_unholdingToAbortingTransition;
        private StateMachineTransitionState m_stoppingToAbortingTransition;
        #endregion
    }
    #endif
    #endregion

    #region AnalyserChannel_OperatingModeExecuteSubStateMachineState Class
    #if (!OPCUA_EXCLUDE_AnalyserChannel_OperatingModeExecuteSubStateMachineState)
    /// <summary>
    /// Stores an instance of the AnalyserChannel_OperatingModeExecuteSubStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AnalyserChannel_OperatingModeExecuteSubStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AnalyserChannel_OperatingModeExecuteSubStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AnalyserChannel_OperatingModeExecuteSubStateMachineType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQA/AAAAQW5hbHlzZXJDaGFubmVsX09wZXJhdGluZ01v" +
           "ZGVFeGVjdXRlU3ViU3RhdGVNYWNoaW5lVHlwZUluc3RhbmNlAQHxAwEB8QMB/////zsAAAAVYIkKAgAA" +
           "AAAADAAAAEN1cnJlbnRTdGF0ZQEB4BgALwEAyArgGAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAC" +
           "AAAASWQBAeEYAC4AROEYAAAAEf////8BAf////8AAAAAJGCACgEAAAABABQAAABTZWxlY3RFeGVjdXRp" +
           "b25DeWNsZQEBBCQDAAAAAEgAAABUaGlzIHBzZXVkby1zdGF0ZSBpcyB1c2VkIHRvIGRlY2lkZSB3aGlj" +
           "aCBleGVjdXRpb24gcGF0aCBzaGFsbCBiZSB0YWtlbi4ALwEABQkEJAAABgAAAAAzAQEBBiQAMwEBAQgk" +
           "ADMBAQEKJAAzAQEBDCQAMwEBAQ4kADQBAQEQJAEAAAAVYKkKAgAAAAEACwAAAFN0YXRlTnVtYmVyAQEF" +
           "JAAuAEQFJAAABwAAAAAAB/////8BAf////8AAAAAJGCACgEAAAABABkAAABXYWl0Rm9yQ2FsaWJyYXRp" +
           "b25UcmlnZ2VyAQF/FAMAAAAAVQAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVh" +
           "ZHkgdG8gcGVyZm9ybSB0aGUgQ2FsaWJyYXRpb24gYWNxdWlzaXRpb24gY3ljbGUALwEAAwl/FAAAAgAA" +
           "AAA0AQEBBiQAMwEBAZQUAQAAABVgqQoCAAAAAQALAAAAU3RhdGVOdW1iZXIBAesYAC4AROsYAAAHAAAA" +
           "AAAH/////wEB/////wAAAAAkYIAKAQAAAAEAGAAAAEV4dHJhY3RDYWxpYnJhdGlvblNhbXBsZQEBgBQD" +
           "AAAAAFsAAABDb2xsZWN0IC8gc2V0dXAgdGhlIHNhbXBsaW5nIHN5c3RlbSB0byBwZXJmb3JtIHRoZSBh" +
           "Y3F1aXNpdGlvbiBjeWNsZSBvZiBhIENhbGlicmF0aW9uIGN5Y2xlAC8BAAMJgBQAAAQAAAAANAEBAZQU" +
           "ADMBAQGVFAA0AQEBlRQAMwEBAZYUAQAAABVgqQoCAAAAAQALAAAAU3RhdGVOdW1iZXIBAewYAC4AROwY" +
           "AAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEAGAAAAFByZXBhcmVDYWxpYnJhdGlvblNhbXBs" +
           "ZQEBgRQDAAAAAEUAAABQcmVwYXJlIHRoZSBDYWxpYnJhdGlvbiBzYW1wbGUgZm9yIHRoZSBBbmFseXNl" +
           "Q2FsaWJyYXRpb25TYW1wbGUgc3RhdGUALwEAAwmBFAAABAAAAAA0AQEBlhQAMwEBAZcUADQBAQGXFAAz" +
           "AQEBmBQBAAAAFWCpCgIAAAABAAsAAABTdGF0ZU51bWJlcgEB7RgALgBE7RgAAAcAAAAAAAf/////AQH/" +
           "////AAAAACRggAoBAAAAAQAYAAAAQW5hbHlzZUNhbGlicmF0aW9uU2FtcGxlAQGCFAMAAAAALgAAAFBl" +
           "cmZvcm0gdGhlIGFuYWx5c2lzIG9mIHRoZSBDYWxpYnJhdGlvbiBTYW1wbGUALwEAAwmCFAAABAAAAAA0" +
           "AQEBmBQAMwEBAZkUADQBAQGZFAAzAQEBmhQBAAAAFWCpCgIAAAABAAsAAABTdGF0ZU51bWJlcgEB7hgA" +
           "LgBE7hgAAAcAAAAAAAf/////AQH/////AAAAACRggAoBAAAAAQAYAAAAV2FpdEZvclZhbGlkYXRpb25U" +
           "cmlnZ2VyAQGDFAMAAAAAVAAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkg" +
           "dG8gcGVyZm9ybSB0aGUgVmFsaWRhdGlvbiBhY3F1aXNpdGlvbiBjeWNsZQAvAQADCYMUAAACAAAAADQB" +
           "AQEIJAAzAQEBnBQBAAAAFWCpCgIAAAABAAsAAABTdGF0ZU51bWJlcgEB7xgALgBE7xgAAAcAAAAAAAf/" +
           "////AQH/////AAAAACRggAoBAAAAAQAXAAAARXh0cmFjdFZhbGlkYXRpb25TYW1wbGUBAYQUAwAAAABa" +
           "AAAAQ29sbGVjdCAvIHNldHVwIHRoZSBzYW1wbGluZyBzeXN0ZW0gdG8gcGVyZm9ybSB0aGUgYWNxdWlz" +
           "aXRpb24gY3ljbGUgb2YgYSBWYWxpZGF0aW9uIGN5Y2xlAC8BAAMJhBQAAAQAAAAANAEBAZwUADMBAQGd" +
           "FAA0AQEBnRQAMwEBAZ4UAQAAABVgqQoCAAAAAQALAAAAU3RhdGVOdW1iZXIBAfAYAC4ARPAYAAAHAAAA" +
           "AAAH/////wEB/////wAAAAAkYIAKAQAAAAEAFwAAAFByZXBhcmVWYWxpZGF0aW9uU2FtcGxlAQGFFAMA" +
           "AAAAQwAAAFByZXBhcmUgdGhlIFZhbGlkYXRpb24gc2FtcGxlIGZvciB0aGUgQW5hbHlzZVZhbGlkYXRp" +
           "b25TYW1wbGUgc3RhdGUALwEAAwmFFAAABAAAAAA0AQEBnhQAMwEBAZ8UADQBAQGfFAAzAQEBoBQBAAAA" +
           "FWCpCgIAAAABAAsAAABTdGF0ZU51bWJlcgEB8RgALgBE8RgAAAcAAAAAAAf/////AQH/////AAAAACRg" +
           "gAoBAAAAAQAXAAAAQW5hbHlzZVZhbGlkYXRpb25TYW1wbGUBAYYUAwAAAAAtAAAAUGVyZm9ybSB0aGUg" +
           "YW5hbHlzaXMgb2YgdGhlIFZhbGlkYXRpb24gU2FtcGxlAC8BAAMJhhQAAAQAAAAANAEBAaAUADMBAQGh" +
           "FAA0AQEBoRQAMwEBAaIUAQAAABVgqQoCAAAAAQALAAAAU3RhdGVOdW1iZXIBAfIYAC4ARPIYAAAHAAAA" +
           "AAAH/////wEB/////wAAAAAkYIAKAQAAAAEAFAAAAFdhaXRGb3JTYW1wbGVUcmlnZ2VyAQGHFAMAAAAA" +
           "UAAAAFdhaXQgdW50aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9ybSB0aGUg" +
           "U2FtcGxlIGFjcXVpc2l0aW9uIGN5Y2xlAC8BAAMJhxQAAAIAAAAANAEBAQokADMBAQGkFAEAAAAVYKkK" +
           "AgAAAAEACwAAAFN0YXRlTnVtYmVyAQHzGAAuAETzGAAABwAAAAAAB/////8BAf////8AAAAAJGCACgEA" +
           "AAABAA0AAABFeHRyYWN0U2FtcGxlAQGIFAMAAAAAIwAAAENvbGxlY3QgdGhlIFNhbXBsZSBmcm9tIHRo" +
           "ZSBwcm9jZXNzAC8BAAMJiBQAAAQAAAAANAEBAaQUADMBAQGlFAA0AQEBpRQAMwEBAaYUAQAAABVgqQoC" +
           "AAAAAQALAAAAU3RhdGVOdW1iZXIBAfQYAC4ARPQYAAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAA" +
           "AAEADQAAAFByZXBhcmVTYW1wbGUBAYkUAwAAAAAuAAAAUHJlcGFyZSB0aGUgU2FtcGxlIGZvciB0aGUg" +
           "QW5hbHlzZVNhbXBsZSBzdGF0ZQAvAQADCYkUAAAEAAAAADQBAQGmFAAzAQEBpxQANAEBAacUADMBAQGo" +
           "FAEAAAAVYKkKAgAAAAEACwAAAFN0YXRlTnVtYmVyAQH1GAAuAET1GAAABwAAAAAAB/////8BAf////8A" +
           "AAAAJGCACgEAAAABAA0AAABBbmFseXNlU2FtcGxlAQGKFAMAAAAAIgAAAFBlcmZvcm0gdGhlIGFuYWx5" +
           "c2lzIG9mIHRoZSBTYW1wbGUALwEAAwmKFAAABAAAAAA0AQEBqBQAMwEBAakUADQBAQGpFAAzAQEBqhQB" +
           "AAAAFWCpCgIAAAABAAsAAABTdGF0ZU51bWJlcgEB9hgALgBE9hgAAAcAAAAAAAf/////AQH/////AAAA" +
           "ACRggAoBAAAAAQAYAAAAV2FpdEZvckRpYWdub3N0aWNUcmlnZ2VyAQGLFAMAAAAASQAAAFdhaXQgdW50" +
           "aWwgdGhlIGFuYWx5c2VyIGNoYW5uZWwgaXMgcmVhZHkgdG8gcGVyZm9ybSB0aGUgZGlhZ25vc3RpYyBj" +
           "eWNsZSwALwEAAwmLFAAAAgAAAAA0AQEBDCQAMwEBAawUAQAAABVgqQoCAAAAAQALAAAAU3RhdGVOdW1i" +
           "ZXIBAfcYAC4ARPcYAAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEACgAAAERpYWdub3N0aWMB" +
           "AYwUAwAAAAAdAAAAUGVyZm9ybSB0aGUgZGlhZ25vc3RpYyBjeWNsZS4ALwEAAwmMFAAABAAAAAA0AQEB" +
           "rBQAMwEBAa0UADQBAQGtFAAzAQEBrhQBAAAAFWCpCgIAAAABAAsAAABTdGF0ZU51bWJlcgEB+BgALgBE" +
           "+BgAAAcAAAAAAAf/////AQH/////AAAAACRggAoBAAAAAQAWAAAAV2FpdEZvckNsZWFuaW5nVHJpZ2dl" +
           "cgEBjRQDAAAAAEcAAABXYWl0IHVudGlsIHRoZSBhbmFseXNlciBjaGFubmVsIGlzIHJlYWR5IHRvIHBl" +
           "cmZvcm0gdGhlIGNsZWFuaW5nIGN5Y2xlLAAvAQADCY0UAAACAAAAADQBAQEOJAAzAQEBsBQBAAAAFWCp" +
           "CgIAAAABAAsAAABTdGF0ZU51bWJlcgEB+RgALgBE+RgAAAcAAAAAAAf/////AQH/////AAAAACRggAoB" +
           "AAAAAQAIAAAAQ2xlYW5pbmcBAY4UAwAAAAAbAAAAUGVyZm9ybSB0aGUgY2xlYW5pbmcgY3ljbGUuAC8B" +
           "AAMJjhQAAAQAAAAANAEBAbAUADMBAQGxFAA0AQEBsRQAMwEBAbIUAQAAABVgqQoCAAAAAQALAAAAU3Rh" +
           "dGVOdW1iZXIBAfoYAC4ARPoYAAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEADgAAAFB1Ymxp" +
           "c2hSZXN1bHRzAQGPFAMAAAAANQAAAFB1Ymxpc2ggdGhlIHJlc3VsdHMgb2YgdGhlIHByZXZpb3VzIGFj" +
           "cXVpc2l0aW9uIGN5Y2xlAC8BAAMJjxQAAAcAAAAANAEBAZoUADQBAQGiFAA0AQEBqhQANAEBAa4UADQB" +
           "AQGyFAAzAQEBsxQAMwEBAbQUAQAAABVgqQoCAAAAAQALAAAAU3RhdGVOdW1iZXIBAfsYAC4ARPsYAAAH" +
           "AAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEADwAAAEVqZWN0R3JhYlNhbXBsZQEBkBQDAAAAAG8A" +
           "AABUaGUgU2FtcGxlIHRoYXQgd2FzIGp1c3QgYW5hbHlzZWQgaXMgZWplY3RlZCBmcm9tIHRoZSBzeXN0" +
           "ZW0gdG8gYWxsb3cgdGhlIG9wZXJhdG9yIG9yIGFub3RoZXIgc3lzdGVtIHRvIGdyYWIgaXQALwEAAwmQ" +
           "FAAABAAAAAA0AQEBtBQAMwEBAbUUADQBAQG1FAAzAQEBthQBAAAAFWCpCgIAAAABAAsAAABTdGF0ZU51" +
           "bWJlcgEB/BgALgBE/BgAAAcAAAAAAAf/////AQH/////AAAAACRggAoBAAAAAQAVAAAAQ2xlYW51cFNh" +
           "bXBsaW5nU3lzdGVtAQGRFAMAAAAARAAAAENsZWFudXAgdGhlIHNhbXBsaW5nIHN1Yi1zeXN0ZW0gdG8g" +
           "YmUgcmVhZHkgZm9yIHRoZSBuZXh0IGFjcXVpc2l0aW9uAC8BAAMJkRQAAAUAAAAANAEBAbMUADQBAQG2" +
           "FAAzAQEBtxQANAEBAbcUADMBAQEQJAEAAAAVYKkKAgAAAAEACwAAAFN0YXRlTnVtYmVyAQH9GAAuAET9" +
           "GAAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABADkAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRv" +
           "V2FpdEZvckNhbGlicmF0aW9uVHJpZ2dlclRyYW5zaXRpb24BAQYkAC8BAAYJBiQAAAIAAAAAMwABAQQk" +
           "ADQAAQF/FAEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAQckAC4ARAckAAAHAAAAAAAH" +
           "/////wEB/////wAAAAAEYIAKAQAAAAEAPQAAAFdhaXRGb3JDYWxpYnJhdGlvblRyaWdnZXJUb0V4dHJh" +
           "Y3RDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BAZQUAC8BAAYJlBQAAAIAAAAAMwABAX8UADQAAQGA" +
           "FAEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAQAZAC4ARAAZAAAHAAAAAAAH/////wEB" +
           "/////wAAAAAEYIAKAQAAAAEAIgAAAEV4dHJhY3RDYWxpYnJhdGlvblNhbXBsZVRyYW5zaXRpb24BAZUU" +
           "AC8BAAYJlRQAAAIAAAAAMwABAYAUADQAAQGAFAEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1i" +
           "ZXIBAQEZAC4ARAEZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAPAAAAEV4dHJhY3RDYWxp" +
           "YnJhdGlvblNhbXBsZVRvUHJlcGFyZUNhbGlicmF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBlhQALwEABgmW" +
           "FAAAAgAAAAAzAAEBgBQANAABAYEUAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBAhkA" +
           "LgBEAhkAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAiAAAAUHJlcGFyZUNhbGlicmF0aW9u" +
           "U2FtcGxlVHJhbnNpdGlvbgEBlxQALwEABgmXFAAAAgAAAAAzAAEBgRQANAABAYEUAQAAABVgqQoCAAAA" +
           "AAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBAxkALgBEAxkAAAcAAAAAAAf/////AQH/////AAAAAARggAoB" +
           "AAAAAQA8AAAAUHJlcGFyZUNhbGlicmF0aW9uU2FtcGxlVG9BbmFseXNlQ2FsaWJyYXRpb25TYW1wbGVU" +
           "cmFuc2l0aW9uAQGYFAAvAQAGCZgUAAACAAAAADMAAQGBFAA0AAEBghQBAAAAFWCpCgIAAAAAABAAAABU" +
           "cmFuc2l0aW9uTnVtYmVyAQEEGQAuAEQEGQAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABACIA" +
           "AABBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGVUcmFuc2l0aW9uAQGZFAAvAQAGCZkUAAACAAAAADMAAQGC" +
           "FAA0AAEBghQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQEFGQAuAEQFGQAABwAAAAAA" +
           "B/////8BAf////8AAAAABGCACgEAAAABADIAAABBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGVUb1B1Ymxp" +
           "c2hSZXN1bHRzVHJhbnNpdGlvbgEBmhQALwEABgmaFAAAAgAAAAAzAAEBghQANAABAY8UAQAAABVgqQoC" +
           "AAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBBhkALgBEBhkAAAcAAAAAAAf/////AQH/////AAAAAARg" +
           "gAoBAAAAAQA4AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JWYWxpZGF0aW9uVHJpZ2dlclRy" +
           "YW5zaXRpb24BAQgkAC8BAAYJCCQAAAIAAAAAMwABAQQkADQAAQGDFAEAAAAVYKkKAgAAAAAAEAAAAFRy" +
           "YW5zaXRpb25OdW1iZXIBAQkkAC4ARAkkAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAOwAA" +
           "AFdhaXRGb3JWYWxpZGF0aW9uVHJpZ2dlclRvRXh0cmFjdFZhbGlkYXRpb25TYW1wbGVUcmFuc2l0aW9u" +
           "AQGcFAAvAQAGCZwUAAACAAAAADMAAQGDFAA0AAEBhBQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9u" +
           "TnVtYmVyAQEIGQAuAEQIGQAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABACEAAABFeHRyYWN0" +
           "VmFsaWRhdGlvblNhbXBsZVRyYW5zaXRpb24BAZ0UAC8BAAYJnRQAAAIAAAAAMwABAYQUADQAAQGEFAEA" +
           "AAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAQkZAC4ARAkZAAAHAAAAAAAH/////wEB////" +
           "/wAAAAAEYIAKAQAAAAEAOgAAAEV4dHJhY3RWYWxpZGF0aW9uU2FtcGxlVG9QcmVwYXJlVmFsaWRhdGlv" +
           "blNhbXBsZVRyYW5zaXRpb24BAZ4UAC8BAAYJnhQAAAIAAAAAMwABAYQUADQAAQGFFAEAAAAVYKkKAgAA" +
           "AAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAQoZAC4ARAoZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAK" +
           "AQAAAAEAIQAAAFByZXBhcmVWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBnxQALwEABgmfFAAAAgAA" +
           "AAAzAAEBhRQANAABAYUUAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBCxkALgBECxkA" +
           "AAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQA6AAAAUHJlcGFyZVZhbGlkYXRpb25TYW1wbGVU" +
           "b0FuYWx5c2VWYWxpZGF0aW9uU2FtcGxlVHJhbnNpdGlvbgEBoBQALwEABgmgFAAAAgAAAAAzAAEBhRQA" +
           "NAABAYYUAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBDBkALgBEDBkAAAcAAAAAAAf/" +
           "////AQH/////AAAAAARggAoBAAAAAQAhAAAAQW5hbHlzZVZhbGlkYXRpb25TYW1wbGVUcmFuc2l0aW9u" +
           "AQGhFAAvAQAGCaEUAAACAAAAADMAAQGGFAA0AAEBhhQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9u" +
           "TnVtYmVyAQENGQAuAEQNGQAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABADEAAABBbmFseXNl" +
           "VmFsaWRhdGlvblNhbXBsZVRvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQGiFAAvAQAGCaIUAAACAAAA" +
           "ADMAAQGGFAA0AAEBjxQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQEOGQAuAEQOGQAA" +
           "BwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABADQAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2Fp" +
           "dEZvclNhbXBsZVRyaWdnZXJUcmFuc2l0aW9uAQEKJAAvAQAGCQokAAACAAAAADMAAQEEJAA0AAEBhxQB" +
           "AAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQELJAAuAEQLJAAABwAAAAAAB/////8BAf//" +
           "//8AAAAABGCACgEAAAABAC0AAABXYWl0Rm9yU2FtcGxlVHJpZ2dlclRvRXh0cmFjdFNhbXBsZVRyYW5z" +
           "aXRpb24BAaQUAC8BAAYJpBQAAAIAAAAAMwABAYcUADQAAQGIFAEAAAAVYKkKAgAAAAAAEAAAAFRyYW5z" +
           "aXRpb25OdW1iZXIBARAZAC4ARBAZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAFwAAAEV4" +
           "dHJhY3RTYW1wbGVUcmFuc2l0aW9uAQGlFAAvAQAGCaUUAAACAAAAADMAAQGIFAA0AAEBiBQBAAAAFWCp" +
           "CgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQERGQAuAEQRGQAABwAAAAAAB/////8BAf////8AAAAA" +
           "BGCACgEAAAABACYAAABFeHRyYWN0U2FtcGxlVG9QcmVwYXJlU2FtcGxlVHJhbnNpdGlvbgEBphQALwEA" +
           "BgmmFAAAAgAAAAAzAAEBiBQANAABAYkUAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEB" +
           "EhkALgBEEhkAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAXAAAAUHJlcGFyZVNhbXBsZVRy" +
           "YW5zaXRpb24BAacUAC8BAAYJpxQAAAIAAAAAMwABAYkUADQAAQGJFAEAAAAVYKkKAgAAAAAAEAAAAFRy" +
           "YW5zaXRpb25OdW1iZXIBARMZAC4ARBMZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAJgAA" +
           "AFByZXBhcmVTYW1wbGVUb0FuYWx5c2VTYW1wbGVUcmFuc2l0aW9uAQGoFAAvAQAGCagUAAACAAAAADMA" +
           "AQGJFAA0AAEBihQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQEUGQAuAEQUGQAABwAA" +
           "AAAAB/////8BAf////8AAAAABGCACgEAAAABABcAAABBbmFseXNlU2FtcGxlVHJhbnNpdGlvbgEBqRQA" +
           "LwEABgmpFAAAAgAAAAAzAAEBihQANAABAYoUAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJl" +
           "cgEBFRkALgBEFRkAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAnAAAAQW5hbHlzZVNhbXBs" +
           "ZVRvUHVibGlzaFJlc3VsdHNUcmFuc2l0aW9uAQGqFAAvAQAGCaoUAAACAAAAADMAAQGKFAA0AAEBjxQB" +
           "AAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQEWGQAuAEQWGQAABwAAAAAAB/////8BAf//" +
           "//8AAAAABGCACgEAAAABADgAAABTZWxlY3RFeGVjdXRpb25DeWNsZVRvV2FpdEZvckRpYWdub3N0aWNU" +
           "cmlnZ2VyVHJhbnNpdGlvbgEBDCQALwEABgkMJAAAAgAAAAAzAAEBBCQANAABAYsUAQAAABVgqQoCAAAA" +
           "AAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBDSQALgBEDSQAAAcAAAAAAAf/////AQH/////AAAAAARggAoB" +
           "AAAAAQAuAAAAV2FpdEZvckRpYWdub3N0aWNUcmlnZ2VyVG9EaWFnbm9zdGljVHJhbnNpdGlvbgEBrBQA" +
           "LwEABgmsFAAAAgAAAAAzAAEBixQANAABAYwUAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJl" +
           "cgEBGBkALgBEGBkAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAUAAAARGlhZ25vc3RpY1Ry" +
           "YW5zaXRpb24BAa0UAC8BAAYJrRQAAAIAAAAAMwABAYwUADQAAQGMFAEAAAAVYKkKAgAAAAAAEAAAAFRy" +
           "YW5zaXRpb25OdW1iZXIBARkZAC4ARBkZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAJAAA" +
           "AERpYWdub3N0aWNUb1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEBrhQALwEABgmuFAAAAgAAAAAzAAEB" +
           "jBQANAABAY8UAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBGhkALgBEGhkAAAcAAAAA" +
           "AAf/////AQH/////AAAAAARggAoBAAAAAQA2AAAAU2VsZWN0RXhlY3V0aW9uQ3ljbGVUb1dhaXRGb3JD" +
           "bGVhbmluZ1RyaWdnZXJUcmFuc2l0aW9uAQEOJAAvAQAGCQ4kAAACAAAAADMAAQEEJAA0AAEBjRQBAAAA" +
           "FWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQEPJAAuAEQPJAAABwAAAAAAB/////8BAf////8A" +
           "AAAABGCACgEAAAABACoAAABXYWl0Rm9yQ2xlYW5pbmdUcmlnZ2VyVG9DbGVhbmluZ1RyYW5zaXRpb24B" +
           "AbAUAC8BAAYJsBQAAAIAAAAAMwABAY0UADQAAQGOFAEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25O" +
           "dW1iZXIBARwZAC4ARBwZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAEgAAAENsZWFuaW5n" +
           "VHJhbnNpdGlvbgEBsRQALwEABgmxFAAAAgAAAAAzAAEBjhQANAABAY4UAQAAABVgqQoCAAAAAAAQAAAA" +
           "VHJhbnNpdGlvbk51bWJlcgEBHRkALgBEHRkAAAcAAAAAAAf/////AQH/////AAAAAARggAoBAAAAAQAi" +
           "AAAAQ2xlYW5pbmdUb1B1Ymxpc2hSZXN1bHRzVHJhbnNpdGlvbgEBshQALwEABgmyFAAAAgAAAAAzAAEB" +
           "jhQANAABAY8UAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBHhkALgBEHhkAAAcAAAAA" +
           "AAf/////AQH/////AAAAAARggAoBAAAAAQAvAAAAUHVibGlzaFJlc3VsdHNUb0NsZWFudXBTYW1wbGlu" +
           "Z1N5c3RlbVRyYW5zaXRpb24BAbMUAC8BAAYJsxQAAAIAAAAAMwABAY8UADQAAQGRFAEAAAAVYKkKAgAA" +
           "AAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAR8ZAC4ARB8ZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAK" +
           "AQAAAAEAKQAAAFB1Ymxpc2hSZXN1bHRzVG9FamVjdEdyYWJTYW1wbGVUcmFuc2l0aW9uAQG0FAAvAQAG" +
           "CbQUAAACAAAAADMAAQGPFAA0AAEBkBQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVyAQEg" +
           "GQAuAEQgGQAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABkAAABFamVjdEdyYWJTYW1wbGVU" +
           "cmFuc2l0aW9uAQG1FAAvAQAGCbUUAAACAAAAADMAAQGQFAA0AAEBkBQBAAAAFWCpCgIAAAAAABAAAABU" +
           "cmFuc2l0aW9uTnVtYmVyAQEhGQAuAEQhGQAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABADAA" +
           "AABFamVjdEdyYWJTYW1wbGVUb0NsZWFudXBTYW1wbGluZ1N5c3RlbVRyYW5zaXRpb24BAbYUAC8BAAYJ" +
           "thQAAAIAAAAAMwABAZAUADQAAQGRFAEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBASIZ" +
           "AC4ARCIZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHwAAAENsZWFudXBTYW1wbGluZ1N5" +
           "c3RlbVRyYW5zaXRpb24BAbcUAC8BAAYJtxQAAAIAAAAAMwABAZEUADQAAQGRFAEAAAAVYKkKAgAAAAAA" +
           "EAAAAFRyYW5zaXRpb25OdW1iZXIBASMZAC4ARCMZAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAA" +
           "AAEANQAAAENsZWFudXBTYW1wbGluZ1N5c3RlbVRvU2VsZWN0RXhlY3V0aW9uQ3ljbGVUcmFuc2l0aW9u" +
           "AQEQJAAvAQAGCRAkAAACAAAAADMAAQGRFAA0AAEBBCQBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9u" +
           "TnVtYmVyAQERJAAuAEQRJAAABwAAAAAAB/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// This pseudo-state is used to decide which execution path shall be taken.
        /// </summary>
        public StateMachineInitialStateState SelectExecutionCycle
        {
            get
            { 
                return m_selectExecutionCycle;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_selectExecutionCycle, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_selectExecutionCycle = value;
            }
        }

        /// <summary>
        /// Wait until the analyser channel is ready to perform the Calibration acquisition cycle
        /// </summary>
        public StateMachineStateState WaitForCalibrationTrigger
        {
            get
            { 
                return m_waitForCalibrationTrigger;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForCalibrationTrigger, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForCalibrationTrigger = value;
            }
        }

        /// <summary>
        /// Collect / setup the sampling system to perform the acquisition cycle of a Calibration cycle
        /// </summary>
        public StateMachineStateState ExtractCalibrationSample
        {
            get
            { 
                return m_extractCalibrationSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractCalibrationSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractCalibrationSample = value;
            }
        }

        /// <summary>
        /// Prepare the Calibration sample for the AnalyseCalibrationSample state
        /// </summary>
        public StateMachineStateState PrepareCalibrationSample
        {
            get
            { 
                return m_prepareCalibrationSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareCalibrationSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareCalibrationSample = value;
            }
        }

        /// <summary>
        /// Perform the analysis of the Calibration Sample
        /// </summary>
        public StateMachineStateState AnalyseCalibrationSample
        {
            get
            { 
                return m_analyseCalibrationSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseCalibrationSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseCalibrationSample = value;
            }
        }

        /// <summary>
        /// Wait until the analyser channel is ready to perform the Validation acquisition cycle
        /// </summary>
        public StateMachineStateState WaitForValidationTrigger
        {
            get
            { 
                return m_waitForValidationTrigger;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForValidationTrigger, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForValidationTrigger = value;
            }
        }

        /// <summary>
        /// Collect / setup the sampling system to perform the acquisition cycle of a Validation cycle
        /// </summary>
        public StateMachineStateState ExtractValidationSample
        {
            get
            { 
                return m_extractValidationSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractValidationSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractValidationSample = value;
            }
        }

        /// <summary>
        /// Prepare the Validation sample for the AnalyseValidationSample state
        /// </summary>
        public StateMachineStateState PrepareValidationSample
        {
            get
            { 
                return m_prepareValidationSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareValidationSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareValidationSample = value;
            }
        }

        /// <summary>
        /// Perform the analysis of the Validation Sample
        /// </summary>
        public StateMachineStateState AnalyseValidationSample
        {
            get
            { 
                return m_analyseValidationSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseValidationSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseValidationSample = value;
            }
        }

        /// <summary>
        /// Wait until the analyser channel is ready to perform the Sample acquisition cycle
        /// </summary>
        public StateMachineStateState WaitForSampleTrigger
        {
            get
            { 
                return m_waitForSampleTrigger;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForSampleTrigger, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForSampleTrigger = value;
            }
        }

        /// <summary>
        /// Collect the Sample from the process
        /// </summary>
        public StateMachineStateState ExtractSample
        {
            get
            { 
                return m_extractSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractSample = value;
            }
        }

        /// <summary>
        /// Prepare the Sample for the AnalyseSample state
        /// </summary>
        public StateMachineStateState PrepareSample
        {
            get
            { 
                return m_prepareSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareSample = value;
            }
        }

        /// <summary>
        /// Perform the analysis of the Sample
        /// </summary>
        public StateMachineStateState AnalyseSample
        {
            get
            { 
                return m_analyseSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseSample = value;
            }
        }

        /// <summary>
        /// Wait until the analyser channel is ready to perform the diagnostic cycle,
        /// </summary>
        public StateMachineStateState WaitForDiagnosticTrigger
        {
            get
            { 
                return m_waitForDiagnosticTrigger;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForDiagnosticTrigger, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForDiagnosticTrigger = value;
            }
        }

        /// <summary>
        /// Perform the diagnostic cycle.
        /// </summary>
        public StateMachineStateState Diagnostic
        {
            get
            { 
                return m_diagnostic;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_diagnostic, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_diagnostic = value;
            }
        }

        /// <summary>
        /// Wait until the analyser channel is ready to perform the cleaning cycle,
        /// </summary>
        public StateMachineStateState WaitForCleaningTrigger
        {
            get
            { 
                return m_waitForCleaningTrigger;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForCleaningTrigger, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForCleaningTrigger = value;
            }
        }

        /// <summary>
        /// Perform the cleaning cycle.
        /// </summary>
        public StateMachineStateState Cleaning
        {
            get
            { 
                return m_cleaning;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_cleaning, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_cleaning = value;
            }
        }

        /// <summary>
        /// Publish the results of the previous acquisition cycle
        /// </summary>
        public StateMachineStateState PublishResults
        {
            get
            { 
                return m_publishResults;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_publishResults, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_publishResults = value;
            }
        }

        /// <summary>
        /// The Sample that was just analysed is ejected from the system to allow the operator or another system to grab it
        /// </summary>
        public StateMachineStateState EjectGrabSample
        {
            get
            { 
                return m_ejectGrabSample;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_ejectGrabSample, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_ejectGrabSample = value;
            }
        }

        /// <summary>
        /// Cleanup the sampling sub-system to be ready for the next acquisition
        /// </summary>
        public StateMachineStateState CleanupSamplingSystem
        {
            get
            { 
                return m_cleanupSamplingSystem;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_cleanupSamplingSystem, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_cleanupSamplingSystem = value;
            }
        }

        /// <summary>
        /// A description for the SelectExecutionCycleToWaitForCalibrationTriggerTransition Object.
        /// </summary>
        public StateMachineTransitionState SelectExecutionCycleToWaitForCalibrationTriggerTransition
        {
            get
            { 
                return m_selectExecutionCycleToWaitForCalibrationTriggerTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_selectExecutionCycleToWaitForCalibrationTriggerTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_selectExecutionCycleToWaitForCalibrationTriggerTransition = value;
            }
        }

        /// <summary>
        /// A description for the WaitForCalibrationTriggerToExtractCalibrationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState WaitForCalibrationTriggerToExtractCalibrationSampleTransition
        {
            get
            { 
                return m_waitForCalibrationTriggerToExtractCalibrationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForCalibrationTriggerToExtractCalibrationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForCalibrationTriggerToExtractCalibrationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExtractCalibrationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState ExtractCalibrationSampleTransition
        {
            get
            { 
                return m_extractCalibrationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractCalibrationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractCalibrationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExtractCalibrationSampleToPrepareCalibrationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState ExtractCalibrationSampleToPrepareCalibrationSampleTransition
        {
            get
            { 
                return m_extractCalibrationSampleToPrepareCalibrationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractCalibrationSampleToPrepareCalibrationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractCalibrationSampleToPrepareCalibrationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the PrepareCalibrationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PrepareCalibrationSampleTransition
        {
            get
            { 
                return m_prepareCalibrationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareCalibrationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareCalibrationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the PrepareCalibrationSampleToAnalyseCalibrationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PrepareCalibrationSampleToAnalyseCalibrationSampleTransition
        {
            get
            { 
                return m_prepareCalibrationSampleToAnalyseCalibrationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareCalibrationSampleToAnalyseCalibrationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareCalibrationSampleToAnalyseCalibrationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the AnalyseCalibrationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState AnalyseCalibrationSampleTransition
        {
            get
            { 
                return m_analyseCalibrationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseCalibrationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseCalibrationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the AnalyseCalibrationSampleToPublishResultsTransition Object.
        /// </summary>
        public StateMachineTransitionState AnalyseCalibrationSampleToPublishResultsTransition
        {
            get
            { 
                return m_analyseCalibrationSampleToPublishResultsTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseCalibrationSampleToPublishResultsTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseCalibrationSampleToPublishResultsTransition = value;
            }
        }

        /// <summary>
        /// A description for the SelectExecutionCycleToWaitForValidationTriggerTransition Object.
        /// </summary>
        public StateMachineTransitionState SelectExecutionCycleToWaitForValidationTriggerTransition
        {
            get
            { 
                return m_selectExecutionCycleToWaitForValidationTriggerTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_selectExecutionCycleToWaitForValidationTriggerTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_selectExecutionCycleToWaitForValidationTriggerTransition = value;
            }
        }

        /// <summary>
        /// A description for the WaitForValidationTriggerToExtractValidationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState WaitForValidationTriggerToExtractValidationSampleTransition
        {
            get
            { 
                return m_waitForValidationTriggerToExtractValidationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForValidationTriggerToExtractValidationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForValidationTriggerToExtractValidationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExtractValidationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState ExtractValidationSampleTransition
        {
            get
            { 
                return m_extractValidationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractValidationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractValidationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExtractValidationSampleToPrepareValidationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState ExtractValidationSampleToPrepareValidationSampleTransition
        {
            get
            { 
                return m_extractValidationSampleToPrepareValidationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractValidationSampleToPrepareValidationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractValidationSampleToPrepareValidationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the PrepareValidationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PrepareValidationSampleTransition
        {
            get
            { 
                return m_prepareValidationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareValidationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareValidationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the PrepareValidationSampleToAnalyseValidationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PrepareValidationSampleToAnalyseValidationSampleTransition
        {
            get
            { 
                return m_prepareValidationSampleToAnalyseValidationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareValidationSampleToAnalyseValidationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareValidationSampleToAnalyseValidationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the AnalyseValidationSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState AnalyseValidationSampleTransition
        {
            get
            { 
                return m_analyseValidationSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseValidationSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseValidationSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the AnalyseValidationSampleToPublishResultsTransition Object.
        /// </summary>
        public StateMachineTransitionState AnalyseValidationSampleToPublishResultsTransition
        {
            get
            { 
                return m_analyseValidationSampleToPublishResultsTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseValidationSampleToPublishResultsTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseValidationSampleToPublishResultsTransition = value;
            }
        }

        /// <summary>
        /// A description for the SelectExecutionCycleToWaitForSampleTriggerTransition Object.
        /// </summary>
        public StateMachineTransitionState SelectExecutionCycleToWaitForSampleTriggerTransition
        {
            get
            { 
                return m_selectExecutionCycleToWaitForSampleTriggerTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_selectExecutionCycleToWaitForSampleTriggerTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_selectExecutionCycleToWaitForSampleTriggerTransition = value;
            }
        }

        /// <summary>
        /// A description for the WaitForSampleTriggerToExtractSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState WaitForSampleTriggerToExtractSampleTransition
        {
            get
            { 
                return m_waitForSampleTriggerToExtractSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForSampleTriggerToExtractSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForSampleTriggerToExtractSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExtractSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState ExtractSampleTransition
        {
            get
            { 
                return m_extractSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the ExtractSampleToPrepareSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState ExtractSampleToPrepareSampleTransition
        {
            get
            { 
                return m_extractSampleToPrepareSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_extractSampleToPrepareSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_extractSampleToPrepareSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the PrepareSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PrepareSampleTransition
        {
            get
            { 
                return m_prepareSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the PrepareSampleToAnalyseSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PrepareSampleToAnalyseSampleTransition
        {
            get
            { 
                return m_prepareSampleToAnalyseSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_prepareSampleToAnalyseSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_prepareSampleToAnalyseSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the AnalyseSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState AnalyseSampleTransition
        {
            get
            { 
                return m_analyseSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the AnalyseSampleToPublishResultsTransition Object.
        /// </summary>
        public StateMachineTransitionState AnalyseSampleToPublishResultsTransition
        {
            get
            { 
                return m_analyseSampleToPublishResultsTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_analyseSampleToPublishResultsTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_analyseSampleToPublishResultsTransition = value;
            }
        }

        /// <summary>
        /// A description for the SelectExecutionCycleToWaitForDiagnosticTriggerTransition Object.
        /// </summary>
        public StateMachineTransitionState SelectExecutionCycleToWaitForDiagnosticTriggerTransition
        {
            get
            { 
                return m_selectExecutionCycleToWaitForDiagnosticTriggerTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_selectExecutionCycleToWaitForDiagnosticTriggerTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_selectExecutionCycleToWaitForDiagnosticTriggerTransition = value;
            }
        }

        /// <summary>
        /// A description for the WaitForDiagnosticTriggerToDiagnosticTransition Object.
        /// </summary>
        public StateMachineTransitionState WaitForDiagnosticTriggerToDiagnosticTransition
        {
            get
            { 
                return m_waitForDiagnosticTriggerToDiagnosticTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForDiagnosticTriggerToDiagnosticTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForDiagnosticTriggerToDiagnosticTransition = value;
            }
        }

        /// <summary>
        /// A description for the DiagnosticTransition Object.
        /// </summary>
        public StateMachineTransitionState DiagnosticTransition
        {
            get
            { 
                return m_diagnosticTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_diagnosticTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_diagnosticTransition = value;
            }
        }

        /// <summary>
        /// A description for the DiagnosticToPublishResultsTransition Object.
        /// </summary>
        public StateMachineTransitionState DiagnosticToPublishResultsTransition
        {
            get
            { 
                return m_diagnosticToPublishResultsTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_diagnosticToPublishResultsTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_diagnosticToPublishResultsTransition = value;
            }
        }

        /// <summary>
        /// A description for the SelectExecutionCycleToWaitForCleaningTriggerTransition Object.
        /// </summary>
        public StateMachineTransitionState SelectExecutionCycleToWaitForCleaningTriggerTransition
        {
            get
            { 
                return m_selectExecutionCycleToWaitForCleaningTriggerTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_selectExecutionCycleToWaitForCleaningTriggerTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_selectExecutionCycleToWaitForCleaningTriggerTransition = value;
            }
        }

        /// <summary>
        /// A description for the WaitForCleaningTriggerToCleaningTransition Object.
        /// </summary>
        public StateMachineTransitionState WaitForCleaningTriggerToCleaningTransition
        {
            get
            { 
                return m_waitForCleaningTriggerToCleaningTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_waitForCleaningTriggerToCleaningTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_waitForCleaningTriggerToCleaningTransition = value;
            }
        }

        /// <summary>
        /// A description for the CleaningTransition Object.
        /// </summary>
        public StateMachineTransitionState CleaningTransition
        {
            get
            { 
                return m_cleaningTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_cleaningTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_cleaningTransition = value;
            }
        }

        /// <summary>
        /// A description for the CleaningToPublishResultsTransition Object.
        /// </summary>
        public StateMachineTransitionState CleaningToPublishResultsTransition
        {
            get
            { 
                return m_cleaningToPublishResultsTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_cleaningToPublishResultsTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_cleaningToPublishResultsTransition = value;
            }
        }

        /// <summary>
        /// A description for the PublishResultsToCleanupSamplingSystemTransition Object.
        /// </summary>
        public StateMachineTransitionState PublishResultsToCleanupSamplingSystemTransition
        {
            get
            { 
                return m_publishResultsToCleanupSamplingSystemTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_publishResultsToCleanupSamplingSystemTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_publishResultsToCleanupSamplingSystemTransition = value;
            }
        }

        /// <summary>
        /// A description for the PublishResultsToEjectGrabSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState PublishResultsToEjectGrabSampleTransition
        {
            get
            { 
                return m_publishResultsToEjectGrabSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_publishResultsToEjectGrabSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_publishResultsToEjectGrabSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the EjectGrabSampleTransition Object.
        /// </summary>
        public StateMachineTransitionState EjectGrabSampleTransition
        {
            get
            { 
                return m_ejectGrabSampleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_ejectGrabSampleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_ejectGrabSampleTransition = value;
            }
        }

        /// <summary>
        /// A description for the EjectGrabSampleToCleanupSamplingSystemTransition Object.
        /// </summary>
        public StateMachineTransitionState EjectGrabSampleToCleanupSamplingSystemTransition
        {
            get
            { 
                return m_ejectGrabSampleToCleanupSamplingSystemTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_ejectGrabSampleToCleanupSamplingSystemTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_ejectGrabSampleToCleanupSamplingSystemTransition = value;
            }
        }

        /// <summary>
        /// A description for the CleanupSamplingSystemTransition Object.
        /// </summary>
        public StateMachineTransitionState CleanupSamplingSystemTransition
        {
            get
            { 
                return m_cleanupSamplingSystemTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_cleanupSamplingSystemTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_cleanupSamplingSystemTransition = value;
            }
        }

        /// <summary>
        /// A description for the CleanupSamplingSystemToSelectExecutionCycleTransition Object.
        /// </summary>
        public StateMachineTransitionState CleanupSamplingSystemToSelectExecutionCycleTransition
        {
            get
            { 
                return m_cleanupSamplingSystemToSelectExecutionCycleTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_cleanupSamplingSystemToSelectExecutionCycleTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_cleanupSamplingSystemToSelectExecutionCycleTransition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_selectExecutionCycle != null)
            {
                children.Add(m_selectExecutionCycle);
            }

            if (m_waitForCalibrationTrigger != null)
            {
                children.Add(m_waitForCalibrationTrigger);
            }

            if (m_extractCalibrationSample != null)
            {
                children.Add(m_extractCalibrationSample);
            }

            if (m_prepareCalibrationSample != null)
            {
                children.Add(m_prepareCalibrationSample);
            }

            if (m_analyseCalibrationSample != null)
            {
                children.Add(m_analyseCalibrationSample);
            }

            if (m_waitForValidationTrigger != null)
            {
                children.Add(m_waitForValidationTrigger);
            }

            if (m_extractValidationSample != null)
            {
                children.Add(m_extractValidationSample);
            }

            if (m_prepareValidationSample != null)
            {
                children.Add(m_prepareValidationSample);
            }

            if (m_analyseValidationSample != null)
            {
                children.Add(m_analyseValidationSample);
            }

            if (m_waitForSampleTrigger != null)
            {
                children.Add(m_waitForSampleTrigger);
            }

            if (m_extractSample != null)
            {
                children.Add(m_extractSample);
            }

            if (m_prepareSample != null)
            {
                children.Add(m_prepareSample);
            }

            if (m_analyseSample != null)
            {
                children.Add(m_analyseSample);
            }

            if (m_waitForDiagnosticTrigger != null)
            {
                children.Add(m_waitForDiagnosticTrigger);
            }

            if (m_diagnostic != null)
            {
                children.Add(m_diagnostic);
            }

            if (m_waitForCleaningTrigger != null)
            {
                children.Add(m_waitForCleaningTrigger);
            }

            if (m_cleaning != null)
            {
                children.Add(m_cleaning);
            }

            if (m_publishResults != null)
            {
                children.Add(m_publishResults);
            }

            if (m_ejectGrabSample != null)
            {
                children.Add(m_ejectGrabSample);
            }

            if (m_cleanupSamplingSystem != null)
            {
                children.Add(m_cleanupSamplingSystem);
            }

            if (m_selectExecutionCycleToWaitForCalibrationTriggerTransition != null)
            {
                children.Add(m_selectExecutionCycleToWaitForCalibrationTriggerTransition);
            }

            if (m_waitForCalibrationTriggerToExtractCalibrationSampleTransition != null)
            {
                children.Add(m_waitForCalibrationTriggerToExtractCalibrationSampleTransition);
            }

            if (m_extractCalibrationSampleTransition != null)
            {
                children.Add(m_extractCalibrationSampleTransition);
            }

            if (m_extractCalibrationSampleToPrepareCalibrationSampleTransition != null)
            {
                children.Add(m_extractCalibrationSampleToPrepareCalibrationSampleTransition);
            }

            if (m_prepareCalibrationSampleTransition != null)
            {
                children.Add(m_prepareCalibrationSampleTransition);
            }

            if (m_prepareCalibrationSampleToAnalyseCalibrationSampleTransition != null)
            {
                children.Add(m_prepareCalibrationSampleToAnalyseCalibrationSampleTransition);
            }

            if (m_analyseCalibrationSampleTransition != null)
            {
                children.Add(m_analyseCalibrationSampleTransition);
            }

            if (m_analyseCalibrationSampleToPublishResultsTransition != null)
            {
                children.Add(m_analyseCalibrationSampleToPublishResultsTransition);
            }

            if (m_selectExecutionCycleToWaitForValidationTriggerTransition != null)
            {
                children.Add(m_selectExecutionCycleToWaitForValidationTriggerTransition);
            }

            if (m_waitForValidationTriggerToExtractValidationSampleTransition != null)
            {
                children.Add(m_waitForValidationTriggerToExtractValidationSampleTransition);
            }

            if (m_extractValidationSampleTransition != null)
            {
                children.Add(m_extractValidationSampleTransition);
            }

            if (m_extractValidationSampleToPrepareValidationSampleTransition != null)
            {
                children.Add(m_extractValidationSampleToPrepareValidationSampleTransition);
            }

            if (m_prepareValidationSampleTransition != null)
            {
                children.Add(m_prepareValidationSampleTransition);
            }

            if (m_prepareValidationSampleToAnalyseValidationSampleTransition != null)
            {
                children.Add(m_prepareValidationSampleToAnalyseValidationSampleTransition);
            }

            if (m_analyseValidationSampleTransition != null)
            {
                children.Add(m_analyseValidationSampleTransition);
            }

            if (m_analyseValidationSampleToPublishResultsTransition != null)
            {
                children.Add(m_analyseValidationSampleToPublishResultsTransition);
            }

            if (m_selectExecutionCycleToWaitForSampleTriggerTransition != null)
            {
                children.Add(m_selectExecutionCycleToWaitForSampleTriggerTransition);
            }

            if (m_waitForSampleTriggerToExtractSampleTransition != null)
            {
                children.Add(m_waitForSampleTriggerToExtractSampleTransition);
            }

            if (m_extractSampleTransition != null)
            {
                children.Add(m_extractSampleTransition);
            }

            if (m_extractSampleToPrepareSampleTransition != null)
            {
                children.Add(m_extractSampleToPrepareSampleTransition);
            }

            if (m_prepareSampleTransition != null)
            {
                children.Add(m_prepareSampleTransition);
            }

            if (m_prepareSampleToAnalyseSampleTransition != null)
            {
                children.Add(m_prepareSampleToAnalyseSampleTransition);
            }

            if (m_analyseSampleTransition != null)
            {
                children.Add(m_analyseSampleTransition);
            }

            if (m_analyseSampleToPublishResultsTransition != null)
            {
                children.Add(m_analyseSampleToPublishResultsTransition);
            }

            if (m_selectExecutionCycleToWaitForDiagnosticTriggerTransition != null)
            {
                children.Add(m_selectExecutionCycleToWaitForDiagnosticTriggerTransition);
            }

            if (m_waitForDiagnosticTriggerToDiagnosticTransition != null)
            {
                children.Add(m_waitForDiagnosticTriggerToDiagnosticTransition);
            }

            if (m_diagnosticTransition != null)
            {
                children.Add(m_diagnosticTransition);
            }

            if (m_diagnosticToPublishResultsTransition != null)
            {
                children.Add(m_diagnosticToPublishResultsTransition);
            }

            if (m_selectExecutionCycleToWaitForCleaningTriggerTransition != null)
            {
                children.Add(m_selectExecutionCycleToWaitForCleaningTriggerTransition);
            }

            if (m_waitForCleaningTriggerToCleaningTransition != null)
            {
                children.Add(m_waitForCleaningTriggerToCleaningTransition);
            }

            if (m_cleaningTransition != null)
            {
                children.Add(m_cleaningTransition);
            }

            if (m_cleaningToPublishResultsTransition != null)
            {
                children.Add(m_cleaningToPublishResultsTransition);
            }

            if (m_publishResultsToCleanupSamplingSystemTransition != null)
            {
                children.Add(m_publishResultsToCleanupSamplingSystemTransition);
            }

            if (m_publishResultsToEjectGrabSampleTransition != null)
            {
                children.Add(m_publishResultsToEjectGrabSampleTransition);
            }

            if (m_ejectGrabSampleTransition != null)
            {
                children.Add(m_ejectGrabSampleTransition);
            }

            if (m_ejectGrabSampleToCleanupSamplingSystemTransition != null)
            {
                children.Add(m_ejectGrabSampleToCleanupSamplingSystemTransition);
            }

            if (m_cleanupSamplingSystemTransition != null)
            {
                children.Add(m_cleanupSamplingSystemTransition);
            }

            if (m_cleanupSamplingSystemToSelectExecutionCycleTransition != null)
            {
                children.Add(m_cleanupSamplingSystemToSelectExecutionCycleTransition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.SelectExecutionCycle:
                {
                    if (createOrReplace)
                    {
                        if (SelectExecutionCycle == null)
                        {
                            if (replacement == null)
                            {
                                SelectExecutionCycle = new StateMachineInitialStateState(this);
                            }
                            else
                            {
                                SelectExecutionCycle = (StateMachineInitialStateState)replacement;
                            }
                        }
                    }

                    instance = SelectExecutionCycle;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForCalibrationTrigger:
                {
                    if (createOrReplace)
                    {
                        if (WaitForCalibrationTrigger == null)
                        {
                            if (replacement == null)
                            {
                                WaitForCalibrationTrigger = new StateMachineStateState(this);
                            }
                            else
                            {
                                WaitForCalibrationTrigger = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = WaitForCalibrationTrigger;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractCalibrationSample:
                {
                    if (createOrReplace)
                    {
                        if (ExtractCalibrationSample == null)
                        {
                            if (replacement == null)
                            {
                                ExtractCalibrationSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                ExtractCalibrationSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = ExtractCalibrationSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareCalibrationSample:
                {
                    if (createOrReplace)
                    {
                        if (PrepareCalibrationSample == null)
                        {
                            if (replacement == null)
                            {
                                PrepareCalibrationSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                PrepareCalibrationSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = PrepareCalibrationSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseCalibrationSample:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseCalibrationSample == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseCalibrationSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                AnalyseCalibrationSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = AnalyseCalibrationSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForValidationTrigger:
                {
                    if (createOrReplace)
                    {
                        if (WaitForValidationTrigger == null)
                        {
                            if (replacement == null)
                            {
                                WaitForValidationTrigger = new StateMachineStateState(this);
                            }
                            else
                            {
                                WaitForValidationTrigger = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = WaitForValidationTrigger;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractValidationSample:
                {
                    if (createOrReplace)
                    {
                        if (ExtractValidationSample == null)
                        {
                            if (replacement == null)
                            {
                                ExtractValidationSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                ExtractValidationSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = ExtractValidationSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareValidationSample:
                {
                    if (createOrReplace)
                    {
                        if (PrepareValidationSample == null)
                        {
                            if (replacement == null)
                            {
                                PrepareValidationSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                PrepareValidationSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = PrepareValidationSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseValidationSample:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseValidationSample == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseValidationSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                AnalyseValidationSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = AnalyseValidationSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForSampleTrigger:
                {
                    if (createOrReplace)
                    {
                        if (WaitForSampleTrigger == null)
                        {
                            if (replacement == null)
                            {
                                WaitForSampleTrigger = new StateMachineStateState(this);
                            }
                            else
                            {
                                WaitForSampleTrigger = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = WaitForSampleTrigger;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractSample:
                {
                    if (createOrReplace)
                    {
                        if (ExtractSample == null)
                        {
                            if (replacement == null)
                            {
                                ExtractSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                ExtractSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = ExtractSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareSample:
                {
                    if (createOrReplace)
                    {
                        if (PrepareSample == null)
                        {
                            if (replacement == null)
                            {
                                PrepareSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                PrepareSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = PrepareSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseSample:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseSample == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                AnalyseSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = AnalyseSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForDiagnosticTrigger:
                {
                    if (createOrReplace)
                    {
                        if (WaitForDiagnosticTrigger == null)
                        {
                            if (replacement == null)
                            {
                                WaitForDiagnosticTrigger = new StateMachineStateState(this);
                            }
                            else
                            {
                                WaitForDiagnosticTrigger = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = WaitForDiagnosticTrigger;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Diagnostic:
                {
                    if (createOrReplace)
                    {
                        if (Diagnostic == null)
                        {
                            if (replacement == null)
                            {
                                Diagnostic = new StateMachineStateState(this);
                            }
                            else
                            {
                                Diagnostic = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Diagnostic;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForCleaningTrigger:
                {
                    if (createOrReplace)
                    {
                        if (WaitForCleaningTrigger == null)
                        {
                            if (replacement == null)
                            {
                                WaitForCleaningTrigger = new StateMachineStateState(this);
                            }
                            else
                            {
                                WaitForCleaningTrigger = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = WaitForCleaningTrigger;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Cleaning:
                {
                    if (createOrReplace)
                    {
                        if (Cleaning == null)
                        {
                            if (replacement == null)
                            {
                                Cleaning = new StateMachineStateState(this);
                            }
                            else
                            {
                                Cleaning = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Cleaning;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PublishResults:
                {
                    if (createOrReplace)
                    {
                        if (PublishResults == null)
                        {
                            if (replacement == null)
                            {
                                PublishResults = new StateMachineStateState(this);
                            }
                            else
                            {
                                PublishResults = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = PublishResults;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EjectGrabSample:
                {
                    if (createOrReplace)
                    {
                        if (EjectGrabSample == null)
                        {
                            if (replacement == null)
                            {
                                EjectGrabSample = new StateMachineStateState(this);
                            }
                            else
                            {
                                EjectGrabSample = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = EjectGrabSample;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CleanupSamplingSystem:
                {
                    if (createOrReplace)
                    {
                        if (CleanupSamplingSystem == null)
                        {
                            if (replacement == null)
                            {
                                CleanupSamplingSystem = new StateMachineStateState(this);
                            }
                            else
                            {
                                CleanupSamplingSystem = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = CleanupSamplingSystem;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SelectExecutionCycleToWaitForCalibrationTriggerTransition:
                {
                    if (createOrReplace)
                    {
                        if (SelectExecutionCycleToWaitForCalibrationTriggerTransition == null)
                        {
                            if (replacement == null)
                            {
                                SelectExecutionCycleToWaitForCalibrationTriggerTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SelectExecutionCycleToWaitForCalibrationTriggerTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SelectExecutionCycleToWaitForCalibrationTriggerTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForCalibrationTriggerToExtractCalibrationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (WaitForCalibrationTriggerToExtractCalibrationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                WaitForCalibrationTriggerToExtractCalibrationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                WaitForCalibrationTriggerToExtractCalibrationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = WaitForCalibrationTriggerToExtractCalibrationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractCalibrationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExtractCalibrationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExtractCalibrationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExtractCalibrationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExtractCalibrationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractCalibrationSampleToPrepareCalibrationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExtractCalibrationSampleToPrepareCalibrationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExtractCalibrationSampleToPrepareCalibrationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExtractCalibrationSampleToPrepareCalibrationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExtractCalibrationSampleToPrepareCalibrationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareCalibrationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PrepareCalibrationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PrepareCalibrationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PrepareCalibrationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PrepareCalibrationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareCalibrationSampleToAnalyseCalibrationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PrepareCalibrationSampleToAnalyseCalibrationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PrepareCalibrationSampleToAnalyseCalibrationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PrepareCalibrationSampleToAnalyseCalibrationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PrepareCalibrationSampleToAnalyseCalibrationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseCalibrationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseCalibrationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseCalibrationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AnalyseCalibrationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AnalyseCalibrationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseCalibrationSampleToPublishResultsTransition:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseCalibrationSampleToPublishResultsTransition == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseCalibrationSampleToPublishResultsTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AnalyseCalibrationSampleToPublishResultsTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AnalyseCalibrationSampleToPublishResultsTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SelectExecutionCycleToWaitForValidationTriggerTransition:
                {
                    if (createOrReplace)
                    {
                        if (SelectExecutionCycleToWaitForValidationTriggerTransition == null)
                        {
                            if (replacement == null)
                            {
                                SelectExecutionCycleToWaitForValidationTriggerTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SelectExecutionCycleToWaitForValidationTriggerTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SelectExecutionCycleToWaitForValidationTriggerTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForValidationTriggerToExtractValidationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (WaitForValidationTriggerToExtractValidationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                WaitForValidationTriggerToExtractValidationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                WaitForValidationTriggerToExtractValidationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = WaitForValidationTriggerToExtractValidationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractValidationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExtractValidationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExtractValidationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExtractValidationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExtractValidationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractValidationSampleToPrepareValidationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExtractValidationSampleToPrepareValidationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExtractValidationSampleToPrepareValidationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExtractValidationSampleToPrepareValidationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExtractValidationSampleToPrepareValidationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareValidationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PrepareValidationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PrepareValidationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PrepareValidationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PrepareValidationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareValidationSampleToAnalyseValidationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PrepareValidationSampleToAnalyseValidationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PrepareValidationSampleToAnalyseValidationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PrepareValidationSampleToAnalyseValidationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PrepareValidationSampleToAnalyseValidationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseValidationSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseValidationSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseValidationSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AnalyseValidationSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AnalyseValidationSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseValidationSampleToPublishResultsTransition:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseValidationSampleToPublishResultsTransition == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseValidationSampleToPublishResultsTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AnalyseValidationSampleToPublishResultsTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AnalyseValidationSampleToPublishResultsTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SelectExecutionCycleToWaitForSampleTriggerTransition:
                {
                    if (createOrReplace)
                    {
                        if (SelectExecutionCycleToWaitForSampleTriggerTransition == null)
                        {
                            if (replacement == null)
                            {
                                SelectExecutionCycleToWaitForSampleTriggerTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SelectExecutionCycleToWaitForSampleTriggerTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SelectExecutionCycleToWaitForSampleTriggerTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForSampleTriggerToExtractSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (WaitForSampleTriggerToExtractSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                WaitForSampleTriggerToExtractSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                WaitForSampleTriggerToExtractSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = WaitForSampleTriggerToExtractSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExtractSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExtractSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExtractSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExtractSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ExtractSampleToPrepareSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (ExtractSampleToPrepareSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                ExtractSampleToPrepareSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                ExtractSampleToPrepareSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = ExtractSampleToPrepareSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PrepareSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PrepareSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PrepareSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PrepareSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PrepareSampleToAnalyseSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PrepareSampleToAnalyseSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PrepareSampleToAnalyseSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PrepareSampleToAnalyseSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PrepareSampleToAnalyseSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AnalyseSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AnalyseSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AnalyseSampleToPublishResultsTransition:
                {
                    if (createOrReplace)
                    {
                        if (AnalyseSampleToPublishResultsTransition == null)
                        {
                            if (replacement == null)
                            {
                                AnalyseSampleToPublishResultsTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                AnalyseSampleToPublishResultsTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = AnalyseSampleToPublishResultsTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SelectExecutionCycleToWaitForDiagnosticTriggerTransition:
                {
                    if (createOrReplace)
                    {
                        if (SelectExecutionCycleToWaitForDiagnosticTriggerTransition == null)
                        {
                            if (replacement == null)
                            {
                                SelectExecutionCycleToWaitForDiagnosticTriggerTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SelectExecutionCycleToWaitForDiagnosticTriggerTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SelectExecutionCycleToWaitForDiagnosticTriggerTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForDiagnosticTriggerToDiagnosticTransition:
                {
                    if (createOrReplace)
                    {
                        if (WaitForDiagnosticTriggerToDiagnosticTransition == null)
                        {
                            if (replacement == null)
                            {
                                WaitForDiagnosticTriggerToDiagnosticTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                WaitForDiagnosticTriggerToDiagnosticTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = WaitForDiagnosticTriggerToDiagnosticTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.DiagnosticTransition:
                {
                    if (createOrReplace)
                    {
                        if (DiagnosticTransition == null)
                        {
                            if (replacement == null)
                            {
                                DiagnosticTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                DiagnosticTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = DiagnosticTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.DiagnosticToPublishResultsTransition:
                {
                    if (createOrReplace)
                    {
                        if (DiagnosticToPublishResultsTransition == null)
                        {
                            if (replacement == null)
                            {
                                DiagnosticToPublishResultsTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                DiagnosticToPublishResultsTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = DiagnosticToPublishResultsTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.SelectExecutionCycleToWaitForCleaningTriggerTransition:
                {
                    if (createOrReplace)
                    {
                        if (SelectExecutionCycleToWaitForCleaningTriggerTransition == null)
                        {
                            if (replacement == null)
                            {
                                SelectExecutionCycleToWaitForCleaningTriggerTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                SelectExecutionCycleToWaitForCleaningTriggerTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = SelectExecutionCycleToWaitForCleaningTriggerTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.WaitForCleaningTriggerToCleaningTransition:
                {
                    if (createOrReplace)
                    {
                        if (WaitForCleaningTriggerToCleaningTransition == null)
                        {
                            if (replacement == null)
                            {
                                WaitForCleaningTriggerToCleaningTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                WaitForCleaningTriggerToCleaningTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = WaitForCleaningTriggerToCleaningTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CleaningTransition:
                {
                    if (createOrReplace)
                    {
                        if (CleaningTransition == null)
                        {
                            if (replacement == null)
                            {
                                CleaningTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CleaningTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CleaningTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CleaningToPublishResultsTransition:
                {
                    if (createOrReplace)
                    {
                        if (CleaningToPublishResultsTransition == null)
                        {
                            if (replacement == null)
                            {
                                CleaningToPublishResultsTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CleaningToPublishResultsTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CleaningToPublishResultsTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PublishResultsToCleanupSamplingSystemTransition:
                {
                    if (createOrReplace)
                    {
                        if (PublishResultsToCleanupSamplingSystemTransition == null)
                        {
                            if (replacement == null)
                            {
                                PublishResultsToCleanupSamplingSystemTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PublishResultsToCleanupSamplingSystemTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PublishResultsToCleanupSamplingSystemTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PublishResultsToEjectGrabSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (PublishResultsToEjectGrabSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                PublishResultsToEjectGrabSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PublishResultsToEjectGrabSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PublishResultsToEjectGrabSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EjectGrabSampleTransition:
                {
                    if (createOrReplace)
                    {
                        if (EjectGrabSampleTransition == null)
                        {
                            if (replacement == null)
                            {
                                EjectGrabSampleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                EjectGrabSampleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = EjectGrabSampleTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EjectGrabSampleToCleanupSamplingSystemTransition:
                {
                    if (createOrReplace)
                    {
                        if (EjectGrabSampleToCleanupSamplingSystemTransition == null)
                        {
                            if (replacement == null)
                            {
                                EjectGrabSampleToCleanupSamplingSystemTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                EjectGrabSampleToCleanupSamplingSystemTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = EjectGrabSampleToCleanupSamplingSystemTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CleanupSamplingSystemTransition:
                {
                    if (createOrReplace)
                    {
                        if (CleanupSamplingSystemTransition == null)
                        {
                            if (replacement == null)
                            {
                                CleanupSamplingSystemTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CleanupSamplingSystemTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CleanupSamplingSystemTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CleanupSamplingSystemToSelectExecutionCycleTransition:
                {
                    if (createOrReplace)
                    {
                        if (CleanupSamplingSystemToSelectExecutionCycleTransition == null)
                        {
                            if (replacement == null)
                            {
                                CleanupSamplingSystemToSelectExecutionCycleTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                CleanupSamplingSystemToSelectExecutionCycleTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = CleanupSamplingSystemToSelectExecutionCycleTransition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private StateMachineInitialStateState m_selectExecutionCycle;
        private StateMachineStateState m_waitForCalibrationTrigger;
        private StateMachineStateState m_extractCalibrationSample;
        private StateMachineStateState m_prepareCalibrationSample;
        private StateMachineStateState m_analyseCalibrationSample;
        private StateMachineStateState m_waitForValidationTrigger;
        private StateMachineStateState m_extractValidationSample;
        private StateMachineStateState m_prepareValidationSample;
        private StateMachineStateState m_analyseValidationSample;
        private StateMachineStateState m_waitForSampleTrigger;
        private StateMachineStateState m_extractSample;
        private StateMachineStateState m_prepareSample;
        private StateMachineStateState m_analyseSample;
        private StateMachineStateState m_waitForDiagnosticTrigger;
        private StateMachineStateState m_diagnostic;
        private StateMachineStateState m_waitForCleaningTrigger;
        private StateMachineStateState m_cleaning;
        private StateMachineStateState m_publishResults;
        private StateMachineStateState m_ejectGrabSample;
        private StateMachineStateState m_cleanupSamplingSystem;
        private StateMachineTransitionState m_selectExecutionCycleToWaitForCalibrationTriggerTransition;
        private StateMachineTransitionState m_waitForCalibrationTriggerToExtractCalibrationSampleTransition;
        private StateMachineTransitionState m_extractCalibrationSampleTransition;
        private StateMachineTransitionState m_extractCalibrationSampleToPrepareCalibrationSampleTransition;
        private StateMachineTransitionState m_prepareCalibrationSampleTransition;
        private StateMachineTransitionState m_prepareCalibrationSampleToAnalyseCalibrationSampleTransition;
        private StateMachineTransitionState m_analyseCalibrationSampleTransition;
        private StateMachineTransitionState m_analyseCalibrationSampleToPublishResultsTransition;
        private StateMachineTransitionState m_selectExecutionCycleToWaitForValidationTriggerTransition;
        private StateMachineTransitionState m_waitForValidationTriggerToExtractValidationSampleTransition;
        private StateMachineTransitionState m_extractValidationSampleTransition;
        private StateMachineTransitionState m_extractValidationSampleToPrepareValidationSampleTransition;
        private StateMachineTransitionState m_prepareValidationSampleTransition;
        private StateMachineTransitionState m_prepareValidationSampleToAnalyseValidationSampleTransition;
        private StateMachineTransitionState m_analyseValidationSampleTransition;
        private StateMachineTransitionState m_analyseValidationSampleToPublishResultsTransition;
        private StateMachineTransitionState m_selectExecutionCycleToWaitForSampleTriggerTransition;
        private StateMachineTransitionState m_waitForSampleTriggerToExtractSampleTransition;
        private StateMachineTransitionState m_extractSampleTransition;
        private StateMachineTransitionState m_extractSampleToPrepareSampleTransition;
        private StateMachineTransitionState m_prepareSampleTransition;
        private StateMachineTransitionState m_prepareSampleToAnalyseSampleTransition;
        private StateMachineTransitionState m_analyseSampleTransition;
        private StateMachineTransitionState m_analyseSampleToPublishResultsTransition;
        private StateMachineTransitionState m_selectExecutionCycleToWaitForDiagnosticTriggerTransition;
        private StateMachineTransitionState m_waitForDiagnosticTriggerToDiagnosticTransition;
        private StateMachineTransitionState m_diagnosticTransition;
        private StateMachineTransitionState m_diagnosticToPublishResultsTransition;
        private StateMachineTransitionState m_selectExecutionCycleToWaitForCleaningTriggerTransition;
        private StateMachineTransitionState m_waitForCleaningTriggerToCleaningTransition;
        private StateMachineTransitionState m_cleaningTransition;
        private StateMachineTransitionState m_cleaningToPublishResultsTransition;
        private StateMachineTransitionState m_publishResultsToCleanupSamplingSystemTransition;
        private StateMachineTransitionState m_publishResultsToEjectGrabSampleTransition;
        private StateMachineTransitionState m_ejectGrabSampleTransition;
        private StateMachineTransitionState m_ejectGrabSampleToCleanupSamplingSystemTransition;
        private StateMachineTransitionState m_cleanupSamplingSystemTransition;
        private StateMachineTransitionState m_cleanupSamplingSystemToSelectExecutionCycleTransition;
        #endregion
    }
    #endif
    #endregion

    #region StreamState Class
    #if (!OPCUA_EXCLUDE_StreamState)
    /// <summary>
    /// Stores an instance of the StreamType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class StreamState : TopologyElementState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public StreamState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.StreamType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQASAAAAU3RyZWFtVHlwZUluc3RhbmNlAQHyAwEB8gP/" +
           "////CAAAACRggAoBAAAAAgAMAAAAUGFyYW1ldGVyU2V0AQHkFAMAAAAAFwAAAEZsYXQgbGlzdCBvZiBQ" +
           "YXJhbWV0ZXJzAC8AOuQUAAD/////GwAAADVgiQoCAAAAAQAJAAAASXNFbmFibGVkAQFTGQMAAAAANQAA" +
           "AFRydWUgaWYgdGhpcyBzdHJlYW0gbWF5YmUgdXNlZCB0byBwZXJmb3JtIGFjcXVpc2l0aW9uAC8BAD0J" +
           "UxkAAAAB/////wEBAQAAAAAjAQEB5hQAAAAANWCJCgIAAAABAAgAAABJc0ZvcmNlZAEBVhkDAAAAAIIA" +
           "AABUcnVlIGlmIHRoaXMgc3RyZWFtIGlzIGZpcmNlZCwgd2hpY2ggbWVhbnMgdGhhdCBpcyB0aGUgb25s" +
           "eSBTdHJlYW0gb24gdGhpcyBBbmFseXNlckNoYW5uZWwgdGhhdCBjYW4gYmUgdXNlZCB0byBwZXJmb3Jt" +
           "IGFjcXVpc2l0aW9uAC8BAD0JVhkAAAAB/////wEB/////wAAAAA1YIkKAgAAAAEAEAAAAERpYWdub3N0" +
           "aWNTdGF0dXMBAVkZAwAAAAAUAAAAU3RyZWFtIGhlYWx0aCBzdGF0dXMALwEAPQlZGQAAAQG6C/////8B" +
           "AQEAAAAAIwEBAecUAAAAADVgiQoCAAAAAQATAAAATGFzdENhbGlicmF0aW9uVGltZQEBXBkDAAAAACoA" +
           "AABUaW1lIGF0IHdoaWNoIHRoZSBsYXN0IGNhbGlicmF0aW9uIHdhcyBydW4ALwEAPQlcGQAAAA3/////" +
           "AQH/////AAAAADVgiQoCAAAAAQASAAAATGFzdFZhbGlkYXRpb25UaW1lAQFfGQMAAAAAKQAAAFRpbWUg" +
           "YXQgd2hpY2ggdGhlIGxhc3QgdmFsaWRhdGlvbiB3YXMgcnVuAC8BAD0JXxkAAAAN/////wEB/////wAA" +
           "AAA1YIkKAgAAAAEADgAAAExhc3RTYW1wbGVUaW1lAQFiGQMAAAAAKgAAAFRpbWUgYXQgd2hpY2ggdGhl" +
           "IGxhc3Qgc2FtcGxlIHdhcyBhY3F1aXJlZAAvAQA9CWIZAAAADf////8BAQEAAAAAIwEBAecUAAAAADVg" +
           "iQoCAAAAAQASAAAAVGltZUJldHdlZW5TYW1wbGVzAQFlGQMAAAAARAAAAE51bWJlciBvZiBtaWxsaXNl" +
           "Y29uZHMgYmV0d2VlbiB0d28gY29uc2VjdXRpdmUgc3RhcnRzIG9mIGFjcXVpc2l0aW9uAC8BAEAJZRkA" +
           "AAEAIgH/////AQH/////AQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBaBkALgBEaBkAAAEAdAP/////" +
           "AQH/////AAAAADVgiQoCAAAAAQAIAAAASXNBY3RpdmUBAWsZAwAAAAA3AAAAVHJ1ZSBpZiB0aGlzIHN0" +
           "cmVhbSBpcyBhY3R1YWxseSBydW5uaW5nLCBhY3F1aXJpbmcgZGF0YQAvAQA9CWsZAAAAAf////8BAQEA" +
           "AAAAIwEBAekUAAAAADVgiQoCAAAAAQAOAAAARXhlY3V0aW9uQ3ljbGUBARMkAwAAAAAuAAAASW5kaWNh" +
           "dGVzIHdoaWNoIEV4ZWN1dGlvbiBjeWNsZSBpcyBpbiBwcm9ncmVzcwAvAQA9CRMkAAABAaIk/////wEB" +
           "AQAAAAAjAQEB6RQAAAAANWCJCgIAAAABABUAAABFeGVjdXRpb25DeWNsZVN1YmNvZGUBARQkAwAAAAA2" +
           "AAAASW5kaWNhdGVzIHdoaWNoIEV4ZWN1dGlvbiBjeWNsZSBzdWJjb2RlIGlzIGluIHByb2dyZXNzAC8B" +
           "AEgJFCQAAAAc/////wEBAQAAAAAjAQEB6RQBAAAAFWCJCgIAAAAAAAsAAABFbnVtU3RyaW5ncwEBFyQA" +
           "LgBEFyQAAAAVAQAAAAEB/////wAAAAA1YIkKAgAAAAEACAAAAFByb2dyZXNzAQFvGQMAAAAAdAAAAElu" +
           "ZGljYXRlcyB0aGUgcHJvZ3Jlc3Mgb2YgYW4gYWNxdWlzaXRpb24gaW4gdGVybXMgb2YgcGVyY2VudGFn" +
           "ZSBvZiBjb21wbGV0aW9uLiBJdHMgdmFsdWUgc2hhbGwgYmUgYmV0d2VlbiAwIGFuZCAxMDAuAC8BAD0J" +
           "bxkAAAAK/////wEBAQAAAAAjAQEB6RQAAAAANWCJCgIAAAABABIAAABBY3F1aXNpdGlvbkNvdW50ZXIB" +
           "AXIZAwAAAABTAAAAU2ltcGxlIGNvdW50ZXIgaW5jcmVtZW50ZWQgYWZ0ZXIgZWFjaCBTYW1wbGluZyBh" +
           "Y3F1aXNpdGlvbiBwZXJmb3JtZWQgb24gdGhpcyBTdHJlYW0ALwEAQAlyGQAAAQAhAf////8BAQEAAAAA" +
           "IwEBAeoUAQAAABVgiQoCAAAAAAAHAAAARVVSYW5nZQEBdRkALgBEdRkAAAEAdAP/////AQH/////AAAA" +
           "ADVgiQoCAAAAAQAXAAAAQWNxdWlzaXRpb25SZXN1bHRTdGF0dXMBAXgZAwAAAAAaAAAAUXVhbGl0eSBv" +
           "ZiB0aGUgYWNxdWlzaXRpb24ALwEAPQl4GQAAAQG7C/////8BAQEAAAAAIwEBAeoUAAAAADVgiQoCAAAA" +
           "AQAHAAAAUmF3RGF0YQEBexkDAAAAAD8AAABSYXcgZGF0YSBwcm9kdWNlZCBhcyBhIHJlc3VsdCBvZiBk" +
           "YXRhIGFjcXVpc2l0aW9uIG9uIHRoZSBTdHJlYW0ALwEAPQl7GQAAABj/////AQH/////AAAAADVgiQoC" +
           "AAAAAQAKAAAAU2NhbGVkRGF0YQEBfhkDAAAAAGgAAABTY2FsZWQgZGF0YSBwcm9kdWNlZCBhcyBhIHJl" +
           "c3VsdCBvZiBkYXRhIGFjcXVpc2l0aW9uIG9uIHRoZSBTdHJlYW0gYW5kIGFwcGxpY2F0aW9uIG9mIHRo" +
           "ZSBhbmFseXNlciBtb2RlbAAvAQA9CX4ZAAAAGP////8BAQEAAAAAIwEBAeoUAAAAADVgiQoCAAAAAQAS" +
           "AAAAQWNxdWlzaXRpb25FbmRUaW1lAQGBGQMAAAAApwAAAFRoZSBlbmQgdGltZSBvZiB0aGUgQW5hbHlz" +
           "ZVNhbXBsZSBvciBBbmFseXNlQ2FsaWJyYXRpb25TYW1wbGUgb3IgQW5hbHlzZVZhbGlkYXRpb25TYW1w" +
           "bGUgc3RhdGUgb2YgdGhlIEFuYWx5c2VyQ2hhbm5lbF9PcGVyYXRpbmdNb2RlRXhlY3V0ZVN1YlN0YXRl" +
           "TWFjaGluZSBzdGF0ZSBtYWNoaW5lAC8BAD0JgRkAAAAN/////wEBAQAAAAAjAQEB6hQAAAAANWCJCgIA" +
           "AAABAAoAAABDYW1wYWlnbklkAQGEGQMAAAAAHAAAAERlZmluZXMgdGhlIGN1cnJlbnQgY2FtcGFpZ24A" +
           "LwEAPQmEGQAAAAz/////AwP/////AAAAADVgiQoCAAAAAQAHAAAAQmF0Y2hJZAEBhxkDAAAAABkAAABE" +
           "ZWZpbmVzIHRoZSBjdXJyZW50IGJhdGNoAC8BAD0JhxkAAAAM/////wMD/////wAAAAA1YIkKAgAAAAEA" +
           "CgAAAFN1YkJhdGNoSWQBAYoZAwAAAAAdAAAARGVmaW5lcyB0aGUgY3VycmVudCBzdWItYmF0Y2gALwEA" +
           "PQmKGQAAAAz/////AwP/////AAAAADVgiQoCAAAAAQAFAAAATG90SWQBAY0ZAwAAAAAXAAAARGVmaW5l" +
           "cyB0aGUgY3VycmVudCBsb3QALwEAPQmNGQAAAAz/////AwP/////AAAAADVgiQoCAAAAAQAKAAAATWF0" +
           "ZXJpYWxJZAEBkBkDAAAAABwAAABEZWZpbmVzIHRoZSBjdXJyZW50IG1hdGVyaWFsAC8BAD0JkBkAAAAM" +
           "/////wMD/////wAAAAA1YIkKAgAAAAEABwAAAFByb2Nlc3MBAZMZAwAAAAAUAAAAQ3VycmVudCBQcm9j" +
           "ZXNzIG5hbWUALwEAPQmTGQAAAAz/////AwP/////AAAAADVgiQoCAAAAAQAEAAAAVW5pdAEBlhkDAAAA" +
           "ABEAAABDdXJyZW50IFVuaXQgbmFtZQAvAQA9CZYZAAAADP////8DA/////8AAAAANWCJCgIAAAABAAkA" +
           "AABPcGVyYXRpb24BAZkZAwAAAAAWAAAAQ3VycmVudCBPcGVyYXRpb24gbmFtZQAvAQA9CZkZAAAADP//" +
           "//8DA/////8AAAAANWCJCgIAAAABAAUAAABQaGFzZQEBnBkDAAAAABIAAABDdXJyZW50IFBoYXNlIG5h" +
           "bWUALwEAPQmcGQAAAAz/////AwP/////AAAAADVgiQoCAAAAAQAGAAAAVXNlcklkAQGfGQMAAAAAPQAA" +
           "AExvZ2luIG5hbWUgb2YgdGhlIHVzZXIgd2hvIGlzIGxvZ2dlZCBvbiBhdCB0aGUgZGV2aWNlIGNvbnNv" +
           "bGUALwEAPQmfGQAAAAz/////AwP/////AAAAADVgiQoCAAAAAQAIAAAAU2FtcGxlSWQBAaIZAwAAAAAZ" +
           "AAAASWRlbnRpZmllciBmb3IgdGhlIHNhbXBsZQAvAQA9CaIZAAAADP////8DA/////8AAAAABGCACgEA" +
           "AAABAA0AAABDb25maWd1cmF0aW9uAQHmFAAvAQLtA+YUAAABAAAAACMAAQFTGQAAAAAEYIAKAQAAAAEA" +
           "BgAAAFN0YXR1cwEB5xQALwEC7QPnFAAAAgAAAAAjAAEBWRkAIwABAWIZAAAAAARggAoBAAAAAQATAAAA" +
           "QWNxdWlzaXRpb25TZXR0aW5ncwEB6BQALwEC7QPoFAAA/////wAAAAAEYIAKAQAAAAEAEQAAAEFjcXVp" +
           "c2l0aW9uU3RhdHVzAQHpFAAvAQLtA+kUAAAEAAAAACMAAQFrGQAjAAEBEyQAIwABARQkACMAAQFvGQAA" +
           "AAAEYIAKAQAAAAEADwAAAEFjcXVpc2l0aW9uRGF0YQEB6hQALwEC7QPqFAAABAAAAAAjAAEBchkAIwAB" +
           "AXgZACMAAQF+GQAjAAEBgRkAAAAABGCACgEAAAABABgAAABDaGVtb21ldHJpY01vZGVsU2V0dGluZ3MB" +
           "AesUAC8BAu0D6xQAAP////8AAAAABGCACgEAAAABAAcAAABDb250ZXh0AQHsFAAvAQLtA+wUAAD/////" +
           "AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Configuration Object.
        /// </summary>
        public FunctionalGroupState Configuration
        {
            get
            { 
                return m_configuration;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_configuration, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_configuration = value;
            }
        }

        /// <summary>
        /// A description for the Status Object.
        /// </summary>
        public FunctionalGroupState Status
        {
            get
            { 
                return m_status;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_status, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_status = value;
            }
        }

        /// <summary>
        /// A description for the AcquisitionSettings Object.
        /// </summary>
        public FunctionalGroupState AcquisitionSettings
        {
            get
            { 
                return m_acquisitionSettings;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_acquisitionSettings, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_acquisitionSettings = value;
            }
        }

        /// <summary>
        /// A description for the AcquisitionStatus Object.
        /// </summary>
        public FunctionalGroupState AcquisitionStatus
        {
            get
            { 
                return m_acquisitionStatus;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_acquisitionStatus, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_acquisitionStatus = value;
            }
        }

        /// <summary>
        /// A description for the AcquisitionData Object.
        /// </summary>
        public FunctionalGroupState AcquisitionData
        {
            get
            { 
                return m_acquisitionData;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_acquisitionData, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_acquisitionData = value;
            }
        }

        /// <summary>
        /// A description for the ChemometricModelSettings Object.
        /// </summary>
        public FunctionalGroupState ChemometricModelSettings
        {
            get
            { 
                return m_chemometricModelSettings;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_chemometricModelSettings, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_chemometricModelSettings = value;
            }
        }

        /// <summary>
        /// A description for the Context Object.
        /// </summary>
        public FunctionalGroupState Context
        {
            get
            { 
                return m_context;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_context, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_context = value;
            }
        }

        /// <summary>
        /// A description for the <GroupIdentifier> Object.
        /// </summary>
        public FunctionalGroupState GroupIdentifier
        {
            get
            { 
                return m_groupIdentifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_groupIdentifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_groupIdentifier = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_configuration != null)
            {
                children.Add(m_configuration);
            }

            if (m_status != null)
            {
                children.Add(m_status);
            }

            if (m_acquisitionSettings != null)
            {
                children.Add(m_acquisitionSettings);
            }

            if (m_acquisitionStatus != null)
            {
                children.Add(m_acquisitionStatus);
            }

            if (m_acquisitionData != null)
            {
                children.Add(m_acquisitionData);
            }

            if (m_chemometricModelSettings != null)
            {
                children.Add(m_chemometricModelSettings);
            }

            if (m_context != null)
            {
                children.Add(m_context);
            }

            if (m_groupIdentifier != null)
            {
                children.Add(m_groupIdentifier);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Configuration:
                {
                    if (createOrReplace)
                    {
                        if (Configuration == null)
                        {
                            if (replacement == null)
                            {
                                Configuration = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Configuration = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Configuration;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Status:
                {
                    if (createOrReplace)
                    {
                        if (Status == null)
                        {
                            if (replacement == null)
                            {
                                Status = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Status = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Status;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AcquisitionSettings:
                {
                    if (createOrReplace)
                    {
                        if (AcquisitionSettings == null)
                        {
                            if (replacement == null)
                            {
                                AcquisitionSettings = new FunctionalGroupState(this);
                            }
                            else
                            {
                                AcquisitionSettings = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = AcquisitionSettings;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AcquisitionStatus:
                {
                    if (createOrReplace)
                    {
                        if (AcquisitionStatus == null)
                        {
                            if (replacement == null)
                            {
                                AcquisitionStatus = new FunctionalGroupState(this);
                            }
                            else
                            {
                                AcquisitionStatus = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = AcquisitionStatus;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AcquisitionData:
                {
                    if (createOrReplace)
                    {
                        if (AcquisitionData == null)
                        {
                            if (replacement == null)
                            {
                                AcquisitionData = new FunctionalGroupState(this);
                            }
                            else
                            {
                                AcquisitionData = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = AcquisitionData;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ChemometricModelSettings:
                {
                    if (createOrReplace)
                    {
                        if (ChemometricModelSettings == null)
                        {
                            if (replacement == null)
                            {
                                ChemometricModelSettings = new FunctionalGroupState(this);
                            }
                            else
                            {
                                ChemometricModelSettings = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = ChemometricModelSettings;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Context:
                {
                    if (createOrReplace)
                    {
                        if (Context == null)
                        {
                            if (replacement == null)
                            {
                                Context = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Context = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Context;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FunctionalGroupState m_configuration;
        private FunctionalGroupState m_status;
        private FunctionalGroupState m_acquisitionSettings;
        private FunctionalGroupState m_acquisitionStatus;
        private FunctionalGroupState m_acquisitionData;
        private FunctionalGroupState m_chemometricModelSettings;
        private FunctionalGroupState m_context;
        private FunctionalGroupState m_groupIdentifier;
        #endregion
    }
    #endif
    #endregion

    #region SpectrometerDeviceState Class
    #if (!OPCUA_EXCLUDE_SpectrometerDeviceState)
    /// <summary>
    /// Stores an instance of the SpectrometerDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SpectrometerDeviceState : AnalyserDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SpectrometerDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.SpectrometerDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAeAAAAU3BlY3Ryb21ldGVyRGV2aWNlVHlwZUluc3Rh" +
           "bmNlAQHzAwEB8wMB/////w4AAAAkYIAKAQAAAAIADAAAAFBhcmFtZXRlclNldAEB7RQDAAAAABcAAABG" +
           "bGF0IGxpc3Qgb2YgUGFyYW1ldGVycwAvADrtFAAA/////wwAAAA1YIkKAgAAAAEAEAAAAERpYWdub3N0" +
           "aWNTdGF0dXMBAawZAwAAAAAlAAAAR2VuZXJhbCBoZWFsdGggc3RhdHVzIG9mIHRoZSBhbmFseXNlcgAv" +
           "AQA9CawZAAABAboL/////wEBAQAAAAAjAQEB8BQAAAAANWCJCgIAAAABABIAAABPdXRPZlNwZWNpZmlj" +
           "YXRpb24BAa8ZAwAAAABkAAAARGV2aWNlIGJlaW5nIG9wZXJhdGVkIG91dCBvZiBTcGVjaWZpY2F0aW9u" +
           "LiBVbmNlcnRhaW4gdmFsdWUgZHVlIHRvIHByb2Nlc3MgYW5kIGVudmlyb25tZW50IGluZmx1ZW5jZQAv" +
           "AQBFCa8ZAAAAAf////8BAQEAAAAAIwEBAfAUAgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEBshkA" +
           "LgBEshkAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBsxkALgBEsxkAAAAV" +
           "/////wEB/////wAAAAA1YIkKAgAAAAEADQAAAEZ1bmN0aW9uQ2hlY2sBAbQZAwAAAABFAAAATG9jYWwg" +
           "b3BlcmF0aW9uLCBjb25maWd1cmF0aW9uIGlzIGNoYW5naW5nLCBzdWJzdGl0dXRlIHZhbHVlIGVudGVy" +
           "ZWQuAC8BAEUJtBkAAAAB/////wEBAQAAAAAjAQEB8BQCAAAAFWCJCgIAAAAAAAoAAABGYWxzZVN0YXRl" +
           "AQG3GQAuAES3GQAAABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQG4GQAuAES4" +
           "GQAAABX/////AQH/////AAAAADVgiQoCAAAAAQAMAAAAU2VyaWFsTnVtYmVyAQG5GQMAAAAATQAAAElk" +
           "ZW50aWZpZXIgdGhhdCB1bmlxdWVseSBpZGVudGlmaWVzLCB3aXRoaW4gYSBtYW51ZmFjdHVyZXIsIGEg" +
           "ZGV2aWNlIGluc3RhbmNlAC8BAD0JuRkAAAAM/////wEBAgAAAAAjAQEBGCQAIwEBAfEUAAAAADVgiQoC" +
           "AAAAAQAMAAAATWFudWZhY3R1cmVyAQG8GQMAAAAAMAAAAE5hbWUgb2YgdGhlIGNvbXBhbnkgdGhhdCBt" +
           "YW51ZmFjdHVyZWQgdGhlIGRldmljZQAvAQA9CbwZAAAAFf////8BAQIAAAAAIwEBARgkACMBAQHxFAAA" +
           "AAA1YIkKAgAAAAEABQAAAE1vZGVsAQG/GQMAAAAAGAAAAE1vZGVsIG5hbWUgb2YgdGhlIGRldmljZQAv" +
           "AQA9Cb8ZAAAAFf////8BAQIAAAAAIwEBARgkACMBAQHxFAAAAAA1YIkKAgAAAAEADAAAAERldmljZU1h" +
           "bnVhbAEBwhkDAAAAAFoAAABBZGRyZXNzIChwYXRobmFtZSBpbiB0aGUgZmlsZSBzeXN0ZW0gb3IgYSBV" +
           "UkwgfCBXZWIgYWRkcmVzcykgb2YgdXNlciBtYW51YWwgZm9yIHRoZSBkZXZpY2UALwEAPQnCGQAAAAz/" +
           "////AQEBAAAAACMBAQHxFAAAAAA1YIkKAgAAAAEADgAAAERldmljZVJldmlzaW9uAQHFGQMAAAAAJAAA" +
           "AE92ZXJhbGwgcmV2aXNpb24gbGV2ZWwgb2YgdGhlIGRldmljZQAvAQA9CcUZAAAADP////8BAQEAAAAA" +
           "IwEBAfEUAAAAADVgiQoCAAAAAQAQAAAAU29mdHdhcmVSZXZpc2lvbgEByBkDAAAAADUAAABSZXZpc2lv" +
           "biBsZXZlbCBvZiB0aGUgc29mdHdhcmUvZmlybXdhcmUgb2YgdGhlIGRldmljZQAvAQA9CcgZAAAADP//" +
           "//8BAQEAAAAAIwEBAfEUAAAAADVgiQoCAAAAAQAQAAAASGFyZHdhcmVSZXZpc2lvbgEByxkDAAAAACwA" +
           "AABSZXZpc2lvbiBsZXZlbCBvZiB0aGUgaGFyZHdhcmUgb2YgdGhlIGRldmljZQAvAQA9CcsZAAAADP//" +
           "//8BAQEAAAAAIwEBAfEUAAAAADVgiQoCAAAAAQAPAAAAUmV2aXNpb25Db3VudGVyAQHOGQMAAAAAaQAA" +
           "AEFuIGluY3JlbWVudGFsIGNvdW50ZXIgaW5kaWNhdGluZyB0aGUgbnVtYmVyIG9mIHRpbWVzIHRoZSBz" +
           "dGF0aWMgZGF0YSB3aXRoaW4gdGhlIERldmljZSBoYXMgYmVlbiBtb2RpZmllZAAvAQA9Cc4ZAAAAB///" +
           "//8BAQEAAAAAIwEBAfEUAAAAABVgiQoCAAAAAQANAAAAU3BlY3RyYWxSYW5nZQEB9hkALwEAPQn2GQAA" +
           "AQB0AwEAAAABAf////8AAAAAJGCACgEAAAACAAkAAABNZXRob2RTZXQBAe4UAwAAAAAUAAAARmxhdCBs" +
           "aXN0IG9mIE1ldGhvZHMALwA67hQAAP////8KAAAABGGCCgQAAAABABAAAABHZXRDb25maWd1cmF0aW9u" +
           "AQEaJAAvAQGeHxokAAABAf////8BAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBARskAC4A" +
           "RBskAACWAQAAAAEAKgEBGQAAAAoAAABDb25maWdEYXRhAA//////AAAAAAABACgBAQAAAAEB/////wAA" +
           "AAAEYYIKBAAAAAEAEAAAAFNldENvbmZpZ3VyYXRpb24BARwkAC8BAaAfHCQAAAEB/////wIAAAAVYKkK" +
           "AgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEdJAAuAEQdJAAAlgEAAAABACoBARkAAAAKAAAAQ29uZmln" +
           "RGF0YQAP/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVu" +
           "dHMBAR4kAC4ARB4kAACWAQAAAAEAKgEBHwAAABAAAABDb25maWdEYXRhRGlnZXN0AAz/////AAAAAAAB" +
           "ACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEAEwAAAEdldENvbmZpZ0RhdGFEaWdlc3QBAR8kAC8BAaMf" +
           "HyQAAAEB/////wEAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBICQALgBEICQAAJYBAAAA" +
           "AQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP////8AAAAAAAEAKAEBAAAAAQH/////AAAAAARh" +
           "ggoEAAAAAQAXAAAAQ29tcGFyZUNvbmZpZ0RhdGFEaWdlc3QBASEkAC8BAaUfISQAAAEB/////wIAAAAV" +
           "YKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEiJAAuAEQiJAAAlgEAAAABACoBAR8AAAAQAAAAQ29u" +
           "ZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRw" +
           "dXRBcmd1bWVudHMBASMkAC4ARCMkAACWAQAAAAEAKgEBFgAAAAcAAABJc0VxdWFsAAH/////AAAAAAAB" +
           "ACgBAQAAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAFJlc2V0QWxsQ2hhbm5lbHMBASQkAwAAAAA8AAAA" +
           "UmVzZXQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5hbHlzZXJEZXZpY2Uu" +
           "AC8BAagfJCQAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAFN0YXJ0QWxsQ2hhbm5lbHMBASUkAwAAAAA8" +
           "AAAAU3RhcnQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5hbHlzZXJEZXZp" +
           "Y2UuAC8BAakfJSQAAAEB/////wAAAAAkYYIKBAAAAAEADwAAAFN0b3BBbGxDaGFubmVscwEBJiQDAAAA" +
           "ADsAAABTdG9wIGFsbCBBbmFseXNlckNoYW5uZWxzIGJlbG9uZ2luZyB0byB0aGlzIEFuYWx5c2VyRGV2" +
           "aWNlLgAvAQGqHyYkAAABAf////8AAAAAJGGCCgQAAAABABAAAABBYm9ydEFsbENoYW5uZWxzAQEnJAMA" +
           "AAAAPAAAAEFib3J0IGFsbCBBbmFseXNlckNoYW5uZWxzIGJlbG9uZ2luZyB0byB0aGlzIEFuYWx5c2Vy" +
           "RGV2aWNlLgAvAQGrHyckAAABAf////8AAAAAJGGCCgQAAAABAA0AAABHb3RvT3BlcmF0aW5nAQEoJAMA" +
           "AAAAjQAAAEFuYWx5c2VyRGV2aWNlU3RhdGVNYWNoaW5lIHRvIGdvIHRvIE9wZXJhdGluZyBzdGF0ZSwg" +
           "Zm9yY2luZyBhbGwgQW5hbHlzZXJDaGFubmVscyB0byBsZWF2ZSB0aGUgU2xhdmVNb2RlIHN0YXRlIGFu" +
           "ZCBnbyB0byB0aGUgT3BlcmF0aW5nIHN0YXRlLgAvAQGsHygkAAABAf////8AAAAAJGGCCgQAAAABAA8A" +
           "AABHb3RvTWFpbnRlbmFuY2UBASkkAwAAAABnAAAAQW5hbHlzZXJEZXZpY2VTdGF0ZU1hY2hpbmUgdG8g" +
           "Z28gdG8gTWFpbnRlbmFuY2Ugc3RhdGUsIGZvcmNpbmcgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgdG8gU2xh" +
           "dmVNb2RlIHN0YXRlLgAvAQGtHykkAAABAf////8AAAAANWCJCgIAAAACAAwAAABTZXJpYWxOdW1iZXIB" +
           "AaUZAwAAAABNAAAASWRlbnRpZmllciB0aGF0IHVuaXF1ZWx5IGlkZW50aWZpZXMsIHdpdGhpbiBhIG1h" +
           "bnVmYWN0dXJlciwgYSBkZXZpY2UgaW5zdGFuY2UALgBEpRkAAAAM/////wEB/////wAAAAA1YIkKAgAA" +
           "AAIADwAAAFJldmlzaW9uQ291bnRlcgEBGSQDAAAAAGkAAABBbiBpbmNyZW1lbnRhbCBjb3VudGVyIGlu" +
           "ZGljYXRpbmcgdGhlIG51bWJlciBvZiB0aW1lcyB0aGUgc3RhdGljIGRhdGEgd2l0aGluIHRoZSBEZXZp" +
           "Y2UgaGFzIGJlZW4gbW9kaWZpZWQALgBEGSQAAAAG/////wEB/////wAAAAA1YIkKAgAAAAIADAAAAE1h" +
           "bnVmYWN0dXJlcgEBphkDAAAAABgAAABNb2RlbCBuYW1lIG9mIHRoZSBkZXZpY2UALgBEphkAAAAV////" +
           "/wEB/////wAAAAA1YIkKAgAAAAIABQAAAE1vZGVsAQGnGQMAAAAAMAAAAE5hbWUgb2YgdGhlIGNvbXBh" +
           "bnkgdGhhdCBtYW51ZmFjdHVyZWQgdGhlIGRldmljZQAuAESnGQAAABX/////AQH/////AAAAADVgiQoC" +
           "AAAAAgAMAAAARGV2aWNlTWFudWFsAQGoGQMAAAAAWgAAAEFkZHJlc3MgKHBhdGhuYW1lIGluIHRoZSBm" +
           "aWxlIHN5c3RlbSBvciBhIFVSTCB8IFdlYiBhZGRyZXNzKSBvZiB1c2VyIG1hbnVhbCBmb3IgdGhlIGRl" +
           "dmljZQAuAESoGQAAAAz/////AQH/////AAAAADVgiQoCAAAAAgAOAAAARGV2aWNlUmV2aXNpb24BAakZ" +
           "AwAAAAAkAAAAT3ZlcmFsbCByZXZpc2lvbiBsZXZlbCBvZiB0aGUgZGV2aWNlAC4ARKkZAAAADP////8B" +
           "Af////8AAAAANWCJCgIAAAACABAAAABTb2Z0d2FyZVJldmlzaW9uAQGqGQMAAAAANQAAAFJldmlzaW9u" +
           "IGxldmVsIG9mIHRoZSBzb2Z0d2FyZS9maXJtd2FyZSBvZiB0aGUgZGV2aWNlAC4ARKoZAAAADP////8B" +
           "Af////8AAAAANWCJCgIAAAACABAAAABIYXJkd2FyZVJldmlzaW9uAQGrGQMAAAAALAAAAFJldmlzaW9u" +
           "IGxldmVsIG9mIHRoZSBoYXJkd2FyZSBvZiB0aGUgZGV2aWNlAC4ARKsZAAAADP////8BAf////8AAAAA" +
           "BGCACgEAAAABAA0AAABDb25maWd1cmF0aW9uAQHvFAAvAQLtA+8UAAD/////AAAAAARggAoBAAAAAQAG" +
           "AAAAU3RhdHVzAQHwFAAvAQLtA/AUAAADAAAAACMAAQGsGQAjAAEBrxkAIwABAbQZAAAAAARggAoBAAAA" +
           "AQAPAAAARmFjdG9yeVNldHRpbmdzAQHxFAAvAQLtA/EUAAAIAAAAACMAAQG5GQAjAAEBvBkAIwABAb8Z" +
           "ACMAAQHCGQAjAAEBxRkAIwABAcgZACMAAQHLGQAjAAEBzhkAAAAABGCACgEAAAABABQAAABBbmFseXNl" +
           "clN0YXRlTWFjaGluZQEB8hQALwEB6gPyFAAAAgAAAAAvAAEBrR8ALwABAawfEAAAABVgiQoCAAAAAAAM" +
           "AAAAQ3VycmVudFN0YXRlAQHXGQAvAQDICtcZAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJ" +
           "ZAEB2BkALgBE2BkAAAAR/////wEB/////wAAAAAkYIAKAQAAAAEABwAAAFBvd2VydXABAfMUAwAAAABR" +
           "AAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIGl0cyBwb3dlci11cCBzZXF1ZW5jZSBhbmQgY2Fubm90" +
           "IHBlcmZvcm0gYW55IG90aGVyIHRhc2suAC8BAAUJ8xQAAAEAAAAAMwEBAfgUAAAAACRggAoBAAAAAQAJ" +
           "AAAAT3BlcmF0aW5nAQH0FAMAAAAALAAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0aGUgT3BlcmF0" +
           "aW5nIG1vZGUuAC8BAAMJ9BQAAAYAAAAANAEBAfgUADMBAQH5FAAzAQEB+hQANAEBAfsUADQBAQH9FAAz" +
           "AQEB/xQAAAAAJGCACgEAAAABAAUAAABMb2NhbAEB9RQDAAAAAHoAAABUaGUgQW5hbHlzZXJEZXZpY2Ug" +
           "aXMgaW4gdGhlIExvY2FsIG1vZGUuIFRoaXMgbW9kZSBpcyBub3JtYWxseSB1c2VkIHRvIHBlcmZvcm0g" +
           "bG9jYWwgcGh5c2ljYWwgbWFpbnRlbmFuY2Ugb24gdGhlIGFuYWx5c2VyLgAvAQADCfUUAAAFAAAAADQB" +
           "AQH5FAAzAQEB+xQAMwEBAfwUADQBAQH+FAAzAQEBABUAAAAAJGCACgEAAAABAAsAAABNYWludGVuYW5j" +
           "ZQEB9hQDAAAAAIUAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gdGhlIE1haW50ZW5hbmNlIG1vZGUu" +
           "IFRoaXMgbW9kZSBpcyB1c2VkIHRvIHBlcmZvcm0gcmVtb3RlIG1haW50ZW5hbmNlIG9uIHRoZSBhbmFs" +
           "eXNlciBsaWtlIGZpcm13YXJlIHVwZ3JhZGUuAC8BAAMJ9hQAAAUAAAAANAEBAfoUADQBAQH8FAAzAQEB" +
           "/RQAMwEBAf4UADMBAQEBFQAAAAAkYIAKAQAAAAEACAAAAFNodXRkb3duAQH3FAMAAAAAUwAAAFRoZSBB" +
           "bmFseXNlckRldmljZSBpcyBpbiBpdHMgcG93ZXItZG93biBzZXF1ZW5jZSBhbmQgY2Fubm90IHBlcmZv" +
           "cm0gYW55IG90aGVyIHRhc2suAC8BAAMJ9xQAAAMAAAAANAEBAf8UADQBAQEAFQA0AQEBARUAAAAABGCA" +
           "CgEAAAABABwAAABQb3dlcnVwVG9PcGVyYXRpbmdUcmFuc2l0aW9uAQH4FAAvAQAGCfgUAAACAAAAADMA" +
           "AQHzFAA0AAEB9BQAAAAABGCACgEAAAABABoAAABPcGVyYXRpbmdUb0xvY2FsVHJhbnNpdGlvbgEB+RQA" +
           "LwEABgn5FAAAAgAAAAAzAAEB9BQANAABAfUUAAAAAARggAoBAAAAAQAgAAAAT3BlcmF0aW5nVG9NYWlu" +
           "dGVuYW5jZVRyYW5zaXRpb24BAfoUAC8BAAYJ+hQAAAMAAAAAMwABAfQUADQAAQH2FAA1AAEBrR8AAAAA" +
           "BGCACgEAAAABABoAAABMb2NhbFRvT3BlcmF0aW5nVHJhbnNpdGlvbgEB+xQALwEABgn7FAAAAgAAAAAz" +
           "AAEB9RQANAABAfQUAAAAAARggAoBAAAAAQAcAAAATG9jYWxUb01haW50ZW5hbmNlVHJhbnNpdGlvbgEB" +
           "/BQALwEABgn8FAAAAgAAAAAzAAEB9RQANAABAfYUAAAAAARggAoBAAAAAQAgAAAATWFpbnRlbmFuY2VU" +
           "b09wZXJhdGluZ1RyYW5zaXRpb24BAf0UAC8BAAYJ/RQAAAMAAAAAMwABAfYUADQAAQH0FAA1AAEBrB8A" +
           "AAAABGCACgEAAAABABwAAABNYWludGVuYW5jZVRvTG9jYWxUcmFuc2l0aW9uAQH+FAAvAQAGCf4UAAAC" +
           "AAAAADMAAQH2FAA0AAEB9RQAAAAABGCACgEAAAABAB0AAABPcGVyYXRpbmdUb1NodXRkb3duVHJhbnNp" +
           "dGlvbgEB/xQALwEABgn/FAAAAgAAAAAzAAEB9BQANAABAfcUAAAAAARggAoBAAAAAQAZAAAATG9jYWxU" +
           "b1NodXRkb3duVHJhbnNpdGlvbgEBABUALwEABgkAFQAAAgAAAAAzAAEB9RQANAABAfcUAAAAAARggAoB" +
           "AAAAAQAfAAAATWFpbnRlbmFuY2VUb1NodXRkb3duVHJhbnNpdGlvbgEBARUALwEABgkBFQAAAgAAAAAz" +
           "AAEB9hQANAABAfcUAAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region ParticleSizeMonitorDeviceState Class
    #if (!OPCUA_EXCLUDE_ParticleSizeMonitorDeviceState)
    /// <summary>
    /// Stores an instance of the ParticleSizeMonitorDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ParticleSizeMonitorDeviceState : AnalyserDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ParticleSizeMonitorDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.ParticleSizeMonitorDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAlAAAAUGFydGljbGVTaXplTW9uaXRvckRldmljZVR5" +
           "cGVJbnN0YW5jZQEB9AMBAfQDAf////8OAAAAJGCACgEAAAACAAwAAABQYXJhbWV0ZXJTZXQBAQIVAwAA" +
           "AAAXAAAARmxhdCBsaXN0IG9mIFBhcmFtZXRlcnMALwA6AhUAAP////8LAAAANWCJCgIAAAABABAAAABE" +
           "aWFnbm9zdGljU3RhdHVzAQEAGgMAAAAAJQAAAEdlbmVyYWwgaGVhbHRoIHN0YXR1cyBvZiB0aGUgYW5h" +
           "bHlzZXIALwEAPQkAGgAAAQG6C/////8BAQEAAAAAIwEBAQUVAAAAADVgiQoCAAAAAQASAAAAT3V0T2ZT" +
           "cGVjaWZpY2F0aW9uAQEDGgMAAAAAZAAAAERldmljZSBiZWluZyBvcGVyYXRlZCBvdXQgb2YgU3BlY2lm" +
           "aWNhdGlvbi4gVW5jZXJ0YWluIHZhbHVlIGR1ZSB0byBwcm9jZXNzIGFuZCBlbnZpcm9ubWVudCBpbmZs" +
           "dWVuY2UALwEARQkDGgAAAAH/////AQEBAAAAACMBAQEFFQIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3Rh" +
           "dGUBAQYaAC4ARAYaAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAQcaAC4A" +
           "RAcaAAAAFf////8BAf////8AAAAANWCJCgIAAAABAA0AAABGdW5jdGlvbkNoZWNrAQEIGgMAAAAARQAA" +
           "AExvY2FsIG9wZXJhdGlvbiwgY29uZmlndXJhdGlvbiBpcyBjaGFuZ2luZywgc3Vic3RpdHV0ZSB2YWx1" +
           "ZSBlbnRlcmVkLgAvAQBFCQgaAAAAAf////8BAQEAAAAAIwEBAQUVAgAAABVgiQoCAAAAAAAKAAAARmFs" +
           "c2VTdGF0ZQEBCxoALgBECxoAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEB" +
           "DBoALgBEDBoAAAAV/////wEB/////wAAAAA1YIkKAgAAAAEADAAAAFNlcmlhbE51bWJlcgEBDRoDAAAA" +
           "AE0AAABJZGVudGlmaWVyIHRoYXQgdW5pcXVlbHkgaWRlbnRpZmllcywgd2l0aGluIGEgbWFudWZhY3R1" +
           "cmVyLCBhIGRldmljZSBpbnN0YW5jZQAvAQA9CQ0aAAAADP////8BAQIAAAAAIwEBASokACMBAQEGFQAA" +
           "AAA1YIkKAgAAAAEADAAAAE1hbnVmYWN0dXJlcgEBEBoDAAAAADAAAABOYW1lIG9mIHRoZSBjb21wYW55" +
           "IHRoYXQgbWFudWZhY3R1cmVkIHRoZSBkZXZpY2UALwEAPQkQGgAAABX/////AQECAAAAACMBAQEqJAAj" +
           "AQEBBhUAAAAANWCJCgIAAAABAAUAAABNb2RlbAEBExoDAAAAABgAAABNb2RlbCBuYW1lIG9mIHRoZSBk" +
           "ZXZpY2UALwEAPQkTGgAAABX/////AQECAAAAACMBAQEqJAAjAQEBBhUAAAAANWCJCgIAAAABAAwAAABE" +
           "ZXZpY2VNYW51YWwBARYaAwAAAABaAAAAQWRkcmVzcyAocGF0aG5hbWUgaW4gdGhlIGZpbGUgc3lzdGVt" +
           "IG9yIGEgVVJMIHwgV2ViIGFkZHJlc3MpIG9mIHVzZXIgbWFudWFsIGZvciB0aGUgZGV2aWNlAC8BAD0J" +
           "FhoAAAAM/////wEBAQAAAAAjAQEBBhUAAAAANWCJCgIAAAABAA4AAABEZXZpY2VSZXZpc2lvbgEBGRoD" +
           "AAAAACQAAABPdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBkZXZpY2UALwEAPQkZGgAAAAz/////" +
           "AQEBAAAAACMBAQEGFQAAAAA1YIkKAgAAAAEAEAAAAFNvZnR3YXJlUmV2aXNpb24BARwaAwAAAAA1AAAA" +
           "UmV2aXNpb24gbGV2ZWwgb2YgdGhlIHNvZnR3YXJlL2Zpcm13YXJlIG9mIHRoZSBkZXZpY2UALwEAPQkc" +
           "GgAAAAz/////AQEBAAAAACMBAQEGFQAAAAA1YIkKAgAAAAEAEAAAAEhhcmR3YXJlUmV2aXNpb24BAR8a" +
           "AwAAAAAsAAAAUmV2aXNpb24gbGV2ZWwgb2YgdGhlIGhhcmR3YXJlIG9mIHRoZSBkZXZpY2UALwEAPQkf" +
           "GgAAAAz/////AQEBAAAAACMBAQEGFQAAAAA1YIkKAgAAAAEADwAAAFJldmlzaW9uQ291bnRlcgEBIhoD" +
           "AAAAAGkAAABBbiBpbmNyZW1lbnRhbCBjb3VudGVyIGluZGljYXRpbmcgdGhlIG51bWJlciBvZiB0aW1l" +
           "cyB0aGUgc3RhdGljIGRhdGEgd2l0aGluIHRoZSBEZXZpY2UgaGFzIGJlZW4gbW9kaWZpZWQALwEAPQki" +
           "GgAAAAf/////AQEBAAAAACMBAQEGFQAAAAAkYIAKAQAAAAIACQAAAE1ldGhvZFNldAEBAxUDAAAAABQA" +
           "AABGbGF0IGxpc3Qgb2YgTWV0aG9kcwAvADoDFQAA/////woAAAAEYYIKBAAAAAEAEAAAAEdldENvbmZp" +
           "Z3VyYXRpb24BASwkAC8BAZ4fLCQAAAEB/////wEAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50" +
           "cwEBLSQALgBELSQAAJYBAAAAAQAqAQEZAAAACgAAAENvbmZpZ0RhdGEAD/////8AAAAAAAEAKAEBAAAA" +
           "AQH/////AAAAAARhggoEAAAAAQAQAAAAU2V0Q29uZmlndXJhdGlvbgEBLiQALwEBoB8uJAAAAQH/////" +
           "AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAS8kAC4ARC8kAACWAQAAAAEAKgEBGQAAAAoA" +
           "AABDb25maWdEYXRhAA//////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1" +
           "dEFyZ3VtZW50cwEBMCQALgBEMCQAAJYBAAAAAQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP//" +
           "//8AAAAAAAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQATAAAAR2V0Q29uZmlnRGF0YURpZ2VzdAEB" +
           "MSQALwEBox8xJAAAAQH/////AQAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEyJAAuAEQy" +
           "JAAAlgEAAAABACoBAR8AAAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAABAf//" +
           "//8AAAAABGGCCgQAAAABABcAAABDb21wYXJlQ29uZmlnRGF0YURpZ2VzdAEBMyQALwEBpR8zJAAAAQH/" +
           "////AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBATQkAC4ARDQkAACWAQAAAAEAKgEBHwAA" +
           "ABAAAABDb25maWdEYXRhRGlnZXN0AAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAA" +
           "DwAAAE91dHB1dEFyZ3VtZW50cwEBNSQALgBENSQAAJYBAAAAAQAqAQEWAAAABwAAAElzRXF1YWwAAf//" +
           "//8AAAAAAAEAKAEBAAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAUmVzZXRBbGxDaGFubmVscwEBNiQD" +
           "AAAAADwAAABSZXNldCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNl" +
           "ckRldmljZS4ALwEBqB82JAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAU3RhcnRBbGxDaGFubmVscwEB" +
           "NyQDAAAAADwAAABTdGFydCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFs" +
           "eXNlckRldmljZS4ALwEBqR83JAAAAQH/////AAAAACRhggoEAAAAAQAPAAAAU3RvcEFsbENoYW5uZWxz" +
           "AQE4JAMAAAAAOwAAAFN0b3AgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5h" +
           "bHlzZXJEZXZpY2UuAC8BAaofOCQAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAEFib3J0QWxsQ2hhbm5l" +
           "bHMBATkkAwAAAAA8AAAAQWJvcnQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMg" +
           "QW5hbHlzZXJEZXZpY2UuAC8BAasfOSQAAAEB/////wAAAAAkYYIKBAAAAAEADQAAAEdvdG9PcGVyYXRp" +
           "bmcBATokAwAAAACNAAAAQW5hbHlzZXJEZXZpY2VTdGF0ZU1hY2hpbmUgdG8gZ28gdG8gT3BlcmF0aW5n" +
           "IHN0YXRlLCBmb3JjaW5nIGFsbCBBbmFseXNlckNoYW5uZWxzIHRvIGxlYXZlIHRoZSBTbGF2ZU1vZGUg" +
           "c3RhdGUgYW5kIGdvIHRvIHRoZSBPcGVyYXRpbmcgc3RhdGUuAC8BAawfOiQAAAEB/////wAAAAAkYYIK" +
           "BAAAAAEADwAAAEdvdG9NYWludGVuYW5jZQEBOyQDAAAAAGcAAABBbmFseXNlckRldmljZVN0YXRlTWFj" +
           "aGluZSB0byBnbyB0byBNYWludGVuYW5jZSBzdGF0ZSwgZm9yY2luZyBhbGwgQW5hbHlzZXJDaGFubmVs" +
           "cyB0byBTbGF2ZU1vZGUgc3RhdGUuAC8BAa0fOyQAAAEB/////wAAAAA1YIkKAgAAAAIADAAAAFNlcmlh" +
           "bE51bWJlcgEB+RkDAAAAAE0AAABJZGVudGlmaWVyIHRoYXQgdW5pcXVlbHkgaWRlbnRpZmllcywgd2l0" +
           "aGluIGEgbWFudWZhY3R1cmVyLCBhIGRldmljZSBpbnN0YW5jZQAuAET5GQAAAAz/////AQH/////AAAA" +
           "ADVgiQoCAAAAAgAPAAAAUmV2aXNpb25Db3VudGVyAQErJAMAAAAAaQAAAEFuIGluY3JlbWVudGFsIGNv" +
           "dW50ZXIgaW5kaWNhdGluZyB0aGUgbnVtYmVyIG9mIHRpbWVzIHRoZSBzdGF0aWMgZGF0YSB3aXRoaW4g" +
           "dGhlIERldmljZSBoYXMgYmVlbiBtb2RpZmllZAAuAEQrJAAAAAb/////AQH/////AAAAADVgiQoCAAAA" +
           "AgAMAAAATWFudWZhY3R1cmVyAQH6GQMAAAAAGAAAAE1vZGVsIG5hbWUgb2YgdGhlIGRldmljZQAuAET6" +
           "GQAAABX/////AQH/////AAAAADVgiQoCAAAAAgAFAAAATW9kZWwBAfsZAwAAAAAwAAAATmFtZSBvZiB0" +
           "aGUgY29tcGFueSB0aGF0IG1hbnVmYWN0dXJlZCB0aGUgZGV2aWNlAC4ARPsZAAAAFf////8BAf////8A" +
           "AAAANWCJCgIAAAACAAwAAABEZXZpY2VNYW51YWwBAfwZAwAAAABaAAAAQWRkcmVzcyAocGF0aG5hbWUg" +
           "aW4gdGhlIGZpbGUgc3lzdGVtIG9yIGEgVVJMIHwgV2ViIGFkZHJlc3MpIG9mIHVzZXIgbWFudWFsIGZv" +
           "ciB0aGUgZGV2aWNlAC4ARPwZAAAADP////8BAf////8AAAAANWCJCgIAAAACAA4AAABEZXZpY2VSZXZp" +
           "c2lvbgEB/RkDAAAAACQAAABPdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBkZXZpY2UALgBE/RkA" +
           "AAAM/////wEB/////wAAAAA1YIkKAgAAAAIAEAAAAFNvZnR3YXJlUmV2aXNpb24BAf4ZAwAAAAA1AAAA" +
           "UmV2aXNpb24gbGV2ZWwgb2YgdGhlIHNvZnR3YXJlL2Zpcm13YXJlIG9mIHRoZSBkZXZpY2UALgBE/hkA" +
           "AAAM/////wEB/////wAAAAA1YIkKAgAAAAIAEAAAAEhhcmR3YXJlUmV2aXNpb24BAf8ZAwAAAAAsAAAA" +
           "UmV2aXNpb24gbGV2ZWwgb2YgdGhlIGhhcmR3YXJlIG9mIHRoZSBkZXZpY2UALgBE/xkAAAAM/////wEB" +
           "/////wAAAAAEYIAKAQAAAAEADQAAAENvbmZpZ3VyYXRpb24BAQQVAC8BAu0DBBUAAP////8AAAAABGCA" +
           "CgEAAAABAAYAAABTdGF0dXMBAQUVAC8BAu0DBRUAAAMAAAAAIwABAQAaACMAAQEDGgAjAAEBCBoAAAAA" +
           "BGCACgEAAAABAA8AAABGYWN0b3J5U2V0dGluZ3MBAQYVAC8BAu0DBhUAAAgAAAAAIwABAQ0aACMAAQEQ" +
           "GgAjAAEBExoAIwABARYaACMAAQEZGgAjAAEBHBoAIwABAR8aACMAAQEiGgAAAAAEYIAKAQAAAAEAFAAA" +
           "AEFuYWx5c2VyU3RhdGVNYWNoaW5lAQEHFQAvAQHqAwcVAAACAAAAAC8AAQGtHwAvAAEBrB8QAAAAFWCJ" +
           "CgIAAAAAAAwAAABDdXJyZW50U3RhdGUBASsaAC8BAMgKKxoAAAAV/////wEB/////wEAAAAVYIkKAgAA" +
           "AAAAAgAAAElkAQEsGgAuAEQsGgAAABH/////AQH/////AAAAACRggAoBAAAAAQAHAAAAUG93ZXJ1cAEB" +
           "CBUDAAAAAFEAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gaXRzIHBvd2VyLXVwIHNlcXVlbmNlIGFu" +
           "ZCBjYW5ub3QgcGVyZm9ybSBhbnkgb3RoZXIgdGFzay4ALwEABQkIFQAAAQAAAAAzAQEBDRUAAAAAJGCA" +
           "CgEAAAABAAkAAABPcGVyYXRpbmcBAQkVAwAAAAAsAAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRo" +
           "ZSBPcGVyYXRpbmcgbW9kZS4ALwEAAwkJFQAABgAAAAA0AQEBDRUAMwEBAQ4VADMBAQEPFQA0AQEBEBUA" +
           "NAEBARIVADMBAQEUFQAAAAAkYIAKAQAAAAEABQAAAExvY2FsAQEKFQMAAAAAegAAAFRoZSBBbmFseXNl" +
           "ckRldmljZSBpcyBpbiB0aGUgTG9jYWwgbW9kZS4gVGhpcyBtb2RlIGlzIG5vcm1hbGx5IHVzZWQgdG8g" +
           "cGVyZm9ybSBsb2NhbCBwaHlzaWNhbCBtYWludGVuYW5jZSBvbiB0aGUgYW5hbHlzZXIuAC8BAAMJChUA" +
           "AAUAAAAANAEBAQ4VADMBAQEQFQAzAQEBERUANAEBARMVADMBAQEVFQAAAAAkYIAKAQAAAAEACwAAAE1h" +
           "aW50ZW5hbmNlAQELFQMAAAAAhQAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0aGUgTWFpbnRlbmFu" +
           "Y2UgbW9kZS4gVGhpcyBtb2RlIGlzIHVzZWQgdG8gcGVyZm9ybSByZW1vdGUgbWFpbnRlbmFuY2Ugb24g" +
           "dGhlIGFuYWx5c2VyIGxpa2UgZmlybXdhcmUgdXBncmFkZS4ALwEAAwkLFQAABQAAAAA0AQEBDxUANAEB" +
           "AREVADMBAQESFQAzAQEBExUAMwEBARYVAAAAACRggAoBAAAAAQAIAAAAU2h1dGRvd24BAQwVAwAAAABT" +
           "AAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIGl0cyBwb3dlci1kb3duIHNlcXVlbmNlIGFuZCBjYW5u" +
           "b3QgcGVyZm9ybSBhbnkgb3RoZXIgdGFzay4ALwEAAwkMFQAAAwAAAAA0AQEBFBUANAEBARUVADQBAQEW" +
           "FQAAAAAEYIAKAQAAAAEAHAAAAFBvd2VydXBUb09wZXJhdGluZ1RyYW5zaXRpb24BAQ0VAC8BAAYJDRUA" +
           "AAIAAAAAMwABAQgVADQAAQEJFQAAAAAEYIAKAQAAAAEAGgAAAE9wZXJhdGluZ1RvTG9jYWxUcmFuc2l0" +
           "aW9uAQEOFQAvAQAGCQ4VAAACAAAAADMAAQEJFQA0AAEBChUAAAAABGCACgEAAAABACAAAABPcGVyYXRp" +
           "bmdUb01haW50ZW5hbmNlVHJhbnNpdGlvbgEBDxUALwEABgkPFQAAAwAAAAAzAAEBCRUANAABAQsVADUA" +
           "AQGtHwAAAAAEYIAKAQAAAAEAGgAAAExvY2FsVG9PcGVyYXRpbmdUcmFuc2l0aW9uAQEQFQAvAQAGCRAV" +
           "AAACAAAAADMAAQEKFQA0AAEBCRUAAAAABGCACgEAAAABABwAAABMb2NhbFRvTWFpbnRlbmFuY2VUcmFu" +
           "c2l0aW9uAQERFQAvAQAGCREVAAACAAAAADMAAQEKFQA0AAEBCxUAAAAABGCACgEAAAABACAAAABNYWlu" +
           "dGVuYW5jZVRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBEhUALwEABgkSFQAAAwAAAAAzAAEBCxUANAABAQkV" +
           "ADUAAQGsHwAAAAAEYIAKAQAAAAEAHAAAAE1haW50ZW5hbmNlVG9Mb2NhbFRyYW5zaXRpb24BARMVAC8B" +
           "AAYJExUAAAIAAAAAMwABAQsVADQAAQEKFQAAAAAEYIAKAQAAAAEAHQAAAE9wZXJhdGluZ1RvU2h1dGRv" +
           "d25UcmFuc2l0aW9uAQEUFQAvAQAGCRQVAAACAAAAADMAAQEJFQA0AAEBDBUAAAAABGCACgEAAAABABkA" +
           "AABMb2NhbFRvU2h1dGRvd25UcmFuc2l0aW9uAQEVFQAvAQAGCRUVAAACAAAAADMAAQEKFQA0AAEBDBUA" +
           "AAAABGCACgEAAAABAB8AAABNYWludGVuYW5jZVRvU2h1dGRvd25UcmFuc2l0aW9uAQEWFQAvAQAGCRYV" +
           "AAACAAAAADMAAQELFQA0AAEBDBUAAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region ChromatographDeviceState Class
    #if (!OPCUA_EXCLUDE_ChromatographDeviceState)
    /// <summary>
    /// Stores an instance of the ChromatographDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ChromatographDeviceState : AnalyserDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ChromatographDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.ChromatographDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAfAAAAQ2hyb21hdG9ncmFwaERldmljZVR5cGVJbnN0" +
           "YW5jZQEB9QMBAfUDAf////8OAAAAJGCACgEAAAACAAwAAABQYXJhbWV0ZXJTZXQBARcVAwAAAAAXAAAA" +
           "RmxhdCBsaXN0IG9mIFBhcmFtZXRlcnMALwA6FxUAAP////8LAAAANWCJCgIAAAABABAAAABEaWFnbm9z" +
           "dGljU3RhdHVzAQFRGgMAAAAAJQAAAEdlbmVyYWwgaGVhbHRoIHN0YXR1cyBvZiB0aGUgYW5hbHlzZXIA" +
           "LwEAPQlRGgAAAQG6C/////8BAQEAAAAAIwEBARoVAAAAADVgiQoCAAAAAQASAAAAT3V0T2ZTcGVjaWZp" +
           "Y2F0aW9uAQFUGgMAAAAAZAAAAERldmljZSBiZWluZyBvcGVyYXRlZCBvdXQgb2YgU3BlY2lmaWNhdGlv" +
           "bi4gVW5jZXJ0YWluIHZhbHVlIGR1ZSB0byBwcm9jZXNzIGFuZCBlbnZpcm9ubWVudCBpbmZsdWVuY2UA" +
           "LwEARQlUGgAAAAH/////AQEBAAAAACMBAQEaFQIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAVca" +
           "AC4ARFcaAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAVgaAC4ARFgaAAAA" +
           "Ff////8BAf////8AAAAANWCJCgIAAAABAA0AAABGdW5jdGlvbkNoZWNrAQFZGgMAAAAARQAAAExvY2Fs" +
           "IG9wZXJhdGlvbiwgY29uZmlndXJhdGlvbiBpcyBjaGFuZ2luZywgc3Vic3RpdHV0ZSB2YWx1ZSBlbnRl" +
           "cmVkLgAvAQBFCVkaAAAAAf////8BAQEAAAAAIwEBARoVAgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0" +
           "ZQEBXBoALgBEXBoAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBXRoALgBE" +
           "XRoAAAAV/////wEB/////wAAAAA1YIkKAgAAAAEADAAAAFNlcmlhbE51bWJlcgEBXhoDAAAAAE0AAABJ" +
           "ZGVudGlmaWVyIHRoYXQgdW5pcXVlbHkgaWRlbnRpZmllcywgd2l0aGluIGEgbWFudWZhY3R1cmVyLCBh" +
           "IGRldmljZSBpbnN0YW5jZQAvAQA9CV4aAAAADP////8BAQIAAAAAIwEBATwkACMBAQEbFQAAAAA1YIkK" +
           "AgAAAAEADAAAAE1hbnVmYWN0dXJlcgEBYRoDAAAAADAAAABOYW1lIG9mIHRoZSBjb21wYW55IHRoYXQg" +
           "bWFudWZhY3R1cmVkIHRoZSBkZXZpY2UALwEAPQlhGgAAABX/////AQECAAAAACMBAQE8JAAjAQEBGxUA" +
           "AAAANWCJCgIAAAABAAUAAABNb2RlbAEBZBoDAAAAABgAAABNb2RlbCBuYW1lIG9mIHRoZSBkZXZpY2UA" +
           "LwEAPQlkGgAAABX/////AQECAAAAACMBAQE8JAAjAQEBGxUAAAAANWCJCgIAAAABAAwAAABEZXZpY2VN" +
           "YW51YWwBAWcaAwAAAABaAAAAQWRkcmVzcyAocGF0aG5hbWUgaW4gdGhlIGZpbGUgc3lzdGVtIG9yIGEg" +
           "VVJMIHwgV2ViIGFkZHJlc3MpIG9mIHVzZXIgbWFudWFsIGZvciB0aGUgZGV2aWNlAC8BAD0JZxoAAAAM" +
           "/////wEBAQAAAAAjAQEBGxUAAAAANWCJCgIAAAABAA4AAABEZXZpY2VSZXZpc2lvbgEBahoDAAAAACQA" +
           "AABPdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBkZXZpY2UALwEAPQlqGgAAAAz/////AQEBAAAA" +
           "ACMBAQEbFQAAAAA1YIkKAgAAAAEAEAAAAFNvZnR3YXJlUmV2aXNpb24BAW0aAwAAAAA1AAAAUmV2aXNp" +
           "b24gbGV2ZWwgb2YgdGhlIHNvZnR3YXJlL2Zpcm13YXJlIG9mIHRoZSBkZXZpY2UALwEAPQltGgAAAAz/" +
           "////AQEBAAAAACMBAQEbFQAAAAA1YIkKAgAAAAEAEAAAAEhhcmR3YXJlUmV2aXNpb24BAXAaAwAAAAAs" +
           "AAAAUmV2aXNpb24gbGV2ZWwgb2YgdGhlIGhhcmR3YXJlIG9mIHRoZSBkZXZpY2UALwEAPQlwGgAAAAz/" +
           "////AQEBAAAAACMBAQEbFQAAAAA1YIkKAgAAAAEADwAAAFJldmlzaW9uQ291bnRlcgEBcxoDAAAAAGkA" +
           "AABBbiBpbmNyZW1lbnRhbCBjb3VudGVyIGluZGljYXRpbmcgdGhlIG51bWJlciBvZiB0aW1lcyB0aGUg" +
           "c3RhdGljIGRhdGEgd2l0aGluIHRoZSBEZXZpY2UgaGFzIGJlZW4gbW9kaWZpZWQALwEAPQlzGgAAAAf/" +
           "////AQEBAAAAACMBAQEbFQAAAAAkYIAKAQAAAAIACQAAAE1ldGhvZFNldAEBGBUDAAAAABQAAABGbGF0" +
           "IGxpc3Qgb2YgTWV0aG9kcwAvADoYFQAA/////woAAAAEYYIKBAAAAAEAEAAAAEdldENvbmZpZ3VyYXRp" +
           "b24BAT4kAC8BAZ4fPiQAAAEB/////wEAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBPyQA" +
           "LgBEPyQAAJYBAAAAAQAqAQEZAAAACgAAAENvbmZpZ0RhdGEAD/////8AAAAAAAEAKAEBAAAAAQH/////" +
           "AAAAAARhggoEAAAAAQAQAAAAU2V0Q29uZmlndXJhdGlvbgEBQCQALwEBoB9AJAAAAQH/////AgAAABVg" +
           "qQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAUEkAC4AREEkAACWAQAAAAEAKgEBGQAAAAoAAABDb25m" +
           "aWdEYXRhAA//////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3Vt" +
           "ZW50cwEBQiQALgBEQiQAAJYBAAAAAQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP////8AAAAA" +
           "AAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQATAAAAR2V0Q29uZmlnRGF0YURpZ2VzdAEBQyQALwEB" +
           "ox9DJAAAAQH/////AQAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQFEJAAuAEREJAAAlgEA" +
           "AAABACoBAR8AAAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAA" +
           "BGGCCgQAAAABABcAAABDb21wYXJlQ29uZmlnRGF0YURpZ2VzdAEBRSQALwEBpR9FJAAAAQH/////AgAA" +
           "ABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAUYkAC4AREYkAACWAQAAAAEAKgEBHwAAABAAAABD" +
           "b25maWdEYXRhRGlnZXN0AAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91" +
           "dHB1dEFyZ3VtZW50cwEBRyQALgBERyQAAJYBAAAAAQAqAQEWAAAABwAAAElzRXF1YWwAAf////8AAAAA" +
           "AAEAKAEBAAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAUmVzZXRBbGxDaGFubmVscwEBSCQDAAAAADwA" +
           "AABSZXNldCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRldmlj" +
           "ZS4ALwEBqB9IJAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAU3RhcnRBbGxDaGFubmVscwEBSSQDAAAA" +
           "ADwAAABTdGFydCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRl" +
           "dmljZS4ALwEBqR9JJAAAAQH/////AAAAACRhggoEAAAAAQAPAAAAU3RvcEFsbENoYW5uZWxzAQFKJAMA" +
           "AAAAOwAAAFN0b3AgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5hbHlzZXJE" +
           "ZXZpY2UuAC8BAaofSiQAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAEFib3J0QWxsQ2hhbm5lbHMBAUsk" +
           "AwAAAAA8AAAAQWJvcnQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5hbHlz" +
           "ZXJEZXZpY2UuAC8BAasfSyQAAAEB/////wAAAAAkYYIKBAAAAAEADQAAAEdvdG9PcGVyYXRpbmcBAUwk" +
           "AwAAAACNAAAAQW5hbHlzZXJEZXZpY2VTdGF0ZU1hY2hpbmUgdG8gZ28gdG8gT3BlcmF0aW5nIHN0YXRl" +
           "LCBmb3JjaW5nIGFsbCBBbmFseXNlckNoYW5uZWxzIHRvIGxlYXZlIHRoZSBTbGF2ZU1vZGUgc3RhdGUg" +
           "YW5kIGdvIHRvIHRoZSBPcGVyYXRpbmcgc3RhdGUuAC8BAawfTCQAAAEB/////wAAAAAkYYIKBAAAAAEA" +
           "DwAAAEdvdG9NYWludGVuYW5jZQEBTSQDAAAAAGcAAABBbmFseXNlckRldmljZVN0YXRlTWFjaGluZSB0" +
           "byBnbyB0byBNYWludGVuYW5jZSBzdGF0ZSwgZm9yY2luZyBhbGwgQW5hbHlzZXJDaGFubmVscyB0byBT" +
           "bGF2ZU1vZGUgc3RhdGUuAC8BAa0fTSQAAAEB/////wAAAAA1YIkKAgAAAAIADAAAAFNlcmlhbE51bWJl" +
           "cgEBShoDAAAAAE0AAABJZGVudGlmaWVyIHRoYXQgdW5pcXVlbHkgaWRlbnRpZmllcywgd2l0aGluIGEg" +
           "bWFudWZhY3R1cmVyLCBhIGRldmljZSBpbnN0YW5jZQAuAERKGgAAAAz/////AQH/////AAAAADVgiQoC" +
           "AAAAAgAPAAAAUmV2aXNpb25Db3VudGVyAQE9JAMAAAAAaQAAAEFuIGluY3JlbWVudGFsIGNvdW50ZXIg" +
           "aW5kaWNhdGluZyB0aGUgbnVtYmVyIG9mIHRpbWVzIHRoZSBzdGF0aWMgZGF0YSB3aXRoaW4gdGhlIERl" +
           "dmljZSBoYXMgYmVlbiBtb2RpZmllZAAuAEQ9JAAAAAb/////AQH/////AAAAADVgiQoCAAAAAgAMAAAA" +
           "TWFudWZhY3R1cmVyAQFLGgMAAAAAGAAAAE1vZGVsIG5hbWUgb2YgdGhlIGRldmljZQAuAERLGgAAABX/" +
           "////AQH/////AAAAADVgiQoCAAAAAgAFAAAATW9kZWwBAUwaAwAAAAAwAAAATmFtZSBvZiB0aGUgY29t" +
           "cGFueSB0aGF0IG1hbnVmYWN0dXJlZCB0aGUgZGV2aWNlAC4AREwaAAAAFf////8BAf////8AAAAANWCJ" +
           "CgIAAAACAAwAAABEZXZpY2VNYW51YWwBAU0aAwAAAABaAAAAQWRkcmVzcyAocGF0aG5hbWUgaW4gdGhl" +
           "IGZpbGUgc3lzdGVtIG9yIGEgVVJMIHwgV2ViIGFkZHJlc3MpIG9mIHVzZXIgbWFudWFsIGZvciB0aGUg" +
           "ZGV2aWNlAC4ARE0aAAAADP////8BAf////8AAAAANWCJCgIAAAACAA4AAABEZXZpY2VSZXZpc2lvbgEB" +
           "ThoDAAAAACQAAABPdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBkZXZpY2UALgBEThoAAAAM////" +
           "/wEB/////wAAAAA1YIkKAgAAAAIAEAAAAFNvZnR3YXJlUmV2aXNpb24BAU8aAwAAAAA1AAAAUmV2aXNp" +
           "b24gbGV2ZWwgb2YgdGhlIHNvZnR3YXJlL2Zpcm13YXJlIG9mIHRoZSBkZXZpY2UALgBETxoAAAAM////" +
           "/wEB/////wAAAAA1YIkKAgAAAAIAEAAAAEhhcmR3YXJlUmV2aXNpb24BAVAaAwAAAAAsAAAAUmV2aXNp" +
           "b24gbGV2ZWwgb2YgdGhlIGhhcmR3YXJlIG9mIHRoZSBkZXZpY2UALgBEUBoAAAAM/////wEB/////wAA" +
           "AAAEYIAKAQAAAAEADQAAAENvbmZpZ3VyYXRpb24BARkVAC8BAu0DGRUAAP////8AAAAABGCACgEAAAAB" +
           "AAYAAABTdGF0dXMBARoVAC8BAu0DGhUAAAMAAAAAIwABAVEaACMAAQFUGgAjAAEBWRoAAAAABGCACgEA" +
           "AAABAA8AAABGYWN0b3J5U2V0dGluZ3MBARsVAC8BAu0DGxUAAAgAAAAAIwABAV4aACMAAQFhGgAjAAEB" +
           "ZBoAIwABAWcaACMAAQFqGgAjAAEBbRoAIwABAXAaACMAAQFzGgAAAAAEYIAKAQAAAAEAFAAAAEFuYWx5" +
           "c2VyU3RhdGVNYWNoaW5lAQEcFQAvAQHqAxwVAAACAAAAAC8AAQGtHwAvAAEBrB8QAAAAFWCJCgIAAAAA" +
           "AAwAAABDdXJyZW50U3RhdGUBAXwaAC8BAMgKfBoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAA" +
           "AElkAQF9GgAuAER9GgAAABH/////AQH/////AAAAACRggAoBAAAAAQAHAAAAUG93ZXJ1cAEBHRUDAAAA" +
           "AFEAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gaXRzIHBvd2VyLXVwIHNlcXVlbmNlIGFuZCBjYW5u" +
           "b3QgcGVyZm9ybSBhbnkgb3RoZXIgdGFzay4ALwEABQkdFQAAAQAAAAAzAQEBIhUAAAAAJGCACgEAAAAB" +
           "AAkAAABPcGVyYXRpbmcBAR4VAwAAAAAsAAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRoZSBPcGVy" +
           "YXRpbmcgbW9kZS4ALwEAAwkeFQAABgAAAAA0AQEBIhUAMwEBASMVADMBAQEkFQA0AQEBJRUANAEBAScV" +
           "ADMBAQEpFQAAAAAkYIAKAQAAAAEABQAAAExvY2FsAQEfFQMAAAAAegAAAFRoZSBBbmFseXNlckRldmlj" +
           "ZSBpcyBpbiB0aGUgTG9jYWwgbW9kZS4gVGhpcyBtb2RlIGlzIG5vcm1hbGx5IHVzZWQgdG8gcGVyZm9y" +
           "bSBsb2NhbCBwaHlzaWNhbCBtYWludGVuYW5jZSBvbiB0aGUgYW5hbHlzZXIuAC8BAAMJHxUAAAUAAAAA" +
           "NAEBASMVADMBAQElFQAzAQEBJhUANAEBASgVADMBAQEqFQAAAAAkYIAKAQAAAAEACwAAAE1haW50ZW5h" +
           "bmNlAQEgFQMAAAAAhQAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0aGUgTWFpbnRlbmFuY2UgbW9k" +
           "ZS4gVGhpcyBtb2RlIGlzIHVzZWQgdG8gcGVyZm9ybSByZW1vdGUgbWFpbnRlbmFuY2Ugb24gdGhlIGFu" +
           "YWx5c2VyIGxpa2UgZmlybXdhcmUgdXBncmFkZS4ALwEAAwkgFQAABQAAAAA0AQEBJBUANAEBASYVADMB" +
           "AQEnFQAzAQEBKBUAMwEBASsVAAAAACRggAoBAAAAAQAIAAAAU2h1dGRvd24BASEVAwAAAABTAAAAVGhl" +
           "IEFuYWx5c2VyRGV2aWNlIGlzIGluIGl0cyBwb3dlci1kb3duIHNlcXVlbmNlIGFuZCBjYW5ub3QgcGVy" +
           "Zm9ybSBhbnkgb3RoZXIgdGFzay4ALwEAAwkhFQAAAwAAAAA0AQEBKRUANAEBASoVADQBAQErFQAAAAAE" +
           "YIAKAQAAAAEAHAAAAFBvd2VydXBUb09wZXJhdGluZ1RyYW5zaXRpb24BASIVAC8BAAYJIhUAAAIAAAAA" +
           "MwABAR0VADQAAQEeFQAAAAAEYIAKAQAAAAEAGgAAAE9wZXJhdGluZ1RvTG9jYWxUcmFuc2l0aW9uAQEj" +
           "FQAvAQAGCSMVAAACAAAAADMAAQEeFQA0AAEBHxUAAAAABGCACgEAAAABACAAAABPcGVyYXRpbmdUb01h" +
           "aW50ZW5hbmNlVHJhbnNpdGlvbgEBJBUALwEABgkkFQAAAwAAAAAzAAEBHhUANAABASAVADUAAQGtHwAA" +
           "AAAEYIAKAQAAAAEAGgAAAExvY2FsVG9PcGVyYXRpbmdUcmFuc2l0aW9uAQElFQAvAQAGCSUVAAACAAAA" +
           "ADMAAQEfFQA0AAEBHhUAAAAABGCACgEAAAABABwAAABMb2NhbFRvTWFpbnRlbmFuY2VUcmFuc2l0aW9u" +
           "AQEmFQAvAQAGCSYVAAACAAAAADMAAQEfFQA0AAEBIBUAAAAABGCACgEAAAABACAAAABNYWludGVuYW5j" +
           "ZVRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBJxUALwEABgknFQAAAwAAAAAzAAEBIBUANAABAR4VADUAAQGs" +
           "HwAAAAAEYIAKAQAAAAEAHAAAAE1haW50ZW5hbmNlVG9Mb2NhbFRyYW5zaXRpb24BASgVAC8BAAYJKBUA" +
           "AAIAAAAAMwABASAVADQAAQEfFQAAAAAEYIAKAQAAAAEAHQAAAE9wZXJhdGluZ1RvU2h1dGRvd25UcmFu" +
           "c2l0aW9uAQEpFQAvAQAGCSkVAAACAAAAADMAAQEeFQA0AAEBIRUAAAAABGCACgEAAAABABkAAABMb2Nh" +
           "bFRvU2h1dGRvd25UcmFuc2l0aW9uAQEqFQAvAQAGCSoVAAACAAAAADMAAQEfFQA0AAEBIRUAAAAABGCA" +
           "CgEAAAABAB8AAABNYWludGVuYW5jZVRvU2h1dGRvd25UcmFuc2l0aW9uAQErFQAvAQAGCSsVAAACAAAA" +
           "ADMAAQEgFQA0AAEBIRUAAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region MassSpectrometerDeviceState Class
    #if (!OPCUA_EXCLUDE_MassSpectrometerDeviceState)
    /// <summary>
    /// Stores an instance of the MassSpectrometerDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MassSpectrometerDeviceState : AnalyserDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MassSpectrometerDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.MassSpectrometerDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAiAAAATWFzc1NwZWN0cm9tZXRlckRldmljZVR5cGVJ" +
           "bnN0YW5jZQEB9gMBAfYDAf////8OAAAAJGCACgEAAAACAAwAAABQYXJhbWV0ZXJTZXQBASwVAwAAAAAX" +
           "AAAARmxhdCBsaXN0IG9mIFBhcmFtZXRlcnMALwA6LBUAAP////8LAAAANWCJCgIAAAABABAAAABEaWFn" +
           "bm9zdGljU3RhdHVzAQGiGgMAAAAAJQAAAEdlbmVyYWwgaGVhbHRoIHN0YXR1cyBvZiB0aGUgYW5hbHlz" +
           "ZXIALwEAPQmiGgAAAQG6C/////8BAQEAAAAAIwEBAS8VAAAAADVgiQoCAAAAAQASAAAAT3V0T2ZTcGVj" +
           "aWZpY2F0aW9uAQGlGgMAAAAAZAAAAERldmljZSBiZWluZyBvcGVyYXRlZCBvdXQgb2YgU3BlY2lmaWNh" +
           "dGlvbi4gVW5jZXJ0YWluIHZhbHVlIGR1ZSB0byBwcm9jZXNzIGFuZCBlbnZpcm9ubWVudCBpbmZsdWVu" +
           "Y2UALwEARQmlGgAAAAH/////AQEBAAAAACMBAQEvFQIAAAAVYIkKAgAAAAAACgAAAEZhbHNlU3RhdGUB" +
           "AagaAC4ARKgaAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUBAakaAC4ARKka" +
           "AAAAFf////8BAf////8AAAAANWCJCgIAAAABAA0AAABGdW5jdGlvbkNoZWNrAQGqGgMAAAAARQAAAExv" +
           "Y2FsIG9wZXJhdGlvbiwgY29uZmlndXJhdGlvbiBpcyBjaGFuZ2luZywgc3Vic3RpdHV0ZSB2YWx1ZSBl" +
           "bnRlcmVkLgAvAQBFCaoaAAAAAf////8BAQEAAAAAIwEBAS8VAgAAABVgiQoCAAAAAAAKAAAARmFsc2VT" +
           "dGF0ZQEBrRoALgBErRoAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBrhoA" +
           "LgBErhoAAAAV/////wEB/////wAAAAA1YIkKAgAAAAEADAAAAFNlcmlhbE51bWJlcgEBrxoDAAAAAE0A" +
           "AABJZGVudGlmaWVyIHRoYXQgdW5pcXVlbHkgaWRlbnRpZmllcywgd2l0aGluIGEgbWFudWZhY3R1cmVy" +
           "LCBhIGRldmljZSBpbnN0YW5jZQAvAQA9Ca8aAAAADP////8BAQIAAAAAIwEBAU4kACMBAQEwFQAAAAA1" +
           "YIkKAgAAAAEADAAAAE1hbnVmYWN0dXJlcgEBshoDAAAAADAAAABOYW1lIG9mIHRoZSBjb21wYW55IHRo" +
           "YXQgbWFudWZhY3R1cmVkIHRoZSBkZXZpY2UALwEAPQmyGgAAABX/////AQECAAAAACMBAQFOJAAjAQEB" +
           "MBUAAAAANWCJCgIAAAABAAUAAABNb2RlbAEBtRoDAAAAABgAAABNb2RlbCBuYW1lIG9mIHRoZSBkZXZp" +
           "Y2UALwEAPQm1GgAAABX/////AQECAAAAACMBAQFOJAAjAQEBMBUAAAAANWCJCgIAAAABAAwAAABEZXZp" +
           "Y2VNYW51YWwBAbgaAwAAAABaAAAAQWRkcmVzcyAocGF0aG5hbWUgaW4gdGhlIGZpbGUgc3lzdGVtIG9y" +
           "IGEgVVJMIHwgV2ViIGFkZHJlc3MpIG9mIHVzZXIgbWFudWFsIGZvciB0aGUgZGV2aWNlAC8BAD0JuBoA" +
           "AAAM/////wEBAQAAAAAjAQEBMBUAAAAANWCJCgIAAAABAA4AAABEZXZpY2VSZXZpc2lvbgEBuxoDAAAA" +
           "ACQAAABPdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBkZXZpY2UALwEAPQm7GgAAAAz/////AQEB" +
           "AAAAACMBAQEwFQAAAAA1YIkKAgAAAAEAEAAAAFNvZnR3YXJlUmV2aXNpb24BAb4aAwAAAAA1AAAAUmV2" +
           "aXNpb24gbGV2ZWwgb2YgdGhlIHNvZnR3YXJlL2Zpcm13YXJlIG9mIHRoZSBkZXZpY2UALwEAPQm+GgAA" +
           "AAz/////AQEBAAAAACMBAQEwFQAAAAA1YIkKAgAAAAEAEAAAAEhhcmR3YXJlUmV2aXNpb24BAcEaAwAA" +
           "AAAsAAAAUmV2aXNpb24gbGV2ZWwgb2YgdGhlIGhhcmR3YXJlIG9mIHRoZSBkZXZpY2UALwEAPQnBGgAA" +
           "AAz/////AQEBAAAAACMBAQEwFQAAAAA1YIkKAgAAAAEADwAAAFJldmlzaW9uQ291bnRlcgEBxBoDAAAA" +
           "AGkAAABBbiBpbmNyZW1lbnRhbCBjb3VudGVyIGluZGljYXRpbmcgdGhlIG51bWJlciBvZiB0aW1lcyB0" +
           "aGUgc3RhdGljIGRhdGEgd2l0aGluIHRoZSBEZXZpY2UgaGFzIGJlZW4gbW9kaWZpZWQALwEAPQnEGgAA" +
           "AAf/////AQEBAAAAACMBAQEwFQAAAAAkYIAKAQAAAAIACQAAAE1ldGhvZFNldAEBLRUDAAAAABQAAABG" +
           "bGF0IGxpc3Qgb2YgTWV0aG9kcwAvADotFQAA/////woAAAAEYYIKBAAAAAEAEAAAAEdldENvbmZpZ3Vy" +
           "YXRpb24BAVAkAC8BAZ4fUCQAAAEB/////wEAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEB" +
           "USQALgBEUSQAAJYBAAAAAQAqAQEZAAAACgAAAENvbmZpZ0RhdGEAD/////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAAARhggoEAAAAAQAQAAAAU2V0Q29uZmlndXJhdGlvbgEBUiQALwEBoB9SJAAAAQH/////AgAA" +
           "ABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAVMkAC4ARFMkAACWAQAAAAEAKgEBGQAAAAoAAABD" +
           "b25maWdEYXRhAA//////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFy" +
           "Z3VtZW50cwEBVCQALgBEVCQAAJYBAAAAAQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP////8A" +
           "AAAAAAEAKAEBAAAAAQH/////AAAAAARhggoEAAAAAQATAAAAR2V0Q29uZmlnRGF0YURpZ2VzdAEBVSQA" +
           "LwEBox9VJAAAAQH/////AQAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQFWJAAuAERWJAAA" +
           "lgEAAAABACoBAR8AAAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAABAf////8A" +
           "AAAABGGCCgQAAAABABcAAABDb21wYXJlQ29uZmlnRGF0YURpZ2VzdAEBVyQALwEBpR9XJAAAAQH/////" +
           "AgAAABVgqQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAVgkAC4ARFgkAACWAQAAAAEAKgEBHwAAABAA" +
           "AABDb25maWdEYXRhRGlnZXN0AAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAVYKkKAgAAAAAADwAA" +
           "AE91dHB1dEFyZ3VtZW50cwEBWSQALgBEWSQAAJYBAAAAAQAqAQEWAAAABwAAAElzRXF1YWwAAf////8A" +
           "AAAAAAEAKAEBAAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAUmVzZXRBbGxDaGFubmVscwEBWiQDAAAA" +
           "ADwAAABSZXNldCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRl" +
           "dmljZS4ALwEBqB9aJAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAU3RhcnRBbGxDaGFubmVscwEBWyQD" +
           "AAAAADwAAABTdGFydCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNl" +
           "ckRldmljZS4ALwEBqR9bJAAAAQH/////AAAAACRhggoEAAAAAQAPAAAAU3RvcEFsbENoYW5uZWxzAQFc" +
           "JAMAAAAAOwAAAFN0b3AgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5hbHlz" +
           "ZXJEZXZpY2UuAC8BAaofXCQAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAEFib3J0QWxsQ2hhbm5lbHMB" +
           "AV0kAwAAAAA8AAAAQWJvcnQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5h" +
           "bHlzZXJEZXZpY2UuAC8BAasfXSQAAAEB/////wAAAAAkYYIKBAAAAAEADQAAAEdvdG9PcGVyYXRpbmcB" +
           "AV4kAwAAAACNAAAAQW5hbHlzZXJEZXZpY2VTdGF0ZU1hY2hpbmUgdG8gZ28gdG8gT3BlcmF0aW5nIHN0" +
           "YXRlLCBmb3JjaW5nIGFsbCBBbmFseXNlckNoYW5uZWxzIHRvIGxlYXZlIHRoZSBTbGF2ZU1vZGUgc3Rh" +
           "dGUgYW5kIGdvIHRvIHRoZSBPcGVyYXRpbmcgc3RhdGUuAC8BAawfXiQAAAEB/////wAAAAAkYYIKBAAA" +
           "AAEADwAAAEdvdG9NYWludGVuYW5jZQEBXyQDAAAAAGcAAABBbmFseXNlckRldmljZVN0YXRlTWFjaGlu" +
           "ZSB0byBnbyB0byBNYWludGVuYW5jZSBzdGF0ZSwgZm9yY2luZyBhbGwgQW5hbHlzZXJDaGFubmVscyB0" +
           "byBTbGF2ZU1vZGUgc3RhdGUuAC8BAa0fXyQAAAEB/////wAAAAA1YIkKAgAAAAIADAAAAFNlcmlhbE51" +
           "bWJlcgEBmxoDAAAAAE0AAABJZGVudGlmaWVyIHRoYXQgdW5pcXVlbHkgaWRlbnRpZmllcywgd2l0aGlu" +
           "IGEgbWFudWZhY3R1cmVyLCBhIGRldmljZSBpbnN0YW5jZQAuAESbGgAAAAz/////AQH/////AAAAADVg" +
           "iQoCAAAAAgAPAAAAUmV2aXNpb25Db3VudGVyAQFPJAMAAAAAaQAAAEFuIGluY3JlbWVudGFsIGNvdW50" +
           "ZXIgaW5kaWNhdGluZyB0aGUgbnVtYmVyIG9mIHRpbWVzIHRoZSBzdGF0aWMgZGF0YSB3aXRoaW4gdGhl" +
           "IERldmljZSBoYXMgYmVlbiBtb2RpZmllZAAuAERPJAAAAAb/////AQH/////AAAAADVgiQoCAAAAAgAM" +
           "AAAATWFudWZhY3R1cmVyAQGcGgMAAAAAGAAAAE1vZGVsIG5hbWUgb2YgdGhlIGRldmljZQAuAEScGgAA" +
           "ABX/////AQH/////AAAAADVgiQoCAAAAAgAFAAAATW9kZWwBAZ0aAwAAAAAwAAAATmFtZSBvZiB0aGUg" +
           "Y29tcGFueSB0aGF0IG1hbnVmYWN0dXJlZCB0aGUgZGV2aWNlAC4ARJ0aAAAAFf////8BAf////8AAAAA" +
           "NWCJCgIAAAACAAwAAABEZXZpY2VNYW51YWwBAZ4aAwAAAABaAAAAQWRkcmVzcyAocGF0aG5hbWUgaW4g" +
           "dGhlIGZpbGUgc3lzdGVtIG9yIGEgVVJMIHwgV2ViIGFkZHJlc3MpIG9mIHVzZXIgbWFudWFsIGZvciB0" +
           "aGUgZGV2aWNlAC4ARJ4aAAAADP////8BAf////8AAAAANWCJCgIAAAACAA4AAABEZXZpY2VSZXZpc2lv" +
           "bgEBnxoDAAAAACQAAABPdmVyYWxsIHJldmlzaW9uIGxldmVsIG9mIHRoZSBkZXZpY2UALgBEnxoAAAAM" +
           "/////wEB/////wAAAAA1YIkKAgAAAAIAEAAAAFNvZnR3YXJlUmV2aXNpb24BAaAaAwAAAAA1AAAAUmV2" +
           "aXNpb24gbGV2ZWwgb2YgdGhlIHNvZnR3YXJlL2Zpcm13YXJlIG9mIHRoZSBkZXZpY2UALgBEoBoAAAAM" +
           "/////wEB/////wAAAAA1YIkKAgAAAAIAEAAAAEhhcmR3YXJlUmV2aXNpb24BAaEaAwAAAAAsAAAAUmV2" +
           "aXNpb24gbGV2ZWwgb2YgdGhlIGhhcmR3YXJlIG9mIHRoZSBkZXZpY2UALgBEoRoAAAAM/////wEB////" +
           "/wAAAAAEYIAKAQAAAAEADQAAAENvbmZpZ3VyYXRpb24BAS4VAC8BAu0DLhUAAP////8AAAAABGCACgEA" +
           "AAABAAYAAABTdGF0dXMBAS8VAC8BAu0DLxUAAAMAAAAAIwABAaIaACMAAQGlGgAjAAEBqhoAAAAABGCA" +
           "CgEAAAABAA8AAABGYWN0b3J5U2V0dGluZ3MBATAVAC8BAu0DMBUAAAgAAAAAIwABAa8aACMAAQGyGgAj" +
           "AAEBtRoAIwABAbgaACMAAQG7GgAjAAEBvhoAIwABAcEaACMAAQHEGgAAAAAEYIAKAQAAAAEAFAAAAEFu" +
           "YWx5c2VyU3RhdGVNYWNoaW5lAQExFQAvAQHqAzEVAAACAAAAAC8AAQGtHwAvAAEBrB8QAAAAFWCJCgIA" +
           "AAAAAAwAAABDdXJyZW50U3RhdGUBAc0aAC8BAMgKzRoAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAA" +
           "AgAAAElkAQHOGgAuAETOGgAAABH/////AQH/////AAAAACRggAoBAAAAAQAHAAAAUG93ZXJ1cAEBMhUD" +
           "AAAAAFEAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gaXRzIHBvd2VyLXVwIHNlcXVlbmNlIGFuZCBj" +
           "YW5ub3QgcGVyZm9ybSBhbnkgb3RoZXIgdGFzay4ALwEABQkyFQAAAQAAAAAzAQEBNxUAAAAAJGCACgEA" +
           "AAABAAkAAABPcGVyYXRpbmcBATMVAwAAAAAsAAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRoZSBP" +
           "cGVyYXRpbmcgbW9kZS4ALwEAAwkzFQAABgAAAAA0AQEBNxUAMwEBATgVADMBAQE5FQA0AQEBOhUANAEB" +
           "ATwVADMBAQE+FQAAAAAkYIAKAQAAAAEABQAAAExvY2FsAQE0FQMAAAAAegAAAFRoZSBBbmFseXNlckRl" +
           "dmljZSBpcyBpbiB0aGUgTG9jYWwgbW9kZS4gVGhpcyBtb2RlIGlzIG5vcm1hbGx5IHVzZWQgdG8gcGVy" +
           "Zm9ybSBsb2NhbCBwaHlzaWNhbCBtYWludGVuYW5jZSBvbiB0aGUgYW5hbHlzZXIuAC8BAAMJNBUAAAUA" +
           "AAAANAEBATgVADMBAQE6FQAzAQEBOxUANAEBAT0VADMBAQE/FQAAAAAkYIAKAQAAAAEACwAAAE1haW50" +
           "ZW5hbmNlAQE1FQMAAAAAhQAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0aGUgTWFpbnRlbmFuY2Ug" +
           "bW9kZS4gVGhpcyBtb2RlIGlzIHVzZWQgdG8gcGVyZm9ybSByZW1vdGUgbWFpbnRlbmFuY2Ugb24gdGhl" +
           "IGFuYWx5c2VyIGxpa2UgZmlybXdhcmUgdXBncmFkZS4ALwEAAwk1FQAABQAAAAA0AQEBORUANAEBATsV" +
           "ADMBAQE8FQAzAQEBPRUAMwEBAUAVAAAAACRggAoBAAAAAQAIAAAAU2h1dGRvd24BATYVAwAAAABTAAAA" +
           "VGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIGl0cyBwb3dlci1kb3duIHNlcXVlbmNlIGFuZCBjYW5ub3Qg" +
           "cGVyZm9ybSBhbnkgb3RoZXIgdGFzay4ALwEAAwk2FQAAAwAAAAA0AQEBPhUANAEBAT8VADQBAQFAFQAA" +
           "AAAEYIAKAQAAAAEAHAAAAFBvd2VydXBUb09wZXJhdGluZ1RyYW5zaXRpb24BATcVAC8BAAYJNxUAAAIA" +
           "AAAAMwABATIVADQAAQEzFQAAAAAEYIAKAQAAAAEAGgAAAE9wZXJhdGluZ1RvTG9jYWxUcmFuc2l0aW9u" +
           "AQE4FQAvAQAGCTgVAAACAAAAADMAAQEzFQA0AAEBNBUAAAAABGCACgEAAAABACAAAABPcGVyYXRpbmdU" +
           "b01haW50ZW5hbmNlVHJhbnNpdGlvbgEBORUALwEABgk5FQAAAwAAAAAzAAEBMxUANAABATUVADUAAQGt" +
           "HwAAAAAEYIAKAQAAAAEAGgAAAExvY2FsVG9PcGVyYXRpbmdUcmFuc2l0aW9uAQE6FQAvAQAGCToVAAAC" +
           "AAAAADMAAQE0FQA0AAEBMxUAAAAABGCACgEAAAABABwAAABMb2NhbFRvTWFpbnRlbmFuY2VUcmFuc2l0" +
           "aW9uAQE7FQAvAQAGCTsVAAACAAAAADMAAQE0FQA0AAEBNRUAAAAABGCACgEAAAABACAAAABNYWludGVu" +
           "YW5jZVRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBPBUALwEABgk8FQAAAwAAAAAzAAEBNRUANAABATMVADUA" +
           "AQGsHwAAAAAEYIAKAQAAAAEAHAAAAE1haW50ZW5hbmNlVG9Mb2NhbFRyYW5zaXRpb24BAT0VAC8BAAYJ" +
           "PRUAAAIAAAAAMwABATUVADQAAQE0FQAAAAAEYIAKAQAAAAEAHQAAAE9wZXJhdGluZ1RvU2h1dGRvd25U" +
           "cmFuc2l0aW9uAQE+FQAvAQAGCT4VAAACAAAAADMAAQEzFQA0AAEBNhUAAAAABGCACgEAAAABABkAAABM" +
           "b2NhbFRvU2h1dGRvd25UcmFuc2l0aW9uAQE/FQAvAQAGCT8VAAACAAAAADMAAQE0FQA0AAEBNhUAAAAA" +
           "BGCACgEAAAABAB8AAABNYWludGVuYW5jZVRvU2h1dGRvd25UcmFuc2l0aW9uAQFAFQAvAQAGCUAVAAAC" +
           "AAAAADMAAQE1FQA0AAEBNhUAAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region AcousticSpectrometerDeviceState Class
    #if (!OPCUA_EXCLUDE_AcousticSpectrometerDeviceState)
    /// <summary>
    /// Stores an instance of the AcousticSpectrometerDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AcousticSpectrometerDeviceState : AnalyserDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AcousticSpectrometerDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AcousticSpectrometerDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAmAAAAQWNvdXN0aWNTcGVjdHJvbWV0ZXJEZXZpY2VU" +
           "eXBlSW5zdGFuY2UBAfcDAQH3AwH/////DgAAACRggAoBAAAAAgAMAAAAUGFyYW1ldGVyU2V0AQFBFQMA" +
           "AAAAFwAAAEZsYXQgbGlzdCBvZiBQYXJhbWV0ZXJzAC8AOkEVAAD/////CwAAADVgiQoCAAAAAQAQAAAA" +
           "RGlhZ25vc3RpY1N0YXR1cwEB8xoDAAAAACUAAABHZW5lcmFsIGhlYWx0aCBzdGF0dXMgb2YgdGhlIGFu" +
           "YWx5c2VyAC8BAD0J8xoAAAEBugv/////AQEBAAAAACMBAQFEFQAAAAA1YIkKAgAAAAEAEgAAAE91dE9m" +
           "U3BlY2lmaWNhdGlvbgEB9hoDAAAAAGQAAABEZXZpY2UgYmVpbmcgb3BlcmF0ZWQgb3V0IG9mIFNwZWNp" +
           "ZmljYXRpb24uIFVuY2VydGFpbiB2YWx1ZSBkdWUgdG8gcHJvY2VzcyBhbmQgZW52aXJvbm1lbnQgaW5m" +
           "bHVlbmNlAC8BAEUJ9hoAAAAB/////wEBAQAAAAAjAQEBRBUCAAAAFWCJCgIAAAAAAAoAAABGYWxzZVN0" +
           "YXRlAQH5GgAuAET5GgAAABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQH6GgAu" +
           "AET6GgAAABX/////AQH/////AAAAADVgiQoCAAAAAQANAAAARnVuY3Rpb25DaGVjawEB+xoDAAAAAEUA" +
           "AABMb2NhbCBvcGVyYXRpb24sIGNvbmZpZ3VyYXRpb24gaXMgY2hhbmdpbmcsIHN1YnN0aXR1dGUgdmFs" +
           "dWUgZW50ZXJlZC4ALwEARQn7GgAAAAH/////AQEBAAAAACMBAQFEFQIAAAAVYIkKAgAAAAAACgAAAEZh" +
           "bHNlU3RhdGUBAf4aAC4ARP4aAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABUcnVlU3RhdGUB" +
           "Af8aAC4ARP8aAAAAFf////8BAf////8AAAAANWCJCgIAAAABAAwAAABTZXJpYWxOdW1iZXIBAQAbAwAA" +
           "AABNAAAASWRlbnRpZmllciB0aGF0IHVuaXF1ZWx5IGlkZW50aWZpZXMsIHdpdGhpbiBhIG1hbnVmYWN0" +
           "dXJlciwgYSBkZXZpY2UgaW5zdGFuY2UALwEAPQkAGwAAAAz/////AQECAAAAACMBAQFgJAAjAQEBRRUA" +
           "AAAANWCJCgIAAAABAAwAAABNYW51ZmFjdHVyZXIBAQMbAwAAAAAwAAAATmFtZSBvZiB0aGUgY29tcGFu" +
           "eSB0aGF0IG1hbnVmYWN0dXJlZCB0aGUgZGV2aWNlAC8BAD0JAxsAAAAV/////wEBAgAAAAAjAQEBYCQA" +
           "IwEBAUUVAAAAADVgiQoCAAAAAQAFAAAATW9kZWwBAQYbAwAAAAAYAAAATW9kZWwgbmFtZSBvZiB0aGUg" +
           "ZGV2aWNlAC8BAD0JBhsAAAAV/////wEBAgAAAAAjAQEBYCQAIwEBAUUVAAAAADVgiQoCAAAAAQAMAAAA" +
           "RGV2aWNlTWFudWFsAQEJGwMAAAAAWgAAAEFkZHJlc3MgKHBhdGhuYW1lIGluIHRoZSBmaWxlIHN5c3Rl" +
           "bSBvciBhIFVSTCB8IFdlYiBhZGRyZXNzKSBvZiB1c2VyIG1hbnVhbCBmb3IgdGhlIGRldmljZQAvAQA9" +
           "CQkbAAAADP////8BAQEAAAAAIwEBAUUVAAAAADVgiQoCAAAAAQAOAAAARGV2aWNlUmV2aXNpb24BAQwb" +
           "AwAAAAAkAAAAT3ZlcmFsbCByZXZpc2lvbiBsZXZlbCBvZiB0aGUgZGV2aWNlAC8BAD0JDBsAAAAM////" +
           "/wEBAQAAAAAjAQEBRRUAAAAANWCJCgIAAAABABAAAABTb2Z0d2FyZVJldmlzaW9uAQEPGwMAAAAANQAA" +
           "AFJldmlzaW9uIGxldmVsIG9mIHRoZSBzb2Z0d2FyZS9maXJtd2FyZSBvZiB0aGUgZGV2aWNlAC8BAD0J" +
           "DxsAAAAM/////wEBAQAAAAAjAQEBRRUAAAAANWCJCgIAAAABABAAAABIYXJkd2FyZVJldmlzaW9uAQES" +
           "GwMAAAAALAAAAFJldmlzaW9uIGxldmVsIG9mIHRoZSBoYXJkd2FyZSBvZiB0aGUgZGV2aWNlAC8BAD0J" +
           "EhsAAAAM/////wEBAQAAAAAjAQEBRRUAAAAANWCJCgIAAAABAA8AAABSZXZpc2lvbkNvdW50ZXIBARUb" +
           "AwAAAABpAAAAQW4gaW5jcmVtZW50YWwgY291bnRlciBpbmRpY2F0aW5nIHRoZSBudW1iZXIgb2YgdGlt" +
           "ZXMgdGhlIHN0YXRpYyBkYXRhIHdpdGhpbiB0aGUgRGV2aWNlIGhhcyBiZWVuIG1vZGlmaWVkAC8BAD0J" +
           "FRsAAAAH/////wEBAQAAAAAjAQEBRRUAAAAAJGCACgEAAAACAAkAAABNZXRob2RTZXQBAUIVAwAAAAAU" +
           "AAAARmxhdCBsaXN0IG9mIE1ldGhvZHMALwA6QhUAAP////8KAAAABGGCCgQAAAABABAAAABHZXRDb25m" +
           "aWd1cmF0aW9uAQFiJAAvAQGeH2IkAAABAf////8BAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVu" +
           "dHMBAWMkAC4ARGMkAACWAQAAAAEAKgEBGQAAAAoAAABDb25maWdEYXRhAA//////AAAAAAABACgBAQAA" +
           "AAEB/////wAAAAAEYYIKBAAAAAEAEAAAAFNldENvbmZpZ3VyYXRpb24BAWQkAC8BAaAfZCQAAAEB////" +
           "/wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQFlJAAuAERlJAAAlgEAAAABACoBARkAAAAK" +
           "AAAAQ29uZmlnRGF0YQAP/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAAAA8AAABPdXRw" +
           "dXRBcmd1bWVudHMBAWYkAC4ARGYkAACWAQAAAAEAKgEBHwAAABAAAABDb25maWdEYXRhRGlnZXN0AAz/" +
           "////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEAEwAAAEdldENvbmZpZ0RhdGFEaWdlc3QB" +
           "AWckAC8BAaMfZyQAAAEB/////wEAAAAVYKkKAgAAAAAADwAAAE91dHB1dEFyZ3VtZW50cwEBaCQALgBE" +
           "aCQAAJYBAAAAAQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFEaWdlc3QADP////8AAAAAAAEAKAEBAAAAAQH/" +
           "////AAAAAARhggoEAAAAAQAXAAAAQ29tcGFyZUNvbmZpZ0RhdGFEaWdlc3QBAWkkAC8BAaUfaSQAAAEB" +
           "/////wIAAAAVYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQFqJAAuAERqJAAAlgEAAAABACoBAR8A" +
           "AAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAABAf////8AAAAAFWCpCgIAAAAA" +
           "AA8AAABPdXRwdXRBcmd1bWVudHMBAWskAC4ARGskAACWAQAAAAEAKgEBFgAAAAcAAABJc0VxdWFsAAH/" +
           "////AAAAAAABACgBAQAAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAFJlc2V0QWxsQ2hhbm5lbHMBAWwk" +
           "AwAAAAA8AAAAUmVzZXQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5hbHlz" +
           "ZXJEZXZpY2UuAC8BAagfbCQAAAEB/////wAAAAAkYYIKBAAAAAEAEAAAAFN0YXJ0QWxsQ2hhbm5lbHMB" +
           "AW0kAwAAAAA8AAAAU3RhcnQgYWxsIEFuYWx5c2VyQ2hhbm5lbHMgYmVsb25naW5nIHRvIHRoaXMgQW5h" +
           "bHlzZXJEZXZpY2UuAC8BAakfbSQAAAEB/////wAAAAAkYYIKBAAAAAEADwAAAFN0b3BBbGxDaGFubmVs" +
           "cwEBbiQDAAAAADsAAABTdG9wIGFsbCBBbmFseXNlckNoYW5uZWxzIGJlbG9uZ2luZyB0byB0aGlzIEFu" +
           "YWx5c2VyRGV2aWNlLgAvAQGqH24kAAABAf////8AAAAAJGGCCgQAAAABABAAAABBYm9ydEFsbENoYW5u" +
           "ZWxzAQFvJAMAAAAAPAAAAEFib3J0IGFsbCBBbmFseXNlckNoYW5uZWxzIGJlbG9uZ2luZyB0byB0aGlz" +
           "IEFuYWx5c2VyRGV2aWNlLgAvAQGrH28kAAABAf////8AAAAAJGGCCgQAAAABAA0AAABHb3RvT3BlcmF0" +
           "aW5nAQFwJAMAAAAAjQAAAEFuYWx5c2VyRGV2aWNlU3RhdGVNYWNoaW5lIHRvIGdvIHRvIE9wZXJhdGlu" +
           "ZyBzdGF0ZSwgZm9yY2luZyBhbGwgQW5hbHlzZXJDaGFubmVscyB0byBsZWF2ZSB0aGUgU2xhdmVNb2Rl" +
           "IHN0YXRlIGFuZCBnbyB0byB0aGUgT3BlcmF0aW5nIHN0YXRlLgAvAQGsH3AkAAABAf////8AAAAAJGGC" +
           "CgQAAAABAA8AAABHb3RvTWFpbnRlbmFuY2UBAXEkAwAAAABnAAAAQW5hbHlzZXJEZXZpY2VTdGF0ZU1h" +
           "Y2hpbmUgdG8gZ28gdG8gTWFpbnRlbmFuY2Ugc3RhdGUsIGZvcmNpbmcgYWxsIEFuYWx5c2VyQ2hhbm5l" +
           "bHMgdG8gU2xhdmVNb2RlIHN0YXRlLgAvAQGtH3EkAAABAf////8AAAAANWCJCgIAAAACAAwAAABTZXJp" +
           "YWxOdW1iZXIBAewaAwAAAABNAAAASWRlbnRpZmllciB0aGF0IHVuaXF1ZWx5IGlkZW50aWZpZXMsIHdp" +
           "dGhpbiBhIG1hbnVmYWN0dXJlciwgYSBkZXZpY2UgaW5zdGFuY2UALgBE7BoAAAAM/////wEB/////wAA" +
           "AAA1YIkKAgAAAAIADwAAAFJldmlzaW9uQ291bnRlcgEBYSQDAAAAAGkAAABBbiBpbmNyZW1lbnRhbCBj" +
           "b3VudGVyIGluZGljYXRpbmcgdGhlIG51bWJlciBvZiB0aW1lcyB0aGUgc3RhdGljIGRhdGEgd2l0aGlu" +
           "IHRoZSBEZXZpY2UgaGFzIGJlZW4gbW9kaWZpZWQALgBEYSQAAAAG/////wEB/////wAAAAA1YIkKAgAA" +
           "AAIADAAAAE1hbnVmYWN0dXJlcgEB7RoDAAAAABgAAABNb2RlbCBuYW1lIG9mIHRoZSBkZXZpY2UALgBE" +
           "7RoAAAAV/////wEB/////wAAAAA1YIkKAgAAAAIABQAAAE1vZGVsAQHuGgMAAAAAMAAAAE5hbWUgb2Yg" +
           "dGhlIGNvbXBhbnkgdGhhdCBtYW51ZmFjdHVyZWQgdGhlIGRldmljZQAuAETuGgAAABX/////AQH/////" +
           "AAAAADVgiQoCAAAAAgAMAAAARGV2aWNlTWFudWFsAQHvGgMAAAAAWgAAAEFkZHJlc3MgKHBhdGhuYW1l" +
           "IGluIHRoZSBmaWxlIHN5c3RlbSBvciBhIFVSTCB8IFdlYiBhZGRyZXNzKSBvZiB1c2VyIG1hbnVhbCBm" +
           "b3IgdGhlIGRldmljZQAuAETvGgAAAAz/////AQH/////AAAAADVgiQoCAAAAAgAOAAAARGV2aWNlUmV2" +
           "aXNpb24BAfAaAwAAAAAkAAAAT3ZlcmFsbCByZXZpc2lvbiBsZXZlbCBvZiB0aGUgZGV2aWNlAC4ARPAa" +
           "AAAADP////8BAf////8AAAAANWCJCgIAAAACABAAAABTb2Z0d2FyZVJldmlzaW9uAQHxGgMAAAAANQAA" +
           "AFJldmlzaW9uIGxldmVsIG9mIHRoZSBzb2Z0d2FyZS9maXJtd2FyZSBvZiB0aGUgZGV2aWNlAC4ARPEa" +
           "AAAADP////8BAf////8AAAAANWCJCgIAAAACABAAAABIYXJkd2FyZVJldmlzaW9uAQHyGgMAAAAALAAA" +
           "AFJldmlzaW9uIGxldmVsIG9mIHRoZSBoYXJkd2FyZSBvZiB0aGUgZGV2aWNlAC4ARPIaAAAADP////8B" +
           "Af////8AAAAABGCACgEAAAABAA0AAABDb25maWd1cmF0aW9uAQFDFQAvAQLtA0MVAAD/////AAAAAARg" +
           "gAoBAAAAAQAGAAAAU3RhdHVzAQFEFQAvAQLtA0QVAAADAAAAACMAAQHzGgAjAAEB9hoAIwABAfsaAAAA" +
           "AARggAoBAAAAAQAPAAAARmFjdG9yeVNldHRpbmdzAQFFFQAvAQLtA0UVAAAIAAAAACMAAQEAGwAjAAEB" +
           "AxsAIwABAQYbACMAAQEJGwAjAAEBDBsAIwABAQ8bACMAAQESGwAjAAEBFRsAAAAABGCACgEAAAABABQA" +
           "AABBbmFseXNlclN0YXRlTWFjaGluZQEBRhUALwEB6gNGFQAAAgAAAAAvAAEBrR8ALwABAawfEAAAABVg" +
           "iQoCAAAAAAAMAAAAQ3VycmVudFN0YXRlAQEeGwAvAQDICh4bAAAAFf////8BAf////8BAAAAFWCJCgIA" +
           "AAAAAAIAAABJZAEBHxsALgBEHxsAAAAR/////wEB/////wAAAAAkYIAKAQAAAAEABwAAAFBvd2VydXAB" +
           "AUcVAwAAAABRAAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIGl0cyBwb3dlci11cCBzZXF1ZW5jZSBh" +
           "bmQgY2Fubm90IHBlcmZvcm0gYW55IG90aGVyIHRhc2suAC8BAAUJRxUAAAEAAAAAMwEBAUwVAAAAACRg" +
           "gAoBAAAAAQAJAAAAT3BlcmF0aW5nAQFIFQMAAAAALAAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiB0" +
           "aGUgT3BlcmF0aW5nIG1vZGUuAC8BAAMJSBUAAAYAAAAANAEBAUwVADMBAQFNFQAzAQEBThUANAEBAU8V" +
           "ADQBAQFRFQAzAQEBUxUAAAAAJGCACgEAAAABAAUAAABMb2NhbAEBSRUDAAAAAHoAAABUaGUgQW5hbHlz" +
           "ZXJEZXZpY2UgaXMgaW4gdGhlIExvY2FsIG1vZGUuIFRoaXMgbW9kZSBpcyBub3JtYWxseSB1c2VkIHRv" +
           "IHBlcmZvcm0gbG9jYWwgcGh5c2ljYWwgbWFpbnRlbmFuY2Ugb24gdGhlIGFuYWx5c2VyLgAvAQADCUkV" +
           "AAAFAAAAADQBAQFNFQAzAQEBTxUAMwEBAVAVADQBAQFSFQAzAQEBVBUAAAAAJGCACgEAAAABAAsAAABN" +
           "YWludGVuYW5jZQEBShUDAAAAAIUAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gdGhlIE1haW50ZW5h" +
           "bmNlIG1vZGUuIFRoaXMgbW9kZSBpcyB1c2VkIHRvIHBlcmZvcm0gcmVtb3RlIG1haW50ZW5hbmNlIG9u" +
           "IHRoZSBhbmFseXNlciBsaWtlIGZpcm13YXJlIHVwZ3JhZGUuAC8BAAMJShUAAAUAAAAANAEBAU4VADQB" +
           "AQFQFQAzAQEBURUAMwEBAVIVADMBAQFVFQAAAAAkYIAKAQAAAAEACAAAAFNodXRkb3duAQFLFQMAAAAA" +
           "UwAAAFRoZSBBbmFseXNlckRldmljZSBpcyBpbiBpdHMgcG93ZXItZG93biBzZXF1ZW5jZSBhbmQgY2Fu" +
           "bm90IHBlcmZvcm0gYW55IG90aGVyIHRhc2suAC8BAAMJSxUAAAMAAAAANAEBAVMVADQBAQFUFQA0AQEB" +
           "VRUAAAAABGCACgEAAAABABwAAABQb3dlcnVwVG9PcGVyYXRpbmdUcmFuc2l0aW9uAQFMFQAvAQAGCUwV" +
           "AAACAAAAADMAAQFHFQA0AAEBSBUAAAAABGCACgEAAAABABoAAABPcGVyYXRpbmdUb0xvY2FsVHJhbnNp" +
           "dGlvbgEBTRUALwEABglNFQAAAgAAAAAzAAEBSBUANAABAUkVAAAAAARggAoBAAAAAQAgAAAAT3BlcmF0" +
           "aW5nVG9NYWludGVuYW5jZVRyYW5zaXRpb24BAU4VAC8BAAYJThUAAAMAAAAAMwABAUgVADQAAQFKFQA1" +
           "AAEBrR8AAAAABGCACgEAAAABABoAAABMb2NhbFRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBTxUALwEABglP" +
           "FQAAAgAAAAAzAAEBSRUANAABAUgVAAAAAARggAoBAAAAAQAcAAAATG9jYWxUb01haW50ZW5hbmNlVHJh" +
           "bnNpdGlvbgEBUBUALwEABglQFQAAAgAAAAAzAAEBSRUANAABAUoVAAAAAARggAoBAAAAAQAgAAAATWFp" +
           "bnRlbmFuY2VUb09wZXJhdGluZ1RyYW5zaXRpb24BAVEVAC8BAAYJURUAAAMAAAAAMwABAUoVADQAAQFI" +
           "FQA1AAEBrB8AAAAABGCACgEAAAABABwAAABNYWludGVuYW5jZVRvTG9jYWxUcmFuc2l0aW9uAQFSFQAv" +
           "AQAGCVIVAAACAAAAADMAAQFKFQA0AAEBSRUAAAAABGCACgEAAAABAB0AAABPcGVyYXRpbmdUb1NodXRk" +
           "b3duVHJhbnNpdGlvbgEBUxUALwEABglTFQAAAgAAAAAzAAEBSBUANAABAUsVAAAAAARggAoBAAAAAQAZ" +
           "AAAATG9jYWxUb1NodXRkb3duVHJhbnNpdGlvbgEBVBUALwEABglUFQAAAgAAAAAzAAEBSRUANAABAUsV" +
           "AAAAAARggAoBAAAAAQAfAAAATWFpbnRlbmFuY2VUb1NodXRkb3duVHJhbnNpdGlvbgEBVRUALwEABglV" +
           "FQAAAgAAAAAzAAEBShUANAABAUsVAAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region NMRDeviceState Class
    #if (!OPCUA_EXCLUDE_NMRDeviceState)
    /// <summary>
    /// Stores an instance of the NMRDeviceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class NMRDeviceState : AnalyserDeviceState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public NMRDeviceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.NMRDeviceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////4RggAABAAAAAQAVAAAATk1SRGV2aWNlVHlwZUluc3RhbmNlAQH4AwEB" +
           "+AMB/////w4AAAAkYIAKAQAAAAIADAAAAFBhcmFtZXRlclNldAEBVhUDAAAAABcAAABGbGF0IGxpc3Qg" +
           "b2YgUGFyYW1ldGVycwAvADpWFQAA/////wsAAAA1YIkKAgAAAAEAEAAAAERpYWdub3N0aWNTdGF0dXMB" +
           "AUQbAwAAAAAlAAAAR2VuZXJhbCBoZWFsdGggc3RhdHVzIG9mIHRoZSBhbmFseXNlcgAvAQA9CUQbAAAB" +
           "AboL/////wEBAQAAAAAjAQEBWRUAAAAANWCJCgIAAAABABIAAABPdXRPZlNwZWNpZmljYXRpb24BAUcb" +
           "AwAAAABkAAAARGV2aWNlIGJlaW5nIG9wZXJhdGVkIG91dCBvZiBTcGVjaWZpY2F0aW9uLiBVbmNlcnRh" +
           "aW4gdmFsdWUgZHVlIHRvIHByb2Nlc3MgYW5kIGVudmlyb25tZW50IGluZmx1ZW5jZQAvAQBFCUcbAAAA" +
           "Af////8BAQEAAAAAIwEBAVkVAgAAABVgiQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEBShsALgBEShsAAAAV" +
           "/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAFRydWVTdGF0ZQEBSxsALgBESxsAAAAV/////wEB////" +
           "/wAAAAA1YIkKAgAAAAEADQAAAEZ1bmN0aW9uQ2hlY2sBAUwbAwAAAABFAAAATG9jYWwgb3BlcmF0aW9u" +
           "LCBjb25maWd1cmF0aW9uIGlzIGNoYW5naW5nLCBzdWJzdGl0dXRlIHZhbHVlIGVudGVyZWQuAC8BAEUJ" +
           "TBsAAAAB/////wEBAQAAAAAjAQEBWRUCAAAAFWCJCgIAAAAAAAoAAABGYWxzZVN0YXRlAQFPGwAuAERP" +
           "GwAAABX/////AQH/////AAAAABVgiQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQFQGwAuAERQGwAAABX/////" +
           "AQH/////AAAAADVgiQoCAAAAAQAMAAAAU2VyaWFsTnVtYmVyAQFRGwMAAAAATQAAAElkZW50aWZpZXIg" +
           "dGhhdCB1bmlxdWVseSBpZGVudGlmaWVzLCB3aXRoaW4gYSBtYW51ZmFjdHVyZXIsIGEgZGV2aWNlIGlu" +
           "c3RhbmNlAC8BAD0JURsAAAAM/////wEBAgAAAAAjAQEBciQAIwEBAVoVAAAAADVgiQoCAAAAAQAMAAAA" +
           "TWFudWZhY3R1cmVyAQFUGwMAAAAAMAAAAE5hbWUgb2YgdGhlIGNvbXBhbnkgdGhhdCBtYW51ZmFjdHVy" +
           "ZWQgdGhlIGRldmljZQAvAQA9CVQbAAAAFf////8BAQIAAAAAIwEBAXIkACMBAQFaFQAAAAA1YIkKAgAA" +
           "AAEABQAAAE1vZGVsAQFXGwMAAAAAGAAAAE1vZGVsIG5hbWUgb2YgdGhlIGRldmljZQAvAQA9CVcbAAAA" +
           "Ff////8BAQIAAAAAIwEBAXIkACMBAQFaFQAAAAA1YIkKAgAAAAEADAAAAERldmljZU1hbnVhbAEBWhsD" +
           "AAAAAFoAAABBZGRyZXNzIChwYXRobmFtZSBpbiB0aGUgZmlsZSBzeXN0ZW0gb3IgYSBVUkwgfCBXZWIg" +
           "YWRkcmVzcykgb2YgdXNlciBtYW51YWwgZm9yIHRoZSBkZXZpY2UALwEAPQlaGwAAAAz/////AQEBAAAA" +
           "ACMBAQFaFQAAAAA1YIkKAgAAAAEADgAAAERldmljZVJldmlzaW9uAQFdGwMAAAAAJAAAAE92ZXJhbGwg" +
           "cmV2aXNpb24gbGV2ZWwgb2YgdGhlIGRldmljZQAvAQA9CV0bAAAADP////8BAQEAAAAAIwEBAVoVAAAA" +
           "ADVgiQoCAAAAAQAQAAAAU29mdHdhcmVSZXZpc2lvbgEBYBsDAAAAADUAAABSZXZpc2lvbiBsZXZlbCBv" +
           "ZiB0aGUgc29mdHdhcmUvZmlybXdhcmUgb2YgdGhlIGRldmljZQAvAQA9CWAbAAAADP////8BAQEAAAAA" +
           "IwEBAVoVAAAAADVgiQoCAAAAAQAQAAAASGFyZHdhcmVSZXZpc2lvbgEBYxsDAAAAACwAAABSZXZpc2lv" +
           "biBsZXZlbCBvZiB0aGUgaGFyZHdhcmUgb2YgdGhlIGRldmljZQAvAQA9CWMbAAAADP////8BAQEAAAAA" +
           "IwEBAVoVAAAAADVgiQoCAAAAAQAPAAAAUmV2aXNpb25Db3VudGVyAQFmGwMAAAAAaQAAAEFuIGluY3Jl" +
           "bWVudGFsIGNvdW50ZXIgaW5kaWNhdGluZyB0aGUgbnVtYmVyIG9mIHRpbWVzIHRoZSBzdGF0aWMgZGF0" +
           "YSB3aXRoaW4gdGhlIERldmljZSBoYXMgYmVlbiBtb2RpZmllZAAvAQA9CWYbAAAAB/////8BAQEAAAAA" +
           "IwEBAVoVAAAAACRggAoBAAAAAgAJAAAATWV0aG9kU2V0AQFXFQMAAAAAFAAAAEZsYXQgbGlzdCBvZiBN" +
           "ZXRob2RzAC8AOlcVAAD/////CgAAAARhggoEAAAAAQAQAAAAR2V0Q29uZmlndXJhdGlvbgEBdCQALwEB" +
           "nh90JAAAAQH/////AQAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQF1JAAuAER1JAAAlgEA" +
           "AAABACoBARkAAAAKAAAAQ29uZmlnRGF0YQAP/////wAAAAAAAQAoAQEAAAABAf////8AAAAABGGCCgQA" +
           "AAABABAAAABTZXRDb25maWd1cmF0aW9uAQF2JAAvAQGgH3YkAAABAf////8CAAAAFWCpCgIAAAAAAA4A" +
           "AABJbnB1dEFyZ3VtZW50cwEBdyQALgBEdyQAAJYBAAAAAQAqAQEZAAAACgAAAENvbmZpZ0RhdGEAD///" +
           "//8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQF4JAAu" +
           "AER4JAAAlgEAAAABACoBAR8AAAAQAAAAQ29uZmlnRGF0YURpZ2VzdAAM/////wAAAAAAAQAoAQEAAAAB" +
           "Af////8AAAAABGGCCgQAAAABABMAAABHZXRDb25maWdEYXRhRGlnZXN0AQF5JAAvAQGjH3kkAAABAf//" +
           "//8BAAAAFWCpCgIAAAAAAA8AAABPdXRwdXRBcmd1bWVudHMBAXokAC4ARHokAACWAQAAAAEAKgEBHwAA" +
           "ABAAAABDb25maWdEYXRhRGlnZXN0AAz/////AAAAAAABACgBAQAAAAEB/////wAAAAAEYYIKBAAAAAEA" +
           "FwAAAENvbXBhcmVDb25maWdEYXRhRGlnZXN0AQF7JAAvAQGlH3skAAABAf////8CAAAAFWCpCgIAAAAA" +
           "AA4AAABJbnB1dEFyZ3VtZW50cwEBfCQALgBEfCQAAJYBAAAAAQAqAQEfAAAAEAAAAENvbmZpZ0RhdGFE" +
           "aWdlc3QADP////8AAAAAAAEAKAEBAAAAAQH/////AAAAABVgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1l" +
           "bnRzAQF9JAAuAER9JAAAlgEAAAABACoBARYAAAAHAAAASXNFcXVhbAAB/////wAAAAAAAQAoAQEAAAAB" +
           "Af////8AAAAAJGGCCgQAAAABABAAAABSZXNldEFsbENoYW5uZWxzAQF+JAMAAAAAPAAAAFJlc2V0IGFs" +
           "bCBBbmFseXNlckNoYW5uZWxzIGJlbG9uZ2luZyB0byB0aGlzIEFuYWx5c2VyRGV2aWNlLgAvAQGoH34k" +
           "AAABAf////8AAAAAJGGCCgQAAAABABAAAABTdGFydEFsbENoYW5uZWxzAQF/JAMAAAAAPAAAAFN0YXJ0" +
           "IGFsbCBBbmFseXNlckNoYW5uZWxzIGJlbG9uZ2luZyB0byB0aGlzIEFuYWx5c2VyRGV2aWNlLgAvAQGp" +
           "H38kAAABAf////8AAAAAJGGCCgQAAAABAA8AAABTdG9wQWxsQ2hhbm5lbHMBAYAkAwAAAAA7AAAAU3Rv" +
           "cCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRldmljZS4ALwEB" +
           "qh+AJAAAAQH/////AAAAACRhggoEAAAAAQAQAAAAQWJvcnRBbGxDaGFubmVscwEBgSQDAAAAADwAAABB" +
           "Ym9ydCBhbGwgQW5hbHlzZXJDaGFubmVscyBiZWxvbmdpbmcgdG8gdGhpcyBBbmFseXNlckRldmljZS4A" +
           "LwEBqx+BJAAAAQH/////AAAAACRhggoEAAAAAQANAAAAR290b09wZXJhdGluZwEBgiQDAAAAAI0AAABB" +
           "bmFseXNlckRldmljZVN0YXRlTWFjaGluZSB0byBnbyB0byBPcGVyYXRpbmcgc3RhdGUsIGZvcmNpbmcg" +
           "YWxsIEFuYWx5c2VyQ2hhbm5lbHMgdG8gbGVhdmUgdGhlIFNsYXZlTW9kZSBzdGF0ZSBhbmQgZ28gdG8g" +
           "dGhlIE9wZXJhdGluZyBzdGF0ZS4ALwEBrB+CJAAAAQH/////AAAAACRhggoEAAAAAQAPAAAAR290b01h" +
           "aW50ZW5hbmNlAQGDJAMAAAAAZwAAAEFuYWx5c2VyRGV2aWNlU3RhdGVNYWNoaW5lIHRvIGdvIHRvIE1h" +
           "aW50ZW5hbmNlIHN0YXRlLCBmb3JjaW5nIGFsbCBBbmFseXNlckNoYW5uZWxzIHRvIFNsYXZlTW9kZSBz" +
           "dGF0ZS4ALwEBrR+DJAAAAQH/////AAAAADVgiQoCAAAAAgAMAAAAU2VyaWFsTnVtYmVyAQE9GwMAAAAA" +
           "TQAAAElkZW50aWZpZXIgdGhhdCB1bmlxdWVseSBpZGVudGlmaWVzLCB3aXRoaW4gYSBtYW51ZmFjdHVy" +
           "ZXIsIGEgZGV2aWNlIGluc3RhbmNlAC4ARD0bAAAADP////8BAf////8AAAAANWCJCgIAAAACAA8AAABS" +
           "ZXZpc2lvbkNvdW50ZXIBAXMkAwAAAABpAAAAQW4gaW5jcmVtZW50YWwgY291bnRlciBpbmRpY2F0aW5n" +
           "IHRoZSBudW1iZXIgb2YgdGltZXMgdGhlIHN0YXRpYyBkYXRhIHdpdGhpbiB0aGUgRGV2aWNlIGhhcyBi" +
           "ZWVuIG1vZGlmaWVkAC4ARHMkAAAABv////8BAf////8AAAAANWCJCgIAAAACAAwAAABNYW51ZmFjdHVy" +
           "ZXIBAT4bAwAAAAAYAAAATW9kZWwgbmFtZSBvZiB0aGUgZGV2aWNlAC4ARD4bAAAAFf////8BAf////8A" +
           "AAAANWCJCgIAAAACAAUAAABNb2RlbAEBPxsDAAAAADAAAABOYW1lIG9mIHRoZSBjb21wYW55IHRoYXQg" +
           "bWFudWZhY3R1cmVkIHRoZSBkZXZpY2UALgBEPxsAAAAV/////wEB/////wAAAAA1YIkKAgAAAAIADAAA" +
           "AERldmljZU1hbnVhbAEBQBsDAAAAAFoAAABBZGRyZXNzIChwYXRobmFtZSBpbiB0aGUgZmlsZSBzeXN0" +
           "ZW0gb3IgYSBVUkwgfCBXZWIgYWRkcmVzcykgb2YgdXNlciBtYW51YWwgZm9yIHRoZSBkZXZpY2UALgBE" +
           "QBsAAAAM/////wEB/////wAAAAA1YIkKAgAAAAIADgAAAERldmljZVJldmlzaW9uAQFBGwMAAAAAJAAA" +
           "AE92ZXJhbGwgcmV2aXNpb24gbGV2ZWwgb2YgdGhlIGRldmljZQAuAERBGwAAAAz/////AQH/////AAAA" +
           "ADVgiQoCAAAAAgAQAAAAU29mdHdhcmVSZXZpc2lvbgEBQhsDAAAAADUAAABSZXZpc2lvbiBsZXZlbCBv" +
           "ZiB0aGUgc29mdHdhcmUvZmlybXdhcmUgb2YgdGhlIGRldmljZQAuAERCGwAAAAz/////AQH/////AAAA" +
           "ADVgiQoCAAAAAgAQAAAASGFyZHdhcmVSZXZpc2lvbgEBQxsDAAAAACwAAABSZXZpc2lvbiBsZXZlbCBv" +
           "ZiB0aGUgaGFyZHdhcmUgb2YgdGhlIGRldmljZQAuAERDGwAAAAz/////AQH/////AAAAAARggAoBAAAA" +
           "AQANAAAAQ29uZmlndXJhdGlvbgEBWBUALwEC7QNYFQAA/////wAAAAAEYIAKAQAAAAEABgAAAFN0YXR1" +
           "cwEBWRUALwEC7QNZFQAAAwAAAAAjAAEBRBsAIwABAUcbACMAAQFMGwAAAAAEYIAKAQAAAAEADwAAAEZh" +
           "Y3RvcnlTZXR0aW5ncwEBWhUALwEC7QNaFQAACAAAAAAjAAEBURsAIwABAVQbACMAAQFXGwAjAAEBWhsA" +
           "IwABAV0bACMAAQFgGwAjAAEBYxsAIwABAWYbAAAAAARggAoBAAAAAQAUAAAAQW5hbHlzZXJTdGF0ZU1h" +
           "Y2hpbmUBAVsVAC8BAeoDWxUAAAIAAAAALwABAa0fAC8AAQGsHxAAAAAVYIkKAgAAAAAADAAAAEN1cnJl" +
           "bnRTdGF0ZQEBbxsALwEAyApvGwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAXAbAC4A" +
           "RHAbAAAAEf////8BAf////8AAAAAJGCACgEAAAABAAcAAABQb3dlcnVwAQFcFQMAAAAAUQAAAFRoZSBB" +
           "bmFseXNlckRldmljZSBpcyBpbiBpdHMgcG93ZXItdXAgc2VxdWVuY2UgYW5kIGNhbm5vdCBwZXJmb3Jt" +
           "IGFueSBvdGhlciB0YXNrLgAvAQAFCVwVAAABAAAAADMBAQFhFQAAAAAkYIAKAQAAAAEACQAAAE9wZXJh" +
           "dGluZwEBXRUDAAAAACwAAABUaGUgQW5hbHlzZXJEZXZpY2UgaXMgaW4gdGhlIE9wZXJhdGluZyBtb2Rl" +
           "LgAvAQADCV0VAAAGAAAAADQBAQFhFQAzAQEBYhUAMwEBAWMVADQBAQFkFQA0AQEBZhUAMwEBAWgVAAAA" +
           "ACRggAoBAAAAAQAFAAAATG9jYWwBAV4VAwAAAAB6AAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRo" +
           "ZSBMb2NhbCBtb2RlLiBUaGlzIG1vZGUgaXMgbm9ybWFsbHkgdXNlZCB0byBwZXJmb3JtIGxvY2FsIHBo" +
           "eXNpY2FsIG1haW50ZW5hbmNlIG9uIHRoZSBhbmFseXNlci4ALwEAAwleFQAABQAAAAA0AQEBYhUAMwEB" +
           "AWQVADMBAQFlFQA0AQEBZxUAMwEBAWkVAAAAACRggAoBAAAAAQALAAAATWFpbnRlbmFuY2UBAV8VAwAA" +
           "AACFAAAAVGhlIEFuYWx5c2VyRGV2aWNlIGlzIGluIHRoZSBNYWludGVuYW5jZSBtb2RlLiBUaGlzIG1v" +
           "ZGUgaXMgdXNlZCB0byBwZXJmb3JtIHJlbW90ZSBtYWludGVuYW5jZSBvbiB0aGUgYW5hbHlzZXIgbGlr" +
           "ZSBmaXJtd2FyZSB1cGdyYWRlLgAvAQADCV8VAAAFAAAAADQBAQFjFQA0AQEBZRUAMwEBAWYVADMBAQFn" +
           "FQAzAQEBahUAAAAAJGCACgEAAAABAAgAAABTaHV0ZG93bgEBYBUDAAAAAFMAAABUaGUgQW5hbHlzZXJE" +
           "ZXZpY2UgaXMgaW4gaXRzIHBvd2VyLWRvd24gc2VxdWVuY2UgYW5kIGNhbm5vdCBwZXJmb3JtIGFueSBv" +
           "dGhlciB0YXNrLgAvAQADCWAVAAADAAAAADQBAQFoFQA0AQEBaRUANAEBAWoVAAAAAARggAoBAAAAAQAc" +
           "AAAAUG93ZXJ1cFRvT3BlcmF0aW5nVHJhbnNpdGlvbgEBYRUALwEABglhFQAAAgAAAAAzAAEBXBUANAAB" +
           "AV0VAAAAAARggAoBAAAAAQAaAAAAT3BlcmF0aW5nVG9Mb2NhbFRyYW5zaXRpb24BAWIVAC8BAAYJYhUA" +
           "AAIAAAAAMwABAV0VADQAAQFeFQAAAAAEYIAKAQAAAAEAIAAAAE9wZXJhdGluZ1RvTWFpbnRlbmFuY2VU" +
           "cmFuc2l0aW9uAQFjFQAvAQAGCWMVAAADAAAAADMAAQFdFQA0AAEBXxUANQABAa0fAAAAAARggAoBAAAA" +
           "AQAaAAAATG9jYWxUb09wZXJhdGluZ1RyYW5zaXRpb24BAWQVAC8BAAYJZBUAAAIAAAAAMwABAV4VADQA" +
           "AQFdFQAAAAAEYIAKAQAAAAEAHAAAAExvY2FsVG9NYWludGVuYW5jZVRyYW5zaXRpb24BAWUVAC8BAAYJ" +
           "ZRUAAAIAAAAAMwABAV4VADQAAQFfFQAAAAAEYIAKAQAAAAEAIAAAAE1haW50ZW5hbmNlVG9PcGVyYXRp" +
           "bmdUcmFuc2l0aW9uAQFmFQAvAQAGCWYVAAADAAAAADMAAQFfFQA0AAEBXRUANQABAawfAAAAAARggAoB" +
           "AAAAAQAcAAAATWFpbnRlbmFuY2VUb0xvY2FsVHJhbnNpdGlvbgEBZxUALwEABglnFQAAAgAAAAAzAAEB" +
           "XxUANAABAV4VAAAAAARggAoBAAAAAQAdAAAAT3BlcmF0aW5nVG9TaHV0ZG93blRyYW5zaXRpb24BAWgV" +
           "AC8BAAYJaBUAAAIAAAAAMwABAV0VADQAAQFgFQAAAAAEYIAKAQAAAAEAGQAAAExvY2FsVG9TaHV0ZG93" +
           "blRyYW5zaXRpb24BAWkVAC8BAAYJaRUAAAIAAAAAMwABAV4VADQAAQFgFQAAAAAEYIAKAQAAAAEAHwAA" +
           "AE1haW50ZW5hbmNlVG9TaHV0ZG93blRyYW5zaXRpb24BAWoVAC8BAAYJahUAAAIAAAAAMwABAV8VADQA" +
           "AQFgFQAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region AccessorySlotState Class
    #if (!OPCUA_EXCLUDE_AccessorySlotState)
    /// <summary>
    /// Stores an instance of the AccessorySlotType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AccessorySlotState : ConfigurableObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AccessorySlotState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AccessorySlotType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQAZAAAAQWNjZXNzb3J5U2xvdFR5cGVJbnN0YW5jZQEB" +
           "+QMBAfkD/////wQAAAAkYIAKAQAAAAIADgAAAFN1cHBvcnRlZFR5cGVzAQGEJAMAAAAAcgAAAEZvbGRl" +
           "ciBtYWludGFpbmluZyB0aGUgc2V0IG9mIChzdWItdHlwZXMgb2YpIEJhc2VPYmplY3RUeXBlcyB0aGF0" +
           "IGNhbiBiZSBpbnN0YW50aWF0ZWQgaW4gdGhlIENvbmZpZ3VyYWJsZUNvbXBvbmVudAAvAD2EJAAA////" +
           "/wAAAAA1YIkKAgAAAAEADgAAAElzSG90U3dhcHBhYmxlAQGOGwMAAAAATgAAAFRydWUgaWYgYW4gYWNj" +
           "ZXNzb3J5IGNhbiBiZSBpbnNlcnRlZCBpbiB0aGUgYWNjZXNzb3J5IHNsb3Qgd2hpbGUgaXQgaXMgcG93" +
           "ZXJlZAAuAESOGwAAAAH/////AQH/////AAAAADVgiQoCAAAAAQAJAAAASXNFbmFibGVkAQGPGwMAAAAA" +
           "RgAAAFRydWUgaWYgdGhpcyBhY2Nlc3Nvcnkgc2xvdCBpcyBjYXBhYmxlIG9mIGFjY2VwdGluZyBhbiBh" +
           "Y2Nlc3NvcnkgaW4gaXQALgBEjxsAAAAB/////wEB/////wAAAAAEYIAKAQAAAAEAGQAAAEFjY2Vzc29y" +
           "eVNsb3RTdGF0ZU1hY2hpbmUBAWsVAC8BAfoDaxUAAP////8TAAAAFWCJCgIAAAAAAAwAAABDdXJyZW50" +
           "U3RhdGUBAZAbAC8BAMgKkBsAAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQGRGwAuAESR" +
           "GwAAABH/////AQH/////AAAAACRggAoBAAAAAQAHAAAAUG93ZXJ1cAEBbBUDAAAAAFAAAABUaGUgQWNj" +
           "ZXNzb3J5U2xvdCBpcyBpbiBpdHMgcG93ZXItdXAgc2VxdWVuY2UgYW5kIGNhbm5vdCBwZXJmb3JtIGFu" +
           "eSBvdGhlciB0YXNrLgAvAQAFCWwVAAABAAAAADMBAQFyFQAAAAAkYIAKAQAAAAEABQAAAEVtcHR5AQFt" +
           "FQMAAAAAQQAAAFRoaXMgcmVwcmVzZW50cyBhbiBBY2Nlc3NvcnlTbG90IHdoZXJlIG5vIEFjY2Vzc29y" +
           "eSBpcyBpbnN0YWxsZWQuAC8BAAMJbRUAAAQAAAAANAEBAXIVADMBAQFzFQA0AQEBeRUAMwEBAXoVAAAA" +
           "ACRggAoBAAAAAQAJAAAASW5zZXJ0aW5nAQFuFQMAAAAAVgAAAFRoaXMgcmVwcmVzZW50cyBhbiBBY2Nl" +
           "c3NvcnlTbG90IHdoZW4gYW4gQWNjZXNzb3J5IGlzIGJlaW5nIGluc2VydGVkIGFuZCBpbml0aWFsaXpp" +
           "bmcuAC8BAAMJbhUAAAYAAAAANAEBAXMVADMBAQF0FQA0AQEBdBUAMwEBAXUVADMBAQF2FQAzAQEBexUA" +
           "AAAAJGCACgEAAAABAAkAAABJbnN0YWxsZWQBAW8VAwAAAABSAAAAVGhpcyByZXByZXNlbnRzIGFuIEFj" +
           "Y2Vzc29yeVNsb3Qgd2hlcmUgYW4gQWNjZXNzb3J5IGlzIGluc3RhbGxlZCBhbmQgcmVhZHkgdG8gdXNl" +
           "LgAvAQADCW8VAAADAAAAADQBAQF2FQAzAQEBdxUAMwEBAXwVAAAAACRggAoBAAAAAQAIAAAAUmVtb3Zp" +
           "bmcBAXAVAwAAAABBAAAAVGhpcyByZXByZXNlbnRzIGFuIEFjY2Vzc29yeVNsb3Qgd2hlcmUgbm8gQWNj" +
           "ZXNzb3J5IGlzIGluc3RhbGxlZC4ALwEAAwlwFQAABgAAAAA0AQEBdRUANAEBAXcVADMBAQF4FQA0AQEB" +
           "eBUAMwEBAXkVADMBAQF9FQAAAAAkYIAKAQAAAAEACAAAAFNodXRkb3duAQFxFQMAAAAAUgAAAFRoZSBB" +
           "Y2Nlc3NvcnlTbG90IGlzIGluIGl0cyBwb3dlci1kb3duIHNlcXVlbmNlIGFuZCBjYW5ub3QgcGVyZm9y" +
           "bSBhbnkgb3RoZXIgdGFzay4ALwEAAwlxFQAABAAAAAA0AQEBehUANAEBAXsVADQBAQF8FQA0AQEBfRUA" +
           "AAAABGCACgEAAAABABgAAABQb3dlcnVwVG9FbXB0eVRyYW5zaXRpb24BAXIVAC8BAAYJchUAAAIAAAAA" +
           "MwABAWwVADQAAQFtFQAAAAAEYIAKAQAAAAEAGgAAAEVtcHR5VG9JbnNlcnRpbmdUcmFuc2l0aW9uAQFz" +
           "FQAvAQAGCXMVAAACAAAAADMAAQFtFQA0AAEBbhUAAAAABGCACgEAAAABABMAAABJbnNlcnRpbmdUcmFu" +
           "c2l0aW9uAQF0FQAvAQAGCXQVAAACAAAAADMAAQFuFQA0AAEBbhUAAAAABGCACgEAAAABAB0AAABJbnNl" +
           "cnRpbmdUb1JlbW92aW5nVHJhbnNpdGlvbgEBdRUALwEABgl1FQAAAgAAAAAzAAEBbhUANAABAXAVAAAA" +
           "AARggAoBAAAAAQAeAAAASW5zZXJ0aW5nVG9JbnN0YWxsZWRUcmFuc2l0aW9uAQF2FQAvAQAGCXYVAAAC" +
           "AAAAADMAAQFuFQA0AAEBbxUAAAAABGCACgEAAAABAB0AAABJbnN0YWxsZWRUb1JlbW92aW5nVHJhbnNp" +
           "dGlvbgEBdxUALwEABgl3FQAAAgAAAAAzAAEBbxUANAABAXAVAAAAAARggAoBAAAAAQASAAAAUmVtb3Zp" +
           "bmdUcmFuc2l0aW9uAQF4FQAvAQAGCXgVAAACAAAAADMAAQFwFQA0AAEBcBUAAAAABGCACgEAAAABABkA" +
           "AABSZW1vdmluZ1RvRW1wdHlUcmFuc2l0aW9uAQF5FQAvAQAGCXkVAAACAAAAADMAAQFwFQA0AAEBbRUA" +
           "AAAABGCACgEAAAABABkAAABFbXB0eVRvU2h1dGRvd25UcmFuc2l0aW9uAQF6FQAvAQAGCXoVAAACAAAA" +
           "ADMAAQFtFQA0AAEBcRUAAAAABGCACgEAAAABAB0AAABJbnNlcnRpbmdUb1NodXRkb3duVHJhbnNpdGlv" +
           "bgEBexUALwEABgl7FQAAAgAAAAAzAAEBbhUANAABAXEVAAAAAARggAoBAAAAAQAdAAAASW5zdGFsbGVk" +
           "VG9TaHV0ZG93blRyYW5zaXRpb24BAXwVAC8BAAYJfBUAAAIAAAAAMwABAW8VADQAAQFxFQAAAAAEYIAK" +
           "AQAAAAEAHAAAAFJlbW92aW5nVG9TaHV0ZG93blRyYW5zaXRpb24BAX0VAC8BAAYJfRUAAAIAAAAAMwAB" +
           "AXAVADQAAQFxFQAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// True if an accessory can be inserted in the accessory slot while it is powered
        /// </summary>
        public PropertyState<bool> IsHotSwappable
        {
            get
            { 
                return m_isHotSwappable;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_isHotSwappable, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_isHotSwappable = value;
            }
        }

        /// <summary>
        /// True if this accessory slot is capable of accepting an accessory in it
        /// </summary>
        public PropertyState<bool> IsEnabled
        {
            get
            { 
                return m_isEnabled;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_isEnabled, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_isEnabled = value;
            }
        }

        /// <summary>
        /// A description for the AccessorySlotStateMachine Object.
        /// </summary>
        public AccessorySlotStateMachineState AccessorySlotStateMachine
        {
            get
            { 
                return m_accessorySlotStateMachine;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_accessorySlotStateMachine, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_accessorySlotStateMachine = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_isHotSwappable != null)
            {
                children.Add(m_isHotSwappable);
            }

            if (m_isEnabled != null)
            {
                children.Add(m_isEnabled);
            }

            if (m_accessorySlotStateMachine != null)
            {
                children.Add(m_accessorySlotStateMachine);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.IsHotSwappable:
                {
                    if (createOrReplace)
                    {
                        if (IsHotSwappable == null)
                        {
                            if (replacement == null)
                            {
                                IsHotSwappable = new PropertyState<bool>(this);
                            }
                            else
                            {
                                IsHotSwappable = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = IsHotSwappable;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.IsEnabled:
                {
                    if (createOrReplace)
                    {
                        if (IsEnabled == null)
                        {
                            if (replacement == null)
                            {
                                IsEnabled = new PropertyState<bool>(this);
                            }
                            else
                            {
                                IsEnabled = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = IsEnabled;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.AccessorySlotStateMachine:
                {
                    if (createOrReplace)
                    {
                        if (AccessorySlotStateMachine == null)
                        {
                            if (replacement == null)
                            {
                                AccessorySlotStateMachine = new AccessorySlotStateMachineState(this);
                            }
                            else
                            {
                                AccessorySlotStateMachine = (AccessorySlotStateMachineState)replacement;
                            }
                        }
                    }

                    instance = AccessorySlotStateMachine;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<bool> m_isHotSwappable;
        private PropertyState<bool> m_isEnabled;
        private AccessorySlotStateMachineState m_accessorySlotStateMachine;
        #endregion
    }
    #endif
    #endregion

    #region AccessorySlotStateMachineState Class
    #if (!OPCUA_EXCLUDE_AccessorySlotStateMachineState)
    /// <summary>
    /// Stores an instance of the AccessorySlotStateMachineType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AccessorySlotStateMachineState : FiniteStateMachineState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AccessorySlotStateMachineState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AccessorySlotStateMachineType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQAlAAAAQWNjZXNzb3J5U2xvdFN0YXRlTWFjaGluZVR5" +
           "cGVJbnN0YW5jZQEB+gMBAfoD/////xMAAAAVYIkKAgAAAAAADAAAAEN1cnJlbnRTdGF0ZQEBrBsALwEA" +
           "yAqsGwAAABX/////AQH/////AQAAABVgiQoCAAAAAAACAAAASWQBAa0bAC4ARK0bAAAAEf////8BAf//" +
           "//8AAAAAJGCACgEAAAABAAcAAABQb3dlcnVwAQF+FQMAAAAAUAAAAFRoZSBBY2Nlc3NvcnlTbG90IGlz" +
           "IGluIGl0cyBwb3dlci11cCBzZXF1ZW5jZSBhbmQgY2Fubm90IHBlcmZvcm0gYW55IG90aGVyIHRhc2su" +
           "AC8BAAUJfhUAAAEAAAAAMwEBAYQVAQAAABVgqQoCAAAAAAALAAAAU3RhdGVOdW1iZXIBAbYbAC4ARLYb" +
           "AAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEABQAAAEVtcHR5AQF/FQMAAAAAQQAAAFRoaXMg" +
           "cmVwcmVzZW50cyBhbiBBY2Nlc3NvcnlTbG90IHdoZXJlIG5vIEFjY2Vzc29yeSBpcyBpbnN0YWxsZWQu" +
           "AC8BAAMJfxUAAAQAAAAANAEBAYQVADMBAQGFFQA0AQEBixUAMwEBAYwVAQAAABVgqQoCAAAAAAALAAAA" +
           "U3RhdGVOdW1iZXIBAbcbAC4ARLcbAAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEACQAAAElu" +
           "c2VydGluZwEBgBUDAAAAAFYAAABUaGlzIHJlcHJlc2VudHMgYW4gQWNjZXNzb3J5U2xvdCB3aGVuIGFu" +
           "IEFjY2Vzc29yeSBpcyBiZWluZyBpbnNlcnRlZCBhbmQgaW5pdGlhbGl6aW5nLgAvAQADCYAVAAAGAAAA" +
           "ADQBAQGFFQAzAQEBhhUANAEBAYYVADMBAQGHFQAzAQEBiBUAMwEBAY0VAQAAABVgqQoCAAAAAAALAAAA" +
           "U3RhdGVOdW1iZXIBAbgbAC4ARLgbAAAHAAAAAAAH/////wEB/////wAAAAAkYIAKAQAAAAEACQAAAElu" +
           "c3RhbGxlZAEBgRUDAAAAAFIAAABUaGlzIHJlcHJlc2VudHMgYW4gQWNjZXNzb3J5U2xvdCB3aGVyZSBh" +
           "biBBY2Nlc3NvcnkgaXMgaW5zdGFsbGVkIGFuZCByZWFkeSB0byB1c2UuAC8BAAMJgRUAAAMAAAAANAEB" +
           "AYgVADMBAQGJFQAzAQEBjhUBAAAAFWCpCgIAAAAAAAsAAABTdGF0ZU51bWJlcgEBuRsALgBEuRsAAAcA" +
           "AAAAAAf/////AQH/////AAAAACRggAoBAAAAAQAIAAAAUmVtb3ZpbmcBAYIVAwAAAABBAAAAVGhpcyBy" +
           "ZXByZXNlbnRzIGFuIEFjY2Vzc29yeVNsb3Qgd2hlcmUgbm8gQWNjZXNzb3J5IGlzIGluc3RhbGxlZC4A" +
           "LwEAAwmCFQAABgAAAAA0AQEBhxUANAEBAYkVADMBAQGKFQA0AQEBihUAMwEBAYsVADMBAQGPFQEAAAAV" +
           "YKkKAgAAAAAACwAAAFN0YXRlTnVtYmVyAQG6GwAuAES6GwAABwAAAAAAB/////8BAf////8AAAAAJGCA" +
           "CgEAAAABAAgAAABTaHV0ZG93bgEBgxUDAAAAAFIAAABUaGUgQWNjZXNzb3J5U2xvdCBpcyBpbiBpdHMg" +
           "cG93ZXItZG93biBzZXF1ZW5jZSBhbmQgY2Fubm90IHBlcmZvcm0gYW55IG90aGVyIHRhc2suAC8BAAMJ" +
           "gxUAAAQAAAAANAEBAYwVADQBAQGNFQA0AQEBjhUANAEBAY8VAQAAABVgqQoCAAAAAAALAAAAU3RhdGVO" +
           "dW1iZXIBAbsbAC4ARLsbAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAGAAAAFBvd2VydXBU" +
           "b0VtcHR5VHJhbnNpdGlvbgEBhBUALwEABgmEFQAAAgAAAAAzAAEBfhUANAABAX8VAQAAABVgqQoCAAAA" +
           "AAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBvBsALgBEvBsAAAcAAAAAAAf/////AQH/////AAAAAARggAoB" +
           "AAAAAQAaAAAARW1wdHlUb0luc2VydGluZ1RyYW5zaXRpb24BAYUVAC8BAAYJhRUAAAIAAAAAMwABAX8V" +
           "ADQAAQGAFQEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAb0bAC4ARL0bAAAHAAAAAAAH" +
           "/////wEB/////wAAAAAEYIAKAQAAAAEAEwAAAEluc2VydGluZ1RyYW5zaXRpb24BAYYVAC8BAAYJhhUA" +
           "AAIAAAAAMwABAYAVADQAAQGAFQEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAb4bAC4A" +
           "RL4bAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHQAAAEluc2VydGluZ1RvUmVtb3ZpbmdU" +
           "cmFuc2l0aW9uAQGHFQAvAQAGCYcVAAACAAAAADMAAQGAFQA0AAEBghUBAAAAFWCpCgIAAAAAABAAAABU" +
           "cmFuc2l0aW9uTnVtYmVyAQG/GwAuAES/GwAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABAB4A" +
           "AABJbnNlcnRpbmdUb0luc3RhbGxlZFRyYW5zaXRpb24BAYgVAC8BAAYJiBUAAAIAAAAAMwABAYAVADQA" +
           "AQGBFQEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAcAbAC4ARMAbAAAHAAAAAAAH////" +
           "/wEB/////wAAAAAEYIAKAQAAAAEAHQAAAEluc3RhbGxlZFRvUmVtb3ZpbmdUcmFuc2l0aW9uAQGJFQAv" +
           "AQAGCYkVAAACAAAAADMAAQGBFQA0AAEBghUBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0aW9uTnVtYmVy" +
           "AQHBGwAuAETBGwAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABABIAAABSZW1vdmluZ1RyYW5z" +
           "aXRpb24BAYoVAC8BAAYJihUAAAIAAAAAMwABAYIVADQAAQGCFQEAAAAVYKkKAgAAAAAAEAAAAFRyYW5z" +
           "aXRpb25OdW1iZXIBAcIbAC4ARMIbAAAHAAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAGQAAAFJl" +
           "bW92aW5nVG9FbXB0eVRyYW5zaXRpb24BAYsVAC8BAAYJixUAAAIAAAAAMwABAYIVADQAAQF/FQEAAAAV" +
           "YKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAcMbAC4ARMMbAAAHAAAAAAAH/////wEB/////wAA" +
           "AAAEYIAKAQAAAAEAGQAAAEVtcHR5VG9TaHV0ZG93blRyYW5zaXRpb24BAYwVAC8BAAYJjBUAAAIAAAAA" +
           "MwABAX8VADQAAQGDFQEAAAAVYKkKAgAAAAAAEAAAAFRyYW5zaXRpb25OdW1iZXIBAcQbAC4ARMQbAAAH" +
           "AAAAAAAH/////wEB/////wAAAAAEYIAKAQAAAAEAHQAAAEluc2VydGluZ1RvU2h1dGRvd25UcmFuc2l0" +
           "aW9uAQGNFQAvAQAGCY0VAAACAAAAADMAAQGAFQA0AAEBgxUBAAAAFWCpCgIAAAAAABAAAABUcmFuc2l0" +
           "aW9uTnVtYmVyAQHFGwAuAETFGwAABwAAAAAAB/////8BAf////8AAAAABGCACgEAAAABAB0AAABJbnN0" +
           "YWxsZWRUb1NodXRkb3duVHJhbnNpdGlvbgEBjhUALwEABgmOFQAAAgAAAAAzAAEBgRUANAABAYMVAQAA" +
           "ABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBxhsALgBExhsAAAcAAAAAAAf/////AQH/////" +
           "AAAAAARggAoBAAAAAQAcAAAAUmVtb3ZpbmdUb1NodXRkb3duVHJhbnNpdGlvbgEBjxUALwEABgmPFQAA" +
           "AgAAAAAzAAEBghUANAABAYMVAQAAABVgqQoCAAAAAAAQAAAAVHJhbnNpdGlvbk51bWJlcgEBxxsALgBE" +
           "xxsAAAcAAAAAAAf/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// The AccessorySlot is in its power-up sequence and cannot perform any other task.
        /// </summary>
        public StateMachineInitialStateState Powerup
        {
            get
            { 
                return m_powerup;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_powerup, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_powerup = value;
            }
        }

        /// <summary>
        /// This represents an AccessorySlot where no Accessory is installed.
        /// </summary>
        public StateMachineStateState Empty
        {
            get
            { 
                return m_empty;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_empty, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_empty = value;
            }
        }

        /// <summary>
        /// This represents an AccessorySlot when an Accessory is being inserted and initializing.
        /// </summary>
        public StateMachineStateState Inserting
        {
            get
            { 
                return m_inserting;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_inserting, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_inserting = value;
            }
        }

        /// <summary>
        /// This represents an AccessorySlot where an Accessory is installed and ready to use.
        /// </summary>
        public StateMachineStateState Installed
        {
            get
            { 
                return m_installed;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_installed, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_installed = value;
            }
        }

        /// <summary>
        /// This represents an AccessorySlot where no Accessory is installed.
        /// </summary>
        public StateMachineStateState Removing
        {
            get
            { 
                return m_removing;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_removing, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_removing = value;
            }
        }

        /// <summary>
        /// The AccessorySlot is in its power-down sequence and cannot perform any other task.
        /// </summary>
        public StateMachineStateState Shutdown
        {
            get
            { 
                return m_shutdown;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_shutdown, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_shutdown = value;
            }
        }

        /// <summary>
        /// A description for the PowerupToEmptyTransition Object.
        /// </summary>
        public StateMachineTransitionState PowerupToEmptyTransition
        {
            get
            { 
                return m_powerupToEmptyTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_powerupToEmptyTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_powerupToEmptyTransition = value;
            }
        }

        /// <summary>
        /// A description for the EmptyToInsertingTransition Object.
        /// </summary>
        public StateMachineTransitionState EmptyToInsertingTransition
        {
            get
            { 
                return m_emptyToInsertingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_emptyToInsertingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_emptyToInsertingTransition = value;
            }
        }

        /// <summary>
        /// A description for the InsertingTransition Object.
        /// </summary>
        public StateMachineTransitionState InsertingTransition
        {
            get
            { 
                return m_insertingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_insertingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_insertingTransition = value;
            }
        }

        /// <summary>
        /// A description for the InsertingToRemovingTransition Object.
        /// </summary>
        public StateMachineTransitionState InsertingToRemovingTransition
        {
            get
            { 
                return m_insertingToRemovingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_insertingToRemovingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_insertingToRemovingTransition = value;
            }
        }

        /// <summary>
        /// A description for the InsertingToInstalledTransition Object.
        /// </summary>
        public StateMachineTransitionState InsertingToInstalledTransition
        {
            get
            { 
                return m_insertingToInstalledTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_insertingToInstalledTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_insertingToInstalledTransition = value;
            }
        }

        /// <summary>
        /// A description for the InstalledToRemovingTransition Object.
        /// </summary>
        public StateMachineTransitionState InstalledToRemovingTransition
        {
            get
            { 
                return m_installedToRemovingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_installedToRemovingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_installedToRemovingTransition = value;
            }
        }

        /// <summary>
        /// A description for the RemovingTransition Object.
        /// </summary>
        public StateMachineTransitionState RemovingTransition
        {
            get
            { 
                return m_removingTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_removingTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_removingTransition = value;
            }
        }

        /// <summary>
        /// A description for the RemovingToEmptyTransition Object.
        /// </summary>
        public StateMachineTransitionState RemovingToEmptyTransition
        {
            get
            { 
                return m_removingToEmptyTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_removingToEmptyTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_removingToEmptyTransition = value;
            }
        }

        /// <summary>
        /// A description for the EmptyToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState EmptyToShutdownTransition
        {
            get
            { 
                return m_emptyToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_emptyToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_emptyToShutdownTransition = value;
            }
        }

        /// <summary>
        /// A description for the InsertingToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState InsertingToShutdownTransition
        {
            get
            { 
                return m_insertingToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_insertingToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_insertingToShutdownTransition = value;
            }
        }

        /// <summary>
        /// A description for the InstalledToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState InstalledToShutdownTransition
        {
            get
            { 
                return m_installedToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_installedToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_installedToShutdownTransition = value;
            }
        }

        /// <summary>
        /// A description for the RemovingToShutdownTransition Object.
        /// </summary>
        public StateMachineTransitionState RemovingToShutdownTransition
        {
            get
            { 
                return m_removingToShutdownTransition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_removingToShutdownTransition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_removingToShutdownTransition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_powerup != null)
            {
                children.Add(m_powerup);
            }

            if (m_empty != null)
            {
                children.Add(m_empty);
            }

            if (m_inserting != null)
            {
                children.Add(m_inserting);
            }

            if (m_installed != null)
            {
                children.Add(m_installed);
            }

            if (m_removing != null)
            {
                children.Add(m_removing);
            }

            if (m_shutdown != null)
            {
                children.Add(m_shutdown);
            }

            if (m_powerupToEmptyTransition != null)
            {
                children.Add(m_powerupToEmptyTransition);
            }

            if (m_emptyToInsertingTransition != null)
            {
                children.Add(m_emptyToInsertingTransition);
            }

            if (m_insertingTransition != null)
            {
                children.Add(m_insertingTransition);
            }

            if (m_insertingToRemovingTransition != null)
            {
                children.Add(m_insertingToRemovingTransition);
            }

            if (m_insertingToInstalledTransition != null)
            {
                children.Add(m_insertingToInstalledTransition);
            }

            if (m_installedToRemovingTransition != null)
            {
                children.Add(m_installedToRemovingTransition);
            }

            if (m_removingTransition != null)
            {
                children.Add(m_removingTransition);
            }

            if (m_removingToEmptyTransition != null)
            {
                children.Add(m_removingToEmptyTransition);
            }

            if (m_emptyToShutdownTransition != null)
            {
                children.Add(m_emptyToShutdownTransition);
            }

            if (m_insertingToShutdownTransition != null)
            {
                children.Add(m_insertingToShutdownTransition);
            }

            if (m_installedToShutdownTransition != null)
            {
                children.Add(m_installedToShutdownTransition);
            }

            if (m_removingToShutdownTransition != null)
            {
                children.Add(m_removingToShutdownTransition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Powerup:
                {
                    if (createOrReplace)
                    {
                        if (Powerup == null)
                        {
                            if (replacement == null)
                            {
                                Powerup = new StateMachineInitialStateState(this);
                            }
                            else
                            {
                                Powerup = (StateMachineInitialStateState)replacement;
                            }
                        }
                    }

                    instance = Powerup;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Empty:
                {
                    if (createOrReplace)
                    {
                        if (Empty == null)
                        {
                            if (replacement == null)
                            {
                                Empty = new StateMachineStateState(this);
                            }
                            else
                            {
                                Empty = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Empty;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Inserting:
                {
                    if (createOrReplace)
                    {
                        if (Inserting == null)
                        {
                            if (replacement == null)
                            {
                                Inserting = new StateMachineStateState(this);
                            }
                            else
                            {
                                Inserting = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Inserting;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Installed:
                {
                    if (createOrReplace)
                    {
                        if (Installed == null)
                        {
                            if (replacement == null)
                            {
                                Installed = new StateMachineStateState(this);
                            }
                            else
                            {
                                Installed = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Installed;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Removing:
                {
                    if (createOrReplace)
                    {
                        if (Removing == null)
                        {
                            if (replacement == null)
                            {
                                Removing = new StateMachineStateState(this);
                            }
                            else
                            {
                                Removing = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Removing;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Shutdown:
                {
                    if (createOrReplace)
                    {
                        if (Shutdown == null)
                        {
                            if (replacement == null)
                            {
                                Shutdown = new StateMachineStateState(this);
                            }
                            else
                            {
                                Shutdown = (StateMachineStateState)replacement;
                            }
                        }
                    }

                    instance = Shutdown;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.PowerupToEmptyTransition:
                {
                    if (createOrReplace)
                    {
                        if (PowerupToEmptyTransition == null)
                        {
                            if (replacement == null)
                            {
                                PowerupToEmptyTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                PowerupToEmptyTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = PowerupToEmptyTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EmptyToInsertingTransition:
                {
                    if (createOrReplace)
                    {
                        if (EmptyToInsertingTransition == null)
                        {
                            if (replacement == null)
                            {
                                EmptyToInsertingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                EmptyToInsertingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = EmptyToInsertingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.InsertingTransition:
                {
                    if (createOrReplace)
                    {
                        if (InsertingTransition == null)
                        {
                            if (replacement == null)
                            {
                                InsertingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                InsertingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = InsertingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.InsertingToRemovingTransition:
                {
                    if (createOrReplace)
                    {
                        if (InsertingToRemovingTransition == null)
                        {
                            if (replacement == null)
                            {
                                InsertingToRemovingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                InsertingToRemovingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = InsertingToRemovingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.InsertingToInstalledTransition:
                {
                    if (createOrReplace)
                    {
                        if (InsertingToInstalledTransition == null)
                        {
                            if (replacement == null)
                            {
                                InsertingToInstalledTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                InsertingToInstalledTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = InsertingToInstalledTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.InstalledToRemovingTransition:
                {
                    if (createOrReplace)
                    {
                        if (InstalledToRemovingTransition == null)
                        {
                            if (replacement == null)
                            {
                                InstalledToRemovingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                InstalledToRemovingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = InstalledToRemovingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.RemovingTransition:
                {
                    if (createOrReplace)
                    {
                        if (RemovingTransition == null)
                        {
                            if (replacement == null)
                            {
                                RemovingTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                RemovingTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = RemovingTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.RemovingToEmptyTransition:
                {
                    if (createOrReplace)
                    {
                        if (RemovingToEmptyTransition == null)
                        {
                            if (replacement == null)
                            {
                                RemovingToEmptyTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                RemovingToEmptyTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = RemovingToEmptyTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EmptyToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (EmptyToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                EmptyToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                EmptyToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = EmptyToShutdownTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.InsertingToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (InsertingToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                InsertingToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                InsertingToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = InsertingToShutdownTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.InstalledToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (InstalledToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                InstalledToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                InstalledToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = InstalledToShutdownTransition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.RemovingToShutdownTransition:
                {
                    if (createOrReplace)
                    {
                        if (RemovingToShutdownTransition == null)
                        {
                            if (replacement == null)
                            {
                                RemovingToShutdownTransition = new StateMachineTransitionState(this);
                            }
                            else
                            {
                                RemovingToShutdownTransition = (StateMachineTransitionState)replacement;
                            }
                        }
                    }

                    instance = RemovingToShutdownTransition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private StateMachineInitialStateState m_powerup;
        private StateMachineStateState m_empty;
        private StateMachineStateState m_inserting;
        private StateMachineStateState m_installed;
        private StateMachineStateState m_removing;
        private StateMachineStateState m_shutdown;
        private StateMachineTransitionState m_powerupToEmptyTransition;
        private StateMachineTransitionState m_emptyToInsertingTransition;
        private StateMachineTransitionState m_insertingTransition;
        private StateMachineTransitionState m_insertingToRemovingTransition;
        private StateMachineTransitionState m_insertingToInstalledTransition;
        private StateMachineTransitionState m_installedToRemovingTransition;
        private StateMachineTransitionState m_removingTransition;
        private StateMachineTransitionState m_removingToEmptyTransition;
        private StateMachineTransitionState m_emptyToShutdownTransition;
        private StateMachineTransitionState m_insertingToShutdownTransition;
        private StateMachineTransitionState m_installedToShutdownTransition;
        private StateMachineTransitionState m_removingToShutdownTransition;
        #endregion
    }
    #endif
    #endregion

    #region AccessoryState Class
    #if (!OPCUA_EXCLUDE_AccessoryState)
    /// <summary>
    /// Stores an instance of the AccessoryType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class AccessoryState : TopologyElementState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public AccessoryState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.AccessoryType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQAVAAAAQWNjZXNzb3J5VHlwZUluc3RhbmNlAQH7AwEB" +
           "+wP/////BgAAACRggAoBAAAAAgAMAAAAUGFyYW1ldGVyU2V0AQGQFQMAAAAAFwAAAEZsYXQgbGlzdCBv" +
           "ZiBQYXJhbWV0ZXJzAC8AOpAVAAD/////AAAAAARggAoBAAAAAQANAAAAQ29uZmlndXJhdGlvbgEBkhUA" +
           "LwEC7QOSFQAA/////wAAAAAEYIAKAQAAAAEABgAAAFN0YXR1cwEBkxUALwEC7QOTFQAA/////wAAAAAE" +
           "YIAKAQAAAAEADwAAAEZhY3RvcnlTZXR0aW5ncwEBlBUALwEC7QOUFQAA/////wAAAAA1YIkKAgAAAAEA" +
           "DgAAAElzSG90U3dhcHBhYmxlAQHIGwMAAAAAUAAAAFRydWUgaWYgdGhpcyBhY2Nlc3NvcnkgY2FuIGJl" +
           "IGluc2VydGVkIGluIHRoZSBhY2Nlc3Nvcnkgc2xvdCB3aGlsZSBpdCBpcyBwb3dlcmVkAC4ARMgbAAAA" +
           "Af////8BAf////8AAAAANWCJCgIAAAABAAcAAABJc1JlYWR5AQHJGwMAAAAAJwAAAFRydWUgaWYgdGhp" +
           "cyBhY2Nlc3NvcnkgaXMgcmVhZHkgZm9yIHVzZQAuAETJGwAAAAH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Configuration Object.
        /// </summary>
        public FunctionalGroupState Configuration
        {
            get
            { 
                return m_configuration;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_configuration, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_configuration = value;
            }
        }

        /// <summary>
        /// A description for the Status Object.
        /// </summary>
        public FunctionalGroupState Status
        {
            get
            { 
                return m_status;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_status, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_status = value;
            }
        }

        /// <summary>
        /// A description for the FactorySettings Object.
        /// </summary>
        public FunctionalGroupState FactorySettings
        {
            get
            { 
                return m_factorySettings;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_factorySettings, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_factorySettings = value;
            }
        }

        /// <summary>
        /// True if this accessory can be inserted in the accessory slot while it is powered
        /// </summary>
        public PropertyState<bool> IsHotSwappable
        {
            get
            { 
                return m_isHotSwappable;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_isHotSwappable, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_isHotSwappable = value;
            }
        }

        /// <summary>
        /// True if this accessory is ready for use
        /// </summary>
        public PropertyState<bool> IsReady
        {
            get
            { 
                return m_isReady;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_isReady, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_isReady = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_configuration != null)
            {
                children.Add(m_configuration);
            }

            if (m_status != null)
            {
                children.Add(m_status);
            }

            if (m_factorySettings != null)
            {
                children.Add(m_factorySettings);
            }

            if (m_isHotSwappable != null)
            {
                children.Add(m_isHotSwappable);
            }

            if (m_isReady != null)
            {
                children.Add(m_isReady);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Configuration:
                {
                    if (createOrReplace)
                    {
                        if (Configuration == null)
                        {
                            if (replacement == null)
                            {
                                Configuration = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Configuration = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Configuration;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Status:
                {
                    if (createOrReplace)
                    {
                        if (Status == null)
                        {
                            if (replacement == null)
                            {
                                Status = new FunctionalGroupState(this);
                            }
                            else
                            {
                                Status = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = Status;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.FactorySettings:
                {
                    if (createOrReplace)
                    {
                        if (FactorySettings == null)
                        {
                            if (replacement == null)
                            {
                                FactorySettings = new FunctionalGroupState(this);
                            }
                            else
                            {
                                FactorySettings = (FunctionalGroupState)replacement;
                            }
                        }
                    }

                    instance = FactorySettings;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.IsHotSwappable:
                {
                    if (createOrReplace)
                    {
                        if (IsHotSwappable == null)
                        {
                            if (replacement == null)
                            {
                                IsHotSwappable = new PropertyState<bool>(this);
                            }
                            else
                            {
                                IsHotSwappable = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = IsHotSwappable;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.IsReady:
                {
                    if (createOrReplace)
                    {
                        if (IsReady == null)
                        {
                            if (replacement == null)
                            {
                                IsReady = new PropertyState<bool>(this);
                            }
                            else
                            {
                                IsReady = (PropertyState<bool>)replacement;
                            }
                        }
                    }

                    instance = IsReady;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private FunctionalGroupState m_configuration;
        private FunctionalGroupState m_status;
        private FunctionalGroupState m_factorySettings;
        private PropertyState<bool> m_isHotSwappable;
        private PropertyState<bool> m_isReady;
        #endregion
    }
    #endif
    #endregion

    #region DetectorState Class
    #if (!OPCUA_EXCLUDE_DetectorState)
    /// <summary>
    /// Stores an instance of the DetectorType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DetectorState : AccessoryState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public DetectorState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.DetectorType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQAUAAAARGV0ZWN0b3JUeXBlSW5zdGFuY2UBAYYkAQGG" +
           "JP////8GAAAAJGCACgEAAAACAAwAAABQYXJhbWV0ZXJTZXQBAYckAwAAAAAXAAAARmxhdCBsaXN0IG9m" +
           "IFBhcmFtZXRlcnMALwA6hyQAAP////8AAAAABGCACgEAAAABAA0AAABDb25maWd1cmF0aW9uAQGKJAAv" +
           "AQLtA4okAAD/////AAAAAARggAoBAAAAAQAGAAAAU3RhdHVzAQGLJAAvAQLtA4skAAD/////AAAAAARg" +
           "gAoBAAAAAQAPAAAARmFjdG9yeVNldHRpbmdzAQGMJAAvAQLtA4wkAAD/////AAAAADVgiQoCAAAAAQAO" +
           "AAAASXNIb3RTd2FwcGFibGUBAY0kAwAAAABQAAAAVHJ1ZSBpZiB0aGlzIGFjY2Vzc29yeSBjYW4gYmUg" +
           "aW5zZXJ0ZWQgaW4gdGhlIGFjY2Vzc29yeSBzbG90IHdoaWxlIGl0IGlzIHBvd2VyZWQALgBEjSQAAAAB" +
           "/////wEB/////wAAAAA1YIkKAgAAAAEABwAAAElzUmVhZHkBAY4kAwAAAAAnAAAAVHJ1ZSBpZiB0aGlz" +
           "IGFjY2Vzc29yeSBpcyByZWFkeSBmb3IgdXNlAC4ARI4kAAAAAf////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region SmartSamplingSystemState Class
    #if (!OPCUA_EXCLUDE_SmartSamplingSystemState)
    /// <summary>
    /// Stores an instance of the SmartSamplingSystemType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SmartSamplingSystemState : AccessoryState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SmartSamplingSystemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.SmartSamplingSystemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQAfAAAAU21hcnRTYW1wbGluZ1N5c3RlbVR5cGVJbnN0" +
           "YW5jZQEBjyQBAY8k/////wYAAAAkYIAKAQAAAAIADAAAAFBhcmFtZXRlclNldAEBkCQDAAAAABcAAABG" +
           "bGF0IGxpc3Qgb2YgUGFyYW1ldGVycwAvADqQJAAA/////wAAAAAEYIAKAQAAAAEADQAAAENvbmZpZ3Vy" +
           "YXRpb24BAZMkAC8BAu0DkyQAAP////8AAAAABGCACgEAAAABAAYAAABTdGF0dXMBAZQkAC8BAu0DlCQA" +
           "AP////8AAAAABGCACgEAAAABAA8AAABGYWN0b3J5U2V0dGluZ3MBAZUkAC8BAu0DlSQAAP////8AAAAA" +
           "NWCJCgIAAAABAA4AAABJc0hvdFN3YXBwYWJsZQEBliQDAAAAAFAAAABUcnVlIGlmIHRoaXMgYWNjZXNz" +
           "b3J5IGNhbiBiZSBpbnNlcnRlZCBpbiB0aGUgYWNjZXNzb3J5IHNsb3Qgd2hpbGUgaXQgaXMgcG93ZXJl" +
           "ZAAuAESWJAAAAAH/////AQH/////AAAAADVgiQoCAAAAAQAHAAAASXNSZWFkeQEBlyQDAAAAACcAAABU" +
           "cnVlIGlmIHRoaXMgYWNjZXNzb3J5IGlzIHJlYWR5IGZvciB1c2UALgBElyQAAAAB/////wEB/////wAA" +
           "AAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region SourceState Class
    #if (!OPCUA_EXCLUDE_SourceState)
    /// <summary>
    /// Stores an instance of the SourceType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class SourceState : AccessoryState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public SourceState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.SourceType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQASAAAAU291cmNlVHlwZUluc3RhbmNlAQGYJAEBmCT/" +
           "////BgAAACRggAoBAAAAAgAMAAAAUGFyYW1ldGVyU2V0AQGZJAMAAAAAFwAAAEZsYXQgbGlzdCBvZiBQ" +
           "YXJhbWV0ZXJzAC8AOpkkAAD/////AAAAAARggAoBAAAAAQANAAAAQ29uZmlndXJhdGlvbgEBnCQALwEC" +
           "7QOcJAAA/////wAAAAAEYIAKAQAAAAEABgAAAFN0YXR1cwEBnSQALwEC7QOdJAAA/////wAAAAAEYIAK" +
           "AQAAAAEADwAAAEZhY3RvcnlTZXR0aW5ncwEBniQALwEC7QOeJAAA/////wAAAAA1YIkKAgAAAAEADgAA" +
           "AElzSG90U3dhcHBhYmxlAQGfJAMAAAAAUAAAAFRydWUgaWYgdGhpcyBhY2Nlc3NvcnkgY2FuIGJlIGlu" +
           "c2VydGVkIGluIHRoZSBhY2Nlc3Nvcnkgc2xvdCB3aGlsZSBpdCBpcyBwb3dlcmVkAC4ARJ8kAAAAAf//" +
           "//8BAf////8AAAAANWCJCgIAAAABAAcAAABJc1JlYWR5AQGgJAMAAAAAJwAAAFRydWUgaWYgdGhpcyBh" +
           "Y2Nlc3NvcnkgaXMgcmVhZHkgZm9yIHVzZQAuAESgJAAAAAH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region GcOvenState Class
    #if (!OPCUA_EXCLUDE_GcOvenState)
    /// <summary>
    /// Stores an instance of the GcOvenType ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class GcOvenState : AccessoryState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public GcOvenState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.ObjectTypes.GcOvenType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////wRggAABAAAAAQASAAAAR2NPdmVuVHlwZUluc3RhbmNlAQH8AwEB/AP/" +
           "////BgAAACRggAoBAAAAAgAMAAAAUGFyYW1ldGVyU2V0AQGVFQMAAAAAFwAAAEZsYXQgbGlzdCBvZiBQ" +
           "YXJhbWV0ZXJzAC8AOpUVAAD/////AAAAAARggAoBAAAAAQANAAAAQ29uZmlndXJhdGlvbgEBlxUALwEC" +
           "7QOXFQAA/////wAAAAAEYIAKAQAAAAEABgAAAFN0YXR1cwEBmBUALwEC7QOYFQAA/////wAAAAAEYIAK" +
           "AQAAAAEADwAAAEZhY3RvcnlTZXR0aW5ncwEBmRUALwEC7QOZFQAA/////wAAAAA1YIkKAgAAAAEADgAA" +
           "AElzSG90U3dhcHBhYmxlAQHKGwMAAAAAUAAAAFRydWUgaWYgdGhpcyBhY2Nlc3NvcnkgY2FuIGJlIGlu" +
           "c2VydGVkIGluIHRoZSBhY2Nlc3Nvcnkgc2xvdCB3aGlsZSBpdCBpcyBwb3dlcmVkAC4ARMobAAAAAf//" +
           "//8BAf////8AAAAANWCJCgIAAAABAAcAAABJc1JlYWR5AQHLGwMAAAAAJwAAAFRydWUgaWYgdGhpcyBh" +
           "Y2Nlc3NvcnkgaXMgcmVhZHkgZm9yIHVzZQAuAETLGwAAAAH/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion

    #region ArrayItemState Class
    #if (!OPCUA_EXCLUDE_ArrayItemState)
    /// <summary>
    /// Stores an instance of the ArrayItemType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ArrayItemState : DataItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ArrayItemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.ArrayItemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
            
            if (InstrumentRange != null)
            {
                InstrumentRange.Initialize(context, InstrumentRange_InitializationString);
            }

            if (Offset != null)
            {
                Offset.Initialize(context, Offset_InitializationString);
            }
        }

        #region Initialization String
        private const string InstrumentRange_InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////zVgiQoCAAAAAQAPAAAASW5zdHJ1bWVudFJhbmdlAQHfGwMAAAAARwAA" +
           "AERlZmluZXMgdGhlIEFycmF5SXRlbS5WYWx1ZSByYW5nZSB0aGF0IGNhbiBiZSByZXR1cm5lZCBieSB0" +
           "aGUgYW5hbHlzZXIuAC4ARN8bAAABAHQD/////wEB/////wAAAAA=";
        
        private const string Offset_InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////zVgiQoCAAAAAQAGAAAAT2Zmc2V0AQHkGwMAAAAAhAAAAERpZmZlcmVu" +
           "Y2UgaW4gMTAwIG5hbm9zZWNvbmQgaW50ZXJ2YWxzIGJldHdlZW4gdGhlIHNvdXJjZVRpbWVzdGFtcCBh" +
           "bmQgdGhlIHRpbWUgd2hlbiB0aGUgc2FtcGxlIG1hdGVyaWFsIHdhcyB0YWtlbiBmcm9tIHRoZSBwcm9j" +
           "ZXNzLgAuAETkGwAAAQAiAf////8BAf////8AAAAA";
        
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVggQACAAAAAQAVAAAAQXJyYXlJdGVtVHlwZUluc3RhbmNlAQHRBwEB" +
           "0QcAGAEB/////wYAAAA1YIkKAgAAAAEADwAAAEluc3RydW1lbnRSYW5nZQEB3xsDAAAAAEcAAABEZWZp" +
           "bmVzIHRoZSBBcnJheUl0ZW0uVmFsdWUgcmFuZ2UgdGhhdCBjYW4gYmUgcmV0dXJuZWQgYnkgdGhlIGFu" +
           "YWx5c2VyLgAuAETfGwAAAQB0A/////8BAf////8AAAAANWCJCgIAAAABAAcAAABFVVJhbmdlAQHgGwMA" +
           "AAAASQAAAEhvbGRzIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJpbmcgdW5pdHMgb2Yg" +
           "dGhlIEFycmF5SXRlbS5WYWx1ZS4ALgBE4BsAAAEAdAP/////AQH/////AAAAADVgiQoCAAAAAQAQAAAA" +
           "RW5naW5lZXJpbmdVbml0cwEB4RsDAAAAAEkAAABIb2xkcyB0aGUgaW5mb3JtYXRpb24gYWJvdXQgdGhl" +
           "IGVuZ2luZWVyaW5nIHVuaXRzIG9mIHRoZSBBcnJheUl0ZW0uVmFsdWUuAC4AROEbAAABAHcD/////wEB" +
           "/////wAAAAA1YIkKAgAAAAEABQAAAHRpdGxlAQHiGwMAAAAAfQAAAEhvbGRzIHRoZSB1c2VyIHJlYWRh" +
           "YmxlIEFycmF5SXRlbS5WYWx1ZSB0aXRsZSwgdXNlZnVsIHdoZW4gdGhlIHVuaXRzIGFyZSAlLCB0aGUg" +
           "dGl0bGUgbWF5IGJlIOKAnFBhcnRpY2xlIHNpemUgZGlzdHJpYnV0aW9u4oCdAC4AROIbAAAAFf////8B" +
           "Af////8AAAAANWCJCgIAAAABAA0AAABheGlzU2NhbGVUeXBlAQHjGwMAAAAAJQAAAExpbmVhciwgbG9n" +
           "LCBsbiwgZGVmaW5lZCBieSBBeGlzU3RlcHMALgBE4xsAAAEBvQv/////AQH/////AAAAADVgiQoCAAAA" +
           "AQAGAAAAT2Zmc2V0AQHkGwMAAAAAhAAAAERpZmZlcmVuY2UgaW4gMTAwIG5hbm9zZWNvbmQgaW50ZXJ2" +
           "YWxzIGJldHdlZW4gdGhlIHNvdXJjZVRpbWVzdGFtcCBhbmQgdGhlIHRpbWUgd2hlbiB0aGUgc2FtcGxl" +
           "IG1hdGVyaWFsIHdhcyB0YWtlbiBmcm9tIHRoZSBwcm9jZXNzLgAuAETkGwAAAQAiAf////8BAf////8A" +
           "AAAA";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// Defines the ArrayItem.Value range that can be returned by the analyser.
        /// </summary>
        public PropertyState<Range> InstrumentRange
        {
            get
            { 
                return m_instrumentRange;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_instrumentRange, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_instrumentRange = value;
            }
        }

        /// <summary>
        /// Holds the information about the engineering units of the ArrayItem.Value.
        /// </summary>
        public PropertyState<Range> EURange
        {
            get
            { 
                return m_eURange;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_eURange, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_eURange = value;
            }
        }

        /// <summary>
        /// Holds the information about the engineering units of the ArrayItem.Value.
        /// </summary>
        public PropertyState<EUInformation> EngineeringUnits
        {
            get
            { 
                return m_engineeringUnits;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_engineeringUnits, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_engineeringUnits = value;
            }
        }

        /// <summary>
        /// Holds the user readable ArrayItem.Value title, useful when the units are %, the title may be “Particle size distribution”
        /// </summary>
        public PropertyState<LocalizedText> title
        {
            get
            { 
                return m_title;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_title, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_title = value;
            }
        }

        /// <summary>
        /// Linear, log, ln, defined by AxisSteps
        /// </summary>
        public PropertyState<AxisScaleEnumeration> axisScaleType
        {
            get
            { 
                return m_axisScaleType;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_axisScaleType, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_axisScaleType = value;
            }
        }

        /// <summary>
        /// Difference in 100 nanosecond intervals between the sourceTimestamp and the time when the sample material was taken from the process.
        /// </summary>
        public PropertyState<double> Offset
        {
            get
            { 
                return m_offset;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_offset, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_offset = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_instrumentRange != null)
            {
                children.Add(m_instrumentRange);
            }

            if (m_eURange != null)
            {
                children.Add(m_eURange);
            }

            if (m_engineeringUnits != null)
            {
                children.Add(m_engineeringUnits);
            }

            if (m_title != null)
            {
                children.Add(m_title);
            }

            if (m_axisScaleType != null)
            {
                children.Add(m_axisScaleType);
            }

            if (m_offset != null)
            {
                children.Add(m_offset);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.InstrumentRange:
                {
                    if (createOrReplace)
                    {
                        if (InstrumentRange == null)
                        {
                            if (replacement == null)
                            {
                                InstrumentRange = new PropertyState<Range>(this);
                            }
                            else
                            {
                                InstrumentRange = (PropertyState<Range>)replacement;
                            }
                        }
                    }

                    instance = InstrumentRange;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EURange:
                {
                    if (createOrReplace)
                    {
                        if (EURange == null)
                        {
                            if (replacement == null)
                            {
                                EURange = new PropertyState<Range>(this);
                            }
                            else
                            {
                                EURange = (PropertyState<Range>)replacement;
                            }
                        }
                    }

                    instance = EURange;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.EngineeringUnits:
                {
                    if (createOrReplace)
                    {
                        if (EngineeringUnits == null)
                        {
                            if (replacement == null)
                            {
                                EngineeringUnits = new PropertyState<EUInformation>(this);
                            }
                            else
                            {
                                EngineeringUnits = (PropertyState<EUInformation>)replacement;
                            }
                        }
                    }

                    instance = EngineeringUnits;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.title:
                {
                    if (createOrReplace)
                    {
                        if (title == null)
                        {
                            if (replacement == null)
                            {
                                title = new PropertyState<LocalizedText>(this);
                            }
                            else
                            {
                                title = (PropertyState<LocalizedText>)replacement;
                            }
                        }
                    }

                    instance = title;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.axisScaleType:
                {
                    if (createOrReplace)
                    {
                        if (axisScaleType == null)
                        {
                            if (replacement == null)
                            {
                                axisScaleType = new PropertyState<AxisScaleEnumeration>(this);
                            }
                            else
                            {
                                axisScaleType = (PropertyState<AxisScaleEnumeration>)replacement;
                            }
                        }
                    }

                    instance = axisScaleType;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.Offset:
                {
                    if (createOrReplace)
                    {
                        if (Offset == null)
                        {
                            if (replacement == null)
                            {
                                Offset = new PropertyState<double>(this);
                            }
                            else
                            {
                                Offset = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Offset;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<Range> m_instrumentRange;
        private PropertyState<Range> m_eURange;
        private PropertyState<EUInformation> m_engineeringUnits;
        private PropertyState<LocalizedText> m_title;
        private PropertyState<AxisScaleEnumeration> m_axisScaleType;
        private PropertyState<double> m_offset;
        #endregion
    }

    #region ArrayItemState<T> Class
    /// <summary>
    /// A typed version of the ArrayItemType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class ArrayItemState<T> : ArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public ArrayItemState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region YArrayItemState Class
    #if (!OPCUA_EXCLUDE_YArrayItemState)
    /// <summary>
    /// Stores an instance of the YArrayItemType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class YArrayItemState : ArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public YArrayItemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.YArrayItemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVgiQACAAAAAQAWAAAAWUFycmF5SXRlbVR5cGVJbnN0YW5jZQEB0gcB" +
           "AdIHABj/////AQH/////BQAAADVgiQoCAAAAAQAHAAAARVVSYW5nZQEB6BsDAAAAAEkAAABIb2xkcyB0" +
           "aGUgaW5mb3JtYXRpb24gYWJvdXQgdGhlIGVuZ2luZWVyaW5nIHVuaXRzIG9mIHRoZSBBcnJheUl0ZW0u" +
           "VmFsdWUuAC4AROgbAAABAHQD/////wEB/////wAAAAA1YIkKAgAAAAEAEAAAAEVuZ2luZWVyaW5nVW5p" +
           "dHMBAekbAwAAAABJAAAASG9sZHMgdGhlIGluZm9ybWF0aW9uIGFib3V0IHRoZSBlbmdpbmVlcmluZyB1" +
           "bml0cyBvZiB0aGUgQXJyYXlJdGVtLlZhbHVlLgAuAETpGwAAAQB3A/////8BAf////8AAAAANWCJCgIA" +
           "AAABAAUAAAB0aXRsZQEB6hsDAAAAAH0AAABIb2xkcyB0aGUgdXNlciByZWFkYWJsZSBBcnJheUl0ZW0u" +
           "VmFsdWUgdGl0bGUsIHVzZWZ1bCB3aGVuIHRoZSB1bml0cyBhcmUgJSwgdGhlIHRpdGxlIG1heSBiZSDi" +
           "gJxQYXJ0aWNsZSBzaXplIGRpc3RyaWJ1dGlvbuKAnQAuAETqGwAAABX/////AQH/////AAAAADVgiQoC" +
           "AAAAAQANAAAAYXhpc1NjYWxlVHlwZQEB6xsDAAAAACUAAABMaW5lYXIsIGxvZywgbG4sIGRlZmluZWQg" +
           "YnkgQXhpc1N0ZXBzAC4AROsbAAABAb0L/////wEB/////wAAAAA1YIkKAgAAAAEADwAAAHhBeGlzRGVm" +
           "aW5pdGlvbgEB7RsDAAAAAEsAAABIb2xkcyB0aGUgaW5mb3JtYXRpb24gYWJvdXQgdGhlIGVuZ2luZWVy" +
           "aW5nIHVuaXRzIGFuZCByYW5nZSBmb3IgdGhlIFgtQXhpcy4ALgBE7RsAAAEBvAv/////AQH/////AAAA" +
           "AA==";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// Holds the information about the engineering units and range for the X-Axis.
        /// </summary>
        public PropertyState<AxisInformation> xAxisDefinition
        {
            get
            { 
                return m_xAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_xAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_xAxisDefinition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_xAxisDefinition != null)
            {
                children.Add(m_xAxisDefinition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.xAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (xAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                xAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                xAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = xAxisDefinition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<AxisInformation> m_xAxisDefinition;
        #endregion
    }

    #region YArrayItemState<T> Class
    /// <summary>
    /// A typed version of the YArrayItemType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class YArrayItemState<T> : YArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public YArrayItemState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region XYArrayItemState Class
    #if (!OPCUA_EXCLUDE_XYArrayItemState)
    /// <summary>
    /// Stores an instance of the XYArrayItemType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class XYArrayItemState : ArrayItemState<XVType>
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public XYArrayItemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.XYArrayItemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.DataTypes.XVType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVggQACAAAAAQAXAAAAWFlBcnJheUl0ZW1UeXBlSW5zdGFuY2UBAdMH" +
           "AQHTBwEBvgsBAf////8FAAAANWCJCgIAAAABAAcAAABFVVJhbmdlAQHxGwMAAAAASQAAAEhvbGRzIHRo" +
           "ZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJpbmcgdW5pdHMgb2YgdGhlIEFycmF5SXRlbS5W" +
           "YWx1ZS4ALgBE8RsAAAEAdAP/////AQH/////AAAAADVgiQoCAAAAAQAQAAAARW5naW5lZXJpbmdVbml0" +
           "cwEB8hsDAAAAAEkAAABIb2xkcyB0aGUgaW5mb3JtYXRpb24gYWJvdXQgdGhlIGVuZ2luZWVyaW5nIHVu" +
           "aXRzIG9mIHRoZSBBcnJheUl0ZW0uVmFsdWUuAC4ARPIbAAABAHcD/////wEB/////wAAAAA1YIkKAgAA" +
           "AAEABQAAAHRpdGxlAQHzGwMAAAAAfQAAAEhvbGRzIHRoZSB1c2VyIHJlYWRhYmxlIEFycmF5SXRlbS5W" +
           "YWx1ZSB0aXRsZSwgdXNlZnVsIHdoZW4gdGhlIHVuaXRzIGFyZSAlLCB0aGUgdGl0bGUgbWF5IGJlIOKA" +
           "nFBhcnRpY2xlIHNpemUgZGlzdHJpYnV0aW9u4oCdAC4ARPMbAAAAFf////8BAf////8AAAAANWCJCgIA" +
           "AAABAA0AAABheGlzU2NhbGVUeXBlAQH0GwMAAAAAJQAAAExpbmVhciwgbG9nLCBsbiwgZGVmaW5lZCBi" +
           "eSBBeGlzU3RlcHMALgBE9BsAAAEBvQv/////AQH/////AAAAADVgiQoCAAAAAQAPAAAAeEF4aXNEZWZp" +
           "bml0aW9uAQH2GwMAAAAASwAAAEhvbGRzIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJp" +
           "bmcgdW5pdHMgYW5kIHJhbmdlIGZvciB0aGUgWC1BeGlzLgAuAET2GwAAAQG8C/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// Holds the information about the engineering units and range for the X-Axis.
        /// </summary>
        public PropertyState<AxisInformation> xAxisDefinition
        {
            get
            { 
                return m_xAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_xAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_xAxisDefinition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_xAxisDefinition != null)
            {
                children.Add(m_xAxisDefinition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.xAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (xAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                xAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                xAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = xAxisDefinition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<AxisInformation> m_xAxisDefinition;
        #endregion
    }
    #endif
    #endregion

    #region ImageItemState Class
    #if (!OPCUA_EXCLUDE_ImageItemState)
    /// <summary>
    /// Stores an instance of the ImageItemType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ImageItemState : ArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ImageItemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.ImageItemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVgiQACAAAAAQAVAAAASW1hZ2VJdGVtVHlwZUluc3RhbmNlAQHUBwEB" +
           "1AcAGP////8BAf////8GAAAANWCJCgIAAAABAAcAAABFVVJhbmdlAQH6GwMAAAAASQAAAEhvbGRzIHRo" +
           "ZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJpbmcgdW5pdHMgb2YgdGhlIEFycmF5SXRlbS5W" +
           "YWx1ZS4ALgBE+hsAAAEAdAP/////AQH/////AAAAADVgiQoCAAAAAQAQAAAARW5naW5lZXJpbmdVbml0" +
           "cwEB+xsDAAAAAEkAAABIb2xkcyB0aGUgaW5mb3JtYXRpb24gYWJvdXQgdGhlIGVuZ2luZWVyaW5nIHVu" +
           "aXRzIG9mIHRoZSBBcnJheUl0ZW0uVmFsdWUuAC4ARPsbAAABAHcD/////wEB/////wAAAAA1YIkKAgAA" +
           "AAEABQAAAHRpdGxlAQH8GwMAAAAAfQAAAEhvbGRzIHRoZSB1c2VyIHJlYWRhYmxlIEFycmF5SXRlbS5W" +
           "YWx1ZSB0aXRsZSwgdXNlZnVsIHdoZW4gdGhlIHVuaXRzIGFyZSAlLCB0aGUgdGl0bGUgbWF5IGJlIOKA" +
           "nFBhcnRpY2xlIHNpemUgZGlzdHJpYnV0aW9u4oCdAC4ARPwbAAAAFf////8BAf////8AAAAANWCJCgIA" +
           "AAABAA0AAABheGlzU2NhbGVUeXBlAQH9GwMAAAAAJQAAAExpbmVhciwgbG9nLCBsbiwgZGVmaW5lZCBi" +
           "eSBBeGlzU3RlcHMALgBE/RsAAAEBvQv/////AQH/////AAAAADVgiQoCAAAAAQAPAAAAeEF4aXNEZWZp" +
           "bml0aW9uAQH/GwMAAAAASwAAAEhvbGRzIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJp" +
           "bmcgdW5pdHMgYW5kIHJhbmdlIGZvciB0aGUgWC1BeGlzLgAuAET/GwAAAQG8C/////8BAf////8AAAAA" +
           "NWCJCgIAAAABAA8AAAB5QXhpc0RlZmluaXRpb24BAQAcAwAAAABLAAAASG9sZHMgdGhlIGluZm9ybWF0" +
           "aW9uIGFib3V0IHRoZSBlbmdpbmVlcmluZyB1bml0cyBhbmQgcmFuZ2UgZm9yIHRoZSBZLUF4aXMuAC4A" +
           "RAAcAAABAbwL/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// Holds the information about the engineering units and range for the X-Axis.
        /// </summary>
        public PropertyState<AxisInformation> xAxisDefinition
        {
            get
            { 
                return m_xAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_xAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_xAxisDefinition = value;
            }
        }

        /// <summary>
        /// Holds the information about the engineering units and range for the Y-Axis.
        /// </summary>
        public PropertyState<AxisInformation> yAxisDefinition
        {
            get
            { 
                return m_yAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_yAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_yAxisDefinition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_xAxisDefinition != null)
            {
                children.Add(m_xAxisDefinition);
            }

            if (m_yAxisDefinition != null)
            {
                children.Add(m_yAxisDefinition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.xAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (xAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                xAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                xAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = xAxisDefinition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.yAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (yAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                yAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                yAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = yAxisDefinition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<AxisInformation> m_xAxisDefinition;
        private PropertyState<AxisInformation> m_yAxisDefinition;
        #endregion
    }

    #region ImageItemState<T> Class
    /// <summary>
    /// A typed version of the ImageItemType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class ImageItemState<T> : ImageItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public ImageItemState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region CubeItemState Class
    #if (!OPCUA_EXCLUDE_CubeItemState)
    /// <summary>
    /// Stores an instance of the CubeItemType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CubeItemState : ArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CubeItemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.CubeItemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVgiQACAAAAAQAUAAAAQ3ViZUl0ZW1UeXBlSW5zdGFuY2UBAdUHAQHV" +
           "BwAY/////wEB/////wcAAAA1YIkKAgAAAAEABwAAAEVVUmFuZ2UBAQQcAwAAAABJAAAASG9sZHMgdGhl" +
           "IGluZm9ybWF0aW9uIGFib3V0IHRoZSBlbmdpbmVlcmluZyB1bml0cyBvZiB0aGUgQXJyYXlJdGVtLlZh" +
           "bHVlLgAuAEQEHAAAAQB0A/////8BAf////8AAAAANWCJCgIAAAABABAAAABFbmdpbmVlcmluZ1VuaXRz" +
           "AQEFHAMAAAAASQAAAEhvbGRzIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJpbmcgdW5p" +
           "dHMgb2YgdGhlIEFycmF5SXRlbS5WYWx1ZS4ALgBEBRwAAAEAdwP/////AQH/////AAAAADVgiQoCAAAA" +
           "AQAFAAAAdGl0bGUBAQYcAwAAAAB9AAAASG9sZHMgdGhlIHVzZXIgcmVhZGFibGUgQXJyYXlJdGVtLlZh" +
           "bHVlIHRpdGxlLCB1c2VmdWwgd2hlbiB0aGUgdW5pdHMgYXJlICUsIHRoZSB0aXRsZSBtYXkgYmUg4oCc" +
           "UGFydGljbGUgc2l6ZSBkaXN0cmlidXRpb27igJ0ALgBEBhwAAAAV/////wEB/////wAAAAA1YIkKAgAA" +
           "AAEADQAAAGF4aXNTY2FsZVR5cGUBAQccAwAAAAAlAAAATGluZWFyLCBsb2csIGxuLCBkZWZpbmVkIGJ5" +
           "IEF4aXNTdGVwcwAuAEQHHAAAAQG9C/////8BAf////8AAAAANWCJCgIAAAABAA8AAAB4QXhpc0RlZmlu" +
           "aXRpb24BAQkcAwAAAABLAAAASG9sZHMgdGhlIGluZm9ybWF0aW9uIGFib3V0IHRoZSBlbmdpbmVlcmlu" +
           "ZyB1bml0cyBhbmQgcmFuZ2UgZm9yIHRoZSBYLUF4aXMuAC4ARAkcAAABAbwL/////wEB/////wAAAAA1" +
           "YIkKAgAAAAEADwAAAHlBeGlzRGVmaW5pdGlvbgEBChwDAAAAAEsAAABIb2xkcyB0aGUgaW5mb3JtYXRp" +
           "b24gYWJvdXQgdGhlIGVuZ2luZWVyaW5nIHVuaXRzIGFuZCByYW5nZSBmb3IgdGhlIFktQXhpcy4ALgBE" +
           "ChwAAAEBvAv/////AQH/////AAAAADVgiQoCAAAAAQAPAAAAekF4aXNEZWZpbml0aW9uAQELHAMAAAAA" +
           "SwAAAEhvbGRzIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUgZW5naW5lZXJpbmcgdW5pdHMgYW5kIHJh" +
           "bmdlIGZvciB0aGUgWi1BeGlzLgAuAEQLHAAAAQG8C/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// Holds the information about the engineering units and range for the X-Axis.
        /// </summary>
        public PropertyState<AxisInformation> xAxisDefinition
        {
            get
            { 
                return m_xAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_xAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_xAxisDefinition = value;
            }
        }

        /// <summary>
        /// Holds the information about the engineering units and range for the Y-Axis.
        /// </summary>
        public PropertyState<AxisInformation> yAxisDefinition
        {
            get
            { 
                return m_yAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_yAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_yAxisDefinition = value;
            }
        }

        /// <summary>
        /// Holds the information about the engineering units and range for the Z-Axis.
        /// </summary>
        public PropertyState<AxisInformation> zAxisDefinition
        {
            get
            { 
                return m_zAxisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_zAxisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_zAxisDefinition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_xAxisDefinition != null)
            {
                children.Add(m_xAxisDefinition);
            }

            if (m_yAxisDefinition != null)
            {
                children.Add(m_yAxisDefinition);
            }

            if (m_zAxisDefinition != null)
            {
                children.Add(m_zAxisDefinition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.xAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (xAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                xAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                xAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = xAxisDefinition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.yAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (yAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                yAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                yAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = yAxisDefinition;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.zAxisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (zAxisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                zAxisDefinition = new PropertyState<AxisInformation>(this);
                            }
                            else
                            {
                                zAxisDefinition = (PropertyState<AxisInformation>)replacement;
                            }
                        }
                    }

                    instance = zAxisDefinition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<AxisInformation> m_xAxisDefinition;
        private PropertyState<AxisInformation> m_yAxisDefinition;
        private PropertyState<AxisInformation> m_zAxisDefinition;
        #endregion
    }

    #region CubeItemState<T> Class
    /// <summary>
    /// A typed version of the CubeItemType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class CubeItemState<T> : CubeItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public CubeItemState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region NDimensionArrayItemState Class
    #if (!OPCUA_EXCLUDE_NDimensionArrayItemState)
    /// <summary>
    /// Stores an instance of the NDimensionArrayItemType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class NDimensionArrayItemState : ArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public NDimensionArrayItemState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.NDimensionArrayItemType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVgiQACAAAAAQAfAAAATkRpbWVuc2lvbkFycmF5SXRlbVR5cGVJbnN0" +
           "YW5jZQEB1gcBAdYHABj/////AQH/////BQAAADVgiQoCAAAAAQAHAAAARVVSYW5nZQEBDxwDAAAAAEkA" +
           "AABIb2xkcyB0aGUgaW5mb3JtYXRpb24gYWJvdXQgdGhlIGVuZ2luZWVyaW5nIHVuaXRzIG9mIHRoZSBB" +
           "cnJheUl0ZW0uVmFsdWUuAC4ARA8cAAABAHQD/////wEB/////wAAAAA1YIkKAgAAAAEAEAAAAEVuZ2lu" +
           "ZWVyaW5nVW5pdHMBARAcAwAAAABJAAAASG9sZHMgdGhlIGluZm9ybWF0aW9uIGFib3V0IHRoZSBlbmdp" +
           "bmVlcmluZyB1bml0cyBvZiB0aGUgQXJyYXlJdGVtLlZhbHVlLgAuAEQQHAAAAQB3A/////8BAf////8A" +
           "AAAANWCJCgIAAAABAAUAAAB0aXRsZQEBERwDAAAAAH0AAABIb2xkcyB0aGUgdXNlciByZWFkYWJsZSBB" +
           "cnJheUl0ZW0uVmFsdWUgdGl0bGUsIHVzZWZ1bCB3aGVuIHRoZSB1bml0cyBhcmUgJSwgdGhlIHRpdGxl" +
           "IG1heSBiZSDigJxQYXJ0aWNsZSBzaXplIGRpc3RyaWJ1dGlvbuKAnQAuAEQRHAAAABX/////AQH/////" +
           "AAAAADVgiQoCAAAAAQANAAAAYXhpc1NjYWxlVHlwZQEBEhwDAAAAACUAAABMaW5lYXIsIGxvZywgbG4s" +
           "IGRlZmluZWQgYnkgQXhpc1N0ZXBzAC4ARBIcAAABAb0L/////wEB/////wAAAAA1YIkKAgAAAAEADgAA" +
           "AGF4aXNEZWZpbml0aW9uAQEUHAMAAAAASQAAAEhvbGRzIHRoZSBpbmZvcm1hdGlvbiBhYm91dCB0aGUg" +
           "ZW5naW5lZXJpbmcgdW5pdHMgYW5kIHJhbmdlIGZvciBhbGwgYXhpcy4ALgBEFBwAAAEBvAsBAAAAAQH/" +
           "////AAAAAA==";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// Holds the information about the engineering units and range for all axis.
        /// </summary>
        public PropertyState<AxisInformation[]> axisDefinition
        {
            get
            { 
                return m_axisDefinition;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_axisDefinition, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_axisDefinition = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_axisDefinition != null)
            {
                children.Add(m_axisDefinition);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.axisDefinition:
                {
                    if (createOrReplace)
                    {
                        if (axisDefinition == null)
                        {
                            if (replacement == null)
                            {
                                axisDefinition = new PropertyState<AxisInformation[]>(this);
                            }
                            else
                            {
                                axisDefinition = (PropertyState<AxisInformation[]>)replacement;
                            }
                        }
                    }

                    instance = axisDefinition;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<AxisInformation[]> m_axisDefinition;
        #endregion
    }

    #region NDimensionArrayItemState<T> Class
    /// <summary>
    /// A typed version of the NDimensionArrayItemType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class NDimensionArrayItemState<T> : NDimensionArrayItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public NDimensionArrayItemState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region EngineeringValueState Class
    #if (!OPCUA_EXCLUDE_EngineeringValueState)
    /// <summary>
    /// Stores an instance of the EngineeringValueType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class EngineeringValueState : DataItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public EngineeringValueState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.EngineeringValueType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVggQACAAAAAQAcAAAARW5naW5lZXJpbmdWYWx1ZVR5cGVJbnN0YW5j" +
           "ZQEBpCQBAaQkABgBAf////8AAAAA";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// A description for the <Identifier> Variable.
        /// </summary>
        public DataItemState Identifier
        {
            get
            { 
                return m_identifier;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_identifier, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_identifier = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_identifier != null)
            {
                children.Add(m_identifier);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private DataItemState m_identifier;
        #endregion
    }

    #region EngineeringValueState<T> Class
    /// <summary>
    /// A typed version of the EngineeringValueType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class EngineeringValueState<T> : EngineeringValueState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public EngineeringValueState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion

    #region ChemometricModelState Class
    #if (!OPCUA_EXCLUDE_ChemometricModelState)
    /// <summary>
    /// Stores an instance of the ChemometricModelType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ChemometricModelState : BaseDataVariableState<byte[]>
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ChemometricModelState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.ChemometricModelType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.ByteString, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVggQACAAAAAQAcAAAAQ2hlbW9tZXRyaWNNb2RlbFR5cGVJbnN0YW5j" +
           "ZQEB1wcBAdcHAA8BAf////8DAAAAFWCJCgIAAAABAAQAAABOYW1lAQEVHAAuAEQVHAAAABX/////AQH/" +
           "////AAAAABVgiQoCAAAAAQAMAAAAQ3JlYXRpb25EYXRlAQEWHAAuAEQWHAAAAA3/////AQH/////AAAA" +
           "ABVgiQoCAAAAAQAQAAAATW9kZWxEZXNjcmlwdGlvbgEBFxwALgBEFxwAAAAV/////wEB/////wAAAAA=";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        /// <summary>
        /// A description for the Name Property.
        /// </summary>
        public PropertyState<LocalizedText> Name
        {
            get
            { 
                return m_name;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the CreationDate Property.
        /// </summary>
        public PropertyState<DateTime> CreationDate
        {
            get
            { 
                return m_creationDate;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_creationDate, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_creationDate = value;
            }
        }

        /// <summary>
        /// A description for the ModelDescription Property.
        /// </summary>
        public PropertyState<LocalizedText> ModelDescription
        {
            get
            { 
                return m_modelDescription;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_modelDescription, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_modelDescription = value;
            }
        }

        /// <summary>
        /// A description for the <User defined Input#> Variable.
        /// </summary>
        public BaseVariableState User_defined_Input
        {
            get
            { 
                return m_user_defined_Input;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_user_defined_Input, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_user_defined_Input = value;
            }
        }

        /// <summary>
        /// A description for the <User defined Output#> Variable.
        /// </summary>
        public BaseVariableState User_defined_Output
        {
            get
            { 
                return m_user_defined_Output;  
            }
            
            set
            {
                if (!Object.ReferenceEquals(m_user_defined_Output, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_user_defined_Output = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_creationDate != null)
            {
                children.Add(m_creationDate);
            }

            if (m_modelDescription != null)
            {
                children.Add(m_modelDescription);
            }

            if (m_user_defined_Input != null)
            {
                children.Add(m_user_defined_Input);
            }

            if (m_user_defined_Output != null)
            {
                children.Add(m_user_defined_Output);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Opc.Ua.Adi.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<LocalizedText>(this);
                            }
                            else
                            {
                                Name = (PropertyState<LocalizedText>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.CreationDate:
                {
                    if (createOrReplace)
                    {
                        if (CreationDate == null)
                        {
                            if (replacement == null)
                            {
                                CreationDate = new PropertyState<DateTime>(this);
                            }
                            else
                            {
                                CreationDate = (PropertyState<DateTime>)replacement;
                            }
                        }
                    }

                    instance = CreationDate;
                    break;
                }

                case Opc.Ua.Adi.BrowseNames.ModelDescription:
                {
                    if (createOrReplace)
                    {
                        if (ModelDescription == null)
                        {
                            if (replacement == null)
                            {
                                ModelDescription = new PropertyState<LocalizedText>(this);
                            }
                            else
                            {
                                ModelDescription = (PropertyState<LocalizedText>)replacement;
                            }
                        }
                    }

                    instance = ModelDescription;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion
            
        #region Private Fields
        private PropertyState<LocalizedText> m_name;
        private PropertyState<DateTime> m_creationDate;
        private PropertyState<LocalizedText> m_modelDescription;
        private BaseVariableState m_user_defined_Input;
        private BaseVariableState m_user_defined_Output;
        #endregion
    }
    #endif
    #endregion

    #region ProcessVariableState Class
    #if (!OPCUA_EXCLUDE_ProcessVariableState)
    /// <summary>
    /// Stores an instance of the ProcessVariableType VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class ProcessVariableState : DataItemState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public ProcessVariableState(NodeState parent) : base(parent)
        {
        }
        
        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.Adi.VariableTypes.ProcessVariableType, Opc.Ua.Adi.Namespaces.OpcUaAdi, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Opc.Ua.DataTypes.BaseDataType, Opc.Ua.Namespaces.OpcUa, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }
        
        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString = 
           "AgAAACAAAABodHRwOi8vb3BjZm91bmRhdGlvbi5vcmcvVUEvQURJLx8AAABodHRwOi8vb3BjZm91bmRh" +
           "dGlvbi5vcmcvVUEvREkv/////xVggQACAAAAAQAbAAAAUHJvY2Vzc1ZhcmlhYmxlVHlwZUluc3RhbmNl" +
           "AQHYBwEB2AcAGAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion
            
        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion
            
        #region Private Fields
        #endregion
    }

    #region ProcessVariableState<T> Class
    /// <summary>
    /// A typed version of the ProcessVariableType variable.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public class ProcessVariableState<T> : ProcessVariableState
    {
        #region Constructors
        /// <summary>
        /// Initializes the instance with its defalt attribute values.
        /// </summary>
        public ProcessVariableState(NodeState parent) : base(parent)
        {
            Value = default(T);
        }

        /// <summary>
        /// Initializes the instance with the default values.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);

            Value = default(T);
            DataType = TypeInfo.GetDataTypeId(typeof(T));
            ValueRank = TypeInfo.GetValueRank(typeof(T));
        }
        #endregion

        #region Public Members
        /// <summary>
        /// The value of the variable.
        /// </summary>
        public new T Value
        {
            get
            {
                return CheckTypeBeforeCast<T>(base.Value, true);
            }

            set 
            { 
                base.Value = value; 
            }
        }
        #endregion
    }
    #endregion
    #endif
    #endregion
}