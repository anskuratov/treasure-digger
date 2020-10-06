using Controller;

namespace Commands
{
	public class EndGameCommand : SaveCommand<EndGame>
	{
		private readonly GameProcessController _gameProcessController;

		public EndGameCommand(GameProcessController gameProcessController,
			StorageManager storageManager) : base(storageManager, gameProcessController)
		{
			_gameProcessController = gameProcessController;
		}

		public override void Execute()
		{
			base.Execute();
			_gameProcessController.EndGame();
		}
	}
}