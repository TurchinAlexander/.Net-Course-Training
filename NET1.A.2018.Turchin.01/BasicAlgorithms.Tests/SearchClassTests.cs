﻿using NUnit.Framework;

using BasicAlgorithms.Tests.Comparers;

namespace BasicAlgorithms.Tests
{
	[TestFixture]
	class SearchClassTests
	{
		static object[] RigthArray =
		{
			new object[] {3, new int[] {1, 2, 3, 4, 5}, 2},
			new object[] {-1, new int[] {-1, 0, 3, 5, 10}, 0},
			new object[] {105, new int[] {1, 2, 43, 64, 105}, 4},
		};

		[TestCaseSource("RigthArray")]
		public void SearchBinary_RigthArray_FindIndex(int value, int[] array, int expected)
		{
			int actual = Search<int>.Binary(array, value, new IntAscendComparer());

			Assert.AreEqual(expected, actual);
		}
	}
}
