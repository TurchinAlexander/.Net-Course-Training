using System;

namespace Algorithm.Tests.Filters
{
	public static class IntFilter
	{
		public static bool Even(int number)
		{
			return (number % 2 == 0);
		}

		public static bool Negative(int number)
		{
			return (number < 0);
		}

		public static bool Prime(int number)
		{
			if (number < 2)
				return false;

			int root = (int)Math.Sqrt(number);

			for (int i = 2; i <= root; i++)
			{
				if (number % i == 0)
					return false;
			}

			return true;
		}
	}
}
