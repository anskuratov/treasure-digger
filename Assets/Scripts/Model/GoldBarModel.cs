using Model.Messages;

namespace Model
{
	public class GoldBarModel : MessageDispatcher
	{
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

		public readonly int PositionIndex;

		private bool _isCollected;

		public GoldBarModel(int positionIndex)
		{
			PositionIndex = positionIndex;
			_isCollected = false;
		}

		public GoldBarModel(GoldBarModel model) : this(model.PositionIndex)
		{
		}
	}
}