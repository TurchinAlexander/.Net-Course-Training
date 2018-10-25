using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaggedArray
{
    public static class JaggedSort
    {
		/// <summary>
		/// What we should sort by.
		/// </summary>
		public enum CompareBy
		{
			Sum = 1,
			MinValue = 2,
			MaxValue = 3
		};

		/// <summary>
		/// How we should sort.
		/// </summary>
		public enum TypeSort
		{
			Ascending = 1,
			Descending = 2
		}

		/// <summary>
		/// Sort jagged array.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="compare">What we sort by.</param>
		/// <param name="typeSort">Type of sort.</param>
		/// <exception cref="ArgumentNullException">If array or one of the elements of subarray is null.</exception>
		/// <exception cref="ArithmeticException">If array or one of the elements of subarray has zero length.</exception>
		public static void Execute(int[][] array, CompareBy compare, TypeSort typeSort)
		{
			CheckArguments(array);

			int[] keyValues = new int[array.Length];

			FindKeyValues(keyValues, array, compare);
			SortJaggedArray(keyValues, array, typeSort);
		}

		/// <summary>
		/// Sort jagged array due condition.
		/// </summary>
		/// <param name="keyValues">Key values of jagged array.</param>
		/// <param name="array">Jagged array.</param>
		/// <param name="typeSort">The condition.</param>
		private static void SortJaggedArray(int[] keyValues, int[][] array, TypeSort typeSort)
		{
			for (int i = 0; i < keyValues.Length - 1; i++)
				for (int j = 0; j < keyValues.Length - i - 1; j++)
				{
					if (Compare(keyValues[j], keyValues[j + 1], typeSort))
					{
						Swap(ref keyValues[j], ref keyValues[j + 1]);
						Swap(ref array[j], ref array[j + 1]);
					}
				}
		}

		/// <summary>
		/// Compare two arguments.
		/// </summary>
		/// <param name="a">First argument.</param>
		/// <param name="b">Second argument.</param>
		/// <param name="typeSort">How we should compare.</param>
		/// <returns></returns>
		private static bool Compare(int a, int b, TypeSort typeSort)
		{
			bool shouldSwap = false;

			if (typeSort == TypeSort.Ascending)
			{
				shouldSwap = (a > b);
			} else if (typeSort == TypeSort.Descending)
			{
				shouldSwap = (a < b);
			}

			return shouldSwap;
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

		/// <summary>
		/// Check input arguments for valid.
		/// </summary>
		/// <param name="array">Array to check.</param>
		/// <exception cref="ArgumentNullException">If array or one of the elements of subarray is null.</exception>
		/// <exception cref="ArithmeticException">If array or one of the elements of subarray has zero length.</exception>
		private static void CheckArguments(int[][] array)
		{
			if (array == null) throw new ArgumentNullException(nameof(array));
			if (array.Length == 0) throw new ArgumentException(nameof(array));

			foreach (int[] element in array)
			{
				if (element == null) throw new ArgumentNullException(nameof(array));
				if (element.Length == 0) throw new ArgumentException(nameof(array));
			}
		}

		/// <summary>
		/// Find key values which what we will sort our jagged array.
		/// </summary>
		/// <param name="keyValues">Array of key values.</param>
		/// <param name="array">Array from what we will take keyValues.</param>
		/// <param name="compare">What we sort by.</param>
		private static void FindKeyValues(int[] keyValues, int[][] array, CompareBy compare)
		{
			for (int i = 0; i < keyValues.Length; i++)
			{
				switch (compare)
				{
					case CompareBy.Sum:
						keyValues[i] = array[i].Sum();
						break;

					case CompareBy.MaxValue:
						keyValues[i] = array[i].Max();
						break;

					case CompareBy.MinValue:
						keyValues[i] = array[i].Min();
						break;
				}
			}
		}
    }
}
