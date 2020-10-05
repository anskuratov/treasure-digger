using UnityEngine;

namespace Commands.Core
{
	public class PerformerFactory
	{
		private class Performer : IPerformer
		{
			private readonly ICommandPool _commandPool;

			public Performer(ICommandPool commandPool)
			{
				_commandPool = commandPool;
			}

			public void Invoke<T>(T commandData) where T : struct
			{
				ICommand command = _commandPool.GetCommand<T>();
				(command as Command<T>)?.Initialize(commandData);

				if (command.Check())
				{
					command.Execute();
					command.PostExecute();
				}
				else
				{
					Debug.LogError("Command invocation was interrupted while Checking");
				}
			}
		}

		public IPerformer Create(ICommandPool commandPool) => new Performer(commandPool);
	}
}