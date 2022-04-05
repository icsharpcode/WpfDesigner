using System.Collections.Generic;

namespace ICSharpCode.WpfDesign.Services
{
	public interface ISelectionFilterService
	{
		ICollection<DesignItem> FilterSelectedElements(ICollection<DesignItem> items);
	}
}
