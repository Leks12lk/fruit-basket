using System.Collections.Generic;

namespace FruitBasket.Web.ViewModels
{
	public class StartingGameViewModel
	{
		public List<PlayerViewModel> Players { get; set; }
		public int RealBasketWeight { get; set; }
	}
}