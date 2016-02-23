// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using System.Xml;

namespace ICSharpCode.WpfDesign.XamlDom
{
	/// <summary>
	/// Static methods to help with designer operations which require access to internal Xaml elements.
	/// </summary>
	public static class XamlStaticTools
	{
		/// <summary>
		/// Gets the Xaml string of the <paramref name="xamlObject"/>
		/// </summary>
		/// <param name="xamlObject">The object whose Xaml is requested.</param>
		public static string GetXaml(XamlObject xamlObject)
		{
			if (xamlObject != null)
			{
				var nd = xamlObject.XmlElement.CloneNode(true);
				var attLst = nd.Attributes.Cast<XmlAttribute>().ToDictionary(x => x.Name);

				var ns = new List<XmlAttribute>();

				var parentObject = xamlObject.ParentObject;
				while (parentObject != null)
				{
					foreach (XmlAttribute attribute in parentObject.XmlElement.Attributes)
					{
						if (attribute.Name.StartsWith("xmlns:"))
						{
							if (!attLst.ContainsKey(attribute.Name))
							{
								nd.Attributes.Append((XmlAttribute)attribute.CloneNode(false));
								attLst.Add(attribute.Name, attribute);
							}
						}
					}
					parentObject = parentObject.ParentObject;
				}


				return nd.OuterXml;
			}
			return null;
		}
	}
}
