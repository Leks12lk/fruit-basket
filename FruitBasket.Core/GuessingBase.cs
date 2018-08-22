using System;
using System.Collections.Generic;
using System.Threading;
using FruitBasket.Core.Interfaces;
using FruitBasket.Core.Models;

namespace FruitBasket.Core
{
	public abstract class GuessingBase : IGuessing
	{
		public GuessResult Guess(int realBasketWeight, string playerName)
		{
			var result = new GuessResult
			{
				PlayerName = playerName,
				RealBasketWeight = realBasketWeight
			};

			HashSet<int> triedGuesses = new HashSet<int>();
			var closestDelta = 0;
			for (var i = 1; i <= 100; i++)
			{

				var guessWeight = GetGuessingWeight(i, triedGuesses);

				triedGuesses.Add(guessWeight);

				StoredGuess.AddGuessWeight(guessWeight);

				if (guessWeight == realBasketWeight)
				{
					result.TotalAttempts = i;
					result.IsWinner = true;
					return result;
				}
				var delta = Math.Abs(realBasketWeight - guessWeight);

				StoredGuess.AddDelta(playerName, guessWeight, delta);

				closestDelta = i == 1 ? delta : closestDelta;
				if (delta < closestDelta)
				{
					result.ClosestGuessWeight = guessWeight;
					closestDelta = delta;
				}
				
				Thread.Sleep(delta);
			}
			result.Delta = closestDelta;
			return result;
		}

		public abstract int GetGuessingWeight(int attemptNumber, HashSet<int> triedGuesses);
	}
}
