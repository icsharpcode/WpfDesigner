using System;
using System.Windows;
using System.Windows.Controls;

namespace ICSharpCode.WpfDesign.Designer.PropertyGrid.Editors
{
	public class CollectionTemplateSelector : DataTemplateSelector
	{
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			FrameworkElement element = container as FrameworkElement;
			if (element != null && item != null && item is DesignItem)
			{
				var di = item as DesignItem;
				if (di.Component is Point)
				{
					return element.FindResource("PointTemplate") as DataTemplate;
				}
				else if (di.Component is String)
				{
					return element.FindResource("StringTemplate") as DataTemplate;
				}
				return element.FindResource("DefaultTemplate") as DataTemplate;
			}

			return null;
		}
	}
}
