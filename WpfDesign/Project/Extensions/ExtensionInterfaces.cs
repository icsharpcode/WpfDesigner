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

using System.Windows.Input;

namespace ICSharpCode.WpfDesign.Extensions
{
	/// <summary>
	/// interface that can be implemented if a control is to be alerted of  KeyDown Event on DesignPanel
	/// </summary>
	public interface IKeyDown
	{
		/// <summary>
		/// Action to be performed on keydown on specific control
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void KeyDownAction(object sender, KeyEventArgs e);

		/// <summary>
		/// if that control wants the default DesignPanel action to be suppressed, let this return false
		/// </summary>
		bool InvokeDefaultAction { get; }
	}

	/// <summary>
	/// interface that can be implemented if a control is to be alerted of  KeyUp Event on DesignPanel
	/// </summary>
	public interface IKeyUp
	{
		/// <summary>
		/// Action to be performed on keyup on specific control
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void KeyUpAction(object sender, KeyEventArgs e);
	}

	
}
