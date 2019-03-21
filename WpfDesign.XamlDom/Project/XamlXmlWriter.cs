// Copyright (c) 2019 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System.Xml;

namespace ICSharpCode.WpfDesign.XamlDom
{
	/// <summary>
	/// A special XamlXmlWriter wich fixes &amp; and &quot; in MarkupExtensions where not correctly handled.
	/// </summary>
	public class XamlXmlWriter : XmlWriter
	{
		/// <summary>
		/// The <see cref="XmlWriter"/> instance used internally.
		/// </summary>
		protected readonly XmlWriter xmlWriter;
		
		/// <summary>
		/// Initializes a new instance of the <see cref="XamlXmlWriter"/> class.
		/// </summary>
		/// <param name="stringBuilder">The <see cref="System.Text.StringBuilder"/> to which to write to.</param>
		public XamlXmlWriter(System.Text.StringBuilder stringBuilder)
		{
			this.xmlWriter = XmlWriter.Create(stringBuilder);
		}
		
		/// <summary>
		/// Initializes a new instance of the <see cref="XamlXmlWriter"/> class.
		/// </summary>
		/// <param name="stringBuilder">The <see cref="System.Text.StringBuilder"/> to which to write to.</param>
		/// <param name="settings">The <see cref="XmlWriterSettings"/> object used to configure the new <see cref="XamlXmlWriter"/> instance.</param>
		public XamlXmlWriter(System.Text.StringBuilder stringBuilder, XmlWriterSettings settings)
		{
			this.xmlWriter = XmlWriter.Create(stringBuilder, settings);
		}
		
		#region implemented abstract members of XmlWriter

		/// <inheritdoc/>
		public override void WriteStartDocument()
		{
			xmlWriter.WriteStartDocument();
		}

		/// <inheritdoc/>
		public override void WriteStartDocument(bool standalone)
		{
			xmlWriter.WriteStartDocument(standalone);
		}

		/// <inheritdoc/>
		public override void WriteEndDocument()
		{
			xmlWriter.WriteEndDocument();
		}

		/// <inheritdoc/>
		public override void WriteDocType(string name, string pubid, string sysid, string subset)
		{
			xmlWriter.WriteDocType(name, pubid, sysid, subset);
		}

		/// <inheritdoc/>
		public override void WriteStartElement(string prefix, string localName, string ns)
		{
			xmlWriter.WriteStartElement(prefix, localName, ns);
		}

		/// <inheritdoc/>
		public override void WriteEndElement()
		{
			xmlWriter.WriteEndElement();
		}

		/// <inheritdoc/>
		public override void WriteFullEndElement()
		{
			xmlWriter.WriteFullEndElement();
		}

		/// <inheritdoc/>
		public override void WriteStartAttribute(string prefix, string localName, string ns)
		{
			xmlWriter.WriteStartAttribute(prefix, localName, ns);
		}

		/// <inheritdoc/>
		public override void WriteEndAttribute()
		{
			xmlWriter.WriteEndAttribute();
		}

		/// <inheritdoc/>
		public override void WriteCData(string text)
		{
			xmlWriter.WriteCData(text);
		}

		/// <inheritdoc/>
		public override void WriteComment(string text)
		{
			xmlWriter.WriteComment(text);
		}

		/// <inheritdoc/>
		public override void WriteProcessingInstruction(string name, string text)
		{
			xmlWriter.WriteProcessingInstruction(name, text);
		}

		/// <inheritdoc/>
		public override void WriteEntityRef(string name)
		{
			xmlWriter.WriteEntityRef(name);
		}

		/// <inheritdoc/>
		public override void WriteCharEntity(char ch)
		{
			xmlWriter.WriteCharEntity(ch);
		}

		/// <inheritdoc/>
		public override void WriteWhitespace(string ws)
		{
			xmlWriter.WriteWhitespace(ws);
		}

		/// <inheritdoc/>
		public override void WriteString(string text)
		{
			xmlWriter.WriteString(text.Replace("&", "&amp;").Replace("<", "&lt;").Replace("\"", "&quot;"));
		}

		/// <inheritdoc/>
		public override void WriteSurrogateCharEntity(char lowChar, char highChar)
		{
			xmlWriter.WriteSurrogateCharEntity(lowChar, highChar);
		}

		/// <inheritdoc/>
		public override void WriteChars(char[] buffer, int index, int count)
		{
			xmlWriter.WriteChars(buffer, index, count);
		}

		/// <inheritdoc/>
		public override void WriteRaw(char[] buffer, int index, int count)
		{
			xmlWriter.WriteRaw(buffer, index, count);
		}

		/// <inheritdoc/>
		public override void WriteRaw(string data)
		{
			xmlWriter.WriteRaw(data);
		}

		/// <inheritdoc/>
		public override void WriteBase64(byte[] buffer, int index, int count)
		{
			xmlWriter.WriteBase64(buffer, index, count);
		}

		/// <inheritdoc/>
		public override void Close()
		{
			xmlWriter.Close();
		}

		/// <inheritdoc/>
		public override void Flush()
		{
			xmlWriter.Flush();
		}

		/// <inheritdoc/>
		public override string LookupPrefix(string ns)
		{
			return xmlWriter.LookupPrefix(ns);
		}

		/// <inheritdoc/>
		public override WriteState WriteState {
			get {
				return xmlWriter.WriteState;
			}
		}

		#endregion
	}
}
