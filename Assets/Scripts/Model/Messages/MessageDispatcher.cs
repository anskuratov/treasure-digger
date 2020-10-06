using System;
using System.Collections.Generic;

namespace Model.Messages
{
	public abstract class MessageDispatcher : IListenable
	{
		private Dictionary<Type, List<object>> _listeners;

		public MessageDispatcher()
		{
			_listeners = new Dictionary<Type, List<object>>();
		}

		public void AddListener<T>(IMessageListener<T> listener)
			where T : struct
		{
			if (_listeners.ContainsKey(typeof(T)) == false)
			{
				_listeners.Add(typeof(T), new List<object>());
			}

			_listeners[typeof(T)].Add(listener);
		}

		public void RemoveListener<T>(IMessageListener<T> listener) where T : struct
		{
			_listeners[typeof(T)].Remove(listener);
		}

		public void Dispatch<T>(T message)
			where T : struct
		{
			if (_listeners.ContainsKey(typeof(T)))
			{
				foreach (object listener in _listeners[typeof(T)])
				{
					IMessageListener<T> messageListener = listener as IMessageListener<T>;
					messageListener.OnMessage(message);
				}
			}
		}
	}
}