using System.Collections.Generic;
using Controller;

namespace Commands
{
	public class RestartGameCommand : SaveCommand<RestartGame>
	{
		private readonly ShovelController _shovelController;
		private readonly GoldWalletController _goldWalletController;
		private readonly IReadOnlyDictionary<int, CellController> _cellControllers;
		private readonly GoldBarsSpawnerController _goldBarsSpawnerController;
		private readonly GameProcessController _gameProcessController;

		public RestartGameCommand(ShovelController shovelController,
			GoldWalletController goldWalletController,
			IReadOnlyDictionary<int, CellController> cellControllers,
			GoldBarsSpawnerController goldBarsSpawnerController,
			GameProcessController gameProcessController,
			StorageManager storageManager) :
			base(storageManager,
				shovelController,
				goldWalletController,
				goldBarsSpawnerController,
				gameProcessController)
		{
			_shovelController = shovelController;
			_goldWalletController = goldWalletController;
			_cellControllers = cellControllers;
			_goldBarsSpawnerController = goldBarsSpawnerController;
			_gameProcessController = gameProcessController;
		}

		public override void Execute()
		{
			base.Execute();

			_shovelController.Reset();
			_goldWalletController.Reset();

			foreach (var cellController in _cellControllers.Values)
			{
				cellController.Reset();
			}

			_goldBarsSpawnerController.Reset();
			_gameProcessController.Reset();
		}

		public override void PostExecute()
		{
			base.PostExecute();

			foreach (CellController cellController in _cellControllers.Values)
			{
				cellController.Save();
			}
		}
	}
}