using Controller;

namespace Commands
{
	public class DigCommand : SaveCommand<Dig>
	{
		private readonly ShovelController _shovelController;

		public DigCommand(Dig data, StorageManager storageManager, IStorable storable) : base(data, storageManager,
			storable)
		{
			_shovelController = data.ShovelController;
		}

		public override void Execute()
		{
			base.Execute();
			_shovelController.UseShovel();
		}
	}
}