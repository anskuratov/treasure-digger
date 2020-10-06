using System;
using Commands;
using Commands.Core;
using Controller;
using Model;
using Model.Messages;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviour
{
	public class GameProcessView : ViewBehaviour<GameProcessView.Data>,
		IMessageListener<GameProcessChanged>
	{
		public readonly struct Data
		{
			public readonly IPerformer Performer;
			public readonly GameProcessController GameProcessController;

			public Data(IPerformer performer, GameProcessController gameProcessController)
			{
				Performer = performer;
				GameProcessController = gameProcessController;
			}
		}

		[SerializeField]
		private GameObject _endGameWindow;

		[SerializeField]
		private Button _endRestartGameButton;

		[SerializeField]
		private Button _restartGameButton;

		private GameProcessController _controller;

		protected override void Refresh()
		{
			base.Refresh();
			_endGameWindow.SetActive(_controller.IsEnded);
		}

		public override void Initialize(Data data)
		{
			_controller = data.GameProcessController;
			SubscribeToModel();

			_endRestartGameButton.onClick.AddListener(() => { data.Performer.Invoke(new RestartGame()); });
			_restartGameButton.onClick.AddListener(() => { data.Performer.Invoke(new RestartGame()); });

			Refresh();
		}

		private void SubscribeToModel()
		{
			_controller.Listenable.AddListener(this);
		}

		public void OnMessage(GameProcessChanged message)
		{
			Refresh();
		}

		private void OnDestroy()
		{
			_controller.Listenable.RemoveListener(this);
		}
	}
}