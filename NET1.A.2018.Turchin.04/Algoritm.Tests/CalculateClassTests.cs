using NUnit.Framework;

namespace NET1.A._2018.Turchin._04.Tests
{
	[TestFixture]
	public class CalculateClassTests
	{
		private static object[] TestVerbal =
		{
			new object[] 
			{
				new double[] { 0 },
				new string[] { "zero" }
			},
			new object[] 
			{
				new double[] {-23.809, 0.295, 15.17 },
				new string[] { "minus two three point eight zero nine", "zero point two nine five", "one five point one seven" }
			},
			new object[]
			{
				new double[] {double.NaN, double.PositiveInfinity, double.NegativeInfinity },
				new string[] { "Nan", "Positive Infinite", "Negative Infinite" }
			},

		};

		private static object[] TestBinary =
		{
			new object[]
			{
				-255.255,
				"1100000001101111111010000010100011110101110000101000111101011100"
			},
			new object[]
			{
				255.255,
				"0100000001101111111010000010100011110101110000101000111101011100"
			},
			new object[]
			{
				4294967295.0,
				"0100000111101111111111111111111111111111111000000000000000000000"
			},
			new object[]
			{
				double.MinValue,
				"1111111111101111111111111111111111111111111111111111111111111111"
			},
			new object[]
			{
				double.MaxValue,
				"0111111111101111111111111111111111111111111111111111111111111111"
			},
			new object[]
			{
				double.Epsilon,
				"0000000000000000000000000000000000000000000000000000000000000001"
			},
			new object[]
			{
				double.NaN,
				"1111111111111000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				double.NegativeInfinity,
				"1111111111110000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				double.PositiveInfinity,
				"0111111111110000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				-0.0,
				"1000000000000000000000000000000000000000000000000000000000000000"
			},
			new object[]
			{
				0.0,
				"0000000000000000000000000000000000000000000000000000000000000000"
			}
		};

		[TestCaseSource("TestVerbal")]
		public void TransformToWordsMethod_DoubleArray_ReturnStringArray(double[] array, string[] expected)
		{
			string[] result = Calculate.TransformToWords(array);

			Assert.IsTrue(Execute.CheckStringArrays(expected, result));
		}

		[TestCaseSource("TestBinary")]
		public void DoubleToBinMethod_Double_StringDoubleInBin(double number, string expected)
		{
			string result = number.ToBinary();

			Assert.IsTrue(expected.Equals(result));
		}
	}

	class Execute
	{
		public static bool CheckStringArrays(string[] a, string[] b)
		{
			bool isTrue = true;

			for (int i = 0; (i < a.Length) && isTrue; i++)
			{
				isTrue = a[i].Equals(b[i]);
			}

			return isTrue;
		}
	}
}
