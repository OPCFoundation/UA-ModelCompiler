/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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
using System.Text;
using System.Runtime.InteropServices;

namespace Opc.Ua
{
    /// <summary>
    /// Produces high resolution timestamps.
    /// </summary>
    public class HiResClock
    {
        /// <summary>
        /// Returns the current UTC time (bugs in HALs on some computers can result in time jumping backwards).
        /// </summary>
        public static DateTime UtcNow
        {
            get
            {
                #if !SILVERLIGHT
                if (s_Default.m_disabled)
                {
                    return DateTime.UtcNow;
                }

                long counter = 0;

                if (NativeMethods.QueryPerformanceCounter(out counter) == 0)
                {
                    return DateTime.UtcNow;
                }

                decimal ticks = (counter - s_Default.m_baseline)*s_Default.m_ratio;

                return new DateTime((long)ticks + s_Default.m_offset);
                #else
                return DateTime.UtcNow;
                #endif
            }
        }

        /// <summary>
        /// Disables the hi-res clock (may be necessary on some machines with bugs in the HAL).
        /// </summary>
        public static bool Disabled
        {
            get
            {
                return s_Default.m_disabled;
            }

            set
            {
                s_Default.m_disabled = value;
            }
        }

        /// <summary>
        /// Constructs a class.
        /// </summary>
        private HiResClock()
        {
            #if !SILVERLIGHT
            if (NativeMethods.QueryPerformanceFrequency(out m_frequency) == 0)
            {
                m_frequency = TimeSpan.TicksPerSecond;
            }

            m_offset = DateTime.UtcNow.Ticks;

            if (NativeMethods.QueryPerformanceCounter(out m_baseline) == 0)
            {
                m_baseline = m_offset;
            }

            m_ratio = ((decimal)TimeSpan.TicksPerSecond)/m_frequency;
            #endif
        }

        /// <summary>
        /// Defines a global instance.
        /// </summary>
        private static readonly HiResClock s_Default = new HiResClock();

        /// <summary>
        /// Defines the native methods used by the class.
        /// </summary>
        private static class NativeMethods
        {
            [DllImport("Kernel32.dll")]
            public static extern int QueryPerformanceFrequency(out long lpFrequency);

            [DllImport("Kernel32.dll")]
            public static extern int QueryPerformanceCounter(out long lpFrequency);
        }

        #if !SILVERLIGHT
        private long m_frequency;
        private long m_baseline;
        private long m_offset;
        private decimal m_ratio;
        #endif

        private bool m_disabled;
    }

}
