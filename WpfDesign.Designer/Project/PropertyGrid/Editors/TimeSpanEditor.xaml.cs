// Copyright (c) 2014 AlphaSierraPapa for the SharpDevelop Team
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.

using System;
using System.Windows;
using ICSharpCode.WpfDesign.PropertyGrid;
using ICSharpCode.WpfDesign.Designer.themes;


namespace ICSharpCode.WpfDesign.Designer.PropertyGrid.Editors
{
	[TypeEditor(typeof(TimeSpan))]
	public partial class TimeSpanEditor
	{
		public TimeSpanEditor()
		{
			SpecialInitializeComponent();
			DataContextChanged += NumberEditor_DataContextChanged;
		}

		/// <summary>
		/// Fixes InitializeComponent with multiple Versions of same Assembly loaded
		/// </summary>
		public void SpecialInitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri(VersionedAssemblyResourceDictionary.GetXamlNameForType(this.GetType()), UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}

			this.InitializeComponent();
		}

		public PropertyNode PropertyNode
		{
			get { return DataContext as PropertyNode; }
		}

		void NumberEditor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (PropertyNode == null)
				return;

			var value = (TimeSpan) PropertyNode.DesignerValue;


			if (value < TimeSpan.Zero)
			{
				this.Neagtive = true;
				value = value.Negate();
			}
			this.Days = value.Days;
			this.Hours = value.Hours;
			this.Minutes = value.Minutes;
			this.Seconds = value.Seconds;
			this.MiliSeconds = value.Milliseconds;
		}

		private void UpdateValue()
		{
			var ts = new TimeSpan(this.Days, this.Hours, this.Minutes, this.Seconds, this.MiliSeconds);
			if (this.Neagtive)
				ts = ts.Negate();
			PropertyNode.DesignerValue = ts;
		}

		public bool Neagtive
		{
			get { return (bool)GetValue(NeagtiveProperty); }
			set { SetValue(NeagtiveProperty, value); }
		}
		 
		// Using a DependencyProperty as the backing store for Neagtive.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty NeagtiveProperty =
			DependencyProperty.Register("Neagtive", typeof(bool), typeof(TimeSpanEditor), new PropertyMetadata(OnNeagtivePropertyChanged));

		private static void OnNeagtivePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctl = (TimeSpanEditor)d;
			ctl.UpdateValue();
		}


		public int Days
		{
			get { return (int)GetValue(DaysProperty); }
			set { SetValue(DaysProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Days.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DaysProperty =
			DependencyProperty.Register("Days", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata(OnDaysPropertyChanged));

		private static void OnDaysPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctl = (TimeSpanEditor)d;
			
			ctl.UpdateValue();
		}

		public int Hours
		{
			get { return (int)GetValue(HoursProperty); }
			set { SetValue(HoursProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Hours.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HoursProperty =
			DependencyProperty.Register("Hours", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata(OnHoursPropertyChanged));

		private static void OnHoursPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctl = (TimeSpanEditor) d;
			if (ctl.Hours > 23)
			{
				ctl.Days++;
				ctl.Hours = 0;
			}
			else if (ctl.Hours < 0)
			{
				ctl.Days--;
				ctl.Hours = 23;
			}

			ctl.UpdateValue();
		}

		public int Minutes
		{
			get { return (int)GetValue(MinutesProperty); }
			set { SetValue(MinutesProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Minutes.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MinutesProperty =
			DependencyProperty.Register("Minutes", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata(OnMinutesPropertyChanged));

		private static void OnMinutesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctl = (TimeSpanEditor)d;
			if (ctl.Minutes > 59)
			{
				ctl.Hours++;
				ctl.Minutes = 0;
			}
			else if (ctl.Minutes < 0)
			{
				ctl.Hours--;
				ctl.Minutes = 59;
			}

			ctl.UpdateValue();
		}
		 
		public int Seconds
		{
			get { return (int)GetValue(SecondsProperty); }
			set { SetValue(SecondsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SecondsProperty =
			DependencyProperty.Register("Seconds", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata(OnSecondsPropertyChanged));

		private static void OnSecondsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctl = (TimeSpanEditor)d;
			if (ctl.Seconds > 59)
			{
				ctl.Minutes++;
				ctl.Seconds = 0;
			}
			else if (ctl.Seconds < 0)
			{
				ctl.Minutes--;
				ctl.Seconds = 59;
			}

			ctl.UpdateValue();
		}
		public int MiliSeconds
		{
			get { return (int)GetValue(MiliSecondsProperty); }
			set { SetValue(MiliSecondsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MiliSeconds.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MiliSecondsProperty =
			DependencyProperty.Register("MiliSeconds", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata(OnMiliSecondsPropertyChanged));

		private static void OnMiliSecondsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			var ctl = (TimeSpanEditor)d;
			if (ctl.MiliSeconds > 999)
			{
				ctl.Seconds++;
				ctl.MiliSeconds = 0;
			}
			else if (ctl.MiliSeconds < 0)
			{
				ctl.Seconds--;
				ctl.MiliSeconds = 999;
			}

			ctl.UpdateValue();
		}
	}
}