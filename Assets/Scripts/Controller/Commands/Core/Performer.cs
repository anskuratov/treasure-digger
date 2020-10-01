using System;

namespace Controller.Commands.Core
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
				Type commandType = _commandPool.GetCommand<T>();
				object commandObject = Activator.CreateInstance(commandType, commandData);
				if (commandObject is ICommand command)
				{
					command.Execute();
				}
			}
		}

		public IPerformer Create(ICommandPool commandPool) => new Performer(commandPool);
	}
}