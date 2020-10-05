using UnityEngine;

namespace Behaviour
{
	public abstract class ViewBehaviour<TData> : MonoBehaviour,
		IInitializable<TData>
		where TData : struct
	{
		protected virtual void Refresh()
		{
		}

		public abstract void Initialize(TData data);
	}
}