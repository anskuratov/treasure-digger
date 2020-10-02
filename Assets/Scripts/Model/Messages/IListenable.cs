namespace Model.Messages
{
	public interface IListenable
	{
		void AddListener<T>(IMessageListener<T> listener) where T : struct;
	}
}