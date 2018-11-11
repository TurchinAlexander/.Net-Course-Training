using System;
using System.Diagnostics;

namespace Algorithm
{
	/// <summary>
	/// Class to find gcd of values.
	/// </summary>
	public static class GCD
	{
		/// <summary>
		/// Pointer to gcd method of two values.
		/// </summary>
		/// <param name="a">First value.</param>
		/// <param name="b">Second value.</param>
		/// <returns>The greatest common divisor.</returns>
		private delegate int LogicGCD(int a, int b);

		/// <summary>
		/// Euclidean method for two parameters.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The greatest common divisor of two parameters.</returns>
		public static int Euclidean(int a, int b)
		{
			return LogicEuclidean(a, b);
		}

		/// <summary>
		/// Euclidean method for two parameters.
		/// </summary>
		/// <param name="timeMilliseconds">The execution time.</param>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The greatest common divisor of two parameters</returns>
		public static int Euclidean(out long timeMilliseconds, int a, int b)
		{
			Stopwatch watch = Stopwatch.StartNew();

			int result = LogicEuclidean(a, b);
			watch.Stop();
			timeMilliseconds = watch.ElapsedMilliseconds;

			return result;
		}

		/// <summary>
		/// Euclidean method for three parameters.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <param name="c">Third parameter.</param>
		/// <returns>The greatest common divisor of three parameters.</returns>
		public static int Euclidean(int a, int b, int c)
		{
			return LogicEuclidean (
				a,
				LogicEuclidean(b, c)
				);
		}

		/// <summary>
		/// Euclidean method for three parameters.
		/// </summary>
		/// <param name="timeMilliseconds">The execution time.</param>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <param name="c">Third parameter.</param>
		/// <returns>The greatest common divisor of three parameters.</returns>
		public static int Euclidean(out long timeMilliseconds, int a, int b, int c)
		{
			Stopwatch watch = Stopwatch.StartNew();

			int result = LogicEuclidean(
				a,
				LogicEuclidean(b, c)
				);

			watch.Stop();

			timeMilliseconds = watch.ElapsedMilliseconds;

			return result;
		}

		/// <summary>
		/// Represents the Euclidean algorithm to find GCD of values.
		/// </summary>
		/// <param name="array">The array of values.</param>
		/// <returns>The greatest common divisor.</returns>
		public static int Euclidean(params int[] array)
		{
			LogicGCD logic = new LogicGCD(LogicEuclidean);

			return HiddenGCD(array, logic);
		}

		/// <summary>
		/// Represents the Euclidean algorithm to find GCD of values.
		/// </summary>
		/// <param name="timeMilliseconds">The execution time.</param>
		/// <param name="array">The array of values.</param>
		/// <returns>The greatest common divisor.</returns>
		public static int Euclidean(out long timeMilliseconds, params int[] array)
		{
			Stopwatch watch = Stopwatch.StartNew();
			LogicGCD logic = new LogicGCD(LogicEuclidean);

			int result = HiddenGCD(array, logic);

			watch.Stop();

			timeMilliseconds = watch.ElapsedMilliseconds;

			return result;
		}

		/// <summary>
		/// Binary method for two parameters.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The greatest common divisor of two parameters.</returns>
		public static int Binary(int a, int b)
		{
			return LogicBinary(a, b);
		}

		/// <summary>
		/// Binary method for two parameters.
		/// </summary>
		/// <param name="timeMilliseconds">The execution time.</param>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <returns>The greatest common divisor of two parameters</returns>
		public static int Binary(out long timeMilliseconds, int a, int b)
		{
			Stopwatch watch = Stopwatch.StartNew();

			int result = LogicBinary(a, b);

			watch.Stop();

			timeMilliseconds = watch.ElapsedMilliseconds;

			return result;
		}

