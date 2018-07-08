using System.Windows;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace ICSharpCode.XamlDesigner.AvalonDock
{
	class PanesTemplateSelector : DataTemplateSelector
	{
		public DataTemplate DocumentTemplate
		{
			get;
			set;
		}
		public override DataTemplate SelectTemplate(object item, DependencyObject container)
		{
			var itemAsLayoutContent = item as LayoutContent;

			if (item is Document)
				return DocumentTemplate;

			return base.SelectTemplate(item, container);
		}
	}
}
