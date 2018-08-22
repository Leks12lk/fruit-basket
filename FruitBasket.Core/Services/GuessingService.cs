using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FruitBasket.Core.Models;
using FruitBasket.Core.ServicesInterfaces;

namespace FruitBasket.Core.Services
{
	public class GuessingService : IGuessingService
	{
		public GuessResult GetWinnerName(List<Player> players, int realBasketWeight)
		{
			List<Thread> threads = new List<Thread>();
			GuessResult winnerResult = new GuessResult();

			foreach (var player in players)
			{
				Thread thread =
					new Thread(() => { winnerResult = DoGuess(player, realBasketWeight); })
					{
						Name = $"Thread [{players.IndexOf(player)}]"
					};
				threads.Add(thread);
			}

			foreach (Thread t in threads)
			{
				t.Start();
			}

			foreach (Thread t in threads)
			{
				t.Join();
			}

			var closestWeight = StoredGuess.GetClosestWeight();
			if (!winnerResult.IsWinner)
			{
				winnerResult.PlayerName = closestWeight.FirstOrDefault().Key;
				winnerResult.ClosestGuessWeight = closestWeight.FirstOrDefault().Value;
			}

			return winnerResult;

		}

		private static GuessResult DoGuess(Player player, int realBasketWeight)
		{
			var winner = player.Guess(realBasketWeight);
			return winner;
		}
	}
}
