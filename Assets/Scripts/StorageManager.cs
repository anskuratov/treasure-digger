using Controller;

public class StorageManager
{
	public void Save(IStorable storable)
	{
		storable.Save();
	}

	public void Load(IStorable storable)
	{
		storable.Load();
	}
}