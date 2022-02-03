namespace ICSharpCode.WpfDesign.Services
{
	public interface ICopyPasteService
	{
		bool CanCopy(DesignContext designContext);

		void Copy(DesignContext designContext);

		bool CanPaste(DesignContext designContext);

		void Paste(DesignContext designContext);

		bool CanCut(DesignContext designContext);

		void Cut(DesignContext designContext);

		bool CanDelete(DesignContext designContext);

		void Delete(DesignContext designContext);
	}
}
