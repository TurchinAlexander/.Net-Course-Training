using System;
using System.Numerics;

namespace Sequences
{
	public static class Fibonacci
	{
		/// <summary>
		/// Get first numbers in Fibonacci's sequence.
		/// </summary>
		/// <param name="count">The count of Fibonacci's numbers.</param>
		/// <returns>Array of Fibonacci's numbers.</returns>
		public static BigInteger[] GetSequence(int count)
		{
			if (count <= 0) throw new ArgumentException($"{nameof(count)} cannot be negative or zero.");

			return CreateSequence(0, count - 1);
		}

		/// <summary>
		/// Get Fibonacci's sequence in current range.
		/// </summary>
		/// <param name="firstIndex">Start index of the element in Fibonacci's sequence.</param>
		/// <param name="lastIndex">Last index of the element in Fibonacci's sequence.</param>
		/// <returns>Array of Fibonacci's numbers.</returns>
		public static BigInteger[] GetSequence(int firstIndex, int lastIndex)
		{
			if (firstIndex < 0) throw new ArgumentException($"{nameof(firstIndex)} cannot be negative.");
			if (lastIndex < 0) throw new ArgumentException($"{nameof(lastIndex)} cannot be negative.");
			if (firstIndex > lastIndex) throw new ArgumentException($"{nameof(firstIndex)} cannot be greater than {nameof(lastIndex)}.");

			return CreateSequence(firstIndex, lastIndex);
		}

		private static BigInteger[] CreateSequence(int firstIndex, int lastIndex)
		{
			BigInteger[] sequence = new BigInteger[lastIndex - firstIndex + 1];
			BigInteger prev = 0, current = 1, next;
			int index = 0;

			for (int i = 0; i <= lastIndex; i++)
			{
				if (i >= firstIndex)
				{
					sequence[index++] = prev;
				}

				next = prev + current;
				prev = current;
				current = next;
			}

			return sequence;
		}
	}
}
