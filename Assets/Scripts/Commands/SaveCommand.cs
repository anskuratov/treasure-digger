using Commands.Core;
using Controller;

namespace Commands
{
	public abstract class SaveCommand<T> : Command<T>
		where T : struct
	{
		private readonly StorageManager _storageManager;
		private readonly IStorable[] _storables;

		protected SaveCommand(StorageManager storageManager, params IStorable[] storables)
		{
			_storageManager = storageManager;
			_storables = storables;
		}

		public override void Execute()
		{
		}

		public override void PostExecute()
		{
			if (_storables != null)
			{
				foreach (IStorable storable in _storables)
				{
					_storageManager.Save(storable);
				}
			}
		}
	}
}