using Model.Messages;

namespace Model
{
	public class GoldBarModel : MessageDispatcher
	{
		private bool _isCollected;

		public bool IsCollected
		{
			get => _isCollected;
			set
			{
				if (_isCollected != value)
				{
					_isCollected = value;
					Dispatch(new GoldBarCollected());
				}
			}
		}

		public GoldBarModel()
		{
			_isCollected = false;
		}
	}
}