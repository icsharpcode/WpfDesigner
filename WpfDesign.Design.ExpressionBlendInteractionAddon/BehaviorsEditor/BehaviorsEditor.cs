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
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ICSharpCode.WpfDesign.Designer.ExpressionBlendInteractionAddon.BehaviorsEditor
{
	public class BehaviorsEditor : Control
	{
		private ListBox partListBox;
		 
		static BehaviorsEditor()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BehaviorsEditor), new FrameworkPropertyMetadata(typeof(BehaviorsEditor)));
		}

		public static readonly DependencyProperty SelectedItemsProperty =
			DependencyProperty.Register("SelectedItems", typeof(IEnumerable<DesignItem>), typeof(BehaviorsEditor));

		public IEnumerable<DesignItem> SelectedItems
		{
			get { return (IEnumerable<DesignItem>)GetValue(SelectedItemsProperty); }
			set { SetValue(SelectedItemsProperty, value); }
		}

		protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			base.OnPropertyChanged(e);
			if (e.Property == SelectedItemsProperty) {
				UpdateBehaviors();
			}
		}

		public override void OnApplyTemplate()
		{
			partListBox = GetTemplateChild("PART_ListBox") as ListBox;
			partListBox.MouseDoubleClick += PartListBox_MouseDoubleClick; ;

			base.OnApplyTemplate();
		}

		private void PartListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var designerItem = partListBox.SelectedItem as DesignItem;
			if (designerItem != null)
			{
				designerItem.Services.Selection.SetSelectedComponents(new[] { designerItem });
			}
		}

		private void UpdateBehaviors()
		{
			if (partListBox != null) {
				partListBox.ItemsSource = null;
				if (SelectedItems != null && SelectedItems.Any()) {
					partListBox.ItemsSource = InteractionHelper.GetBehaviors(SelectedItems);
				}
			}
		}
	}
}
