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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using ICSharpCode.WpfDesign.Interfaces;

namespace ICSharpCode.WpfDesign
{
	/// <summary>
	/// Represents a property of a DesignItem.
	/// All changes done via the DesignItemProperty class are represented in the underlying model (e.g. XAML).
	/// All such changes are recorded in the currently running designer transaction (<see cref="ChangeGroup"/>),
	/// enabling Undo/Redo support.
	/// Warning: Changes directly done to control instances might not be reflected in the model.
	/// </summary>
	public abstract class DesignItemProperty : INotifyPropertyChanged
	{
		/// <summary>
		/// Gets the property name.
		/// </summary>
		public abstract string Name { get; }
		
		/// <summary>
		/// Gets the return type of the property.
		/// </summary>
		public abstract Type ReturnType { get; }
		
		/// <summary>
		/// Gets the type that declares the property.
		/// </summary>
		public abstract Type DeclaringType { get; }
		
		/// <summary>
		/// Gets the category of the property.
		/// </summary>
		public abstract string Category { get; }
		
		/// <summary>
		/// Gets the type converter used to convert property values to/from string.
		/// </summary>
		public virtual TypeConverter TypeConverter {
			get { return TypeDescriptor.GetConverter(this.ReturnType); }
		}
		
		/// <summary>
		/// Gets if the property represents a collection.
		/// </summary>
		public abstract bool IsCollection { get; }
		
		/// <summary>
		/// Gets if the property represents an event.
		/// </summary>
		public abstract bool IsEvent { get; }
		
		/// <summary>
		/// Gets the elements represented by the collection.
		/// </summary>
		public abstract IObservableList<DesignItem> CollectionElements { get; }
		
		/// <summary>
		/// Gets the value of the property. This property returns null if the value is not set,
		/// or if the value is set to a primitive value.
		/// </summary>
		public abstract DesignItem Value { get; }
		
		/// <summary>
		/// Gets the string value of the property. This property returns null if the value is not set,
		/// or if the value is set to a non-primitive value (i.e. represented by a <see cref="DesignItem"/>, accessible through <see cref="Value"/> property).
		/// </summary>
		public abstract string TextValue { get; }
		
		/// <summary>
		/// Is raised when the value of the property changes (by calling <see cref="SetValue"/> or <see cref="Reset"/>).
		/// </summary>
		public abstract event EventHandler ValueChanged;
		
		/// <summary>
		/// Is raised when the <see cref="ValueOnInstance"/> property changes.
		/// This event is not raised when the value is changed without going through the designer infrastructure.
		/// </summary>
		public abstract event EventHandler ValueOnInstanceChanged;
		
		/// <summary>
		/// Gets/Sets the value of the property on the designed instance.
		/// If the property is not set, this returns the default value.
		/// </summary>
		public abstract object ValueOnInstance { get; }
		
		/// <summary>
		/// Sets the value of the property.
		/// </summary>
		public abstract void SetValue(object value);
		
		/// <summary>
		/// Gets if the property is set on the design item.
		/// </summary>
		public abstract bool IsSet { get; }
		
		/// <summary>
		/// Occurs when the value of the IsSet property changes.
		/// </summary>
		public abstract event EventHandler IsSetChanged;
		
		/// <summary>
		/// Resets the property value to the default, possibly removing it from the list of properties.
		/// </summary>
		public abstract void Reset();

		/// <summary>
		/// Gets the parent design item.
		/// </summary>
		public abstract DesignItem DesignItem { get; }

		/// <summary>
		/// Gets the dependency property, or null if this property does not represent a dependency property.
		/// </summary>
		public abstract DependencyProperty DependencyProperty { get; }

		/// <summary>
		/// Gets if this property is considered "advanced" and should be hidden by default in a property grid.
		/// </summary>
		public virtual bool IsAdvanced { get { return false; } }

		/// <summary>
		/// Gets the full name of the property (DeclaringType.FullName + "." + Name).
		/// </summary>
		public string FullName  {
			get {
				return DeclaringType.FullName + "." + Name;
			}
		}

		/// <summary>
		/// Gets the View of the Value or the ValueOnInstance 
		/// (e.g. a Content Property has a DesignItem if it's a Complex Object, if it's only a Text it only has ValueOnInstance)
		/// </summary>		
        public object ValueOnInstanceOrView
        {
            get { return Value == null ? ValueOnInstance : Value.View; }
        }

		/// <summary>
		/// Gets the full name of the dependency property. Returns the normal FullName if the property
		/// isn't a dependency property.
		/// </summary>
		public string DependencyFullName {
			get {
				if (DependencyProperty != null) {
					return DependencyProperty.GetFullName();
				}
				return FullName;
			}
		}

		/// <summary>
		/// It's raised when a property value changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		/// Raises the Property changed Event for the speciefied Property
		/// </summary>
		/// <param name="propertyName"></param>
	    protected virtual void OnPropertyChanged(string propertyName)
	    {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	/// <summary>
	/// Represents a collection of design item properties.
	/// </summary>
	public abstract class DesignItemPropertyCollection : IEnumerable<DesignItemProperty>
	{
		/// <summary>
		/// Gets the property with the specified name.
		/// </summary>
		public DesignItemProperty this[string name] {
			get { return GetProperty(name); }
		}
		
		/// <summary>
		/// Gets the design item property representing the specified dependency property.
		/// The property must not be an attached property.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1043")]
		public DesignItemProperty this[DependencyProperty dependencyProperty] {
			get {
				return GetProperty(dependencyProperty);
			}
		}
		
		/// <summary>
		/// Gets the design item property with the specified name.
		/// </summary>
		public abstract DesignItemProperty GetProperty(string name);
		
		/// <summary>
		/// Gets the attached property on the specified owner with the specified name.
		/// </summary>
		public abstract DesignItemProperty GetAttachedProperty(Type ownerType, string name);
		
		/// <summary>
		/// Gets the design item property representing the specified dependency property.
		/// The property must not be an attached property.
		/// </summary>
		public DesignItemProperty GetProperty(DependencyProperty dependencyProperty)
		{
			if (dependencyProperty == null)
				throw new ArgumentNullException("dependencyProperty");
			return GetProperty(dependencyProperty.Name);
		}
		
		/// <summary>
		/// Gets the design item property representing the specified attached dependency property.
		/// </summary>
		public DesignItemProperty GetAttachedProperty(DependencyProperty dependencyProperty)
		{
			if (dependencyProperty == null)
				throw new ArgumentNullException("dependencyProperty");
			return GetAttachedProperty(dependencyProperty.OwnerType, dependencyProperty.Name);
		}
		
		/// <summary>
		/// Gets an enumerator to enumerate the properties that have a non-default value.
		/// </summary>
		public abstract IEnumerator<DesignItemProperty> GetEnumerator();
		
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
