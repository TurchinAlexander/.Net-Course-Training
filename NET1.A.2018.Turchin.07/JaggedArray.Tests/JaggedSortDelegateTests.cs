using NUnit.Framework;
using JaggedArray.Tests.Comparators;

namespace JaggedArray.Tests
{
	[TestFixture]
	class JaggedSortDelegateTests
	{
		[Test]
		public void ExecuteMethodWithDelegate_ArrayWithNullElements_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] { 1, 2, 3 },
				null,
				new int[] {5, 6, 7 }
			};

			int[][] expected = new int[][]
			{
				null,
				new int[] { 1, 2, 3 },
				new int[] { 5, 6, 7 }
			};

			ComparatorSumAscend comparator = new ComparatorSumAscend();

			JaggedSort.Execute(array, comparator.Compare);

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethodWithDelegate_ArrayWithEmptyElements_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] { 1, 2, 3 },
				new int[] { },
				new int[] { 5, 6, 7 }
			};

			int[][] expected = new int[][]
			{
				new int[] { 5, 6, 7 },
				new int[] { 1, 2, 3 },
				new int[] { }
			};

			ComparatorSumDescend comparator = new ComparatorSumDescend();

			JaggedSort.Execute(array, comparator.Compare);

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethodWithDelegate_ArraySortByMinValueAndDescending_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] {11, -2, 3},
				new int[] {5, 6, 7},
				new int[] {0, -1, 2}
			};

			int[][] expected = new int[][]
			{
				new int[] {5, 6, 7},
				new int[] {0, -1, 2},
				new int[] {11, -2, 3}

			};

			ComparatorMinValueDescend comparator = new ComparatorMinValueDescend();

			JaggedSort.Execute(array, comparator.Compare);

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		private bool CheckJaggedArrays(int[][] expected, int[][] actual)
		{
			bool isEqual = true;

			for (int i = 0; (i < expected.Length) && isEqual; i++)
			{
				int arrayLength = (expected[i] == null) ? 0 : expected[i].Length;
				for (int j = 0; (j < arrayLength) && isEqual; j++)
				{
					isEqual = (expected[i][j] == actual[i][j]);
				}
			}
			return isEqual;
		}
	}
}
