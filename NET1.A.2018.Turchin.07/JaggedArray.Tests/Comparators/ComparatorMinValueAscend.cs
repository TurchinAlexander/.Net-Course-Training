using JaggedArray.Interfaces;

namespace JaggedArray.Tests.Comparators
{
	public class ComparatorMinValueAscend : IComparer
	{
		public int Compare(int[] a, int[] b)
		{
			if (((a == null) || (a.Length == 0)) && ((b == null) || (b.Length == 0)))
				return 0;

			if ((a == null) || (a.Length == 0))
				return -1;

			if ((b == null) || (b.Length == 0))
				return 1;

			return KeyValue(a) - KeyValue(b);
		}

		private int KeyValue(int[] array)
		{ 
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
