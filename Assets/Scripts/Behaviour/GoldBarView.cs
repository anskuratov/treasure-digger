using System.Collections;
using Controller;
using UnityEngine;

namespace Behaviour
{
	public class GoldBarView : ViewBehaviour<GoldBarView.Data>
	{
		public readonly struct Data
		{
			public readonly GoldBarController GoldBarController;
			public readonly Vector2 InitialPosition;

			public Data(GoldBarController goldBarController, Vector2 initialPosition)
			{
				GoldBarController = goldBarController;
				InitialPosition = initialPosition;
			}
		}

		private GoldBarController _controller;
		private Vector2 _initialPosition;
		private bool _isDragging;

		protected override void Refresh()
		{
		}

		public override void Initialize(Data data)
		{
			_controller = data.GoldBarController;
			_initialPosition = data.InitialPosition;

			Refresh();
		}

		public void OnMouseDown()
		{
			_isDragging = true;
			StartCoroutine(DraggingCoroutine());
		}

		public void OnMouseUp()
		{
			_isDragging = false;
		}

		private IEnumerator DraggingCoroutine()
		{
			while (_isDragging)
			{
				Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				transform.localPosition = mousePosition;

				yield return null;
			}

			transform.localPosition = _initialPosition;
		}
	}
}