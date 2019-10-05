using System.Windows;
using System.Windows.Media;
using ICSharpCode.WpfDesign.Designer;
using NUnit.Framework;

namespace ICSharpCode.WpfDesign.Tests.Designer
{
	public class TransformTests : ModelTestHelper
	{
		internal static void Rotate(double angle, DesignItem item)
		{
			ModelTools.ApplyTransform(item, new RotateTransform(angle, 0.5, 0.5));
		}

		[Test]
		public void RotateSkewedButton()
		{
			DesignItem button = CreateCanvasContext(
				"<Button Content='Button' Width='75' Height='23' RenderTransformOrigin='0.5,0.5'>"
				+ "<Button.RenderTransform>"
				+ "<SkewTransform AngleY='-45' />"
				+ "</Button.RenderTransform>"
				+ "</Button>");
			Rotate(30, button);
			//AssertCanvasDesignerOutput();
		}
	}
}