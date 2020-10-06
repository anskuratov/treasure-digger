using System.Collections.Generic;
using Commands.Core;
using Controller;

namespace Commands
{
	public class LoadGameCommand : Command<LoadGame>
	{
		private readonly StorageManager _storageManager;
		private readonly List<IStorable> _storables;

		public LoadGameCommand(StorageManager storageManager,
			IReadOnlyList<IStorable> listStorables,
			params IStorable[] otherStorables)
		{
			_storageManager = storageManager;

			_storables = new List<IStorable>();

			foreach (IStorable storable in listStorables)
			{
				_storables.Add(storable);
			}

			foreach (IStorable storable in otherStorables)
			{
				_storables.Add(storable);
			}
		}

		public override bool Check()
		{
			var result = true;
			foreach (IStorable storable in _storables)
			{
				result &= storable != null;
			}

			return result;
		}

		public override void Execute()
		{
			foreach (IStorable storable in _storables)
			{
				_storageManager.Load(storable);
			}
		}

		public override void PostExecute()
		{
		}
	}
}