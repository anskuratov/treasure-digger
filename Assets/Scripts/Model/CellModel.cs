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

		private int _level;

		public CellModel(int depth)
		{
			Depth = depth;
			_level = 0;
		}
	}
}