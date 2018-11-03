using JaggedArray.Interfaces;

namespace JaggedArray.Tests.Comparators
{
	public class ComparatorSumAscend : IComparer
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
			int sum = 0;
			for (int i = 0; i < array.Length; i++)
			{
				sum += array[i];
			}

			return sum;
		}
	}
}
