using Controller;

namespace Commands
{
	public class CollectGoldCommand : SaveCommand<CollectGold>
	{
		private readonly GoldWalletController _goldWalletController;

		public CollectGoldCommand(GoldWalletController goldWalletController, StorageManager storageManager) :
			base(storageManager, goldWalletController)
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