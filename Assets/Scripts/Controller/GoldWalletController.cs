using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class GoldWalletController : IStorable
	{
		private const string StoreKey = "GoldWallet";

		private readonly GoldWalletModel _goldWallet;

		public IListenable Listenable => _goldWallet;

		public GoldWalletController(GoldWalletModel goldWallet)
		{
			_goldWallet = goldWallet;
		}

		public int GoldAmount => _goldWallet.Amount;
		public int GoldGoalAmount => _goldWallet.GoalAmount;

		public void CollectGold()
		{
			_goldWallet.Amount += 1;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _goldWallet.Amount);
		}

		public void Load()
		{
			_goldWallet.Amount = PlayerPrefs.GetInt(StoreKey);
		}
	}
}