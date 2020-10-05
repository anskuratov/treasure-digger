namespace Commands.Core
{
	public abstract class Command<T> : ICommand
		where T : struct
	{
		protected T _data;

		public void Initialize(T data)
		{
			_data = data;
		}

		public abstract bool Check();
		public abstract void Execute();
		public abstract void PostExecute();
	}
}