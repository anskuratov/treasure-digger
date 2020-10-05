namespace Commands.Core
{
	public interface ICommand
	{
		bool Check();
		void Execute();
		void PostExecute();
	}
}