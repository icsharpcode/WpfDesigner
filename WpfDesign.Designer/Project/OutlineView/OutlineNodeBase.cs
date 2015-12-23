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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using ICSharpCode.WpfDesign.Designer.Xaml;
using ICSharpCode.WpfDesign.XamlDom;

namespace ICSharpCode.WpfDesign.Designer.OutlineView
{
	/// <summary>
	/// Description of OutlineNodeBase.
	/// </summary>
	public abstract class OutlineNodeBase : INotifyPropertyChanged, IOutlineNode
	{
		protected abstract void UpdateChildren();
		protected abstract void UpdateChildrenCollectionChanged(NotifyCollectionChangedEventArgs e);
		//Used to check if element can enter other containers
		protected static PlacementType DummyPlacementType;

		private bool _collectionWasChanged;

		protected OutlineNodeBase(DesignItem designItem)
		{
			DesignItem = designItem;

			bool hidden = false;
			try
			{
				hidden = (bool)designItem.Properties.GetAttachedProperty(DesignTimeProperties.IsHiddenProperty).ValueOnInstance;
			}
			catch (Exception)
			{ }
			if (hidden) {
				_isDesignTimeVisible = false;
			}

			bool locked = false;
			try
			{
				locked = (bool)designItem.Properties.GetAttachedProperty(DesignTimeProperties.IsLockedProperty).ValueOnInstance;
			}
			catch (Exception)
			{ }
			if (locked) {
				_isDesignTimeLocked = true;
			}

			//TODO

			DesignItem.NameChanged += new EventHandler(DesignItem_NameChanged);

			if (DesignItem.ContentProperty != null && DesignItem.ContentProperty.IsCollection)
			{
				DesignItem.ContentProperty.CollectionElements.CollectionChanged += CollectionElements_CollectionChanged;
				DesignItem.PropertyChanged += new PropertyChangedEventHandler(DesignItem_PropertyChanged);
			}
			else
			{
				DesignItem.PropertyChanged += new PropertyChangedEventHandler(DesignItem_PropertyChanged);

			}

		}
		 
		public DesignItem DesignItem { get; set; }

		public ISelectionService SelectionService
		{
			get { return DesignItem.Services.Selection; }
		}

		bool isExpanded = true;

		public bool IsExpanded
		{
			get
			{
				return isExpanded;
			}
			set
			{
				isExpanded = value;
				RaisePropertyChanged("IsExpanded");
			}
		}

		bool isSelected;

		public bool IsSelected
		{
			get
			{
				return isSelected;
			}
			set
			{
				if (isSelected != value) {
					isSelected = value;
					SelectionService.SetSelectedComponents(new[] { DesignItem },
					                                       value ? SelectionTypes.Add : SelectionTypes.Remove);
					RaisePropertyChanged("IsSelected");
				}
			}
		}

		bool _isDesignTimeVisible = true;

		public bool IsDesignTimeVisible
		{
			get
			{
				return _isDesignTimeVisible;
			}
			set
			{
				_isDesignTimeVisible = value;

				RaisePropertyChanged("IsDesignTimeVisible");

				if (!value)
					DesignItem.Properties.GetAttachedProperty(DesignTimeProperties.IsHiddenProperty).SetValue(true);
				else
					DesignItem.Properties.GetAttachedProperty(DesignTimeProperties.IsHiddenProperty).Reset();
			}
		}

		bool _isDesignTimeLocked = false;

		public bool IsDesignTimeLocked
		{
			get
			{
				return _isDesignTimeLocked;
			}
			set
			{
				_isDesignTimeLocked = value;
				((XamlDesignItem)DesignItem).IsDesignTimeLocked = _isDesignTimeLocked;

				RaisePropertyChanged("IsDesignTimeLocked");

				//				if (value)
				//					DesignItem.Properties.GetAttachedProperty(DesignTimeProperties.IsLockedProperty).SetValue(true);
				//				else
				//					DesignItem.Properties.GetAttachedProperty(DesignTimeProperties.IsLockedProperty).Reset();
			}
		}

		ObservableCollection<IOutlineNode> children = new ObservableCollection<IOutlineNode>();

		public ObservableCollection<IOutlineNode> Children
		{
			get { return children; }
		}

		public string Name
		{
			get
			{
				return DesignItem.Services.GetService<IOutlineNodeNameService>().GetOutlineNodeName(DesignItem);
			}
		}

		void DesignItem_NameChanged(object sender, EventArgs e)
		{
			RaisePropertyChanged("Name");
		}

		void DesignItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == DesignItem.ContentPropertyName) {
				if (!_collectionWasChanged)	{
					UpdateChildren();
				}
				_collectionWasChanged = false;
			}
		}

		private void CollectionElements_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			_collectionWasChanged = true;
			UpdateChildrenCollectionChanged(e);
		}



		public bool CanInsert(IEnumerable<IOutlineNode> nodes, IOutlineNode after, bool copy)
		{
			var placementBehavior = DesignItem.GetBehavior<IPlacementBehavior>();
			if (placementBehavior == null)
				return false;
			var operation = PlacementOperation.Start(nodes.Select(node => node.DesignItem).ToArray(), DummyPlacementType);
			if (operation != null) {
				bool canEnter = placementBehavior.CanEnterContainer(operation, true);
				operation.Abort();
				return canEnter;
			}
			return false;
		}

		public virtual void Insert(IEnumerable<IOutlineNode> nodes, IOutlineNode after, bool copy)
		{
			using (var moveTransaction = DesignItem.Context.OpenGroup("Item moved in outline view", nodes.Select(n => n.DesignItem).ToList()))
			{
				if (copy) {
					nodes = nodes.Select(n => OutlineNode.Create(n.DesignItem.Clone())).ToList();
				} else {
					foreach (var node in nodes) {
						node.DesignItem.Remove();
					}
				}

				var index = after == null ? 0 : Children.IndexOf(after) + 1;

				var content = DesignItem.ContentProperty;
				if (content.IsCollection) {
					foreach (var node in nodes) {
						content.CollectionElements.Insert(index++, node.DesignItem);
					}
				} else {
					content.SetValue(nodes.First().DesignItem);
				}
				moveTransaction.Commit();
			}
		}

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		public void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		#endregion
	}
}
