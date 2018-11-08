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

using System.Linq;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using ICSharpCode.WpfDesign.Designer.Xaml;

namespace ICSharpCode.WpfDesign.Designer.Services
{
	/// <summary>
	/// A tool that creates a component.
	/// </summary>
	public class CreateComponentTool : ITool
	{
		protected ChangeGroup ChangeGroup;

		readonly Type componentType;
		MoveLogic moveLogic;
		Point createPoint;
		
		/// <summary>
		/// Creates a new CreateComponentTool instance.
		/// </summary>
		public CreateComponentTool(Type componentType)
		{
			if (componentType == null)
				throw new ArgumentNullException("componentType");
			this.componentType = componentType;
		}
		
		/// <summary>
		/// Gets the type of the component to be created.
		/// </summary>
		public Type ComponentType {
			get { return componentType; }
		}
		
		public Cursor Cursor {
			get { return Cursors.Cross; }
		}
		
		public void Activate(IDesignPanel designPanel)
		{
			designPanel.MouseDown += OnMouseDown;
			designPanel.DragOver += designPanel_DragOver;
			designPanel.Drop += designPanel_Drop;
			designPanel.DragLeave += designPanel_DragLeave;
		}
		
		public void Deactivate(IDesignPanel designPanel)
		{
			designPanel.MouseDown -= OnMouseDown;
			designPanel.DragOver -= designPanel_DragOver;
			designPanel.Drop -= designPanel_Drop;
			designPanel.DragLeave -= designPanel_DragLeave;
		}

		void designPanel_DragOver(object sender, DragEventArgs e)
		{
			try {
				IDesignPanel designPanel = (IDesignPanel)sender;
				e.Effects = DragDropEffects.Copy;
				e.Handled = true;
				Point p = e.GetPosition(designPanel);

				if (moveLogic == null) {
					if (e.Data.GetData(this.GetType()) != this) return;
					// TODO: dropLayer in designPanel
					designPanel.IsAdornerLayerHitTestVisible = false;
					DesignPanelHitTestResult result = designPanel.HitTest(p, false, true, HitTestType.Default);
					
					if (result.ModelHit != null) {
						designPanel.Focus();
						var items = CreateItemsWithPosition(designPanel.Context, e.GetPosition(result.ModelHit.View));
						if (items != null) {
							if (AddItemsWithDefaultSize(result.ModelHit, items))
							{
								moveLogic = new MoveLogic(items[0]);

								foreach (var designItem in items)
								{
									if (designPanel.Context.Services.Component is XamlComponentService) {
										((XamlComponentService)designPanel.Context.Services.Component).RaiseComponentRegisteredAndAddedToContainer(designItem);
									}
								}
								createPoint = p;
								// We'll keep the ChangeGroup open as long as the moveLogic is active.
							}
							else
							{
								// Abort the ChangeGroup created by the CreateItem() call.
								ChangeGroup.Abort();
							}
						}
						else
						{
							DesignItem createdItem = CreateItemWithPosition(designPanel.Context, e.GetPosition(result.ModelHit.View));
							if (AddItemsWithDefaultSize(result.ModelHit, new[] { createdItem })) {
								moveLogic = new MoveLogic(createdItem);

								if (designPanel.Context.Services.Component is XamlComponentService) {
									((XamlComponentService) designPanel.Context.Services.Component).RaiseComponentRegisteredAndAddedToContainer(createdItem);
								}
								
								createPoint = p;
								// We'll keep the ChangeGroup open as long as the moveLogic is active.
							} else {
								// Abort the ChangeGroup created by the CreateItem() call.
								ChangeGroup.Abort();
							}
						}
					}
				} else if ((moveLogic.ClickedOn.View as FrameworkElement).IsLoaded) {
					if (moveLogic.Operation == null) {
						moveLogic.Start(createPoint);
					} else {
						moveLogic.Move(p);
					}
				}
			} catch (Exception x) {
				DragDropExceptionHandler.RaiseUnhandledException(x);
			}
		}

