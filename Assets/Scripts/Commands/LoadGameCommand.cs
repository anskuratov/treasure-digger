using System.Collections.Generic;
using Commands.Core;
using Controller;

namespace Commands
{
	public class LoadGameCommand : Command<LoadGame>
	{
		private readonly ShovelController _shovelController;
		private readonly GoldWalletController _goldWalletController;
		private readonly Dictionary<int, CellController> _cellControllers;
		private readonly GoldBarsSpawnerController _goldBarsSpawnerController;

		public LoadGameCommand(ShovelController shovelController,
			GoldWalletController goldWalletController,
			Dictionary<int, CellController> cellControllers,
			GoldBarsSpawnerController goldBarsSpawnerController)
		{
			_shovelController = shovelController;
			_goldWalletController = goldWalletController;
			_cellControllers = cellControllers;
			_goldBarsSpawnerController = goldBarsSpawnerController;
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
		}

		public override void PostExecute()
		{
		}
	}
}