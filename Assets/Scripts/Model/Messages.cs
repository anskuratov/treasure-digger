using System.Collections.Generic;

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

	public readonly struct GoldWalletChanged
	{
		public readonly int Amount;

		public GoldWalletChanged(int amount)
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

	public readonly struct GoldBarCollected
	{
		public readonly GoldBarModel GoldBarModel;

		public GoldBarCollected(GoldBarModel goldBarModel)
		{
			GoldBarModel = goldBarModel;
		}
	}

	public readonly struct GoldBarFound
	{
		public readonly GoldBarModel GoldBarModel;

		public GoldBarFound(GoldBarModel goldBarModel)
		{
			GoldBarModel = goldBarModel;
		}
	}

	public readonly struct GameProcessChanged
	{
	}

	public readonly struct GoldBarsRemoved
	{
	}
}