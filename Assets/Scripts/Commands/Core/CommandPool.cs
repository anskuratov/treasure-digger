using System;
using System.Collections.Generic;

namespace Commands.Core
{
	public class CommandPool : ICommandPool
	{
		private readonly Dictionary<Type, ICommand> _commands;

		public CommandPool()
		{
			_commands = new Dictionary<Type, ICommand>();
		}

		public void Register<TData>(ICommand command)
			where TData : struct
		{
			if (_commands.ContainsKey(typeof(TData)))
			{
				throw new ArgumentException("Command is already existed");
			}

			_commands.Add(typeof(TData), command);
		}

		public ICommand GetCommand<TData>()
			where TData : struct
		{
			if (_commands.ContainsKey(typeof(TData)) == false)
			{
				throw new ArgumentException("Unknown command");
			}

			ICommand command = _commands[typeof(TData)];
			return command;
		}
	}
}