		/// <summary>
		/// Binary method for three parameters.
		/// </summary>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <param name="c">Third parameter.</param>
		/// <returns>The greatest common divisor of three parameters.</returns>
		public static int Binary(int a, int b, int c)
		{
			return LogicBinary(
				a,
				LogicBinary(b, c)
				);
		}

		/// <summary>
		/// Binary method for three parameters.
		/// </summary>
		/// <param name="timeMilliseconds">The execution time.</param>
		/// <param name="a">First parameter.</param>
		/// <param name="b">Second parameter.</param>
		/// <param name="c">Third parameter.</param>
		/// <returns>The greatest common divisor of three parameters.</returns>
		public static int Binary(out long timeMilliseconds, int a, int b, int c)
		{
			Stopwatch watch = Stopwatch.StartNew();

			int result = LogicBinary(
				a,
				LogicBinary(b, c)
				);

			watch.Stop();

			timeMilliseconds = watch.ElapsedMilliseconds;

			return result;
		}

		/// <summary>
		/// Represents the Binary algorithm to find GCD of values.
		/// </summary>
		/// <param name="array">The array of values.</param>
		/// <returns>The greatest common divisor.</returns>
		public static int Binary(params int[] array)
		{
			LogicGCD logic = new LogicGCD(LogicBinary);

			return HiddenGCD(array, logic);
		}

		/// <summary>
		/// Represents the Binary algorithm to find GCD of values.
		/// </summary>
		/// <param name="timeMilliseconds">The execution time.</param>
		/// <param name="array">The array of values.</param>
		/// <returns>The greatest common divisor.</returns>
		public static int Binary(out long timeMilliseconds, params int[] array)
		{
			Stopwatch watch = Stopwatch.StartNew();
			LogicGCD logic = new LogicGCD(LogicBinary);

			int result = HiddenGCD(array, logic);

			watch.Stop();

			timeMilliseconds = watch.ElapsedMilliseconds;

			return result;
		}

		/// <summary>
		/// Main method to calculate gcd.
		/// </summary>
		/// <param name="array">The array of values.</param>
		/// <param name="logic">Pointer to gcd method of two parameters.</param>
		/// <returns>The <see cref="int"/>.</returns>
		private static int HiddenGCD(int[] array, LogicGCD logic)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));

			if (array.Length == 0) throw new ArgumentException(nameof(array));

			int result = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				result = logic(result, array[i]);
			}

			return result;
		}

		/// <summary>
		/// Logic of Euclidean algorithm.
		/// </summary>
		/// <param name="a">First value.</param>
		/// <param name="b">Second value.</param>
		/// <returns>The greatest common divisor of <paramref name="a"/> and <paramref name="b"/>.</returns>
		private static int LogicEuclidean(int a, int b)
		{
			a = Math.Abs(a);
			b = Math.Abs(b);

			while ((a != b) && (a > 0) && (b > 0))
			{
				if (a > b)
				{
					a -= b;
				}
				else
				{
					b -= a;
				}
			}

			return (a > 0) ? a : b;
		}

		/// <summary>
		/// Logic of Binary algorithm.
		/// </summary>
		/// <param name="a">First value.</param>
		/// <param name="b">Second value.</param>
		/// <returns>The greatest common divisor of <paramref name="a"/> and <paramref name="b"/>.</returns>
		private static int LogicBinary(int a, int b)
		{
			a = Math.Abs(a);
			b = Math.Abs(b);

			int multiplier = 1;

			while ((a != b) && (a > 0) && (b > 0))
			{
				if ((~a & 1) == 1)
				{
					if ((b & 1) == 1)
					{
						a >>= 1;
					}
					else
					{
						a >>= 1;
						b >>= 1;
						multiplier <<= 1;
					}
				}
				else if ((~b & 1) == 1)
				{
					b >>= 1;
				}
				else if (a > b)
				{
					a = (a - b) >> 1;
				}
				else
				{
					b = (b - a) >> 1;
				}
			}

			return multiplier * ((a > 0) ? a : b);
		}
	}
}
