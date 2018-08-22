using System.Collections.Generic;
using System.Web.Mvc;
using FruitBasket.Core;
using FruitBasket.Core.Interfaces;
using FruitBasket.Core.Models;
using FruitBasket.Core.Services;
using FruitBasket.Core.ServicesInterfaces;

namespace FruitBasket.Web.Controllers
{
	public class HomeController : Controller
	{
		private readonly IGuessingService _guessingService;
		public HomeController(IGuessingService guessingService)
		{
			_guessingService = guessingService;
		}
		public ActionResult Index()
		{
			
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			var service = new GuessingService();
			// MOCK
			var players = GeneratePlayers();
			int realBasketWeight = new Core.Models.FruitBasket().RealWeight;

			//var result = service.GetWinnerName(players, realBasketWeight);
			var result = _guessingService.GetWinnerName(players, realBasketWeight);

			return View();
		}

		private List<Player> GeneratePlayers()
		{
			var players = new List<Player>();
			for (var i = 0; i < 5; i++)
			{
				var name = "Test " + i;
				var type = i % 2 == 0 ? PlayerType.Random : PlayerType.Memory;
				IGuessing guessing = i % 2 == 0 ? (IGuessing)new GuessingForRandomPlayer() : new GuessingForMemoryPlayer();

				var player = new Player(name, type, guessing);


				players.Add(player);
			}

			return players;
		}
	}
}