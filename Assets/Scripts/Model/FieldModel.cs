namespace Model
{
	public class FieldModel : IStorable
	{
		private readonly CellModel[][] _cells;

		public FieldModel(int fieldSize, int cellDepth)
		{
			_cells = new CellModel[fieldSize][];

			for (int i = 0; i < _cells.Length; ++i)
			{
				_cells[i] = new CellModel[fieldSize];

				for (int j = 0; j < _cells[i].Length; ++j)
				{
					_cells[i][j] = new CellModel(cellDepth, (i, j));
				}
			}
		}

		public void Save()
		{
			foreach (CellModel[] cellLine in _cells)
			{
				foreach (CellModel cell in cellLine)
				{
					cell.Save();
				}
			}
		}

		public void Load()
		{
			foreach (CellModel[] cellLine in _cells)
			{
				foreach (CellModel cell in cellLine)
				{
					cell.Load();
				}
			}
		}
	}
}