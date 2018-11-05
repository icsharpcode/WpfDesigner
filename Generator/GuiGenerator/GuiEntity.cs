using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiGenerator
{
	class GuiEntity
	{
	}


	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
				return this.canvasField;
			}
			set
			{
				this.canvasField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.openxmlformats.org/markup-compatibility/2006")]
		public string Ignorable
		{
			get
			{
				return this.ignorableField;
			}
			set
			{
				this.ignorableField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string BorderBrush
		{
			get
			{
				return this.borderBrushField;
			}
			set
			{
				this.borderBrushField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasCheckBox
	{

		private string contentField;

		private ushort widthField;

		private ushort heightField;

		private string horizontalContentAlignmentField;

		private string verticalContentAlignmentField;

		private ushort fontSizeField;

		private string isCheckedField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return this.horizontalContentAlignmentField;
			}
			set
			{
				this.horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return this.verticalContentAlignmentField;
			}
			set
			{
				this.verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsChecked
		{
			get
			{
				return this.isCheckedField;
			}
			set
			{
				this.isCheckedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
				return this.comboBoxItemField;
			}
			set
			{
				this.comboBoxItemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return this.horizontalContentAlignmentField;
			}
			set
			{
				this.horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return this.verticalContentAlignmentField;
			}
			set
			{
				this.verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasComboBoxComboBoxItem
	{

		private string contentField;

		private ushort fontSizeField;

		private bool fontSizeFieldSpecified;

		private string foregroundField;

		private string isSelectedField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool FontSizeSpecified
		{
			get
			{
				return this.fontSizeFieldSpecified;
			}
			set
			{
				this.fontSizeFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsSelected
		{
			get
			{
				return this.isSelectedField;
			}
			set
			{
				this.isSelectedField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
				return this.itemsField;
			}
			set
			{
				this.itemsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsEnabled
		{
			get
			{
				return this.isEnabledField;
			}
			set
			{
				this.isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsHitTestVisible
		{
			get
			{
				return this.isHitTestVisibleField;
			}
			set
			{
				this.isHitTestVisibleField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsManipulationEnabled
		{
			get
			{
				return this.isManipulationEnabledField;
			}
			set
			{
				this.isManipulationEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string ShowGridLines
		{
			get
			{
				return this.showGridLinesField;
			}
			set
			{
				this.showGridLinesField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string BorderBrush
		{
			get
			{
				return this.borderBrushField;
			}
			set
			{
				this.borderBrushField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return this.horizontalContentAlignmentField;
			}
			set
			{
				this.horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return this.verticalContentAlignmentField;
			}
			set
			{
				this.verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsChecked
		{
			get
			{
				return this.isCheckedField;
			}
			set
			{
				this.isCheckedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridColumnDefinitions
	{

		private WindowCanvasGridGridColumnDefinitionsColumnDefinition[] columnDefinitionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ColumnDefinition")]
		public WindowCanvasGridGridColumnDefinitionsColumnDefinition[] ColumnDefinition
		{
			get
			{
				return this.columnDefinitionField;
			}
			set
			{
				this.columnDefinitionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridColumnDefinitionsColumnDefinition
	{

		private string widthField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridRowDefinitions
	{

		private WindowCanvasGridGridRowDefinitionsRowDefinition[] rowDefinitionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("RowDefinition")]
		public WindowCanvasGridGridRowDefinitionsRowDefinition[] RowDefinition
		{
			get
			{
				return this.rowDefinitionField;
			}
			set
			{
				this.rowDefinitionField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasGridGridRowDefinitionsRowDefinition
	{

		private string nameField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return this.horizontalContentAlignmentField;
			}
			set
			{
				this.horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return this.verticalContentAlignmentField;
			}
			set
			{
				this.verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsEnabled
		{
			get
			{
				return this.isEnabledField;
			}
			set
			{
				this.isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Fill
		{
			get
			{
				return this.fillField;
			}
			set
			{
				this.fillField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Stroke
		{
			get
			{
				return this.strokeField;
			}
			set
			{
				this.strokeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort StrokeThickness
		{
			get
			{
				return this.strokeThicknessField;
			}
			set
			{
				this.strokeThicknessField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Margin
		{
			get
			{
				return this.marginField;
			}
			set
			{
				this.marginField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalAlignment
		{
			get
			{
				return this.horizontalAlignmentField;
			}
			set
			{
				this.horizontalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return this.horizontalContentAlignmentField;
			}
			set
			{
				this.horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return this.verticalContentAlignmentField;
			}
			set
			{
				this.verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool FontSizeSpecified
		{
			get
			{
				return this.fontSizeFieldSpecified;
			}
			set
			{
				this.fontSizeFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsEnabled
		{
			get
			{
				return this.isEnabledField;
			}
			set
			{
				this.isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string TextAlignment
		{
			get
			{
				return this.textAlignmentField;
			}
			set
			{
				this.textAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Column")]
		public ushort GridColumn
		{
			get
			{
				return this.gridColumnField;
			}
			set
			{
				this.gridColumnField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Grid.Row")]
		public ushort GridRow
		{
			get
			{
				return this.gridRowField;
			}
			set
			{
				this.gridRowField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
	public partial class WindowCanvasImage
	{

		private string nameField;

		private ushort widthField;

		private ushort heightField;

		private ushort canvasLeftField;

		private ushort canvasTopField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Content
		{
			get
			{
				return this.contentField;
			}
			set
			{
				this.contentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string HorizontalContentAlignment
		{
			get
			{
				return this.horizontalContentAlignmentField;
			}
			set
			{
				this.horizontalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalContentAlignment
		{
			get
			{
				return this.verticalContentAlignmentField;
			}
			set
			{
				this.verticalContentAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Background
		{
			get
			{
				return this.backgroundField;
			}
			set
			{
				this.backgroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string IsEnabled
		{
			get
			{
				return this.isEnabledField;
			}
			set
			{
				this.isEnabledField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Padding
		{
			get
			{
				return this.paddingField;
			}
			set
			{
				this.paddingField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string RenderTransformOrigin
		{
			get
			{
				return this.renderTransformOriginField;
			}
			set
			{
				this.renderTransformOriginField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Stretch
		{
			get
			{
				return this.stretchField;
			}
			set
			{
				this.stretchField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Stroke
		{
			get
			{
				return this.strokeField;
			}
			set
			{
				this.strokeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort StrokeThickness
		{
			get
			{
				return this.strokeThicknessField;
			}
			set
			{
				this.strokeThicknessField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort X1
		{
			get
			{
				return this.x1Field;
			}
			set
			{
				this.x1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort X2
		{
			get
			{
				return this.x2Field;
			}
			set
			{
				this.x2Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Y1
		{
			get
			{
				return this.y1Field;
			}
			set
			{
				this.y1Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Y2
		{
			get
			{
				return this.y2Field;
			}
			set
			{
				this.y2Field = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Fill
		{
			get
			{
				return this.fillField;
			}
			set
			{
				this.fillField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort RadiusX
		{
			get
			{
				return this.radiusXField;
			}
			set
			{
				this.radiusXField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort RadiusY
		{
			get
			{
				return this.radiusYField;
			}
			set
			{
				this.radiusYField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Stroke
		{
			get
			{
				return this.strokeField;
			}
			set
			{
				this.strokeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort StrokeThickness
		{
			get
			{
				return this.strokeThicknessField;
			}
			set
			{
				this.strokeThicknessField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
	}

	/// <remarks/>
	[System.SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml/presentation")]
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
		[System.Xml.Serialization.XmlAttributeAttribute(Form = System.Xml.Schema.XmlSchemaForm.Qualified, Namespace = "http://schemas.microsoft.com/winfx/2006/xaml")]
		public string Name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Width
		{
			get
			{
				return this.widthField;
			}
			set
			{
				this.widthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort Height
		{
			get
			{
				return this.heightField;
			}
			set
			{
				this.heightField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string VerticalAlignment
		{
			get
			{
				return this.verticalAlignmentField;
			}
			set
			{
				this.verticalAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort FontSize
		{
			get
			{
				return this.fontSizeField;
			}
			set
			{
				this.fontSizeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Foreground
		{
			get
			{
				return this.foregroundField;
			}
			set
			{
				this.foregroundField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public ushort MaxLength
		{
			get
			{
				return this.maxLengthField;
			}
			set
			{
				this.maxLengthField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Text
		{
			get
			{
				return this.textField;
			}
			set
			{
				this.textField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string TextAlignment
		{
			get
			{
				return this.textAlignmentField;
			}
			set
			{
				this.textAlignmentField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Left")]
		public ushort CanvasLeft
		{
			get
			{
				return this.canvasLeftField;
			}
			set
			{
				this.canvasLeftField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute("Canvas.Top")]
		public ushort CanvasTop
		{
			get
			{
				return this.canvasTopField;
			}
			set
			{
				this.canvasTopField = value;
			}
		}
	}



}
