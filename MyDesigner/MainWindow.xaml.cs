using System;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.IO;
using MyTestAssembly;
using ICSharpCode.WpfDesign.Designer.Xaml;
using ICSharpCode.WpfDesign;
using ICSharpCode.WpfDesign.Designer.Services;

namespace MyDesigner
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		//From the simple example, enough text to show a root container in the designer.
		private static string xaml = @"<Grid 
xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
xmlns:d=""http://schemas.microsoft.com/expression/blend/2008""
xmlns:mc=""http://schemas.openxmlformats.org/markup-compatibility/2006""
mc:Ignorable=""d""
x:Name=""rootElement"" Background=""White"" Width=""200"" Height=""200""><Grid  Margin=""100""/></Grid>";

		public MainWindow()
		{
			DataContext = MyDesignerModel.Instance;

			InitializeComponent();

			//Plug the design surface into the grid that is its parent
			this.DesignSurfaceGrid.Children.Add(MyDesignerModel.Instance.DesignSurface);

			//For testing property getting/setting only.
			MyDesignerModel.Instance.PropertyGrid = this.uxPropertyGridView.PropertyGrid;

			//Load the design surface with some minimal XAML that we have hardcoded.
			using (var xmlReader = XmlReader.Create(new StringReader(xaml)))
			{
				MyDesignerModel.Instance.DesignSurface.LoadDesigner(xmlReader, new XamlLoadSettings());
			}

			Metadata.AddStandardValues(MyWidgetHolderView.MyStringPropertyProperty, "aa", "bb", "cc");

			//We want to supply our own implementation of IComponentPropertyService so we return just the properties that we want.
			//This would probably go better in the MyDesignerModel class, but have to wait until after the DesignContext has been created.
			MyDesignerModel.Instance.DesignSurface.DesignContext.Services.AddOrReplaceService(typeof(IComponentPropertyService), new MyComponentPropertyService());
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
		

			var desItem = MyDesignerModel.Instance.DesignSurface.DesignContext.RootItem;
			desItem.Services.GetService<UndoService>().Clear();
			GC.Collect();
			if (desItem.Services.Selection.PrimarySelection != null &&
				desItem.Services.Selection.PrimarySelection.Component is Grid)
			{
				for (int i = 0; i < 5; i++)
				{
					desItem.Services.Selection.PrimarySelection.Properties.GetProperty("ColumnDefinitions")
						.CollectionElements
						.Add(desItem.Services.Component.RegisterComponentForDesigner(
							new ColumnDefinition() { Width = new GridLength(200) }));
				}

				desItem.Services.Selection.PrimarySelection.ReapplyAllExtensions();
			}
		}
	}
}
