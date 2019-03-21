// Copyright (c) 2019 AlphaSierraPapa for the SharpDevelop Team
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
using System.Windows.Controls;
using System.Windows.Media;

using ICSharpCode.WpfDesign.Adorners;
using ICSharpCode.WpfDesign.Extensions;

namespace ICSharpCode.WpfDesign.Designer.Extensions
{
	[ExtensionFor(typeof(FrameworkElement))]
	[ExtensionServer(typeof(MouseOverExtensionServer))]

	public class BorderForMouseOver : AdornerProvider
	{
		readonly AdornerPanel adornerPanel;

		public BorderForMouseOver()
		{
			adornerPanel = new AdornerPanel();
			adornerPanel.Order = AdornerOrder.Background;
			this.Adorners.Add(adornerPanel);
			var border = new Border();
			border.BorderThickness = new Thickness(1);
			border.BorderBrush = Brushes.DodgerBlue;
			border.Margin = new Thickness(-2);
			AdornerPanel.SetPlacement(border, AdornerPlacement.FillContent);
			adornerPanel.Children.Add(border);
		}
	}
}
