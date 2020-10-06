using System.Collections;
using Commands;
using Commands.Core;
using Controller;
using UnityEngine;

namespace Behaviour
{
	public class GoldBarView : ViewBehaviour<GoldBarView.Data>
	{
		public readonly struct Data
		{
			public readonly IPerformer Performer;
			public readonly GoldBarController GoldBarController;
			public readonly Vector2 InitialPosition;

			public Data(IPerformer performer, GoldBarController goldBarController, Vector2 initialPosition)
			{
				Performer = performer;
				GoldBarController = goldBarController;
				InitialPosition = initialPosition;
			}
		}

		public bool IsInBag { get; set; }

		private IPerformer _performer;
		private GoldBarController _controller;
		private Vector2 _initialPosition;
		private bool _isDragging;

		protected override void Refresh()
		{
		}

		public override void Initialize(Data data)
		{
			_performer = data.Performer;
			_controller = data.GoldBarController;
			_initialPosition = data.InitialPosition;

			IsInBag = false;

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

			if (IsInBag)
			{
				_performer.Invoke(new CollectGold(_controller));
			}
			else
			{
				transform.localPosition = _initialPosition;
			}
		}
	}
}