using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FruitBasket.Core
{
	public class GuessingForMemoryPlayer : GuessingBase
	{
		public override int GetGuessingWeight(int attemptNumber, HashSet<int> triedGuesses)
		{
			Debug.WriteLine(Thread.CurrentThread.Name);
			var guessWeight = new Random().Next(40, 140);
			guessWeight = triedGuesses.Contains(guessWeight) ? new Random().Next(40, 140) : guessWeight;

			return guessWeight;
		}
	}
}
