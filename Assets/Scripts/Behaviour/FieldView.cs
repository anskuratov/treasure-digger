using System.Collections.Generic;
using Commands.Core;
using Controller;
using DefaultNamespace;
using UnityEngine;

namespace Behaviour
{
	public class FieldView : ViewBehaviour<FieldView.Data>
	{
		public readonly struct Data
		{
			public readonly IPerformer Performer;
			public readonly IReadOnlyDictionary<int, CellController> CellControllers;
			public readonly int FieldSize;
			public readonly Vector2 ElementSize;

			public Data(IPerformer performer,
				IReadOnlyDictionary<int, CellController> cellControllers,
				int fieldSize,
				Vector2 elementSize)
			{
				Performer = performer;
				CellControllers = cellControllers;
				FieldSize = fieldSize;
				ElementSize = elementSize;
			}
		}

		[SerializeField]
		private Transform _cellsParent;

		private IPerformer _performer;
		private IReadOnlyDictionary<int, CellController> _cellControllers;
		private FieldGrid _fieldGrid;

		public override void Initialize(Data data)
		{
			_performer = data.Performer;
			_cellControllers = data.CellControllers;
			_fieldGrid = new FieldGrid(data.FieldSize, data.ElementSize);

			CreateCells();

			transform.localPosition += new Vector3(0f, 0f, 1f);
		}

		private void CreateCells()
		{
			foreach (KeyValuePair<int, CellController> cellController in _cellControllers)
			{
				var cellView = Instantiate(Resources.Load<CellView>(PrefabPath.CellView), _cellsParent);
				cellView.transform.localPosition = _fieldGrid.Grid[cellController.Key];
				cellView.Initialize(new CellView.Data(_performer, cellController.Value));
			}
		}
	}
}