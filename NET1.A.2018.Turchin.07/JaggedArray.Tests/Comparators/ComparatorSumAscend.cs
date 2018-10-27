using JaggedArray.Interfaces;

namespace JaggedArray.Tests.Comparators
{
	public class ComparatorSumAscend : ICompare
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

			int sum = 0;
			for (int i = 0; i < array.Length; i++)
			{
				sum += array[i];
			}

			return sum;
		}
	}
}
