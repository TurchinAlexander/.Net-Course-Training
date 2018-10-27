using System;
using JaggedArray.Interfaces;


namespace JaggedArray
{
    public static class JaggedSort
    {
		/// <summary>
		/// Sort jagged array.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="compare">What we sort by.</param>
		/// <param name="typeSort">Type of sort.</param>
		public static void Execute(int[][] array, ICompare comparator)
		{ 
			int[] keyValues = new int[array.Length];

			FindKeyValues(keyValues, array, comparator);
			SortJaggedArray(keyValues, array, comparator);
		}

		/// <summary>
		/// Sort jagged array due condition.
		/// </summary>
		/// <param name="keyValues">Key values of jagged array.</param>
		/// <param name="array">Jagged array.</param>
		/// <param name="typeSort">The condition.</param>
		private static void SortJaggedArray(int[] keyValues, int[][] array, ICompare comparator)
		{
			for (int i = 0; i < keyValues.Length - 1; i++)
				for (int j = 0; j < keyValues.Length - i - 1; j++)
				{
					if (comparator.Compare(keyValues[j], keyValues[j + 1]))
					{
						Swap(ref keyValues[j], ref keyValues[j + 1]);
						Swap(ref array[j], ref array[j + 1]);
					}
				}
		}

		/// <summary>
		/// Swap values between themselfs.
		/// </summary>
		/// <param name="a">First value.</param>
		/// <param name="b">Second value.</param>
		private static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		public static void FindKeyValues(int[] keyValues, int[][] array, ICompare comparator)
		{
			for (int i = 0; i < keyValues.Length; i++)
			{
				keyValues[i] = comparator.KeyValue(array[i]);
			}
		}
    }
}
