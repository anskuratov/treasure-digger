namespace Model
{
	public class StorageController
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
}