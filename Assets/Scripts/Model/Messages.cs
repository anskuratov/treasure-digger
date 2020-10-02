namespace Model
{
	public readonly struct ShovelChanged
	{
		public readonly int Amount;

		public ShovelChanged(int amount)
		{
			Amount = amount;
		}
	}

	public readonly struct GoldChanged
	{
		public readonly int Amount;

		public GoldChanged(int amount)
		{
			Amount = amount;
		}
	}

	public readonly struct CellChanged
	{
		public readonly int Level;

		public CellChanged(int level)
		{
			Level = level;
		}
	}
}