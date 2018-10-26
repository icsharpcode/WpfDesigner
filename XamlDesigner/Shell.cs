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
					#endregion

					#region Label
					string lblStr = "//============Label============" + Environment.NewLine;
					if (entity.LblList != null)
					{
						lblStr += "struct label sc_work_labs[" + entity.LblList.Count + "];" + Environment.NewLine;
						for (int i = 0; i < entity.LblList.Count; i++)
						{
							Label lbl = entity.LblList[i];
							lblStr += string.Format(LabelInitCode, "sc_work_labs+" + i, lbl.X, lbl.Y, lbl.Text) + Environment.NewLine;
						}
					}
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
					#endregion

					settingStr = iconStr + lblStr + btnStr + lbxStr + txtStr + chkStr;

					#region SaveConfig
					if (!string.IsNullOrEmpty(settingStr))
					{
						string filePath = Path.GetDirectoryName(path) + "\\";
						filePath += Path.GetFileNameWithoutExtension(path) + ".txt";
						StringBuilder sb = new StringBuilder();
						sb.Append(settingStr);
						FileStream _file = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
						using (StreamWriter sw = new StreamWriter(_file))
						{
							sw.Write(sb.ToString());
							sw.Close();
							sw.Dispose();
						}
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
		private static string FONT = "FONT32_SONGTI";
		private static string IconInitCode = "GUI_IconInit(&sc_menu_icons[{0}],{1},{2},{3},{4},&{5},NULL);";
		private static string LabelInitCode = "GUI_LabelInit({0},{1},{2},BLACK,\"{3}\","+FONT+");";
		private static string ButtonInitCode = "GUI_ButtonInit(struct button *button,{0},{1},{2},{3},GREEN,BLACK);";
		private static string ButtonSetTextCode = "GUI_ButtonSetText(struct button *button,\"{0}\","+FONT+");";
		private static string TextboxInitCode = "GUI_TextboxInit(struct textbox *txtb,{0},{1},BLACK,"+FONT+",{2});";
		private static string TextboxSetTextCode = "GUI_TextboxSetText(struct textbox *txtb,\"{0}\");";
		private static string CheckboxInitCode = "GUI_CheckboxInit(struct checkbox *ckb,{0},{1},BLACK,\"{2}\","+FONT+");";
		private static string CheckboxSetCode = "GUI_CheckboxSet(struct checkbox *ckb,{0});";
		private static string ListboxInitCode = "GUI_ListboxInit(struct listbox *lbx,{0},{1},{2},BLACK,"+FONT+");";
		private static string ListboxSetItemsCode = "GUI_ListboxSetItems(struct listbox *lbx,const char **items,int count);";
		#endregion
	}
}
