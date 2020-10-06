using Commands;
using Commands.Core;
using Controller;
using Model;
using Model.Messages;
using UnityEngine;

namespace Behaviour
{
	public class CellView : ViewBehaviour<CellView.Data>,
		IMessageListener<CellChanged>
	{
		public readonly struct Data
		{
			public readonly IPerformer Performer;
			public readonly CellController CellController;

			public Data(IPerformer performer, CellController cellController)
			{
				Performer = performer;
				CellController = cellController;
			}
		}

		[SerializeField]
		private SpriteRenderer _cellSprite;

		private IPerformer _performer;
		private ShovelController _shovelController;
		private CellController _controller;

		protected override void Refresh()
		{
			_cellSprite.color = Color.white - (Color.white / _controller.CellDepth) * (_controller.CellLevel);
		}

		public override void Initialize(Data data)
		{
			_performer = data.Performer;

			_controller = data.CellController;
			SubscribeToModel();

			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener(this);
		}

		public void OnMessage(CellChanged message)
		{
			Refresh();
		}

		private void OnMouseUp()
		{
			_performer.Invoke(new Dig(_controller));
		}
	}
}