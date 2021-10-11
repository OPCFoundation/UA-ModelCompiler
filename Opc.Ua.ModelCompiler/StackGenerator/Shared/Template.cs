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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Reflection;

namespace CodeGenerator
{
    /// <summary>
    /// Generates types used to implement an address space.
    /// </summary>
    public class Template
    {
        #region Constructors
        /// <summary>
        /// Initializes the stream from the resource block of the specified assembly.
        /// </summary>
        public Template(TextWriter writer, string templatePath, Assembly assembly)
        :
            this(writer, false, templatePath, assembly)
        {
        }

        /// <summary>
        /// Initializes the stream from the resource block of the specified assembly.
        /// </summary>
        private Template(TextWriter writer, bool written, string templatePath, Assembly assembly)
        {
            Initialize();

            try
            {
                string[] names = assembly.GetManifestResourceNames();

                if (templatePath.Length > 0)
                {
                    m_reader = new StreamReader(assembly.GetManifestResourceStream(templatePath));
                }
                else
                {
                    m_reader = new StringReader(String.Empty);
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(String.Format("Template '{0}' not found.", templatePath), e);
            }

            m_writer = writer;
            m_written = written;
            m_assembly = assembly;
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
            m_replacements                  = new Dictionary<string,string>();
            m_templates                     = new Dictionary<string,TemplateDefinition>();
            m_reader                        = null;
            m_writer                        = null;
            m_indentCount                   = 0;
            m_templateStartTag              = "***START***";
            m_templateEndTag                = "***END***";
            m_templateEndAppendNewLineTag   = "***ENDAPPENDNEWLINE***";
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The tag that marks the start of a template body.
        /// </summary>
        protected string TemplateStartTag
        {
            get { return m_templateStartTag;  }
            set { m_templateStartTag = value; }
        }

        /// <summary>
        /// The tag that marks the end of a template body.
        /// </summary>
        protected string TemplateEndTag
        {
            get { return m_templateEndTag;  }
            set { m_templateEndTag = value; }
        }

        /// <summary>
        /// The tag that marks the end of a template body and is replaced by a new line.
        /// </summary>
        protected string TemplateEndAppendNewLineTag
        {
            get { return m_templateEndAppendNewLineTag; }
            set { m_templateEndAppendNewLineTag = value; }
        }

        /// <summary>
        /// The number of levels to ident a the current line.
        /// </summary>
        protected int IndentCount
        {
            get { return m_indentCount;  }
            set { m_indentCount = value; }
        }

        /// <summary>
        /// Returns enough whitespace to indent the current line properly.
        /// </summary>
        public string Indent
        {
            get
            {
                if (m_indentCount > 0)
                {
                    return new string(' ', m_indentCount*4);
                }

                return String.Empty;
            }
        }

        /// <summary>
        /// Returns the new line characters.
        /// </summary>
        public string NewLine
        {
            get { return "\r\n"; }
        }

        /// <summary>
        /// The table of tokens to replace.
        /// </summary>
        public Dictionary<string, string> Replacements
        {
            get { return m_replacements; }
        }

        /// <summary>
        /// The templates to load.
        /// </summary>
        public Dictionary<string,TemplateDefinition> Templates
        {
            get { return m_templates; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a replacement value for a token.
        /// </summary>
        public void AddReplacement(string token, object replacement)
        {
            if (replacement is bool)
            {
                m_replacements.Add(token, ((bool)replacement) ? "true" : "false");
            }
            else
            {
                m_replacements.Add(token, String.Format("{0}", replacement));
            }
        }

        /// <summary>
        /// Performs the substitutions specified in the template and writes it to the stream.
        /// </summary>
        public bool WriteTemplate(Context context)
        {
            // ensure context is not null.
            if (context == null)
            {
                context = new Context();
            }

            bool skipping = true;
            bool written  = false;

            // build list of tokens.
            int count = 0;

            string[] tokens = new string[m_replacements.Count];

            foreach (string token in m_replacements.Keys)
            {
                tokens[count++] = token;
            }

            // read first line.
            string line = m_reader.ReadLine();

            while (line != null)
            {
                // if skipping lines look for the template start tag.
                if (skipping)
                {
                    if (line.IndexOf(TemplateStartTag) != -1)
                    {
                        skipping = false;
                    }

                    line = m_reader.ReadLine();
                    continue;
                }

                // if writing lines look for the template end tag.
                else
                {
                    if (line.IndexOf(TemplateEndAppendNewLineTag) != -1)
                    {
                        Write(NewLine);
                        break;
                    }
                    if (line.IndexOf(TemplateEndTag) != -1)
                    {
                        break;
                    }
                }

                // process empty lines.
                if (line.Length == 0)
                {
                    if (written)
                    {
                        Write(NewLine);
                    }

                    written = true;
                    line = m_reader.ReadLine();
                    continue;
                }

                bool found = false;

                for (int index = 0; index < line.Length; index++)
                {
                    // check for a token at the current position.
                    string token = null;

                    for (int ii = 0; ii < tokens.Length; ii++)
                    {
                        if (StrCmp(line, index, tokens[ii]))
                        {
                            token = tokens[ii];
                            break;
                        }
                    }

                    // nothing found.
                    if (token == null)
                    {
                        continue;
                    }

                    // check if a template substitution is required.
                    if (m_templates.ContainsKey(token))
                    {
                        // skip the token if no items to write.
                        TemplateDefinition definition = m_templates[token];

                        if (definition == null || definition.Targets == null || definition.Targets.Count == 0)
                        {
                            found = true;
                            line = line.Substring(index + token.Length);
                            index = -1;
                            continue;
                        }

                        // write multi-line template.
                        bool result = WriteTemplate(
                            context.Target,
                            token,
                            context.Prefix + line.Substring(0, index));

                        if (result)
                        {
                            written = true;
                        }

                        line = String.Empty;
                        continue;
                    }

                    // only process tokens if a value is provided.
                    if (m_replacements[token] != null)
                    {
                        written = WriteToken(
                            context.Target,
                            context,
                            !found,
                            line.Substring(0, index),
                            token);

                        found = true;
                    }

                    line = line.Substring(index + token.Length);
                    index = -1;
                }

                // write line if no token found.
                if (line.Length > 0)
                {
                    if (!found)
                    {
                        // ensure that an empty line does not get inserted at the start of a file.
                        if (written || context.Target != null)
                        {
                            Write(NewLine);
                        }

                        Write(context.Prefix);
                        written = true;
                    }

                    Write(line);
                }

                // read next line.
                line = m_reader.ReadLine();
            }

            return written;
        }

        /// <summary>
        /// Writes the text to the stream.
        /// </summary>
        public void Write(char text)
        {
            m_writer.Write(text);
            m_written = true;
        }

        /// <summary>
        /// Writes the text to the stream.
        /// </summary>
        public void Write(string text)
        {
            if (!m_written)
            {
                if (text == NewLine)
                {
                    return;
                }
            }

            m_writer.Write(text);
            m_written = true;
        }

        /// <summary>
        /// Formats and then writes the text to the stream.
        /// </summary>
        public void Write(string format, object arg1)
        {
            m_writer.Write(format, arg1);
            m_written = true;
        }

        /// <summary>
        /// Formats and then writes the text to the stream.
        /// </summary>
        public void Write(string format, object arg1, object arg2)
        {
            m_writer.Write(format, arg1, arg2);
            m_written = true;
        }

        /// <summary>
        /// Formats and then writes the text to the stream.
        /// </summary>
        public void Write(string format, object arg1, object arg2, object arg3)
        {
            m_writer.Write(format, arg1, arg2, arg3);
            m_written = true;
        }

        /// <summary>
        /// Formats and then writes the text to the stream.
        /// </summary>
        public void Write(string format, params object[] args)
        {
            m_writer.Write(format, args);
            m_written = true;
        }

        /// <summary>
        /// Writes a newline and then indents the text for the next line.
        /// </summary>
        public void WriteNextLine(string prefix)
        {
            m_writer.Write(NewLine);
            m_writer.Write(Indent);
            m_writer.Write(prefix);
            m_written = true;
        }

        /// <summary>
        /// Writes the text to the stream followed by a new line.
        /// </summary>
        public void WriteLine(string text)
        {
            m_writer.Write(Indent);
            m_writer.Write(text);
            m_writer.Write(NewLine);
            m_written = true;
        }

        /// <summary>
        /// Formats and then writes the text to the stream followed by a new line.
        /// </summary>
        public void WriteLine(string text, object arg1)
        {
            WriteLine(text, new object[] { arg1 });
        }

        /// <summary>
        /// Formats and then writes the text to the stream followed by a new line.
        /// </summary>
        public void WriteLine(string text, object arg1, object arg2)
        {
            WriteLine(text, new object[] { arg1, arg2 });
        }

        /// <summary>
        /// Formats and then writes the text to the stream followed by a new line.
        /// </summary>
        public void WriteLine(string text, object arg1, object arg2, object arg3)
        {
            WriteLine(text, new object[] { arg1, arg2, arg3 });
        }

        /// <summary>
        /// Formats and then writes the text to the stream followed by a new line.
        /// </summary>
        public void WriteLine(string text, object[] args)
        {
            m_writer.Write(Indent);
            m_writer.Write(text, args);
            m_writer.Write(NewLine);
            m_written = true;
        }
        #endregion

        #region Protected Methods
        /// <summary>
        /// Substitutes simple text template for a token.
        /// </summary>
        protected virtual bool WriteToken(
            object   target,
            Context  context,
            bool     firstToken,
            string   prefix,
            string   token)
        {
            // write context prefix for first token.
            if (firstToken)
            {
                Write(NewLine);
                Write(context.Prefix);
            }

            // write prefix.
            Write(prefix);

            // write replacement.
            string replacement = m_replacements[token];

            if (replacement != null)
            {
                Write(replacement);
            }

            return true;
        }

        /// <summary>
        /// Substitutes a multi-line template for a token.
        /// </summary>
        protected virtual bool WriteTemplate(
            object   container,
            string   token,
            string   prefix)
        {
            bool written = false;

            // write each item in the list.
            Context context = new Context();

            context.Container    = container;
            context.Token        = token;
            context.Index        = 0;
            context.FirstInList  = true;
            context.Prefix       = prefix;

            TemplateDefinition definition = m_templates[token];

            context.TemplatePath = definition.TemplatePath;

            foreach (object target in definition.Targets)
            {
                context.Target = target;

                // get the template path name.
                string templatePath = definition.Load(this, context);

                // skip item if no template specified.
                if (templatePath == null)
                {
                    context.Index++;
                    continue;
                }

                // load the template.
                Template template = new Template(m_writer, m_written, templatePath, m_assembly);

                if (template != null)
                {
                    if (!context.FirstInList && context.BlankLine)
                    {
                        Write(NewLine);
                    }

                    if (definition.Write(template, context))
                    {
                        context.FirstInList = false;
                        written = true;
                    }

                    m_written = template.m_written;
                }

                context.Index++;
            }

            // return flag indicating whether something was written.
            return written;
        }

        /// <summary>
        /// Determines if the target exists in the string at the specified index.
        /// </summary>
        protected bool StrCmp(string source, int index, string target)
        {
            for (int ii = 0; ii < target.Length; ii++)
            {
                if (index+ii >= source.Length || source[index+ii] != target[ii])
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region Private Members
        private TextReader m_reader;
        private TextWriter m_writer;
        private Assembly m_assembly;

        private Dictionary<string,string> m_replacements;
        private Dictionary<string,TemplateDefinition> m_templates;

        private string m_templateStartTag;
        private string m_templateEndTag;
        private string m_templateEndAppendNewLineTag;
        private int m_indentCount;
        private bool m_written;
        #endregion
    }

    /// <summary>
    /// A delegate handle events associated with template.
    /// </summary>
    public delegate string LoadTemplateEventHandler(Template template, Context context);

    /// <summary>
    /// A delegate handle events associated with template.
    /// </summary>
    public delegate bool WriteTemplateEventHandler(Template template, Context context);

    /// <summary>
    /// Stores the information that describes how to initialize and process a template.
    /// </summary>
    public class TemplateDefinition
    {
        #region Public Properties
        /// <summary>
        /// The path of the template to load.
        /// </summary>
        public string TemplatePath
        {
            get { return m_templatePath; }
            set { m_templatePath = value; }
        }

        /// <summary>
        /// The targets that the template should be applied to.
        /// </summary>
        public ICollection Targets
        {
            get { return m_targets; }
            set { m_targets = value; }
        }

        /// <summary>
        /// The callback to call when loading the template.
        /// </summary>
        public event LoadTemplateEventHandler LoadTemplate
        {
            add { m_loadTemplate += value; }
            remove { m_loadTemplate -= value; }
        }

        /// <summary>
        /// The callback to call when writing the template.
        /// </summary>
        public event WriteTemplateEventHandler WriteTemplate
        {
            add { m_writeTemplate += value; }
            remove { m_writeTemplate -= value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Loads the template.
        /// </summary>
        public string Load(Template template, Context context)
        {
            // check for override.
            if (m_loadTemplate != null)
            {
                return m_loadTemplate(template, context);
            }

            // use the default function to write the template.
            return context.TemplatePath;
        }

        /// <summary>
        /// Writes the template.
        /// </summary>
        public bool Write(Template template, Context context)
        {
            // check for override.
            if (m_writeTemplate != null)
            {
                return m_writeTemplate(template, context);
            }

            // use the default function to write the template.
            return template.WriteTemplate(context);
        }
        #endregion

        #region Private Fields
        private string m_templatePath;
        private ICollection m_targets;
        private event LoadTemplateEventHandler m_loadTemplate;
        private event WriteTemplateEventHandler m_writeTemplate;
        #endregion
    }
}
