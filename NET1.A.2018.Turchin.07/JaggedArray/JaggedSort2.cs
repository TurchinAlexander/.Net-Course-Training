using System;
using JaggedArray.Interfaces;
using JaggedArray.Adapters;
using JaggedArray.Delegates;

namespace JaggedArray
{
	/// <summary>
	/// Represent sort for jagged array.
	/// </summary>
    public static class JaggedSort2
    {
		/// <summary>
		/// Sort the jagged array.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="comparator">Compare our element in the array.</param>
		public static void Execute(int[][] array, IComparer comparator)
		{ 
			SortJaggedArray(array, comparator.Compare);
		}

		/// <summary>
		/// Sort the jagged array.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="delegateComparer">The delegate, which contain method to compare.</param>
		public static void Execute(int[][] array, DelegateType.Comparer delegateComparer)
		{
			SortJaggedArray(array, delegateComparer);
		}

		/// <summary>
		/// Sort jagged array due condition.
		/// </summary>
		/// <param name="keyValues">Key values of jagged array.</param>
		/// <param name="array">Jagged array.</param>
		/// <param name="comparator">Compare our element in the array.</param>
		private static void SortJaggedArray(int[][] array, DelegateType.Comparer comparator)
		{
			for (int i = 0; i < array.Length - 1; i++)
			{
				for (int j = 0; j < array.Length - i - 1; j++)
				{
					if (comparator(array[j], array[j + 1]) > 0)
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
