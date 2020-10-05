using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class CellController : IStorable
	{
		private string StoreKey => $"Cell{_cell.PositionIndex.ToString()}";

		public IListenable Listenable => _cell;

		private readonly CellModel _cell;

		public CellController(CellModel cell)
		{
			_cell = cell;
		}

		public int CellLevel => _cell.Level;
		public int CellDepth => _cell.Depth;
		public int PositionIndex => _cell.PositionIndex;

		public void UpLevel()
		{
			if (CellLevel < CellDepth)
			{
				_cell.Level += 1;
			}
		}

		public void Save()
		{
			PlayerPrefs.SetInt(StoreKey, _cell.Level);
		}

		public void Load()
		{
			if (PlayerPrefs.HasKey(StoreKey))
			{
				_cell.Level = PlayerPrefs.GetInt(StoreKey);
			}
		}
	}
}