using AvalonDock.Layout;
using System.Windows;
using System.Windows.Controls;

namespace ICSharpCode.XamlDesigner.Converters
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
