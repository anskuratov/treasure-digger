namespace Model.Messages
{
	public interface IMessageListener<in T>
		where T : struct
	{
		void OnMessage(T message);
	}
}