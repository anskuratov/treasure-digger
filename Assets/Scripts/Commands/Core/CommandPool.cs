using System;
using System.Collections.Generic;

namespace Commands.Core
{
	public class CommandPool : ICommandPool
	{
		private readonly Dictionary<Type, Type> _commands;

		public CommandPool()
		{
			_commands = new Dictionary<Type, Type>();
		}

		public void Register<TData, TCommand>()
			where TData : struct
			where TCommand : ICommand
		{
			if (_commands.ContainsKey(typeof(TData)))
			{
				throw new ArgumentException("Command is already existed");
			}

			_commands.Add(typeof(TData), typeof(TCommand));
		}

		public Type GetCommand<TData>()
			where TData : struct
		{
			if (_commands.ContainsKey(typeof(TData)) == false)
			{
				throw new ArgumentException("Unknown command");
			}

			Type commandType = _commands[typeof(TData)];
			return commandType;
		}
	}
}