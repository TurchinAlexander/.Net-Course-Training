using NUnit.Framework;

namespace NET1.A._2018.Turchin._04.Tests
{
	[TestFixture]
	public class CalculateClassTests
	{
		private static object[] Test =
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
			}
		};

		[TestCaseSource("Test")]
		public void TransformToWordsMethod_DoubleArray_ReturnStringArray(double[] array, string[] expected)
		{
			string[] result = Calculate.TransformToWords(array);

			Assert.IsTrue(Execute.CheckStringArrays(expected, result));
		}

		[TestCase(-255.255, ExpectedResult =
			"1100000001101111111010000010100011110101110000101000111101011100")]
		[TestCase(255.255, ExpectedResult =
			"0100000001101111111010000010100011110101110000101000111101011100")]
		[TestCase(4294967295.0, ExpectedResult =
			"0100000111101111111111111111111111111111111000000000000000000000")]
		[TestCase(double.MinValue, ExpectedResult =
			"1111111111101111111111111111111111111111111111111111111111111111")]
		[TestCase(double.MaxValue, ExpectedResult = 
			"0111111111101111111111111111111111111111111111111111111111111111")]
		[TestCase(double.Epsilon, ExpectedResult =
			"0000000000000000000000000000000000000000000000000000000000000001")]
		[TestCase(double.NaN, ExpectedResult =
			"1111111111111000000000000000000000000000000000000000000000000000")]
		[TestCase(double.NegativeInfinity, ExpectedResult =
			"1111111111110000000000000000000000000000000000000000000000000000")]
		[TestCase(double.PositiveInfinity, ExpectedResult =
			"0111111111110000000000000000000000000000000000000000000000000000")]
		[TestCase(-0.0, ExpectedResult =
			"1000000000000000000000000000000000000000000000000000000000000000")]
		[TestCase(0.0, ExpectedResult =
			"0000000000000000000000000000000000000000000000000000000000000000")]
		public string DoubleToBinMethod_Double_StringDoubleInBin(double number)
		{
			return number.ToBinary();
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
