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
using System.Threading;

namespace Opc.Ua
{
    /// <summary>
    /// A class that allows threads to determine who, if anyone, has the lock on an object.
    /// </summary>
    public class SafeLock
    {
        /// <summary>
        /// Acquires the lock.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the lock state is inconsistent.</exception>
        public void Enter()
        {
            System.Threading.Monitor.Enter(this);

            if (m_refs == 0)
            {
                int result = Interlocked.CompareExchange(ref m_owner, Thread.CurrentThread.ManagedThreadId, -1);

                if (result != -1)
                {
                    throw new InvalidOperationException("Operation failed because Lock object is in an invalid state.");
                }
            }

            m_refs++;
        }

        /// <summary>
        /// Attempts to acquire the lock.
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait.</param>
        /// <returns>True if the lock was acquired.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the lock state is inconsistent.</exception>
        public bool TryEnter(int timeout)
        {
            if (!System.Threading.Monitor.TryEnter(this, timeout))
            {
                return false;
            }

            if (m_refs == 0)
            {
                int result = Interlocked.CompareExchange(ref m_owner, Thread.CurrentThread.ManagedThreadId, -1);

                if (result != -1)
                {
                    throw new InvalidOperationException("Operation failed because Lock object is in an invalid state.");
                }
            }

            m_refs++;

            return true;
        }

        /// <summary>
        /// Releases the lock.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the lock state is inconsistent.</exception>
        public void Exit()
        {
            m_refs--;

            if (m_refs == 0)
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;

                int result = Interlocked.CompareExchange(ref m_owner, -1, threadId);

                if (result != threadId)
                {
                    throw new InvalidOperationException("Operation failed because Lock object is in an invalid state.");
                }
            }

            System.Threading.Monitor.Exit(this);
        }

        /// <summary>
        /// Checks if the current thread has acquired the lock.
        /// </summary>
        /// <returns>True if the current thread owns the lock.</returns>
        public bool HasLock()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            int result = Interlocked.CompareExchange(ref m_owner, threadId, threadId);

            if (result != threadId)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// The ManagedThreadId for the Thread that owns the lock. -1 if no thread owns the lock.
        /// </summary>
        private int m_owner = -1;

        /// <summary>
        /// The number of times Enter has been called.
        /// </summary>
        private int m_refs = 0;
    }

    /// <summary>
    /// A helper object that can be used in a using() clause to acquire/release a SafeLock.
    /// </summary>
    public sealed class Lock : IDisposable
    {
        /// <summary>
        /// Acquires the lock on the SafeLock object.
        /// </summary>
        public Lock(SafeLock safeLock)
        {
            m_safeLock = safeLock;
            m_safeLock.Enter();
        }

        #region IDisposable Members
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!m_disposed)
                {
                    m_safeLock.Exit();
                    m_disposed = true;
                }
            }
        }
        #endregion

        #region Private Fields
        private SafeLock m_safeLock;
        private bool m_disposed;
        #endregion
    }
}
