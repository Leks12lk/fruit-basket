using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace FruitBasket.Core
{
	public class GuessingForThoroughPlayer : GuessingBase
	{
		public override int GetGuessingWeight(int attemptNumber, HashSet<int> triedGuesses)
		{
			Debug.WriteLine(Thread.CurrentThread.Name);
			const int startNum = 40;
			var currentNum = startNum + attemptNumber;
			var guessWeight = currentNum <= 140 && currentNum > startNum ? currentNum : startNum + attemptNumber;

			return guessWeight;
		}
	}
}
