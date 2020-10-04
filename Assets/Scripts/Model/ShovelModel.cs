using Model.Messages;

namespace Model
{
	public class ShovelModel : MessageDispatcher
	{
		public int Amount
		{
			get => _amount;
			set
			{
				_amount = value;
				Dispatch(new ShovelChanged(_amount));
			}
		}

		private int _amount;

		public ShovelModel(int amount)
		{
			_amount = amount;
		}
	}
}