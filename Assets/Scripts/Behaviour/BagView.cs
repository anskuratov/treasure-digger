using UnityEngine;

namespace Behaviour
{
	public class BagView : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			var goldBarView = other.gameObject.GetComponent<GoldBarView>();
			if (other.gameObject.GetComponent<GoldBarView>() != null)
			{
				goldBarView.IsInBag = true;
			}
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			var goldBarView = other.gameObject.GetComponent<GoldBarView>();
			if (other.gameObject.GetComponent<GoldBarView>() != null)
			{
				goldBarView.IsInBag = false;
			}
		}
	}
}