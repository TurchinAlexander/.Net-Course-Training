using System;
using NUnit.Framework;
using JaggedArray.Tests.Comparators;

namespace JaggedArray.Tests
{
	[TestFixture]
    public class JaggedSortTests
    {
		[Test]
		public void ExecuteMethod_ArrayWithNullElements_ReturnSortedArray()
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

			JaggedSort.Execute(array, new ComparatorSumAscend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArrayWithEmptyElements_ReturnSortedArray()
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

			JaggedSort.Execute(array, new ComparatorSumDescend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArrayWithNullAndEmptyElements_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] { 1, 2, 3 },
				new int[] { },
				null,
				new int[] { 5, 6, 7 }
			};

			int[][] expected = new int[][]
			{
				new int[] { 5, 6, 7 },
				new int[] { 1, 2, 3 },
				new int[] { },
				null
			};

			JaggedSort.Execute(array, new ComparatorSumDescend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArraySortBySumAndAscending_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] {1, 2, 3},
				new int[] {5, 6, 7},
				new int[] {0, 1, 2}
			};

			int[][] expected = new int[][]
			{
				new int[] {0, 1, 2},
				new int[] {1, 2, 3},
				new int[] {5, 6, 7}
			};

			JaggedSort.Execute(array, new ComparatorSumAscend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArraySortBySumAndDescending_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] {1, 2, 3},
				new int[] {5, 6, 7},
				new int[] {0, 1, 2}
			};

			int[][] expected = new int[][]
			{
				new int[] {5, 6, 7},
				new int[] {1, 2, 3},
				new int[] {0, 1, 2}
			};

			JaggedSort.Execute(array, new ComparatorSumDescend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArraySortByMaxValueAndAscending_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] {1, 2, 10},
				new int[] {5, 6, 7},
				new int[] {0, 1, 2}
			};

			int[][] expected = new int[][]
			{
				new int[] {0, 1, 2},
				new int[] {5, 6, 7},
				new int[] {1, 2, 10}
			};

			JaggedSort.Execute(array, new ComparatorMaxValueAscend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArraySortByMaxValueAndDescending_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] {1, 2, 3},
				new int[] {5, 6, 7},
				new int[] {0, 1, 2}
			};

			int[][] expected = new int[][]
			{
				new int[] {5, 6, 7},
				new int[] {1, 2, 3},
				new int[] {0, 1, 2}
			};

			JaggedSort.Execute(array, new ComparatorMaxValueDescend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArraySortByMinValueAndAscending_ReturnSortedArray()
		{
			int[][] array = new int[][]
			{
				new int[] {11, -2, 3},
				new int[] {5, 6, 7},
				new int[] {0, -1, 2}
			};

			int[][] expected = new int[][]
			{
				new int[] {11, -2, 3},
				new int[] {0, -1, 2},
				new int[] {5, 6, 7}
			};

			JaggedSort.Execute(array, new ComparatorMinValueAscend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		[Test]
		public void ExecuteMethod_ArraySortByMinValueAndDescending_ReturnSortedArray()
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

			JaggedSort.Execute(array, new ComparatorMinValueDescend());

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		private bool CheckJaggedArrays(int[][] expected, int[][] actual)
		{
			bool isEqual = true;

			for (int i = 0; (i < expected.Length) && isEqual; i++)
			{
				int arrayLength = (expected[i] == null)? 0 : expected[i].Length;
				for (int j = 0; (j < arrayLength) && isEqual; j++)
				{
					isEqual = (expected[i][j] == actual[i][j]);
				}
			}
			return isEqual;
		}
	}
}
