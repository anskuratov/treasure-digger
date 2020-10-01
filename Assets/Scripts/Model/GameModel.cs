using UnityEngine;

namespace Model
{
	public class GameModel : IStorable
	{
		private const int ShovelsAmount = 25;
		private const int GoldGoal = 5;
		private const int FieldSize = 10;
		private const int CellDepth = 4;
		
		private readonly PlayerModel _player;
		private readonly FieldModel _field;

		public GameModel()
		{
			_player = new PlayerModel(ShovelsAmount, GoldGoal);
			_field = new FieldModel(FieldSize, CellDepth);
		}

		public void Save()
		{
			_player.Save();
			_field.Save();
			PlayerPrefs.Save();
		}

		public void Load()
		{
			_player.Load();
			_field.Load();
		}
	}
}