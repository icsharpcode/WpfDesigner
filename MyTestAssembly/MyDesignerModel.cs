using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.WpfDesign.Designer;
using ICSharpCode.WpfDesign.Designer.PropertyGrid;
using ICSharpCode.WpfDesign;

namespace MyTestAssembly
{
	//Similar to the Shell class used in the sharpdevlop large sample
	public class MyDesignerModel
	{
		public MyDesignerModel()
		{
			this.m_designSurface = new DesignSurface();			
		}

		public static MyDesignerModel Instance = new MyDesignerModel();

		private DesignSurface m_designSurface;


		public DesignSurface DesignSurface
		{
			get { return this.m_designSurface; }
		}

		public IPropertyGrid PropertyGrid { get; set; }
	}
}
