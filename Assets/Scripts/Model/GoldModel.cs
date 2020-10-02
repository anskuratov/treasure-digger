using Model.Messages;

namespace Model
{
	public class GoldModel : MessageDispatcher
	{
		public string StoreKey => "Gold";
		public int GoalAmount { get; }

		public int Amount
		{
			get => _amount;
			set
			{
				_amount = value;
				Dispatch(new GoldChanged(_amount));
			}
		}

		private int _amount;

		public GoldModel(int goalAmount)
		{
			GoalAmount = goalAmount;
			_amount = 0;
		}
	}
}