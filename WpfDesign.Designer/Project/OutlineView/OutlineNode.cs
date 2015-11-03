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
using System.Collections.Specialized;
using System.Linq;

namespace ICSharpCode.WpfDesign.Designer.OutlineView
{ 
	public class OutlineNode: OutlineNodeBase
	{
		//TODO: Reset with DesignContext
		static Dictionary<DesignItem, IOutlineNode> outlineNodes = new Dictionary<DesignItem, IOutlineNode>();

		protected OutlineNode(DesignItem designitem): base(designitem)
		{
			UpdateChildren();
			SelectionService.SelectionChanged += new EventHandler<DesignItemCollectionEventArgs>(Selection_SelectionChanged);
		}

		static OutlineNode()
		{
			DummyPlacementType = PlacementType.Register("DummyPlacement");
		}

		public static IOutlineNode Create(DesignItem designItem)
		{
			IOutlineNode node = null;
			if (designItem != null && !outlineNodes.TryGetValue(designItem, out node)) {
				node = new OutlineNode(designItem);
				outlineNodes[designItem] = node;
			}
			return node;
		}

		void Selection_SelectionChanged(object sender, DesignItemCollectionEventArgs e)
		{
			IsSelected = DesignItem.Services.Selection.IsComponentSelected(DesignItem);
		}


		protected override void UpdateChildren()
		{
			Children.Clear();
			
			if (DesignItem.ContentPropertyName != null) {
				var content = DesignItem.ContentProperty;
				if (content.IsCollection) {
					UpdateChildrenCore(content.CollectionElements);
				} else {
					if (content.Value != null) {
						UpdateChildrenCore(new[] { content.Value });
					}
				}
			}	
		}

		protected override void UpdateChildrenCollectionChanged(NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Remove) {
				foreach (var oldItem in e.OldItems) {
					var item = Children.FirstOrDefault(x => x.DesignItem == oldItem);
					if (item != null) {
						Children.Remove(item);
					}
				}
			} else if (e.Action == NotifyCollectionChangedAction.Add) {
				UpdateChildrenCore(e.NewItems.Cast<DesignItem>(), e.NewStartingIndex);				
			}
		}

		void UpdateChildrenCore(IEnumerable<DesignItem> items, int index = -1)
		{
			foreach (var item in items) {
				if (ModelTools.CanSelectComponent(item)) {
					if (Children.All(x => x.DesignItem != item)) {
						var node = OutlineNode.Create(item);
						if (index>-1)
							Children.Insert(index++, node);
						else
							Children.Add(node);
					}
				} else {
					var content = item.ContentProperty;
					if (content != null) {
						if (content.IsCollection) {
							UpdateChildrenCore(content.CollectionElements);
						} else {
							if (content.Value != null) {
								UpdateChildrenCore(new[] { content.Value });
							}
						}
					}
				}
			}
		}
	}
}
