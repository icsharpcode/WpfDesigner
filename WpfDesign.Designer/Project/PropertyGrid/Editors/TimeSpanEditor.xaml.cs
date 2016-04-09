// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

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

		public int Days
		{
			get { return (int)GetValue(DaysProperty); }
			set { SetValue(DaysProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Days.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty DaysProperty =
			DependencyProperty.Register("Days", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata());

		public int Hours
		{
			get { return (int)GetValue(HoursProperty); }
			set { SetValue(HoursProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Hours.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty HoursProperty =
			DependencyProperty.Register("Hours", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata());

		public int Minutes
		{
			get { return (int)GetValue(MinutesProperty); }
			set { SetValue(MinutesProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Minutes.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MinutesProperty =
			DependencyProperty.Register("Minutes", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata());


		public int Seconds
		{
			get { return (int)GetValue(SecondsProperty); }
			set { SetValue(SecondsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty SecondsProperty =
			DependencyProperty.Register("Seconds", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata());

		public int MiliSeconds
		{
			get { return (int)GetValue(MiliSecondsProperty); }
			set { SetValue(MiliSecondsProperty, value); }
		}

		// Using a DependencyProperty as the backing store for MiliSeconds.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty MiliSecondsProperty =
			DependencyProperty.Register("MiliSeconds", typeof(int), typeof(TimeSpanEditor), new PropertyMetadata());


	}
}