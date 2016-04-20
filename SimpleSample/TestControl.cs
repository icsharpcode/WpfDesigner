using System;
using System.ComponentModel;
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

		public TimeSpan TestTimeSpan2
		{
			get { return (TimeSpan)GetValue(TestTimeSpan2Property); }
			set { SetValue(TestTimeSpan2Property, value); }
		}

		// Using a DependencyProperty as the backing store for TestTimeSpan2.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TestTimeSpan2Property =
			DependencyProperty.Register("TestTimeSpan2", typeof(TimeSpan), typeof(TestControl), new PropertyMetadata(TimeSpan.FromMinutes(-55)));


		public double? TestDouble1
		{
			get { return (double?)GetValue(TestDouble1Property); }
			set { SetValue(TestDouble1Property, value); }
		}

		// Using a DependencyProperty as the backing store for TestDouble.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TestDouble1Property =
			DependencyProperty.Register("TestDouble1", typeof(double?), typeof(TestControl), new PropertyMetadata(0.0));

		public double? TestDouble2
		{
			get { return (double?)GetValue(TestDouble2Property); }
			set { SetValue(TestDouble2Property, value); }
		}

		// Using a DependencyProperty as the backing store for TestDouble.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty TestDouble2Property =
			DependencyProperty.Register("TestDouble2", typeof(double?), typeof(TestControl), new PropertyMetadata(null));


	}
}
