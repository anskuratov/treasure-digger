using Controller;

namespace Commands
{
	public struct Dig
	{
		public readonly ShovelController ShovelController;

		public Dig(ShovelController shovelController)
		{
			ShovelController = shovelController;
		}
	}
}