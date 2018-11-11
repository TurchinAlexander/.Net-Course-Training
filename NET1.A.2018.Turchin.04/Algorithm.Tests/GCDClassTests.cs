using System;
using NUnit.Framework;

namespace Algorithm.Tests
{
	[TestFixture]
	class GCDClassTests
	{
		static object[] Test =
		{
			new object[] { new int[] { 5, 0 }, 5 },
			new object[] { new int[] { 0, 15 }, 15 },
			new object[] { new int[] { -3, 3 }, 3 },
			new object[] { new int[] { 52, 13 }, 13 },
			new object[] { new int[] { 52, 26 }, 26 },
			new object[] { new int[] { 0, 0 }, 0 },
			new object[] { new int[] { 5, 0 }, 5 },
			new object[] { new int[] { -7, -14, 21 }, 7 },
			new object[] { new int[] { -5, -100, 1 }, 1 },
			new object[] { new int[] { -2, -4, -6, 8, 10, 16 }, 2 },
			new object[] { new int[] { -16, -8, 4 }, 4 },
			new object[] { new int[] { -50, -10, 40 }, 10 },
		};

		[TestCaseSource("Test")]
		public void EucledianMethod_Array_ReturnGCD(int[] array, int expected)
		{
			int actual = GCD.Euclidean(array);

			Assert.AreEqual(expected, actual);
		}

		[TestCase(null)]
		public void EucledianMethod_Array_ReturnAgrumentNullException(int[] array)
		{
			Assert.Throws<ArgumentNullException>(() => GCD.Euclidean(array));
		}

		[TestCase(new int[] {})]
		public void EucledianMethod_Array_ReturnAgrumentException(int[] array)
		{
			Assert.Throws<ArgumentException>(() => GCD.Euclidean(array));
		}

		[TestCaseSource("Test")]
		public void BinaryMethod_Array_ReturnGCD(int[] array, int expected)
		{
			int actual = GCD.Euclidean(array);

			Assert.AreEqual(expected, actual);
		}

		[TestCase(null)]
		public void BinaryMethod_Array_ReturnAgrumentNullException(int[] array)
		{
			Assert.Throws<ArgumentNullException>(() => GCD.Binary(array));
		}

		[TestCase(new int[] { })]
		public void BinaryMethod_Array_ReturnAgrumentException(int[] array)
		{
			Assert.Throws<ArgumentException>(() => GCD.Binary(array));
		}
	}
}
