using System;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using ICSharpCode.WpfDesign;
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

			var loadSettings = new XamlLoadSettings();
			loadSettings.DesignerAssemblies.Add(this.GetType().Assembly);

			DragFileToDesignPanelHelper.Install(designSurface, CreateItemsOnDragCallback);
			using (var xmlReader = XmlReader.Create(new StringReader(xaml)))
			{
				designSurface.LoadDesigner(xmlReader, loadSettings);
			}
		}

		private DesignItem[] CreateItemsOnDragCallback(DesignContext context, DragEventArgs e)
		{
			var data = e.Data.GetData(DataFormats.FileDrop, false);
			if (data == null)
				return null;
			var item = context.Services.Component.RegisterComponentForDesigner(new TextBlock());
			item.Properties.GetProperty(FrameworkElement.WidthProperty).SetValue(300.0);
			item.Properties.GetProperty(FrameworkElement.HeightProperty).SetValue(30.0);
			string[] fileList = (string[])data;
			item.Properties.GetProperty(TextBlock.TextProperty).SetValue(string.Join(Environment.NewLine, fileList));
			return new[] { item };
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
