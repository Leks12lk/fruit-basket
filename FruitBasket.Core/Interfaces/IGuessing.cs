using FruitBasket.Core.Models;

namespace FruitBasket.Core.Interfaces
{
	public interface IGuessing
	{
		GuessResult Guess(int realBasketWeight, string playerName);
	}
}
