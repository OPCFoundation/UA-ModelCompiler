/* ========================================================================
 * Copyright (c) 2005-2011 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community License ("RCL") Version 1.00
 *
 * Unless explicitly acquired and licensed from Licensor under another
 * license, the contents of this file are subject to the Reciprocal
 * Community License ("RCL") Version 1.00, or subsequent versions
 * as allowed by the RCL, and You may not copy or use this file in either
 * source code or executable form, except in compliance with the terms and
 * conditions of the RCL.
 *
 * All software distributed under the RCL is provided strictly on an
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED,
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCL for specific
 * language governing rights and limitations under the RCL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCL/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;

#pragma warning disable 0618

namespace Opc.Ua
{
    /// <summary>
    /// A class that instantiates nodes based on their type definition.
    /// </summary>
    [Obsolete("The NodeFactory class is obsolete and is not supported.")]
    public class NodeFactory
    {
        #region Constructors
        /// <summary>
        /// Initializes the factory with a table of nodes in the address space.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        public NodeFactory(INodeTable nodes)
        {
            m_nodes = nodes;
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Applies the modelling rules to the instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="typeDefinitionId">The type definition identifier.</param>
        /// <param name="counter">The counter.</param>
        /// <param name="namespaceIndex">Index of the namespace.</param>
        /// <returns></returns>
        public IList<ILocalNode> ApplyModellingRules(
            ILocalNode instance,
            NodeId     typeDefinitionId,
            ref long   counter,
            ushort     namespaceIndex)
        {
            InstanceDeclarationHierarchy hierarchy = new InstanceDeclarationHierarchy();

            GetInstanceHierarchyForType(typeDefinitionId, hierarchy);

            UpdateInstanceHierarchyWithInstance(instance.NodeId, hierarchy);

            return InstantiateHierarchy(instance, hierarchy, ref counter, namespaceIndex);
        }
        #endregion

        #region Protected Members
        /// <summary>
        /// Returns the creation rule for the modelling rule.
        /// </summary>
        /// <param name="modellingRule">The modelling rule.</param>
        /// <returns>The creation rule for the modelling rule.</returns>
        private static CreationRule GetCreationRule(NodeId modellingRule)
        {
            if (modellingRule == Objects.ModellingRule_Mandatory || modellingRule == Objects.ModellingRule_Optional)
            {
                return CreationRule.New;
            }

            if (modellingRule == Objects.ModellingRule_MandatoryShared)
            {
                return CreationRule.Shared;
            }

            if (modellingRule == Objects.ModellingRule_ExposesItsArray)
            {
                return CreationRule.Any;
            }

            return CreationRule.None;
        }

        /// <summary>
        /// Returns the naming rule for the modelling rule.
        /// </summary>
        /// <param name="modellingRule">The modelling rule.</param>
        /// <returns>The naming rule for the modelling rule.</returns>
        protected virtual NamingRule GetNamingRule(NodeId modellingRule)
        {
            if (modellingRule == Objects.ModellingRule_Mandatory || modellingRule == Objects.ModellingRule_MandatoryShared)
            {
                return NamingRule.Unique;
            }

            if (modellingRule == Objects.ModellingRule_Optional)
            {
                return NamingRule.UniqueOptional;
            }

            return NamingRule.None;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Recursively updates a hierarchy with the nodes that already exist in an instance.
        /// </summary>
        /// <param name="instanceId">The instance identifier.</param>
        /// <param name="hierarchy">The hierarchy.</param>
        private void UpdateInstanceHierarchyWithInstance(
            ExpandedNodeId               instanceId,
            InstanceDeclarationHierarchy hierarchy)
        {
            // the instance must be local to the address space.
            ILocalNode instance = m_nodes.Find(instanceId) as ILocalNode;

            if (instance == null)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadNodeIdUnknown,
                    "The node is not in the local address space.\r\nNodeId = {0}",
                    instanceId);
            }

            // must be an object, variable or method.
            if ((instance.NodeClass & (NodeClass.Object | NodeClass.Variable | NodeClass.Method)) == 0)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadNodeClassInvalid,
                    "The instance node is not any Object, Variable or Method.\r\nNodeId = {0}\r\nNodeClass = {1}",
                    instanceId,
                    instance.NodeClass);
            }

            // find the root of the hierarchy.
            HierarchyBrowsePath root = null;

            if (!hierarchy.BrowsePaths.TryGetValue("/", out root))
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadUnexpectedError,
                    "The hierarchy does not have a root.\r\nHierarchy = {0}",
                    hierarchy);
            }

            // the instance type definition must match the hierarchy.
            if (instance.TypeDefinitionId != root.DeclarationId)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadTypeDefinitionInvalid,
                    "The instance node is not an instance of a {0} type.\r\nNodeId = {1}\r\nTypeDefinition = {2}",
                    root.DeclarationId,
                    instanceId,
                    instance.TypeDefinitionId);
            }

            // set the instance id for the root.
            root.InstanceId = instance.NodeId;

            // follow children.
            foreach (IReference reference in instance.References.Find(ReferenceTypeIds.HierarchicalReferences, false, true, m_nodes.TypeTree))
            {
                UpdateInstanceHierarchyWithInstance(root, reference.TargetId, hierarchy);
            }
        }

        /// <summary>
        /// Instantiates the hierarchy.
        /// </summary>
        private IList<ILocalNode> InstantiateHierarchy(
            ILocalNode                   root,
            InstanceDeclarationHierarchy hierarchy,
            ref long                     counter,
            ushort                       namespaceIndex)
        {
            List<ILocalNode> nodesToAdd = new List<ILocalNode>();
            List<HierarchyBrowsePath> nodesToUpdate = new List<HierarchyBrowsePath>();

            // create an instance for each browse path that does not already have one.
            foreach (HierarchyBrowsePath browsePath in hierarchy.BrowsePaths.Values)
            {
                bool updateReferences = browsePath.BrowsePath == "/";

                // find the instance.
                INode instance = m_nodes.Find(browsePath.InstanceId);

                if (instance == null)
                {
                    // do nothing if optional.
                    if (browsePath.IsOptional)
                    {
                        continue;
                    }

                    // find the declaration.
                    ILocalNode declaration = m_nodes.Find(browsePath.DeclarationId) as ILocalNode;

                    if (declaration == null)
                    {
                        continue;
                    }

                    instance = declaration;

                    // check the creation rule.
                    CreationRule creationRule = GetCreationRule(declaration.ModellingRule);

                    // create a new instance is the creation rule is new.
                    if (creationRule == CreationRule.New)
                    {
                        Node newNode = Node.Copy(declaration);
                        newNode.NodeId = new NodeId(Utils.IncrementIdentifier(ref counter), namespaceIndex);
                        instance = newNode;
                        nodesToAdd.Add(newNode);
                        updateReferences = true;
                    }
                }

                // update the browse path.
                browsePath.InstanceId = instance.NodeId;
                hierarchy.Instances[(NodeId)instance.NodeId] = instance;

                // check if instance can be traced back to root.
                if (!updateReferences)
                {
                    continue;
                }

                nodesToUpdate.Add(browsePath);
            }

            // create the references.
            foreach (HierarchyBrowsePath browsePath in nodesToUpdate)
            {
                if (browsePath.InstanceId != null)
                {
                    InstantiateReferences(browsePath, hierarchy);
                }
            }

            return nodesToAdd;
        }

        /// <summary>
        /// Recursively collects the nodes within a type hierarchy.
        /// </summary>
        private void UpdateInstanceHierarchyWithInstance(
            HierarchyBrowsePath          parent,
            ExpandedNodeId               instanceId,
            InstanceDeclarationHierarchy hierarchy)
        {
            INode instance = m_nodes.Find(instanceId) as INode;

            // ignore instances not in the address space.
            if (instance == null)
            {
                return;
            }

            // must be an object, variable or method.
            if ((instance.NodeClass & (NodeClass.Object | NodeClass.Variable | NodeClass.Method)) == 0)
            {
                return;
            }

            // construct the browse path that identifies the node.
            string browsePath = null;

            if (parent.BrowsePath == "/")
            {
                browsePath = Utils.Format("/{0}", instance.BrowseName);
            }
            else
            {
                browsePath = Utils.Format("{0}/{1}", parent.BrowsePath, instance.BrowseName);
            }

            // check if the browse path exists in the hierarchy.
            HierarchyBrowsePath child = null;

            if (!hierarchy.BrowsePaths.TryGetValue(browsePath, out child))
            {
                return;
            }

            // update the instance.
            child.InstanceId = instance.NodeId;

            // check if already followed.
            if (hierarchy.Instances.ContainsKey((NodeId)instance.NodeId))
            {
                return;
            }

            // save child.
            hierarchy.Instances.Add((NodeId)instance.NodeId, instance);

            // check for local node.
            ILocalNode localInstance = instance as ILocalNode;

            if (localInstance == null)
            {
                return;
            }

            // follow children.
            foreach (IReference reference in localInstance.References.Find(ReferenceTypeIds.HierarchicalReferences, false, true, m_nodes.TypeTree))
            {
                UpdateInstanceHierarchyWithInstance(child, reference.TargetId, hierarchy);
            }
        }

        /// <summary>
        /// Recursively builds the full inhierited type hierarchy starting with the top-level type.
        /// </summary>
        private void GetInstanceHierarchyForType(ExpandedNodeId typeId, InstanceDeclarationHierarchy hierarchy)
        {
            // the type must be local to the address space.
            ILocalNode type = m_nodes.Find(typeId) as ILocalNode;

            if (type == null)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadNodeIdUnknown,
                    "The type is not in the local address space.\r\nNodeId = {0}",
                    typeId);
            }

            // must be an object or variable type.
            if ((type.NodeClass & (NodeClass.ObjectType | NodeClass.VariableType)) == 0)
            {
                throw ServiceResultException.Create(
                    StatusCodes.BadNodeClassInvalid,
                    "The type node is not an ObjectType or VariableType.\r\nNodeId = {0}\r\nNodeClass = {1}",
                    typeId,
                    type.NodeClass);
            }

            // find hierarchy in supertypes first.
            foreach (IReference reference in type.References.Find(ReferenceTypeIds.HasSubtype, true, false, null))
            {
                GetInstanceHierarchyForType(reference.TargetId, hierarchy);
            }

            string browsePath = "/";

            // check if the browse path already exists in the hierarchy.
            HierarchyBrowsePath parent = null;

            if (!hierarchy.BrowsePaths.TryGetValue(browsePath, out parent))
            {
                parent = new HierarchyBrowsePath();

                parent.BrowsePath    = browsePath;
                parent.DeclarationId = type.NodeId;
                parent.InstanceId    = null;
                parent.IsModelParent = true;
                parent.IsOptional    = false;

                // add new browse path to hierarchy.
                hierarchy.BrowsePaths.Add(browsePath, parent);
            }

            // override any declaration specified in a supertype.
            parent.DeclarationId = type.NodeId;
            hierarchy.Declarations[type.NodeId] = parent;

            // follow hierarchial references to nodes with a naming rule of unique or unique optional.
            foreach (IReference reference in type.References.Find(ReferenceTypeIds.HierarchicalReferences, false, true, m_nodes.TypeTree))
            {
                GetInstanceHierarchyForType(parent, reference.TargetId, hierarchy);
            }

            // update references defined in the type.
            foreach (HierarchyBrowsePath declaration in hierarchy.Declarations.Values)
            {
                // the declaration must be local to the address space.
                ILocalNode declarationNode = m_nodes.Find(declaration.DeclarationId) as ILocalNode;

                if (declarationNode == null)
                {
                    continue;
                }

                // process all references.
                foreach (IReference reference in declarationNode.References)
                {
                    UpdateReferenceDeclaration(declaration, reference, hierarchy);
                }
            }
        }

        /// <summary>
        /// Adds or updates the references
        /// </summary>
        private void InstantiateReferences(
            HierarchyBrowsePath          source,
            InstanceDeclarationHierarchy hierarchy)
        {
            // don't add references to nodes that are not owned.
            if (!source.IsModelParent)
            {
                return;
            }

            // get the instance.
            ILocalNode instance = hierarchy.Instances[(NodeId)source.InstanceId] as ILocalNode;

            if (instance == null)
            {
                return;
            }

            // find references for the source.
            foreach (HierarchyReference reference in hierarchy.References)
            {
                // match source browse path.
                if (reference.SourceBrowsePath != source.BrowsePath)
                {
                    continue;
                }

                // check if the target is in the hierarchy.
                HierarchyBrowsePath targetBrowsePath = null;

                // check declaration.
                if (!reference.TargetDeclarationId.IsAbsolute)
                {
                    if (!hierarchy.Declarations.TryGetValue((NodeId)reference.TargetDeclarationId, out targetBrowsePath))
                    {
                        targetBrowsePath = null;
                    }
                }

                // check browse path.
                if (targetBrowsePath == null && reference.TargetBrowsePath != null)
                {
                    if (!hierarchy.BrowsePaths.TryGetValue(reference.TargetBrowsePath, out targetBrowsePath))
                    {
                        targetBrowsePath = null;
                    }
                }

                // type definition references are never relative to the hierarchy.
                if (m_nodes.TypeTree.IsTypeOf(reference.ReferenceTypeId, ReferenceTypeIds.HasTypeDefinition))
                {
                    targetBrowsePath = null;
                }

                // target outside hierarchy.
                if (targetBrowsePath == null)
                {
                    if (reference.TargetDeclarationId != null)
                    {
                        // check for existing type definition.
                        if (reference.ReferenceTypeId == ReferenceTypeIds.HasTypeDefinition)
                        {
                            IList<IReference> existingReferences = instance.References.Find(reference.ReferenceTypeId, false, true, m_nodes.TypeTree);

                            if (existingReferences.Count > 0)
                            {
                                if (m_nodes.TypeTree.IsTypeOf(existingReferences[0].TargetId, reference.TargetDeclarationId))
                                {
                                    continue;
                                }

                                instance.References.RemoveAll(ReferenceTypeIds.HasTypeDefinition, false);
                            }
                        }

                        instance.References.Add(reference.ReferenceTypeId, false, reference.TargetDeclarationId);
                    }

                    continue;
                }

                // target inside hierarchy.
                if (targetBrowsePath.InstanceId != null)
                {
                    instance.References.Add(reference.ReferenceTypeId, false, targetBrowsePath.InstanceId);
                }
            }
        }

        /// <summary>
        /// Adds or updates a reference declaration.
        /// </summary>
        private void UpdateReferenceDeclaration(
            HierarchyBrowsePath          source,
            IReference                   reference,
            InstanceDeclarationHierarchy hierarchy)
        {
            // ignore inverse references.
            if (reference.IsInverse)
            {
                return;
            }

            // ignore subtype references.
            if (m_nodes.TypeTree.IsTypeOf(reference.ReferenceTypeId, ReferenceTypeIds.HasSubtype))
            {
                return;
            }

            // find the target browse path.
            HierarchyBrowsePath targetBrowsePath = null;

            if (!reference.TargetId.IsAbsolute)
            {
                if (!hierarchy.Declarations.TryGetValue((NodeId)reference.TargetId, out targetBrowsePath))
                {
                    targetBrowsePath = null;
                }
            }

            // ignore hierarchical references with targets that are outside the hierarchy.
            if (targetBrowsePath == null)
            {
                if (m_nodes.TypeTree.IsTypeOf(reference.ReferenceTypeId, ReferenceTypeIds.HierarchicalReferences))
                {
                    return;
                }
            }

            // type definition references are never relative to the hierarchy.
            if (m_nodes.TypeTree.IsTypeOf(reference.ReferenceTypeId, ReferenceTypeIds.HasTypeDefinition))
            {
                targetBrowsePath = null;
            }

            // update existing references.
            int count = hierarchy.References.Count;

            for (int ii = 0; ii < count; ii++)
            {
                HierarchyReference existingReference = hierarchy.References[ii];

                // match source browse path.
                if (existingReference.SourceBrowsePath != source.BrowsePath)
                {
                    continue;
                }

                // allow subtypes of the reference type.
                if (!m_nodes.TypeTree.IsTypeOf(reference.ReferenceTypeId, existingReference.ReferenceTypeId))
                {
                    continue;
                }

                // match target browse path for internal references.
                if (targetBrowsePath != null)
                {
                    if (existingReference.TargetBrowsePath != targetBrowsePath.BrowsePath)
                    {
                        continue;
                    }
                }
                else
                {


                    // check for external reference types where exactly one reference is permitted.
                    bool singletonReferenceType = false;

                    if (reference.ReferenceTypeId.IdType == IdType.Numeric && reference.ReferenceTypeId.NamespaceIndex == 0)
                    {
                        switch ((uint)reference.ReferenceTypeId.Identifier)
                        {
                            case ReferenceTypes.HasTypeDefinition:
                            {
                                singletonReferenceType = true;
                                break;
                            }

                            case ReferenceTypes.HasModellingRule:
                            {
                                singletonReferenceType = true;
                                break;
                            }

                            default:
                            {
                                break;
                            }
                        }
                    }

                    // add new reference if multiples permitted.
                    if (!singletonReferenceType)
                    {
                        break;
                    }
                }

                // update existing reference.
                existingReference.SourceDeclarationId = source.DeclarationId;
                existingReference.SourceInstanceId    = null;
                existingReference.ReferenceTypeId     = reference.ReferenceTypeId;
                existingReference.TargetBrowsePath    = (targetBrowsePath != null)?targetBrowsePath.BrowsePath:null;
                existingReference.TargetDeclarationId = reference.TargetId;
                existingReference.TargetInstanceId    = null;

                // only one reference with the same source/reference type/target allowed.
                return;
            }

            // create a new reference.
            HierarchyReference newReference = new HierarchyReference();

            newReference.SourceBrowsePath    = source.BrowsePath;
            newReference.SourceDeclarationId = source.DeclarationId;
            newReference.SourceInstanceId    = null;
            newReference.ReferenceTypeId     = reference.ReferenceTypeId;
            newReference.TargetBrowsePath    = (targetBrowsePath != null)?targetBrowsePath.BrowsePath:null;
            newReference.TargetDeclarationId = reference.TargetId;
            newReference.TargetInstanceId    = null;

            hierarchy.References.Add(newReference);
        }

        /// <summary>
        /// Recursively collects the nodes within a type hierarchy.
        /// </summary>
        private void GetInstanceHierarchyForType(
            HierarchyBrowsePath          parent,
            ExpandedNodeId               instanceId,
            InstanceDeclarationHierarchy hierarchy)
        {
            // the instance must be local to the address space.
            ILocalNode instance = m_nodes.Find(instanceId) as ILocalNode;

            if (instance == null)
            {
                return;
            }

            // must be an object, variable or method.
            if ((instance.NodeClass & (NodeClass.Object | NodeClass.Variable | NodeClass.Method)) == 0)
            {
                return;
            }

            // get the naming rule.
            NamingRule namingRule = GetNamingRule(instance.ModellingRule);

            // only include instances with unique browse names in the hierarchy.
            if (namingRule != NamingRule.Unique && namingRule != NamingRule.UniqueOptional)
            {
                return;
            }

            // construct the browse path that identifies the node.
            string browsePath = null;

            if (parent.BrowsePath == "/")
            {
                browsePath = Utils.Format("/{0}", instance.BrowseName);
            }
            else
            {
                browsePath = Utils.Format("{0}/{1}", parent.BrowsePath, instance.BrowseName);
            }

            // check if the browse path already exists in the hierarchy.
            HierarchyBrowsePath child = null;

            if (!hierarchy.BrowsePaths.TryGetValue(browsePath, out child))
            {
                child = new HierarchyBrowsePath();

                child.BrowsePath    = browsePath;
                child.DeclarationId = instance.NodeId;
                child.InstanceId    = null;
                child.IsModelParent = false;
                child.IsOptional    = namingRule != NamingRule.Unique;

                // add new browse path to hierarchy.
                hierarchy.BrowsePaths.Add(browsePath, child);
            }

            // override any declaration specified in a supertype.
            child.DeclarationId = instance.NodeId;

            // check if node has been processed via another path.
            HierarchyBrowsePath alternatePath = null;

            if (hierarchy.Declarations.TryGetValue(instance.NodeId, out alternatePath))
            {
                // keep the model parent path as the primary path.
                if (!alternatePath.IsModelParent && child.IsModelParent)
                {
                    hierarchy.Declarations[instance.NodeId] = child;
                }

                // nothing more to do since node has been processed once.
                return;
            }

            // save child.
            hierarchy.Declarations.Add(instance.NodeId, child);



            // follow children.
            foreach (IReference reference in instance.References.Find(ReferenceTypeIds.HierarchicalReferences, false, true, m_nodes.TypeTree))
            {
                GetInstanceHierarchyForType(child, reference.TargetId, hierarchy);
            }
        }
        #endregion

        #region Private Fields
        private INodeTable m_nodes;
        #endregion
    }

    /// <summary>
    /// A browse path defined within an instance declaration hierarchy.
    /// </summary>
    [Obsolete("The InstanceDeclarationHierarchy class is obsolete and is not supported.")]
    public class InstanceDeclarationHierarchy : IFormattable
    {
        #region Constructors
        /// <summary>
        /// Creates an empty hierarchy.
        /// </summary>
        public InstanceDeclarationHierarchy()
        {
            m_declarations = new NodeIdDictionary<HierarchyBrowsePath>();
            m_instances = new NodeIdDictionary<INode>();
            m_browsePaths = new SortedDictionary<string,HierarchyBrowsePath>();
            m_references = new List<HierarchyReference>();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The set of declarations in the hierarchy.
        /// </summary>
        /// <value>The declarations.</value>
        public NodeIdDictionary<HierarchyBrowsePath> Declarations
        {
            get { return m_declarations; }
        }

        /// <summary>
        /// The set of instances in the hierarchy.
        /// </summary>
        /// <value>The instances.</value>
        public NodeIdDictionary<INode> Instances
        {
            get { return m_instances; }
        }

        /// <summary>
        /// The set of browse paths in the hierarchy.
        /// </summary>
        /// <value>The browse paths.</value>
        public IDictionary<string,HierarchyBrowsePath> BrowsePaths
        {
            get { return m_browsePaths; }
        }

        /// <summary>
        /// The set of references in the hierarchy.
        /// </summary>
        /// <value>The references.</value>
        public IList<HierarchyReference> References
        {
            get { return m_references; }
        }
        #endregion

        #region IFormattable Members
        /// <summary>
        /// Returns a string representation of the InstanceDeclarationHierarchy.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

        /// <summary>
        /// Returns a string representation of the InstanceDeclarationHierarchy.
        /// </summary>
        /// <param name="format">The <see cref="T:System.String"/> specifying the format to use.
        /// -or-
        /// null to use the default format defined for the type of the <see cref="T:System.IFormattable"/> implementation.</param>
        /// <param name="formatProvider">The <see cref="T:System.IFormatProvider"/> to use to format the value.
        /// -or-
        /// null to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <returns>
        /// A <see cref="T:System.String"/> containing the value of the current instance in the specified format.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format != null)
            {
                throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
            }

            return Utils.Format("BrowsePaths[{0}] References[{1}]", m_browsePaths.Count, m_references.Count);
        }
        #endregion

        #region Private Fields
        private NodeIdDictionary<HierarchyBrowsePath> m_declarations;
        private NodeIdDictionary<INode> m_instances;
        private SortedDictionary<string,HierarchyBrowsePath> m_browsePaths;
        private List<HierarchyReference> m_references;
        #endregion
    }

    /// <summary>
    /// A browse path defined within an instance declaration hierarchy.
    /// </summary>
    [Obsolete("The HierarchyBrowsePath class is obsolete and is not supported.")]
    public class HierarchyBrowsePath : IFormattable
    {
        #region Public Properties
        /// <summary>
        /// The identifier for the browse path.
        /// </summary>
        /// <value>The browse path.</value>
        public string BrowsePath
        {
            get { return m_browsePath;  }
            set { m_browsePath = value; }
        }

        /// <summary>
        /// The identifier for the node in the fully inhierited type hierarchy.
        /// </summary>
        /// <value>The declaration identifier.</value>
        public NodeId DeclarationId
        {
            get { return m_declarationId;  }
            set { m_declarationId = value; }
        }

        /// <summary>
        /// The identifier for the node in the instance hierarchy.
        /// </summary>
        /// <value>The instance identifier.</value>
        public ExpandedNodeId InstanceId
        {
            get { return m_instanceId;  }
            set { m_instanceId = value; }
        }

        /// <summary>
        /// Whether the browse path follows the model parent references.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is model parent; otherwise, <c>false</c>.
        /// </value>
        public bool IsModelParent
        {
            get { return m_isModelParent;  }
            set { m_isModelParent = value; }
        }

        /// <summary>
        /// Whether the browse path is optional.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is optional; otherwise, <c>false</c>.
        /// </value>
        public bool IsOptional
        {
            get { return m_isOptional;  }
            set { m_isOptional = value; }
        }
        #endregion

        #region IFormattable Members
        /// <summary>
        /// Returns a string representation of the HierarchyBrowsePath.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

        /// <summary>
        /// Returns a string representation of the HierarchyBrowsePath.
        /// </summary>
        /// <param name="format">The <see cref="T:System.String"/> specifying the format to use.
        /// -or-
        /// null to use the default format defined for the type of the <see cref="T:System.IFormattable"/> implementation.</param>
        /// <param name="formatProvider">The <see cref="T:System.IFormatProvider"/> to use to format the value.
        /// -or-
        /// null to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <returns>
        /// A <see cref="T:System.String"/> containing the value of the current instance in the specified format.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format != null)
            {
                throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
            }

            return Utils.Format("{0}({1},{2})", m_browsePath, m_isModelParent?"New":"Shared", m_isOptional?"Optional":"Required");
        }
        #endregion

        #region Private Fields
        private string m_browsePath;
        private NodeId m_declarationId;
        private ExpandedNodeId m_instanceId;
        private bool m_isModelParent;
        private bool m_isOptional;
        #endregion
    }

    /// <summary>
    /// A references between nodes in an instance declaration hierarchy.
    /// </summary>
    [Obsolete("The HierarchyReference class is obsolete and is not supported.")]
    public class HierarchyReference : IFormattable
    {
        #region Public Properties
        /// <summary>
        /// The browse path for the source node.
        /// </summary>
        /// <value>The source browse path.</value>
        public string SourceBrowsePath
        {
            get { return m_sourceBrowsePath;  }
            set { m_sourceBrowsePath = value; }
        }

        /// <summary>
        /// The identifier for the target node in the fully inhierited type hierarchy.
        /// </summary>
        /// <value>The source declaration identifier.</value>
        public NodeId SourceDeclarationId
        {
            get { return m_sourceDeclarationId;  }
            set { m_sourceDeclarationId = value; }
        }

        /// <summary>
        /// The identifier for the source node in the instance hierarchy.
        /// </summary>
        /// <value>The source instance identifier.</value>
        public NodeId SourceInstanceId
        {
            get { return m_sourceInstanceId;  }
            set { m_sourceInstanceId = value; }
        }

        /// <summary>
        /// The identifier for the reference type.
        /// </summary>
        /// <value>The reference type identifier.</value>
        public NodeId ReferenceTypeId
        {
            get { return m_referenceTypeId;  }
            set { m_referenceTypeId = value; }
        }

        /// <summary>
        /// The browse path for the target node.
        /// </summary>
        /// <value>The target browse path.</value>
        public string TargetBrowsePath
        {
            get { return m_targetBrowsePath;  }
            set { m_targetBrowsePath = value; }
        }

        /// <summary>
        /// The identifier for the target node in the fully inhierited type hierarchy.
        /// </summary>
        /// <value>The target declaration identifier.</value>
        public ExpandedNodeId TargetDeclarationId
        {
            get { return m_targetDeclarationId;  }
            set { m_targetDeclarationId = value; }
        }

        /// <summary>
        /// The identifier for the target node in the instance hierarchy.
        /// </summary>
        /// <value>The target instance identifier.</value>
        public ExpandedNodeId TargetInstanceId
        {
            get { return m_targetInstanceId;  }
            set { m_targetInstanceId = value; }
        }

        /// <summary>
        /// Whether the reference is instantiated as a one way reference.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is one way; otherwise, <c>false</c>.
        /// </value>
        public bool IsOneWay
        {
            get { return m_isOneWay;  }
            set { m_isOneWay = value; }
        }
        #endregion

        #region IFormattable Members
        /// <summary>
        /// Returns a string representation of the HierarchyReference.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return ToString(null, null);
        }

        /// <summary>
        /// Returns a string representation of the HierarchyReference.
        /// </summary>
        /// <param name="format">The <see cref="T:System.String"/> specifying the format to use.
        /// -or-
        /// null to use the default format defined for the type of the <see cref="T:System.IFormattable"/> implementation.</param>
        /// <param name="formatProvider">The <see cref="T:System.IFormatProvider"/> to use to format the value.
        /// -or-
        /// null to obtain the numeric format information from the current locale setting of the operating system.</param>
        /// <returns>
        /// A <see cref="T:System.String"/> containing the value of the current instance in the specified format.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format != null)
            {
                throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
            }

            string referenceType = Utils.Format("{0}", m_referenceTypeId);

            if (m_referenceTypeId != null && m_referenceTypeId.IdType == IdType.Numeric && m_referenceTypeId.NamespaceIndex == 0)
            {
                referenceType = ReferenceTypes.GetBrowseName((uint)m_referenceTypeId.Identifier);
            }

            string targetBrowsePath = m_targetBrowsePath;

            if (targetBrowsePath == null)
            {
                targetBrowsePath = Utils.Format("{0}", m_targetDeclarationId);
            }

            return Utils.Format("{0}<{1}>{2})", m_sourceBrowsePath, referenceType, targetBrowsePath);
        }
        #endregion

        #region Private Fields
        private string m_sourceBrowsePath;
        private NodeId m_sourceDeclarationId;
        private NodeId m_sourceInstanceId;
        private NodeId m_referenceTypeId;
        private string m_targetBrowsePath;
        private ExpandedNodeId m_targetDeclarationId;
        private ExpandedNodeId m_targetInstanceId;
        private bool m_isOneWay;
        #endregion
    }

    /// <summary>
    /// The naming rule for a modelling rule.
    /// </summary>
    [Obsolete("The NamingRule enumeration is obsolete and is not supported.")]
    public enum NamingRule
    {
        /// <summary>
        /// There are no naming requirements.
        /// </summary>
        None,

        /// <summary>
        /// A node with the same BrowseName must be present.
        /// </summary>
        Unique,

        /// <summary>
        /// A node with the same BrowseName may be present.
        /// </summary>
        UniqueOptional
    }

    /// <summary>
    /// The creation rule for a modelling rule.
    /// </summary>
    [Obsolete("The CreationRule enumeration is obsolete and is not supported.")]
    public enum CreationRule
    {
        /// <summary>
        /// The node is not created when the type is instantiated.
        /// </summary>
        None,

        /// <summary>
        /// Each instance has a its own copy of the node.
        /// </summary>
        New,

        /// <summary>
        /// Each instance references the node defined in the type definition.
        /// </summary>
        Shared,

        /// <summary>
        /// Each instance references a node defined anywhere in the address space.
        /// </summary>
        Any
    }
}
