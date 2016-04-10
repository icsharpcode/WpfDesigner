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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using ICSharpCode.WpfDesign.Designer.themes;

namespace ICSharpCode.WpfDesign.Designer.PropertyGrid.Editors.FormatedTextEditor
{
	/// <summary>
	/// Interaktionslogik für RichTextBoxToolbar.xaml
	/// </summary>
	public partial class RichTextBoxToolbar
	{
		public RichTextBoxToolbar()
		{
			SpecialInitializeComponent();

			cmbFontFamily.SelectionChanged += (s, e) =>
			{
				if (cmbFontFamily.SelectedValue != null && RichTextBox != null)
				{
					TextRange tr = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
					var value = cmbFontFamily.SelectedValue;
					tr.ApplyPropertyValue(TextElement.FontFamilyProperty, value);
				}
			};

			cmbFontSize.SelectionChanged += (s, e) =>
			{
				if (cmbFontSize.SelectedValue != null && RichTextBox != null)
				{
					TextRange tr = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
					var value = ((ComboBoxItem)cmbFontSize.SelectedValue).Content.ToString();
					tr.ApplyPropertyValue(TextElement.FontSizeProperty, double.Parse(value));
				}
			};
			cmbFontSize.AddHandler(TextBoxBase.TextChangedEvent, new TextChangedEventHandler((s, e) =>
			{
				if (!string.IsNullOrEmpty(cmbFontSize.Text) && RichTextBox != null)
				{
					TextRange tr = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
					tr.ApplyPropertyValue(TextElement.FontSizeProperty, double.Parse(cmbFontSize.Text));
				}
			}));
		}

		public void SetValuesFromTextBlock(TextBlock textBlock)
		{
			cmbFontFamily.Text = textBlock.FontFamily.ToString();
			cmbFontSize.Text = textBlock.FontSize.ToString();
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

		public RichTextBox RichTextBox
		{
			get { return (RichTextBox) GetValue(RichTextBoxProperty); }
			set { SetValue(RichTextBoxProperty, value); }
		}

		public static readonly DependencyProperty RichTextBoxProperty =
			DependencyProperty.Register("RichTextBox", typeof (RichTextBox), typeof (RichTextBoxToolbar),
				new PropertyMetadata(null));

		

	}
}
