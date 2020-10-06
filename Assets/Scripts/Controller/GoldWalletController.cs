using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class GoldWalletController : IStorable
	{
		private const string StoreKey = "GoldWallet";

		private readonly GoldWalletModel _model;

		public IListenable Listenable => _model;

		public GoldWalletController(GoldWalletModel model)
		{
			_model = model;
		}

		public int GoldAmount => _model.Amount;
		public int GoldGoalAmount => _model.GoalAmount;

		public void CollectGold()
		{
			_model.Amount += 1;
		}

		public void Reset()
		{
			_model.Amount = 0;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _model.Amount);
		}

		public void Load()
		{
			if (PlayerPrefs.HasKey(StoreKey))
			{
				_model.Amount = PlayerPrefs.GetInt(StoreKey);
			}
		}
	}
}