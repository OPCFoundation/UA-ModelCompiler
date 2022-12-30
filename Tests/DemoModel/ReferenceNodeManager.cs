using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Opc.Ua;
using Opc.Ua.Server;

namespace ModelCompiler
{
    public class ReferenceNodeManager : CustomNodeManager2
    {
        #region Private Fields
        private ushort m_namespaceIndex;
        private long m_lastUsedId;
        #endregion

        static readonly string[] ModelNamespaceUris = new string[]
        {
            DemoModel.Namespaces.DemoModel
        };

        #region Constructors
        /// <summary>
        /// Initializes the node manager.
        /// </summary>
        public ReferenceNodeManager(IServerInternal server, ApplicationConfiguration configuration)
            : base(server, ModelNamespaceUris)
        {
            SystemContext.NodeIdFactory = this;

            foreach (var uri in ModelNamespaceUris)
            {
                Server.NamespaceUris.GetIndexOrAppend(uri);
            }

            m_namespaceIndex = (ushort)Server.NamespaceUris.GetIndex(ModelNamespaceUris[0]);

            Server.Factory.AddEncodeableTypes(
                typeof(ReferenceNodeManager).Assembly.GetExportedTypes()
                .Where(t => t.FullName.StartsWith(typeof(ReferenceNodeManager).Namespace))
            );
            
            m_lastUsedId = 0;
        }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // TBD
            }
            base.Dispose(disposing);
        }
        #endregion

        #region INodeIdFactory Members
        public override NodeId New(ISystemContext context, NodeState node)
        {
            uint id = Utils.IncrementIdentifier(ref m_lastUsedId);
            return new NodeId(id, m_namespaceIndex);
        }
        #endregion

        #region INodeManager Members
        public override void CreateAddressSpace(IDictionary<NodeId, IList<IReference>> externalReferences)
        {
            lock (Lock)
            {
                IList<IReference> references = null;

                if (!externalReferences.TryGetValue(ObjectIds.ObjectsFolder, out references))
                {
                    externalReferences[ObjectIds.ObjectsFolder] = references = new List<IReference>();
                }

                LoadPredefinedNodes(SystemContext, externalReferences);
            }
        }

        protected override NodeStateCollection LoadPredefinedNodes(ISystemContext context)
        {
            NodeStateCollection predefinedNodes = new NodeStateCollection();

            foreach (var name in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (name.EndsWith(".uanodes"))
                {
                    predefinedNodes.LoadFromBinaryResource(context, name, Assembly.GetExecutingAssembly(), true);
                }
            }

            return predefinedNodes;
        }
        #endregion
    }
}
