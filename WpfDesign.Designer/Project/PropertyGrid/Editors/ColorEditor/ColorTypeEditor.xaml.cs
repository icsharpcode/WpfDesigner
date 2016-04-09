// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.Windows;
using System.Windows.Media;
using ICSharpCode.WpfDesign.PropertyGrid;
using ICSharpCode.WpfDesign.Designer.themes;
using System.Windows.Input;
using System.ComponentModel;
using ICSharpCode.WpfDesign.Designer.PropertyGrid.Editors.BrushEditor;
using System.Linq;

namespace ICSharpCode.WpfDesign.Designer.PropertyGrid.Editors.ColorEditor
{
	[TypeEditor(typeof(Color))]
	public partial class ColorTypeEditor
	{
		public ColorTypeEditor()
		{
			SpecialInitializeComponent();
		}

		/// <summary>
		/// Fixes InitializeComponent with multiple Versions of same Assembly loaded
		/// </summary>
		public void SpecialInitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri(VersionedAssemblyResourceDictionary.GetXamlNameForType(this.GetType()), UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}

			this.InitializeComponent();
		}

		private ChangeGroup _changeGroup = null;

		protected override void OnMouseUp(MouseButtonEventArgs e)
		{
			var pnode = this.DataContext as PropertyNode;
			var colorEditorPopup = new ColorEditorPopup();
			colorEditorPopup.PlacementTarget = this;
			colorEditorPopup.IsOpen = true;
			colorEditorPopup.solidBrushEditor.Color = (Color)pnode.Value;
			colorEditorPopup.Closed += ColorEditorPopup_Closed;
			DependencyPropertyDescriptor.FromProperty(SolidBrushEditor.ColorProperty, typeof(SolidBrushEditor))
				.AddValueChanged(colorEditorPopup.solidBrushEditor, 
				(s, ee) => {
					if (_changeGroup == null) {
						_changeGroup = pnode.Context.OpenGroup("change color",
											   pnode.Properties.Select(p => p.DesignItem).ToArray());

					}
					pnode.Value = colorEditorPopup.solidBrushEditor.Color;
				});
		}

		private void ColorEditorPopup_Closed(object sender, EventArgs e)
		{
			if (_changeGroup != null) {
				_changeGroup.Commit();
				_changeGroup = null;
			}
		}
	}
}