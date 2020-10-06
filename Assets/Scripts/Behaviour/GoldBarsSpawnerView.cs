using System.Collections.Generic;
using System.Linq;
using Commands.Core;
using Controller;
using DefaultNamespace;
using Model;
using Model.Messages;
using UnityEngine;

namespace Behaviour
{
	public class GoldBarsSpawnerView : ViewBehaviour<GoldBarsSpawnerView.Data>,
		IMessageListener<GoldBarFound>,
		IMessageListener<GoldBarsRemoved>,
		IMessageListener<GoldBarCollected>
	{
		public readonly struct Data
		{
			public readonly IPerformer Performer;
			public readonly GoldBarsSpawnerController GoldBarsSpawnerController;
			public readonly int FieldSize;
			public readonly Vector2 ElementSize;

			public Data(IPerformer performer, GoldBarsSpawnerController goldBarsSpawnerController, int fieldSize, Vector2 elementSize)
			{
				Performer = performer;
				GoldBarsSpawnerController = goldBarsSpawnerController;
				FieldSize = fieldSize;
				ElementSize = elementSize;
			}
		}

		private IPerformer _performer;
		private GoldBarsSpawnerController _controller;
		private FieldGrid _fieldGrid;

		private readonly List<GoldBarView> _goldBarsPool = new List<GoldBarView>();
		private readonly Dictionary<GoldBarModel, GoldBarView> _goldBars = new Dictionary<GoldBarModel, GoldBarView>();

		protected override void Refresh()
		{
		}

		public override void Initialize(Data data)
		{
			_performer = data.Performer;
			_controller = data.GoldBarsSpawnerController;
			SubscribeToModel();
			_fieldGrid = new FieldGrid(data.FieldSize, data.ElementSize);

			SpawnGoldBars();

			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener<GoldBarFound>(this);
			_controller.Listenable.AddListener<GoldBarsRemoved>(this);
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
			goldBarView.Initialize(new GoldBarView.Data(_performer, goldBarController, initialPosition));
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
		}

		private void MoveViewBackToPool(GoldBarModel goldBarModel)
		{
			var goldBarView = _goldBars[goldBarModel];
			goldBarView.gameObject.SetActive(false);
			_goldBars.Remove(goldBarModel);

			_goldBarsPool.Add(goldBarView);
		}

		private void OnDestroy()
		{
			_controller.Listenable.RemoveListener<GoldBarFound>(this);
		}

		public void OnMessage(GoldBarsRemoved message)
		{
			while (_goldBars.Count > 0)
			{
				GoldBarModel goldBarModel = _goldBars.First().Key;
				MoveViewBackToPool(goldBarModel);
			}
		}
	}
}