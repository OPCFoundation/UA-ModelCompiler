using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using Opc.Ua;
using Opc.Ua.UANodeSet;
using Newtonsoft.Json;

namespace NodeSetTests
{
    static class Program
    {
        const string Input = @"D:\Work\OPC\nodesets\master\Provisioning\Opc.Ua.Provisioning.NodeSet2.xml";
        const string Output = @"D:\Work\OPC\nodesets\master\Provisioning\Opc.Ua.Provisioning.NodeSet2.json";

        static void Main(string[] args)
        {
            // new JsonNodeSetSerializer().XmlToJson(Input, Output);

            /*
            var nodeset = convertor.Convert(input);

            ServiceMessageContext context = new ServiceMessageContext();
            context.NamespaceUris = convertor.SystemContext.NamespaceUris;
            context.ServerUris = convertor.SystemContext.ServerUris;
            context.Factory = convertor.SystemContext.EncodeableFactory;

            using (Stream istrm = File.Open(@"D:\Work\OPC\nodesets\master\Provisioning\Opc.Ua.Provisioning.NodeSet2.json", FileMode.Create))
            {
                using (JsonEncoder encoder = new JsonEncoder(context, false, new StreamWriter(istrm)))
                {
                    encoder.IncludeDefaultValues = false;
                    encoder.IncludeDefaultNumberValues = false;
                    nodeset.Encode(encoder);
                }
            }
            */
        }
    }
}
