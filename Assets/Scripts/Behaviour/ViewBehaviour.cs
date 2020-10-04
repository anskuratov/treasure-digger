using UnityEngine;

namespace Behaviour
{
	public abstract class ViewBehaviour<TData> : MonoBehaviour,
		IInitializable<TData>
		where TData : struct
	{
		protected abstract void Refresh();
		public abstract void Initialize(TData data);
	}
}