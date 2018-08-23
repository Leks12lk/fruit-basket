using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace FruitBasket.Web.ViewModels
{
	
	public class GuessResultViewModel
	{
		[JsonProperty("isWinner")]
		public bool IsWinner { get; set; }

		[JsonProperty("totalAttempts")]
		public int TotalAttempts { get; set; }

	
		public int Delta { get; set; }

		
		public string PlayerName { get; set; }

		
		public int ClosestGuessWeight { get; set; }

		
		public int RealBasketWeight { get; set; }
	}
}