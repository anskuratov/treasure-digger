using Controller;

namespace Commands
{
	public class DigCommand : SaveCommand<Dig>
	{
		private readonly ShovelController _shovelController;
		private readonly StorageManager _storageManager;

		public DigCommand(ShovelController shovelController, StorageManager storageManager) : base(storageManager,
			shovelController)
		{
			_shovelController = shovelController;
			_storageManager = storageManager;
		}

		public override void Execute()
		{
			base.Execute();
			_shovelController.UseShovel();
		}

		public override void PostExecute()
		{
			base.PostExecute();
			_storageManager.Save(_data.CellController);
		}
	}
}