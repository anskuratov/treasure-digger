using System.Collections.Generic;
using UnityEngine;

public class FieldGrid
{
	private readonly int _fieldSize;
	private readonly Vector2 _elementSize;
	private readonly Dictionary<int, Vector2> _grid;

	public IReadOnlyDictionary<int, Vector2> Grid => _grid;

	public FieldGrid(int fieldSize, Vector2 elementSize)
	{
		_fieldSize = fieldSize;
		_elementSize = elementSize;
		_grid = new Dictionary<int, Vector2>(_fieldSize * _fieldSize);

		InitializeGrid();
	}

	private void InitializeGrid()
	{
		for (int i = 0; i < _fieldSize; ++i)
		{
			for (int j = 0; j < _fieldSize; ++j)
			{
				var position = new Vector2(_elementSize.x * (j - _fieldSize / 2),
					_elementSize.y * (_fieldSize / 2 - i));
				_grid.Add(i * _fieldSize + j, position);
			}
		}
	}
}