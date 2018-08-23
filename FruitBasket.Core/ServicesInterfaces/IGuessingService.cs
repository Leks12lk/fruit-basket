using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitBasket.Core.Models;

namespace FruitBasket.Core.ServicesInterfaces
{
	public interface IGuessingService
	{
		GuessResult GetWinnerResult(List<Player> players, int realBasketWeight);
	}
}
