using System;
using System.Collections.Generic;

namespace Sorts
{
	/// <summary>
	/// Represent the class, which contains Merge and Quick sort algorithms.
	/// </summary>
	public static class Sort<T> where T: IComparable<T>
	{
		/// <summary>
		/// Represent the merge sort.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <exception cref="ArgumentException">If the length of the array is zero.</exception>
		/// <exception cref="ArgumentNullException">If array is null</exception>
		public static void Merge(T[] array)
		{
			CheckConditions(array);
			MergeLogic(array, 0, array.Length - 1);
		}

		/// <summary>
		/// Represent the merge sort.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="left">The left bound of the array.</param>
		/// <param name="right">The right bound of the array.</param>
		/// <exception cref="ArgumentException">If the length of the array is zero.</exception>
		/// <exception cref="ArgumentNullException">If array is null</exception>
		public static void Merge(T[] array, int left, int right)
		{
			CheckConditions(array, left, right);
			MergeLogic(array, left, right);
		}

		/// <summary>
		/// Represent the Quick sort.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <exception cref="ArgumentException">If the length of the array is zero.</exception>
		/// <exception cref="ArgumentNullException">If array is null</exception>
		public static void Quick(T[] array)
		{
			CheckConditions(array);
			QuickLogic(array, 0, array.Length - 1);
		}

		/// <summary>
		/// Represent the Quick sort.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="left">The left bound of the array.</param>
		/// <param name="right">The right bound of the array.</param>
		/// <exception cref="ArgumentException">If the length of the array is zero.</exception>
		/// <exception cref="ArgumentNullException">If array is null</exception>
		public static void Quick(T[] array, int left, int right)
		{
			CheckConditions(array, left, right);
			QuickLogic(array, left, right);
		}

		/// <summary>
		/// Divide array to two little ones.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <param name="left">The left bound of the array.</param>
		/// <param name="right">The right bound of the array.</param>
		private static void MergeLogic(T[] array, int left, int right)
		{
			int middle = (left + right) / 2;

			if (left == right)
			{
				return;
			}

			MergeLogic(array, left, middle);
			MergeLogic(array, middle + 1, right);

			MergeLogic(array, left, middle, right);
		}

		/// <summary>
		/// Take two arrays in a sorted one. 
		/// </summary>
		/// <param name="array">Two logic arrays in one physic array.</param>
		/// <param name="left">The left bound of the first array.</param>
		/// <param name="middle">The right bound of the first array and the left bound of the second one.</param>
		/// <param name="right">The right bound of the second array.</param>
		private static void MergeLogic(T[] array, int left, int middle, int right)
		{
			int firstArray = left;
			int secondArray = middle + 1;
			T[] temp = new T[right - left + 1];
			int tempIndex = 0;

			while ((firstArray <= middle) && (secondArray <= right))
			{
				temp[tempIndex] = (array[firstArray].CompareTo(array[secondArray]) > 0)
					? array[secondArray++]
					: array[firstArray++];
				tempIndex++;
			}

			while (firstArray <= middle)
			{
				temp[tempIndex++] = array[firstArray++];
			}

			while (secondArray <= right)
			{
				temp[tempIndex++] = array[secondArray++];
			}

			for (int i = 0; i < temp.Length; i++)
			{
				array[left + i] = temp[i];
			}
		}

        /// <summary>
        /// Sort the array with Quick sort algorithm.
        /// </summary>
        /// <param name="arr">Input array.</param>
        /// <param name="left">The left bound of the array.</param>
        /// <param name="right">The right bound </param>
        private static void QuickLogic(T[] array, int left, int right)
        {
            int i = left, j = right;
            T x = array[(left + right) / 2];

            do
            {
                while (array[i].CompareTo(x) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(x) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
					Swap(ref array[i], ref array[j]);

                    i++;
                    j--;
                }
            }
            while (i < j);

            if (left < j)
            {
                Quick(array, left, j);
            }

            if (i < right)
            {
                Quick(array, i, right);
            }
        }

		/// <summary>
		/// Changes values between two arguments.
		/// </summary>
		/// <param name="value1">Argument 1.</param>
		/// <param name="value2">Argument 2.</param>
		private static void Swap(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		/// <summary>
		/// Check conditions of the input array.
		/// </summary>
		/// <param name="array">Input array.</param>
		/// <exception cref="ArgumentException">If the length of the array is zero.</exception>
		/// <exception cref="ArgumentNullException">If array is null</exception>
		private static void CheckConditions<T>(T[] array)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
			if (array.Length == 0) throw new ArgumentException(nameof(array));
        }

		/// <summary>
		/// Check conditions of the input array.
		/// </summary>
		/// <param name="array">The input array.</param>
		/// <param name="left">The left bound of the array.</param>
		/// <param name="right">The right bound of the array.</param>
		/// <exception cref="ArgumentException">If the length of the array is zero or the bound are invalid.</exception>
		/// <exception cref="ArgumentNullException">If array is null</exception>
		private static void CheckConditions(T[] array, int left, int right)
		{
			CheckConditions(array);

			if ((left < 0) || (right < 0) || (left > right)) throw new ArgumentException();
		}
    }
}
