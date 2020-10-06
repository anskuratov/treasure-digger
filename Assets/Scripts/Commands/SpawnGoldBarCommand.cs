using Controller;
using Model;

namespace Commands
{
	public class SpawnGoldBarCommand : SaveCommand<SpawnGoldBar>
	{
		private readonly GoldBarsSpawnerController _goldBarsSpawnerController;

		public SpawnGoldBarCommand(GoldBarsSpawnerController goldBarsSpawnerController, StorageManager storageManager) :
			base(storageManager, goldBarsSpawnerController)
		{
			_goldBarsSpawnerController = goldBarsSpawnerController;
		}

		public override void Execute()
		{
			base.Execute();
			_goldBarsSpawnerController.AddGoldBar(new GoldBarModel(_data.PositionIndex));
		}
	}
}