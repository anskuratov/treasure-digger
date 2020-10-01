using UnityEngine;

namespace Model
{
	public class GoldModel : IStorable
	{
		private readonly int _goalAmount;
		
		private int _actualAmount;

		private string StoreKey => "Gold"; 

		public GoldModel(int goalAmount)
		{
			_goalAmount = goalAmount;
			_actualAmount = 0;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _actualAmount);
		}

		public void Load()
		{
			_actualAmount = PlayerPrefs.GetInt(StoreKey);
		}
	}
}