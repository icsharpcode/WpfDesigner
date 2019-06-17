// Copyright (c) 2019 AlphaSierraPapa for the SharpDevelop Team
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

using System.Linq;
using System.Windows;
using System;
using System.Collections.Generic;
using ICSharpCode.WpfDesign.Designer.Xaml;
using System.Windows.Controls;

namespace ICSharpCode.WpfDesign.Designer.Services
{
	/// <summary>
	/// A helper for DragDrop files to a DesignPanel
	/// </summary>
	public class DragFileToDesignPanelHelper
	{
		protected ChangeGroup ChangeGroup;

		MoveLogic moveLogic;
		Point createPoint;

		Func<DesignContext, DragEventArgs, DesignItem[]> _createItems;
		DesignPanel _designPanel;


		public static DragFileToDesignPanelHelper Install(DesignSurface designSurface, Func<DesignContext, DragEventArgs, DesignItem[]> createItems)
		{
			var helper = new DragFileToDesignPanelHelper();
			helper._createItems = createItems;
			helper._designPanel = designSurface._designPanel as DesignPanel;

			helper._designPanel.AllowDrop = true;
			helper._designPanel.DragOver += helper.designPanel_DragOver;
			helper._designPanel.Drop += helper.designPanel_Drop;
			helper._designPanel.DragLeave += helper.designPanel_DragLeave;

			return helper;
		}

		public void Remove()
		{
			_designPanel.DragOver -= designPanel_DragOver;
			_designPanel.Drop -= designPanel_Drop;
			_designPanel.DragLeave -= designPanel_DragLeave;
		}

		void designPanel_DragOver(object sender, DragEventArgs e)
		{
			try
			{
				IDesignPanel designPanel = (IDesignPanel)sender;
				e.Effects = DragDropEffects.Copy;
				e.Handled = true;
				Point p = e.GetPosition(designPanel);

				if (moveLogic == null)
				{
					if (ChangeGroup != null)
					{
						ChangeGroup.Abort();
						ChangeGroup = null;
					}
					ChangeGroup = designPanel.Context.RootItem.OpenGroup("Add Control");
					designPanel.IsAdornerLayerHitTestVisible = false;
					DesignPanelHitTestResult result = designPanel.HitTest(p, false, true, HitTestType.Default);

					if (result.ModelHit != null)
					{
						designPanel.Focus();
						var items = CreateItemsWithPosition(designPanel.Context, e.GetPosition(result.ModelHit.View), e);
						if (items != null)
						{
							if (AddItems(result.ModelHit, items))
							{
								moveLogic = new MoveLogic(items[0]);

								foreach (var designItem in items)
								{
									if (designPanel.Context.Services.Component is XamlComponentService)
									{
										((XamlComponentService)designPanel.Context.Services.Component).RaiseComponentRegisteredAndAddedToContainer(designItem);
									}
								}
								createPoint = p;
							}
							else
							{
								ChangeGroup.Abort();
								ChangeGroup = null;
							}
						}
						else
						{
							e.Effects = DragDropEffects.None;
						}
					}
				}
				else if ((moveLogic.ClickedOn.View as FrameworkElement).IsLoaded)
				{
					if (moveLogic.Operation == null)
					{
						moveLogic.Start(createPoint);
					}
					else
					{
						moveLogic.Move(p);
					}
				}
			}
			catch (Exception x)
			{
				DragDropExceptionHandler.RaiseUnhandledException(x);
			}
		}

		void designPanel_Drop(object sender, DragEventArgs e)
		{
			try
			{
				if (moveLogic != null)
				{
					moveLogic.Stop();
					if (moveLogic.ClickedOn.Services.Tool.CurrentTool is CreateComponentTool)
					{
						moveLogic.ClickedOn.Services.Tool.CurrentTool = moveLogic.ClickedOn.Services.Tool.PointerTool;
					}
					moveLogic.DesignPanel.IsAdornerLayerHitTestVisible = true;
					moveLogic = null;
					ChangeGroup.Commit();
					ChangeGroup = null;

					e.Handled = true;
				}
			}
			catch (Exception x)
			{
				DragDropExceptionHandler.RaiseUnhandledException(x);
			}
		}

		void designPanel_DragLeave(object sender, DragEventArgs e)
		{
			try
			{
				if (moveLogic != null)
				{
					moveLogic.Cancel();
					moveLogic.ClickedOn.Services.Selection.SetSelectedComponents(null);
					moveLogic.DesignPanel.IsAdornerLayerHitTestVisible = true;
					moveLogic = null;
					ChangeGroup.Abort();
					ChangeGroup = null;

				}
			}
			catch (Exception x)
			{
				DragDropExceptionHandler.RaiseUnhandledException(x);
			}
		}

		private DesignItem[] CreateItemsWithPosition(DesignContext context, Point position, DragEventArgs e)
		{
			var items = _createItems(context, e); //CreateItems(context, e);
			if (items != null)
			{
				foreach (var designItem in items)
				{
					designItem.Position = position;
				}
			}

			return items;
		}

		private DesignItem[] CreateItems(DesignContext context, DragEventArgs e)
		{
			var item = context.Services.Component.RegisterComponentForDesigner(new Image());
			item.Properties.GetProperty(FrameworkElement.WidthProperty).SetValue(100.0);
			item.Properties.GetProperty(FrameworkElement.HeightProperty).SetValue(100.0);
			return new[] { item };
		}

		private bool AddItems(DesignItem container, DesignItem[] createdItems)
		{
			var sizes = createdItems.Select(x =>
			{
				var fe = x.Component as FrameworkElement;
				if (fe != null &&
				fe.ReadLocalValue(FrameworkElement.WidthProperty) != DependencyProperty.UnsetValue &&
				fe.ReadLocalValue(FrameworkElement.HeightProperty) != DependencyProperty.UnsetValue)
				{
					return new Rect(x.Position, new Size(fe.Width, fe.Height));
				}
				return new Rect(x.Position, ModelTools.GetDefaultSize(x));
			}).ToList();

			return AddItemsWithCustomSize(container, createdItems, sizes);
		}

		private bool AddItemsWithCustomSize(DesignItem container, DesignItem[] createdItems, IList<Rect> positions)
		{
			PlacementOperation operation = null;

			while (operation == null && container != null)
			{
				operation = PlacementOperation.TryStartInsertNewComponents(
					container,
					createdItems,
					positions,
					PlacementType.AddItem
				);

				if (operation != null)
					break;

				try
				{
					if (container.Parent != null)
					{
						var rel = container.View.TranslatePoint(new Point(0, 0), container.Parent.View);
						for (var index = 0; index < positions.Count; index++)
						{
							positions[index] = new Rect(new Point(positions[index].X + rel.X, positions[index].Y + rel.Y), positions[index].Size);
						}
					}
				}
				catch (Exception)
				{ }

				container = container.Parent;
			}

			if (operation != null)
			{
				container.Services.Selection.SetSelectedComponents(createdItems);
				operation.Commit();
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
