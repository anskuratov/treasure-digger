﻿using System.Collections.Generic;
using Commands.Core;
using Controller;

namespace Commands
{
	public class LoadGameCommand : Command<LoadGame>
	{
		private readonly ShovelController _shovelController;
		private readonly GoldWalletController _goldWalletController;
		private readonly IReadOnlyDictionary<int, CellController> _cellControllers;
		private readonly GoldBarsSpawnerController _goldBarsSpawnerController;
		private readonly GameProcessController _gameProcessController;

		public LoadGameCommand(ShovelController shovelController,
			GoldWalletController goldWalletController,
			IReadOnlyDictionary<int, CellController> cellControllers,
			GoldBarsSpawnerController goldBarsSpawnerController,
			GameProcessController gameProcessController)
		{
			_shovelController = shovelController;
			_goldWalletController = goldWalletController;
			_cellControllers = cellControllers;
			_goldBarsSpawnerController = goldBarsSpawnerController;
			_gameProcessController = gameProcessController;
		}

		public override bool Check()
		{
			var result = _shovelController != null;
			result &= _goldWalletController != null;
			result &= _cellControllers.Count > 0;
			result &= _goldBarsSpawnerController != null;
			result &= _gameProcessController != null;
			return result;
		}

		public override void Execute()
		{
			_shovelController.Load();
			_goldWalletController.Load();

			foreach (var cell in _cellControllers)
			{
				cell.Value.Load();
			}

			_goldBarsSpawnerController.Load();
			_gameProcessController.Load();
		}

		public override void PostExecute()
		{
		}
	}
}