using UnityEngine;

namespace Model
{
	public class ShovelModel : IStorable
	{
		private int _amount;

		private string StoreKey => "Shovel";

		public ShovelModel(int amount)
		{
			_amount = amount;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _amount);
		}

		public void Load()
		{
			_amount = PlayerPrefs.GetInt(StoreKey);
		}
	}
}