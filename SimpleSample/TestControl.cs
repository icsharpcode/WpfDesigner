using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SimpleSample
{
	public class TestControl : Control
	{
		public Color TestColor
		{
			get { return (Color)GetValue(TestColorProperty); }
			set { SetValue(TestColorProperty, value); }
		}

		public static readonly DependencyProperty TestColorProperty =
			DependencyProperty.Register("TestColor", typeof(Color), typeof(TestControl), new PropertyMetadata());
	}
}
