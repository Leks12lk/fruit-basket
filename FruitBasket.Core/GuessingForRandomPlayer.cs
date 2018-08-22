using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FruitBasket.Core
{
	public class GuessingForRandomPlayer : GuessingBase
	{
		public override int GetGuessingWeight(int attemptNumber, HashSet<int> triedGuesses)
		{
			Debug.WriteLine(Thread.CurrentThread.Name);
			var guessWeight = new Random().Next(40, 140);
			return guessWeight;
		}
		
	}
}
