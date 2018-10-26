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
	}


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
		/// 标签文字水平对齐方向
		/// </summary>
		[XmlIgnore]
		[XmlAttribute("HorizontalContentAlignment")]
		public string TextAlign_Horizontal { get; set; }
		/// <summary>
		/// 背景
		/// </summary>
		[XmlAttribute("Background")]
		public string Background { get; set; }


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
}
