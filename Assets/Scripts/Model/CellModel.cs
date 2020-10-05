using Model.Messages;

namespace Model
{
	public class CellModel : MessageDispatcher
	{
		public int Depth { get; }

		public int Level
		{
			get => _level;
			set
			{
				_level = value;
				Dispatch(new CellChanged(_level));
			}
		}

		public readonly int PositionIndex;

		private int _level;

		public CellModel(int depth, int positionIndex)
		{
			Depth = depth;
			PositionIndex = positionIndex;
			_level = 0;
		}
	}
}