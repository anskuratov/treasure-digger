using Controller;
using Model;
using Model.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour
{
	public class ShovelView : ViewBehaviour<ShovelView.Data>,
		IMessageListener<ShovelChanged>
	{
		public readonly struct Data
		{
			public readonly ShovelController ShovelController;

			public Data(ShovelController shovelController)
			{
				ShovelController = shovelController;
			}
		}

		[SerializeField]
		private Text _amount;

		[SerializeField]
		private Text _initialAmount;

		private ShovelController _controller;

		protected override void Refresh()
		{
			_amount.text = _controller.ShovelAmount.ToString();
		}

		public override void Initialize(Data data)
		{
			_controller = data.ShovelController;
			SubscribeToModel();

			_initialAmount.text = _controller.ShovelAmount.ToString();
			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener(this);
		}

		public void OnMessage(ShovelChanged message)
		{
			Refresh();
		}
	}
}