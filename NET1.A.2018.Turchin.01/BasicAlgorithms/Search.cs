using System;
using System.Collections.Generic;

namespace BasicAlgorithms
{
	public static class Search<T>
	{
		public static int Binary(T[] array, T value, IComparer<T> comparer)
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");
			if (array.Length == 0) throw new ArgumentException($"{nameof(array)} cannot be zero length.");

			int left = 0, right = array.Length - 1, mid;

			while (left <= right)
			{
				mid = (left + right) / 2;
				
				if (comparer.Compare(value, array[mid]) > 0)
				{
					left = mid + 1;
				} 
				else if (comparer.Compare(value, array[mid]) < 0)
				{
					right = mid - 1;
				} 
				else
				{
					return mid;
				}
			}

			return -1;
		}
	}
}
