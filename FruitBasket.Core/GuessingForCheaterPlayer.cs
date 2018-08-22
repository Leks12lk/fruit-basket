﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using FruitBasket.Core.Models;

namespace FruitBasket.Core
{
	public class GuessingForCheaterPlayer : GuessingBase
	{
		//public bool Guess(int realBasketWeight)
		//{
		//	while (true)
		//	{
		//		Debug.WriteLine(Thread.CurrentThread.Name);
		//		var guessWeight = new Random().Next(40, 140);
		//		guessWeight = StoredGuess.Contains(guessWeight) ? new Random().Next(40, 140) : guessWeight;

		//		StoredGuess.AddGuessWeight(guessWeight);

		//		if (guessWeight == realBasketWeight) return true;
		//		var delayTime = Math.Abs(realBasketWeight - guessWeight);
		//		Thread.Sleep(delayTime);
		//	}
		//}

		public override int GetGuessingWeight(int attemptNumber, HashSet<int> triedGuesses)
		{
			Debug.WriteLine(Thread.CurrentThread.Name);
			var guessWeight = new Random().Next(40, 140);
			guessWeight = StoredGuess.Contains(guessWeight) ? new Random().Next(40, 140) : guessWeight;

			return guessWeight;
		}
	}
}