		void designPanel_Drop(object sender, DragEventArgs e)
		{
			try {
				if (moveLogic != null) {
					moveLogic.Stop();
					if (moveLogic.ClickedOn.Services.Tool.CurrentTool is CreateComponentTool) {
						moveLogic.ClickedOn.Services.Tool.CurrentTool = moveLogic.ClickedOn.Services.Tool.PointerTool;
					}
					moveLogic.DesignPanel.IsAdornerLayerHitTestVisible = true;
					moveLogic = null;
					ChangeGroup.Commit();

					e.Handled = true;
				}
			} catch (Exception x) {
				DragDropExceptionHandler.RaiseUnhandledException(x);
			}
		}

		void designPanel_DragLeave(object sender, DragEventArgs e)
		{
			try {
				if (moveLogic != null) {
					moveLogic.Cancel();
					moveLogic.ClickedOn.Services.Selection.SetSelectedComponents(null);
					moveLogic.DesignPanel.IsAdornerLayerHitTestVisible = true;
					moveLogic = null;
					ChangeGroup.Abort();

				}
			} catch (Exception x) {
				DragDropExceptionHandler.RaiseUnhandledException(x);
			}
		}

		/// <summary>
		/// Is called to create the item used by the CreateComponentTool.
		/// </summary>
		protected virtual DesignItem CreateItemWithPosition(DesignContext context, Point position)
		{
			var item = CreateItem(context);
			item.Position = position;
			return item;
		}

		/// <summary>
		/// Is called to create the item used by the CreateComponentTool.
		/// </summary>
		protected virtual DesignItem CreateItem(DesignContext context)
		{
			ChangeGroup = context.RootItem.OpenGroup("Add Control");
			var item = CreateItem(context, componentType);
			return item;
		}

		protected virtual DesignItem[] CreateItemsWithPosition(DesignContext context, Point position)
		{
			var items = CreateItems(context);
			if (items != null) {
				foreach (var designItem in items) {
					designItem.Position = position;
				}
			}

			return items;
		}

		protected virtual DesignItem[] CreateItems(DesignContext context)
		{
			return null;
		}

		/// <summary>
		/// Is called to create the item used by the CreateComponentTool.
		/// </summary>
		public static DesignItem CreateItem(DesignContext context, Type type)
		{
			object newInstance = context.Services.ExtensionManager.CreateInstanceWithCustomInstanceFactory(type, null);
			DesignItem item = context.Services.Component.RegisterComponentForDesigner(newInstance);
			context.Services.Component.SetDefaultPropertyValues(item);
			context.Services.ExtensionManager.ApplyDefaultInitializers(item);
			return item;
		}

		/// <summary>
		/// Is called to set Properties of the Drawn Item
		/// </summary>
		protected virtual void SetPropertiesForDrawnItem(DesignItem designItem)
		{ }

		public static bool AddItemWithCustomSizePosition(DesignItem container, Type createdItem, Size size, Point position)
		{
			CreateComponentTool cct = new CreateComponentTool(createdItem);
			return AddItemsWithCustomSize(container, new[] { cct.CreateItem(container.Context) }, new[] { new Rect(position, size) });
		}
		
		public static bool AddItemWithDefaultSize(DesignItem container, Type createdItem, Size size)
		{
			CreateComponentTool cct = new CreateComponentTool(createdItem);
			return AddItemsWithCustomSize(container, new[] { cct.CreateItem(container.Context) }, new[] { new Rect(new Point(0, 0), size) });
		}

		internal static bool AddItemsWithDefaultSize(DesignItem container, DesignItem[] createdItems)
		{
			return AddItemsWithCustomSize(container, createdItems, createdItems.Select(x => new Rect(x.Position, ModelTools.GetDefaultSize(x))).ToList());
		}

		internal static bool AddItemsWithCustomSize(DesignItem container, DesignItem[] createdItems, IList<Rect> positions)
		{
			
			PlacementOperation operation = PlacementOperation.TryStartInsertNewComponents(
				container,
				createdItems,
				positions,
				PlacementType.AddItem
			);
			if (operation != null) {
				container.Services.Selection.SetSelectedComponents(createdItems);
				operation.Commit();
				return true;
			} else {
				return false;
			}
		}
		
