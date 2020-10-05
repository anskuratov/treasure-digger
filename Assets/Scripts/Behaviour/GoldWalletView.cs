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
		private Text _amount;

		[SerializeField]
		private Text _goalAmount;

		private GoldWalletController _controller;

		protected override void Refresh()
		{
			_amount.text = _controller.GoldAmount.ToString();
		}

		public override void Initialize(Data data)
		{
			_controller = data.GoldWalletController;
			SubscribeToModel();

			_goalAmount.text = _controller.GoldGoalAmount.ToString();
			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener(this);
		}

		public void OnMessage(GoldChanged message)
		{
			Refresh();
		}
	}
}