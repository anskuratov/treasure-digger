using Commands.Core;
using Controller;

namespace Commands
{
	public class DigCommand : SaveCommand<Dig>
	{
		private readonly IPerformer _performer;
		private readonly ShovelController _shovelController;
		private readonly StorageManager _storageManager;

		public DigCommand(IPerformer performer, ShovelController shovelController, StorageManager storageManager) : base(storageManager,
			shovelController)
		{
			_performer = performer;
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

			_performer.Invoke(new SpawnGoldBar(_data.CellController.PositionIndex));
		}

		public override void PostExecute()
		{
			base.PostExecute();
			_storageManager.Save(_data.CellController);
		}
	}
}