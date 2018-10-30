using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using ICSharpCode.WpfDesign.Designer.PropertyGrid;
using ICSharpCode.XamlDesigner.Configuration;
using System.Collections.Specialized;
using System.IO;
using System.Windows;
using System.Diagnostics;
using ICSharpCode.WpfDesign.Designer.Services;
using GuiGenerator;
using System.Windows.Media;

namespace ICSharpCode.XamlDesigner
{
	public class Shell : INotifyPropertyChanged
	{
		public Shell()
		{
			Documents = new ObservableCollection<Document>();
			RecentFiles = new ObservableCollection<string>();
			Views = new Dictionary<object, FrameworkElement>();

			LoadSettings();
		}

		public static Shell Instance = new Shell();
		public const string ApplicationTitle = "Xaml Designer";

		//public Toolbox Toolbox { get; set; }
		//public SceneTree SceneTree { get; set; }
		public IPropertyGrid PropertyGrid { get; internal set; }
		//public ErrorList ErrorList { get; set; }

		public ObservableCollection<Document> Documents { get; private set; }
		public ObservableCollection<string> RecentFiles { get; private set; }
		public Dictionary<object, FrameworkElement> Views { get; private set; }

		Document currentDocument;

		public Document CurrentDocument
		{
			get
			{
				return currentDocument;
			}
			set
			{
				currentDocument = value;
				RaisePropertyChanged("CurrentDocument");
				RaisePropertyChanged("Title");
			}
		}

		public string Title
		{
			get
			{
				if (CurrentDocument != null)
				{
					return CurrentDocument.Title + " - " + ApplicationTitle;
				}
				return ApplicationTitle;
			}
		}

		void LoadSettings()
		{
			if (Settings.Default.RecentFiles != null)
			{
				RecentFiles.AddRange(Settings.Default.RecentFiles.Cast<string>());
			}
		}

		public void SaveSettings()
		{
			if (Settings.Default.RecentFiles == null)
			{
				Settings.Default.RecentFiles = new StringCollection();
			}
			else
			{
				Settings.Default.RecentFiles.Clear();
			}
			foreach (var f in RecentFiles)
			{
				Settings.Default.RecentFiles.Add(f);
			}
		}

		public static void ReportException(Exception x)
		{
			MessageBox.Show(x.ToString());
		}

		public void JumpToError(XamlError error)
		{
			if (CurrentDocument != null)
			{
				(Views[CurrentDocument] as DocumentView).JumpToError(error);
			}
		}

		public bool CanRefresh()
		{
			return CurrentDocument != null;
		}

		public void Refresh()
		{
			CurrentDocument.Refresh();
		}

		#region Files
		public static XmlDeserialize deserialize;
		bool IsSomethingDirty
		{
			get
			{
				foreach (var doc in Shell.Instance.Documents)
				{
					if (doc.IsDirty) return true;
				}
				return false;
			}
		}

		static int nonameIndex = 1;

		public void New()
		{
			Document doc = new Document("New" + nonameIndex++, File.ReadAllText("NewFileTemplate.xaml"));
			Documents.Add(doc);
			CurrentDocument = doc;
		}

		public void Open()
		{
			var path = MainWindow.Instance.AskOpenFileName();
			if (path != null)
			{
				Open(path);
			}
		}

		public void Open(string path)
		{
			path = Path.GetFullPath(path);

			if (RecentFiles.Contains(path))
			{
				RecentFiles.Remove(path);
			}
			RecentFiles.Insert(0, path);

			foreach (var doc in Documents)
			{
				if (doc.FilePath == path)
				{
					CurrentDocument = doc;
					return;
				}
			}

			var newDoc = new Document(path);
			Documents.Add(newDoc);
			CurrentDocument = newDoc;
		}

		public bool Save(Document doc)
		{
			if (doc.IsDirty)
			{
				if (doc.FilePath == null)
				{
					return SaveAs(doc);
				}
				doc.Save();
			}
			return true;
		}

