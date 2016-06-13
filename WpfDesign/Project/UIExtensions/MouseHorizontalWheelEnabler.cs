using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

namespace ICSharpCode.WpfDesign.UIExtensions
{
	public static class MouseHorizontalWheelEnabler
	{
		/// <summary>
		///   When true it will try to enable Horizontal Wheel support on parent windows/popups/context menus automatically
		///   so the programmer does not need to call it.
		///   Defaults to true.
		/// </summary>
		public static bool AutoEnableMouseHorizontalWheelSupport = true;

		private static readonly HashSet<IntPtr> _HookedWindows = new HashSet<IntPtr>();

		/// <summary>
		///   Enable Horizontal Wheel support for all the controls inside the window.
		///   This method does not need to be called if AutoEnableMouseHorizontalWheelSupport is true.
		///   This does not include popups or context menus.
		///   If it was already enabled it will do nothing.
		/// </summary>
		/// <param name="window">Window to enable support for.</param>
		public static void EnableMouseHorizontalWheelSupport(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			if (window.IsLoaded)
			{
				// handle should be available at this level
				IntPtr handle = new WindowInteropHelper(window).Handle;
				EnableMouseHorizontalWheelSupport(handle);
			}
			else
			{
				window.Loaded += (sender, args) => {
					IntPtr handle = new WindowInteropHelper(window).Handle;
					EnableMouseHorizontalWheelSupport(handle);
				};
			}
		}

		/// <summary>
		///   Enable Horizontal Wheel support for all the controls inside the popup.
		///   This method does not need to be called if AutoEnableMouseHorizontalWheelSupport is true.
		///   This does not include sub-popups or context menus.
		///   If it was already enabled it will do nothing.
		/// </summary>
		/// <param name="popup">Popup to enable support for.</param>
		public static void EnableMouseHorizontalWheelSupport(Popup popup)
		{
			if (popup == null)
			{
				throw new ArgumentNullException(nameof(popup));
			}

			if (popup.IsOpen)
			{
				// handle should be available at this level
				// ReSharper disable once PossibleInvalidOperationException
				EnableMouseHorizontalWheelSupport(GetObjectParentHandle(popup.Child).Value);
			}

			// also hook for IsOpened since a new window is created each time
			popup.Opened += (sender, args) => {
				// ReSharper disable once PossibleInvalidOperationException
				EnableMouseHorizontalWheelSupport(GetObjectParentHandle(popup.Child).Value);
			};
		}

		/// <summary>
		///   Enable Horizontal Wheel support for all the controls inside the context menu.
		///   This method does not need to be called if AutoEnableMouseHorizontalWheelSupport is true.
		///   This does not include popups or sub-context menus.
		///   If it was already enabled it will do nothing.
		/// </summary>
		/// <param name="contextMenu">Context menu to enable support for.</param>
		public static void EnableMouseHorizontalWheelSupport(ContextMenu contextMenu)
		{
			if (contextMenu == null)
			{
				throw new ArgumentNullException(nameof(contextMenu));
			}

			if (contextMenu.IsOpen)
			{
				// handle should be available at this level
				// ReSharper disable once PossibleInvalidOperationException
				EnableMouseHorizontalWheelSupport(GetObjectParentHandle(contextMenu).Value);
			}

			// also hook for IsOpened since a new window is created each time
			contextMenu.Opened += (sender, args) => {
				// ReSharper disable once PossibleInvalidOperationException
				EnableMouseHorizontalWheelSupport(GetObjectParentHandle(contextMenu).Value);
			};
		}

		private static IntPtr? GetObjectParentHandle(DependencyObject depObj)
		{
			if (depObj == null)
			{
				throw new ArgumentNullException(nameof(depObj));
			}

			var presentationSource = PresentationSource.FromDependencyObject(depObj) as HwndSource;
			return presentationSource?.Handle;
		}

		/// <summary>
		///   Enable Horizontal Wheel support for all the controls inside the HWND.
		///   This method does not need to be called if AutoEnableMouseHorizontalWheelSupport is true.
		///   This does not include popups or sub-context menus.
		///   If it was already enabled it will do nothing.
		/// </summary>
		/// <param name="handle">HWND handle to enable support for.</param>
		/// <returns>True if it was enabled or already enabled, false if it couldn't be enabled.</returns>
		public static bool EnableMouseHorizontalWheelSupport(IntPtr handle)
		{
			if (_HookedWindows.Contains(handle))
			{
				return true;
			}

			_HookedWindows.Add(handle);
			HwndSource source = HwndSource.FromHwnd(handle);
			if (source == null)
			{
				return false;
			}

			source.AddHook(WndProcHook);
			return true;
		}

