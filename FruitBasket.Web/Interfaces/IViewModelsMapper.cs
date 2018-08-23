using System.Collections.Generic;
using FruitBasket.Core.Models;
using FruitBasket.Web.ViewModels;

namespace FruitBasket.Web.Interfaces
{
	public interface IViewModelsMapper
	{
		List<Player> MapPlayersViewModelToPLayers(List<PlayerViewModel> playersVm);
		GuessResultViewModel MapResultToResultVm(GuessResult guessResult);
	}
}
