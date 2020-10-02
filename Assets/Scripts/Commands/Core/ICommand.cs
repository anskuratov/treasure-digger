namespace Commands.Core
{
	public interface ICommand
	{
		void Execute();
		void PostExecute();
	}
}