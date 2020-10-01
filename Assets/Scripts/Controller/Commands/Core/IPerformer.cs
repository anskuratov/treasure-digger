namespace Controller.Commands.Core
{
	public interface IPerformer
	{
		void Invoke<T>(T commandData)
			where T : struct;
	}
}