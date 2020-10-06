using System.Collections.Generic;
using System.Linq;
using Controller;
using DefaultNamespace;
using Model;
using Model.Messages;
using UnityEngine;

namespace Behaviour
{
	public class GoldBarsSpawnerView : ViewBehaviour<GoldBarsSpawnerView.Data>,
		IMessageListener<GoldBarFound>,
		IMessageListener<GoldBarCollected>
	{
		public readonly struct Data
		{
			public readonly GoldBarsSpawnerController GoldBarsSpawnerController;
			public readonly int FieldSize;
			public readonly Vector2 ElementSize;

			public Data(GoldBarsSpawnerController goldBarsSpawnerController,
			int fieldSize,
			Vector2 elementSize)
			{
				GoldBarsSpawnerController = goldBarsSpawnerController;
				FieldSize = fieldSize;
				ElementSize = elementSize;
			}
		}

		private GoldBarsSpawnerController _controller;
		private FieldGrid _fieldGrid;

		private readonly List<GoldBarView> _goldBarsPool = new List<GoldBarView>();
		private readonly Dictionary<GoldBarModel, GoldBarView> _goldBars = new Dictionary<GoldBarModel, GoldBarView>();

		protected override void Refresh()
		{
		}

		public override void Initialize(Data data)
		{
			_controller = data.GoldBarsSpawnerController;
			SubscribeToModel();
			_fieldGrid = new FieldGrid(data.FieldSize, data.ElementSize);

			SpawnGoldBars();

			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener<GoldBarFound>(this);
		}

		private void SpawnGoldBars()
		{
			foreach (GoldBarModel goldBar in _controller.GoldBars)
			{
				CreateGoldBarView(goldBar);
			}
		}

		private void CreateGoldBarView(GoldBarModel goldBarModel)
		{
			var goldBarController = new GoldBarController(goldBarModel);

			GoldBarView goldBarView;
			if (_goldBarsPool.Count > 0)
			{
				goldBarView = _goldBarsPool.First();
				_goldBarsPool.Remove(goldBarView);
			}
			else
			{
				goldBarView = Instantiate(Resources.Load<GoldBarView>(PrefabPath.GoldBarView), transform);
			}

			var initialPosition = _fieldGrid.Grid[goldBarModel.PositionIndex];
			goldBarView.gameObject.SetActive(true);
			goldBarView.transform.localPosition = initialPosition;
			goldBarView.Initialize(new GoldBarView.Data(goldBarController, initialPosition));
			_goldBars.Add(goldBarModel, goldBarView);

			goldBarController.Listenable.AddListener<GoldBarCollected>(this);
		}

		public void OnMessage(GoldBarFound message)
		{
			CreateGoldBarView(new GoldBarModel(message.GoldBarModel));
		}

		public void OnMessage(GoldBarCollected message)
		{
			MoveViewBackToPool(message.GoldBarModel);
			_controller.RemoveGoldBar(message.GoldBarModel);
			message.GoldBarModel.RemoveListener<GoldBarCollected>(this);
		}

		private void MoveViewBackToPool(GoldBarModel goldBarModel)
		{
			var goldBarView = _goldBars[goldBarModel];
			_goldBars.Remove(goldBarModel);

			_goldBarsPool.Add(goldBarView);
		}

		private void OnDestroy()
		{
			_controller.Listenable.RemoveListener<GoldBarFound>(this);
		}
	}
}