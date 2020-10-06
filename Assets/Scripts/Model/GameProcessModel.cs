using Model.Messages;

namespace Model
{
	public class GameProcessModel : MessageDispatcher
	{
		public bool IsEnded
		{
			get => _isEnded;
			set
			{
				if (_isEnded != value)
				{
					_isEnded = value;
					Dispatch(new GameProcessChanged());
				}
			}
		}

		private bool _isEnded;

		public GameProcessModel()
		{
			_isEnded = false;
		}
	}
}