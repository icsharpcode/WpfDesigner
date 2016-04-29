using ICSharpCode.WpfDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using ICSharpCode.WpfDesign.PropertyGrid;

namespace MyTestAssembly
{
	public class MyComponentPropertyService : IComponentPropertyService
	{
		public IEnumerable<MemberDescriptor> GetAvailableEvents(DesignItem designItem)
		{
			//We don't want to show events for our design items, so probably throw an exception here?
			IEnumerable<EventDescriptor> retVal = TypeHelper.GetAvailableEvents(designItem.ComponentType);
			return retVal;
		}

		public IEnumerable<MemberDescriptor> GetAvailableProperties(DesignItem designItem)
		{
			IEnumerable<PropertyDescriptor> retVal = TypeHelper.GetAvailableProperties(designItem.Component);

			retVal = retVal.Where(c => c.Name == "Foreground");

			return retVal;
		}

		public IEnumerable<MemberDescriptor> GetCommonAvailableProperties(IEnumerable<DesignItem> designItems)
		{
			IEnumerable<PropertyDescriptor> retVal = TypeHelper.GetCommonAvailableProperties(designItems.Select(t => t.Component));

			return retVal;
		}
	}
}
