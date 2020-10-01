namespace Controller.Commands.Core
{
	public struct PrintHello
	{
	}

	public struct Summarize
	{
	}

	public struct PrintText
	{
		public readonly string Text;

		public PrintText(string text)
		{
			Text = text;
		}
	}
}