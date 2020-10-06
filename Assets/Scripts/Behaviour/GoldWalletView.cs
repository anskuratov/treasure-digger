using Commands;
using Commands.Core;
using Controller;
using Model;
using Model.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour
{
	public class GoldWalletView : ViewBehaviour<GoldWalletView.Data>,
		IMessageListener<GoldWalletChanged>
	{
		public readonly struct Data
		{
			public readonly IPerformer Performer;
			public readonly GoldWalletController GoldWalletController;

			public Data(IPerformer performer, GoldWalletController goldWalletController)
			{
				Performer = performer;
				GoldWalletController = goldWalletController;
			}
		}

		[SerializeField]
		private Text _amount;

		[SerializeField]
		private Text _goalAmount;

		private IPerformer _performer;
		private GoldWalletController _controller;

		protected override void Refresh()
		{
			base.Refresh();
			_amount.text = _controller.GoldAmount.ToString();

			if (_controller.GoldAmount >= _controller.GoldGoalAmount)
			{
				_performer.Invoke(new EndGame());
			}
		}

		public override void Initialize(Data data)
		{
			_performer = data.Performer;
			_controller = data.GoldWalletController;
			SubscribeToModel();

			_goalAmount.text = _controller.GoldGoalAmount.ToString();
			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener(this);
		}

		public void OnMessage(GoldWalletChanged message)
		{
			Refresh();
		}
	}
}