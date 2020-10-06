using Controller;

namespace Commands
{
	public readonly struct LoadGame
	{
	}

	public readonly struct RestartGame
	{
	}

	public readonly struct Dig
	{
		public readonly CellController CellController;

		public Dig(CellController cellController)
		{
			CellController = cellController;
		}
	}

	public readonly struct CollectGold
	{
		public readonly GoldBarController GoldBarController;

		public CollectGold(GoldBarController goldBarController)
		{
			GoldBarController = goldBarController;
		}
	}

	public readonly struct SpawnGoldBar
	{
		public readonly int PositionIndex;

		public SpawnGoldBar(int positionIndex)
		{
			PositionIndex = positionIndex;
		}
	}

	public readonly struct EndGame
	{
	}
}