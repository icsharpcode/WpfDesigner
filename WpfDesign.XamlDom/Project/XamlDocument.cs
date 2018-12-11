﻿// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
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
using System.Windows.Markup;
using System.Xml;
using System.IO;
using System.Linq;
using System.Windows.Media;
using System.Collections.Generic;
using System.Reflection;

namespace ICSharpCode.WpfDesign.XamlDom
{
	/// <summary>
	/// Represents a .xaml document.
	/// </summary>
	public sealed class XamlDocument
	{
		static XamlDocument()
		{
			_colorBrushDictionary = new Dictionary<Color, string>();
			foreach (var brushProp in typeof(Brushes).GetProperties(BindingFlags.Static|BindingFlags.Public).Where(p => p.PropertyType == typeof(SolidColorBrush)))
			{
				var brush = brushProp.GetValue(null, null) as SolidColorBrush;
				if (!_colorBrushDictionary.ContainsKey(brush.Color)) {
					_colorBrushDictionary.Add(brush.Color, brushProp.Name);
				}
			}
		}

		private static Dictionary<Color, string> _colorBrushDictionary;

		XmlDocument _xmlDoc;
		XamlObject _rootElement;
		IServiceProvider _serviceProvider;
		private string _currentProjectAssemblyName; 

		XamlTypeFinder _typeFinder;

		int namespacePrefixCounter;
		
		internal XmlDocument XmlDocument {
			get { return _xmlDoc; }
		}
		
		/// <summary>
		/// Gets the type finder used for this XAML document.
		/// </summary>
		public XamlTypeFinder TypeFinder {
			get { return _typeFinder; }
		}
		
		/// <summary>
		/// Gets the service provider used for markup extensions in this document.
		/// </summary>
		public IServiceProvider ServiceProvider {
			get { return _serviceProvider; }
		}

		/// <summary>
		/// Gets the Current Projects Assembly Name (if it has any).
		/// </summary>
		public string CurrentProjectAssemblyName
		{
			get { return _currentProjectAssemblyName; }
		}

		/// <summary>
		/// Gets the type descriptor context used for type conversions.
		/// </summary>
		/// <param name="containingObject">The containing object, used when the
		/// type descriptor context needs to resolve an XML namespace.</param>
		internal ITypeDescriptorContext GetTypeDescriptorContext(XamlObject containingObject)
		{
			IServiceProvider serviceProvider;
			if (containingObject != null) {
				if (containingObject.OwnerDocument != this)
					throw new ArgumentException("Containing object must belong to the document!");
				serviceProvider = containingObject.ServiceProvider;
			} else {
				serviceProvider = this.ServiceProvider;
			}
			return new DummyTypeDescriptorContext(serviceProvider);
		}
		
		sealed class DummyTypeDescriptorContext : ITypeDescriptorContext
		{
			readonly IServiceProvider baseServiceProvider;
			
			public DummyTypeDescriptorContext(IServiceProvider serviceProvider)
			{
				this.baseServiceProvider = serviceProvider;
			}
			
			public IContainer Container {
				get { return null; }
			}
			
			public object Instance {
				get; set;
			}
			
			public PropertyDescriptor PropertyDescriptor {
				get { return null; }
			}
			
			public bool OnComponentChanging()
			{
				return false;
			}
			
			public void OnComponentChanged()
			{
			}
			
			public object GetService(Type serviceType)
			{
				return baseServiceProvider.GetService(serviceType);
			}
		}
		
		/// <summary>
		/// Gets the root xaml object.
		/// </summary>
		public XamlObject RootElement {
			get { return _rootElement; }
		}
		
		/// <summary>
		/// Gets the object instance created by the root xaml object.
		/// </summary>
		public object RootInstance {
			get { return (_rootElement != null) ? _rootElement.Instance : null; }
		}
		
