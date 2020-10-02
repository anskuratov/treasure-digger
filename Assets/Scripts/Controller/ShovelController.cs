using System;
using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class ShovelController : IStorable
	{
		public IListenable Listenable => _shovel;

		private readonly ShovelModel _shovel;

		public ShovelController(ShovelModel shovel)
		{
			_shovel = shovel;
		}

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
			PlayerPrefs.SetInt(_shovel.StoreKey, _shovel.Amount);
		}

		public void Load()
		{
			_shovel.Amount = PlayerPrefs.GetInt(_shovel.StoreKey);
		}
	}
}