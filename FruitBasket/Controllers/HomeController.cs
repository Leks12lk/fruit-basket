using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FruitBasket.Core;
using FruitBasket.Core.Interfaces;
using FruitBasket.Core.Models;
using FruitBasket.Services;

namespace FruitBasket.Controllers
{
	public class HomeController : Controller
	{
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

			var service = new ComputingService();
			// MOCK
			var players = GeneratePlayers();
			int realBasketWeight = new Models.FruitBasket().RealWeight;

			var result = service.RunThreads_test(players, realBasketWeight);

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