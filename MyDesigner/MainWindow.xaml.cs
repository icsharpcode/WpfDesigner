using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;
using MyTestAssembly;
using ICSharpCode.WpfDesign.Designer.Xaml;
using ICSharpCode.WpfDesign.Designer.PropertyGrid;
using ICSharpCode.WpfDesign;

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
x:Name=""rootElement"" Background=""White""></Grid>";

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

			//We want to supply our own implementation of IComponentPropertyService so we return just the properties that we want.
			//This would probably go better in the MyDesignerModel class, but have to wait until after the DesignContext has been created.
			MyDesignerModel.Instance.DesignSurface.DesignContext.Services.AddOrReplaceService(typeof(IComponentPropertyService), new MyComponentPropertyService());
		}
	}
}
