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

using System.Collections.Generic;
using ICSharpCode.WpfDesign.Extensions;
using System.Windows.Controls;
using System.Windows;
using ICSharpCode.WpfDesign.Designer.Controls;

namespace ICSharpCode.WpfDesign.Designer.Extensions
{
	[ExtensionFor(typeof(object))]
	public class OnlyDeletePlacementBehavior : BehaviorExtension, IPlacementBehavior
	{
		static OnlyDeletePlacementBehavior()
		{ }

		protected override void OnInitialized()
		{
			base.OnInitialized();
			if (ExtendedItem.Component is Panel || ExtendedItem.Component is Control || ExtendedItem.Component is Border || ExtendedItem.Component is Viewbox)
				return;

			ExtendedItem.AddBehavior(typeof(IPlacementBehavior), this);
		}

		public virtual bool CanPlace(IEnumerable<DesignItem> childItems, PlacementType type, PlacementAlignment position)
		{
			return type == PlacementType.Delete;
		}

		public virtual void BeginPlacement(PlacementOperation operation)
		{
		}

		public virtual void EndPlacement(PlacementOperation operation)
		{
		}

		public virtual Rect GetPosition(PlacementOperation operation, DesignItem item)
		{
			return new Rect();
		}

		public Rect GetPositionRelativeToContainer(PlacementOperation operation, DesignItem item)
		{
			return new Rect();
		}

		public virtual void BeforeSetPosition(PlacementOperation operation)
		{
		}

		public virtual bool CanPlaceItem(PlacementInformation info)
		{
			return false;
		}

		public virtual void SetPosition(PlacementInformation info)
		{
		}

		public virtual bool CanLeaveContainer(PlacementOperation operation)
		{
			return true;
		}

		public virtual void LeaveContainer(PlacementOperation operation)
		{
			foreach (var item in operation.PlacedItems) {
				if (item.Item.ParentProperty.IsCollection) {
					item.Item.ParentProperty.CollectionElements.Remove(item.Item);
				}
				else {
					item.Item.ParentProperty.Reset();
				}
			}
		}

		private static InfoTextEnterArea infoTextEnterArea;

		public virtual bool CanEnterContainer(PlacementOperation operation, bool shouldAlwaysEnter)
		{
			return false;
		}

		public virtual void EnterContainer(PlacementOperation operation)
		{
		}

		public virtual Point PlacePoint(Point point)
		{
			return new Point();
		}
	}
}