		public bool SaveAs(Document doc)
		{
			var initName = doc.FileName ?? doc.Name + ".xaml";
			var path = MainWindow.Instance.AskSaveFileName(initName);
			if (path != null)
			{
				doc.SaveAs(path);


				return true;
			}
			return false;
		}
		public void Generator()
		{
			var path = MainWindow.Instance.AskOpenFileName();
			if (path != null)
			{
				Open(path);
			}
			var cfgName = CurrentDocument.FileName ?? CurrentDocument.Name;
			GuiGenerator.Window xmlentity = (GuiGenerator.Window)XmlDeserialize.DeserializeFile<GuiGenerator.Window>(path);
			if (xmlentity != null)
			{
				Canvas entity = xmlentity.canvas;
				string settingStr = "";
				if (entity != null)
				{
					settingStr = GetScreenSettingCode(entity);
					#region SaveConfig
					string filePath = Path.GetDirectoryName(path) + "\\";
					filePath += Path.GetFileNameWithoutExtension(path) + ".c";
					StringBuilder sb = new StringBuilder();
					sb.Append(settingStr);
					FileStream _file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
					using (StreamWriter sw = new StreamWriter(_file))
					{
						sw.Write(sb.ToString());
						sw.Close();
						sw.Dispose();
					}
					#endregion
				}
			}
		}
		public bool SaveAll()
		{
			foreach (var doc in Documents)
			{
				if (!Save(doc)) return false;
			}
			return true;
		}

		public bool Close(Document doc)
		{
			if (doc.IsDirty)
			{
				var result = MessageBox.Show("Save \"" + doc.Name + "\" ?", Shell.ApplicationTitle,
					MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					if (!Save(doc)) return false;
				}
				else if (result == MessageBoxResult.Cancel)
				{
					return false;
				}
			}
			Documents.Remove(doc);
			Views.Remove(doc);
			return true;
		}

		public bool CloseAll()
		{
			foreach (var doc in Documents.ToArray())
			{
				if (!Close(doc)) return false;
			}
			return true;
		}

		public bool PrepareExit()
		{
			if (IsSomethingDirty)
			{
				var result = MessageBox.Show("Save All?", Shell.ApplicationTitle,
					MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

				if (result == MessageBoxResult.Yes)
				{
					if (!SaveAll()) return false;
				}
				else if (result == MessageBoxResult.Cancel)
				{
					return false;
				}
			}
			return true;
		}

		public void Exit()
		{
			MainWindow.Instance.Close();
		}

		public void SaveCurrentDocument()
		{
			Save(CurrentDocument);
		}

		public void SaveCurrentDocumentAs()
		{
			SaveAs(CurrentDocument);
		}

		public void CloseCurrentDocument()
		{
			Close(CurrentDocument);
		}

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

		#endregion

		#region Extend
		private static string FONT = "FONT{0}_SONGTI";
		private static string COLOR = "RGB888toRGB565({0}, {1}, {2})";

		private static string IconInitCode = "GUI_IconInit(&sc_menu_icons[{0}],{1},{2},{3},{4},&{5},NULL);";
		private static string LabelInitCode = "GUI_LabelInit({0},{1},{2},{3},{4},{5},{6},\"{7}\",{8},{9});";
		private static string ButtonInitCode = "GUI_ButtonInit(struct button *button,{0},{1},{2},{3},GREEN,BLACK);";
		private static string ButtonSetTextCode = "GUI_ButtonSetText(struct button *button,\"{0}\"," + FONT + ");";
		private static string TextboxInitCode = "GUI_TextboxInit(struct textbox *txtb,{0},{1},BLACK," + FONT + ",{2});";
		private static string TextboxSetTextCode = "GUI_TextboxSetText(struct textbox *txtb,\"{0}\");";
		private static string CheckboxInitCode = "GUI_CheckboxInit(struct checkbox *ckb,{0},{1},BLACK,\"{2}\"," + FONT + ");";
		private static string CheckboxSetCode = "GUI_CheckboxSet(struct checkbox *ckb,{0});";
		private static string ListboxInitCode = "GUI_ListboxInit(struct listbox *lbx,{0},{1},{2},BLACK," + FONT + ");";
		private static string ListboxSetItemsCode = "GUI_ListboxSetItems(struct listbox *lbx,const char **items,int count);";

		private static string Draw_Tag_Code = "GUI_DrawTag({0},{1},{2},{3},{4},{5},\"{6}\",{7},{8});";
		private static string Draw_Line_Code = "GUI_DrawLine({0},{1},{2},{3},{4});";
		private static string Draw_Rect_Code_Normal = "GUI_DrawRect({0},{1},{2},{3},{4});";
		private static string Draw_Rect_Code_Round = "GUI_FillRoundRect({0},{1},{2}, {3},{4},{5});";
		private enum AlignType
		{
			Hrizontal = 0,
			Vertical
		}

		private string GetRGB565Code(string cStr)
		{
			Color color = (Color)ColorConverter.ConvertFromString(cStr);
			try
			{
				string rValue = string.Format("0x{0:X2}", color.R);
				string gValue = string.Format("0x{0:X2}", color.G);
				string bValue = string.Format("0x{0:X2}", color.B);
				string output = string.Format(COLOR, rValue, gValue, bValue);
				return output;
			}
			catch
			{
				return string.Format(COLOR, "00", "00", "00");
			}
		}
		private string GetRGB565Code_(string color)
		{
			try
			{
				string output = string.Format(COLOR, "0x" + color.Substring(3, 2), "0x" + color.Substring(5, 2), "0x" + color.Substring(7, 2));
				return output;
			}
			catch
			{
				return string.Format(COLOR, "00", "00", "00");
			}
		}
		private string GetFontSizeCode(int fontsize)
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
		private string GetAliginmentCode(int type, string align)
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
					align = "LEFT";
					break;
			}
			if (type == (int)AlignType.Hrizontal)
				output = horz + align;
			else
				output = ver + align;
			return output;
		}

