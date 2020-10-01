using System;

namespace Controller.Commands.Core
{
	public interface ICommandPool
	{
		void Register<TData, TCommand>()
			where TData : struct
			where TCommand : ICommand;

		Type GetCommand<TData>()
			where TData : struct;
	}
}