		/// <summary>
		/// Saves the xaml document into the <paramref name="writer"/>.
		/// </summary>
		public void Save(XmlWriter writer)
		{
			if (writer == null)
				throw new ArgumentNullException("writer");
			_xmlDoc.Save(writer);
		}
		
		/// <summary>
		/// Internal constructor, used by XamlParser.
		/// </summary>
		internal XamlDocument(XmlDocument xmlDoc, XamlParserSettings settings)
		{
			this._xmlDoc = xmlDoc;
			this._typeFinder = settings.TypeFinder;
			this._serviceProvider = settings.ServiceProvider;
			this._currentProjectAssemblyName = settings.CurrentProjectAssemblyName;
		}
		
		/// <summary>
		/// Called by XamlParser to finish initializing the document.
		/// </summary>
		internal void ParseComplete(XamlObject rootElement)
		{
			this._rootElement = rootElement;
		}
		
		/// <summary>
		/// Create an XamlObject from the instance.
		/// </summary>
		public XamlObject CreateObject(object instance)
		{
			return (XamlObject)CreatePropertyValue(instance, null);
		}

		/// <summary>
		/// Create an XamlObject from the instance.
		/// </summary>
		public XamlObject CreateObject(XamlObject parent, object instance)
		{
			return (XamlObject)CreatePropertyValue(parent, instance, null);
		}

		/// <summary>
		/// Creates a value that represents {x:Null}
		/// </summary>
		public XamlPropertyValue CreateNullValue()
		{
			return CreateObject(new NullExtension());
		}

		/// <summary>
		/// Create a XamlPropertyValue for the specified value instance.
		/// </summary>
		public XamlPropertyValue CreatePropertyValue(object instance, XamlProperty forProperty)
		{
			return CreatePropertyValue(null, instance, forProperty);
		}

		/// <summary>
		/// Create a XamlPropertyValue for the specified value instance.
		/// </summary>
		public XamlPropertyValue CreatePropertyValue(XamlObject parent, object instance, XamlProperty forProperty)
		{
			if (instance == null)
				throw new ArgumentNullException("instance");
			
			Type elementType = instance.GetType();
			TypeConverter c = TypeDescriptor.GetConverter(instance);
			var ctx = new DummyTypeDescriptorContext(this.ServiceProvider);
			ctx.Instance = instance;
			bool hasStringConverter = c.CanConvertTo(ctx, typeof(string)) && c.CanConvertFrom(typeof(string));
			if (forProperty != null && hasStringConverter) {

				if (instance is SolidColorBrush && _colorBrushDictionary.ContainsKey(((SolidColorBrush)instance).Color)) {
					var name = _colorBrushDictionary[((SolidColorBrush)instance).Color];
					return new XamlTextValue(this, name);
				}

				return new XamlTextValue(this, c.ConvertToInvariantString(ctx, instance));
			}

			string ns = GetNamespaceFor(elementType);
			string prefix = GetPrefixForNamespace(ns);
			if (parent != null)
				prefix = GetPrefixForNamespace(parent.XmlElement, ns);

			XmlElement xml = _xmlDoc.CreateElement(prefix, elementType.Name, ns);

			if (hasStringConverter && (XamlObject.GetContentPropertyName(elementType) != null || IsNativeType(instance))) {
				xml.InnerText = c.ConvertToInvariantString(instance);
			} else if (instance is Brush && forProperty != null) {  // TODO: this is a hacky fix, because Brush Editor doesn't
																	// edit Design Items and so we have no XML, only the Brush 
																	// object and we need to parse the Brush to XAML!
				var s = new MemoryStream();
				XamlWriter.Save(instance, s);
				s.Seek(0, SeekOrigin.Begin);
				XmlDocument doc = new XmlDocument();
				doc.Load(s);
				xml = (XmlElement) _xmlDoc.ImportNode(doc.DocumentElement, true);

				var attLst = xml.Attributes.Cast<XmlAttribute>().ToList();
				foreach (XmlAttribute att in attLst)
				{
					if (att.Name.StartsWith(XamlConstants.Xmlns))
					{
						var rootAtt = doc.DocumentElement.GetAttributeNode(att.Name);
						if (rootAtt != null && rootAtt.Value == att.Value)
						{
							xml.Attributes.Remove(att);
						}
					}
				}
			}

			return new XamlObject(this, xml, elementType, instance);
		}
		