		private string GetScreenSettingCode(Canvas entity)
		{
			try
			{
				string output = "";
				List<Label> List_Label = new List<Label>();
				List<Label> List_Tag = new List<Label>();

				#region Controls

				#region Icon
				string iconStr = "//============Icon============" + Environment.NewLine;
				if (entity.IconList != null)
				{
					for (int i = 0; i < entity.IconList.Count; i++)
					{
						Icon icon = entity.IconList[i];
						if (!string.IsNullOrEmpty(icon.ImgSrc))
						{
							string[] rcvArr = icon.ImgSrc.Split(new string[] { "=" }, StringSplitOptions.None);
							rcvArr = rcvArr.Where(s => !string.IsNullOrEmpty(s)).ToArray();
							string str = rcvArr[1];
							string[] strArr = str.Split(new string[] { "}" }, StringSplitOptions.None);
							strArr = strArr.Where(s => !string.IsNullOrEmpty(s)).ToArray();
							icon.ImgSrc = strArr[0];
						}
						iconStr += string.Format(IconInitCode, i, icon.X, icon.Y, icon.Width, icon.Height, icon.ImgSrc) + Environment.NewLine;
					}
				}
				output += iconStr;
				#endregion

				#region Label

				string lblStr = "//============Label============" + Environment.NewLine;
				if (entity.LblList != null)
				{
					foreach (var item in entity.LblList)
					{
						switch (item.IsEnabled)
						{
							case "False":
								List_Tag.Add(item);
								break;
							case "True":
								List_Label.Add(item);
								break;
							default:
								break;
						}
					}
					if (List_Label != null)
					{
						lblStr += "struct label sc_work_labs[" + List_Label.Count + "];" + Environment.NewLine;
						for (int i = 0; i < List_Label.Count; i++)
						{
							Label lbl = List_Label[i];
							if (lbl.Background == null)
							{
								lbl.Background = entity.Background;
							}
							string backcolor = GetRGB565Code(lbl.Background);
							string forecolor = GetRGB565Code(lbl.Foreground);
							string font = GetFontSizeCode(lbl.FontSize);
							string horz = GetAliginmentCode(0, lbl.HorizontalContentAlignment);
							string ver = GetAliginmentCode(1, lbl.VerticalContentAlignment);
							string align = horz + "|" + ver;
							lblStr += string.Format(LabelInitCode, "sc_work_labs+" + i, lbl.X, lbl.Y, lbl.Width, lbl.Height, backcolor, forecolor, lbl.Text, font, align) + Environment.NewLine;
						}
					}
				}
				output += lblStr;
				#endregion

				#region Button
				string btnStr = "//============Button============" + Environment.NewLine;
				if (entity.BtnList != null)
				{
					for (int i = 0; i < entity.BtnList.Count; i++)
					{
						Button btn = entity.BtnList[i];
						btnStr += string.Format(ButtonInitCode, btn.X, btn.Y, btn.Width, btn.Height) + Environment.NewLine;
						btnStr += string.Format(ButtonSetTextCode, btn.Text) + Environment.NewLine;
					}
				}
				output += btnStr;
				#endregion

				#region CheckBox
				string chkStr = "//============Checkbox============" + Environment.NewLine;
				if (entity.ChkList != null)
				{
					for (int i = 0; i < entity.ChkList.Count; i++)
					{
						Checkbox chk = entity.ChkList[i];
						chkStr += string.Format(CheckboxInitCode, chk.X, chk.Y, chk.Text) + Environment.NewLine;
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
				}
				output += iconStr;
				#endregion

				#region Textbox
				string txtStr = "//============Textbox============" + Environment.NewLine;
				if (entity.TxtList != null)
				{
					for (int i = 0; i < entity.TxtList.Count; i++)
					{
						Textbox txt = entity.TxtList[i];
						txtStr += string.Format(TextboxInitCode, txt.X, txt.Y, txt.MaxLength) + Environment.NewLine;
						txtStr += string.Format(TextboxSetTextCode, txt.Text) + Environment.NewLine;
					}
				}
				output += txtStr;
				#endregion

				#region Listbox
				string lbxStr = "//============Listbox============" + Environment.NewLine;
				if (entity.LbxList != null)
				{
					for (int i = 0; i < entity.LbxList.Count; i++)
					{
						Listbox lbx = entity.LbxList[i];
						lbxStr += string.Format(ListboxInitCode, lbx.X, lbx.Y, lbx.Width) + Environment.NewLine;

					}
				}
				output += lbxStr;
				#endregion

				#endregion

				#region Draw
				#region Tag
				string tagStr = "//============Tag============" + Environment.NewLine;
				if (List_Tag != null)
				{
					for (int i = 0; i < List_Tag.Count; i++)
					{
						Label lbl = List_Tag[i];
						if (lbl.Background == null)
						{
							lbl.Background = entity.Background;
						}
						string backcolor = GetRGB565Code(lbl.Background);
						string forecolor = GetRGB565Code(lbl.Foreground);
						string font = GetFontSizeCode(lbl.FontSize);
						string horz = GetAliginmentCode(0, lbl.HorizontalContentAlignment);
						string ver = GetAliginmentCode(1, lbl.VerticalContentAlignment);
						string align = horz + "|" + ver;
						tagStr += string.Format(Draw_Tag_Code, lbl.X, lbl.Y, lbl.Width, lbl.Height, backcolor, forecolor, lbl.Text, font, align) + Environment.NewLine;
					}
				}
				output += tagStr;
				#endregion

				#region Line
				string lineStr = "//============Line============" + Environment.NewLine;
				if (entity.LineList != null)
				{
					for (int i = 0; i < entity.LineList.Count; i++)
					{
						Line line = entity.LineList[i];
						int x1 = Convert.ToInt32(line.X) + Convert.ToInt32(line.X1);
						int y1 = Convert.ToInt32(line.Y) + Convert.ToInt32(line.Y1);
						int x2 = Convert.ToInt32(line.X) + Convert.ToInt32(line.X2);
						int y2 = Convert.ToInt32(line.Y) + Convert.ToInt32(line.Y2);
						string color = GetRGB565Code(line.Stroke);

						lineStr += string.Format(Draw_Line_Code, x1, y1, x2, y2, color) + Environment.NewLine;
					}
				}
				output += lineStr;
				#endregion

				#region Rect
				string recStr = "//============Rect============" + Environment.NewLine;
				if (entity.RecList != null)
				{
					for (int i = 0; i < entity.RecList.Count; i++)
					{
						Rectangle rect = entity.RecList[i];
						if (!string.IsNullOrEmpty(rect.RadiusX) && !string.IsNullOrEmpty(rect.RadiusY))
						{
							string color = GetRGB565Code(rect.Fill);
							if ((Convert.ToInt32(rect.RadiusX) == Convert.ToInt32(rect.RadiusY)) && Convert.ToInt32(rect.RadiusY) != 0)
							{
								recStr += string.Format(Draw_Rect_Code_Round, rect.X, rect.Y, rect.Width, rect.Height, Convert.ToInt32(rect.RadiusX), color) + Environment.NewLine;
							}
							else
								recStr += string.Format(Draw_Rect_Code_Normal, rect.X, rect.Y, rect.Width, rect.Height, color);
						}
					}
				}
				output += recStr;
				#endregion

				#endregion


				return output;
			}
			catch (Exception e)
			{
				string output = e.Message;
				return output;
			}
		}
		#endregion
	}
}
