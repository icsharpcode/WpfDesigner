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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Interactivity;

namespace ICSharpCode.WpfDesign.Designer.ExpressionBlendInteractionAddon
{
	public static class InteractionHelper
	{
		public static DesignItemProperty GetBehaviorsCollectionProperty(DesignItem designItem)
		{
			return designItem.Properties.GetAttachedProperty(typeof(Interaction), "Behaviors");
		}

		public static IEnumerable<DesignItem> GetBehaviors(DesignItem designItem)
		{
			var componentService = designItem.Context.Services.GetService<IComponentService>();
			
			var depObject = designItem.Component as DependencyObject;
			if (depObject != null) {
				return Interaction.GetBehaviors(depObject).Select(x => componentService.GetDesignItem(x));
			}

			return null;
		}

		public static IEnumerable<DesignItem> GetBehaviors(IEnumerable<DesignItem> designItems)
		{
			var componentService = designItems.First().Context.Services.GetService<IComponentService>();

			var depObject = designItems.First().Component as DependencyObject;
			if (depObject != null)
			{
				return Interaction.GetBehaviors(depObject).Select(x => componentService.GetDesignItem(x));
			}

			return null;
		}

		public static DesignItemProperty GetTriggersCollectionProperty(DesignItem designItem)
		{
			return designItem.Properties.GetAttachedProperty(typeof(Interaction), "Triggers");
		}

		public static IEnumerable<DesignItem> GetTriggers(DesignItem designItem)
		{
			var componentService = designItem.Context.Services.GetService<IComponentService>();

			var depObject = designItem.Component as DependencyObject;
			if (depObject != null) {
				return Interaction.GetTriggers(depObject).Select(x => componentService.GetDesignItem(x));
			}

			return null;
		}

		public static IEnumerable<DesignItem> GetTriggers(IEnumerable<DesignItem> designItems)
		{
			var componentService = designItems.First().Context.Services.GetService<IComponentService>();

			var depObject = designItems.First().Component as DependencyObject;
			if (depObject != null)
			{
				return Interaction.GetTriggers(depObject).Select(x => componentService.GetDesignItem(x));
			}

			return null;
		}

		public static IEnumerable<Type> GetBehaviors(params Assembly[] assemblies)
		{
			return assemblies.SelectMany(x => x.GetTypes()).Where(x => !x.IsAbstract && !x.IsInterface && !x.IsEnum && typeof(Behavior).IsAssignableFrom(x));
		}

		public static IEnumerable<Type> GetTriggers(params Assembly[] assemblies)
		{
			return assemblies.SelectMany(x => x.GetTypes()).Where(x => !x.IsAbstract && !x.IsInterface && !x.IsEnum && typeof(System.Windows.Interactivity.TriggerBase).IsAssignableFrom(x));
		}
	}
}
