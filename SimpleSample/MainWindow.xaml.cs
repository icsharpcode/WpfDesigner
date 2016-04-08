using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using ICSharpCode.WpfDesign.Designer.Services;
using ICSharpCode.WpfDesign.Designer.Xaml;
using ICSharpCode.WpfDesign.XamlDom;

namespace SimpleSample
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static string xaml = @"<Grid 
xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
mc:Ignorable=""d""
x:Name=""rootElement"" Background=""White""></Grid>";

		public MainWindow()
		{
			InitializeComponent();

			using (var xmlReader = XmlReader.Create(new StringReader(xaml)))
			{
				designSurface.LoadDesigner(xmlReader, new XamlLoadSettings());
			}
		}
		
		private void lstControls_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var item = lstControls.SelectedItem as ToolBoxItem;
			if (item != null)
			{
				var tool = new CreateComponentTool(item.Type);
				designSurface.DesignPanel.Context.Services.Tool.CurrentTool = tool;		  
			}
		}

		private void lstControls_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
			var item = lstControls.SelectedItem as ToolBoxItem;
			if (item != null)
			{
				var tool = new CreateComponentTool(item.Type);
				designSurface.DesignPanel.Context.Services.Tool.CurrentTool = tool;
			}
		}

		private void Export()
		{
			var sb = new StringBuilder();
			using (var xmlWriter = new XamlXmlWriter(sb))
			{
				designSurface.SaveDesigner(xmlWriter);
			}
			var xamlCode = sb.ToString();
		}
	}
}
