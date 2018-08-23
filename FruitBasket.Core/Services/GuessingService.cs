using System.Collections.Generic;
using System.Linq;
using System.Threading;
using FruitBasket.Core.Models;
using FruitBasket.Core.ServicesInterfaces;

namespace FruitBasket.Core.Services
{
	public class GuessingService : IGuessingService
	{
		public GuessResult GetWinnerResult(List<Player> players, int realBasketWeight)
		{
			GuessResult winnerResult = new GuessResult();

			// create thread for each player in order to make guess in a concurrence way
			List<Thread> threads = players.Select(player => new Thread(() => { winnerResult = DoGuess(player, realBasketWeight); })
				{
					Name = $"Thread [{players.IndexOf(player)}]"
				})
				.ToList();

			// run just created threads
			foreach (Thread t in threads)
			{
				t.Start();
			}

			// join running threads with the main thread
			foreach (Thread t in threads)
			{
				t.Join();
			}

			// get the guess which was closest to the goal
			var closestWeight = StoredGuess.GetClosestWeight();

			// if we have the winner - return winner result object
			if (winnerResult.IsWinner) return winnerResult;

			// if there is no winner - get neccessary info to display about the most closest guess
			winnerResult.PlayerName = closestWeight.FirstOrDefault().Key;
			winnerResult.ClosestGuessWeight = closestWeight.FirstOrDefault().Value;

			return winnerResult;

		}
		
		private static GuessResult DoGuess(Player player, int realBasketWeight)
		{
			// this method of a Player class is formed by Strategy pattern 
			var winner = player.Guess(realBasketWeight);
			return winner;
		}
	}
}
