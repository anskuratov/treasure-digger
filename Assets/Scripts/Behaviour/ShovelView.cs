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

		private ShovelController _controller;

		protected override void Refresh()
		{
			_amount.text = _controller.ShovelAmount.ToString();
		}

		public override void Initialize(Data data)
		{
			_controller = data.ShovelController;
			SubscribeToModel();

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