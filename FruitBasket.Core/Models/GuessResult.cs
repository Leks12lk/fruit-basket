namespace FruitBasket.Core.Models
{
	public class GuessResult
	{
		public bool IsWinner { get; set; }
		public int TotalAttempts { get; set; }
		public int Delta { get; set; }
		public string PlayerName { get; set; }
		public int ClosestGuessWeight { get; set; }
		public int RealBasketWeight { get; set; }
	}
}
