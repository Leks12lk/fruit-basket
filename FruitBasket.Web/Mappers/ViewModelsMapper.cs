using System;
using System.Collections.Generic;
using FruitBasket.Core.Interfaces;
using FruitBasket.Core.Models;
using FruitBasket.Web.Interfaces;
using FruitBasket.Web.ViewModels;
using StructureMap;

namespace FruitBasket.Web.Mappers
{
	public class ViewModelsMapper : IViewModelsMapper
	{
		private readonly IContainer _container;
		public ViewModelsMapper(IContainer container)
		{
			_container = container;

		}
		public List<Player> MapPlayersViewModelToPLayers(List<PlayerViewModel> playersVm)
		{
			var players = new List<Player>();

			foreach (var pl in playersVm)
			{
				var name = pl.Name;
				PlayerType playerType;
				playerType = Enum.TryParse(pl.Type, out playerType) ? playerType : PlayerType.Random;

				// define concrete of IGuessing with StructureMap IoC (depends on PlayerType)
				var guessing = _container.GetInstance<IGuessing>(playerType.ToString());
				var player = new Player(name, playerType, guessing);

				players.Add(player);
			}

			return players;
		}

		public GuessResultViewModel MapResultToResultVm(GuessResult guessResult)
		{
			return new GuessResultViewModel
			{
				IsWinner = guessResult.IsWinner,
				TotalAttempts = guessResult.TotalAttempts,
				Delta = guessResult.Delta,
				PlayerName = guessResult.PlayerName,
				ClosestGuessWeight = guessResult.ClosestGuessWeight,
				RealBasketWeight = guessResult.RealBasketWeight
			};
		}
	}
}