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

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using ICSharpCode.WpfDesign.PropertyGrid;

namespace ICSharpCode.WpfDesign.Designer.Services
{
	public class ComponentPropertyService : IComponentPropertyService
	{
		protected HashSet<string> IgnoreTypes = new HashSet<string>(new[]
		{
			typeof(XmlAttributeProperties).Name,
			typeof(Typography).Name,
			typeof(ContextMenuService).Name,
			typeof(DesignerProperties).Name,
			typeof(InputLanguageManager).Name,
			typeof(InputMethod).Name,
			typeof(KeyboardNavigation).Name,
			typeof(NumberSubstitution).Name,
			typeof(RenderOptions).Name,
			typeof(TextSearch).Name,
			typeof(ToolTipService).Name,
			typeof(Validation).Name,
			typeof(Stylus).Name
		});

		public virtual IEnumerable<MemberDescriptor> GetAvailableProperties(DesignItem designItem)
		{
			return TypeHelper.GetAvailableProperties(designItem.Component)
				.Where(x => !x.Name.Contains(".") || !IgnoreTypes.Contains(x.Name.Split('.')[0]));
		}

		public virtual IEnumerable<MemberDescriptor> GetAvailableEvents(DesignItem designItem)
		{
			return TypeHelper.GetAvailableEvents(designItem.ComponentType);
		}

		public virtual IEnumerable<MemberDescriptor> GetCommonAvailableProperties(IEnumerable<DesignItem> designItems)
		{
			return TypeHelper.GetCommonAvailableProperties(designItems.Select(t => t.Component))
				.Where(x => !x.Name.Contains(".") || !IgnoreTypes.Contains(x.Name.Split('.')[0]));
		}
	}
}
