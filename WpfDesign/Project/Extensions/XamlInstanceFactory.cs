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
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xaml;
using System.Xml;

namespace ICSharpCode.WpfDesign.Extensions
{
	/// <summary>
	/// 
	/// </summary>
	[ExtensionServer(typeof(NeverApplyExtensionsExtensionServer))]
	public class XamlInstanceFactory : Extension
	{
		/// <summary>
		/// Gets a default instance factory that uses Activator.CreateInstance to create instances.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
		public static readonly XamlInstanceFactory DefaultInstanceFactory = new XamlInstanceFactory();
		
		/// <summary>
		/// Creates a new CustomInstanceFactory instance.
		/// </summary>
		protected XamlInstanceFactory()
		{
		}

		/// <summary>
		/// A Instance Factory that uses XAML to instanciate the Control!
		/// So you can add the 
		/// </summary>
		public virtual object CreateInstance(Type type, params object[] arguments)
		{
			var txt = @"<ContentControl xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"">
<ContentControl.ResourceDictionary>
<ResourceDictionary>
<ResourceDictionary.MergedDictionarys>
</ResourceDictionary.MergedDictionarys>
</ResourceDictionary>
</ContentControl.ResourceDictionary>
<a:{0} xmlns:a=""clr-namespace:{1};assembly={2}"" /></ContentControl>";

			var xaml = string.Format(txt, type.Name, type.Namespace, type.Assembly.GetName().Name);
			var contentControl = XamlServices.Load(new XamlXmlReader(new StringReader(xaml))) as ContentControl;

			return contentControl.Content;

		}
	}
}
