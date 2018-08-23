using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using FruitBasket.Core.Models;

namespace FruitBasket.Core
{
	public class GuessingForThoroughCheaterPlayer : GuessingBase
	{
		public override int GetGuessingWeight(int attemptNumber, HashSet<int> triedGuesses)
		{
			Debug.WriteLine(Thread.CurrentThread.Name);
			const int startNum = 40;
			var currentNum = startNum + attemptNumber;
			var guessWeight = currentNum <= 140 && currentNum > startNum ? currentNum : startNum + attemptNumber;

			guessWeight = StoredGuess.Contains(guessWeight) ? currentNum + 1 : guessWeight;

			return guessWeight;
		}
	}
}