		/// <summary>
		///   Disable Horizontal Wheel support for all the controls inside the HWND.
		///   This method does not need to be called in most cases.
		///   This does not include popups or sub-context menus.
		///   If it was already disabled it will do nothing.
		/// </summary>
		/// <param name="handle">HWND handle to disable support for.</param>
		/// <returns>True if it was disabled or already disabled, false if it couldn't be disabled.</returns>
		public static bool DisableMouseHorizontalWheelSupport(IntPtr handle)
		{
			if (!_HookedWindows.Contains(handle))
			{
				return true;
			}

			HwndSource source = HwndSource.FromHwnd(handle);
			if (source == null)
			{
				return false;
			}

			source.RemoveHook(WndProcHook);
			_HookedWindows.Remove(handle);
			return true;
		}

		/// <summary>
		///   Disable Horizontal Wheel support for all the controls inside the window.
		///   This method does not need to be called in most cases.
		///   This does not include popups or sub-context menus.
		///   If it was already disabled it will do nothing.
		/// </summary>
		/// <param name="window">Window to disable support for.</param>
		/// <returns>True if it was disabled or already disabled, false if it couldn't be disabled.</returns>
		public static bool DisableMouseHorizontalWheelSupport(Window window)
		{
			if (window == null)
			{
				throw new ArgumentNullException(nameof(window));
			}

			IntPtr handle = new WindowInteropHelper(window).Handle;
			return DisableMouseHorizontalWheelSupport(handle);
		}

		/// <summary>
		///   Disable Horizontal Wheel support for all the controls inside the popup.
		///   This method does not need to be called in most cases.
		///   This does not include popups or sub-context menus.
		///   If it was already disabled it will do nothing.
		/// </summary>
		/// <param name="popup">Popup to disable support for.</param>
		/// <returns>True if it was disabled or already disabled, false if it couldn't be disabled.</returns>
		public static bool DisableMouseHorizontalWheelSupport(Popup popup)
		{
			if (popup == null)
			{
				throw new ArgumentNullException(nameof(popup));
			}

			IntPtr? handle = GetObjectParentHandle(popup.Child);
			if (handle == null)
			{
				return false;
			}

			return DisableMouseHorizontalWheelSupport(handle.Value);
		}

		/// <summary>
		///   Disable Horizontal Wheel support for all the controls inside the context menu.
		///   This method does not need to be called in most cases.
		///   This does not include popups or sub-context menus.
		///   If it was already disabled it will do nothing.
		/// </summary>
		/// <param name="contextMenu">Context menu to disable support for.</param>
		/// <returns>True if it was disabled or already disabled, false if it couldn't be disabled.</returns>
		public static bool DisableMouseHorizontalWheelSupport(ContextMenu contextMenu)
		{
			if (contextMenu == null)
			{
				throw new ArgumentNullException(nameof(contextMenu));
			}

			IntPtr? handle = GetObjectParentHandle(contextMenu);
			if (handle == null)
			{
				return false;
			}

			return DisableMouseHorizontalWheelSupport(handle.Value);
		}


		/// <summary>
		///   Enable Horizontal Wheel support for all that control and all controls hosted by the same window/popup/context menu.
		///   This method does not need to be called if AutoEnableMouseHorizontalWheelSupport is true.
		///   If it was already enabled it will do nothing.
		/// </summary>
		/// <param name="uiElement">UI Element to enable support for.</param>
		public static void EnableMouseHorizontalWheelSupportForParentOf(UIElement uiElement)
		{
			// try to add it right now
			if (uiElement is Window)
			{
				EnableMouseHorizontalWheelSupport((Window)uiElement);
			}
			else if (uiElement is Popup)
			{
				EnableMouseHorizontalWheelSupport((Popup)uiElement);
			}
			else if (uiElement is ContextMenu)
			{
				EnableMouseHorizontalWheelSupport((ContextMenu)uiElement);
			}
			else
			{
				IntPtr? parentHandle = GetObjectParentHandle(uiElement);
				if (parentHandle != null)
				{
					EnableMouseHorizontalWheelSupport(parentHandle.Value);
				}

				// and in the rare case the parent window ever changes...
				PresentationSource.AddSourceChangedHandler(uiElement, PresenationSourceChangedHandler);
			}
		}

