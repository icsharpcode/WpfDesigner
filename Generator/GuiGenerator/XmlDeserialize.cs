using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Media;
using System.Reflection;

namespace GuiGenerator
{
	public class XmlDeserialize
	{
		private static Window window;
		/// <summary>
		/// 获取界面设计
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string ScreenSettings(string path)
		{
			window = (Window)DeserializeFile<Window>(path);
			string output = "";
			if (window != null)
			{
				WindowCanvas canvas = window.Canvas;

				if (canvas != null)
				{
					output = GetScreenSettingCode(canvas);
				}
			}
			return output;
		}
		/// <summary>
		/// XML文件反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlFile"></param>
		/// <returns></returns>
		public static object DeserializeFile<T>(string xmlFile)
		{
			try
			{
				using (StreamReader sr = new StreamReader(xmlFile))
				{
					XmlSerializer xmldes = new XmlSerializer(typeof(T));
					return xmldes.Deserialize(sr);
				}
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		#region Extend

		private static string FONT = "FONT{0}_SONGTI";
		private static string COLOR = "RGB888toRGB565({0}, {1}, {2})";

		private static string ScreenInitCode = "GUI_ScreenInit(&{0},{1},{2},NULL,NULL);";
		private static string IconInitCode = "GUI_IconInit(&sc_menu_icons[{0}],{1},{2},{3},{4},&{5},NULL);";
		private static string LabelInitCode = "GUI_LabelInit({0},{1},{2},{3},{4},{5},{6},\"{7}\",{8},{9});";
		private static string ButtonInitCode = "GUI_ButtonInit({0},{1},{2},{3},{4},{5},{6});";
		private static string ButtonSetTextCode = "GUI_ButtonSetText({0},\"{1}\",{2});";
		private static string TextboxInitCode = "GUI_TextboxInit({0},{1},{2},{3},{4},{5},{6});";	
		private static string CheckboxInitCode = "GUI_CheckboxInit(struct checkbox *ckb,{0},{1},BLACK,\"{2}\"," + FONT + ");";
		private static string CheckboxSetCode = "GUI_CheckboxSet(struct checkbox *ckb,{0});";
		private static string ListboxInitCode = "GUI_ListboxInit({0},{1},{2},{3},{4},{5},{6},{7});";
		private static string ListboxSetItemsCode = "GUI_ListboxSetItems({0},{1},{2});";

		#region Tag
		private static string Draw_Tag_Code = "GUI_DrawTag({0},{1},{2},{3},{4},{5},\"{6}\",{7},{8});";

		private static string TagArr_Code = "const u16 dimensions_tag[{0}][8] ={{\r{1}}};";
		private static string TagArr_Text_Code = "const char* text_tag[{0}] = {{\r{1}}};";
		private static string TagArrItem_Code = "\t{{{0},{1},{2},{3},{4},{5},{6},{7}}},";
		private static string TagArrItem_Text_Code = "\t\"{0}\",";

		private static string Draw_TagArr_Code =
			"for(i=0;i<sizeof(dimensions_tag)/sizeof(dimensions_tag[0]);i++)" + Environment.NewLine
			+ "\t" + "GUI_DrawTag(" + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][0]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][1]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][2]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][3]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][4]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][5]," + Environment.NewLine
			+ "\t" + "\t" + "text_tag[i]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][6]," + Environment.NewLine
			+ "\t" + "\t" + "dimensions_tag[i][7]" + Environment.NewLine
			+ "\t" + "\t" + ");"
			;

		#endregion

		private static string Draw_Line_Code = "GUI_DrawLine({0},{1},{2},{3},{4});";
		#region Rectangle
		private static string Draw_Rect_Code_Normal = "GUI_FillRect({0},{1},{2},{3},{4});";
		private static string Draw_Rect_Code_Round = "GUI_FillRoundRect({0},{1},{2}, {3},{4},{5});";

		private static string RectArrItem_Code_Normal = "\t{{{0},{1},{2},{3},{4}}},";
		private static string RectArrItem_Code_Round = "\t{{{0},{1},{2},{3},{4},{5}}},";		
		private static string RectArr_Code_Normal = "const u16 dimensions_rect1[{0}][5] = {{\r{1}}};";//填充矩形
		private static string RectArr_Code_Round = "const u16 dimensions_rect2[{0}][5] = {{\r{1}}};";//填充圆角矩形
		private static string RectLineArr_Code_Normal = "const u16 dimensions_rect3[{0}][5] = {{\r{1}}};";//矩形框
		private static string RectLineArr_Code_Round = "const u16 dimensions_rect4[{0}][5] = {{\r{1}}};";//圆角矩形框
		#endregion
		private enum AlignType
		{
			Hrizontal = 0,
			Vertical
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="entity"></param>
		/// <returns></returns>
		private static string GetScreenSettingCode(WindowCanvas entity)
		{
			try
			{
				#region Define
				string output = "";
				string initStr = "";//控件初始化
				string controlStr = "";//控件
				string drawStr = "";//绘制图形
				List<WindowCanvasImage> IconList = new List<WindowCanvasImage>();
				List<WindowCanvasButton> BtnList = new List<WindowCanvasButton>();
				List<WindowCanvasCheckBox> ChkList = new List<WindowCanvasCheckBox>();
				List<WindowCanvasComboBox> LbxList = new List<WindowCanvasComboBox>();
				List<WindowCanvasLabel> LblList = new List<WindowCanvasLabel>();
				List<WindowCanvasLabel> TagList = new List<WindowCanvasLabel>();
				List<WindowCanvasTextBox> TxtList = new List<WindowCanvasTextBox>();
				List<WindowCanvasGrid> GridList = new List<WindowCanvasGrid>();
				List<WindowCanvasLine> LineList = new List<WindowCanvasLine>();
				List<WindowCanvasRectangle> RecList = new List<WindowCanvasRectangle>();
				#endregion
				#region Screen
				string screenStr = "//============Screen============" + Environment.NewLine;
				string screen_background = GetRGB565Code(entity.Background);
				screenStr += string.Format(ScreenInitCode, entity.Name, 3, screen_background) + Environment.NewLine;
				controlStr += screenStr;
				if (entity.Items != null)
				{
					foreach (var item in entity.Items)
					{
						if (item is WindowCanvasImage)
							IconList.Add(item as WindowCanvasImage);
						else if (item is WindowCanvasButton)
							BtnList.Add(item as WindowCanvasButton);
						else if (item is WindowCanvasCheckBox)
							ChkList.Add(item as WindowCanvasCheckBox);
						else if (item is WindowCanvasComboBox)
							LbxList.Add(item as WindowCanvasComboBox);
						else if (item is WindowCanvasLabel)
						{
							WindowCanvasLabel label = item as WindowCanvasLabel;
							switch (label.IsEnabled)
							{
								case "True":
									LblList.Add(label);
									break;
								case "False":
									TagList.Add(label);
									break;
								default:
									break;
							}
						}
						else if (item is WindowCanvasTextBox)
							TxtList.Add(item as WindowCanvasTextBox);
						else if (item is WindowCanvasGrid)
							GridList.Add(item as WindowCanvasGrid);
						else if (item is WindowCanvasLine)
							LineList.Add(item as WindowCanvasLine);
						else if (item is WindowCanvasRectangle)
							RecList.Add(item as WindowCanvasRectangle);
						else if (item is WindowCanvasGrid)
							GridList.Add(item as WindowCanvasGrid);
					}
					#region Grid
					if (GridList != null && GridList?.Count > 0)
					{
						foreach (var grid in GridList)
						{
							if (grid != null)
							{
								foreach (var item in grid.Items)
								{
									if (item is WindowCanvasGridImage)
									{
										WindowCanvasImage icon = new WindowCanvasImage();
										Mapper(item, ref icon);
										IconList.Add(icon);
									}
									else if (item is WindowCanvasGridButton)
									{
										WindowCanvasButton btn = new WindowCanvasButton();
										Mapper(item, ref btn);
										BtnList.Add(btn);
									}
									else if (item is WindowCanvasGridCheckBox)
									{
										WindowCanvasCheckBox chk = new WindowCanvasCheckBox();
										Mapper(item, ref chk);
										ChkList.Add(chk);
									}
									else if (item is WindowCanvasGridComboBox)
									{
										WindowCanvasComboBox lbx = new WindowCanvasComboBox();
										Mapper(item, ref lbx);
										LbxList.Add(lbx);
									}
									else if (item is WindowCanvasGridLabel)
									{
										WindowCanvasLabel label = new WindowCanvasLabel();
										Mapper(item, ref label);
										switch (label.IsEnabled)
										{
											case "True":
												LblList.Add(label);
												break;
											case "False":
												TagList.Add(label);
												break;
											default:
												break;
										}
									}
									else if (item is WindowCanvasGridTextBox)
									{
										WindowCanvasTextBox txt = new WindowCanvasTextBox();
										Mapper(item, ref txt);
										TxtList.Add(txt);
									}
									else if (item is WindowCanvasGridRectangle)
									{
										WindowCanvasRectangle rect = new WindowCanvasRectangle();
										Mapper(item, ref rect);
										RecList.Add(rect);
									}
								}
							}
						}
					}
					#endregion
				}

				#region Controls


				if (IconList != null && IconList?.Count > 0)
				{
					initStr += string.Format("struct icon {0}_icons[{1}];", entity.Name, IconList.Count) + Environment.NewLine;
					controlStr += GetIconSettings(IconList);
				}
				if (LblList != null && LblList?.Count > 0)
				{
					initStr += string.Format("struct label {0}_labs[{1}];", entity.Name, LblList.Count) + Environment.NewLine;
					controlStr += GetLabelSettings(LblList);
				}
				if (BtnList != null && BtnList?.Count > 0)
				{
					initStr += string.Format("struct button {0}_btns[{1}];", entity.Name, BtnList.Count) + Environment.NewLine;
					controlStr += GetButtonSettings(BtnList);
				}
				if (ChkList != null && ChkList?.Count > 0)//checkbox
				{
					initStr += string.Format("struct checkbox {0}_ckbs[{1}];", entity.Name, ChkList.Count) + Environment.NewLine;
					controlStr += GetCheckBoxSettings(ChkList);
				}
				if (TxtList != null && TxtList?.Count > 0)//textbox
				{
					initStr += string.Format("struct textbox {0}_tbxs[{1}];", entity.Name, TxtList.Count) + Environment.NewLine;
					controlStr += GetTextBoxSettings(TxtList);
				}
				if (LbxList != null && LbxList?.Count > 0)//listbox
				{
					initStr += string.Format("struct listbox {0}_lbxs[{1}];", entity.Name, LbxList.Count) + Environment.NewLine;
					controlStr += GetListBoxSettings(LbxList);
				}
				#endregion

				#region Draw
				if (LineList != null && LineList?.Count > 0)//line
					drawStr += GetDrawLineSettings(LineList);
				if (RecList != null && RecList?.Count > 0)//rectangle
					drawStr += GetDrawRectSettings(RecList);
				if (TagList != null && TagList?.Count > 0)//tag
					drawStr += GetTagSettings(TagList);

				#endregion

				#endregion
				output = initStr + controlStr + drawStr;
				return output;
			}
			catch (Exception e)
			{
				string output = e.Message;
				return output;
			}
		}
		/// <summary>
		/// Icon
		/// </summary>
		/// <param name="IconList"></param>
		/// <returns></returns>
		private static string GetIconSettings(List<WindowCanvasImage> IconList)
		{
			string iconStr = "//============Icon============" + Environment.NewLine;
			for (int i = 0; i < IconList.Count; i++)
			{
				var icon = IconList[i];
				iconStr += string.Format(IconInitCode, i, icon.CanvasLeft, icon.CanvasTop, icon.Width, icon.Height, icon.Name) + Environment.NewLine;
			}
			return iconStr;
		}
		/// <summary>
		/// Button
		/// </summary>
		/// <param name="BtnList"></param>
		/// <returns></returns>
		private static string GetButtonSettings(List<WindowCanvasButton> BtnList)
		{
			string btnStr = "//============Button============" + Environment.NewLine;
			for (int i = 0; i < BtnList.Count; i++)
			{
				var btn = BtnList[i];
				string btnName = window.Canvas.Name + "_btns+" + i;
				btnStr += string.Format(ButtonInitCode,
					btnName,
					btn.CanvasLeft,
					btn.CanvasTop,
					btn.Width,
					btn.Height,
					GetRGB565Code(btn.Background),
					GetRGB565Code(btn.Foreground)) + Environment.NewLine;
				btnStr += string.Format(ButtonSetTextCode,
					btnName,
					btn.Content,
					GetFontSizeCode(btn.FontSize)) + Environment.NewLine;
			}
			return btnStr;
		}
		/// <summary>
		/// Label
		/// </summary>
		/// <param name="LblList"></param>
		/// <returns></returns>
		private static string GetLabelSettings(List<WindowCanvasLabel> LblList)
		{
			string lblStr = "//============Label============" + Environment.NewLine;
			for (int i = 0; i < LblList.Count; i++)
			{
				var lbl = LblList[i];
				string lblName = window.Canvas.Name + "_labs+" + i;
				if (lbl.Background == null)
				{
					lbl.Background = window.Canvas.Background;//背景色 默认Canvas(Screen)底色
				}
				string horz = GetAliginmentCode(0, lbl.HorizontalContentAlignment);//水平对齐
				string ver = GetAliginmentCode(1, lbl.VerticalContentAlignment);//垂直对齐
				string align = horz + "|" + ver;
				lblStr += string.Format(LabelInitCode,
					lblName,
					lbl.CanvasLeft,
					lbl.CanvasTop,
					lbl.Width,
					lbl.Height,
					GetRGB565Code(lbl.Background),
					GetRGB565Code(lbl.Foreground),
					lbl.Content,
					GetFontSizeCode(lbl.FontSize),
					align) + Environment.NewLine;
			}
			return lblStr;
		}
		/// <summary>
		/// TextBox
		/// </summary>
		/// <param name="TxtList"></param>
		/// <returns></returns>
		private static string GetTextBoxSettings(List<WindowCanvasTextBox> TxtList)
		{
			string txtStr = "//============Textbox============" + Environment.NewLine;
			for (int i = 0; i < TxtList.Count; i++)
			{
				var txt = TxtList[i];
				string txtName = window.Canvas.Name + "_tbxs+" + i;
				txtStr += string.Format(TextboxInitCode,
					txtName,
					txt.CanvasLeft,
					txt.CanvasTop,
					txt.Width,
					txt.Height,
					GetRGB565Code(txt.Foreground),
					GetFontSizeCode(txt.FontSize)
					) + Environment.NewLine;
 			}
			return txtStr;
		}
		/// <summary>
		/// CheckBox
		/// </summary>
		/// <param name="ChkList"></param>
		/// <returns></returns>
		private static string GetCheckBoxSettings(List<WindowCanvasCheckBox> ChkList)
		{
			string chkStr = "//============Checkbox============" + Environment.NewLine;
			for (int i = 0; i < ChkList.Count; i++)
			{
				var chk = ChkList[i];
				chkStr += string.Format(CheckboxInitCode, chk.CanvasLeft, chk.CanvasTop, chk.Content) + Environment.NewLine;
				if (chk.IsChecked != null)
				{
					switch (chk.IsChecked)
					{
						case "True":
							chkStr += string.Format(CheckboxSetCode, 1) + Environment.NewLine;
							break;
						case "False":
							chkStr += string.Format(CheckboxSetCode, 0) + Environment.NewLine;
							break;
						default:
							break;
					}
				}
			}
			return chkStr;
		}
		/// <summary>
		/// ListBox
		/// </summary>
		/// <param name="LbxList"></param>
		/// <returns></returns>
		private static string GetListBoxSettings(List<WindowCanvasComboBox> LbxList)
		{
			string lbxStr = "//============Listbox============" + Environment.NewLine;
			for (int i = 0; i < LbxList.Count; i++)
			{
				var lbx = LbxList[i];
				string lbxName = window.Canvas.Name + "_lbxs+" + i;
				string horz = GetAliginmentCode(0, lbx.HorizontalContentAlignment);//水平对齐
				string ver = GetAliginmentCode(1, lbx.VerticalContentAlignment);//垂直对齐
				string align = horz + "|" + ver;
				lbxStr += string.Format(ListboxInitCode,
					lbxName,
					lbx.CanvasLeft,
					lbx.CanvasTop,
					lbx.Width,
					lbx.Height,
					GetRGB565Code(lbx.Foreground),
					GetFontSizeCode(lbx.FontSize),
					align
					) + Environment.NewLine;
				var items = lbx.ComboBoxItem;
				string itemsName = window.Canvas.Name + "_lbx_select_" + lbx.Name + "_items";
				string itemsInit = "const char *{0} = {{ {1} }};";//items定义					
				string itemsStr = "";
				if (items != null && items?.Length > 0)
				{
					var itemsArr = new List<string>();
					foreach (var item in items)
					{
						itemsArr.Add("\"" + item.Content + "\"");
					}
					itemsStr = string.Join(",", itemsArr.ToArray());
				}
				lbxStr += string.Format(itemsInit, itemsName + "[]", itemsStr) + Environment.NewLine;
				lbxStr += string.Format(ListboxSetItemsCode, lbxName, itemsName, items.Length) + Environment.NewLine;
			}
			return lbxStr;
		}
		/// <summary>
		/// Line
		/// </summary>
		/// <param name="LineList"></param>
		/// <returns></returns>
		private static string GetDrawLineSettings(List<WindowCanvasLine> LineList)
		{
			string lineStr = "//============Line============" + Environment.NewLine;
			for (int i = 0; i < LineList.Count; i++)
			{
				var line = LineList[i];
				var x1 = line.CanvasLeft + line.X1;
				var y1 = line.CanvasTop + line.Y1;
				var x2 = line.CanvasLeft + line.X2;
				var y2 = line.CanvasTop + line.Y2;

				string color = GetRGB565Code(line.Stroke);

				lineStr += string.Format(Draw_Line_Code, x1, y1, x2, y2, color) + Environment.NewLine;
			}
			return lineStr;
		}
		private static string GetDrawRectSettings(List<WindowCanvasRectangle> RecList)
		{
			string recStr = "//============Rect============" + Environment.NewLine;
			var RecList_Normal = new List<WindowCanvasRectangle>();
			var RecList_Round = new List<WindowCanvasRectangle>();
			string recStr_Normal = "";
			string recStr_Round = "";
			string recItemStr_Normal = "";
			string recItemStr_Round = "";
			foreach (var item in RecList)
			{
				if (item.RadiusX == item.RadiusY && item.RadiusX != 0)
					RecList_Round.Add(item);
				else
					RecList_Normal.Add(item);
			}
			if (RecList_Round != null && RecList_Round?.Count > 0)
			{
				for (int i = 0; i < RecList_Round.Count; i++)
				{
					var rect = RecList_Round[i];
					string color = GetRGB565Code(rect.Fill);
					recItemStr_Round += string.Format(RectArrItem_Code_Round, rect.CanvasLeft, rect.CanvasTop, rect.Width, rect.Height, Convert.ToInt32(rect.RadiusX), color) + Environment.NewLine;
				}
				recStr_Round = string.Format(RectArr_Code_Round,
					RecList_Round.Count,
					recItemStr_Round) + Environment.NewLine;
				recStr_Round += "for(i=0;i<sizeof(dimensions_rect2)/sizeof(dimensions_rect2[0]);i++)" + Environment.NewLine;
				recStr_Round += "\t" + "GUI_FillRoundRect(dimensions_rect2[i][0],dimensions_rect2[i][1],dimensions_rect2[i][2],dimensions_rect2[i][3],dimensions_rect2[i][4],dimensions_rect2[i][5]);" + Environment.NewLine;
			}
			if (RecList_Normal != null && RecList_Normal?.Count > 0)
			{
				for (int i = 0; i < RecList_Normal.Count; i++)
				{
					var rect = RecList_Normal[i];
					string color = GetRGB565Code(rect.Fill);
					recItemStr_Normal += string.Format(RectArrItem_Code_Normal, rect.CanvasLeft, rect.CanvasTop, rect.Width, rect.Height, color) + Environment.NewLine;
				}
				recStr_Normal = string.Format(RectArr_Code_Normal,
					RecList_Normal.Count,
					recItemStr_Normal) + Environment.NewLine;
				recStr_Normal += "for(i=0;i<sizeof(dimensions_rect1)/sizeof(dimensions_rect1[0]);i++)" + Environment.NewLine;
				recStr_Normal += "\t" + "GUI_FillRect(dimensions_rect1[i][0],dimensions_rect1[i][1],dimensions_rect1[i][2],dimensions_rect1[i][3],dimensions_rect1[i][4]);" + Environment.NewLine;
			}
			recStr += recStr_Normal + recStr_Round;
			return recStr;
		}
		/// <summary>
		/// Rectangle
		/// </summary>
		/// <param name="RecList"></param>
		/// <returns></returns>
		private static string GetDrawRectSettings_(List<WindowCanvasRectangle> RecList)
		{
			string recStr = "//============Rect============" + Environment.NewLine;
			for (int i = 0; i < RecList.Count; i++)
			{
				var rect = RecList[i];

				string color = GetRGB565Code(rect.Fill);
				if (rect.RadiusX == rect.RadiusY && rect.RadiusX != 0)
				{
					recStr += string.Format(Draw_Rect_Code_Round, rect.CanvasLeft, rect.CanvasTop, rect.Width, rect.Height, Convert.ToInt32(rect.RadiusX), color) + Environment.NewLine;
				}
				else
					recStr += string.Format(Draw_Rect_Code_Normal, rect.CanvasLeft, rect.CanvasTop, rect.Width, rect.Height, color) + Environment.NewLine;
			}
			return recStr;
		}
		/// <summary>
		/// Tag(tag放置在矩形后绘制)
		/// </summary>
		/// <param name="TagList"></param>
		/// <returns></returns>
		private static string GetTagSettings(List<WindowCanvasLabel> TagList)
		{
			string tagStr = "//============Tag============" + Environment.NewLine;
			string tagStr_ = "";
			string tagStr_Text = "";
			string tagItemStr_ = "";
			string tagItemStr_Text = "";
			for (int i = 0; i < TagList.Count; i++)
			{
				var tag = TagList[i];
				if (tag.Background == null)
				{
					tag.Background = tag.Background;
				}
				string horz = GetAliginmentCode(0, tag.HorizontalContentAlignment);
				string ver = GetAliginmentCode(1, tag.VerticalContentAlignment);
				string align = horz + "|" + ver;

				tagItemStr_ += string.Format(TagArrItem_Code,
				tag.CanvasLeft,
				tag.CanvasTop,
				tag.Width,
				tag.Height,
				GetRGB565Code(tag.Background),
				GetRGB565Code(tag.Foreground),
				GetFontSizeCode(tag.FontSize),
				align) + Environment.NewLine;

				tagItemStr_Text += string.Format(TagArrItem_Text_Code, tag.Content) + Environment.NewLine;
			}
			tagStr_ += string.Format(TagArr_Code, TagList.Count, tagItemStr_) + Environment.NewLine;
			tagStr_Text += string.Format(TagArr_Text_Code, TagList.Count, tagItemStr_Text) + Environment.NewLine;

			tagStr += tagStr_ + tagStr_Text;
			tagStr += Draw_TagArr_Code;
			return tagStr;
		}

		/// <summary>
		/// Tag(tag放置在矩形后绘制)
		/// </summary>
		/// <param name="TagList"></param>
		/// <returns></returns>
		private static string GetTagSettings_(List<WindowCanvasLabel> TagList)
		{
			string tagStr = "//============Tag============" + Environment.NewLine;

			for (int i = 0; i < TagList.Count; i++)
			{
				var tag = TagList[i];
				if (tag.Background == null)
				{
					tag.Background = tag.Background;
				}
				string horz = GetAliginmentCode(0, tag.HorizontalContentAlignment);
				string ver = GetAliginmentCode(1, tag.VerticalContentAlignment);
				string align = horz + "|" + ver;
				tagStr += string.Format(Draw_Tag_Code,
				tag.CanvasLeft,
				tag.CanvasTop,
				tag.Width,
				tag.Height,
				GetRGB565Code(tag.Background),
				GetRGB565Code(tag.Foreground),
				tag.Content,
				GetFontSizeCode(tag.FontSize),
				align) + Environment.NewLine;

			}
			return tagStr;
		}
		/// <summary>
		/// 颜色
		/// </summary>
		/// <param name="cStr"></param>
		/// <returns></returns>
		private static string GetRGB565Code(string cStr)
		{
			try
			{
				if (string.IsNullOrEmpty(cStr))
					return string.Format(COLOR, "00", "00", "00");
				Color color = (Color)ColorConverter.ConvertFromString(cStr);
				string rValue = string.Format("0x{0:X2}", color.R);
				string gValue = string.Format("0x{0:X2}", color.G);
				string bValue = string.Format("0x{0:X2}", color.B);
				string output = string.Format(COLOR, rValue, gValue, bValue);
				return output;
			}
			catch (Exception ex)
			{

				return string.Format(COLOR, "00", "00", "00");
			}
		}
		/// <summary>
		/// 字体
		/// </summary>
		/// <param name="fontsize"></param>
		/// <returns></returns>
		private static string GetFontSizeCode(int fontsize)
		{
			try
			{
				string output = string.Format(FONT, Convert.ToString(fontsize));
				return output;
			}
			catch
			{
				return string.Format(FONT, "24");
			}
		}
		/// <summary>
		/// 对齐
		/// </summary>
		/// <param name="type"></param>
		/// <param name="align"></param>
		/// <returns></returns>
		private static string GetAliginmentCode(int type, string align)
		{
			string output = "";
			string horz = "HORIZONTAL_ALIGNMENT_";
			string ver = "VERTICAL_ALIGNMENT_";

			switch (align)
			{
				case "Center":
					align = "CENTER";
					break;
				case "Left":
					align = "LEFT";
					break;
				case "Right":
					align = "RIGHT";
					break;
				default:
					align = "CENTER";
					break;
			}
			if (type == (int)AlignType.Hrizontal)
				output = horz + align;
			else
				output = ver + align;
			return output;
		}	
		/// <summary>
		/// 传入类型A的对象a,类型B的对象b，将b和a相同名称的值进行赋值给a
		/// </summary>
		/// <typeparam name="A"></typeparam>
		/// <typeparam name="B"></typeparam>
		/// <param name="a"></param>
		/// <param name="b"></param>
		public static void Mapper<A, B>(B b, ref A a)
		{
			try
			{
				Type Typeb = b.GetType();//获得类型  
				Type Typea = typeof(A);
				foreach (PropertyInfo sp in Typeb.GetProperties())//获得类型的属性字段  
				{
					foreach (PropertyInfo ap in Typea.GetProperties())
					{
						if (ap.Name == sp.Name)//判断属性名是否相同  
						{
							ap.SetValue(a, sp.GetValue(b, null), null);//获得b对象属性的值复制给a对象的属性  
						}
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion
	}
}
