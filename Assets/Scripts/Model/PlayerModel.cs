namespace Model
{
	public class PlayerModel : IStorable
	{
		private readonly ShovelModel _shovel;
		private readonly GoldModel _gold;

		public PlayerModel(int shovelsAmount, int goldGoal)
		{
			_shovel = new ShovelModel(shovelsAmount);
			_gold = new GoldModel(goldGoal);
		}

		public void Save()
		{
			_shovel.Save();
			_gold.Save();
		}

		public void Load()
		{
			_shovel.Load();
			_gold.Load();
		}
	}
}