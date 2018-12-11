using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiGenerator.GuiEntity
{
	class GuiEntity
	{
	}


	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation", IsNullable = false)]
	public partial class Window
	{

		private WindowCanvas canvasField;

		private ushort widthField;

		private ushort heightField;

		private string ignorableField;

		/// <remarks/>
		public WindowCanvas Canvas
		{
			get
			{
				return canvasField;
			}
			set
			{
				canvasField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.openxmlformats.org/markup-compatibility/2006")]
		public string Ignorable
		{
			get
			{
				return ignorableField;
			}
			set
			{
				ignorableField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvas
	{

		private object[] itemsField;

		private string nameField;

		private ushort widthField;

		private ushort heightField;

		private string backgroundField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Button", typeof(WindowCanvasButton))]
		[System.Xml.Serialization.XmlElementAttribute("CheckBox", typeof(WindowCanvasCheckBox))]
		[System.Xml.Serialization.XmlElementAttribute("ComboBox", typeof(WindowCanvasComboBox))]
		[System.Xml.Serialization.XmlElementAttribute("Grid", typeof(WindowCanvasGrid))]
		[System.Xml.Serialization.XmlElementAttribute("Image", typeof(WindowCanvasImage))]
		[System.Xml.Serialization.XmlElementAttribute("Label", typeof(WindowCanvasLabel))]
		[System.Xml.Serialization.XmlElementAttribute("Line", typeof(WindowCanvasLine))]
		[System.Xml.Serialization.XmlElementAttribute("Rectangle", typeof(WindowCanvasRectangle))]
		[System.Xml.Serialization.XmlElementAttribute("TextBox", typeof(WindowCanvasTextBox))]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasButton
	{

		private string nameField;

		private string contentField;

		private ushort widthField;

		private ushort heightField;

		private string backgroundField;

		private string borderBrushField;

		private ushort fontSizeField;

		private string foregroundField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string BorderBrush
		{
			get
			{
				return borderBrushField;
			}
			set
			{
				borderBrushField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasCheckBox
	{

		private string contentField;

		private ushort widthField;

		private ushort heightField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private string foregroundField;

		private ushort fontSizeField;

		private string isCheckedField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return horizontalContentAlignmentField;
			}
			set
			{
				horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return verticalContentAlignmentField;
			}
			set
			{
				verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsChecked
		{
			get
			{
				return isCheckedField;
			}
			set
			{
				isCheckedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasComboBox
	{

		private WindowCanvasComboBoxComboBoxItem[] comboBoxItemField;

		private string nameField;

		private ushort widthField;

		private ushort heightField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private ushort fontSizeField;

		private string foregroundField;

		private ushort textField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ComboBoxItem")]
		public WindowCanvasComboBoxComboBoxItem[] ComboBoxItem
		{
			get
			{
				return comboBoxItemField;
			}
			set
			{
				comboBoxItemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return horizontalContentAlignmentField;
			}
			set
			{
				horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return verticalContentAlignmentField;
			}
			set
			{
				verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Text
		{
			get
			{
				return textField;
			}
			set
			{
				textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasComboBoxComboBoxItem
	{

		private string contentField;

		private ushort fontSizeField;

		private bool fontSizeFieldSpecified;

		private string foregroundField;

		private string isSelectedField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool FontSizeSpecified
		{
			get
			{
				return fontSizeFieldSpecified;
			}
			set
			{
				fontSizeFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsSelected
		{
			get
			{
				return isSelectedField;
			}
			set
			{
				isSelectedField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGrid
	{

		private object[] itemsField;

		private string nameField;

		private ushort widthField;

		private ushort heightField;

		private string backgroundField;

		private string isEnabledField;

		private string isHitTestVisibleField;

		private string isManipulationEnabledField;

		private string showGridLinesField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Button", typeof(WindowCanvasGridButton))]
		[System.Xml.Serialization.XmlElementAttribute("CheckBox", typeof(WindowCanvasGridCheckBox))]
		[System.Xml.Serialization.XmlElementAttribute("ComboBox", typeof(WindowCanvasGridComboBox))]
		[System.Xml.Serialization.XmlElementAttribute("Grid.ColumnDefinitions", typeof(WindowCanvasGridGridColumnDefinitions))]
		[System.Xml.Serialization.XmlElementAttribute("Grid.RowDefinitions", typeof(WindowCanvasGridGridRowDefinitions))]
		[System.Xml.Serialization.XmlElementAttribute("Image", typeof(WindowCanvasGridImage))]
		[System.Xml.Serialization.XmlElementAttribute("Label", typeof(WindowCanvasGridLabel))]
		[System.Xml.Serialization.XmlElementAttribute("Rectangle", typeof(WindowCanvasGridRectangle))]
		[System.Xml.Serialization.XmlElementAttribute("TextBox", typeof(WindowCanvasGridTextBox))]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsEnabled
		{
			get
			{
				return isEnabledField;
			}
			set
			{
				isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsHitTestVisible
		{
			get
			{
				return isHitTestVisibleField;
			}
			set
			{
				isHitTestVisibleField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsManipulationEnabled
		{
			get
			{
				return isManipulationEnabledField;
			}
			set
			{
				isManipulationEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string ShowGridLines
		{
			get
			{
				return showGridLinesField;
			}
			set
			{
				showGridLinesField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridButton
	{

		private string nameField;

		private string contentField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private string backgroundField;

		private string borderBrushField;

		private ushort fontSizeField;

		private string foregroundField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string BorderBrush
		{
			get
			{
				return borderBrushField;
			}
			set
			{
				borderBrushField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridCheckBox
	{

		private string nameField;

		private string contentField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private ushort fontSizeField;

		private string isCheckedField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return horizontalContentAlignmentField;
			}
			set
			{
				horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return verticalContentAlignmentField;
			}
			set
			{
				verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsChecked
		{
			get
			{
				return isCheckedField;
			}
			set
			{
				isCheckedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridComboBox
	{

		private string nameField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private ushort fontSizeField;

		private string foregroundField;

		private ushort textField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Text
		{
			get
			{
				return textField;
			}
			set
			{
				textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridColumnDefinitions
	{

		private WindowCanvasGridGridColumnDefinitionsColumnDefinition[] columnDefinitionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ColumnDefinition")]
		public WindowCanvasGridGridColumnDefinitionsColumnDefinition[] ColumnDefinition
		{
			get
			{
				return columnDefinitionField;
			}
			set
			{
				columnDefinitionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridColumnDefinitionsColumnDefinition
	{

		private string widthField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridRowDefinitions
	{

		private WindowCanvasGridGridRowDefinitionsRowDefinition[] rowDefinitionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("RowDefinition")]
		public WindowCanvasGridGridRowDefinitionsRowDefinition[] RowDefinition
		{
			get
			{
				return rowDefinitionField;
			}
			set
			{
				rowDefinitionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridRowDefinitionsRowDefinition
	{

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridImage
	{

		private string nameField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridLabel
	{

		private string nameField;

		private string contentField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private string backgroundField;

		private ushort fontSizeField;

		private string foregroundField;

		private string isEnabledField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return horizontalContentAlignmentField;
			}
			set
			{
				horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return verticalContentAlignmentField;
			}
			set
			{
				verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsEnabled
		{
			get
			{
				return isEnabledField;
			}
			set
			{
				isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridRectangle
	{

		private string nameField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private string fillField;

		private string strokeField;

		private ushort strokeThicknessField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Fill
		{
			get
			{
				return fillField;
			}
			set
			{
				fillField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Stroke
		{
			get
			{
				return strokeField;
			}
			set
			{
				strokeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort StrokeThickness
		{
			get
			{
				return strokeThicknessField;
			}
			set
			{
				strokeThicknessField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridTextBox
	{

		private string nameField;

		private string marginField;

		private string horizontalAlignmentField;

		private string verticalAlignmentField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private string backgroundField;

		private ushort fontSizeField;

		private bool fontSizeFieldSpecified;

		private string foregroundField;

		private string isEnabledField;

		private string textAlignmentField;

		private ushort gridColumnField;

		private ushort gridRowField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Margin
		{
			get
			{
				return marginField;
			}
			set
			{
				marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return horizontalAlignmentField;
			}
			set
			{
				horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return horizontalContentAlignmentField;
			}
			set
			{
				horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return verticalContentAlignmentField;
			}
			set
			{
				verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool FontSizeSpecified
		{
			get
			{
				return fontSizeFieldSpecified;
			}
			set
			{
				fontSizeFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsEnabled
		{
			get
			{
				return isEnabledField;
			}
			set
			{
				isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string TextAlignment
		{
			get
			{
				return textAlignmentField;
			}
			set
			{
				textAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return gridColumnField;
			}
			set
			{
				gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return gridRowField;
			}
			set
			{
				gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasImage
	{

		private string nameField;

		private ushort widthField;

		private ushort heightField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasLabel
	{

		private string nameField;

		private string contentField;

		private ushort widthField;

		private ushort heightField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private string backgroundField;

		private ushort fontSizeField;

		private string foregroundField;

		private string isEnabledField;

		private string paddingField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		private string renderTransformOriginField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Content
		{
			get
			{
				return contentField;
			}
			set
			{
				contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return horizontalContentAlignmentField;
			}
			set
			{
				horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return verticalContentAlignmentField;
			}
			set
			{
				verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Background
		{
			get
			{
				return backgroundField;
			}
			set
			{
				backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string IsEnabled
		{
			get
			{
				return isEnabledField;
			}
			set
			{
				isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Padding
		{
			get
			{
				return paddingField;
			}
			set
			{
				paddingField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string RenderTransformOrigin
		{
			get
			{
				return renderTransformOriginField;
			}
			set
			{
				renderTransformOriginField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasLine
	{

		private string nameField;

		private string stretchField;

		private string strokeField;

		private ushort strokeThicknessField;

		private ushort x1Field;

		private ushort x2Field;

		private ushort y1Field;

		private ushort y2Field;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Stretch
		{
			get
			{
				return stretchField;
			}
			set
			{
				stretchField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Stroke
		{
			get
			{
				return strokeField;
			}
			set
			{
				strokeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort StrokeThickness
		{
			get
			{
				return strokeThicknessField;
			}
			set
			{
				strokeThicknessField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort X1
		{
			get
			{
				return x1Field;
			}
			set
			{
				x1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort X2
		{
			get
			{
				return x2Field;
			}
			set
			{
				x2Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Y1
		{
			get
			{
				return y1Field;
			}
			set
			{
				y1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Y2
		{
			get
			{
				return y2Field;
			}
			set
			{
				y2Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasRectangle
	{

		private ushort widthField;

		private ushort heightField;

		private string fillField;

		private ushort radiusXField;

		private ushort radiusYField;

		private string strokeField;

		private ushort strokeThicknessField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Fill
		{
			get
			{
				return fillField;
			}
			set
			{
				fillField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort RadiusX
		{
			get
			{
				return radiusXField;
			}
			set
			{
				radiusXField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort RadiusY
		{
			get
			{
				return radiusYField;
			}
			set
			{
				radiusYField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Stroke
		{
			get
			{
				return strokeField;
			}
			set
			{
				strokeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort StrokeThickness
		{
			get
			{
				return strokeThicknessField;
			}
			set
			{
				strokeThicknessField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategory("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasTextBox
	{

		private string nameField;

		private ushort widthField;

		private ushort heightField;

		private string verticalAlignmentField;

		private ushort fontSizeField;

		private string foregroundField;

		private ushort maxLengthField;

		private string textField;

		private string textAlignmentField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Width
		{
			get
			{
				return widthField;
			}
			set
			{
				widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort Height
		{
			get
			{
				return heightField;
			}
			set
			{
				heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return verticalAlignmentField;
			}
			set
			{
				verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Foreground
		{
			get
			{
				return foregroundField;
			}
			set
			{
				foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public ushort MaxLength
		{
			get
			{
				return maxLengthField;
			}
			set
			{
				maxLengthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string Text
		{
			get
			{
				return textField;
			}
			set
			{
				textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute()]
		public string TextAlignment
		{
			get
			{
				return textAlignmentField;
			}
			set
			{
				textAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return canvasLeftField;
			}
			set
			{
				canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return canvasTopField;
			}
			set
			{
				canvasTopField = value;
			}
		}
	}



}
