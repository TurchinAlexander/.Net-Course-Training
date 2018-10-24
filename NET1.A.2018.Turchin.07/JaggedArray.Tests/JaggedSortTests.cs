using System;
using NUnit.Framework;
using JaggedArray;

namespace JaggedArray.Tests
{
	[TestFixture]
    public class JaggedSortTests
    {
		[Test]
		public void ExecuteMethod_NullArray_ReturnArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => JaggedSort.Execute(null, JaggedSort.CompareBy.Sum, JaggedSort.TypeSort.Ascending));
		}

		[Test]
		public void ExecuteMethod_EmptyArray_ReturnArgumentException()
		{
			Assert.Throws<ArgumentException>(() => JaggedSort.Execute(new int[][] { }, JaggedSort.CompareBy.Sum, JaggedSort.TypeSort.Ascending));
		}

		[Test]
		public void ExecuteMethod_ArrayWithNullElements_ReturnArgumentNullException()
		{
			int[][] array = new int[][]
			{
				new int[] { 1, 2, 3 },
				null,
				new int[] {5, 6, 7 }
			};

			Assert.Throws<ArgumentNullException>(() => JaggedSort.Execute(array, JaggedSort.CompareBy.Sum, JaggedSort.TypeSort.Ascending));
		}

		[Test]
		public void ExecuteMethod_ArrayWithEmptyElements_ReturnArgumentException()
		{
			int[][] array = new int[][]
			{
				new int[] { 1, 2, 3 },
				new int[] { },
				new int[] {5, 6, 7 }
			};

			Assert.Throws<ArgumentException>(() => JaggedSort.Execute(array, JaggedSort.CompareBy.Sum, JaggedSort.TypeSort.Ascending));
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

			JaggedSort.Execute(array, JaggedSort.CompareBy.Sum, JaggedSort.TypeSort.Ascending);

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

			JaggedSort.Execute(array, JaggedSort.CompareBy.Sum, JaggedSort.TypeSort.Descending);

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

			JaggedSort.Execute(array, JaggedSort.CompareBy.MaxValue, JaggedSort.TypeSort.Ascending);

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

			JaggedSort.Execute(array, JaggedSort.CompareBy.MaxValue, JaggedSort.TypeSort.Descending);

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

			JaggedSort.Execute(array, JaggedSort.CompareBy.MinValue, JaggedSort.TypeSort.Ascending);

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

			JaggedSort.Execute(array, JaggedSort.CompareBy.MinValue, JaggedSort.TypeSort.Descending);

			Assert.IsTrue(CheckJaggedArrays(expected, array));
		}

		private bool CheckJaggedArrays(int[][] expected, int[][] actual)
		{
			bool isEqual = true;

			for (int i = 0; (i < expected.Length) && isEqual; i++) 
				for (int j = 0; (j < expected[i].Length) && isEqual; j++)
				{
					isEqual = (expected[i][j] == actual[i][j]);
				}

			return isEqual;
		}
	}
}
