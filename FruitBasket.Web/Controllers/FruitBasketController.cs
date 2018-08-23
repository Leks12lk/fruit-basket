using System.Web.Mvc;
using FruitBasket.Core.ServicesInterfaces;
using FruitBasket.Web.Interfaces;
using FruitBasket.Web.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FruitBasket.Web.Controllers
{
	public class FruitBasketController : Controller
	{
		private readonly IGuessingService _guessingService;
		private readonly IViewModelsMapper _viewModelsMapper;
		public FruitBasketController(
			  IGuessingService guessingService
			, IViewModelsMapper viewModelsMapper
			)
		{
			_guessingService = guessingService;
			_viewModelsMapper = viewModelsMapper;
		}
		// Endpoint for Angular client app
		public ActionResult Index()
		{
			return View();
		}

		// Action toload index.html of Angular client app
		[ChildActionOnly]
		public virtual ActionResult GetHtmlPage(string path)
		{
			return new FilePathResult(path, "text/html");
		}

		[HttpGet]
		public JsonResult GetRealBasketWeight()
		{
			int realBasketWeight = new Core.Models.FruitBasket().RealWeight;
			return Json(realBasketWeight, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult StartGame(StartingGameViewModel model)
		{
			var domainPlayers = _viewModelsMapper.MapPlayersViewModelToPLayers(model.Players);
			var guess = _guessingService.GetWinnerResult(domainPlayers, model.RealBasketWeight);
			var result = _viewModelsMapper.MapResultToResultVm(guess);

			var settings = new JsonSerializerSettings
			{
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};

			var json = JsonConvert.SerializeObject(result, settings);
			return Json(json);
		}

		
	}
}
