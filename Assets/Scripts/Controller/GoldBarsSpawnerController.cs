using System.Collections.Generic;
using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class GoldBarsSpawnerController : IStorable
	{
		private const string StoreKey = "GoldBarsSpawner";
		private const string GoldBarStoreKeyPrefix = "GoldBar";

		private readonly GoldBarsSpawnerModel _model;

		public IListenable Listenable => _model;
		public IReadOnlyList<GoldBarModel> GoldBars => _model.GoldBars;

		public GoldBarsSpawnerController(GoldBarsSpawnerModel model)
		{
			_model = model;
		}

		public void AddGoldBar(int positionIndex) => _model.AddGoldBar(new GoldBarModel(positionIndex));
		public void RemoveGoldBar(GoldBarModel goldBar) => _model.RemoveGoldBar(goldBar);

		public void Reset()
		{
			_model.RemoveAllGoldBars();
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _model.GoldBars.Count);
			for (int i = 0; i < _model.GoldBars.Count; ++i)
			{
				PlayerPrefs.SetInt($"{GoldBarStoreKeyPrefix}{i.ToString()}", _model.GoldBars[i].PositionIndex);
			}
		}

		public void Load()
		{
			if (PlayerPrefs.HasKey(StoreKey))
			{
				var goldBarsCount = PlayerPrefs.GetInt(StoreKey);
				for (int i = 0; i < goldBarsCount; ++i)
				{
					var positionIndex = PlayerPrefs.GetInt($"{GoldBarStoreKeyPrefix}{i.ToString()}");
					var goldBarModel = new GoldBarModel(positionIndex);
					_model.AddGoldBar(goldBarModel);
				}
			}
		}
	}
}