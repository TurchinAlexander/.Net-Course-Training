using System;
using System.Collections.Generic;


namespace Sorts
{
	public static class Search
	{
		public static int Binary<T>(T[] array, T value) where T: IComparable<T>
		{
			if (array == null) throw new ArgumentNullException($"{nameof(array)} cannot be null.");
			if (array.Length == 0) throw new ArgumentException($"{nameof(array)} cannot be zero length.");

			int left = 0, right = array.Length - 1, mid;

			while (left <= right)
			{
				mid = (left + right) / 2;
				
				if (value.CompareTo(array[mid]) > 0)
				{
					left = mid + 1;
				} 
				else if (value.CompareTo(array[mid]) < 0)
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
