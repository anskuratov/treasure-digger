using Model.Messages;

namespace Model
{
	public class GoldWalletModel : MessageDispatcher
	{
		public int GoalAmount { get; }

		public int Amount
		{
			get => _amount;
			set
			{
				_amount = value;
				Dispatch(new GoldWalletChanged(_amount));
			}
		}

		private int _amount;

		public GoldWalletModel(int goalAmount)
		{
			GoalAmount = goalAmount;
			_amount = 0;
		}
	}
}