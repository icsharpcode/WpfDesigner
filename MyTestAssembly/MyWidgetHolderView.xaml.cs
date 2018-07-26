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

namespace MyTestAssembly
{
	/// <summary>
	/// Interaction logic for MyWidgetHolderView.xaml
	/// </summary>
	public partial class MyWidgetHolderView : UserControl, IDisposable
	{
		public MyWidgetHolderView()
		{
			Console.WriteLine("Inst created:" + this.GetHashCode());
			InitializeComponent();
		}



		public string MyStringProperty
		{
			get { return (string)GetValue(MyStringPropertyProperty); }
			set { SetValue(MyStringPropertyProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MyStringProperty.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MyStringPropertyProperty =
			DependencyProperty.Register("MyStringProperty", typeof(string), typeof(MyWidgetHolderView), new PropertyMetadata(null));



		~MyWidgetHolderView()
		{

		}

		public void Dispose()
		{

		}
	}
}
