using Controller;
using Model;
using Model.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour
{
	public class GoldWalletView : ViewBehaviour<GoldWalletView.Data>,
		IMessageListener<GoldChanged>
	{
		public readonly struct Data
		{
			public readonly GoldWalletController GoldWalletController;

			public Data(GoldWalletController goldWalletController)
			{
				GoldWalletController = goldWalletController;
			}
		}

		[SerializeField]
		private Text _count;

		[SerializeField]
		private Text _goalCount;

		private GoldWalletController _walletController;

		protected override void Refresh()
		{
			_count.text = _walletController.GoldAmount.ToString();
		}

		public override void Initialize(Data data)
		{
			_walletController = data.GoldWalletController;
			SubscribeToModel();

			_goalCount.text = _walletController.GoldGoalAmount.ToString();
			Refresh();
		}

		private void SubscribeToModel()
		{
			_walletController.Listenable.AddListener(this);
		}

		public void OnMessage(GoldChanged message)
		{
			Refresh();
		}
	}
}