using Controller;

namespace Commands
{
	public readonly struct LoadGame
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
	}

	public readonly struct SpawnGoldBar
	{
	}
}