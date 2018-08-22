using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using FruitBasket.Core.Models;
using FruitBasket.Models;
using PlayerType1 = FruitBasket.Models.PlayerType1;

namespace FruitBasket.Services
{
	public class ComputingService
	{
		public string RunThreads(List<Player1> players, int realBasketWeight)
		{
			List<Thread> threads = new List<Thread>();

			var result = new Dictionary<string,bool>();
			var result1 = new HashSet<string>();
			var result2 = new TestClass();

			foreach (var player in players)
			{
				GuessingResult value = new GuessingResult();
				Thread thread = new Thread(() => { result2.SetWinner(MyFunction(player, realBasketWeight), player.Name); });
				thread.Name = $"Thread [{players.IndexOf(player)}]";
				//Thread thread = new Thread(() =>
				//{
				//	MyFunction(player, realBasketWeight) ? result1.Add(player.Name) : false;
				//});
				threads.Add(thread);
				//thread.Start();
				//thread.Join();
				//if (!value.IsSuccess) continue;
				//result = value;
				//break;
			}

			foreach (Thread t in threads)
			{
				t.Start();
			}

			foreach (Thread t in threads)
			{
				t.Join();
			}


			//foreach (var r in result)
			//{
			//	if (r.Value) return result;
			//}

			//if (result2.IsWinner)
			//{
			//	return new Dictionary<string, bool>
			//	{
			//		{result2.WinnerName, result2.IsWinner}
			//	};
			//}

			//double getadd = 0;
			//Thread2 ClsAdd = new Thread2();
			//Thread AddThread = new Thread(delegate ()
			//{
			//	getadd = ClsAdd.Add(lOpr1, lOpr2);
			//});
			//AddThread.Start();



			//for (int i = 0; i < 10; i++)
			//{
			//	//threads[i] = new Thread(new ThreadStart(mt.ThreadNumbers));
			//	threads[i].Name = string.Format("Работает поток: #{0}", i);
			//}

			return result2.WinnerName;
		}

		public bool MyFunction(Player1 player, int realBasketWeight)
		{
			//var result = new GuessingResult
			//{
			//	PlayerName = player.Name
			//};
			var isSuccess = false;
			switch (player.PlayerType)
			{
				case PlayerType1.Random:
					isSuccess = GuessForRandomPlayer(realBasketWeight);
					break;
				case PlayerType1.Memory:
					isSuccess = GuessForMemoryPlayer(realBasketWeight);
					break;
				case PlayerType1.Thorough:
					break;
				case PlayerType1.Cheater:
					break;
				case PlayerType1.ThoroughCheater:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			//result.IsSuccess = isSuccess;
			//return result;
			return isSuccess;
		}


		public string RunThreads_test(List<Player> players, int realBasketWeight)
		{
			List<Thread> threads = new List<Thread>();

			var result = new Dictionary<string, bool>();
			var result1 = new HashSet<string>();
			var result2 = new TestClass();
			string winnerName = null;

			foreach (var player in players)
			{
				GuessingResult value = new GuessingResult();
				//Thread thread = new Thread(() => { result2.SetWinner(MyFunction_test(player, realBasketWeight), player.Name); });
				Thread thread = new Thread(() => { winnerName = MyFunction_test(player, realBasketWeight); });
				thread.Name = $"Thread [{players.IndexOf(player)}]";
				//Thread thread = new Thread(() =>
				//{
				//	MyFunction(player, realBasketWeight) ? result1.Add(player.Name) : false;
				//});
				threads.Add(thread);
				//thread.Start();
				//thread.Join();
				//if (!value.IsSuccess) continue;
				//result = value;
				//break;
			}

			foreach (Thread t in threads)
			{
				t.Start();
			}

			foreach (Thread t in threads)
			{
				t.Join();
			}

			return winnerName;
		}
		public string MyFunction_test(Player player, int realBasketWeight)
		{
			var winnerName = player.Guess(realBasketWeight);
			return winnerName;
		}


		private bool GuessForRandomPlayer(int realBasketWeight)
		{
			
			while (true)
			{
				Debug.WriteLine(Thread.CurrentThread.Name);
				var guessWeight = new Random().Next(40, 140);
				if (guessWeight == realBasketWeight) return true;
				var delayTime = Math.Abs(realBasketWeight - guessWeight);
				Thread.Sleep(delayTime);
			}
		}

		private bool GuessForMemoryPlayer(int realBasketWeight)
		{
			
			HashSet<int> triedGuesses = new HashSet<int>();
			while (true)
			{
				Debug.WriteLine(Thread.CurrentThread.Name);
				var guessWeight = new Random().Next(40, 140);
				guessWeight = triedGuesses.Contains(guessWeight) ? new Random().Next(40, 140) : guessWeight;
				if (guessWeight == realBasketWeight) return true;
				var delayTime = Math.Abs(realBasketWeight - guessWeight);
				triedGuesses.Add(guessWeight);
				Thread.Sleep(delayTime);
			}
		}
		private bool GuessForThoroughPlayer()
		{
			return false;
		}
		private bool GuessForCheaterPlayer()
		{
			return false;
		}
		private bool GuessForThoroughCheaterPlayer()
		{
			return false;
		}
	}


	public class GuessingResult
	{
		public string PlayerName { get; set; }
		public bool IsSuccess { get; set; }
	}

	public class TestClass
	{
		public string WinnerName { get; set; }
		public bool IsWinner { get; set; }
		private static object _lockObject = new object();

		public void SetWinner(bool isWunner, string winnerName)
		{
			lock (_lockObject)
			{
				IsWinner = true;
				WinnerName = winnerName;
			}
		}
	}
}