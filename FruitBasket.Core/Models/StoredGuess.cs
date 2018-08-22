using System;
using System.Collections.Generic;
using System.Linq;

namespace FruitBasket.Core.Models
{
	internal static class StoredGuess
	{
		private static readonly object Lock = new object();
		private static readonly object AnotherLock = new object();

		internal static HashSet<int> TriedGuessesWeight = new HashSet<int>();
		internal static List<TestClass> PlayersGuesses = new List<TestClass>();
		internal static void AddGuessWeight(int guessWeight)
		{
			lock (Lock)
			{
				if (!TriedGuessesWeight.Contains(guessWeight))
				{
					TriedGuessesWeight.Add(guessWeight);
				}
			}
		}

		internal static void AddDelta(string playerName, int guessWeight, int delta)
		{
			lock (Lock)
			{
				PlayersGuesses.Add(new TestClass
				{
					PlayerName = playerName,
					GuessWeight = guessWeight,
					Delta = delta,
					AttemptTime = DateTime.Now
				});
			}
		}

		internal static bool Contains(int guessWeight)
		{
			lock (AnotherLock)
			{
				return TriedGuessesWeight.Contains(guessWeight);
			}
		}

		internal static Dictionary<string, int> GetClosestWeight()
		{
			lock (AnotherLock)
			{
				var result = new Dictionary<string, int>();
				var min = PlayersGuesses.Min(x => x.Delta);
				var count = PlayersGuesses.Count(x => x.Delta == min);

				var firstOrDefault = count == 1 
					? PlayersGuesses.FirstOrDefault(x => x.Delta == min) 
					: PlayersGuesses.Where(x => x.Delta == min).OrderBy(x => x.AttemptTime).FirstOrDefault();

				if (firstOrDefault != null)
					result.Add(firstOrDefault.PlayerName, firstOrDefault.GuessWeight);

				return result;
			}
		}
	}


	internal class TestClass
	{
		public string PlayerName { get; set; }
		public int Delta { get; set; }
		public int GuessWeight { get; set; }
		public DateTime AttemptTime { get; set; }
	}
}
