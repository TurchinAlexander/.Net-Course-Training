using JaggedArray.Interfaces;

namespace JaggedArray.Tests.Comparators
{
	public class ComparatorMinValueAscend : ICompare
	{
		public bool Compare(int a, int b)
		{
			return (a > b);
		}

		public int KeyValue(int[] array)
		{
			if ((array == null) || (array.Length == 0))
			{
				return int.MinValue;
			}

			int min = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (min > array[i])
				{
					min = array[i];
				}
			}

			return min;
		}
	}
}
