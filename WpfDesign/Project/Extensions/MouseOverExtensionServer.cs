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

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ICSharpCode.WpfDesign.Adorners;

namespace ICSharpCode.WpfDesign.Extensions
{
	/// <summary>
	/// Applies an extension to the hovered components.
	/// </summary>
	public class MouseOverExtensionServer : DefaultExtensionServer
	{
		private DesignItem _lastItem = null;

		/// <summary>
		/// Is called after the extension server is initialized and the Context property has been set.
		/// </summary>
		protected override void OnInitialized()
		{
			base.OnInitialized();
			var panel = this.Services.GetService<IDesignPanel>() as FrameworkElement;
			if (panel != null) {
				((FrameworkElement) this.Services.DesignPanel).PreviewMouseMove += MouseOverExtensionServer_PreviewMouseMove;
				((FrameworkElement) this.Services.DesignPanel).MouseLeave += MouseOverExtensionServer_MouseLeave;
				Services.Selection.SelectionChanged += OnSelectionChanged;
			}
		}

		void OnSelectionChanged(object sender, DesignItemCollectionEventArgs e)
		{
			ReapplyExtensions(e.Items);
		}

		private void MouseOverExtensionServer_MouseLeave(object sender, MouseEventArgs e)
		{
			if (_lastItem != null) {
				var oldLastItem = _lastItem;
				_lastItem = null;
				ReapplyExtensions(new[] { oldLastItem });
			}
		}

		private void MouseOverExtensionServer_PreviewMouseMove(object sender, MouseEventArgs e)
		{
			DesignItem element = null;
			VisualTreeHelper.HitTest(((FrameworkElement)this.Services.DesignPanel),
				potentialHitTestTarget =>
				{
					if (potentialHitTestTarget is IAdornerLayer)
						return HitTestFilterBehavior.ContinueSkipSelfAndChildren;

					var item = this.Services.Component.GetDesignItem(potentialHitTestTarget);
					if (item == null)
						return HitTestFilterBehavior.ContinueSkipSelf;

					if (element == null || item.Parent == element) {
						element = item;
						return HitTestFilterBehavior.Continue;
					}

					var par = item.Parent;
					while (par != null) {
						if (par.Parent == element) {
							element = item;
							return HitTestFilterBehavior.Continue;
						}
						par = par.Parent;
					}

					return HitTestFilterBehavior.Stop;
				},
				result =>
				{
					return HitTestResultBehavior.Stop;
				},
				new PointHitTestParameters(e.GetPosition(((FrameworkElement)this.Services.DesignPanel))));

			var oldLastItem = _lastItem;
			_lastItem = element;
			if (oldLastItem != null && oldLastItem != element)
				ReapplyExtensions(new[] { oldLastItem, element});
			else {
				ReapplyExtensions(new[] { element });
			}
		}

		/// <summary>
		/// Gets if the item is selected.
		/// </summary>
		public override bool ShouldApplyExtensions(DesignItem extendedItem)
		{
			return extendedItem == _lastItem && !Services.Selection.IsComponentSelected(extendedItem);
		}
	}

}
