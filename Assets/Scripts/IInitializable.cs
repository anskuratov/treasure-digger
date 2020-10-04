public interface IInitializable<in T>
	where T : struct
{
	void Initialize(T data);
}