using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuiGenerator
{
	[XmlRoot(Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public class Window
	{
		[XmlElement("Canvas")]
		public Canvas canvas { get; set; }
	}
	/// <summary>
	/// 屏幕
	/// </summary>
	public class Canvas
	{
		public Canvas()
		{

		}
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute]
		public string Height { get; set; }
		/// <summary>
		/// 背景色
		/// </summary>
		[XmlAttribute]
		public string Background { get; set; }
		/// <summary>
		/// 图标
		/// </summary>
		[XmlElement("Image")]
		public List<Icon> IconList { get; set; }
		/// <summary>
		/// 按钮
		/// </summary>
		[XmlElement("Button")]
		public List<Button> BtnList { get; set; }
		/// <summary>
		/// 标签
		/// </summary>
		[XmlElement("Label")]
		public List<Label> LblList { get; set; }
		/// <summary>
		/// 下拉框
		/// </summary>
		[XmlElement("ComboBox")]
		public List<Listbox> LbxList { get; set; }
		/// <summary>
		/// 选择框
		/// </summary>
		[XmlElement("CheckBox")]
		public List<Checkbox> ChkList { get; set; }
		/// <summary>
		/// 文本框
		/// </summary>
		[XmlElement("TextBox")]
		public List<Textbox> TxtList { get; set; }
		/// <summary>
		/// 线段
		/// </summary>
		[XmlElement("Line")]
		public List<Line> LineList { get; set; }
		/// <summary>
		/// 矩形
		/// </summary>
		[XmlElement("Rectangle")]
		public List<Rectangle> RecList { get; set; }
	}

	#region Controls

	/// <summary>
	/// 标签
	/// </summary>
	public class Label
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public int Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public int Height { get; set; }
		/// <summary>
		/// 标签文字
		/// </summary>
		[XmlAttribute("Content")]
		public string Text { get; set; }
		/// <summary>
		/// 背景
		/// </summary>
		[XmlAttribute("Background")]
		public string Background { get; set; }
		/// <summary>
		/// 前景色
		/// </summary>
		[XmlAttribute("Foreground")]
		public string Foreground { get; set; }
		/// <summary>
		/// 字号
		/// </summary>
		[XmlAttribute("FontSize")]
		public int FontSize { get; set; }
		/// <summary>
		/// 水平对齐
		/// </summary>
		[XmlAttribute("HorizontalContentAlignment")]
		public string HorizontalContentAlignment { get; set; }
		/// <summary>
		/// 垂直对齐
		/// </summary>
		[XmlAttribute("VerticalContentAlignment")]
		public string VerticalContentAlignment { get; set; }
		/// <summary>
		/// 文字是否可变（Label|Tag）
		/// </summary>
		[XmlAttribute("IsEnabled")]
		public string IsEnabled { get; set; }
	}
	/// <summary>
	/// 按钮
	/// </summary>
	public class Button
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public string Height { get; set; }
		/// <summary>
		/// 标签文字
		/// </summary>
		[XmlAttribute("Content")]
		public string Text { get; set; }
		/// <summary>
		/// 背景色
		/// </summary>
		[XmlAttribute("Background")]
		public string Background { get; set; }
		/// <summary>
		/// 边框颜色
		/// </summary>
		[XmlAttribute("BorderBrush")]
		public string BorderBrush { get; set; }
	}
	/// <summary>
	/// 图标
	/// </summary>
	public class Icon
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		[XmlIgnore]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public string Height { get; set; }
		/// <summary>
		/// 图片源
		/// </summary>
		[XmlAttribute("Source")]
		public string ImgSrc { get; set; }
	}
	/// <summary>
	/// 文本框
	/// </summary>
	public class Textbox
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public string Height { get; set; }
		/// <summary>
		/// 文本框文字
		/// </summary>
		[XmlAttribute("Content")]
		public string Text { get; set; }
		/// <summary>
		/// 最大长度
		/// </summary>
		[XmlAttribute("MaxLength")]
		public string MaxLength { get; set; }
	}
	/// <summary>
	/// 下拉框
	/// </summary>
	public class Listbox
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public string Height { get; set; }
	}
	/// <summary>
	/// 选择框
	/// </summary>
	public class Checkbox
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public string Height { get; set; }
		/// <summary>
		/// 选择框文字
		/// </summary>
		[XmlAttribute("Content")]
		public string Text { get; set; }
		/// <summary>
		/// 是否选中
		/// </summary>
		[XmlAttribute("IsChecked")]
		public string IsChecked { get; set; }
	}
	#endregion

	#region Draw

	public class Line
	{
		/// <summary>
		/// name
		/// </summary>
		[XmlAttribute(Namespace = "Name")]
		public string Name { get; set; }
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置 Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 起点横坐标 = X+X1
		/// </summary>
		[XmlAttribute("X1")]
		public string X1 { get; set; }
		/// <summary>
		/// 起点纵坐标 = Y+Y1
		/// </summary>
		[XmlAttribute("Y1")]
		public string Y1 { get; set; }
		/// <summary>
		/// 终点横坐标 = X+X2
		/// </summary>
		[XmlAttribute("X2")]
		public string X2 { get; set; }
		/// <summary>
		/// 终点纵坐标 = Y+Y2
		/// </summary>
		[XmlAttribute("Y2")]
		public string Y2 { get; set; }
		/// <summary>
		/// 颜色
		/// </summary>
		[XmlAttribute("Stroke")]
		public string Stroke { get; set; }
		/// <summary>
		/// 线粗细
		/// </summary>
		[XmlAttribute("StrokeThickness")]
		public string StrokeThickness { get; set; }
	}

	public class Rectangle
	{
		/// <summary>
		/// 位置-X
		/// </summary>
		[XmlAttribute("Canvas.Left")]
		public string X { get; set; }
		/// <summary>
		/// 位置Y
		/// </summary>
		[XmlAttribute("Canvas.Top")]
		public string Y { get; set; }
		/// <summary>
		/// 宽
		/// </summary>
		[XmlAttribute("Width")]
		public string Width { get; set; }
		/// <summary>
		/// 高
		/// </summary>
		[XmlAttribute("Height")]
		public string Height { get; set; }
		/// <summary>
		/// X 圆角半径
		/// </summary>
		[XmlAttribute("RadiusX")]
		public string RadiusX { get; set; }
		/// <summary>
		/// Y 圆角半径
		/// </summary>
		[XmlAttribute("RadiusY")]
		public string RadiusY { get; set; }
		/// <summary>
		/// 边线颜色
		/// </summary>
		[XmlAttribute("Stroke")]
		public string Stroke { get; set; }
		/// <summary>
		/// 边线粗细
		/// </summary>
		[XmlAttribute("StrokeThickness")]
		public string StrokeThickness { get; set; }
		/// <summary>
		/// 填充色
		/// </summary>
		[XmlAttribute("Fill")]
		public string Fill { get; set; }

	}
	#endregion

	#region Extention 
	#endregion
}
