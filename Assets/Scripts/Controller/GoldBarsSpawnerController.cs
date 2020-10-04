using System.Collections.Generic;
using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class GoldBarsSpawnerController : IStorable
	{
		private const string StoreKey = "GoldBarsSpawner";

		private readonly GoldBarsSpawnerModel _model;

		public IListenable Listenable => _model;
		public IReadOnlyList<GoldBarModel> GoldBars => _model.GoldBars;

		public GoldBarsSpawnerController(GoldBarsSpawnerModel model)
		{
			_model = model;
		}
 
		public void AddGoldBar() => _model.AddGoldBar(new GoldBarModel());
		public void RemoveGoldBar(GoldBarModel goldBar) => _model.RemoveGoldBar(goldBar);

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _model.GoldBars.Count);
		}

		public void Load()
		{
			var goldBarsCount = PlayerPrefs.GetInt(StoreKey);
			for (int i = 0; i < goldBarsCount; ++i)
			{
				var goldBarModel = new GoldBarModel();
				_model.AddGoldBar(goldBarModel);
			}
		}
	}
}