using Controller;

namespace Commands
{
	public class CollectGoldCommand : SaveCommand<CollectGold>
	{
		private readonly GoldWalletController _goldWalletController;

		public CollectGoldCommand(GoldWalletController goldWalletController,
			GoldBarsSpawnerController goldBarsSpawnerController,
			StorageManager storageManager) :
			base(storageManager, goldWalletController, goldBarsSpawnerController)
		{
			_goldWalletController = goldWalletController;
		}

		public override void Execute()
		{
			base.Execute();
			_goldWalletController.CollectGold();
			_data.GoldBarController.Collect();
		}
	}
}