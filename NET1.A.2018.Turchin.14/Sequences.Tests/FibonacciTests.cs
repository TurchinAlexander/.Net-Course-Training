using System;
using System.Text;
using System.Numerics;
using NUnit.Framework;

namespace Sequences.Tests
{
	[TestFixture]
    public class FibonacciTests
    {
		static object[] RightCount = new object[]
		{
			new object[] { 1, "0" },
			new object[] { 2, "0, 1" },
			new object[] { 5, "0, 1, 1, 2, 3" },
			new object[] { 10, "0, 1, 1, 2, 3, 5, 8, 13, 21, 34" }
		};

		static object[] RightRange = new object[]
		{
			new object[] { 0, 0, "0" },
			new object[] { 0, 1, "0, 1" },
			new object[] { 0, 4, "0, 1, 1, 2, 3" },
			new object[] { 0, 9, "0, 1, 1, 2, 3, 5, 8, 13, 21, 34" },
			new object[] { 1, 4, "1, 1, 2, 3" },
			new object[] { 3, 4, "2, 3" },
			new object[] { 8, 10, "21, 34, 55" }
		};

		[TestCaseSource("RightCount")]
		public void GetSequenceMethod_RightCount_RightSequence(int count, string expected)
		{
			string actual = Fibonacci.GetSequence(count).ConvertToString();

			Assert.IsTrue(expected.Equals(actual));
		}

		[TestCaseSource("RightRange")]
		public void GetSequenceMethod_RightRange_RightSequence(int firstIndex, int secondIndex, string expected)
		{
			string actual = Fibonacci.GetSequence(firstIndex, secondIndex).ConvertToString();

			Assert.IsTrue(expected.Equals(actual));
		}

		[TestCase(-1)]
		[TestCase(0)]
		public void GetSequenceMethod_WrondCount_Exception(int count)
		{
			Assert.Throws<ArgumentException>(() => Fibonacci.GetSequence(count));
		}

		[TestCase(-4, -1)]
		[TestCase(-4, 0)]
		[TestCase(5, -5)]
		[TestCase(1, 0)]
		[TestCase(4, 3)]
		public void GetSequenceMethod_WrondRange_Exception(int firstIndex, int secondIndex)
		{
			Assert.Throws<ArgumentException>(() => Fibonacci.GetSequence(firstIndex, secondIndex));
		}
	}


	public static class Coverts
	{
		public static string ConvertToString(this BigInteger[] array)
		{
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i]);
				stringBuilder.Append(", ");
			}

			stringBuilder.Length -= 2;

			return stringBuilder.ToString();
		}
	}
}