		void OnMouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left && MouseGestureBase.IsOnlyButtonPressed(e, MouseButton.Left)) {
				e.Handled = true;
				IDesignPanel designPanel = (IDesignPanel)sender;
				DesignPanelHitTestResult result = designPanel.HitTest(e.GetPosition(designPanel), false, true, HitTestType.Default);
				if (result.ModelHit != null) {
					var darwItemBehaviors = result.ModelHit.Extensions.OfType<IDrawItemExtension>();
					var drawItembehavior = darwItemBehaviors.FirstOrDefault(x => x.CanItemBeDrawn(componentType));
					if (drawItembehavior != null && drawItembehavior.CanItemBeDrawn(componentType)) {
						drawItembehavior.StartDrawItem(result.ModelHit, componentType, designPanel, e, SetPropertiesForDrawnItem);
					}
					else {
						var placementBehavior = result.ModelHit.GetBehavior<IPlacementBehavior>();
						if (placementBehavior != null) {
							var createdItem = CreateItem(designPanel.Context);
							
							new CreateComponentMouseGesture(result.ModelHit, createdItem, ChangeGroup).Start(designPanel, e);
							// CreateComponentMouseGesture now is responsible for the changeGroup created by CreateItem()
							ChangeGroup = null;
						}
					}
				}
			}
		}
	}
	
	sealed class CreateComponentMouseGesture : ClickOrDragMouseGesture
	{
		DesignItem createdItem;
		PlacementOperation operation;
		DesignItem container;
		ChangeGroup changeGroup;
		
		public CreateComponentMouseGesture(DesignItem clickedOn, DesignItem createdItem, ChangeGroup changeGroup)
		{
			this.container = clickedOn;
			this.createdItem = createdItem;
			this.positionRelativeTo = clickedOn.View;
			this.changeGroup = changeGroup;
		}
		
//		GrayOutDesignerExceptActiveArea grayOut;
//		SelectionFrame frame;
//		AdornerPanel adornerPanel;
		
		Rect GetStartToEndRect(MouseEventArgs e)
		{
			Point endPoint = e.GetPosition(positionRelativeTo);
			return new Rect(
				Math.Min(startPoint.X, endPoint.X),
				Math.Min(startPoint.Y, endPoint.Y),
				Math.Abs(startPoint.X - endPoint.X),
				Math.Abs(startPoint.Y - endPoint.Y)
			);
		}
		
		protected override void OnDragStarted(MouseEventArgs e)
		{
			operation = PlacementOperation.TryStartInsertNewComponents(container,
			                                                           new DesignItem[] { createdItem },
			                                                           new Rect[] { GetStartToEndRect(e).Round() },
			                                                           PlacementType.Resize);
			if (operation != null) {
				services.Selection.SetSelectedComponents(new DesignItem[] { createdItem });
			}
		}
		
		protected override void OnMouseMove(object sender, MouseEventArgs e)
		{
			base.OnMouseMove(sender, e);
			if (operation != null) {
				foreach (PlacementInformation info in operation.PlacedItems) {
					info.Bounds = GetStartToEndRect(e).Round();
					operation.CurrentContainerBehavior.SetPosition(info);
				}
			}
		}
		
		protected override void OnMouseUp(object sender, MouseButtonEventArgs e)
		{
			if (hasDragStarted) {
				if (operation != null) {
					operation.Commit();
					operation = null;
				}
			} else {
				CreateComponentTool.AddItemsWithDefaultSize(container, new[] { createdItem });
			}
			if (changeGroup != null) {
				changeGroup.Commit();
				changeGroup = null;
			}
			
			if (designPanel.Context.Services.Component is XamlComponentService)
			{
				((XamlComponentService)designPanel.Context.Services.Component).RaiseComponentRegisteredAndAddedToContainer(createdItem);
			}

			base.OnMouseUp(sender, e);
		}
		
		protected override void OnStopped()
		{
			if (operation != null) {
				operation.Abort();
				operation = null;
			}
			if (changeGroup != null) {
				changeGroup.Abort();
				changeGroup = null;
			}
			if (services.Tool.CurrentTool is CreateComponentTool) {
				services.Tool.CurrentTool = services.Tool.PointerTool;
			}
			base.OnStopped();
		}
	}
}
