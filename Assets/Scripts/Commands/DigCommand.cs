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

		public override bool Check()
		{
			var result = base.Check();
			result &= _shovelController.ShovelAmount > 0;
			result &= _data.CellController.CellLevel < _data.CellController.CellDepth;
			return result;
		}

		public override void Execute()
		{
			base.Execute();
			_shovelController.UseShovel();
			_data.CellController.UpLevel();
		}

		public override void PostExecute()
		{
			base.PostExecute();
			_storageManager.Save(_data.CellController);
		}
	}
}