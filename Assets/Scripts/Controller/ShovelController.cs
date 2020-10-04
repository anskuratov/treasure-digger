using System;
using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class ShovelController : IStorable
	{
		private const string StoreKey = "Shovel";

		public IListenable Listenable => _shovel;

		private readonly ShovelModel _shovel;

		public ShovelController(ShovelModel shovel)
		{
			_shovel = shovel;
		}

		public int ShovelAmount => _shovel.Amount;

		public void UseShovel()
		{
			if (_shovel.Amount < 1)
			{
				throw new InvalidOperationException("You can't use shovel, if you haven't it");
			}

			_shovel.Amount -= 1;
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _shovel.Amount);
		}

		public void Load()
		{
			if (PlayerPrefs.HasKey(StoreKey))
			{
				_shovel.Amount = PlayerPrefs.GetInt(StoreKey);
			}
		}
	}
}