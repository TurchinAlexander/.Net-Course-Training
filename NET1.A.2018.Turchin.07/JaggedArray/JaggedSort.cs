using System;
using JaggedArray.Interfaces;

namespace JaggedArray
{
	/// <summary>
	/// Represent sort for jagged array.
	/// </summary>
    public static class JaggedSort
    {
		/// <summary>
		/// Sort jagged array.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="comparator">Compare our element in the array.</param>
		public static void Execute(int[][] array, IComparer comparator)
		{ 
			SortJaggedArray(array, comparator);
		}

		/// <summary>
		/// Sort jagged array due condition.
		/// </summary>
		/// <param name="keyValues">Key values of jagged array.</param>
		/// <param name="array">Jagged array.</param>
		/// <param name="comparator">Compare our element in the array.</param>
		private static void SortJaggedArray(int[][] array, IComparer comparator)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - i - 1; j++)
				{
					if (comparator.Compare(array[j], array[j + 1]) > 0)
					{
						Swap(ref array[j], ref array[j + 1]);
					}
				}
			}
		}

		/// <summary>
		/// Swap values between themselves.
		/// </summary>
		/// <typeparam name="T">Type of elements.</typeparam>
		/// <param name="a">First value.</param>
		/// <param name="b">Second value.</param>
		private static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}
    }
}
