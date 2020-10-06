using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class GameProcessController : IStorable
	{
		private const string StoreKey = "GameProcess";
		
		private readonly GameProcessModel _model;

		public IListenable Listenable => _model;
		public bool IsEnded => _model.IsEnded;

		public GameProcessController(GameProcessModel model)
		{
			_model = model;
		}

		public void EndGame()
		{
			_model.IsEnded = true;
		}

		public void Reset()
		{
			_model.IsEnded = false;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _model.IsEnded ? 1 : 0);
		}

		public void Load()
		{
			if (PlayerPrefs.HasKey(StoreKey))
			{
				_model.IsEnded = PlayerPrefs.GetInt(StoreKey) == 1;
			}
		}
	}
}