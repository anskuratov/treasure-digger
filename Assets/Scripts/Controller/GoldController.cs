using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class GoldController : IStorable
	{
		private readonly GoldModel _gold;

		public IListenable Listenable => _gold;

		public GoldController(GoldModel gold)
		{
			_gold = gold;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(_gold.StoreKey, _gold.Amount);
		}

		public void Load()
		{
			_gold.Amount = PlayerPrefs.GetInt(_gold.StoreKey);
		}
	}
}