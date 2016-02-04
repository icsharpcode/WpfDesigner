namespace ICSharpCode.WpfDesign.XamlDom
{
	public class XamlElementLineInfo
	{
		public XamlElementLineInfo(int lineNumber, int linePosition)
		{
			this.LineNumber = lineNumber;
			this.LinePosition = linePosition;
		}

		public int LineNumber { get; set; }
		public int LinePosition { get; set; }

		public int Position { get; set; }
		public int Length { get; set; }
	}
}
