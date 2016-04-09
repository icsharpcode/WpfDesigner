using System;
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

		public TimeSpan TestTimeSpan
		{
			get { return (TimeSpan)GetValue(TestTimeSpanProperty); }
			set { SetValue(TestTimeSpanProperty, value); }
		}

		// Using a DependencyProperty as the backing store for TestTimeSpan.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TestTimeSpanProperty =
			DependencyProperty.Register("TestTimeSpan", typeof(TimeSpan), typeof(TestControl), new PropertyMetadata(new TimeSpan(4, 3, 55, 34, 345)));


	}
}
