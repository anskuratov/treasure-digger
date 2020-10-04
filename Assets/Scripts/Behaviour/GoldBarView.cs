using Controller;
using Model;
using Model.Messages;

namespace Behaviour
{
	public class GoldBarView : ViewBehaviour<GoldBarView.Data>,
		IMessageListener<GoldBarCollected>
	{
		public readonly struct Data
		{
			public readonly GoldBarController GoldBarController;

			public Data(GoldBarController goldBarController)
			{
				GoldBarController = goldBarController;
			}
		}

		private GoldBarController _controller;

		protected override void Refresh()
		{
		}

		public override void Initialize(Data data)
		{
			_controller = data.GoldBarController;
			SubscribeToModel();

			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener(this);
		}

		public void OnMessage(GoldBarCollected message)
		{
			_controller.Collect();
		}
	}
}