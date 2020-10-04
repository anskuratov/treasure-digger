using Model;
using Model.Messages;
using UnityEngine;

namespace Controller
{
	public class CellController : IStorable
	{
		private string StoreKey => $"Cell{_storeIndex.ToString()}";

		public IListenable Listenable => _cell;

		private readonly CellModel _cell;
		private readonly int _storeIndex;

		public CellController(CellModel cell, int storeIndex)
		{
			_cell = cell;
			_storeIndex = storeIndex;
		}

		public int CellLevel => _cell.Level;
		public int CellDepth => _cell.Depth;

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