		internal string GetNamespaceFor(Type type, bool getClrNamespace = false)
		{
			if (type == typeof (DesignTimeProperties))
				return XamlConstants.DesignTimeNamespace;
			if (type == typeof (MarkupCompatibilityProperties))
				return XamlConstants.MarkupCompatibilityNamespace;
			if (type == typeof(XamlNamespaceProperties))
				return XamlConstants.Xaml2009Namespace;

			return _typeFinder.GetXmlNamespaceFor(type.Assembly, type.Namespace, getClrNamespace);
		}
		
		internal List<string> GetNamespacesFor(Type type, bool getClrNamespace = false)
		{
			if (type == typeof (DesignTimeProperties))
				return new List<string>(){XamlConstants.DesignTimeNamespace};
			if (type == typeof (MarkupCompatibilityProperties))
				return new List<string>(){XamlConstants.MarkupCompatibilityNamespace};
			if (type == typeof(XamlNamespaceProperties))
				return new List<string>() { XamlConstants.Xaml2009Namespace, XamlConstants.XamlNamespace };

			return _typeFinder.GetXmlNamespacesFor(type.Assembly, type.Namespace, getClrNamespace);
		}

		internal string GetPrefixForNamespace(string @namespace)
		{
			return GetPrefixForNamespace(_xmlDoc.DocumentElement, @namespace);
		}

		internal string GetPrefixForNamespace(XmlElement xmlElement, string @namespace)
		{
			//if (@namespace == XamlConstants.PresentationNamespace)
			//{
			//	return null;
			//}

			string prefix = xmlElement.GetPrefixOfNamespace(@namespace);

			if (xmlElement.NamespaceURI == @namespace && xmlElement.Prefix == String.Empty)
			{
				return string.Empty;
			}
   
			if (String.IsNullOrEmpty(prefix))
			{
				prefix = _typeFinder.GetPrefixForXmlNamespace(@namespace);

				string existingNamespaceForPrefix = null;
				if (!String.IsNullOrEmpty(prefix))
				{
					existingNamespaceForPrefix = xmlElement.GetNamespaceOfPrefix(prefix);
				}

				if (String.IsNullOrEmpty(prefix) ||
				    !String.IsNullOrEmpty(existingNamespaceForPrefix) &&
				    existingNamespaceForPrefix != @namespace)
				{
					do
					{
						prefix = "Controls" + namespacePrefixCounter++;
					} while (!String.IsNullOrEmpty(xmlElement.GetNamespaceOfPrefix(prefix)));
				}

				string xmlnsPrefix = xmlElement.GetPrefixOfNamespace(XamlConstants.XmlnsNamespace);
				System.Diagnostics.Debug.Assert(!String.IsNullOrEmpty(xmlnsPrefix));

				xmlElement.SetAttribute(xmlnsPrefix + ":" + prefix, @namespace);
				
				if (@namespace == XamlConstants.DesignTimeNamespace)
				{
					var ignorableProp = new XamlProperty(this._rootElement, new XamlDependencyPropertyInfo(MarkupCompatibilityProperties.IgnorableProperty, true, null));
					ignorableProp.SetAttribute(prefix);
				}
			}

			return prefix;
		}

		internal string GetNamespaceForPrefix(string prefix)
		{
			return _xmlDoc.DocumentElement.GetNamespaceOfPrefix(prefix);
		}

		bool IsNativeType(object instance)
		{
			return instance.GetType().Assembly == typeof(String).Assembly || instance.GetType().IsEnum;
		}
	}
}
