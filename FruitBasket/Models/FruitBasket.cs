using System;

namespace FruitBasket.Models
{
	public class FruitBasket
	{
		public int MinWeight => 40;
		public int MaxWeight => 140;

		public int RealWeight => new Random().Next(MinWeight, MaxWeight);
	}
}