using System;

namespace SimpleSample
{
	public class ToolBoxItem
	{
		public Type Type { get; set; }

		private object _instance;
		public object Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Activator.CreateInstance(Type);
				}
				return _instance;
			}
		}
		
		public string Name
		{
			get
			{
				return Type.Name;
			}
		}
	}
}
