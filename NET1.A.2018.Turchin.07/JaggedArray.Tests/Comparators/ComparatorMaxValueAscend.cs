using JaggedArray.Interfaces;

namespace JaggedArray.Tests.Comparators
{
	public class ComparatorMaxValueAscend : ICompare
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

			int max = array[0];
			for (int i = 1; i < array.Length; i++)
			{
				if (max < array[i])
				{
					max = array[i];
				}
			}

			return max;
		}
	}
}
