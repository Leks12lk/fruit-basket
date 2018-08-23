using FruitBasket.Core.Interfaces;

namespace FruitBasket.Core.Models
{
	public class Player
	{
		// for different player types will be different implementation
		private readonly IGuessing _guessing;

		public Player(string name, PlayerType type, IGuessing guessing)
		{
			Name = name;
			PlayerType = type;
			_guessing = guessing;
		}

		public string Name { get; set; }
		public PlayerType PlayerType { get; set; }

		public GuessResult Guess(int realBasketWeight)
		{
			return _guessing.Guess(realBasketWeight, Name);
		}

	}
}
