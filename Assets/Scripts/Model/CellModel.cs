using UnityEngine;

namespace Model
{
	public class CellModel : IStorable
	{
		private readonly int _depth;
		private readonly (int, int) _address;

		private int _level;

		private string StoreKey => $"Cell{_address.Item1}:{_address.Item2}";

		public CellModel(int depth, (int, int) address)
		{
			_depth = depth;
			_address = address;
			_level = 0;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _level);
		}

		public void Load()
		{
			_level = PlayerPrefs.GetInt(StoreKey);
		}
	}
}