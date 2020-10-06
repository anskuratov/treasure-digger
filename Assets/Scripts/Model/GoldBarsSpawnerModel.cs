using System.Collections.Generic;
using Model.Messages;

namespace Model
{
	public class GoldBarsSpawnerModel : MessageDispatcher
	{
		private readonly List<GoldBarModel> _goldBars;

		public IReadOnlyList<GoldBarModel> GoldBars => _goldBars;

		public GoldBarsSpawnerModel()
		{
			_goldBars = new List<GoldBarModel>();
		}

		public void AddGoldBar(GoldBarModel goldBar)
		{
			if (_goldBars.Contains(goldBar))
			{
				return;
			}

			_goldBars.Add(goldBar);
			Dispatch(new GoldBarFound(goldBar));
		}

		public void RemoveGoldBar(GoldBarModel goldBar)
		{
			if (_goldBars.Contains(goldBar))
			{
				_goldBars.Remove(goldBar);
			}
		}

		public void RemoveAllGoldBars()
		{
			_goldBars.Clear();
			Dispatch(new GoldBarsRemoved());
		}
	}
}