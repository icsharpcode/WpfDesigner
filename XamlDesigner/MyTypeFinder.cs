using System.Reflection;
using ICSharpCode.WpfDesign.XamlDom;

namespace ICSharpCode.XamlDesigner
{
	public class MyTypeFinder : XamlTypeFinder
	{
		public override Assembly LoadAssembly(string name)
		{
			foreach (var registeredAssembly in RegisteredAssemblies) {
				if (registeredAssembly.GetName().Name == name)
					return registeredAssembly;
			}

			foreach (var assemblyNode in Toolbox.Instance.AssemblyNodes)
			{
				if (assemblyNode.Name == name)
					return assemblyNode.Assembly;
			}

			return null;
		}

		public override XamlTypeFinder Clone()
		{
			return _instance;
		}

		private static object lockObj = new object();

		private static MyTypeFinder _instance;
		public static MyTypeFinder Instance
		{
			get
			{
				lock (lockObj)
				{
					if (_instance == null)
					{
						_instance = new MyTypeFinder();
						_instance.ImportFrom(CreateWpfTypeFinder());
					}
				}

				return _instance;
			}
		}
	}
}
