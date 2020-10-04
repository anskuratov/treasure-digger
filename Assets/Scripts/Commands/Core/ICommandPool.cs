namespace Commands.Core
{
	public interface ICommandPool
	{
		void Register<TData>(ICommand command)
			where TData : struct;

		ICommand GetCommand<TData>()
			where TData : struct;
	}
}