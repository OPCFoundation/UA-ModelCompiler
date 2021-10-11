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
using System.Xml;
using System.IO;

namespace CodeGenerator
{
    /// <summary>
    /// Contains the current context to use for serialization.
    /// </summary>
    public class Context
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public Context()
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_prefix      = String.Empty;
            m_token       = String.Empty;
            m_index       = -1;
            m_firstInList = true;
            m_blankLine   = true;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The path of the template being processed.
        /// </summary>
        public string TemplatePath
        {
            get { return m_templatePath;  }
            set { m_templatePath = value; }
        }

        /// <summary>
        /// The container for the object being processed.
        /// </summary>
        public object Container
        {
            get { return m_container;  }
            set { m_container = value; }
        }

        /// <summary>
        /// The current object being processed.
        /// </summary>
        public object Target
        {
            get { return m_target;  }
            set { m_target = value; }
        }

        /// <summary>
        /// The prefix to prepend to every line of output.
        /// </summary>
        public string Prefix
        {
            get { return m_prefix;  }
            set { m_prefix = value; }
        }

        /// <summary>
        /// The token current being processed.
        /// </summary>
        public string Token
        {
            get { return m_token;  }
            set { m_token = value; }
        }

        /// <summary>
        /// The index of the current target within the list being processed.
        /// </summary>
        public int Index
        {
            get { return m_index;  }
            set { m_index = value; }
        }

        /// <summary>
        /// Whether the current target being processed is the first in the list.
        /// </summary>>
        public bool FirstInList
        {
            get { return m_firstInList;  }
            set { m_firstInList = value; }
        }

        /// <summary>
        /// Whether a blank line seperates entries in the list.
        /// </summary>>
        public bool BlankLine
        {
            get { return m_blankLine;  }
            set { m_blankLine = value; }
        }
        #endregion

        #region Private Members
        private string m_templatePath;
        private object m_container;
        private object m_target;
        private string m_prefix;
        private string m_token;
        private int m_index;
        private bool m_firstInList;
        private bool m_blankLine;
        #endregion
    }
}
