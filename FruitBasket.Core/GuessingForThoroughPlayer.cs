using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using FruitBasket.Core.Interfaces;
using FruitBasket.Core.Models;

namespace FruitBasket.Core
{
	public class GuessingForThoroughPlayer : GuessingBase
	{
		//public bool Guess(int realBasketWeight)
		//{
		//	while (true)
		//	{
		//		Debug.WriteLine(Thread.CurrentThread.Name);
				
		//		for (var i = 40; i <= 141; i++)
		//		{
		//			var guessWeight = i;

		//			StoredGuess.AddGuessWeight(guessWeight);

		//			if (guessWeight == realBasketWeight) return true;

		//			var delayTime = Math.Abs(realBasketWeight - guessWeight);
		//			Thread.Sleep(delayTime);
		//		}
		//	}
		//}

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
