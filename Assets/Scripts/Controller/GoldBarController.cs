using Model;
using Model.Messages;

namespace Controller
{
	public class GoldBarController
	{
		private readonly GoldBarModel _model;

		public IListenable Listenable => _model;

		public GoldBarController(GoldBarModel model)
		{
			_model = model;
		}

		public void Collect()
		{
			_model.IsCollected = true;
		}
	}
}