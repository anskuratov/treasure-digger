using Commands.Core;
using Controller;
using Model;

namespace Commands
{
	public abstract class SaveCommand<T> : Command<T>, ICommand
		where T : struct
	{
		private readonly StorageManager _storageManager;
		private readonly IStorable _storable;

		protected SaveCommand(T data, StorageManager storageManager, IStorable storable) : base(data)
		{
			_storageManager = storageManager;
			_storable = storable;
		}

		public virtual void Execute()
		{
		}

		public virtual void PostExecute()
		{
			_storageManager.Save(_storable);
		}
	}
}