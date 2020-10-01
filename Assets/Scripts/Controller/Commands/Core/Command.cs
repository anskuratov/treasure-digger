namespace Controller.Commands.Core
{
	public abstract class Command<T>
		where T : struct
	{
		protected T _data;

		public Command(T data)
		{
			_data = data;
		}
	}
}