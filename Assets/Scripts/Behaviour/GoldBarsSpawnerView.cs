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

			public Data(GoldBarsSpawnerController goldBarsSpawnerController)
			{
				GoldBarsSpawnerController = goldBarsSpawnerController;
			}
		}

		private GoldBarsSpawnerController _controller;

		private readonly List<GoldBarView> _goldBarsPool = new List<GoldBarView>();
		private readonly Dictionary<GoldBarModel, GoldBarView> _goldBars = new Dictionary<GoldBarModel, GoldBarView>();

		protected override void Refresh()
		{
		}

		public override void Initialize(Data data)
		{
			_controller = data.GoldBarsSpawnerController;
			SubscribeToModel();

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

				goldBarView.Initialize(new GoldBarView.Data(goldBarController));
				goldBarView.gameObject.SetActive(true);
				_goldBars.Add(goldBarModel, goldBarView);

				return;
			}

			goldBarView = Instantiate(Resources.Load<GoldBarView>(PrefabPath.GoldBarView), transform);
			goldBarView.Initialize(new GoldBarView.Data(goldBarController));
			_goldBars.Add(goldBarModel, goldBarView);
		}

		public void OnMessage(GoldBarFound message)
		{
			CreateGoldBarView(new GoldBarModel());
		}

		public void OnMessage(GoldBarCollected message)
		{
			MoveViewBackToPool(message.GoldBarModel);
			_controller.RemoveGoldBar(message.GoldBarModel);
		}

		private void MoveViewBackToPool(GoldBarModel goldBarModel)
		{
			var goldBarView = _goldBars[goldBarModel];
			_goldBars.Remove(goldBarModel);

			_goldBarsPool.Add(goldBarView);
		}
	}
}