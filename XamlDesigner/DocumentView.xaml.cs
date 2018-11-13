using System;
using System.ComponentModel;
using System.Threading.Tasks;
using ICSharpCode.WpfDesign.Designer.Services;

namespace ICSharpCode.XamlDesigner
{
	public partial class DocumentView
	{
		public DocumentView()
		{
			InitializeComponent();
			this.Loaded += DocumentView_Loaded;
		}

		private void DocumentView_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			this.Loaded -= DocumentView_Loaded;

			Document = (Document) this.DataContext;
			Shell.Instance.Views[Document] = this;

			Document.Mode = DocumentMode.Design;
			Document.PropertyChanged += Document_PropertyChanged;
			uxTextEditor.TextChanged += uxTextEditor_TextChanged;
		}

		void uxTextEditor_TextChanged(object sender, EventArgs e)
		{
			Document.Text = uxTextEditor.Text;
		}

		async void Document_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Text" && Document.Text != uxTextEditor.Text)
				uxTextEditor.Text = Document.Text;
			if (e.PropertyName == "XamlElementLineInfo")
			{
				try
				{
					await Task.Delay(70);
					if (Document.XamlElementLineInfo != null) {
						uxTextEditor.SelectionLength = 0;
						uxTextEditor.SelectionStart = Document.XamlElementLineInfo.Position;
						uxTextEditor.SelectionLength = Document.XamlElementLineInfo.Length;
					}
					else
					{
						uxTextEditor.SelectionStart = 0;
						uxTextEditor.SelectionLength = 0;
					}

					uxTextEditor.Focus();
				}
				catch(Exception)
				{ }
			}
				
		}

		public Document Document { get; private set; }

		public void JumpToError(XamlError error)
		{
			Document.Mode = DocumentMode.Xaml;
			try {
				uxTextEditor.ScrollTo(error.Line, error.Column);
				uxTextEditor.CaretOffset = uxTextEditor.Document.GetOffset(error.Line, error.Column);
				
				int n = 0;
				char chr;
				while ((chr = uxTextEditor.Document.GetCharAt(uxTextEditor.CaretOffset + n)) != ' ' && chr != '.' && chr != '<' && chr != '>' && chr != '"')
				{ n++; }

				uxTextEditor.SelectionLength = n;
			}
			catch (ArgumentException) {
				// invalid line number
			}
		}
	}
}