		private static void PresenationSourceChangedHandler(object sender, SourceChangedEventArgs sourceChangedEventArgs)
		{
			var src = sourceChangedEventArgs.NewSource as HwndSource;
			if (src != null)
			{
				EnableMouseHorizontalWheelSupport(src.Handle);
			}
		}

		private static void HandleMouseHorizontalWheel(IntPtr wParam)
		{
			int tilt = Win32.HiWord(wParam);
			if (tilt == 0)
			{
				return;
			}

			IInputElement element = Mouse.DirectlyOver;
			if (element == null)
			{
				return;
			}

			if (!(element is UIElement))
			{
				element = UIHelpers.FindAncestor<UIElement>(element as DependencyObject);
			}
			if (element == null)
			{
				return;
			}

			var ev = new MouseHorizontalWheelEventArgs(Mouse.PrimaryDevice, Environment.TickCount, tilt)
			{
				RoutedEvent = PreviewMouseHorizontalWheelEvent
				//Source = handledWindow
			};

			// first raise preview
			element.RaiseEvent(ev);
			if (ev.Handled)
			{
				return;
			}

			// then bubble it
			ev.RoutedEvent = MouseHorizontalWheelEvent;
			element.RaiseEvent(ev);
		}

		private static IntPtr WndProcHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
		{
			// transform horizontal mouse wheel messages 
			switch (msg)
			{
				case Win32.WM_MOUSEHWHEEL:
					HandleMouseHorizontalWheel(wParam);
					break;
			}
			return IntPtr.Zero;
		}

		private static class Win32
		{
			// ReSharper disable InconsistentNaming
			public const int WM_MOUSEHWHEEL = 0x020E;
			// ReSharper restore InconsistentNaming

			public static int GetIntUnchecked(IntPtr value)
			{
				return IntPtr.Size == 8 ? unchecked((int)value.ToInt64()) : value.ToInt32();
			}

			public static int HiWord(IntPtr ptr)
			{
				return unchecked((short)((uint)GetIntUnchecked(ptr) >> 16));
			}
		}

		#region MouseWheelHorizontal Event

		public static readonly RoutedEvent MouseHorizontalWheelEvent =
		  EventManager.RegisterRoutedEvent("MouseHorizontalWheel", RoutingStrategy.Bubble, typeof(RoutedEventHandler),
			typeof(MouseHorizontalWheelEnabler));

		public static void AddMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler)
		{
			var uie = d as UIElement;
			if (uie != null)
			{
				uie.AddHandler(MouseHorizontalWheelEvent, handler);

				if (AutoEnableMouseHorizontalWheelSupport)
				{
					EnableMouseHorizontalWheelSupportForParentOf(uie);
				}
			}
		}

		public static void RemoveMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler)
		{
			var uie = d as UIElement;
			uie?.RemoveHandler(MouseHorizontalWheelEvent, handler);
		}

		#endregion

		#region PreviewMouseWheelHorizontal Event

		public static readonly RoutedEvent PreviewMouseHorizontalWheelEvent =
		  EventManager.RegisterRoutedEvent("PreviewMouseHorizontalWheel", RoutingStrategy.Tunnel, typeof(RoutedEventHandler),
			typeof(MouseHorizontalWheelEnabler));

		public static void AddPreviewMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler)
		{
			var uie = d as UIElement;
			if (uie != null)
			{
				uie.AddHandler(PreviewMouseHorizontalWheelEvent, handler);

				if (AutoEnableMouseHorizontalWheelSupport)
				{
					EnableMouseHorizontalWheelSupportForParentOf(uie);
				}
			}
		}

		public static void RemovePreviewMouseHorizontalWheelHandler(DependencyObject d, RoutedEventHandler handler)
		{
			var uie = d as UIElement;
			uie?.RemoveHandler(PreviewMouseHorizontalWheelEvent, handler);
		}

		#endregion
	}
}
